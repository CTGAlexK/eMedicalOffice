Public Class frmAttorneyAssignCaseNumber
    Public initLI As ListViewItem
    Public Arbitration As Boolean
    Public ArbitrationFieldPrefix As String
    Private Sub txtInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvoice.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtInvoice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoice.TextChanged
        txtPatientName.Text = ""
        txtPatientName.Tag = ""
    End Sub

    Private Sub txtInvoice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInvoice.Validating
        Dim Reader As SqlClient.SqlDataReader
        txtPatientName.Text = ""
        txtPatientName.Tag = ""
        Dim FoundByAltNumber As Boolean
        If txtInvoice.Text.Trim = "" Then Exit Sub
        txtInvoice.ForeColor = Color.Black
        If IsNumeric(txtInvoice.Text.Trim) = False Then
            If CheckBoxspeech.Checked Then gSpeak("Invalid Bill Number. The Bill Number should be numeric value.")
            MsgBox("Invalid Bill #. The Bill # should be numeric value.", MsgBoxStyle.Exclamation)
            txtInvoice.SelectAll()
            e.Cancel = True
            Exit Sub
        End If
        Reader = gSQLGetDataReader("SELECT Bills.BillID, Patients.LName, Patients.FName, Patients.PatientID, Patients.LName+' '+Patients.MI+' '+Patients.FName as PName, Bills.BillID, Bills." & ArbitrationFieldPrefix & "AttorneyCaseNumber FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID Where Bills." & ArbitrationFieldPrefix & "AttorneyCompanyID IS NOT NULL and Bills.BillID = '" & Val(txtInvoice.Text.Trim) & "' and   Bills.OfficeID = " & gOfficeID & " ")
        If Reader Is Nothing Then
            MsgBox("Unexpected error. Please reenter the Bill #.", MsgBoxStyle.Critical)
            txtInvoice.SelectAll()
            e.Cancel = True
            Exit Sub
        End If
        If Reader.HasRows = False Then
            Reader = gSQLGetDataReader("SELECT Bills.BillID, Patients.LName, Patients.FName, Patients.PatientID, Patients.LName+' '+Patients.MI+' '+Patients.FName as PName, Bills.BillID, Bills." & ArbitrationFieldPrefix & "AttorneyCaseNumber FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID Where Bills." & ArbitrationFieldPrefix & "AttorneyCompanyID IS NOT NULL and Bills.OldBillNumber = '" & Val(txtInvoice.Text.Trim) & "' and   Bills.OfficeID = " & gOfficeID & " ")
            If Reader Is Nothing Then
                MsgBox("Unexpected error. Please reenter the Bill #.", MsgBoxStyle.Critical)
                txtInvoice.SelectAll()
                e.Cancel = True
                Exit Sub
            End If
            If Reader.HasRows = False Then
                If CheckBoxspeech.Checked Then gSpeak("Unable to continue. The specified Bill Number is not found or Attorney has not been assigned to specified bill." & vbCrLf & "Please check the Bill Number / Attorney Bill Status and try again.")
                MsgBox("Unable to continue." & vbCrLf & vbCrLf & "The specified Bill # is not found or Attornet has not been assigned to specified bill." & vbCrLf & "Please check the Bill # / Attorney Bill Status and try again.", MsgBoxStyle.Critical)
                txtInvoice.SelectAll()
                e.Cancel = True
                Exit Sub
            End If
            FoundByAltNumber = True
        End If
        Reader.Read()
        Dim ApprovedByID As Long
        Dim ApprovedByName As String
        Dim msg As String
        Dim msgspeak
        If Val(Reader("" & ArbitrationFieldPrefix & "AttorneyCaseNumber").ToString) > 0 Then
            msg = "Attention!" & vbCrLf & vbCrLf & "The Case number " & Val(Reader("" & ArbitrationFieldPrefix & "AttorneyCaseNumber")) & " is already assigned to this Bill." & vbCrLf & "Would you like to overwrite?"
            msgspeak = "The Attorney case number is already assigned to this Bill. Would you like to overwrite?"
            If CheckBoxspeech.Checked Then gSpeak(msgspeak)
            txtCase.Text = Val(Reader("" & ArbitrationFieldPrefix & "AttorneyCaseNumber").ToString)
            If MsgBox(msg, MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                txtInvoice.Focus()
                txtInvoice.SelectAll()
                Exit Sub
            End If

        End If
        If FoundByAltNumber Then
            txtInvoice.ForeColor = Color.BlueViolet
            ToolTip1.UseFading = True
            ToolTip1.Hide(txtInvoice)
            ToolTip1.Show("The Invoice has been found by Alternative Invoice number" & vbCrLf & "The Invoice # has been adjusted." & vbCrLf & vbCrLf & "The Alternative Invoice # " & txtInvoice.Text & vbCrLf & "The Adjusted System Invoice # " & Reader("BillID").ToString, txtInvoice, New Point(0, -140), 5000)
            txtInvoice.Text = Reader("BillID").ToString
            If CheckBoxspeech.Checked Then gSpeak("The Invoice has been found by Alternative Invoice number. The Invoice Number has been adjusted." & ", " & Reader("LName").ToString & ", " & Reader("FName").ToString)
        Else
            If CheckBoxspeech.Checked Then gSpeak(Reader("LName").ToString & ", " & Reader("FName").ToString)
        End If
        txtPatientName.Text = Reader("PName").ToString
        txtPatientName.Tag = Reader("PatientID").ToString
    End Sub

    Private Sub frmAttorneyAssignCaseNumber_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
        txtInvoice.Focus()
    End Sub

    Private Sub frmAttorneyAssignCaseNumber_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ListView1.Items.Count > 0 Then
            If MsgBox("You have not updated bills case numbers. Discard data?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)

    End Sub

    Private Sub frmAttorneyAssignCaseNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            If Me.ActiveControl Is Nothing Then Exit Sub
            If Me.ActiveControl Is txtInvoice Then
                If txtInvoice.Text <> "" Then txtCase.Focus()
                Exit Sub
            End If
            If Me.ActiveControl Is TextBoxPrefix Then
                txtCase.Focus()
                Exit Sub
            End If
            If Me.ActiveControl Is txtCase Then
                If txtInvoice.Text <> "" And txtCase.Text <> "" And txtPatientName.Text <> "" Then
                    ButtonAdd_Click(Nothing, Nothing)
                End If
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub frmAttorneyAssignCaseNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        On Error GoTo Er
        Dim vox
        vox = CreateObject("Sapi.SpVoice")
        If Not initLI Is Nothing Then txtInvoice.Text = Val(initLI.SubItems(4).Text)

        'Dim vox As New SpeechLib.SpVoice
        If vox.GetVoices.Count = 0 Then
            CheckBoxspeech.Visible = False
        End If
        Exit Sub
Er:
        CheckBoxspeech.Visible = False
    End Sub

    Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        If txtInvoice.Text.Trim = "" Then
            MsgBox("Unable to assign Case." & vbCrLf & vbCrLf & "The Bill # is required.", MsgBoxStyle.Exclamation)
            txtInvoice.Focus()

            Exit Sub
        End If
        If IsNumeric(txtInvoice.Text.Trim) = False Then
            MsgBox("Unable to assign Case." & vbCrLf & vbCrLf & "Invalid Bill #." & vbCrLf & "The Bill # should be numeric.", MsgBoxStyle.Exclamation)
            txtInvoice.Focus()
            Exit Sub
        End If
        If txtCase.Text.Trim = "" And TextBoxPrefix.Text.Trim = "" Then
            MsgBox("Unable to assign Case. The Case number is required.", MsgBoxStyle.Exclamation)
            txtCase.Focus()
            Exit Sub
        End If
        If IsNumeric(TextBoxPrefix.Text.Trim) = False And TextBoxPrefix.Text.Trim <> "" Then
            MsgBox("Unable to assign Case." & vbCrLf & vbCrLf & "Invalid Case number." & vbCrLf & "The Case number should be numeric.", MsgBoxStyle.Exclamation)
            TextBoxPrefix.Focus()
            Exit Sub
        End If

        If IsNumeric(txtCase.Text.Trim) = False Then
            MsgBox("Unable to assign Case." & vbCrLf & vbCrLf & "Invalid Case number." & vbCrLf & "The Case number should be numeric.", MsgBoxStyle.Exclamation)
            txtCase.Focus()
            Exit Sub
        End If

        For Each LI In ListView1.Items
            If Val(LI.SubItems(2).Text) = Val(txtInvoice.Text.Trim) Then
                MsgBox("Unable to assign Case." & vbCrLf & vbCrLf & "The Bill # " & Val(txtInvoice.Text.Trim) & " is already on the list.", MsgBoxStyle.Exclamation)
                LI.Selected = True
                LI.EnsureVisible()
                txtInvoice.Focus()
                txtInvoice.SelectAll()
                Exit Sub
            End If
        Next
        For Each LI In ListView1.Items
            If Val(LI.SubItems(3).Text) = Val(TextBoxPrefix.Text.Trim & txtCase.Text.Trim) Then
                MsgBox("Unable to assign Case." & vbCrLf & vbCrLf & "The Case number " & Val(TextBoxPrefix.Text.Trim & txtCase.Text.Trim) & " is already on the list.", MsgBoxStyle.Exclamation)
                LI.Selected = True
                LI.EnsureVisible()
                txtCase.Focus()
                txtCase.SelectAll()
                Exit Sub
            End If
        Next
        Reader = gSQLGetDataReader("Select BillID from Bills Where " & ArbitrationFieldPrefix & "AttorneyCaseNumber = " & Val(TextBoxPrefix.Text.Trim & txtCase.Text.Trim) & " and   Bills.OfficeID = " & gOfficeID & " ")
        If Not Reader Is Nothing Then
            If Reader.HasRows Then
                Reader.Read()
                MsgBox("Unable to assign Case." & vbCrLf & vbCrLf & "The Case number " & Val(TextBoxPrefix.Text.Trim & txtCase.Text.Trim) & " has been previously assigned to the Bill # " & Reader("BillID").ToString, MsgBoxStyle.Exclamation)
                txtCase.Focus()
                txtCase.SelectAll()
                Exit Sub
            End If
        End If

        If Val(txtPatientName.Tag) = 0 Then Exit Sub
        LI = ListView1.Items.Add(ListView1.Items.Count + 1)
        LI.SubItems.Add(txtPatientName.Text)
        LI.SubItems.Add(txtInvoice.Text.Trim)
        LI.SubItems.Add(TextBoxPrefix.Text.Trim & txtCase.Text.Trim)
        LI.Selected = True
        LI.EnsureVisible()
        On Error Resume Next
        txtPatientName.Text = ""
        txtCase.Text = ""
        txtInvoice.Text = ""
        txtInvoice.Focus()
        txtInvoice.ForeColor = Color.Black
        LabelTotal.Text = "Total Bills: " & ListView1.Items.Count
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim LI As ListViewItem
        If ListView1.Items.Count = 0 Then
            MsgBox("Unable to update. No records created.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please check all records and click the OK button to continue." & vbCrLf & "Otherwise click the Cancel Button.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        End If
        For Each LI In ListView1.Items
            LI.BackColor = Color.Green
            gSQLUpdateData("Update Bills set " & ArbitrationFieldPrefix & "AttorneyCaseNumber = " & Val(LI.SubItems(3).Text) & ", " & ArbitrationFieldPrefix & "AttorneyCaseNumberDate=getdate() where BillID= " & Val(LI.SubItems(2).Text))
        Next
        If Not LI Is Nothing Then
            If Not initLI Is Nothing Then
                If Arbitration = False Then
                    If Val(LI.SubItems(2).Text) = Val(initLI.SubItems(4).Text) Then
                        initLI.SubItems(19).Text = Val(LI.SubItems(3).Text)
                        initLI.SubItems(26).Text = Now.Date.ToString("MM/dd/yyyy")
                        initLI.SubItems(19).BackColor = Nothing
                        initLI.SubItems(26).BackColor = Nothing
                    End If
                Else
                    If Val(LI.SubItems(2).Text) = Val(initLI.SubItems(4).Text) Then
                        initLI.SubItems(29).Text = Val(LI.SubItems(3).Text)
                        initLI.SubItems(30).Text = Now.Date.ToString("MM/dd/yyyy")
                        initLI.SubItems(29).BackColor = Nothing
                        initLI.SubItems(30).BackColor = Nothing
                    End If
                End If
            End If
            End If
            ListView1.Items.Clear()
            If CheckBoxspeech.Checked Then gSpeak("Update process complete. Thank You")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim LI As ListViewItem
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to remove. No Bill record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)
        If MsgBox("Please confirm you want to remove following record:" & vbCrLf & vbCrLf & "Patient: " & LI.SubItems(1).Text & vbCrLf & "Invlice #: " & LI.SubItems(2).Text & vbCrLf & "Case #: " & LI.SubItems(3).Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        ListView1.Items.Remove(LI)
        LabelTotal.Text = "Total Bills: " & ListView1.Items.Count
    End Sub

    Private Sub txtCase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtCase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCase.KeyPress

    End Sub

    Private Sub txtCase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCase.TextChanged

    End Sub

    Private Sub TextBoxPrefix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxPrefix.TextChanged

    End Sub
End Class