Imports System.Data.SqlClient

Public Class frmScheduleMove
    Private PressedKey As String = ""
    Public ReturnSchPickupTransportation As Integer
    Public ReturnSchDestinationTransportation As Integer
    Public ReturnSchName As String
    Public ReturnScheduleID As Long
    Public ReturnUserID As Long
    Private LoadingInd As Boolean
    Public MoveCell As FarPoint.Win.Spread.Cell
    Public DiagID As Long
    Public CurrentSchedule As String
    Public PassedTimeScheduleUnloacked As Boolean
    Public ActiveSheet As FarPoint.Win.Spread.SheetView

    Public Sub New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Private Sub frmScheduleMove_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
        FpSpreadSchedule.Focus()
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

    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        Dim sizerow As Single
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        FpSpreadSchedule.Font = F
        For i = 0 To ActiveSheet.Rows.Count - 1
            sizerow = ActiveSheet.Rows(i).GetPreferredHeight()
            ActiveSheet.Rows(i).Height = sizerow
        Next
        ActiveSheet.Columns(0).Width = ActiveSheet.Columns(0).GetPreferredWidth()
        ActiveSheet.Columns(1).Width = ActiveSheet.Columns(1).GetPreferredWidth()
    End Sub

    Private Sub Schedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim H As ToolStripControlHost
        Me.DoubleBuffered = True
        H = New ToolStripControlHost(DateTimePicker1)
        ToolStrip1.Items.Insert(3, H)
        FpSpreadSchedule.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Default)
        FpSpreadSchedule.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, System.Windows.Forms.Cursors.Default)
        Application.DoEvents()
        ActiveSheet = FpSpreadSchedule.Sheets(0)
        SetFont()
        Setup_Spread()

        LoadingInd = True
        DateTimePicker1.Value = Now
        LoadingInd = False
        Setup_Diags()
        Load_Schedule()
        Timer1_Tick(Nothing, Nothing)
        ActiveSheet.SetColumnWidth(2, FpSpreadSchedule.Width - 150)
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
        FP = ActiveSheet
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
        Dim Holiday As String = ""
        ' Setup Cell Type
        Dim CT As New FarPoint.Win.Spread.CellType.TextCellType
        CurDate = DateTimePicker1.Value.DayOfWeek.ToString().Mid(1, 2)
        Reader = gSQLGetDataReader("SELECT OffName From HolidaysOffDays Where DATEDIFF(d,  OffDate, '" & FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate) & "')=0")
        If Not Reader Is Nothing Then
            If Reader.HasRows Then
                Reader.Read()
                Holiday = Reader("OffName").ToString.ToUpper
            End If
        End If
        SQL = "SELECT Su, Mo, Tu, We, Th, Fr, Sa, OfficeDiagnostics.DiagID, DiagName FROM OfficeDiagnostics inner Join Diagnostics on OfficeDiagnostics.DiagID = Diagnostics.DiagID WHERE OfficeDiagnostics.DiagID=" & DiagID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        FP = ActiveSheet
        gSpread_Settings(Me, FpSpreadSchedule, ReadWrite.sWrite)
        With FP
            .ColumnCount = 2
            Do Until Reader.Read = False
                .ColumnCount = .ColumnCount + 1
                .Columns(.ColumnCount - 1).CellType = CT
                .ColumnHeader.Columns(.ColumnCount - 1).Label = "" & Reader("DiagName").ToString
                .ColumnHeader.Columns(.ColumnCount - 1).Tag = "" & Reader("DiagID").ToString
                If Reader(CurDate).ToString = "1" And Holiday = "" Then
                    .ColumnHeader.Columns(.ColumnCount - 1).Locked = False
                    .Columns(.ColumnCount - 1).BackColor = Color.White
                    .Columns(.ColumnCount - 1).Locked = False
                Else
                    If Holiday <> "" Then
                        .ColumnHeader.Columns(.ColumnCount - 1).Label = Holiday
                        .Columns(.ColumnCount - 1).BackColor = Color.MistyRose
                        .ColumnHeader.Columns(.ColumnCount - 1).BackColor = Color.Red
                    Else
                        .Columns(.ColumnCount - 1).BackColor = Color.Silver
                    End If
                    .ColumnHeader.Columns(.ColumnCount - 1).Locked = True
                    .Columns(.ColumnCount - 1).BackColor = Color.Silver
                    .Columns(.ColumnCount - 1).Locked = True
                End If
            Loop
            Reader = Nothing
        End With
        gSpread_Settings(Me, FpSpreadSchedule, ReadWrite.sRead)
    End Sub

    Private Sub Load_Schedule()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim AppTime As DateTime
        Dim SchH As Integer
        Dim SchM As Integer
        Dim SchAM As String
        Dim I As Integer
        Dim C As Integer
        Dim SI As ScheduleInfo = Nothing
        Dim LockCell As New FarPoint.Win.Spread.CellType.TextCellType
        LockCell.Static = True
        LockCell.ReadOnly = True

        Application.DoEvents()
        If LoadingInd = True Then Exit Sub
        SI.ScheduleID = 0
        SI.PatientID = 0
        SI.ScheduleID = 0
        SI.PickupTransportation = 0
        SI.DestinationTransportation = 0
        SI.ToolTip = ""
        For I = 0 To ActiveSheet.RowCount - 1
            For C = 2 To ActiveSheet.ColumnCount - 1
                SI.PatientID = 0
                SI.ScheduleID = 0
                SI.PickupTransportation = 0
                SI.DestinationTransportation = 0
                ActiveSheet.Cells(I, C).Text = ""
                ActiveSheet.Cells(I, C).Tag = SI
                ActiveSheet.Cells(I, C).CellType = Nothing
                If ActiveSheet.Columns(C).Locked = False Then
                    ActiveSheet.Cells(I, C).BackColor = Color.Transparent
                End If
            Next
        Next
        SQL = "SELECT  Schedule.ConfirmedBy, Schedule.ShowUpDatetime, Schedule.ToolTip, Patients.CaseTypeID, Patients.FName, Patients.MI, Patients.LName, Schedule.ScheduleID, PatientProcedures.DiagID, Schedule.PickupTransportation, Schedule.DestinationTransportation, Schedule.ScheduleDateTime, PatientProcedures.PatientID, MIN(PatientProcedures.ProcedureStatusID) AS ScheduleStatusID"
        SQL = SQL & " FROM PatientProcedures INNER JOIN Patients ON Patients.PatientID = PatientProcedures.PatientID INNER JOIN Schedule ON Schedule.ScheduleID = PatientProcedures.ScheduleID "
        SQL = SQL & " WHERE PatientProcedures.ProcedureStatusID<>0 and PatientProcedures.OfficeID = " & gOfficeID & " and ScheduleDateTime > '" & DateTimePicker1.Value.Date & " 00:00" & "' and ScheduleDateTime < '" & DateTimePicker1.Value.Date & " 23:59" & "' "
        SQL = SQL & " GROUP BY  Schedule.ConfirmedBy, Schedule.ShowUpDatetime, Schedule.ToolTip,Patients.CaseTypeID, Patients.FName, Patients.MI, Patients.LName, Schedule.ScheduleID, PatientProcedures.DiagID, Schedule.PickupTransportation, Schedule.DestinationTransportation, Schedule.ScheduleDateTime, PatientProcedures.PatientID "
        Reader = gSQLGetDataReader(SQL.ToString())
        Dim ToolTip As String = ""
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False

            AppTime = CDate(CDate(Reader("ScheduleDateTime").ToString).ToString("hh:mm tt"))
            For I = 0 To ActiveSheet.RowCount - 1
                SchH = CInt(Val(ActiveSheet.Cells(I, 0).Text))
                SchM = CInt(Val(ActiveSheet.Cells(I, 1).Text))
                SchAM = ActiveSheet.Cells(I, 0).Text.Mid(4, 2)
                SI = New ScheduleInfo
                If AppTime = CDate(CDate(SchH & ":" & SchM & " " & SchAM).ToString("hh:mm tt")) Then
                    For C = 2 To ActiveSheet.ColumnCount - 1
                        ToolTip = ""
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
                        If Val(Reader("DiagID").ToString) = Val(ActiveSheet.Columns(C).Tag) Then
                            ActiveSheet.Cells(I, C).Text = Reader("Fname").ToString & " " & IIf(Reader("MI").ToString <> "", Reader("MI").ToString & " ", "").ToString & Reader("Lname").ToString
                            ActiveSheet.Cells(I, C).Tag = SI
                            ActiveSheet.Cells(I, C).BackColor = Color.Silver
                            ActiveSheet.Cells(I, C).Locked = True
                            ActiveSheet.Cells(I, C).CanFocus = False
                            GoTo NextSchedule
                        End If
                    Next
                End If
            Next
NextSchedule:
        Loop
        Load_Blocks()
        FpSpreadSchedule.SetViewportTopRow(0, 0)
        FpSpreadSchedule.SetViewportLeftColumn(0, 0)
        ActiveSheet.SetActiveCell(0, 2)

    End Sub

    Private Sub Load_Blocks()
        Dim SQL As String
        Dim BlockTime As DateTime
        Dim SchH As Integer
        Dim SchM As Integer
        Dim SchAM As String
        Dim I As Integer
        Dim C As Integer
        Dim SI As ScheduleInfo = Nothing

        Dim Reader As SqlClient.SqlDataReader
        Reader = GetBlockedSpots(DateTimePicker1.Value.Date)
        If Reader Is Nothing Then Return
        Dim ToolTip As String = ""
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False

            BlockTime = CDate(CDate(Reader("ScheduleDateTime").ToString).ToString("hh:mm tt"))
            For I = 0 To ActiveSheet.RowCount - 1
                SchH = CInt(Val(ActiveSheet.Cells(I, 0).Text))
                SchM = CInt(Val(ActiveSheet.Cells(I, 1).Text))
                SchAM = ActiveSheet.Cells(I, 0).Text.Mid(4, 2)
                If BlockTime = CDate(CDate(SchH & ":" & SchM & " " & SchAM).ToString("hh:mm tt")) Then
                    For C = 2 To ActiveSheet.ColumnCount - 1
                        SI = ActiveSheet.Cells(I, C).Tag
                        SI.SchedulkeBlockID = 0
                        ActiveSheet.Cells(I, C).Locked = False
                        ActiveSheet.Cells(I, C).BackColor = Color.White
                        If CLng(ActiveSheet.ColumnHeader.Columns(C).Tag) = CLng(Val(Reader("DiagID").ToString)) Then
                            SI.SchedulkeBlockID = Val(Reader("ID").ToString)
                            SI.ToolTip = "" & Reader("Comments").ToString()
                            SI.ToolTip = SI.ToolTip & vbCrLf & "" & Reader("EmpName").ToString()
                            ActiveSheet.Cells(I, C).Tag = SI
                            ActiveSheet.Cells(I, C).Locked = True
                            ActiveSheet.Cells(I, C).BackColor = Color.Gray
                            Dim CT As New FarPoint.Win.Spread.CellType.TextCellType
                            CT.BackgroundImage = New FarPoint.Win.Picture(My.Resources.ScheduleLocked)
                            CT.BackgroundImage.AlignHorz = FarPoint.Win.HorizontalAlignment.Left
                            CT.BackgroundImage.AlignVert = FarPoint.Win.VerticalAlignment.Center
                            'CT.BackgroundImage.Style = FarPoint.Win.RenderStyle.Tile
                            ActiveSheet.Cells(I, C).CellType = CT

                        End If
                    Next
                End If
            Next
        Loop
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If LoadingInd = True Then Exit Sub
        Application.DoEvents()
        Setup_Diags()
        Load_Schedule()
        Timer1_Tick(Nothing, Nothing)
    End Sub

    Dim SelectedCD As FarPoint.Win.Spread.Cell
    Dim DblClick As Boolean

    Private Sub FpSpreadSchedule_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadSchedule.CellDoubleClick
        Dim CD As FarPoint.Win.Spread.Cell = ActiveSheet.Cells(e.Row, e.Column)
        If CD.Text = "" And CD.Column.Locked = False And e.Row > -1 And e.Column > 1 Then
            DblClick = True
            Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FpSpreadSchedule_EnterCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EnterCellEventArgs) Handles FpSpreadSchedule.EnterCell
        If e.Column < 2 Then
            ActiveSheet.SetActiveCell(e.Row, 2)
        Else
            ActiveSheet.SetActiveCell(e.Row, e.Column)
        End If
        Dim CD As FarPoint.Win.Spread.Cell = ActiveSheet.ActiveCell
        If CD.Column.Locked Then
            Exit Sub
        End If

        If Not SelectedCD Is Nothing Then
            SelectedCD.BackColor = Color.White
        End If
        If CD.Text = "" And CD.Locked = False And CD.Row.Index > -1 And CD.Column.Index > 1 Then
            CD.BackColor = Color.Orange
            SelectedCD = CD
        End If
    End Sub

    Private Sub FpSpreadSchedule_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadSchedule.CellClick
        If e.Column < 2 Then
            ActiveSheet.SetActiveCell(e.Row, 2)
        Else
            ActiveSheet.SetActiveCell(e.Row, e.Column)
        End If

        Dim CD As FarPoint.Win.Spread.Cell = ActiveSheet.ActiveCell
        If CD.Column.Locked Then
            Exit Sub
        End If

        If Not SelectedCD Is Nothing Then
            SelectedCD.BackColor = Color.White
        End If
        If CD.Text = "" And CD.Locked = False And CD.Row.Index > -1 And CD.Column.Index > 1 Then
            CD.BackColor = Color.Orange
            SelectedCD = CD
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim I As Integer
        Dim RetH As Integer
        Dim RetM As Integer
        Dim RetAM As String
        Dim C As Integer
        With ActiveSheet
            For I = 0 To .RowCount - 1
                RetH = CInt(Val(.GetText(I, 0)))
                RetM = CInt(Val(.GetText(I, 1)))
                RetAM = .GetText(I, 0).Mid(4, 2)
                'If DateAdd(DateInterval.Hour, 10, Now) >= CDate(DateTimePicker1.Value.Date & " " & RetH & ":" & RetM & " " & RetAM) Then
                If PassedTimeScheduleUnloacked = False Then
                    If Now >= CDate(DateTimePicker1.Value.Date & " " & RetH & ":" & RetM & " " & RetAM) Then
                        For C = 2 To .ColumnCount - 1
                            .Cells(I, C).Locked = True
                            .Cells(I, C).BackColor = Color.Silver
                        Next
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub FpSpreadSchedule_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FpSpreadSchedule.MouseDown
        Dim C As Integer
        Dim R As Integer
        C = FpSpreadSchedule.GetCellFromPixel(0, 0, e.X, e.Y).Column
        R = FpSpreadSchedule.GetCellFromPixel(0, 0, e.X, e.Y).Row
        Dim Rp As New FarPoint.Win.Spread.EnterCellEventArgs(Nothing, R, C)
        If C < 1 And R < 0 Then Exit Sub
        ActiveSheet.SetActiveCell(R, C)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonToday.Click
        DateTimePicker1.Value = Now
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim C As FarPoint.Win.Spread.Cell
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        LockWindowUpdate(Me.Handle)
        C = ActiveSheet.ActiveCell
        Application.DoEvents()
        Load_Schedule()

        Timer1_Tick(Nothing, Nothing)
        If Not C Is Nothing Then
            ActiveSheet.SetActiveCell(C.Row.Index, C.Column.Index)
        End If
        LockWindowUpdate(0)
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonPreviousDay.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, -1, DateTimePicker1.Value)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonNextDay.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, 1, DateTimePicker1.Value)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim CD As FarPoint.Win.Spread.Cell = ActiveSheet.ActiveCell
        If CD.Text <> "" Then
            MsgBox("Unable to move schedule. The schedule time is busy.", MsgBoxStyle.Exclamation)
            FpSpreadSchedule.Focus()
            Exit Sub
        End If

        Dim Ind As Integer = CD.Row.Index
        Dim SchH As Integer = CInt(Val(ActiveSheet.Cells(Ind, 0).Text))
        Dim SchM As Integer = CInt(Val(ActiveSheet.Cells(Ind, 1).Text))
        Dim SchAM As String = ActiveSheet.Cells(Ind, 0).Text.Mid(4, 2)
        Dim ScheduleDateTime As Date = CDate(DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " " & SchH & ":" & SchM & " " & SchAM)

        Dim SIdest As ScheduleInfo = Nothing
        SIdest = CType(CD.Tag, ScheduleInfo)
        Dim SQL As String
        SQL = "SELECT count (*) from Schedule inner join PatientProcedures on Schedule.ScheduleID = PatientProcedures.ScheduleID "
        SQL &= " where PatientProcedures.DiagID = " & DiagID
        SQL &= " and Schedule.ScheduleDateTime = '" & ScheduleDateTime & "'"
        If gSQLGetSingleValue(SQL) > 0 Then
            TimerReloadSchedule.Enabled = False
            FpSpreadSchedule.EditMode = False
            DateTimePicker1_ValueChanged(Nothing, Nothing)
            FpSpreadSchedule.EditMode = False

            MsgBox("Unable to move schedule to selected time spot. " & vbCrLf & "The selected schedule time spot: " & ScheduleDateTime & " is already busy." & vbCrLf & vbCrLf & "Please select another time spot.", MsgBoxStyle.Exclamation)
            TimerReloadSchedule.Enabled = True
            Exit Sub
        End If

        If Val(SIdest.SchedulkeBlockID) <> 0 Then
            MsgBox("Selected schedule spot has been blocked by supervisor." & vbCrLf & "Unable to move appointment to the Blocked schedule spot.", MsgBoxStyle.Exclamation)
            FpSpreadSchedule.EditMode = False
            Exit Sub
        Else
            Dim info As SpotInfo

            info = GetSpotLockedID(ScheduleDateTime, CLng(ActiveSheet.ColumnHeader.Columns(ActiveSheet.ActiveColumn.Index).Tag))
            If info.ID > 0 Then
                SIdest.SchedulkeBlockID = info.ID
                SIdest.ToolTip = info.ToolTip
                CD.Locked = True
                CD.Tag = SIdest
                CD.Locked = True
                CD.BackColor = Color.Gray
                Dim CT As New FarPoint.Win.Spread.CellType.TextCellType
                CT.BackgroundImage = New FarPoint.Win.Picture(My.Resources.ScheduleLocked)
                CT.BackgroundImage.AlignHorz = FarPoint.Win.HorizontalAlignment.Left
                CT.BackgroundImage.AlignVert = FarPoint.Win.VerticalAlignment.Center
                'CT.BackgroundImage.Style = FarPoint.Win.RenderStyle.Tile
                CD.CellType = CT
                MsgBox("The selected time spot is currently Blocked by supervisor." & vbCrLf & "Unable to schedule appointment to Blocked schedule spot.", MsgBoxStyle.Exclamation)
                FpSpreadSchedule.EditMode = False
                Exit Sub
            End If
        End If
        If CD.Locked Then
            MsgBox("Unable to move schedule to the past time or unavailable.", MsgBoxStyle.Exclamation)
            FpSpreadSchedule.EditMode = False
            FpSpreadSchedule.Focus()
            Exit Sub
        End If
        Dim DiagName As String = ActiveSheet.ColumnHeader.Columns(CD.Column.Index).Label

        If ActiveSheet.Cells(CD.Row.Index, 2).Column.Locked Then
            MsgBox("Unable to move schedule to the selected Date/Time", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim Reader As SqlClient.SqlDataReader

        SQL = "SELECT     Schedule.ConfirmedBy, Schedule.ShowUpDatetime, Schedule.ToolTip, Patients.CaseTypeID, Patients.FName, Patients.MI, Patients.LName, Schedule.ScheduleID, PatientProcedures.DiagID, Schedule.PickupTransportation, Schedule.DestinationTransportation, Schedule.ScheduleDateTime, PatientProcedures.PatientID "
        SQL &= " FROM  Schedule INNER JOIN PatientProcedures ON Schedule.ScheduleID = PatientProcedures.ScheduleID INNER JOIN Patients ON PatientProcedures.PatientID = Patients.PatientID "
        SQL &= " WHERE     (PatientProcedures.DiagID = " & DiagID & ") AND (Schedule.ScheduleDateTime = '" & ScheduleDateTime & "')"
        Reader = gSQLGetDataReader(SQL)

        If Not Reader Is Nothing Then
            If Reader.HasRows Then
                Reader.Read()
                Dim FoundSI As New ScheduleInfo
                FoundSI.PatientID = CLng(Val(Reader("PatientID").ToString))
                FoundSI.ScheduleID = CLng(Val(Reader("ScheduleID").ToString))
                FoundSI.PickupTransportation = CInt(Val(Reader("PickupTransportation").ToString))
                FoundSI.DestinationTransportation = CInt(Val(Reader("DestinationTransportation").ToString))
                FoundSI.CaseTypeID = CLng(Val(Reader("CaseTypeID").ToString))
                FoundSI.ToolTip = Reader("ToolTip").ToString
                CD.Text = Reader("Fname").ToString & " " & IIf(Reader("MI").ToString <> "", Reader("MI").ToString & " ", "").ToString & Reader("Lname").ToString
                If CD.Text = "" Then
                    CD.Text = "Busy"
                End If
                CD.Tag = FoundSI
                CD.BackColor = Color.Silver
                CD.Locked = True
                CD.CanFocus = False
                MsgBox("Unable to move schedule to the selected Date/Time" & vbCrLf & "Please select another schedule Date/Time.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Reader.Close()
        End If

        If MsgBox("Please confirm you want to ReSchedule " & DiagName & " for the" & vbCrLf & vbCrLf & Label1.Tag & vbCrLf & vbCrLf & "To : " & DateTimePicker1.Value.Date.ToString("dddd MM/dd/yyyy") & " at " & SchH & ":" & SchM & " " & SchAM & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            FpSpreadSchedule.Focus()
            Exit Sub
        End If
        Dim ComplettedProcs As Integer
        ComplettedProcs = gSQLGetSingleValue("select count(*) from PatientProcedures WHERE ProcedureStatusID=2 AND PatientProcedures.ScheduleID = " & CType(MoveCell.Tag, ScheduleInfo).ScheduleID)
        If ComplettedProcs > 0 Then
            Dim ToolTip As String = ""
            Dim r As SqlDataReader
            SQL = "SELECT Procedures.ProcName FROM PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID WHERE ProcedureStatusID<>2 and ProcedureStatusID<>3 and ScheduleID = " & CType(MoveCell.Tag, ScheduleInfo).ScheduleID
            r = gSQLGetDataReader(SQL)
            Do Until r.Read = False
                ToolTip &= r("ProcName").ToString() & vbCrLf
            Loop
            'Duplicate Procedure and create new one for not completted procedures.
            SQL = "INSERT INTO SCHEDULE ( ScheduleDateTime, PickupTransportation, DestinationTransportation, PickupTransportationOther, DestinationTransportationOther, PickupTransportationStatus, DestinationTransportationStatus, InsertedDT, UpdatedDT, UpdatedByEmpID, ToolTip)  "
            SQL &= " SELECT '" & ScheduleDateTime & "', PickupTransportation, DestinationTransportation, PickupTransportationOther, DestinationTransportationOther, PickupTransportationStatus, DestinationTransportationStatus, InsertedDT, UpdatedDT, UpdatedByEmpID, '" & ToolTip & "' FROM SCHEDULE "
            SQL &= " WHERE scheduleID = " & CType(MoveCell.Tag, ScheduleInfo).ScheduleID
            If gSQLUpdateData(SQL) = False Then
                Return
            End If
            Dim NewScheduleID As Integer = gSQLGetSingleValue("SELECT IDENT_CURRENT('SCHEDULE')")
            SQL = "UPDATE PatientProcedures set PACSAltNumber='', ScheduleID = " & NewScheduleID & " WHERE ProcedureStatusID<>2 and ProcedureStatusID<>3 and ScheduleID = " & CType(MoveCell.Tag, ScheduleInfo).ScheduleID
            gSQLUpdateData(SQL)
        Else
            gSQLUpdateData("UPDATE Schedule set UpdatedByEmpID=" & gCurrentEmployee.EmpID & ", ConfirmedBy='', ShowUpDatetime=null, ScheduleDateTime='" & ScheduleDateTime & "' Where  ScheduleID=" & CType(MoveCell.Tag, ScheduleInfo).ScheduleID)
        End If

        '1- Reschedule
        '2-Cancelation
        If FormatDateTime(CurrentSchedule, 2) = FormatDateTime(Now, 2) And FormatDateTime(ScheduleDateTime, 2) > FormatDateTime(Now, 2) Then
            gSQLUpdateData("INSERT INTO PatientReschedulesCancelations (PatientID, ReScheduleCancelInd, Comments, ProcessedBy) VALUES(" & Val(CType(MoveCell.Tag, ScheduleInfo).PatientID) & ",1,'" & "From:" & CurrentSchedule & " To:" & ScheduleDateTime & "'," & gCurrentEmployee.EmpID & " )")
        End If
        gUpdate_Profile_Log(CType(MoveCell.Tag, ScheduleInfo).PatientID, PatientLogTypes.tScheduleChanged, "From:" & CurrentSchedule & " To:" & ScheduleDateTime, gCurrentEmployee.FName & " " & gCurrentEmployee.LName)

        Dim SI As ScheduleInfo = Nothing
        SI.PickupTransportation = 0
        SI.DestinationTransportation = 0
        SI.ScheduleID = 0
        SI.PatientID = 0
        MoveCell.Tag = SI
        Dim I As Integer
        Dim TopRow As Integer = 0
        Dim RetH As String
        Dim retM As String
        Dim NewH = ActiveSheet.Cells(CD.Row.Index, 0).Text
        Dim NewM = ActiveSheet.Cells(CD.Row.Index, 1).Text
        With frmScheduleInstance
            If .DateTimePicker1.Value.Date = DateTimePicker1.Value.Date Then
                .Clear_Details()
                .Setup_Menus()
                .Load_Schedule()
                .Timer1_Tick(Nothing, Nothing)
            Else
                .DateTimePicker1.Value = DateTimePicker1.Value
                'MoveCell.Text = ""
                'MoveCell.BackColor = Color.White
                'frmSchedule.Timer1_Tick(Nothing, Nothing)
                'frmSchedule.Clear_Details()
                'frmSchedule.Setup_Menus()
            End If

            'Dim SchAM As String = ActiveSheet.Cells(CD.Row.Index, 0).Text.Mid(3, 2)

            For I = 0 To .ActiveSheet.RowCount - 1
                RetH = .ActiveSheet.Cells(I, 0).Text
                retM = .ActiveSheet.Cells(I, 1).Text
                If RetH = NewH And TopRow = 0 Then
                    TopRow = I
                End If
                If RetH = NewH And retM = NewM Then
                    .FpSpreadSchedule.SetViewportTopRow(0, TopRow)
                    .FpSpreadSchedule.SetViewportLeftColumn(0, MoveCell.Column.Index)
                    .ActiveSheet.SetActiveCell(I, MoveCell.Column.Index)
                    Dim Rp As New FarPoint.Win.Spread.EnterCellEventArgs(Nothing, I, MoveCell.Column.Index)
                    .FpSpread1_EnterCell(sender, Rp)
                    Exit For
                End If
            Next
        End With
        Me.Close()
    End Sub

    Private Sub FpSpreadSchedule_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpreadSchedule.Enter

    End Sub

    Private Sub FpSpreadSchedule_EditModeStarting(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditModeStartingEventArgs) Handles FpSpreadSchedule.EditModeStarting

    End Sub

    Private Sub FpSpreadSchedule_EditModeOn(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpreadSchedule.EditModeOn
        If DblClick Then
            DblClick = False
            Exit Sub
        End If

        Dim CD As FarPoint.Win.Spread.Cell = ActiveSheet.ActiveCell
        If CD Is Nothing Then Exit Sub
        FpSpreadSchedule.EditMode = False

        If CD.Text = "" And CD.Column.Locked = False And CD.Row.Index > -1 And CD.Column.Index > 1 Then

            Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FpSpreadSchedule_SelectionChanged(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.SelectionChangedEventArgs) Handles FpSpreadSchedule.SelectionChanged

    End Sub

    Private Sub FpSpreadSchedule_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FpSpreadSchedule.MouseUp
        Dim CD As FarPoint.Win.Spread.Cell = ActiveSheet.ActiveCell
        If CD.Column.Index < 2 Then
            ActiveSheet.SetActiveCell(CD.Row.Index, 2)
        Else
            ActiveSheet.SetActiveCell(CD.Row.Index, CD.Column.Index)
        End If
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        SetFont(1)
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        SetFont(-1)
    End Sub

    Private Sub TimerReloadSchedule_Tick(sender As Object, e As EventArgs) Handles TimerReloadSchedule.Tick
        TimerReloadSchedule.Enabled = False
        FpSpreadSchedule.EditMode = False
        FpSpreadSchedule.Focus()

    End Sub

End Class