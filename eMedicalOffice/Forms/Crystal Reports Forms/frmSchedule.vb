Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmSchedule
    Private PressedKey As String = ""
    Public ReturnSchPickupTransportation As Integer
    Public ReturnSchDestinationTransportation As Integer
    Public ReturnSchName As String
    Public ReturnScheduleID As Long
    Public ReturnUserID As Long
    Private LoadingInd As Boolean
    Public Sub New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    End Sub
    Private Sub Calculate_Totals()
        Dim TL As Long = 0
        Dim CT As Long = 0
        Dim CD As Long = 0
        Dim WG As Long = 0
        Dim NS As Long = 0
        Dim R As Long = 0
        Dim C As Long = 0
        For R = 0 To FpSpreadSchedule.ActiveSheet.RowCount - 1
            For C = 2 To FpSpreadSchedule.ActiveSheet.ColumnCount - 1
                If FpSpreadSchedule.ActiveSheet.Cells(R, C).Text <> "" Then
                    TL += 1
                End If
                Select Case FpSpreadSchedule.ActiveSheet.Cells(R, C).BackColor
                    Case Color.Violet ' Waiting
                        WG += 1
                    Case Color.BurlyWood ' Confirmed
                        If CDate(FormatDateTime(DateTimePicker1.Value.Date, 2)) < CDate(FormatDateTime(Now, 2)) Then
                            NS += 1
                        Else
                            CD += 1
                        End If
                    Case Color.MediumAquamarine ' Complete
                        CT += 1
                    Case Color.Khaki
                        If CDate(FormatDateTime(DateTimePicker1.Value.Date, 2)) < CDate(FormatDateTime(Now, 2)) Then
                            NS += 1
                        End If
                End Select
            Next
        Next


        ToolStripStatusTotal.Text = "Total: " & TL
        ToolStripStatusComplete.Text = "Complete: " & CT
        ToolStripStatusConfirmed.Text = "Confirmed: " & CD
        ToolStripStatusWaiting.Text = "Waiting: " & WG
        ToolStripStatusNoShow.Text = "NoShow: " & NS
    End Sub
    Private Sub Schedule_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gSpread_Settings(Me, FpSpreadSchedule, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            Exit Sub
        End If
    End Sub
    Private Sub Schedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SPHeight As Integer
        Dim I As Integer
        Dim H As ToolStripControlHost
        Me.DoubleBuffered = True
        H = New ToolStripControlHost(DateTimePicker1)
        ToolStrip1.Items.Insert(3, H)
        FpSpreadSchedule.SetCursor(FarPoint.Win.Spread.CursorType.Normal, System.Windows.Forms.Cursors.Default)
        FpSpreadSchedule.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, System.Windows.Forms.Cursors.Default)

        gWindow_Settings(Me, ReadWrite.sRead)
        Application.DoEvents()
        Setup_Spread()
        LoadingInd = True
        DateTimePicker1.Value = Now
        LoadingInd = False
        Setup_Diags()
        For I = 0 To FpSpreadDetails_Sheet1.RowCount - 1
            FpSpreadDetails_Sheet1.SetRowHeight(I, CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight))
            SPHeight = SPHeight + CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight)
        Next
        FpSpreadDetails.Height = SPHeight
        FpSpreadProcedures.ActiveSheet.RowCount = 0
        Load_Schedule()
        Setup_Menus()
        Timer1_Tick(Nothing, Nothing)
    End Sub
    Private Sub Setup_Spread()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim FP As FarPoint.Win.Spread.SheetView
        Dim I As Integer = 0
        Dim P As Integer
        ' Office Settings
        Dim StartTime As Integer
        Dim WorkDayHours As Integer
        Dim SplitInterval As Integer
        Dim NumberPatientsPerInterval As Integer

        SQL = "SELECT     OfficeID, StartTime, WorkDayHours, SplitInterval, NumberPatientsPerInterval FROM Offices WHERE OfficeID = " & gOfficeID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        If Reader.Read = True Then
            StartTime = CInt(Val(Reader("StartTime").ToString) - 1)     ' Baecause the first hour starts from StartTime +1
            WorkDayHours = CInt(Val(Reader("WorkDayHours").ToString))
            SplitInterval = CInt(Val(Reader("SplitInterval").ToString))
            NumberPatientsPerInterval = CInt(Val(Reader("NumberPatientsPerInterval").ToString))
        Else
            Exit Sub
        End If
        Reader = Nothing
        FP = FpSpreadSchedule.ActiveSheet
        With FP
            .RowCount = 0
            For I = 0 To CInt(((60 / SplitInterval) * WorkDayHours) - 1)
                If I Mod (60 / SplitInterval) = 0 Then
                    StartTime = StartTime + 1
                End If
                For P = 0 To NumberPatientsPerInterval - 1
                    .RowCount = .RowCount + 1
                    .Cells(.RowCount - 1, 0).Text = CDate(StartTime & ":00").ToString("hh tt")
                    .Cells(.RowCount - 1, 1).Text = CDate("1:" & (I Mod (60 / SplitInterval)) * SplitInterval).ToString("mm")
                Next
            Next
            .SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always)
            .SetColumnMerge(1, FarPoint.Win.Spread.Model.MergePolicy.Always)
        End With
    End Sub

    Private Sub Setup_Diags()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim FP As FarPoint.Win.Spread.SheetView
        Dim I As Integer = 0
        Dim CurDate As String
        ' Setup Cell Type
        Dim CT As New FarPoint.Win.Spread.CellType.TextCellType
        CurDate = DateTimePicker1.Value.DayOfWeek.ToString.Substring(0, 2)
        SQL = "SELECT Su, Mo, Tu, We, Th, Fr, Sa, OfficeDiagnostics.DiagID, DiagName FROM OfficeDiagnostics inner Join Diagnostics on OfficeDiagnostics.DiagID = Diagnostics.DiagID WHERE OfficeID = " & gOfficeID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        FP = FpSpreadSchedule.ActiveSheet
        gSpread_Settings(Me, FpSpreadSchedule, ReadWrite.sWrite)
        With FP
            .ColumnCount = 2
            Do Until Reader.Read = False
                .ColumnCount = .ColumnCount + 1
                .Columns(.ColumnCount - 1).CellType = CT
                .ColumnHeader.Columns(.ColumnCount - 1).Label = "" & Reader("DiagName").ToString
                .ColumnHeader.Columns(.ColumnCount - 1).Tag = "" & Reader("DiagID").ToString
                If Reader(CurDate).ToString = "1" Then
                    .ColumnHeader.Columns(.ColumnCount - 1).Locked = False
                    .Columns(.ColumnCount - 1).BackColor = Color.White
                    .Columns(.ColumnCount - 1).Locked = False
                Else
                    .ColumnHeader.Columns(.ColumnCount - 1).Locked = True
                    .Columns(.ColumnCount - 1).BackColor = Color.Silver
                    .Columns(.ColumnCount - 1).Locked = True
                End If
            Loop
            Reader = Nothing
        End With
        gSpread_Settings(Me, FpSpreadSchedule, ReadWrite.sRead)
    End Sub

    Private Sub FpSpreadSchedule_DragDropBlock(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.DragDropBlockEventArgs) Handles FpSpreadSchedule.DragDropBlock
        Dim C As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.Cells(e.RowBegin, e.ColumnBegin)
        Dim CD As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.Cells(e.DestinationRowBegin, e.DestinationColumnBegin)
        Dim DiagName As String
        Dim SaveColor As Color = C.BackColor

        DiagName = FpSpreadSchedule.ActiveSheet.ColumnHeader.Columns(e.ColumnBegin).Label
        If e.ColumnBegin = 0 Then
            e.Action = 0
            e.Cancel = True
            Exit Sub
        End If
        If e.ColumnBegin = 1 Then
            e.Action = 0
            e.Cancel = True
            Exit Sub
        End If

        If C.Text = "" Then
            e.Action = 0
            e.Cancel = True
            Exit Sub
        End If
        If C.BackColor = Color.MediumAquamarine Then
            MsgBox("Unable to move Completted schedule.", MsgBoxStyle.Exclamation)
            e.Action = 0
            e.Cancel = True
            FpSpreadSchedule.ActiveSheet.SetActiveCell(e.RowBegin, e.ColumnBegin)
            Exit Sub
        End If
        If CD.Text <> "" Then
            MsgBox("Unable to move schedule. The schedule time is busy.", MsgBoxStyle.Exclamation)
            e.Action = 0
            e.Cancel = True
            FpSpreadSchedule.ActiveSheet.SetActiveCell(e.RowBegin, e.ColumnBegin)
            Exit Sub
        End If
        If CD.Locked Then
            MsgBox("Unable to move schedule to the past time.", MsgBoxStyle.Exclamation)
            e.Action = 0
            e.Cancel = True
            FpSpreadSchedule.ActiveSheet.SetActiveCell(e.RowBegin, e.ColumnBegin)
            Exit Sub
        End If
        If e.ColumnBegin <> e.DestinationColumnBegin Then
            MsgBox("The [" & DiagName & "] schedule can be moved within the same [" & DiagName & "] diagnostic only.", MsgBoxStyle.Exclamation)
            e.Action = 0
            e.Cancel = True
            FpSpreadSchedule.ActiveSheet.SetActiveCell(e.RowBegin, e.ColumnBegin)
            Exit Sub
        End If
        If C.BackColor = Color.Violet Then
            MsgBox("Unable to reschedule appointment is the patient is already Shows Up", MsgBoxStyle.Exclamation)
            e.Action = 0
            e.Cancel = True
            FpSpreadSchedule.ActiveSheet.SetActiveCell(e.RowBegin, e.ColumnBegin)
            Exit Sub
        End If
        e.Action = 0
        e.Cancel = False
    End Sub
    Private Sub FpSpreadSchedule_DragDropBlockCompleted(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.DragDropBlockCompletedEventArgs) Handles FpSpreadSchedule.DragDropBlockCompleted
        Dim C As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.Cells(e.RowBegin, e.ColumnBegin)
        Dim CD As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.Cells(e.DestinationRowBegin, e.DestinationColumnBegin)
        Dim SchH As Integer = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(CD.Row.Index, 0).Text))
        Dim SchM As Integer = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(CD.Row.Index, 1).Text))
        Dim SchAM As String = FpSpreadSchedule.ActiveSheet.Cells(CD.Row.Index, 0).Text.Substring(3, 2)
        Dim ScheduleDateTime As Date = CDate(DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " " & SchH & ":" & SchM & " " & SchAM)
        Dim SI As ScheduleInfo = Nothing
        SI.PickupTransportation = 0
        SI.DestinationTransportation = 0
        SI.ScheduleID = 0
        SI.PatientID = 0
        C.Tag = SI
        CD.Locked = False
        gSQLUpdateData("UPDATE Schedule set ScheduleDateTime='" & ScheduleDateTime & "' Where  ScheduleID=" & CType(CD.Tag, ScheduleInfo).ScheduleID)
        gUpdate_Profile_Log(CType(CD.Tag, ScheduleInfo).PatientID, PatientLogTypes.tScheduleChanged)
        Timer1_Tick(Nothing, Nothing)
    End Sub
    Private Sub FpSpread1_EditModeOn(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpreadSchedule.EditModeOn
        If FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.MediumAquamarine Then
            FpSpreadSchedule.EditMode = False
            Exit Sub
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.Text <> "" Then
            FpSpreadSchedule.EditMode = False
            MarkAsDoneToolStripMenuItem_Click(Nothing, Nothing)
            Exit Sub
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.Locked Then
            FpSpreadSchedule.EditMode = False
            Exit Sub
        End If

        If FpSpreadSchedule.ActiveSheet.ActiveCell.Text = "" Then FpSpreadSchedule.ActiveSheet.ActiveCell.Text = PressedKey
        Application.DoEvents()
        frmScheduleSearchPopup.CalledForm = Me
        frmScheduleSearchPopup.SchDiagID = CLng(FpSpreadSchedule.ActiveSheet.ColumnHeader.Columns(FpSpreadSchedule.ActiveSheet.ActiveColumn.Index).Tag)
        frmScheduleSearchPopup.SchDiagName = FpSpreadSchedule.ActiveSheet.ActiveColumn.Label
        frmScheduleSearchPopup.SchActiveCell = FpSpreadSchedule.ActiveSheet.ActiveCell
        frmScheduleSearchPopup.TextBoxSearch.Text = FpSpreadSchedule.ActiveSheet.ActiveCell.Text
        frmScheduleSearchPopup.TextBoxSearch.SelectionStart = Len(frmScheduleSearchPopup.TextBoxSearch.Text)
        frmScheduleSearchPopup.SchH = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(FpSpreadSchedule.ActiveSheet.ActiveCell.Row.Index, 0).Text))
        frmScheduleSearchPopup.SchM = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(FpSpreadSchedule.ActiveSheet.ActiveCell.Row.Index, 1).Text))
        frmScheduleSearchPopup.SchAM = FpSpreadSchedule.ActiveSheet.Cells(FpSpreadSchedule.ActiveSheet.ActiveCell.Row.Index, 0).Text.Substring(3, 2)
        frmScheduleSearchPopup.SchDate = DateTimePicker1.Value.Date
        If frmScheduleSearchPopup.ListViewPatients.SelectedItems.Count > 0 Then
            frmScheduleSearchPopup.Show_Details(CLng(frmScheduleSearchPopup.ListViewPatients.SelectedItems(0).Tag))
        End If
        FpSpreadSchedule.EditMode = False
        ReturnSchName = ""
        ReturnScheduleID = 0
        ReturnSchPickupTransportation = 0
        ReturnSchDestinationTransportation = 0
        Dim SaveRow As Integer = FpSpreadSchedule.ActiveSheet.ActiveRowIndex
        Dim SaveCol As Integer = FpSpreadSchedule.ActiveSheet.ActiveColumnIndex
        'Dim SI As ScheduleInfo
        If frmScheduleSearchPopup.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Load_Schedule()
            Timer1_Tick(Nothing, Nothing)
            FpSpreadSchedule.ActiveSheet.SetActiveCell(SaveRow, SaveCol)
            gLockWindowUpdate(Me.Handle, False)
            Show_Details(ReturnUserID)
            gLockWindowUpdate(Me.Handle, True)
        Else
            If FpSpreadSchedule.ActiveSheet.ActiveCell.Text.Length = 1 Then
                FpSpreadSchedule.ActiveSheet.ActiveCell.Text = ""
            End If
        End If
        PressedKey = ""
        Setup_Menus()

    End Sub
    Private Sub ClearScheduleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearScheduleToolStripMenuItem.Click
        Dim SI As ScheduleInfo = Nothing
        Dim CL As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.ActiveCell
        Dim ApprovedByID As Long = 0
        Dim ApprovedByName As String = ""
        Dim Comments As String = ""
        Dim AmountPaid As Double = 0
        Dim BillID As Long
        FpSpreadSchedule.Focus()
        If CL Is Nothing Then Exit Sub
        If Val(CType(CL.Tag, ScheduleInfo).ScheduleID) = 0 Then Exit Sub

        Dim SchH As Integer = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(FpSpreadSchedule.ActiveSheet.ActiveRowIndex, 0).Text))
        Dim SchM As Integer = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(FpSpreadSchedule.ActiveSheet.ActiveRowIndex, 1).Text))
        Dim SchAM As String = FpSpreadSchedule.ActiveSheet.Cells(FpSpreadSchedule.ActiveSheet.ActiveRowIndex, 0).Text.Substring(3, 2)
        Dim SchDate As String = DateTimePicker1.Value.Date
        Dim ScheduleTime As String = SchDate & " " & SchH & ":" & SchM & SchAM
        Dim PatientID As Long = CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).CaseTypeID
        If CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).CaseTypeID = 4 And FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.Violet Then
            AmountPaid = gSQLGetSingleValue("select BillAmount from Bills where ScheduleID = " & CType(CL.Tag, ScheduleInfo).ScheduleID)
            BillID = gSQLGetSingleValue("select BillID from Bills where ScheduleID = " & CType(CL.Tag, ScheduleInfo).ScheduleID)
            If gCurrentEmployee.PositionID > 3 Then
                frmSupervisorApproval.LabelMsg.Text = "Cash Appointment Cancelation." & vbCrLf & vbCrLf & "Refund " & AmountPaid.ToString("c") & " requested."
                If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    frmSupervisorApproval.Dispose()
                    Exit Sub
                End If
                ApprovedByID = frmSupervisorApproval.SupervisorID
                ApprovedByName = frmSupervisorApproval.SupervisorName
                frmSupervisorApproval.Dispose()
                Comments = "Cash Schedule " & ScheduleTime & " Cancelation And Payment " & AmountPaid.ToString("c") & " Refund Approved"
            Else
                If MsgBox("Cash Appointment Cancelation." & vbCrLf & vbCrLf & "Refund " & AmountPaid.ToString("c") & " requested." & vbCrLf & vbCrLf & "Are you approving this cancelation?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = vbNo Then
                    Exit Sub
                End If
                Comments = "Cash Schedule " & ScheduleTime & " Cancelation And Payment " & AmountPaid & " Refund Approved"
                ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
            End If
            MsgBox("Appointment has been canceled." & vbCrLf & vbCrLf & "Please refund " & AmountPaid.ToString("c") & " to patient.", MsgBoxStyle.Information)
            gUpdate_Profile_Log(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID, PatientLogTypes.tScheduleCanceled, Comments, ApprovedByName)
            gSQLUpdateData("UPDATE BILLS SET BillStatusID=8 WHERE BillID=" & BillID)
        Else
            If MsgBox("Please confirm you want to Cancel Appointment for the " & CL.Text & "?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            gUpdate_Profile_Log(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID, PatientLogTypes.tScheduleCanceled, "Canceled Schedule  " & ScheduleTime, ApprovedByName)
        End If
        gSQLUpdateData("UPDATE PatientProcedures set PatientSignature=Null, TechSignature=null, UpdatedByEmpID=" & gCurrentEmployee.EmpID.ToString & ", UpdatedDT=getdate(), ProcedureStatusID = 0, ScheduleID=Null Where ScheduleID=" & CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).ScheduleID)
        gSQLDeleteRecord("Delete From Schedule Where ScheduleID=" & CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).ScheduleID)
        '1- Reschedule
        '2-Cancelation
        'If FormatDateTime(ScheduleTime, 2) = FormatDateTime(Now, 2) Then
        gSQLUpdateData("INSERT INTO PatientReschedulesCancelations (PatientID, ReScheduleCancelInd, Comments, ProcessedBy) VALUES(" & Val(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID) & ",2,'" & ScheduleTime & "'," & gCurrentEmployee.EmpID & " )")
        'End If

        SI.PickupTransportation = 0
        SI.DestinationTransportation = 0
        SI.ScheduleID = 0
        SI.PatientID = 0
        CL.Text = ""
        CL.Tag = SI
        Clear_Details()
        CL.BackColor = Color.White
        CL.CellType = Nothing
        Calculate_Totals()
        Timer1_Tick(Nothing, Nothing)
    End Sub
    Public Sub Clear_Details()
        Dim I As Integer
        Dim SPHeight As Integer

        FpSpreadDetails_Sheet1.RowCount = 12
        '        FpSpreadDetails_Sheet1.Visible = False
        For I = 0 To FpSpreadDetails_Sheet1.RowCount - 1
            FpSpreadDetails_Sheet1.SetText(I, 1, "")
            FpSpreadDetails_Sheet1.SetRowHeight(I, CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight))
            SPHeight = SPHeight + CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight)
        Next
        PatientComments = ""
        FpSpreadDetails.Height = SPHeight
        FpSpreadProcedures.ActiveSheet.RowCount = 0
        gSpreadActivateCell(FpSpreadDetails)
        gSpreadActivateCell(FpSpreadProcedures)

    End Sub

    Private Sub FindPatientToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FindPatientToolStripMenuItem.Click
        Dim CL As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.ActiveCell
        FpSpreadSchedule.Focus()
        If CL Is Nothing Then Exit Sub
        FpSpreadSchedule.ActiveSheet.ActiveRowIndex = CL.Row.Index
        If CL.Column.Index < 2 Then
            FpSpreadSchedule.ActiveSheet.ActiveColumnIndex = 2
        Else
            FpSpreadSchedule.ActiveSheet.ActiveColumnIndex = CL.Column.Index
        End If
        FpSpreadSchedule.EditMode = True
    End Sub
    Public Sub FpSpread1_EnterCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EnterCellEventArgs) Handles FpSpreadSchedule.EnterCell
        Panel3.SuspendLayout()
        If FpSpreadSchedule.ActiveSheet.ActiveCell Is Nothing Then Exit Sub

        If e.Column < 2 Then
            PrintProceduresFormToolStripMenuItem.Visible = False
            cmdProcedureForm.Enabled = False
            FindPatientToolStripMenuItem.Visible = False
            TransportationToolStripMenuItem.Visible = False
            MarkAsDoneToolStripMenuItem.Visible = False
            ShowPatientsInformationToolStripMenuItem.Visible = False
            cmdComments.Enabled = False
            CommentsToolStripMenu.Visible = False
            ShowPatientInfoToolStripSeparator1.Visible = False
            ClearScheduleToolStripMenuItem.Visible = False
            CancelAppointmentToolStripSeparator1.Visible = False
            cmdTransport.Enabled = False
            cmdAdd.Enabled = False
            cmdDelete.Enabled = False
            cmdDone.Enabled = False
            SetAsUnDoneToolStripMenuItem.Visible = False
            Exit Sub
        End If
        LockWindowUpdate(Panel3.Handle)
        If Val(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID) <> 0 Then
            Show_Details(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID)
        Else
            Clear_Details()
        End If
        Panel3.ResumeLayout()
        LockWindowUpdate(0)
        Setup_Menus()

    End Sub
    Public PatientComments As String
    Public Sub Show_Details(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim lCell As String
        Dim I As Integer
        Dim SPHeight As Integer
        Dim CR As Integer
        Clear_Details()
        'Panel3.SuspendLayout()
        gSpreadActivateCell(FpSpreadDetails, 0, 0, True)
        gSpreadActivateCell(FpSpreadProcedures, 0, 0, True)

        gLockWindowUpdate(Panel3.Handle, False)
        SQL = "SELECT  CaseTypes.Description as CaseType, Patients.NoMoreAppointmentsInd, Patients.CaseTypeID, Patients.ParentsRequiredInd, Patients.DOA, Patients.PatientID,  Patients.FName, Patients.MI, Patients.LName, Patients.DOB, Patients.Phone1, Patients.Phone2, Patients.CellPhone, Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, InsuranceCompanies_1.CompanyName AS Insurance1, InsuranceCompanies.CompanyName AS Insurance2, "
        SQL = SQL & " Patients.ReferringDoctor, ReferringOffices.OfficeName AS ReferringCompany, ReferringOffices.Phone1 AS RefPhone1, ReferringOffices.Phone2 AS RefPhone2, ReferringOffices.Phone3 AS RefPhone3, "
        SQL = SQL & " TransportationCompanies.CompanyName AS Transportation, TransportationCompanies.Phone1 AS TransPhone1, TransportationCompanies.Phone2 AS TransPhone2, TransportationCompanies.Phone3 AS TransPhone3, Patients.Comments "
        SQL = SQL & " FROM Patients LEFT OUTER JOIN TransportationCompanies ON Patients.TransportationCompanyID = TransportationCompanies.CompanyID LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID1 = InsuranceCompanies.CompanyID LEFT OUTER JOIN InsuranceCompanies AS InsuranceCompanies_1 ON Patients.InsuranceCompanyID = InsuranceCompanies_1.CompanyID Inner Join CaseTypes on Patients.CaseTypeID = CaseTypes.CaseTypeID"
        SQL = SQL & " WHERE Patients.PatientID = " & ID
        CR = gSQLGetSingleValue("select COUNT(*) from PatientReschedulesCancelations Where PatientID =" & ID)
        Reader = gSQLGetDataReader(SQL.ToString())

        If Reader Is Nothing Then Exit Sub
        Panel3.SuspendLayout()
        FpSpreadDetails.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        FpSpreadProcedures.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        With FpSpreadDetails_Sheet1
            Do Until Reader.Read = False
                PatientComments = Reader("Comments").ToString.Trim
                .SetText(0, 1, Reader("PatientID").ToString & "   /   " & Reader("CaseType").ToString & "   /   " & "CR: " & CR)
                .Cells(0, 1).Tag = Val(Reader("CaseTypeID").ToString)

                If CR >= gCancelationDrop Then
                    .Cells(0, 1).ForeColor = Color.Red
                    .Cells(0, 0).ForeColor = Color.Red
                    .SetText(0, 1, .GetText(0, 1) & " - DROP")
                ElseIf CR >= gCancelationWarning Then
                    .Cells(0, 1).ForeColor = Color.Red
                    .Cells(0, 0).ForeColor = Color.Red
                    .SetText(0, 1, .GetText(0, 1) & "  !!!")
                Else
                    .Cells(0, 1).ForeColor = Color.Black
                    .Cells(0, 0).ForeColor = Color.Black
                End If
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
                If Val(Reader("NoMoreAppointmentsInd").ToString) > 0 Or CR >= gCancelationDrop Then
                    .RowCount = .RowCount + 1
                    .SetText(.RowCount - 1, 0, "Attention")
                    If Val(Reader("NoMoreAppointmentsInd").ToString) = 0 Then
                        .SetText(.RowCount - 1, 1, "No More Appointments! [CR]")
                    Else
                        .SetText(.RowCount - 1, 1, "No More Appointments!")
                    End If
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
        FpSpreadProcedures.Top = SPHeight
        FpSpreadProcedures.Height = 1000
        SQL = "SELECT     PatientProcedures.PatientProcedureID, PatientProcedures.ProcID, PatientProcedures.DiagID, PatientProcedures.ProcedureStatusID, Procedures.ProcName, Schedule.ScheduleDateTime "
        SQL = SQL & " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
        SQL = SQL & " WHERE PatientProcedures.PatientID = " & ID
        SQL = SQL & " Order by PatientProcedures.ProcID "
        Reader = gSQLGetDataReader(SQL.ToString())
        FpSpreadProcedures.ActiveSheet.RowCount = 0

        If Reader Is Nothing Then Panel3.ResumeLayout(True) : Exit Sub
        With FpSpreadProcedures.ActiveSheet
            Do Until Reader.Read = False

                .RowCount = .RowCount + 1
                .SetText(.RowCount - 1, 0, Val(Reader("ProcedureStatusID").ToString).ToString)
                .SetText(.RowCount - 1, 1, Reader("ProcName").ToString)
                If Reader("ScheduleDateTime").ToString <> "" Then
                    If Val(Reader("ProcedureStatusID").ToString) = 1 And DateDiff(DateInterval.Hour, CDate(Reader("ScheduleDateTime")), Now) > gNoShowHours Then
                        .Cells(.RowCount - 1, 1).ForeColor = Color.DarkRed
                        .Cells(.RowCount - 1, 1).Font = New Font(FpSpreadProcedures.Font, FontStyle.Bold)
                    End If
                End If
                .SetRowHeight(.RowCount - 1, CInt(.Rows(.RowCount - 1).GetPreferredHeight + 2))
            Loop
        End With

        'FpSpreadProcedures.Dock = DockStyle.Fill
        'Panel3.ResumeLayout(True)

        gSpreadActivateCell(FpSpreadDetails)
        gSpreadActivateCell(FpSpreadProcedures)
        'FpSpreadDetails_Sheet1.Visible = True
        gLockWindowUpdate(Panel3.Handle, True)

    End Sub
    Public Sub Load_Schedule()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim AppTime As DateTime
        Dim SchH As Integer
        Dim SchM As Integer
        Dim SchAM As String
        Dim I As Integer
        Dim C As Integer
        Dim SI As ScheduleInfo = Nothing
        Application.DoEvents()
        If LoadingInd = True Then Exit Sub
        SI.ScheduleID = 0
        SI.PatientID = 0
        SI.ScheduleID = 0
        SI.PickupTransportation = 0
        SI.DestinationTransportation = 0
        SI.ToolTip = ""
        For I = 0 To FpSpreadSchedule.ActiveSheet.RowCount - 1
            For C = 2 To FpSpreadSchedule.ActiveSheet.ColumnCount - 1
                SI.PatientID = 0
                SI.ScheduleID = 0
                SI.PickupTransportation = 0
                SI.DestinationTransportation = 0
                FpSpreadSchedule.ActiveSheet.Cells(I, C).Text = ""
                FpSpreadSchedule.ActiveSheet.Cells(I, C).Tag = SI
                FpSpreadSchedule.ActiveSheet.Cells(I, C).CellType = Nothing
                If FpSpreadSchedule.ActiveSheet.Columns(C).Locked = False Then
                    FpSpreadSchedule.ActiveSheet.Cells(I, C).BackColor = Color.Transparent
                End If
            Next
        Next
        SQL = "SELECT  Schedule.ConfirmedBy, Schedule.ShowUpDatetime, Schedule.ToolTip, Patients.Phone1, Patients.Phone2, Patients.CellPhone, Patients.CaseTypeID, Patients.FName, Patients.MI, Patients.LName, Schedule.ScheduleID, PatientProcedures.DiagID, Schedule.PickupTransportation, Schedule.DestinationTransportation, Schedule.ScheduleDateTime, PatientProcedures.PatientID, MIN(PatientProcedures.ProcedureStatusID) AS ScheduleStatusID"
        SQL = SQL & " FROM PatientProcedures INNER JOIN Patients ON Patients.PatientID = PatientProcedures.PatientID INNER JOIN Schedule ON Schedule.ScheduleID = PatientProcedures.ScheduleID "
        SQL = SQL & " WHERE PatientProcedures.ProcedureStatusID<>0 and PatientProcedures.OfficeID = " & gOfficeID & " and ScheduleDateTime > '" & DateTimePicker1.Value.Date & " 00:00" & "' and ScheduleDateTime < '" & DateTimePicker1.Value.Date & " 23:59" & "' "
        SQL = SQL & " GROUP BY  Schedule.ConfirmedBy, Schedule.ShowUpDatetime, Schedule.ToolTip, Patients.Phone1, Patients.Phone2, Patients.CellPhone, Patients.CaseTypeID, Patients.FName, Patients.MI, Patients.LName, Schedule.ScheduleID, PatientProcedures.DiagID, Schedule.PickupTransportation, Schedule.DestinationTransportation, Schedule.ScheduleDateTime, PatientProcedures.PatientID "
        Reader = gSQLGetDataReader(SQL.ToString())
        Dim ToolTip As String = ""
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False

            AppTime = CDate(CDate(Reader("ScheduleDateTime").ToString).ToString("hh:mm tt"))
            For I = 0 To FpSpreadSchedule.ActiveSheet.RowCount - 1
                SchH = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(I, 0).Text))
                SchM = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(I, 1).Text))
                SchAM = FpSpreadSchedule.ActiveSheet.Cells(I, 0).Text.Substring(3, 2)
                SI = New ScheduleInfo
                If AppTime = CDate(CDate(SchH & ":" & SchM & " " & SchAM).ToString("hh:mm tt")) Then
                    For C = 2 To FpSpreadSchedule.ActiveSheet.ColumnCount - 1
                        ToolTip = ""
                        SI.ScheduleDateTime = AppTime
                        SI.PatientPhone = Reader("Phone1").ToString & IIf(Reader("Phone2").ToString <> "", ", " & Reader("Phone2").ToString, "") & IIf(Reader("Phone2").ToString <> "", ", Cell: " & Reader("CellPhone").ToString, "")
                        SI.PatientID = CLng(Val(Reader("PatientID").ToString))
                        SI.ScheduleID = CLng(Val(Reader("ScheduleID").ToString))
                        SI.PickupTransportation = CInt(Val(Reader("PickupTransportation").ToString))
                        SI.DestinationTransportation = CInt(Val(Reader("DestinationTransportation").ToString))
                        SI.CaseTypeID = CLng(Val(Reader("CaseTypeID").ToString))
                        If IsDate(Reader("ShowUpDatetime").ToString) Then
                            SI.ShowUpDateTime = Reader("ShowUpDatetime").ToString
                        End If
                        SI.ConfirmedBy = Reader("ConfirmedBy").ToString

                        If SI.PickupTransportation = 1 Then
                            ToolTip = ToolTip & "Pickup From Home"
                        ElseIf SI.PickupTransportation = 2 Then
                            ToolTip = ToolTip & "Pickup From Referring Office"
                        End If
                        If ToolTip <> "" Then ToolTip = ToolTip & vbCrLf
                        If SI.DestinationTransportation = 1 Then
                            ToolTip = ToolTip & "Dropoff Home"
                        ElseIf SI.DestinationTransportation = 2 Then
                            ToolTip = ToolTip & "Dropoff Referring Office"
                        End If
                        If ToolTip <> "" Then ToolTip = ToolTip & vbCrLf & vbCrLf
                        ToolTip = ToolTip & Reader("ToolTip").ToString
                        SI.ToolTip = ToolTip
                        If Val(Reader("DiagID").ToString) = Val(FpSpreadSchedule.ActiveSheet.Columns(C).Tag) Then
                            FpSpreadSchedule.ActiveSheet.Cells(I, C).Text = Reader("Fname").ToString & " " & IIf(Reader("MI").ToString <> "", Reader("MI").ToString & " ", "").ToString & Reader("Lname").ToString
                            FpSpreadSchedule.ActiveSheet.Cells(I, C).Tag = SI
                            If Val(Reader("ScheduleStatusID").ToString) = 1 Then
                                If IsDate(Reader("ShowUpDatetime").ToString) Then
                                    FpSpreadSchedule.ActiveSheet.Cells(I, C).BackColor = Color.Violet
                                Else
                                    If Reader("ConfirmedBy").ToString <> "" Then
                                        FpSpreadSchedule.ActiveSheet.Cells(I, C).BackColor = Color.BurlyWood
                                    Else
                                        FpSpreadSchedule.ActiveSheet.Cells(I, C).BackColor = Color.Khaki
                                    End If
                                End If
                            ElseIf Val(Reader("ScheduleStatusID").ToString) = 2 Then
                                FpSpreadSchedule.ActiveSheet.Cells(I, C).BackColor = Color.MediumAquamarine
                                FpSpreadSchedule.ActiveSheet.ActiveCell.Locked = True
                            End If

                            If Val(Reader("PickupTransportation").ToString) > 0 Or Val(Reader("DestinationTransportation").ToString) > 0 Then
                                Dim CT As New FarPoint.Win.Spread.CellType.TextCellType
                                CT.BackgroundImage = New FarPoint.Win.Picture(PictureBoxTransportation.Image)
                                CT.BackgroundImage.AlignHorz = FarPoint.Win.HorizontalAlignment.Right
                                CT.BackgroundImage.AlignVert = FarPoint.Win.VerticalAlignment.Center
                                FpSpreadSchedule.ActiveSheet.Cells(I, C).CellType = CT
                            End If
                            GoTo NextSchedule
                        End If
                    Next
                End If
            Next
NextSchedule:
        Loop
        Calculate_Totals()
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If LoadingInd = True Then Exit Sub
        Application.DoEvents()
        Clear_Details()
        Setup_Diags()
        Load_Schedule()
        Setup_Menus()
        Timer1_Tick(Nothing, Nothing)
    End Sub


    Private Sub FpSpread1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FpSpreadSchedule.KeyPress
        PressedKey = e.KeyChar
    End Sub

    Private Sub FpSpread1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpSpreadSchedule.KeyUp
        PressedKey = ""
    End Sub

    Private Sub FpSpread1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpSpreadSchedule.KeyDown
        If e.KeyCode = 46 Then
            ClearScheduleToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Public Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim I As Integer
        Dim RetH As Integer
        Dim RetM As Integer
        Dim RetAM As String
        Dim C As Integer
        With FpSpreadSchedule.ActiveSheet
            For I = 0 To .RowCount - 1
                RetH = CInt(Val(.GetText(I, 0)))
                RetM = CInt(Val(.GetText(I, 1)))
                RetAM = .GetText(I, 0).Substring(3, 2)
                'If DateAdd(DateInterval.Hour, 10, Now) >= CDate(DateTimePicker1.Value.Date & " " & RetH & ":" & RetM & " " & RetAM) Then
                If Now >= CDate(DateTimePicker1.Value.Date & " " & RetH & ":" & RetM & " " & RetAM) Then
                    For C = 2 To .ColumnCount - 1
                        .Cells(I, C).Locked = True
                        If .Cells(I, C).BackColor <> Color.BurlyWood And .Cells(I, C).BackColor <> Color.Khaki And .Cells(I, C).BackColor <> Color.MediumAquamarine And .Cells(I, C).BackColor <> Color.Violet Then
                            .Cells(I, C).BackColor = Color.Silver
                        End If
                    Next
                End If
            Next
        End With
        Dim T As New Threading.Thread(AddressOf Track_Noshows)
        T.Start()
    End Sub
    Private Sub Track_Noshows()
        Dim SQL As String
        SQL = "INSERT INTO PatientNoShow (ProcedureID, DiagID, PatientID, ScheduleDateTime) "
        SQL = SQL & " SELECT PatientProcedures.ProcID, PatientProcedures.DiagID, PatientProcedures.PatientID, Schedule.ScheduleDateTime"
        SQL = SQL & " FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
        SQL = SQL & " WHERE (DATEDIFF(hh, Schedule.ScheduleDateTime, GETDATE()) > " & gNoShowHours & ") AND (PatientProcedures.ProcedureStatusID = 1) AND (NOT EXISTS(SELECT * FROM PatientNoShow WHERE PatientID = PatientProcedures.PatientID AND ScheduleDateTime = Schedule.ScheduleDateTime AND ProcID = PatientProcedures.ProcID)) "
        gSQLUpdateData(SQL)
        SQL = "Update Schedule set  ShowUpDatetime = null where ShowUpDatetime IS NOT NULL and DATEDIFF(hh, ShowUpDatetime, GETDATE()) > " & gNoShowHours
        gSQLUpdateData(SQL)
        SQL = "Update PatientProcedures set PatientSignature=null, TechSignature = null FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID where ProcedureStatusID=1 and DATEDIFF(hh, ShowUpDatetime, GETDATE()) >" & gNoShowHours
        gSQLUpdateData(SQL)

    End Sub
    Private Sub ContextMenuStripFindPatient_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripFindPatient.Opening

    End Sub

    Private Sub FpSpreadSchedule_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FpSpreadSchedule.MouseDown
        Dim C As Integer
        Dim R As Integer
        C = FpSpreadSchedule.GetCellFromPixel(0, 0, e.X, e.Y).Column
        R = FpSpreadSchedule.GetCellFromPixel(0, 0, e.X, e.Y).Row
        Dim Rp As New FarPoint.Win.Spread.EnterCellEventArgs(Nothing, R, C)
        FpSpread1_EnterCell(sender, Rp)
        If C < 1 And R < 0 Then Exit Sub
        FpSpreadSchedule.ActiveSheet.SetActiveCell(R, C)
        Setup_Menus()
    End Sub
    Public Sub Setup_Menus()
        Dim C As Object
        For Each C In ContextMenuStripFindPatient.Items
            C.Visible = False
        Next
        cmdProcedureForm.Enabled = False
        cmdTransport.Enabled = False
        cmdAdd.Enabled = False
        cmdDelete.Enabled = False
        cmdDone.Enabled = False
        cmdReSchedule.Enabled = False
        cmdComments.Enabled = False


        If FpSpreadSchedule.ActiveSheet.ActiveColumnIndex < 2 Then Exit Sub
        'If FpSpreadSchedule.ActiveSheet.ActiveRowIndex = 0 Then Exit Sub
        If FpSpreadSchedule.ActiveSheet.ActiveCell Is Nothing Then Exit Sub
        ToolStrip1.SuspendLayout()


        If FpSpreadSchedule.ActiveSheet.ActiveCell.Text <> "" Then
            ShowPatientsInformationToolStripMenuItem.Visible = True
            cmdComments.Enabled = True
            CommentsToolStripMenu.Visible = True

            ShowPatientInfoToolStripSeparator1.Visible = True
            ClearScheduleToolStripMenuItem.Visible = True
            ToolStripSeparatorEditSchedule.Visible = True
            EditScheduleToolStripMenuItem.Visible = True
            CancelAppointmentToolStripSeparator1.Visible = True
            TransportationToolStripMenuItem.Visible = False
            cmdTransport.Enabled = False
            PrintProceduresFormToolStripMenuItem.Visible = False
            cmdProcedureForm.Enabled = False

            cmdDelete.Enabled = True
            cmdDone.Enabled = True
            If FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.Violet Then
                RemoveShowUpToolStripMenuItem.Visible = True
                ToolStripSeparatorCoupon.Visible = True
                ToolStripMenuItemCoupon.Visible = True
            Else
                ToolStripSeparatorCoupon.Visible = False
                ToolStripMenuItemCoupon.Visible = False
                RemoveShowUpToolStripMenuItem.Visible = False
                ToolStripSeparatorShowUp.Visible = False
            End If

            If DateDiff(DateInterval.Hour, Now, DateTimePicker1.Value) > gNoShowHours Or DateDiff(DateInterval.Hour, Now, DateTimePicker1.Value) < -gNoShowHours Or FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.Violet Then
                ShowUpToolStripMenuItem.Visible = True
                ConfirmedToolStripMenuItem.Visible = True
                ToolStripSeparatorConfirmed.Visible = True
                ToolStripSeparatorShowUp.Visible = True
                ShowUpToolStripMenuItem.Text = "Present " & Now.ToShortTimeString
            Else
                ShowUpToolStripMenuItem.Visible = False
                ConfirmedToolStripMenuItem.Visible = False
                ToolStripSeparatorConfirmed.Visible = False
                If FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.Violet Then
                    RemoveShowUpToolStripMenuItem.Visible = True
                    ToolStripSeparatorCoupon.Visible = True
                    ToolStripMenuItemCoupon.Visible = True
                Else
                    ToolStripSeparatorCoupon.Visible = False
                    ToolStripMenuItemCoupon.Visible = False
                    RemoveShowUpToolStripMenuItem.Visible = False
                    ToolStripSeparatorShowUp.Visible = False
                End If

            End If

            If DateDiff(DateInterval.Hour, Now, DateTimePicker1.Value) < gNoShowHours Then If gCurrentEmployee.PositionID < 3 Then MarkAsDoneToolStripMenuItem.Visible = True

            If FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor <> Color.Violet Then
                TransportationToolStripMenuItem.Visible = True
            End If
            cmdTransport.Enabled = True
            PrintProceduresFormToolStripMenuItem.Visible = True
            cmdProcedureForm.Enabled = True
        Else
            If FpSpreadSchedule.ActiveSheet.ActiveCell.Locked = False Then
                cmdAdd.Enabled = True
                FindPatientToolStripMenuItem.Visible = True
            End If
            Exit Sub
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.Locked Or FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.MediumAquamarine Then
            FindPatientToolStripMenuItem.Visible = False
            TransportationToolStripMenuItem.Visible = False
            cmdTransport.Enabled = False
            PrintProceduresFormToolStripMenuItem.Visible = False
            cmdProcedureForm.Enabled = False
            ToolStripSeparatorEditSchedule.Visible = False
            EditScheduleToolStripMenuItem.Visible = False
            cmdAdd.Enabled = False
            cmdDelete.Enabled = False
            cmdDone.Enabled = False
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.MediumAquamarine Then
            ClearScheduleToolStripMenuItem.Visible = False
            CancelAppointmentToolStripSeparator1.Visible = False
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.Text <> "" And FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.MediumAquamarine And gCurrentEmployee.PositionID < 3 Then
            SetAsUnDoneToolStripMenuItem.Visible = True
        Else
            SetAsUnDoneToolStripMenuItem.Visible = False
        End If

        If FpSpreadSchedule.ActiveSheet.ActiveCell.Text <> "" And FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor <> Color.MediumAquamarine Then
            cmdReSchedule.Enabled = True
            ReScheduleToolStripMenuItem.Visible = True
            ToolStripSeparatorReSchedule.Visible = True
            If DateDiff(DateInterval.Hour, Now, DateTimePicker1.Value) > gNoShowHours Or DateDiff(DateInterval.Hour, Now, DateTimePicker1.Value) < -gNoShowHours Or FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.Violet Then
                ShowUpToolStripMenuItem.Visible = False
                ConfirmedToolStripMenuItem.Visible = True
                ToolStripSeparatorConfirmed.Visible = True
                ToolStripSeparatorShowUp.Visible = False
            Else
                ShowUpToolStripMenuItem.Visible = True
                ConfirmedToolStripMenuItem.Visible = True
                ToolStripSeparatorConfirmed.Visible = True
                ShowUpToolStripMenuItem.Text = "Present " & Now.ToShortTimeString
                ToolStripSeparatorShowUp.Visible = True
            End If
            If DateDiff(DateInterval.Hour, Now, DateTimePicker1.Value) < gNoShowHours Then If gCurrentEmployee.PositionID < 3 Then MarkAsDoneToolStripMenuItem.Visible = True
            cmdDone.Enabled = True
        Else
            If DateDiff(DateInterval.Hour, Now, DateTimePicker1.Value) < gNoShowHours Then MarkAsDoneToolStripMenuItem.Visible = False
            ShowUpToolStripMenuItem.Visible = False
            ConfirmedToolStripMenuItem.Visible = False
            ToolStripSeparatorConfirmed.Visible = False
            cmdDone.Enabled = False
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.BurlyWood Or FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.Violet Then
            ConfirmedToolStripMenuItem.Visible = False
            ToolStripSeparatorConfirmed.Visible = False
        End If
        Application.DoEvents()
        ToolStrip1.ResumeLayout()

    End Sub

    Private Sub MarkAsDoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkAsDoneToolStripMenuItem.Click
        Dim PatientID As Long
        If gCurrentEmployee.PositionID > 3 Then
            ' Manual Complete allowed for the Manager only
            Exit Sub
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.Text <> "" Then
            FpSpreadSchedule.EditMode = False
            frmScheduleComplete.Load_Procedures(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).ScheduleID)
            PatientID = CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID
            Dim SaveRow As Integer = FpSpreadSchedule.ActiveSheet.ActiveRowIndex
            Dim SaveCol As Integer = FpSpreadSchedule.ActiveSheet.ActiveColumnIndex
            If frmScheduleComplete.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Load_Schedule()
                Timer1_Tick(Nothing, Nothing)
                FpSpreadSchedule.ActiveSheet.SetActiveCell(SaveRow, SaveCol)
                LockWindowUpdate(Panel3.Handle)
                Show_Details(PatientID)
                LockWindowUpdate(0)
            End If
            frmScheduleComplete.Dispose()
            'If MsgBox("Please confirm the appointment for the " & FpSpreadSchedule.ActiveSheet.ActiveCell.Text & " at " & RetH.ToString("00") & ":" & RetM.ToString("00") & " " & RetAM & "  is complete?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            'FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.MediumAquamarine
            'gSQLUpdateData("UPDATE Schedule set UpdatedByEmpID=" & gCurrentEmployee.ID.ToString & ", UpdatedDT=getdate(), ScheduleStatusID =2 Where  ScheduleID=" & CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).ScheduleID)
            'gUpdate_Profile_Log(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID, PatientLogTypes.tScheduleCompleted)
            'Show_Details(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID)
            Calculate_Totals()
        End If

    End Sub

    Private Sub FpSpreadSchedule_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadSchedule.CellClick
        Dim Rp As New FarPoint.Win.Spread.EnterCellEventArgs(e.View, e.Row, e.Column)
        FpSpread1_EnterCell(sender, Rp)
    End Sub

    Private Sub TransportationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransportationToolStripMenuItem.Click
        Dim CT As New FarPoint.Win.Spread.CellType.TextCellType
        Dim SI As ScheduleInfo
        frmRequireTransportation.CalledForm = Me
        frmRequireTransportation.ComboBoxPickup.SelectedIndex = CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PickupTransportation
        frmRequireTransportation.ComboBoxDestination.SelectedIndex = CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).DestinationTransportation

        If frmRequireTransportation.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            frmRequireTransportation.Dispose()
            Exit Sub
        End If
        frmRequireTransportation.Dispose()
        If ReturnSchPickupTransportation > 0 Or ReturnSchDestinationTransportation > 0 Then
            SI = CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo)
            SI.PickupTransportation = ReturnSchPickupTransportation
            SI.DestinationTransportation = ReturnSchDestinationTransportation
            CT.BackgroundImage = New FarPoint.Win.Picture(PictureBoxTransportation.Image)
            CT.BackgroundImage.AlignHorz = FarPoint.Win.HorizontalAlignment.Right
            CT.BackgroundImage.AlignVert = FarPoint.Win.VerticalAlignment.Center
            FpSpreadSchedule.ActiveSheet.ActiveCell.CellType = CT
            FpSpreadSchedule.ActiveSheet.ActiveCell.Tag = SI
            gSQLUpdateData("UPDATE Schedule set UpdatedByEmpID=" & gCurrentEmployee.EmpID.ToString & ", UpdatedDT=getdate(), PickupTransportation=" & ReturnSchPickupTransportation & ", DestinationTransportation=" & ReturnSchDestinationTransportation & " Where  ScheduleID=" & CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).ScheduleID)
            gUpdate_Profile_Log(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID, PatientLogTypes.tTransportationCanceled)
        Else
            SI = CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo)
            SI.PickupTransportation = ReturnSchPickupTransportation
            SI.DestinationTransportation = ReturnSchDestinationTransportation
            FpSpreadSchedule.ActiveSheet.ActiveCell.CellType = CT
            FpSpreadSchedule.ActiveSheet.ActiveCell.Tag = SI
            gSQLUpdateData("UPDATE Schedule set UpdatedByEmpID=" & gCurrentEmployee.EmpID.ToString & ", UpdatedDT=getdate(), PickupTransportation=" & ReturnSchPickupTransportation & ", DestinationTransportation=" & ReturnSchDestinationTransportation & " Where  ScheduleID=" & CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).ScheduleID)
            gUpdate_Profile_Log(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID, PatientLogTypes.tTransportationRequested)

        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub

    Private Sub SetAsUnDoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAsUnDoneToolStripMenuItem.Click
        Dim PatientID As Long
        If gCurrentEmployee.PositionID > 3 Then
            ' Manual Undone allowed for the Manager only
            Exit Sub
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.Text <> "" Then
            FpSpreadSchedule.EditMode = False
            frmScheduleUndone.Load_Procedures(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).ScheduleID)
            PatientID = CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID
            Dim SaveRow As Integer = FpSpreadSchedule.ActiveSheet.ActiveRowIndex
            Dim SaveCol As Integer = FpSpreadSchedule.ActiveSheet.ActiveColumnIndex
            If frmScheduleUndone.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Load_Schedule()
                Timer1_Tick(Nothing, Nothing)
                FpSpreadSchedule.ActiveSheet.SetActiveCell(SaveRow, SaveCol)
                LockWindowUpdate(Panel3.Handle)
                Show_Details(PatientID)
                LockWindowUpdate(0)
            End If
            frmScheduleUndone.Dispose()
            Calculate_Totals()
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
            frmPatient.InitialPatientName = FpSpreadSchedule.ActiveSheet.ActiveCell.Text
            frmPatient.Width = 1000
            frmPatient.WindowState = FormWindowState.Normal
            frmPatient.Location = New Point(Me.Left + ((Width - frmPatient.Size.Width) \ 2), Me.Top + ((Height - frmPatient.Size.Height) \ 2))
            frmPatient.Show(Me)
            frmPatient.BringToFront()
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PrintProceduresFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintProceduresFormToolStripMenuItem.Click
        Dim ID As Long
        Dim CL As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.ActiveCell

        FpSpreadSchedule.Focus()
        If CL Is Nothing Then Exit Sub
        ID = Val(CType(CL.Tag, ScheduleInfo).PatientID)
        If ID = 0 Then Exit Sub
        frmReportPatientVisitsTodayProceduresOnePatient.Setup_report(ID, DateTimePicker1.Value.ToString("MM/dd/yyyy"))
        frmReportPatientVisitsTodayProceduresOnePatient.ShowDialog(Me)
        frmReportPatientVisitsTodayProceduresOnePatient.Dispose()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonToday.Click
        DateTimePicker1.Value = Now
    End Sub

    Private Sub FpSpreadSchedule_TextTipFetch(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.TextTipFetchEventArgs) Handles FpSpreadSchedule.TextTipFetch
        Dim Ret As String
        'If e.Row = 0 Then e.ShowTip = False : Exit Sub
        If e.Column < 2 Then e.ShowTip = False : Exit Sub
        If FpSpreadSchedule.ActiveSheet.Cells(e.Row, e.Column).Text = "" Then e.ShowTip = False : Exit Sub
        Ret = CType(FpSpreadSchedule.ActiveSheet.Cells(e.Row, e.Column).Tag, ScheduleInfo).ToolTip
        If IsDate(CType(FpSpreadSchedule.ActiveSheet.Cells(e.Row, e.Column).Tag, ScheduleInfo).ShowUpDateTime) And CType(FpSpreadSchedule.ActiveSheet.Cells(e.Row, e.Column).Tag, ScheduleInfo).ShowUpDateTime <> "#12:00:00 AM#" Then
            If CDate(CType(FpSpreadSchedule.ActiveSheet.Cells(e.Row, e.Column).Tag, ScheduleInfo).ShowUpDateTime).Hour > 0 Then
                Ret = "Present: " & CType(FpSpreadSchedule.ActiveSheet.Cells(e.Row, e.Column).Tag, ScheduleInfo).ShowUpDateTime & vbCrLf & vbCrLf & Ret
            End If
        Else
            If CType(FpSpreadSchedule.ActiveSheet.Cells(e.Row, e.Column).Tag, ScheduleInfo).ConfirmedBy <> "" Then
                Ret = Ret & vbCrLf & vbCrLf & CType(FpSpreadSchedule.ActiveSheet.Cells(e.Row, e.Column).Tag, ScheduleInfo).ConfirmedBy
            End If
        End If
        If Ret <> "" Then
            e.TipText = Ret
            e.WrapText = False
            e.ShowTip = True
        Else
            e.TipText = FpSpreadSchedule.ActiveSheet.Cells(e.Row, e.Column).Text
            e.ShowTip = True
        End If
    End Sub

    Private Sub EditScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditScheduleToolStripMenuItem.Click
        If CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).CaseTypeID = 4 And FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.Violet Then
            MsgBox("Unable to make changes to the Cash Schedule which is set as Present." & vbCrLf & "You can cancel appointment, refund money and recteate it again.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor = Color.MediumAquamarine Then
            FpSpreadSchedule.EditMode = False
            Exit Sub
        End If
        If FpSpreadSchedule.ActiveSheet.ActiveCell.Locked Then
            FpSpreadSchedule.EditMode = False
            Exit Sub
        End If
        Dim SI As ScheduleInfo
        SI = CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo)
        frmScheduleSearchPopup.CalledForm = Me
        frmScheduleSearchPopup.SchID = SI.ScheduleID
        frmScheduleSearchPopup.SchDiagID = CLng(FpSpreadSchedule.ActiveSheet.ColumnHeader.Columns(FpSpreadSchedule.ActiveSheet.ActiveColumn.Index).Tag)
        frmScheduleSearchPopup.SchDiagName = FpSpreadSchedule.ActiveSheet.ActiveColumn.Label
        frmScheduleSearchPopup.SchActiveCell = FpSpreadSchedule.ActiveSheet.ActiveCell
        frmScheduleSearchPopup.SchH = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(FpSpreadSchedule.ActiveSheet.ActiveCell.Row.Index, 0).Text))
        frmScheduleSearchPopup.SchM = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(FpSpreadSchedule.ActiveSheet.ActiveCell.Row.Index, 1).Text))
        frmScheduleSearchPopup.SchAM = FpSpreadSchedule.ActiveSheet.Cells(FpSpreadSchedule.ActiveSheet.ActiveCell.Row.Index, 0).Text.Substring(3, 2)
        frmScheduleSearchPopup.SchDate = DateTimePicker1.Value.Date
        frmScheduleSearchPopup.ReturnSchPickupTransportation = SI.PickupTransportation
        frmScheduleSearchPopup.ReturnSchDestinationTransportation = SI.DestinationTransportation

        frmScheduleSearchPopup.Find_Patient(CType(FpSpreadSchedule.ActiveSheet.ActiveCell.Tag, ScheduleInfo).PatientID)
        FpSpreadSchedule.EditMode = False
        ReturnSchName = ""
        ReturnScheduleID = 0
        ReturnSchPickupTransportation = 0
        ReturnSchDestinationTransportation = 0
        Dim SaveRow As Integer = FpSpreadSchedule.ActiveSheet.ActiveRowIndex
        Dim SaveCol As Integer = FpSpreadSchedule.ActiveSheet.ActiveColumnIndex
        'Dim SI As ScheduleInfo
        If frmScheduleSearchPopup.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            gLockWindowUpdate(Me.Handle, False)
            Load_Schedule()
            Timer1_Tick(Nothing, Nothing)
            FpSpreadSchedule.ActiveSheet.SetActiveCell(SaveRow, SaveCol)
            Show_Details(ReturnUserID)
            gLockWindowUpdate(Me.Handle, True)
        Else
            If FpSpreadSchedule.ActiveSheet.ActiveCell.Text.Length = 1 Then
                FpSpreadSchedule.ActiveSheet.ActiveCell.Text = ""
            End If
        End If
        PressedKey = ""
        Setup_Menus()
        Calculate_Totals()
    End Sub


    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        FindPatientToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub cmdDone_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click
        Dim CL As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.ActiveCell
        If CL Is Nothing Then Exit Sub
        If CL.Locked Then Exit Sub
        MarkAsDoneToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub cmdTransport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransport.Click
        TransportationToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub cmdProcedureForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcedureForm.Click
        PrintProceduresFormToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub cmdDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        ClearScheduleToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim R As Integer = 0
        Dim C As Integer = 0
        Dim SI As ScheduleInfo
        FpSpreadRpt.ActiveSheet.ColumnCount = 1
        FpSpreadRpt.ActiveSheet.RowCount = 0
        FpSpreadRpt.ActiveSheet.ColumnCount = FpSpreadSchedule.ActiveSheet.ColumnCount - 1
        For C = 2 To FpSpreadSchedule.ActiveSheet.ColumnCount - 1
            FpSpreadRpt.ActiveSheet.SetColumnLabel(0, C - 1, FpSpreadSchedule.ActiveSheet.GetColumnLabel(0, C))
            FpSpreadRpt.ActiveSheet.SetColumnWidth(C - 1, FpSpreadSchedule.ActiveSheet.GetColumnWidth(C))
        Next
        For R = 0 To FpSpreadSchedule.ActiveSheet.RowCount - 1
            For C = 2 To FpSpreadSchedule.ActiveSheet.ColumnCount - 1
                If FpSpreadSchedule.ActiveSheet.Cells(R, C).Text <> "" Then
                    FpSpreadRpt.ActiveSheet.RowCount = FpSpreadRpt.ActiveSheet.RowCount + 1
                    SI = CType(FpSpreadSchedule.ActiveSheet.Cells(R, C).Tag, ScheduleInfo)
                    FpSpreadRpt.ActiveSheet.Cells(FpSpreadRpt.ActiveSheet.RowCount - 1, 0).Text = SI.ScheduleDateTime
                    FpSpreadRpt.ActiveSheet.Cells(FpSpreadRpt.ActiveSheet.RowCount - 1, C - 1).Text = FpSpreadSchedule.ActiveSheet.Cells(R, C).Text & vbCrLf & SI.PatientPhone
                End If
            Next
        Next
        Application.DoEvents()
        FpSpreadRpt.Refresh()
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.Header = "SCHEDULE FOR THE " & DateTimePicker1.Text.ToUpper
        Printinfo.BestFitRows = True
        Printinfo.BestFitCols = False
        Printinfo.Preview = True
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office Schedule"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = True
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.None))
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.None))
        Printinfo.UseSmartPrint = False
        Printinfo.UseMax = False

        FpSpreadRpt.ActiveSheet.PrintInfo = Printinfo
        FpSpreadRpt.PrintSheet(FpSpreadRpt_Sheet1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ShowUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowUpToolStripMenuItem.Click
        Dim SI As ScheduleInfo
        Dim C As FarPoint.Win.Spread.Cell
        Dim ScheduleID As Long
        Dim SQL As String
        C = FpSpreadSchedule.ActiveSheet.ActiveCell
        SI = CType(C.Tag, ScheduleInfo)
        ScheduleID = SI.ScheduleID
        If SI.CaseTypeID = 4 Then
            frmCashPayment.ScheduleID = ScheduleID
            If frmCashPayment.ShowDialog(Me) <> Windows.Forms.DialogResult.OK Then
                MsgBox("Procedure can not be accomplished." & vbCrLf & "Payment Required." & vbCrLf & vbCrLf & vbCrLf & "If payment amount not accepted, please cancel this appointment.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            If MsgBox("Please confirm the patient " & C.Text & " is waiting...", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        SI.ShowUpDateTime = Now
        C.Tag = SI
        C.BackColor = Color.Violet
        SQL = "Update Schedule set ShowUpDatetime = getdate() where ScheduleID  = " & SI.ScheduleID
        gSQLUpdateData(SQL)
        Calculate_Totals()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim C As FarPoint.Win.Spread.Cell
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        LockWindowUpdate(Me.Handle)
        C = FpSpreadSchedule.ActiveSheet.ActiveCell
        Application.DoEvents()
        Load_Schedule()

        Timer1_Tick(Nothing, Nothing)
        If Not C Is Nothing Then
            FpSpreadSchedule.ActiveSheet.SetActiveCell(C.Row.Index, C.Column.Index)
        End If
        LockWindowUpdate(0)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TimerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRefresh.Tick
        If gIdleTimeCurrent > 20 Then
            ToolStripButton1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, -1, DateTimePicker1.Value)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, 1, DateTimePicker1.Value)
    End Sub

    Private Sub RemoveShowUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveShowUpToolStripMenuItem.Click
        Dim SI As ScheduleInfo
        Dim C As FarPoint.Win.Spread.Cell
        Dim ScheduleID As Long
        Dim SQL As String
        If FpSpreadSchedule.ActiveSheet.ActiveCell.BackColor <> Color.Violet Then
            Exit Sub
        End If
        C = FpSpreadSchedule.ActiveSheet.ActiveCell
        SI = CType(C.Tag, ScheduleInfo)
        ScheduleID = SI.ScheduleID
        If MsgBox("Please confirm the patient " & C.Text & " left or was set as waiting by mistake...", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        SI.ShowUpDateTime = Now
        C.Tag = SI
        C.BackColor = Color.Khaki
        SQL = "Update Schedule set ShowUpDatetime = Null where ScheduleID  = " & SI.ScheduleID
        gSQLUpdateData(SQL)
        Calculate_Totals()
    End Sub

    Private Sub ConfirmedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfirmedToolStripMenuItem.Click
        Dim SI As ScheduleInfo
        Dim C As FarPoint.Win.Spread.Cell
        Dim ScheduleID As Long
        Dim SQL As String
        C = FpSpreadSchedule.ActiveSheet.ActiveCell
        SI = CType(C.Tag, ScheduleInfo)
        ScheduleID = SI.ScheduleID
        If MsgBox(FpSpreadSchedule.ActiveSheet.ActiveCell.Text & vbCrLf & vbCrLf & "Appointment Confirmed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        SI.ConfirmedBy = "Appointment Confirmed at " & FormatDateTime(Now, DateFormat.ShortDate) & " " & FormatDateTime(Now, DateFormat.ShortTime) & " by " & gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        C.Tag = SI
        C.BackColor = Color.BurlyWood
        SQL = "Update Schedule set ConfirmedBy = '" & SI.ConfirmedBy & "' where ScheduleID  = " & SI.ScheduleID
        gSQLUpdateData(SQL)
        Calculate_Totals()
    End Sub

    Private Sub ToolStripButtonReSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReSchedule.Click
        Dim CL As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.ActiveCell
        If CL.Column.Index < 2 Then
            Exit Sub
        End If
        If CL Is Nothing Then
            MsgBox("Unable to move schedule." & vbCrLf & "No schedule selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If CL.Text = "" Then
            MsgBox("Unable to move schedule." & vbCrLf & "Selected schedule is empty.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If CL.BackColor = Color.MediumAquamarine Then
            MsgBox("Unable to move complete schedule.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim SchH As Integer = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(CL.Row.Index, 0).Text))
        Dim SchM As Integer = CInt(Val(FpSpreadSchedule.ActiveSheet.Cells(CL.Row.Index, 1).Text))
        Dim SchAM As String = FpSpreadSchedule.ActiveSheet.Cells(CL.Row.Index, 0).Text.Substring(3, 2)
        Dim ScheduleDateTime As Date = CDate(DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " " & SchH & ":" & SchM & " " & SchAM)

        frmScheduleMove.Height = Me.Height
        frmScheduleMove.DiagID = CLng(FpSpreadSchedule.ActiveSheet.ColumnHeader.Columns(FpSpreadSchedule.ActiveSheet.ActiveColumn.Index).Tag)
        frmScheduleMove.MoveCell = CL
        frmScheduleMove.CurrentSchedule = ScheduleDateTime
        frmScheduleMove.Label1.Text = UCase("ReSchedule Appointment For: " & CL.Text & "  -  Current Schedule: " & ScheduleDateTime)
        frmScheduleMove.Label1.Tag = CL.Text & "  -  Current Schedule: " & ScheduleDateTime
        frmScheduleMove.ShowDialog(Me)
        frmScheduleMove.Dispose()
        Calculate_Totals()
    End Sub

    Private Sub ReScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReScheduleToolStripMenuItem.Click
        ToolStripButtonReSchedule_Click(Nothing, Nothing)
    End Sub

    Private Sub FpSpreadProcedures_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadProcedures.CellClick

    End Sub

    Private Sub FpSpreadDetails_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadDetails.CellClick

    End Sub

    Private Sub ToolStripMenuItemCoupon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCoupon.Click
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim ConInfo As New TableLogOnInfo
        Dim ID As Long
        Dim PatientID As Long
        Dim Msg As String = ""
        Dim CL As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.ActiveCell
        Application.DoEvents()
        If CL Is Nothing Then Exit Sub
        If CL.Text = "" Then Exit Sub
        PatientID = CType(CL.Tag, ScheduleInfo).PatientID
        Dim CC As Long = gSQLGetSingleValue("SELECT COUNT(*) FROM ComplimentaryCoupon Where PatientID=" & PatientID)
        If CC = 0 Then
            Msg = "Please confirm you want to print the Complimentary Coupon for " & vbCrLf & CL.Text & "?"
        ElseIf CC = 1 Then
            Msg = "Please confirm you want to print the Complimentary Coupon for " & vbCrLf & CL.Text & vbCrLf & vbCrLf & "This patient is already received " & CC & " coupon!"
        Else
            Msg = "Please confirm you want to print the Complimentary Coupon for " & vbCrLf & CL.Text & vbCrLf & vbCrLf & "This patient is already received " & CC & " coupon(s)!"
        End If
        If MsgBox(Msg, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLUpdateData("INSERT INTO ComplimentaryCoupon (PatientID) VALUES(" & PatientID & ")")
        ID = gSQLGetSingleValue("SELECT MAX(ID) FROM ComplimentaryCoupon")




        CR = New eMedicalOffice.rptComplimentaryCoupon
        ConInfo.ConnectionInfo.UserID = gSQLServerUID
        ConInfo.ConnectionInfo.Password = gSQLServerPassword
        ConInfo.ConnectionInfo.ServerName = gSQLServerName
        ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
        For intCounter = 0 To CR.Database.Tables.Count - 1
            CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
            CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
            CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSQLServerName
            CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
            Application.DoEvents()
            CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
            Application.DoEvents()
        Next
        CR.Refresh()
        CR.SetParameterValue("ID", ID)
        If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
        CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
        CR.PrintToPrinter(1, False, 0, 0)

    End Sub

    Private Sub CommentsToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentsToolStripMenu.Click
        Add_Patient_Comments()
    End Sub
    Private Sub Add_Patient_Comments()
        Dim ID As Long
        Dim CL As FarPoint.Win.Spread.Cell = FpSpreadSchedule.ActiveSheet.ActiveCell
        If CL Is Nothing Then Exit Sub
        ID = Val(CType(CL.Tag, ScheduleInfo).PatientID)
        If ID = 0 Then Exit Sub
        frmPatientComment.calledForm = Me
        frmPatientComment.TextBoxComment.Text = PatientComments
        frmPatientComment.PatientID = ID
        frmPatientComment.ShowDialog()
        frmPatientComment.Dispose()
    End Sub

    Private Sub cmdComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdComments.Click
        Add_Patient_Comments()
    End Sub
End Class
