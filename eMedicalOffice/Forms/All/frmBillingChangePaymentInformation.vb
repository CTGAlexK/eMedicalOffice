Public Class frmBillingChangePaymentInformation
    Public BillID As Long
    Public CalledBillPaidSI As ListViewItem.ListViewSubItem
    Public CalledBillBalanceSI As ListViewItem.ListViewSubItem
    Public BillAmount As Double
    Private SelectedPaymentID As Long
    Public PatientID As Long
    Private SupervisorName As String
    Private PaidAmount As Double

    Private Sub frmBillingChangeBillDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub Load_Payments(ByVal pBillID)
        Dim SQL As String = ""
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        SQL = "SELECT   BillPayments.note, BillPayments.NoteID, BillPayments.PaymentID,  BillPayments.PaymentDate, BillPayments.InsertedDate, BillPaymentTypes.Description, BillPayments.PaymentAmount, BillPayments.CheckNumber, BillPaymentNotes.Description AS Notes"
        SQL &= " FROM         BillPayments LEFT OUTER JOIN BillPaymentNotes ON BillPayments.NoteID = BillPaymentNotes.NoteID LEFT OUTER JOIN BillPaymentTypes ON BillPayments.PaymentTypeID = BillPaymentTypes.PaymentTypeID "
        SQL &= " WHERE BillPayments.BillID = " & pBillID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then
            MsgBox("Unexpected Error. Please call your system administrator.")
            Exit Sub
        End If
        ListView1.Items.Clear()
        Do Until Reader.Read = False
            With ListView1.Items
                If IsDate(Reader("PaymentDate").ToString) Then
                    LI = .Add(CDate(Reader("PaymentDate")).ToString("MM/dd/yyyy"))
                Else
                    LI = .Add("")
                End If
                If IsDate(Reader("InsertedDate").ToString) Then
                    LI.SubItems.Add(CDate(Reader("InsertedDate")).ToString("MM/dd/yyyy"))
                Else
                    LI.SubItems.Add("")
                End If

                LI.Tag = Val(Reader("PaymentID").ToString)
                LI.SubItems.Add(Reader("Description").ToString)
                LI.SubItems.Add(CDbl(Reader("PaymentAmount").ToString).ToString("c"))
                LI.SubItems.Add(Reader("CheckNumber").ToString)
                LI.SubItems.Add(Reader("Note").ToString).Tag = Val(Reader("NoteID").ToString)

            End With
        Loop
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            ListView1_SelectedIndexChanged(Nothing, Nothing)

        End If
        BillID = pBillID
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim PaidAmount As Double
        Dim LI As ListViewItem
        If SelectedPaymentID = 0 Then
            MsgBox("Unable to process update." & vbCrLf & "No Payment selected!", MsgBoxStyle.Exclamation)
            txtCheckNumber.Focus()
            Exit Sub
        End If
        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub

        If txtCheckNumber.Text = "" Then
            MsgBox("Unable to process update." & vbCrLf & "Invalid Payment Check number!", MsgBoxStyle.Exclamation)
            txtCheckNumber.Focus()
            Exit Sub
        End If
        If IsDate(DateTimePicker1.Value.Date) = False Then
            MsgBox("Unable to process update." & vbCrLf & "Invalid check date specified.", MsgBoxStyle.Exclamation)
            DateTimePicker1.Focus()
            Exit Sub
        End If
        If IsDate(DateTimePicker2.Value.Date) = False Then
            MsgBox("Unable to process update." & vbCrLf & "Invalid check posted date specified.", MsgBoxStyle.Exclamation)
            DateTimePicker1.Focus()
            Exit Sub
        End If

        If CDate(DateTimePicker1.Value.Date) < CDate(LabelBillDate.Text) Then
            MsgBox("Unable to process update." & vbCrLf & "Invalid check date specified. The check date can not be less then the bill date.", MsgBoxStyle.Exclamation)
            DateTimePicker1.Focus()
            Exit Sub
        End If
        If CDate(DateTimePicker2.Value.Date) < CDate(DateTimePicker1.Value.Date) Then
            MsgBox("Unable to process update." & vbCrLf & "Invalid check posted Date specified. The check posted date can not be less then the check date.", MsgBoxStyle.Exclamation)
            DateTimePicker2.Focus()
            Exit Sub
        End If

        If IsNumeric(txtAmount.Text) = False Or txtAmount.Text.Trim = "" Then
            MsgBox("Unable to process update." & vbCrLf & "Invalid Payment Amount!", MsgBoxStyle.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        If cboNotes.Enabled And cboNotes.SelectedIndex = -1 Then
            MsgBox("Unable to process." & vbCrLf & "Please select the Payment Notes.", MsgBoxStyle.Exclamation)
            If cboNotes.CanFocus Then
                cboNotes.Focus()
            End If
            Exit Sub
        End If

        If cboNotes.SelectedIndex > -1 Then
            If CType(cboNotes.SelectedItem, ValueDescription).Value1 = 4 And txtNotes.Text = "" Then
                MsgBox("Unable to process." & vbCrLf & "Please specify the Payment reason.", MsgBoxStyle.Exclamation)
                txtNotes.Focus()
                Exit Sub
            End If
        End If

        If MsgBox("Please confirm you want to update selected bill payment?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)

        gSQLUpdateData("Update BillPayments set InsertedDate = '" & DateTimePicker2.Value & "', PaymentDate = '" & DateTimePicker1.Value & "', CheckNumber='" & txtCheckNumber.Text.ToSafeSQLString() & "', PaymentAmount=" & Val(txtAmount.Text) & ", NoteID=" & CType(cboNotes.SelectedItem, ValueDescription).Value & ", Note='" & txtNotes.Text.Trim.ToSafeSQLString() & "' Where PaymentID=" & SelectedPaymentID)
        PaidAmount = gSQLGetSingleValue("Select sum(PaymentAmount) from BillPayments where BillID=" & BillID)
        gSQLUpdateData("Update Bills set PaidAmount = " & PaidAmount & " where BillID = " & BillID)
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillPaymentChanged, "Payment Changed." & vbCrLf & "Old Check Number: " & LI.SubItems(3).Text & vbCrLf & "New Check Number: " & txtCheckNumber.Text & vbCrLf & "Old Check Date: " & LI.Text & vbCrLf & "New Check Date: " & DateTimePicker1.Value.Date & vbCrLf & "Old Check Posted Date: " & LI.SubItems(1).Text & vbCrLf & "New Check Posted Date: " & DateTimePicker2.Value.Date & vbCrLf & "Old Payment Amount:" & LI.SubItems(3).Text & vbCrLf & "New Payment Amouont: " & CDbl(txtAmount.Text).ToString("c") & "Payment Note:" & txtNotes.Text.Trim.ToSafeSQLString(), SupervisorName)
        CalledBillPaidSI.Text = PaidAmount
        CalledBillBalanceSI.Text = BillAmount - PaidAmount
        Me.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim LI As ListViewItem
        PaidAmount = 0
        txtRemaining.Text = ""
        txtCheckNumber.Text = ""
        txtAmount.Text = ""
        txtNotes.Text = ""
        cboNotes.SelectedIndex = -1
        If ListView1.SelectedItems.Count = 0 Then Exit Sub

        LI = ListView1.SelectedItems(0)
        SelectedPaymentID = Val(LI.Tag)
        If IsDate(LI.Text) Then DateTimePicker1.Value = LI.Text
        If IsDate(LI.SubItems(1).Text) Then DateTimePicker2.Value = LI.SubItems(1).Text
        txtCheckNumber.Text = LI.SubItems(4).Text
        txtAmount.Text = CDbl(LI.SubItems(3).Text)
        gFindComboItemByValue(cboNotes, Val(LI.SubItems(5).Tag), True)
        txtNotes.Text = LI.SubItems(5).Text
        txtNotes.Enabled = False
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Payment selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        cmdEdit.Enabled = False
        cmdCancel.Enabled = True
        cmdUpdate.Enabled = True
        txtAmount.Enabled = True
        txtCheckNumber.Enabled = True
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        cboNotes.Enabled = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        cmdEdit.Enabled = True
        cmdCancel.Enabled = False
        cmdUpdate.Enabled = False
        txtAmount.Enabled = False
        txtCheckNumber.Enabled = False
        DateTimePicker1.Enabled = False
        ListView1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub txtCheckNumber_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckNumber.GotFocus
        txtCheckNumber.SelectAll()
    End Sub

    Private Sub txtCheckNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCheckNumber.TextChanged

    End Sub

    Private Sub txtAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.GotFocus
        txtAmount.SelectAll()
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        Dim SQL As String = ""
        Dim Reader As SqlClient.SqlDataReader
        Dim PaidAmount As Double
        Dim CheckAmount As Double
        Dim LI As ListViewItem
        PaidAmount = 0
        txtRemaining.Text = ""
        txtNotes.Text = ""
        If txtAmount.Text = "" Then Exit Sub
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If IsNumeric(txtAmount.Text) Then
            CheckAmount = CDbl(txtAmount.Text)
        Else
            CheckAmount = 0
            txtAmount.Text = ""
        End If

        For Each LI In ListView1.Items
            If LI.Tag <> ListView1.SelectedItems(0).Tag Then
                PaidAmount = PaidAmount + CDbl(LI.SubItems(2).Text)
            End If
        Next
        txtRemaining.Text = (BillAmount - (CheckAmount + PaidAmount)).ToString("c")
        If IsNumeric(txtAmount.Text) Then
            cboNotes.Enabled = txtAmount.Enabled
            cboNotes.Enabled = txtAmount.Enabled
            cboNotes.SelectedIndex = -1
            cboNotes.Items.Clear()
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

    Private Sub cboNotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNotes.SelectedIndexChanged
        txtNotes.Enabled = False
        If cboNotes.SelectedIndex = -1 Then Exit Sub
        If CType(cboNotes.SelectedItem, ValueDescription).Value1 = 4 Then
            txtNotes.Enabled = txtAmount.Enabled
            txtNotes.Text = ""
            txtNotes.Focus()
        Else
            txtNotes.Enabled = False
            txtNotes.Text = CType(cboNotes.SelectedItem, ValueDescription).Description
        End If
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub

End Class