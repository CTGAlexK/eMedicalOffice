Public Class frmInsuranceExamination
    Public PatientID As Integer
    Public ExaminationID As Integer
    Public ScheduleDate As DateTime
    Public Status As Integer
    Public Enum sType
        All = 0
        Past = 1
        Future = 2
    End Enum
    Private FlashCount As Integer
    Private Sub frmScheduleCancelationReason_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub frmScheduleCancelationReason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ExaminationID = 0 Then
            LabelInfo.Text = gCurrentEmployee.FName & ", please do the following:" & vbCrLf
            LabelInfo.Text &= "Explain Patient the Importance of this appointment!" & vbCrLf
            LabelInfo.Text &= "Inform Patient that we will provide round-trip transportation."
            DateTimePickerDate.Value = Now.AddDays(1)
        Else
            DateTimePickerDate.Value = ScheduleDate
            DateTimePickerTime.Value = ScheduleDate
            gFindComboItemByValue(cboStatus, Status, True)
        End If
    End Sub
    Public Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        cboType.Items.Clear()
        SQL = "Select * from InsuranceExaminationsTypes order by TypeID"
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                cboType.Items.Add(New ValueDescription(Val(Reader("TypeID").ToString), Reader("Description").ToString))
            Loop
        End If
        Reader.Close()

        Load_Statuses()
    End Sub
    Public Sub Load_Statuses(Optional ByVal Past As sType = sType.All)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        cboStatus.Items.Clear()
        Select Case Past
            Case sType.All
                SQL = "Select * from InsuranceExaminationStatuses order by StatusID"
            Case sType.Past
                SQL = "Select * from InsuranceExaminationStatuses Where StatusID>2 order by StatusID"
            Case sType.Future
                SQL = "Select * from InsuranceExaminationStatuses Where StatusID<3 order by StatusID"
        End Select
        If Past = False Then

        Else

        End If
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                cboStatus.Items.Add(New ValueDescription(Val(Reader("StatusID").ToString), Reader("Description").ToString))
            Loop
        End If
        Reader.Close()


    End Sub
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Sql As String
        Dim Reader As SqlClient.SqlDataReader
        Dim EUOIMEMessage As String
        If cboType.SelectedIndex = -1 Then
            MsgBox("Unable to update. The Type Should be selected.", MsgBoxStyle.Exclamation)
            cboType.Focus()
            Exit Sub
        End If
        If DateTimePickerDate.Value.Date < Now.Date And ExaminationID = 0 Then
            If MsgBox("Attention!" & vbCrLf & vbCrLf & "The selected Examination Date is Past Date." & vbCrLf & vbCrLf & "Please confirm?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                DateTimePickerDate.Focus()
                Exit Sub
            End If
        End If
        If cboStatus.SelectedIndex = -1 Then
            MsgBox("Unable to update. The Status Should be selected.", MsgBoxStyle.Exclamation)
            cboStatus.Focus()
            Exit Sub
        End If
        If ExaminationID = 0 Then
            Sql = "SELECT     Schedule.ScheduleID, Schedule.ScheduleDateTime, Procedures.ProcName "
            Sql &= " FROM Schedule INNER JOIN PatientProcedures ON Schedule.ScheduleID = PatientProcedures.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID "
            Sql &= " WHERE     (PatientProcedures.PatientID = " & PatientID & ") AND (CAST(FLOOR(CAST(Schedule.ScheduleDateTime AS FLOAT)) AS DATETIME) = '" & DateTimePickerDate.Value.Date & "')"
            Reader = gSQLGetDataReader(Sql)
            EUOIMEMessage = ""
            If Not Reader Is Nothing Then
                If Reader.HasRows Then
                    Do Until Reader.Read = False
                        EUOIMEMessage &= CDate(Reader("ScheduleDateTime").ToString).ToShortDateString & " " & Reader("ProcName").ToString & vbCrLf
                    Loop
                    MsgBox("ATTENTION!" & vbCrLf & vbCrLf & "The following procedure(s) has been scheduled on IME Schedule Date!" & vbCrLf & vbCrLf & EUOIMEMessage & vbCrLf & vbCrLf & "All procedures scheduled for this date should be rescheduled!", MsgBoxStyle.Critical)
                End If
            End If
            Sql = "INSERT INTO InsuranceExaminations (TypeID, PatientID, ScheduleDate, StatusID, AddressComments, EmpID, CreatedDT)"
            Sql &= " VALUES(" & CType(cboType.SelectedItem, ValueDescription).Value & ", " & PatientID & ", '" & DateTimePickerDate.Value.ToShortDateString & " " & DateTimePickerTime.Value.ToShortTimeString & "', " & CType(cboStatus.SelectedItem, ValueDescription).Value & ", '" & txtIMEEUOAddress.Text.ToSafeSQLString() & "', " & gCurrentEmployee.EmpID & ", getdate())"
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tInsuranceExaminationScheduled, cboType.Text & " scheduled at: " & DateTimePickerDate.Value.ToShortDateString & " " & DateTimePickerTime.Value.ToShortTimeString)

        Else
            Sql = "UPDATE InsuranceExaminations "
            Sql &= " set StatusID = " & CType(cboStatus.SelectedItem, ValueDescription).Value
            Sql &= " ,AddressComments = '" & txtIMEEUOAddress.Text.ToSafeSQLString() & "'"
            Sql &= " ,ScheduleDate = '" & DateTimePickerDate.Value.ToShortDateString & " " & DateTimePickerTime.Value.ToShortTimeString & "'"
            Sql &= " WHERE ID = " & ExaminationID
            If Val(cboType.Tag) <> CType(cboType.SelectedItem, ValueDescription).Value Then
                Select Case CType(cboType.SelectedItem, ValueDescription).Value
                    Case 1 ' Scheduled
                        gUpdate_Profile_Log(PatientID, PatientLogTypes.tInsuranceExaminationScheduled, cboType.Text & " Scheduled At: " & DateTimePickerDate.Value.ToShortDateString & " " & DateTimePickerDate.Value.ToShortTimeString)
                    Case 2
                        gUpdate_Profile_Log(PatientID, PatientLogTypes.tInsuranceExaminationConfirmed)
                    Case 3
                        gUpdate_Profile_Log(PatientID, PatientLogTypes.tInsuranceExaminationComplete)
                    Case 4
                        gUpdate_Profile_Log(PatientID, PatientLogTypes.tInsuranceExaminationNoShow)
                    Case 5
                        gUpdate_Profile_Log(PatientID, PatientLogTypes.tInsuranceExaminationCanceledRescheduled)
                End Select
            End If
        End If
        gSQLUpdateData(Sql)

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DateTimePickerDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerDate.ValueChanged
        If ExaminationID = 0 Then
            If DateTimePickerDate.Value.Date < Now.Date Then
                Load_Statuses(sType.Past)
            ElseIf DateTimePickerDate.Value.Date > Now.Date Then
                Load_Statuses(sType.Future)
            Else
                Load_Statuses()
            End If
        Else
            Load_Statuses()
        End If
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        FlashCount = 0
        LabelInfo.ForeColor = Color.White
        Timer1.Enabled = False
        PictureBox2.Visible = False
        Select Case CType(cboStatus.SelectedItem, ValueDescription).Value
            Case 1, 2
                LabelInfo.Text = gCurrentEmployee.FName & ", please do the following:" & vbCrLf
                LabelInfo.Text &= "1. Explain Patient the Importance of this " & cboType.Text & " appointment!" & vbCrLf
                LabelInfo.Text &= "2. Inform Patient that we will provide round-trip transportation." & vbCrLf
                LabelInfo.Text &= "3. Contact the transportation company to schedule Patient's pickup."
                LabelInfo.BackColor = Color.Maroon
                PictureBox2.Visible = False
            Case 3
                LabelInfo.Text = gCurrentEmployee.FName & "! Good Job! Thanks."
                LabelInfo.BackColor = Color.SeaGreen
                PictureBox2.Visible = False
            Case 4
                LabelInfo.Text = gCurrentEmployee.FName & ", please do the following:" & vbCrLf
                LabelInfo.Text &= "1. Contact the Patient's Attorney Immediately to reschedule missed " & cboType.Text & " appointment!" & vbCrLf
                LabelInfo.Text &= "2. Explain Patient the Importance of this " & cboType.Text & " appointment!" & vbCrLf
                LabelInfo.Text &= "3. Inform Patient that we will provide round-trip transportation." & vbCrLf
                LabelInfo.Text &= "4. Immediately Inform the Manager about missed " & cboType.Text & " appointment!"
                LabelInfo.BackColor = Color.Maroon
                PictureBox2.Visible = True
                Timer1.Enabled = True
            Case 5
                LabelInfo.Text = gCurrentEmployee.FName & ", please do the following:" & vbCrLf
                LabelInfo.Text &= "1. Contact the Patient's Attorney Immediately to get new " & cboType.Text & " appointment information!" & vbCrLf
                LabelInfo.Text &= "2. Explain Patient the Importance of this " & cboType.Text & " appointment!" & vbCrLf
                LabelInfo.Text &= "3. Inform Patient that we will provide round-trip transportation." & vbCrLf
                LabelInfo.Text &= "4. Immediately Inform the Manager about missed " & cboType.Text & " appointment!"
                PictureBox2.Visible = True
                LabelInfo.BackColor = Color.Maroon
                Timer1.Enabled = True
        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        FlashCount = FlashCount + 1
        If FlashCount = 6 Then
            Timer1.Enabled = False
            FlashCount = 0
            PictureBox2.Visible = True
        Else
            If PictureBox2.Visible = True Then
                PictureBox2.Visible = False
            Else
                PictureBox2.Visible = True
            End If
        End If
    End Sub
End Class