Imports System.Reflection
Imports log4net

Public Class frmBillingPaymentChangeCheckNumber
    Public PatientID As Long
    Public ApprovedByName As String
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmPatientTreatingProviderPopUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
    End Sub

    Private Sub Load_Data()
        Dim LI As ListViewItem
        Try
            Dim Reader As SqlClient.SqlDataReader
            ListView1.Items.Clear()

            Reader = gSQLGetDataReader("SELECT BillPayments.BillID, BillPayments.PaymentAmount, BillPayments.PaymentDate, BillPayments.PaymentID, BillPayments.CheckNumber FROM BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE isnull(BillPayments.CheckNumber,'')<>'' and Bills.PatientID = " & PatientID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False

                LI = ListView1.Items.Add(Reader("BillID").ToString)
                If IsDate(Reader("PaymentDate").ToString) Then
                    LI.SubItems.Add(CDate(Reader("PaymentDate").ToString).ToString("MM/dd/yyyy"))
                Else
                    LI.SubItems.Add("")
                End If
                LI.Tag = Val(Reader("PaymentID").ToString)
                LI.SubItems.Add(Val(Reader("PaymentAmount").ToString).ToString("c"))
                LI.SubItems.Add(Reader("CheckNumber").ToString)
            Loop
            Reader.Close() : Reader.Dispose()
        Catch ex As Exception

            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        cboPart.Items.Add("")
        cboPart.SelectedIndex = 0
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim LI As ListViewItem
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to process update. No Payment Selected selected", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Exit Sub
        End If
        If txtCheckNumber.Text.Trim = "" Then
            MsgBox("Unable to process update. No New Check number specified", MsgBoxStyle.Exclamation)
            txtCheckNumber.Focus()
            Exit Sub
        End If
        If InStr(txtCheckNumber.Text.Trim, " ") Then
            MsgBox("Unable to process update. Invalid New Check number specified." & vbCrLf & vbCrLf & "No empty characters allowed in the check number", MsgBoxStyle.Exclamation)
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

        LI = ListView1.SelectedItems(0)
        If MsgBox("Please confirm you want to update the payment Check Number from:" & vbCrLf & vbCrLf & LI.SubItems(3).Text & vbCrLf & vbCrLf & "To" & vbCrLf & vbCrLf & txtCheckNumber.Text.Trim & IIf(cboPart.SelectedIndex > 0, "-" & cboPart.Text, ""), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            ListView1.Focus()
            Exit Sub
        End If
        gSQLUpdateData("UPDATE BillPayments set CheckNumber = '" & txtCheckNumber.Text.Trim.ToSafeSQLString() & IIf(cboPart.SelectedIndex > 0, "-" & cboPart.Text, "") & "' WHERE  PaymentID = " & Val(LI.Tag))
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tUpdated, "Payment Check Number updated from: " & LI.SubItems(3).Text & " to " & txtCheckNumber.Text.Trim & IIf(cboPart.SelectedIndex > 0, "-" & cboPart.Text, ""), ApprovedByName)
        Me.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        gHighlightListviewItem(ListView1)
    End Sub

    Private Sub txtCheckNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCheckNumber.TextChanged

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

End Class