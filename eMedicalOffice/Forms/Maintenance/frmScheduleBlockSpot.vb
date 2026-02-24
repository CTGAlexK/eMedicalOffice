Imports System.Reflection
Imports log4net

Public Class frmScheduleBlockSpot
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public DT As DateTime
    Public DiagID As Long
    Public calledForm As frmSchedule
    Public AdminLoggedIn As Boolean

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmActionsPool_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(My.Application.Info.ProductName, "Settings", "SpotBlockreason", TextBox1.Text)
    End Sub

    Private Sub frmScheduleBlockSpot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = GetSetting(My.Application.Info.ProductName, "Settings", "SpotBlockreason", "")
        ComboBox1.SelectedIndex = 0
        If AdminLoggedIn = True Then
            PanelSecurity.Visible = False
            Height = 225
        End If

    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim curDate As Date
        Dim endDate As Date
        Dim blockTime As String = ""
        Dim blockDateTime As DateTime
        Dim diagResult As DialogResult
        Dim SchedulesFound As String = ""
        Dim b As Integer
        Dim DatesList As New List(Of DateTime)
        Dim SupervisorName As String
        Dim BlockedBy As Long

        If PanelSecurity.Visible Then
            Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
            If Suppervisor.SupervisorName = "" Then Exit Sub
            SupervisorName = Suppervisor.SupervisorName
            BlockedBy = Suppervisor.SupervisorID
            If SupervisorName = "" Then
                Panel2.Enabled = True
                Return
            End If
        End If
        If BlockedBy = 0 Then
            BlockedBy = gCurrentEmployee.EmpID
        End If
        Panel2.Enabled = False
        If TextBox1.Text.Trim.Length = 0 Then
            TextBox1.Text = "Admin Block"
        End If

        If ComboBox1.SelectedIndex = 0 Then
            DatesList.Add(DT)
        ElseIf ComboBox1.SelectedIndex = 1 Then

            curDate = CDate(DT.ToShortDateString)
            endDate = DateAdd(DateInterval.Day, 7, curDate)
            endDate = endDate.AddDays(-1)
            blockTime = DT.ToShortTimeString
            Do While curDate <= endDate
                b = b + 1
                LabelStatus.Text = "Validating Spot [" & b & "]"
                LabelStatus.Refresh()
                blockDateTime = CDate(curDate.ToShortDateString & " " & blockTime)
                If gSQLGetSingleValue("SELECT count(*) FROM Schedule INNER JOIN PatientProcedures ON Schedule.ScheduleID = PatientProcedures.ScheduleID where ScheduleDateTime = '" & blockDateTime & "' and DiagID =" & DiagID & " and OfficeID = " & gOfficeID) > 0 Then
                    SchedulesFound = SchedulesFound & blockDateTime & vbCrLf
                Else
                    If gSQLGetSingleValue("SELECT count(*) FROM ScheduleBlock where Removedby is NULL and ScheduleDateTime = '" & blockDateTime & "' and DiagID =" & DiagID & " and OfficeID = " & gOfficeID) = 0 Then
                        DatesList.Add(blockDateTime)
                    End If
                End If
                curDate = curDate.AddDays(1)
            Loop
            If SchedulesFound = "" Then
                If MsgBox("Please confirm you want to block Spots for a Week?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm...") = MsgBoxResult.No Then
                    Panel2.Enabled = True
                    Return
                End If
            Else
                If MsgBox("The following schedule(s) already exist " & vbCrLf & vbCrLf & SchedulesFound & vbCrLf & vbCrLf & "Would you like to blocks Spots for a Week avoiding an existing schedule(s)?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm...") = MsgBoxResult.No Then
                    Panel2.Enabled = True
                    LabelStatus.Text = ""
                    Return
                End If
            End If

        ElseIf ComboBox1.SelectedIndex = 2 Then

            curDate = CDate(DT.ToShortDateString)
            endDate = DateAdd(DateInterval.Month, 1, curDate)
            endDate = endDate.AddDays(-1)
            blockTime = DT.ToShortTimeString
            Do While curDate <= endDate
                b = b + 1
                LabelStatus.Text = "Validating Spot [" & b & "]"
                LabelStatus.Refresh()
                blockDateTime = CDate(curDate.ToShortDateString & " " & blockTime)
                If gSQLGetSingleValue("SELECT count(*) FROM Schedule INNER JOIN PatientProcedures ON Schedule.ScheduleID = PatientProcedures.ScheduleID where ScheduleDateTime = '" & blockDateTime & "' and DiagID =" & DiagID & " and OfficeID = " & gOfficeID) > 0 Then
                    SchedulesFound = SchedulesFound & blockDateTime & vbCrLf
                Else
                    If gSQLGetSingleValue("SELECT count(*) FROM ScheduleBlock where Removedby is NULL and ScheduleDateTime = '" & blockDateTime & "' and DiagID =" & DiagID & " and OfficeID = " & gOfficeID) = 0 Then
                        DatesList.Add(blockDateTime)
                    End If
                End If
                curDate = curDate.AddDays(1)
            Loop
            If SchedulesFound = "" Then
                If MsgBox("Please confirm you want to block Spots for a Month?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm...") = MsgBoxResult.No Then
                    Panel2.Enabled = True
                    Return
                End If
            Else
                If MsgBox("The following schedule(s) already exist " & vbCrLf & vbCrLf & SchedulesFound & vbCrLf & vbCrLf & "Would you like to block Spots for a Month avoiding an existing schedule(s)?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm...") = MsgBoxResult.No Then
                    Panel2.Enabled = True
                    LabelStatus.Text = ""
                    Return
                End If
            End If
        Else
            Return
        End If
        b = 0
        For Each blockDateTime In DatesList
            b = b + 1
            LabelStatus.Text = "Processing Spot [" & b & "]"
            LabelStatus.Refresh()
            gSQLUpdateData("INSERT INTO [ScheduleBlock]   ([ScheduleDateTime] ,[OfficeID] ,[DiagID] ,[InsertedDT],[insertedBy],[Comments]) VALUES('" & blockDateTime & "', " & gOfficeID & ", " & DiagID & ", getdate(), " & BlockedBy & ", '" & TextBox1.Text.Trim.ToSafeSQLString() & "')")
        Next

        LabelStatus.Text = ""
        calledForm.SchedulkeBlockID = gSQLGetSingleValue("Select IDENT_CURRENT('ScheduleBlock')")
        calledForm.SchedulkeBlockComment = TextBox1.Text.Trim
        Me.DialogResult = DialogResult.OK

    End Sub

    Private Sub frmScheduleBlockSpot_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If TextBox1.CanFocus Then
            TextBox1.Focus()
            TextBox1.SelectAll()
        End If
    End Sub

    Private Sub PictureBox4_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox4.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub PictureBox4_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox4.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdUpdate_Click(Nothing, Nothing)
        End If
    End Sub

End Class