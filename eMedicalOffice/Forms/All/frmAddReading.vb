Imports System.Reflection
Imports log4net

Public Class frmAddReading
    Public TextBoxReading As TextBox
    Public ListViewReadings As ListView
    Public PatientProcedureID As Long = 0
    Public PatientID As Long = 0
    Public ReadingID As Long = 0
    Public DoctorID As Long
    Public ScheduleDate As String
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim LI As ListViewItem
        If ReadingID > 0 Then
            If gSQLGetSingleValue("SELECT     BillProcedures.BillID FROM PatientProcedureReadings INNER JOIN BillProcedures ON PatientProcedureReadings.PatientProcedureID = BillProcedures.PatientProcedureID WHERE PatientProcedureReadings.ResultID = " & ReadingID) > 0 Then
                MsgBox("Unable to process your request." & vbCrLf & "The current procedure is already has been billed." & vbCrLf & "The reading report can not be updated.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        If cboDoctor.SelectedIndex = -1 Then
            MsgBox("Unable to process update. Please select the Reading Doctor", MsgBoxStyle.Exclamation)
            cboDoctor.Focus()
            Exit Sub

        End If
        If txtResultDescription.Text.Trim = "" Then
            MsgBox("Unable to process update. Reading Description is required.", MsgBoxStyle.Exclamation)
            txtResultDescription.Focus()
            Exit Sub
        End If
        If txtResultDescription2.Text.Trim = "" Then
            MsgBox("Unable to process update. Reading Impression is required.", MsgBoxStyle.Exclamation)
            txtResultDescription2.Focus()
            Exit Sub
        End If

        If CType(cboDoctor.SelectedItem, ValueDescription).Value <> DoctorID And DoctorID > 0 Then
            If MsgBox("You have changed the Treating Provider " & vbCrLf & vbCrLf & "From: " & cboDoctor.Tag & vbCrLf & "To: " & CType(cboDoctor.SelectedItem, ValueDescription).Description & vbCrLf & vbCrLf & "Please confirm." & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "Attention!" & vbCrLf & "Check the procedure reading to make sure you have selected the propper Treating Provider!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                cboDoctor.Focus()
                Exit Sub
            End If
        End If
        Try
            If ReadingID > 0 Then
                Dim ApprovedByID As Long
                Dim ApprovedByName As String
                If gCurrentEmployee.PositionID > 3 And gCurrentEmployee.PositionID <> 5 Then
                    frmSupervisorApproval.LabelMsg.Text = "Procedure Reading Update."
                    If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                        frmSupervisorApproval.Dispose()
                        Exit Sub
                    End If
                    ApprovedByID = frmSupervisorApproval.SupervisorID
                    ApprovedByName = frmSupervisorApproval.SupervisorName
                    frmSupervisorApproval.Dispose()
                Else
                    If MsgBox("Please confirm you want to update procedure reading?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    ApprovedByID = gCurrentEmployee.EmpID
                    ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
                End If
                gUpdate_Profile_Log(PatientID, PatientLogTypes.tProcedureReadingUpdated, "Procedure Reading Has Been Updated on " & Now, ApprovedByName)

                'gSQLUpdateData("UPDATE    PatientProcedureReadings SET ResultDescription ='" & RBC(txtResultDescription.Text.Trim) & "', ResultDescription2 = '" & RBC(txtResultDescription2.Text.Trim) & "', DoctorID=" & CType(cboDoctor.SelectedItem, ValueDescription).Value & " WHERE ResultID=" & ReadingID)
                gSQLUpdateData("UPDATE    PatientProcedureReadings SET ResultDescription ='" & txtResultDescription.Text.Trim.ToSafeSQLString() & "', ResultDescription2 = '" & txtResultDescription2.Text.Trim.ToSafeSQLString() & "' WHERE ResultID=" & ReadingID)
                gSQLUpdateData("UPDATE    PatientProcedures SET TreatingProviderID =" & CType(cboDoctor.SelectedItem, ValueDescription).Value & " WHERE PatientProcedureID=" & PatientProcedureID)
                'Update dictation date if doctor forgot
                gSQLUpdateData("UPDATE PatientProcedures SET DictationDate=getdate() WHERE DictationDate is null and PatientProcedureID=" & PatientProcedureID)

                ListViewReadings.SelectedItems(0).SubItems(1).Tag = txtResultDescription.Text.Trim & vbCrLf & txtResultDescription2.Text.Trim
                ListViewReadings.SelectedItems(0).SubItems(2).Text = cboDoctor.Text
                ListViewReadings.SelectedItems(0).SubItems(2).Tag = CType(cboDoctor.SelectedItem, ValueDescription).Value
                ListViewReadings.SelectedItems(0).Tag = New ValueDescription(PatientProcedureID, "", "", txtResultDescription.Text.Trim, txtResultDescription2.Text.Trim, PatientID, ReadingID)
                If IsDate(ListViewReadings.SelectedItems(0).SubItems(3)) = False Then ListViewReadings.SelectedItems(0).SubItems(3).Text = Now.ToShortDateString
                If IsDate(ListViewReadings.SelectedItems(0).SubItems(4)) = False Then ListViewReadings.SelectedItems(0).SubItems(4).Text = Now.ToShortDateString
            Else
                gSQLUpdateData("INSERT INTO PatientProcedureReadings (PatientProcedureID, PatientID, ResultDescription, ResultDescription2, ReadingDate) VALUES     (" & PatientProcedureID & ", " & PatientID & ", '" & txtResultDescription.Text.Trim.ToSafeSQLString() & "', '" & txtResultDescription2.Text.Trim.ToSafeSQLString() & "', getdate())")
                gSQLUpdateData("UPDATE    PatientProcedures SET TreatingProviderID =" & CType(cboDoctor.SelectedItem, ValueDescription).Value & " WHERE PatientProcedureID=" & PatientProcedureID)
                'Update dictation date if doctor forgot
                gSQLUpdateData("UPDATE PatientProcedures SET DictationDate=getdate() WHERE DictationDate is null and PatientProcedureID=" & PatientProcedureID)

                LI = ListViewReadings.SelectedItems(0)
                LI.SubItems(1).Tag = txtResultDescription.Text.Trim & vbCrLf & txtResultDescription2.Text.Trim
                LI.SubItems(2).Text = cboDoctor.Text
                LI.SubItems(2).Tag = CType(cboDoctor.SelectedItem, ValueDescription).Value
                If IsDate(ListViewReadings.SelectedItems(0).SubItems(3)) = False Then ListViewReadings.SelectedItems(0).SubItems(3).Text = Now.ToShortDateString
                LI.SubItems(4).Text = Now.ToShortDateString
                LI.ForeColor = Color.Black
                gSetListItemForeColor(LI, Color.Black)
                LI.Tag = New ValueDescription(PatientProcedureID, "", "", txtResultDescription.Text.Trim, txtResultDescription2.Text.Trim, PatientID, gSQLGetSingleValue("Select IDENT_CURRENT('PatientProcedureReadings')"))
            End If
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmAddComment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            txtResultDescription.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmAddReading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        Load_Data()
        SetFont()
        If ReadingID > 0 Then
            If gSQLGetSingleValue("SELECT     BillProcedures.BillID FROM PatientProcedureReadings INNER JOIN BillProcedures ON PatientProcedureReadings.PatientProcedureID = BillProcedures.PatientProcedureID WHERE PatientProcedureReadings.ResultID = " & ReadingID) > 0 Then
                txtResultDescription.ReadOnly = True
                txtResultDescription2.ReadOnly = True
                ButtonDeleteReading.Enabled = False
                cmdUpdate.Enabled = False
                cboDoctor.Enabled = False
                Button1.Enabled = False
                Button2.Enabled = False
                lblAuth.Text = "The selected reading report in read only mode. Procedure has been billed."
            End If
        End If
        Opacity = 1
    End Sub

    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        txtResultDescription.Font = F
        txtResultDescription2.Font = F
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        SQL = "SELECT     EmpID, Fname, Lname, Alias From Employees WHERE TreatmentPrv = 1 and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ") ORDER BY Fname, Lname"
        Reader = gSQLGetDataReader(SQL)
        cboDoctor.Items.Clear()
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboDoctor.Items.Add(New ValueDescription(Reader("EmpID").ToString, Reader("Fname").ToString & " " & Reader("Lname").ToString & " " & Reader("Alias").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        If DoctorID > 0 Then
            gFindComboItemByValue(cboDoctor, DoctorID, True)
            If cboDoctor.SelectedIndex > -1 Then
                cboDoctor.Tag = CType(cboDoctor.SelectedItem, ValueDescription).Description
                'cboDoctor.Enabled = False
            End If
        End If
    End Sub

    Private Sub ButtonDeleteReading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeleteReading.Click
        If ReadingID = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "The current reading report has not been saved yet." & vbCrLf & "If you decide to not save the current reading report, click the cancel button.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If gSQLGetSingleValue("SELECT     BillProcedures.BillID FROM PatientProcedureReadings INNER JOIN BillProcedures ON PatientProcedureReadings.PatientProcedureID = BillProcedures.PatientProcedureID WHERE PatientProcedureReadings.ResultID = " & ReadingID) > 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "The current procedure is already has been billed." & vbCrLf & "The reading can not be removed.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim ApprovedByID As Long
        Dim ApprovedByName As String
        If gCurrentEmployee.PositionID > 3 And gCurrentEmployee.PositionID <> 5 Then
            frmSupervisorApproval.LabelMsg.Text = "Delete Procedure Reading."
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByID = frmSupervisorApproval.SupervisorID
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If MsgBox("Please confirm you want to delete the procedure reading?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                Exit Sub
            End If
            ApprovedByID = gCurrentEmployee.EmpID
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tProcedureReadingUpdated, "Procedure Reading Has Been Deleted on " & Now, ApprovedByName)

        gSQLUpdateData("Delete from PatientProcedureReadings WHERE ResultID=" & ReadingID)
        ListViewReadings.SelectedItems(0).SubItems(4).Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtResultDescription.Text = Clipboard.GetText(TextDataFormat.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtResultDescription2.Text = Clipboard.GetText(TextDataFormat.Text)
    End Sub

    Private Sub ToolStripFontIncrease_Click(sender As Object, e As EventArgs) Handles ToolStripFontIncrease.Click
        SetFont(1)
    End Sub

    Private Sub ToolStripFonrDecrease_Click(sender As Object, e As EventArgs) Handles ToolStripFonrDecrease.Click
        SetFont(-1)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub frmAddReading_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub
End Class