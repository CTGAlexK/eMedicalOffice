Public Class frmPatientProceduresSwitchSchedule
    Public PatientID As Long

    Private Sub frmPatientProceduresSwitchSchedule_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sWrite)
    End Sub
    Private Sub frmPatientProceduresSwitchSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead)
        If Val(PatientID) <> 0 Then
            txtSearch.Text = PatientID
        End If
    End Sub
    Private Sub Load_PatientProcedures()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewProcedures.Items.Clear()
        If Val(TextBox1.Tag) = 0 Then
            Exit Sub
        End If
        SQL = "SELECT  PatientProcedureStatuses.Description as Status,   PatientProcedures.ReferringDoctor, Schedule.ScheduleDateTime, PatientProcedures.ProcID, Procedures.ProcName, PatientProcedures.PatientProcedureID, PatientProcedures.ProcedureStatusID,  PatientProcedureStatuses.Description AS StatusDescription, Employees.Fname + ' ' + Employees.Lname+' '+Employees.Alias AS TRName, PatientProcedures.TreatingProviderID "
        SQL = SQL & " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID LEFT OUTER JOIN Employees ON PatientProcedures.TreatingProviderID = Employees.EmpID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
        'SQL = SQL & " LEFT OUTER JOIN PatientProcedureStatuses on PatientProcedures.ProcedureStatusID=PatientProcedureStatuses.ProcedureStatusID"
        SQL = SQL & " Where PatientProcedures.PatientID = " & Val(TextBox1.Tag)
        SQL = SQL & " ORDER BY PatientProcedures.PatientProcedureID "




        Reader = gSQLGetDataReader(SQL)
        ListViewProcedures.BeginUpdate()
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                LI = ListViewProcedures.Items.Add(CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy hh:mm"), CInt(Val(Reader("ProcedureStatusID").ToString)))
            Else
                LI = ListViewProcedures.Items.Add("", 0)
            End If
            LI.SubItems.Add(Reader("ProcName").ToString)
            LI.SubItems(1).Tag = Reader("PatientProcedureID").ToString
            LI.Tag = Reader("ProcID").ToString
            LI.ToolTipText = Reader("StatusDescription").ToString

            LI.SubItems.Add(Reader("TRName").ToString)
            LI.SubItems.Add(Reader("ReferringDoctor").ToString)
            LI.SubItems.Add(Reader("Status").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewProcedures.Items.Count > 0 Then
            ListViewProcedures.Items(0).Selected = True
            ListViewProcedures.Items(0).EnsureVisible()
        End If
        ListViewProcedures.EndUpdate()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, txtSearch, False)
    End Sub

    Private Sub txtICDCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        TextBox1.Tag = ""
        TextBox1.Text = ""
        Dim Reader As SqlClient.SqlDataReader
        If txtSearch.Text = "" Then Exit Sub
        If IsNumeric(txtSearch.Text) = False Then
            MsgBox("the Patient Number should be numeric value", MsgBoxStyle.Critical)
            txtSearch.Focus()
            Exit Sub
        End If

        TextBox1.Tag = ""
        TextBox1.Text = ""
        Reader = gSQLGetDataReader("select PatientID, FName +' '+MI+' '+LName as pName from patients where PatientID=" & Val(txtSearch.Text))
        If Reader.HasRows Then
            Reader.Read()
            TextBox1.Tag = Reader("PatientID").ToString
            TextBox1.Text = Reader("pName").ToString
            Load_PatientProcedures()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If ListViewProcedures.CheckedItems.Count = 0 Then
            MsgBox("Unable to process. No procedures selectd." & vbCrLf & "Two procedures should be selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewProcedures.CheckedItems.Count > 2 Then
            MsgBox("Unable to process. Too many procedures selectd." & vbCrLf & "Two procedures should be selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewProcedures.CheckedItems.Count < 2 Then
            MsgBox("Unable to process. Two procedures should be selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub

        Dim SupervisorName As String = Suppervisor.SupervisorName


        Dim ProcID1 As Long = ListViewProcedures.CheckedItems(0).Tag
        Dim PatientProcID1 As Long = ListViewProcedures.CheckedItems(0).SubItems(1).Tag
        Dim ProcID2 As Long = ListViewProcedures.CheckedItems(1).Tag
        Dim PatientProcID2 As Long = ListViewProcedures.CheckedItems(1).SubItems(1).Tag
        Dim Proc1Name As String = ListViewProcedures.CheckedItems(0).SubItems(1).Text & " Scheduled Date: " & ListViewProcedures.CheckedItems(0).Text
        Dim Proc2Name As String = ListViewProcedures.CheckedItems(1).SubItems(1).Text & " Scheduled Date: " & ListViewProcedures.CheckedItems(1).Text

        If MsgBox("Please confirm you want to switch the following procedures:" & vbCrLf & vbCrLf & Proc1Name & vbCrLf & vbCrLf & "and" & vbCrLf & vbCrLf & Proc2Name, MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLUpdateData("UPDATE PatientProcedures set ProcID = " & ProcID2 & " WHERE PatientProcedureID = " & PatientProcID1)
        gSQLUpdateData("UPDATE PatientProcedures set ProcID = " & ProcID1 & " WHERE PatientProcedureID = " & PatientProcID2)
        If PatientID = 0 Then
            PatientID = gSQLGetSingleValue("Select PatientID PatientProcedures Where ProcID= " & ProcID1)
        End If
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tScheduleChanged, "Swith Procedures From: " & Proc1Name & " To: " & Proc2Name, gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
        Load_PatientProcedures()
        Dim frm As Form = FormsCollection.FindForm("frmPatient")
        If Not frm Is Nothing Then
            If CType(frm, frmPatient).OpMode <> AddEditMode.AddNew Then
                CType(frm, frmPatient).Load_PatientProcedures()
            End If
        End If
        Me.Close()
    End Sub
End Class
