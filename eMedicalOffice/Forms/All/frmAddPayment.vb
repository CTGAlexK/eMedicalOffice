Imports System.Reflection
Imports log4net

Public Class frmAddPayment
    Public BillID As Long
    Public PatientID As Long
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Sql As String = ""
        txtAmount.Text = txtAmount.Text.Trim
        txtCheckNumber.Text = txtCheckNumber.Text.Trim
        If CDate(DateTimePicker2.Value.Date) < CDate(DateTimePicker1.Value.Date) Then
            MsgBox("Unable to process update." & vbCrLf & "Invalid check posted Date specified. The check posted date can not be less then the check date.", MsgBoxStyle.Exclamation)
            DateTimePicker2.Focus()
            Exit Sub
        End If
        If txtCheckNumber.Enabled Then
            If txtCheckNumber.Text.Trim = "" Then
                ErrorProvider1.SetError(txtCheckNumber, "The Check Number is required")
                MsgBox("Unable to process. The Check Number is required.", MsgBoxStyle.Critical)
                txtCheckNumber.Focus()
                txtCheckNumber.SelectAll()
                Exit Sub
            End If

            If InStr(txtCheckNumber.Text.Trim, " ") Then
                ErrorProvider1.SetError(txtCheckNumber, "No empty characters allowed in the Check Number")
                MsgBox("Unable to process." & vbCrLf & vbCrLf & "No empty characters allowed in the Check Number", MsgBoxStyle.Exclamation)
                txtCheckNumber.Focus()
                txtCheckNumber.SelectAll()
                Exit Sub
            End If

            If InStr(txtCheckNumber.Text.Trim, "'") Or InStr(txtCheckNumber.Text.Trim, "`") Or InStr(txtCheckNumber.Text.Trim, "!") Or InStr(txtCheckNumber.Text.Trim, "@") Or InStr(txtCheckNumber.Text.Trim, "$") Or InStr(txtCheckNumber.Text.Trim, "%") Or InStr(txtCheckNumber.Text.Trim, "%") Or InStr(txtCheckNumber.Text.Trim, "^") Or InStr(txtCheckNumber.Text.Trim, "&") Or InStr(txtCheckNumber.Text.Trim, "*") Or InStr(txtCheckNumber.Text.Trim, "<") Or InStr(txtCheckNumber.Text.Trim, ">") Or InStr(txtCheckNumber.Text.Trim, "?") Or InStr(txtCheckNumber.Text.Trim, "|") Or InStr(txtCheckNumber.Text.Trim, "`") Or InStr(txtCheckNumber.Text.Trim, "(") Or InStr(txtCheckNumber.Text.Trim, ")") Or InStr(txtCheckNumber.Text.Trim, ",") Or InStr(txtCheckNumber.Text.Trim, ".") Or InStr(txtCheckNumber.Text.Trim, "<") Or InStr(txtCheckNumber.Text.Trim, ">") Or InStr(txtCheckNumber.Text.Trim, ":") Or InStr(txtCheckNumber.Text.Trim, ";") Or InStr(txtCheckNumber.Text.Trim, Chr(34)) Or InStr(txtCheckNumber.Text.Trim, "_") Or InStr(txtCheckNumber.Text.Trim, "=") Or InStr(txtCheckNumber.Text.Trim, "+") Or InStr(txtCheckNumber.Text.Trim, "-") Then
                MsgBox("Unable to process." & vbCrLf & vbCrLf & "Invalid character in the New Check Number" & vbCrLf & vbCrLf & "Only Letters and Numbers allowed." & vbCrLf & vbCrLf & "If the payment check is covering more then one bill, please use the Part drop down box to specify the check part number", MsgBoxStyle.Exclamation)
                txtCheckNumber.Focus()
                txtCheckNumber.SelectAll()
                Exit Sub
            End If

            If gSQLGetSingleValue("SELECT COUNT(*) AS C FROM BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE Bills.PatientID = " & PatientID & " AND BillPayments.CheckNumber = '" & txtCheckNumber.Text.Trim.ToSafeSQLString() & IIf(cboPart.SelectedIndex > 0, "-" & cboPart.Text, "") & "'") > 0 Then
                MsgBox("Unable to process." & vbCrLf & vbCrLf & "Duplicate Check Number:  " & txtCheckNumber.Text.Trim.ToSafeSQLString() & IIf(cboPart.SelectedIndex > 0, "-" & cboPart.Text, "") & vbCrLf & vbCrLf & "If the payment check is covering more then one bill, please use the Part drop down box to specify the check part number", MsgBoxStyle.Exclamation)
                cboPart.Focus()
                Exit Sub
            End If
        End If

        If txtAmount.Text = "" Then
            ErrorProvider1.SetError(txtAmount, "Payment Amount is required")
            MsgBox("Unable to process. The Payment Amount is required.", MsgBoxStyle.Critical)
            txtAmount.Focus()
            txtAmount.SelectAll()
            Exit Sub
        End If

        If IsNumeric(txtAmount.Text) = False Then
            ErrorProvider1.SetError(txtAmount, "Invalid Payment Amount specified")
            MsgBox("Unable to process. Invalid Payment Amount.", MsgBoxStyle.Critical)
            txtAmount.Focus()
            txtAmount.SelectAll()
            Exit Sub
        End If
        If CDbl(txtAmount.Text) < 0 Then
            ErrorProvider1.SetError(txtAmount, "Invalid Payment Amount")
            MsgBox("Unable to process. Invalid Payment Amount specified." & vbCrLf & "The Payment Amount should be numeric positive value.", MsgBoxStyle.Critical)
            txtAmount.Focus()
            txtAmount.SelectAll()
            Exit Sub
        End If
        If Val(txtAmount.Text) > CDbl(txtBillAmount.Text) * 2 Then
            If MsgBox("Attention." & vbCrLf & "The specified Payment Amount is much more then Billed Amount." & vbCrLf & vbCrLf & "Please Confirm", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                txtAmount.Focus()
                txtAmount.SelectAll()
                Exit Sub
            End If
        End If

        If CDbl(txtRemaining.Text) < 0 Then
            If cboNotes.SelectedIndex = -1 Then
                ErrorProvider1.SetError(cboNotes, "Reason Required.")
                MsgBox("Unable to process." & vbCrLf & "The specified Payment Amount is more then Billed Amount." & vbCrLf & "Please specify the reason.", MsgBoxStyle.Exclamation)
                cboNotes.Focus()
                Exit Sub
            End If
        End If
        If CDbl(txtRemaining.Text) > 0 Then
            If cboNotes.SelectedIndex = -1 Then
                ErrorProvider1.SetError(cboNotes, "Reason Required.")
                MsgBox("Unable to process." & vbCrLf & "The Payment Amount is less then Billed Amount." & vbCrLf & "Please specify the reason.", MsgBoxStyle.Exclamation)
                cboNotes.Focus()
                Exit Sub
            End If
        End If
        If cboNotes.SelectedIndex > -1 Then
            If CType(cboNotes.SelectedItem, ValueDescription).Value1 = 4 And txtNotes.Text = "" Then
                ErrorProvider1.SetError(txtNotes, "Reason Required.")
                MsgBox("Unable to process." & vbCrLf & "Please specify the Payment reason.", MsgBoxStyle.Exclamation)
                txtNotes.Focus()
                Exit Sub
            End If
        End If
        If CheckBoxCloseProfile.Checked = False Then
            If chkNoMoreCollection.Checked Then
                If MsgBox("You have marked this bill as No More Collection. Please confirm.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    chkNoMoreCollection.Focus()
                    Exit Sub
                End If
            End If
        Else
            chkNoMoreCollection.Checked = True
            If MsgBox("You have requested to close Patient's profile." & vbCrLf & vbCrLf & "Please confirm all the patient's procedures has been paid!", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                CheckBoxCloseProfile.Focus()
                Exit Sub
            End If
        End If

        If MsgBox("Please confirm the following payment" & vbCrLf & vbCrLf & "Bill Number: " & BillID & IIf(txtCheckNumber.Text <> "", vbCrLf & "Check Number: " & txtCheckNumber.Text & IIf(cboPart.SelectedIndex > 0, "-" & cboPart.Text, ""), "") & vbCrLf & "Payment Amount: " & CDbl(txtAmount.Text).ToString("c"), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim PaymentType As Integer
        If CheckBox1.Checked Then
            PaymentType = 2
        Else
            PaymentType = 1
        End If
        Try
            Sql = "INSERT INTO BillPayments (BillID, PaymentTypeID, PaymentDate, InsertedDate, PaymentAmount, CheckNumber, NoteID, Note) "
            Sql &= " VALUES     (" & BillID & ", " & PaymentType & ", '" & DateTimePicker1.Value & "', '" & DateTimePicker2.Value & "', " & CDbl(txtAmount.Text) & ", '" & txtCheckNumber.Text.Trim.ToSafeSQLString() & IIf(cboPart.SelectedIndex > 0, "-" & cboPart.Text, "") & "', " & CType(cboNotes.SelectedItem, ValueDescription).Value & ", '" & txtNotes.Text.Trim.ToSafeSQLString() & "')"
            gSQLUpdateData(Sql)
            Sql = "UPDATE Bills Set NoMoreCollection = " & Math.Abs(Val(chkNoMoreCollection.Checked)) & ", BillStatusID=3, PaidAmount = (SELECT SUM(PaymentAmount) FROM BillPayments Where BillID=" & BillID & ") Where BillID=" & BillID
            gSQLUpdateData(Sql)
            Sql = "INSERT INTO BillComments  (BillID, Comment, InsertedBy, InsertedDT) VALUES(" & BillID & ",'Payment Received: " & CDbl(txtAmount.Text).ToString("c") & "', " & gCurrentEmployee.EmpID & ", getdate())"
            gSQLUpdateData(Sql)
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillPaid, "Bill #" & BillID & " Payment Received: " & CDbl(txtAmount.Text).ToString("c"))

            If CheckBoxCloseProfile.Checked = True Then
                Sql = "UPDATE Patients Set CaseStatusID = 5 Where PatientID=" & PatientID
                gSQLUpdateData(Sql)
                gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillStatusChanged, "Case Closed. All Procedures Paid")
                If gSQLGetSingleValue("select count(*) from BillingRequests  Where PatientID=" & PatientID & " and RequestStatusID<>3 and RequestStatusID<>4 ") > 0 Then
                    gSQLUpdateData("UPDATE BillingRequests Set RequestStatusID = 4 Where PatientID=" & PatientID & " and RequestStatusID<>3 and RequestStatusID<>4")
                    gUpdate_Profile_Log(PatientID, PatientLogTypes.tRequestCanceledAll, "Case Closed. All Procedures Paid. All Requests Canceled")
                End If
            End If
            If CheckBoxAudio.Checked Then My.Computer.Audio.Play(My.Resources.CashRegister, AudioPlayMode.Background)

            PaymentScanCheck = chkScanCheck.Checked
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub txtCheckNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCheckNumber.TextChanged
        ErrorProvider1.SetError(txtCheckNumber, "")
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, txtCheckNumber, True)
    End Sub

    Private NoComments As Boolean

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        Dim SQL As String = ""
        Dim Reader As SqlClient.SqlDataReader
        Dim PaidAmount As Double
        Dim CheckAmount As Double

        If IsNumeric(txtPaid.Text) Then
            PaidAmount = CDbl(txtPaid.Text)
        Else
            PaidAmount = 0
        End If
        If IsNumeric(txtAmount.Text) Then
            CheckAmount = CDbl(txtAmount.Text)
        Else
            CheckAmount = 0
        End If

        ErrorProvider1.SetError(txtAmount, "")
        txtRemaining.Text = CDbl(CDbl(txtBillAmount.Text) - (CheckAmount + PaidAmount)).ToString("c")
        If IsNumeric(txtAmount.Text) Then
            cboNotes.Enabled = True
            cboNotes.Enabled = True
            cboNotes.SelectedIndex = -1
            cboNotes.Items.Clear()
            NoComments = False
            If CDbl(txtRemaining.Text) < 0 Then
                txtRemaining.ForeColor = Color.Blue
                SQL = "SELECT     NoteID, Description, NoteTypeID FROM BillPaymentNotes Where NoteTypeID = 2 or NoteTypeID = 4"
            ElseIf CDbl(txtRemaining.Text) > 0 Then
                txtRemaining.ForeColor = Color.Red
                SQL = "SELECT     NoteID, Description, NoteTypeID FROM BillPaymentNotes Where NoteTypeID = 1 or NoteTypeID = 4 or NoteTypeID = 5"
            ElseIf CDbl(txtRemaining.Text) = 0 Then
                txtRemaining.ForeColor = Color.Green
                SQL = "SELECT     NoteID, Description, NoteTypeID FROM BillPaymentNotes Where NoteTypeID = 3 "
            End If
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboNotes.Items.Add(New ValueDescription(Reader("NoteID").ToString, Reader("Description").ToString, Reader("NoteTypeID").ToString))
            Loop
            If CDbl(txtRemaining.Text) = 0 Then
                If cboNotes.Items.Count > 0 Then
                    cboNotes.SelectedIndex = 0
                    'cboNotes.Enabled = False
                    'txtNotes.Enabled = False
                End If
            End If
        Else
            cboNotes.SelectedIndex = -1
            cboNotes.Enabled = False
            txtNotes.Enabled = False
            txtNotes.Text = ""
            txtRemaining.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtRemaining_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemaining.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRemaining_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemaining.TextChanged

    End Sub

    Private Sub cboNotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNotes.SelectedIndexChanged
        ErrorProvider1.SetError(txtNotes, "")
        ErrorProvider1.SetError(cboNotes, "")
        txtNotes.Enabled = False
        If cboNotes.SelectedIndex = -1 Then Exit Sub
        If CType(cboNotes.SelectedItem, ValueDescription).Value1 = 4 Then
            txtNotes.Enabled = True
            txtNotes.Text = ""
            txtNotes.Focus()
        Else
            txtNotes.Enabled = False
            txtNotes.Text = CType(cboNotes.SelectedItem, ValueDescription).Description
        End If

    End Sub

    Private Sub frmAddPayment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewBills, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", "PaymentSound", CheckBoxAudio.Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "PaymentScanCheck", chkScanCheck.Checked)
    End Sub

    Private Sub frmAddPayment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            If Not ActiveControl Is Nothing Then
                If ActiveControl Is txtCheckNumber And txtCheckNumber.Text <> "" Then
                    txtAmount.Focus()
                    Exit Sub
                End If
                If ActiveControl Is txtAmount And txtCheckNumber.Text <> "" And txtAmount.Text <> "" Then
                    cmdUpdate_Click(Nothing, Nothing)
                End If
            End If

        End If
    End Sub

    Private Sub frmAddPayment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmAddPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckBoxAudio.Checked = GetSetting(My.Application.Info.ProductName, "Settings", "PaymentSound", True)
        chkScanCheck.Checked = GetSetting(My.Application.Info.ProductName, "Settings", "PaymentScanCheck", True)
        DateTimePicker1.MaxDate = DateAdd(DateInterval.Day, 1, Now)
        DateTimePicker1.Value = Now
        DateTimePicker2.MaxDate = DateAdd(DateInterval.Day, 1, Now)
        DateTimePicker2.Value = Now
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        gListview_Settings(Me, ListViewBills, ReadWrite.sRead)
        PictureBoxInfo.Visible = False
        If gSQLGetSingleValue("SELECT     COUNT(*) AS C FROM Bills WHERE PatientID = " & Val(PatientID) & " AND PaidAmount = 0 AND BillID <> " & Val(BillID)) > 0 Then
            'chkNoMoreCollection.Enabled = False
            CheckBoxCloseProfile.Enabled = False
            PictureBoxInfo.Visible = True
            ToolTip1.SetToolTip(chkNoMoreCollection, "Patient has UnBilled Procedures or Unpaid Bills")
            ToolTip1.SetToolTip(CheckBoxCloseProfile, "Patient has UnBilled Procedures or Unpaid Bills")

        End If
        Dim ProcCount As Integer = gSQLGetSingleValue("SELECT    COUNT(*) as C FROM PatientProcedures WHERE PatientProcedureID not in (select PatientProcedureID from BillProcedures) AND PatientID = " & Val(PatientID))


        If ProcCount > 0 Then
            'chkNoMoreCollection.Enabled = False
            CheckBoxCloseProfile.Enabled = False
            PictureBoxInfo.Visible = True
            ToolTip1.SetToolTip(chkNoMoreCollection, "Patient has UnBilled Procedures or Unpaid Bills")
            ToolTip1.SetToolTip(CheckBoxCloseProfile, "Patient has UnBilled Procedures or Unpaid Bills")
        End If
        cboPart.Items.Add("")
        cboPart.SelectedIndex = 0
        Timer1.Enabled = True
    End Sub

    Private Sub txtNotes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotes.TextChanged
        ErrorProvider1.SetError(txtNotes, "")
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub txtCheckNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCheckNumber.Validating
        Dim Ret As Integer
        Dim I As Integer
        txtCheckNumber.Text = txtCheckNumber.Text.ToUpper.Trim
        cboPart.Items.Clear()
        cboPart.Items.Add("")
        cboPart.SelectedIndex = 0
        If txtCheckNumber.Text = "" Then Exit Sub
        For I = 1 To 99
            cboPart.Items.Add(I)
        Next
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("Select BillPayments.CheckNumber FROM BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE (Bills.PatientID = " & PatientID & ") AND (BillPayments.CheckNumber like '" & txtCheckNumber.Text.ToSafeSQLString() & "%')")
        Do Until Reader.Read = False
            Ret = InStr(Reader("CheckNumber").ToString, "-", CompareMethod.Text)
            If Ret > 0 Then
                Ret = Val(Mid(Reader("CheckNumber").ToString, Ret + 1))
                If Ret > 0 Then
                    For I = 1 To cboPart.Items.Count - 1
                        If Ret = Val(cboPart.Items(I).ToString) Then
                            cboPart.Items.RemoveAt(I)
                            Exit For
                        End If
                    Next
                End If

            End If
        Loop
        cboPart.SelectedIndex = 0
        Reader.Close()
        Reader = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtAmount.Text = txtRemaining.Tag
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtCheckNumber.Text = "CASH"
            txtCheckNumber.Enabled = False
            cboPart.SelectedIndex = 0
            cboPart.Enabled = False
        Else
            txtCheckNumber.Text = ""
            txtCheckNumber.Enabled = True
            cboPart.Enabled = True
        End If
    End Sub

    Private Sub ScanDocumentFromScanner(ByVal DocProfileID As Integer)
        Dim Reader As SqlClient.SqlDataReader
        Dim DocProfID As Integer = 5 ' Payment Check

        frmDocumentScannerPDF.IniDocProfile = DocProfID
        frmDocumentScannerPDF.PatientID = PatientID
        If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            gSQLUpdateData("UPDATE Documents set PatientID = " & PatientID & " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
        End If
        frmDocumentScannerPDF.Dispose()
    End Sub

    Private Sub ScanDocumentFromScannerApplication(ByVal DocProfileID As Integer)
        Dim M As MessageBox
        If gScannerFolder = "" Then
            MsgBox("Unable to scan. The Scanner Folder has not been specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IO.Directory.Exists(gScannerFolder) = False Then
            MsgBox("Unable to scan. Invalid Scanner Folder specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim Reader As SqlClient.SqlDataReader
        Dim DocProfID As Integer = 5 ' Payment Check
        'Reader = gSQLGetDataReader("Select ProfileID From DocumentProfiles where DocumentName='Billing Request'")
        'If Reader Is Nothing Then Exit Sub
        'If Reader.HasRows Then
        '    Reader.Read()
        '    DocProfID = Val(Reader("ProfileID").ToString)
        'Else
        '    DocProfID = 17 ' Document
        'End If
        frmDocumentScannerExternalProgram.IniDocProfile = DocProfID
        frmDocumentScannerExternalProgram.PatientID = PatientID
        If frmDocumentScannerExternalProgram.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            gSQLUpdateData("UPDATE Documents set PatientID = " & PatientID & " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
        End If
        frmDocumentScannerExternalProgram.Dispose()
    End Sub

    Private Sub cmdUnlockPostedDate_Click(sender As Object, e As EventArgs) Handles cmdUnlockPostedDate.Click
        Dim ApprovedByName As String = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        Application.DoEvents()
        If gCurrentEmployee.PositionID > 3 Then
            Dim frm As frmSupervisorApproval = New frmSupervisorApproval
            frm.LabelMsg.Text = "Confirm the Check Posted Date update authorization..."
            If frm.ShowDialog(Me) <> Windows.Forms.DialogResult.OK Then
                frm.Dispose()
                frm = Nothing
                Exit Sub
            End If
            ApprovedByName = frm.SupervisorName
            frm.Dispose()
            frm = Nothing
        End If
        DateTimePicker2.Enabled = True
        DateTimePicker2.Focus()
        cmdUnlockPostedDate.Visible = False
    End Sub

    Private Sub frmAddPayment_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtCheckNumber.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtCheckNumber.Focus()
        Timer1.Enabled = False
    End Sub

End Class