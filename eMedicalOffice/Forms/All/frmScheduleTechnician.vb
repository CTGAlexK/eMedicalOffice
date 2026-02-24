Imports System.Reflection
Imports log4net
Imports Microsoft.VisualBasic.PowerPacks

Public Class frmScheduleTechnician
    Private SaveObject As PictureBox
    Private SelectedVolume As Integer
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmScheduleTechnician_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        If ComboBoxDiagnostics.SelectedIndex > -1 Then
            SaveSetting(My.Application.Info.ProductName, "Settings", "LastTechSchedule", ComboBoxDiagnostics.SelectedIndex)
        Else
            SaveSetting(My.Application.Info.ProductName, "Settings", "LastTechSchedule", 0)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FpSpread1.Dock = DockStyle.Fill
        SaveStripImage = MenuStrip.BackgroundImage

        Loading = True
        'Me.Location = New Point(0, 0)
        'Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        FullScreenToolStripMenuItem.Checked = False
        FullScreenToolStripMenuItem_Click(Nothing, Nothing)
        If gCurrentEmployee.SC Then
            ToolStripStatusDBServer.Text = gSqlServerName
        End If
        lblOffice.Text = " " & gOfficeName & "    "
        lblDate.Text = Now.ToString("dddd, MMMM dd, yyyy")
        lblTime.Text = Now.ToLongTimeString
        lblUserName.Text = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        FpSpread1.Cursor = Cursors.Default
        FpSpread1.ActiveSheet.RowCount = 0
        FpSpread1.EditModePermanent = False
        FpSpread1.EditMode = False
        Load_Data()
        'FullScreenToolStripMenuItem_Click(Nothing, Nothing)
        Loading = False
        ComboBoxDiagnostics_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Public mnuChanels As ArrayList = New ArrayList

    Private Sub Load_Data()
        Dim I As Long
        Application.DoEvents()
        Dim Reader As SqlClient.SqlDataReader

        Reader = gSQLGetDataReader("SELECT     TOP (200) Diagnostics.DiagName, OfficeDiagnostics.OfficeID, Diagnostics.DiagID FROM OfficeDiagnostics INNER JOIN Diagnostics ON OfficeDiagnostics.DiagID = Diagnostics.DiagID WHERE OfficeDiagnostics.OfficeID = " & gOfficeID & " Order by DiagName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxDiagnostics.Items.Add(New ValueDescription(Reader("DiagID").ToString, Reader("DiagName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        ComboBoxDiagnostics.SelectedIndex = GetSetting(My.Application.Info.ProductName, "Settings", "LastTechSchedule", 0)
        'DateTimePicker1.Value = Now
        'DateTimePicker1.Focus()
        ComboBoxDiagnostics.Focus()

        'FpSpread1.ActiveSheet.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always)
        'FpSpread1.ActiveSheet.SetColumnMerge(1, FarPoint.Win.Spread.Model.MergePolicy.Always)
    End Sub

    Private SaveScheduleID As Long
    Private LastColor As Color
    Private SavedItem As DataRepeaterItem

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click
        FullScreenToolStripMenuItem.Checked = Not FullScreenToolStripMenuItem.Checked

        If FullScreenToolStripMenuItem.Checked Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Normal
            Application.DoEvents()
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
        End If
        'gFullScreen = FullScreenToolStripMenuItem.Checked
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAboutBox.ShowDialog()
        frmAboutBox.Dispose()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Me.Close()
        Application.Exit()
        End
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim printer As New Printing.Compatibility.VB6.Printer
        'printer.PrintAction = Drawing.Printing.PrintAction.PrintToPreview
        'If DataRepeater1.ItemCount = 0 Then Exit Sub
        'If Me.DataRepeater1.ItemCount > 0 Then
        '    ' define a VB Power Packs Printer object

        '    Dim sz As Size = Me.DataRepeater1.CurrentItem.ClientSize
        '    Dim w As Integer = sz.Width
        '    Dim h As Integer = sz.Height

        '    Dim bm As New Bitmap(w, h)

        '    Dim x = 0
        '    Dim y = 100

        '    Dim n As Integer = Me.DataRepeater1.ItemCount
        '    For i As Integer = 1 To n
        '        ' Set item i be the current item so that it can be visible
        '        Me.DataRepeater1.CurrentItemIndex = i - 1

        '        ' Paint the content of the current DataRepeater item to a bitmap
        '        Dim item As DataRepeaterItem = Me.DataRepeater1.CurrentItem
        '        item.DrawToBitmap(bm, item.ClientRectangle)

        '        ' if y coordinate > height of the page, start a new page
        '        If y + h * 15 + 100 > printer.ScaleHeight Then
        '            printer.NewPage()
        '            y = 100
        '        End If

        '        ' Print the bitmap to the printer
        '        printer.PaintPicture(bm, x, y)

        '        ' Calculate the next left,top position
        '        y += h * 15
        '    Next

        '    printer.EndDoc()
        'End If

    End Sub

    Private Loading As Boolean

    Private Sub Load_Schedule(Optional force As Boolean = False)

        Dim SQL As String
        Dim Tbl As DataTable
        Dim Ds As New DataSet
        Dim I As Integer
        Dim arrayImage() As Byte
        Dim ms As System.IO.MemoryStream
        Dim img As System.Drawing.Image
        SaveScheduleID = 0
        LastColor = Color.Transparent
        Application.DoEvents()
        If ComboBoxDiagnostics.SelectedIndex = -1 Then
            FpSpread1.ActiveSheet.RowCount = 0
            FpSpread1.Visible = False
            'My.Computer.Audio.Play(My.Resources.Lock, AudioPlayMode.Background)
            StartScreenSaver()
            Exit Sub
        Else
            If FpSpread1.Visible = False Then
                'My.Computer.Audio.Play(My.Resources.WakeUp, AudioPlayMode.Background)
                FpSpread1.Visible = True
            Else
                'My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
            End If
        End If
        SQL = "SELECT ShowUpDatetime, Injury, CONVERT(varchar, Schedule.ScheduleDateTime, 8) AS SchTime, CONVERT(varchar, Schedule.ShowUpDatetime, 8) AS ShowTime, Procedures.ProcName, Patients.FName + ' ' + Patients.LName AS PatientName, PatientProcedures.PatientSignature, PatientProcedures.TechSignature, Patients.PatientID,Schedule.ScheduleID, PatientProcedures.PatientProcedureID, PatientProcedures.ProcedureStatusID - 1 AS Status"
        SQL &= " FROM         Schedule INNER JOIN PatientProcedures ON Schedule.ScheduleID = PatientProcedures.ScheduleID INNER JOIN Patients ON PatientProcedures.PatientID = Patients.PatientID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID "
        SQL &= " WHERE     (PatientProcedures.ProcedureStatusID = 1 OR PatientProcedures.ProcedureStatusID = 2) "
        If ButtonPresent.Tag = 1 Then
            SQL &= " AND (Schedule.ShowUpDatetime IS NOT NULL)  "
        End If
        '

        SQL &= " AND Patients.OfficeID=" & gOfficeID
        SQL &= " AND (DATEDIFF(d, Schedule.ScheduleDateTime, '" & Now.ToShortDateString & "') =0)"
        SQL &= "  AND (PatientProcedures.DiagID = " & CType(ComboBoxDiagnostics.SelectedItem, ValueDescription).Value & ")"
        SQL &= " ORDER BY Schedule.ShowUpDatetime "

        Ds = gSQLGetDataSet(SQL)
        Tbl = Ds.Tables(0)
        If Check_Changes(Tbl) Or force Then
            With FpSpread1.ActiveSheet
                .RowCount = 0
                .RowCount = Tbl.Rows.Count
                'FpSpread1.ActiveSheet.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Restricted)
                Do Until I = Tbl.Rows.Count
                    arrayImage = Nothing
                    ms = Nothing
                    img = Nothing
                    FpSpread1.ActiveSheet.Rows(I).Height = 70
                    FpSpread1.ActiveSheet.Rows(I).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center

                    .Cells(I, 0).Tag = Tbl.Rows(I).Item("PatientID").ToString
                    .Cells(I, 1).Tag = Tbl.Rows(I).Item("PatientName").ToString
                    .Cells(I, 2).Tag = Tbl.Rows(I).Item("PatientProcedureID").ToString
                    .Cells(I, 3).Tag = Tbl.Rows(I).Item("ScheduleID").ToString

                    .SetText(I, 0, CDate(Tbl.Rows(I).Item("SchTime")).ToString("hh:mm tt"))
                    .SetText(I, 1, Tbl.Rows(I).Item("PatientID").ToString & vbCrLf & Tbl.Rows(I).Item("PatientName").ToString & IIf(Tbl.Rows(I).Item("Injury").ToString().Trim() <> "", vbCrLf & Tbl.Rows(I).Item("Injury").ToString().Trim(), ""))
                    .SetText(I, 2, Tbl.Rows(I).Item("ProcName").ToString)
                    If Tbl.Rows(I).Item("ShowUpDatetime").ToString = "" Then
                        FpSpread1.ActiveSheet.Rows(I).ForeColor = Color.LightGray
                        Dim lbl As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType
                        lbl.ReadOnly = True
                        .Cells(I, 3).CellType = lbl
                        .SetText(I, 3, "")
                    Else
                        .SetText(I, 3, Tbl.Rows(I).Item("Status").ToString)
                    End If

                    I = I + 1
                Loop
            End With
            lblStatus.Text = "Procedures: " & FpSpread1.ActiveSheet.RowCount & "   "
            gSpreadActivateCell(FpSpread1, 0, 1)
            FpSpread1_SizeChanged(Nothing, Nothing)
            Count_Complete()
        End If
    End Sub

    Private Function Check_Changes(ByVal Tbl As DataTable) As Boolean
        Dim I As Integer

        If FpSpread1.ActiveSheet.RowCount <> Tbl.Rows.Count Then
            Return True
        End If
        For I = 0 To FpSpread1.ActiveSheet.RowCount - 1
            If CDbl(FpSpread1.ActiveSheet.Cells(I, 2).Tag) <> CDbl(Tbl.Rows(I).Item("PatientProcedureID")) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub Count_Complete()
        Dim C As Integer = 0
        Dim I As Integer
        With FpSpread1.ActiveSheet
            For I = 0 To .RowCount - 1
                'If .Cells(I, 5).Value = 1 Then
                If IsNumeric(.Cells(I, 3).Value) Then
                    If .Cells(I, 3).Value = 1 Then
                        C = C + 1
                    End If
                End If
            Next
        End With
        ToolStripStatusLabelComplete.Text = "Completed: " & C & "   "
    End Sub

    Private Sub ComboBoxDiagnostics_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDiagnostics.SelectedIndexChanged
        If ComboBoxDiagnostics.SelectedIndex = -1 Then Exit Sub
        If Loading Then Exit Sub
        Application.DoEvents()

        Load_Schedule()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ComboBoxDiagnostics_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub DataRepeater1_Enter(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataRepeater1_CurrentItemIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FpSpread1_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellDoubleClick
        Dim Ret As Integer = 0
        Dim PatientProcedureID As Long = 0
        Dim PatientID As Long = 0
        Dim SchTime As String
        Dim ProcName As String
        Dim ScheduleID As Long
        If e.ColumnHeader Then Exit Sub
        If e.RowHeader Then Exit Sub
        Dim PatientName As String
        PatientProcedureID = FpSpread1.ActiveSheet.Cells(e.Row, 2).Tag
        PatientID = FpSpread1.ActiveSheet.Cells(e.Row, 0).Tag
        SchTime = FpSpread1.ActiveSheet.Cells(e.Row, 0).Text
        ProcName = FpSpread1.ActiveSheet.Cells(e.Row, 2).Text
        PatientName = FpSpread1.ActiveSheet.Cells(e.Row, 1).Tag
        Dim ApprovedByID As Long
        Dim ApprovedByName As String
        If Long.TryParse(FpSpread1.ActiveSheet.Cells(e.Row, 3).Tag, ScheduleID) = False Then
            Exit Sub
        End If
        If IsNumeric(FpSpread1.ActiveSheet.Cells(e.Row, 3).Value) = False Then
            ''MsgBox("Unable to change status for the NOT present patient...", vbExclamation, "Oops")
            Exit Sub
        End If

        With FpSpread1.ActiveSheet
            Try
                If .Cells(e.Row, 3).Value = 1 Then
                    If gCurrentEmployee.PositionID > 3 Then
                        frmSupervisorApproval.LabelMsg.Text = "Authorization required:" & vbCrLf & "set procedure as Incomplete"
                        If frmSupervisorApproval.ShowDialog <> DialogResult.OK Then
                            frmSupervisorApproval.Dispose()
                            .Cells(e.Row, 3).Value = 0
                            Exit Sub
                        End If
                        ApprovedByID = frmSupervisorApproval.SupervisorID
                        ApprovedByName = frmSupervisorApproval.SupervisorName
                        frmSupervisorApproval.Dispose()
                    Else
                        'If MsgBox("Undone Procedure." & vbCrLf & vbCrLf & "Please confirm?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = vbNo Then
                        '    Exit Sub
                        'End If
                        ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
                    End If
                    frmScheduleUndone.Load_Procedures(ScheduleID)
                    frmScheduleUndone.MinimizeBox = False
                    frmScheduleUndone.MaximizeBox = False
                    If frmScheduleUndone.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        gUpdate_Profile_Log(PatientID, PatientLogTypes.tScheduleNotCompleted, "Schedule: " & SchTime & ". Procedure marked done by mistake", ApprovedByName)
                        .Cells(e.Row, 3).Value = 0
                    End If
                    frmScheduleUndone.Dispose()
                    '.Cells(e.Row, 3).Value = Process_Complete(False, PatientProcedureID, PatientID, SchTime, ProcName, PatientName)
                Else
                    frmScheduleComplete.Load_Procedures(ScheduleID)
                    frmScheduleComplete.MinimizeBox = False
                    frmScheduleComplete.MaximizeBox = False
                    If frmScheduleComplete.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        .Cells(e.Row, 3).Value = 1
                    End If
                    frmScheduleComplete.Dispose()
                    '.Cells(e.Row, 3).Value = Process_Complete(True, PatientProcedureID, PatientID, SchTime, ProcName, PatientName)
                End If
            Catch ex As Exception
                log.Error(ex)
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
            Button1_Click(Nothing, Nothing)
            Count_Complete()
        End With
    End Sub

    Private Function Process_Complete(ByVal Complete As Boolean, ByVal PatientProcedureID As Long, ByVal PatientID As Long, ByVal SchTime As String, ByVal ProcName As String, PatName As String) As Integer
        'If Complete = False Then
        '    If MsgBox("Please confirm the Procedure: " & vbCrLf & ProcName & vbCrLf & "Patient: " & vbCrLf & PatName & vbCrLf & " has NOT been completed?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.No Then
        '        Return 1
        '    End If
        'End If

        Dim ScheduleDT As String = Now.Date.ToString("MM/dd/yyyy") & " " & SchTime
        'If PatientSign = "" And Complete Then
        '    MsgBox("Unable to set this procedure as completed." & vbCrLf & "The Patient's signature is missing.", MsgBoxStyle.Exclamation)
        '    Return 0
        'End If
        'If TechSign = "" And Complete Then
        '    MsgBox("Unable to set this procedure as completed." & vbCrLf & "The Thechnician signature is missing.", MsgBoxStyle.Exclamation)
        '    Return 0
        'End If
        'If Complete Then
        '    If MsgBox("Please confirm the Procedure: " & vbCrLf & ProcName & "Patient: " & vbCrLf & PatName & vbCrLf & "has been completed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        Return 0
        '    End If
        'End If

        Dim TA As New SqlClient.SqlDataAdapter("SELECT BillingStatusDate, TechID, ProcedureStatusID, UpdatedDT, UpdatedByEmpID, PatientProcedureID, PACSAltNumber FROM PatientProcedures WHERE PatientProcedureID = " & PatientProcedureID, gConnectionString)
        Dim CB As New SqlClient.SqlCommandBuilder(TA)
        Dim TR As DataRow
        Dim dTab As New DataTable("PatientProcedures")
        TA.Fill(dTab)
        TR = dTab.Rows(0)
        If Complete Then
            TR("ProcedureStatusID") = 2
            TR("BillingStatusDate") = Now
            TR("TechID") = gCurrentEmployee.EmpID
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tScheduleCompleted, "Schedule Status Set Completed " & ScheduleDT)
        Else
            TR("ProcedureStatusID") = 1
            TR("BillingStatusDate") = DBNull.Value
            TR("TechID") = 0
            TR("PACSAltNumber") = ""
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tUpdated, "Schedule Status Set Not Completed " & ScheduleDT)
        End If
        TR("UpdatedDT") = Now.ToString("MM/dd/yyyy")
        TR("UpdatedByEmpID") = gCurrentEmployee.EmpID
        TA.UpdateCommand = CB.GetUpdateCommand(True)
        Try
            TA.Update(dTab)
            dTab.AcceptChanges()
        Catch ex As Exception
            log.Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return Complete
        End Try
        dTab.Dispose() : CB.Dispose() : TA.Dispose()
        If Complete Then
            Return 1
        Else
            Return 0
        End If

    End Function

    Private Function Capture_Signature(ByVal CapturePatient As String, ByVal PatientProcedureID As Long, ByVal InitialImage As String) As String
    End Function

    Private Sub FpSpread1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FpSpread1.MouseDown
        Dim HT As FarPoint.Win.Spread.HitTestInformation

        If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub
        HT = FpSpread1.HitTest(e.X, e.Y)
        If HT.ViewportInfo Is Nothing Then
            FpSpread1.ContextMenuStrip = Nothing
            Exit Sub
        End If

        If HT.ViewportInfo.Column = -1 Or HT.ViewportInfo.Row = -1 Then
            FpSpread1.ContextMenuStrip = Nothing
            Exit Sub
        End If
        Dim C As FarPoint.Win.Spread.Cell = FpSpread1.ActiveSheet.Cells(HT.ViewportInfo.Row, HT.ViewportInfo.Column)
        FpSpread1.ContextMenuStrip = Nothing
        If C Is Nothing Then Exit Sub
        FpSpread1.ActiveSheet.SetActiveCell(C.Row.Index, C.Column.Index)
        If C.Row.Index < 0 Then Exit Sub
        'ToolStripSeparatorShowInfo.Visible = True
        'If C.Column.Index = 3 Then
        '    '            Img = FpSpread1.ActiveSheet.Cells(C.Row.Index, 3).Value
        '    'If Img Is Nothing Then
        '    If FpSpread1.ActiveSheet.Cells(C.Row.Index, 3).Text = "" Then
        '        CaptureSignatureToolStripMenuItem.Text = "Capture Patient's Signature"
        '        RemoveSignatureToolStripMenuItem.Visible = False
        '    Else
        '        CaptureSignatureToolStripMenuItem.Text = "Re Capture Patient's Signature"
        '        RemoveSignatureToolStripMenuItem.Visible = True
        '        RemoveSignatureToolStripMenuItem.Text = "Remove Patient's Signature"
        '    End If
        '    'FpSpread1.ContextMenuStrip = ContextMenuStrip1
        'ElseIf C.Column.Index = 4 Then

        '    If FpSpread1.ActiveSheet.Cells(C.Row.Index, 4).Text = "" Then
        '        CaptureSignatureToolStripMenuItem.Text = "Capture Technician's Signature"
        '        RemoveSignatureToolStripMenuItem.Visible = False
        '    Else
        '        CaptureSignatureToolStripMenuItem.Text = "Re Capture Technician's Signature"
        '        RemoveSignatureToolStripMenuItem.Visible = True
        '        RemoveSignatureToolStripMenuItem.Text = "Remove Technician's Signature"
        '    End If
        'Else
        '    CaptureSignatureToolStripMenuItem.Visible = False
        '    RemoveSignatureToolStripMenuItem.Visible = False
        '    ToolStripSeparatorShowInfo.Visible = False
        'End If
        FpSpread1.ContextMenuStrip = ContextMenuStrip1
        'RemoveSignatureSeparator.Visible = RemoveSignatureToolStripMenuItem.Visible
    End Sub

    Public Sub New()
        Loading = True
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub PrintScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintScheduleToolStripMenuItem.Click
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to print. No schedule data loaded for printing.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        FpSpread1.ActiveSheet.Columns(3).Visible = False
        FpSpread1.ActiveSheet.Columns(4).Visible = False
        FpSpread1.ActiveSheet.Rows(0, FpSpread1.ActiveSheet.Rows.Count - 1).Height = 17
        FpSpread1.Refresh()
        Printinfo.Header = "SCHEDULE TODO LIST " & ComboBoxDiagnostics.Text & " - " & Now.ToShortTimeString
        Printinfo.Preview = True
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office Schedule ToDo List"
        Printinfo.ShowColor = True
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.UseMax = True
        FpSpread1.ActiveSheet.PrintInfo = Printinfo
        FpSpread1.PrintSheet(FpSpread1.ActiveSheet)
        FpSpread1.ActiveSheet.Rows(0, FpSpread1.ActiveSheet.Rows.Count - 1).Height = 60
        FpSpread1.ActiveSheet.Columns(3).Visible = True
        FpSpread1.ActiveSheet.Columns(4).Visible = True
    End Sub

    Private Sub EmailScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailScheduleToolStripMenuItem.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to email. No schedule data loaded for email.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Subject = "Message From " & gOfficeName & " / Schedule ToDo List " & ComboBoxDiagnostics.Text & " - " & Now.ToShortTimeString

        Dim FName As String = System.IO.Path.GetTempFileName.ToString
        FName = FName.Replace("tmp", "xls")
        FpSpread1.SaveExcel(FName)
        Try
            Msg.SendMail(FName, Subject, Subject)
        Catch ex As Exception
            log.Error("Error Sending Email", ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private SaveStripImage As Image
    Private SelectedTVChanel As String

    Private Sub Show_Chanel(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mnu As ToolStripMenuItem

        For Each mnu In mnuChanels
            mnu.Checked = False
        Next
        CType(sender, ToolStripMenuItem).Checked = True
        SelectedTVChanel = sender.tag
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        ExitToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub frmScheduleTechnician_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Resize_columns()
    End Sub

    Private Sub Resize_columns()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBoxDiagnostics.SelectedIndex = -1 Then Exit Sub
        If Loading Then Exit Sub

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Load_Schedule(True)
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Cursor = Cursors.Default
    End Sub

    Private Sub FpSpread1_SizeChanged(sender As Object, e As EventArgs) Handles FpSpread1.SizeChanged
        Try
            Dim spreadwidth As Integer
            If FpSpread1.ActiveSheet Is Nothing Then
                Exit Sub
            End If
            spreadwidth = (FpSpread1.Width - FpSpread1.ActiveSheet.RowHeader.Columns(0).Width) - FpSpread1.VerticalScrollBar.Width - 2

            FpSpread1.ActiveSheet.Columns(0).Width = (spreadwidth / 8) * 1
            FpSpread1.ActiveSheet.Columns(1).Width = ((spreadwidth / 8) * 3)
            FpSpread1.ActiveSheet.Columns(2).Width = (spreadwidth / 8) * 3
            FpSpread1.ActiveSheet.Columns(3).Width = (spreadwidth / 8) * 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        FullScreenToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub RefreshScheduleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshScheduleToolStripMenuItem.Click
        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        lblDate.Text = Now.ToString("dddd, MMMM dd, yyyy")
        lblTime.Text = Now.ToLongTimeString
    End Sub

    Private Sub FpSpread1_ButtonClicked(sender As Object, e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ButtonClicked
        Stop
    End Sub

    Private Sub FpSpread1_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellClick

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub SetStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetStatusToolStripMenuItem.Click
        If FpSpread1.ActiveSheet Is Nothing Then Exit Sub
        If FpSpread1.ActiveSheet.ActiveCell Is Nothing Then Exit Sub
        If FpSpread1.ActiveSheet.ActiveCell.Row.Index = -1 Then Exit Sub
        If FpSpread1.ActiveSheet.ActiveCell.Column.Index = -1 Then Exit Sub
        FpSpread1_CellDoubleClick(FpSpread1, New FarPoint.Win.Spread.CellClickEventArgs(Nothing, FpSpread1.ActiveSheet.ActiveCell.Row.Index, 3, Nothing, 0, 0, False, False))
    End Sub

    Private Sub ToolStripMenuItem4_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        SetStatusToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonPresent_Click(sender As Object, e As EventArgs) Handles ButtonPresent.Click
        If ButtonPresent.Tag = 0 Then
            ButtonPresent.Tag = 1
            ButtonPresent.Image = My.Resources.Present
            ToolTip1.SetToolTip(ButtonPresent, "Show All Schedules")
        Else
            ButtonPresent.Tag = 0
            ButtonPresent.Image = My.Resources.NotPresent
            ToolTip1.SetToolTip(ButtonPresent, "Show Present Patients Only")
        End If
        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If FpSpread1.ActiveSheet Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveCell Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveCell.Row.Index = -1 Then
            e.Cancel = True
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveCell.Column.Index = -1 Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Row As Integer = FpSpread1.ActiveSheet.ActiveCell.Row.Index
        If IsNumeric(FpSpread1.ActiveSheet.Cells(Row, 3).Value) = False Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub ToolsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ToolsToolStripMenuItem.DropDownOpening
        ToolStripMenuItem4.Visible = False
        If FpSpread1.ActiveSheet Is Nothing Then
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveCell Is Nothing Then
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveCell.Row.Index = -1 Then
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveCell.Column.Index = -1 Then
            Exit Sub
        End If
        If IsNumeric(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveCell.Row.Index, 3).Value) = False Then
            Exit Sub
        End If
        ToolStripMenuItem4.Visible = True
    End Sub

    Private Sub MenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

End Class