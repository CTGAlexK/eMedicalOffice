Imports System.Reflection
Imports log4net

Public Class frmBillingLienAttorney
    Public Bill_ID As Integer = 0
    Public Save_Att As String = ""
    Public Save_date As String = ""
    Public save_lvi As ListViewItem
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private savecomments As String = ""

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ApprovedByName As String = ""
        Dim confirmMessage As String = ""
        Dim Confirm As Boolean = False
        Dim ldate As DateTime
        If Save_Att = "" And (cboLienAttorney.Text = "" Or cboLienAttorney.SelectedItem Is Nothing) Then
            MsgBox("Unable to process your request. No Lien attorney selected.", MsgBoxStyle.Exclamation, "Error")
            cboLienAttorney.Focus()
            Exit Sub
        End If
        If cboLienAttorney.Text <> "" And (txtLienDate.MaskCompleted = False AndAlso IsDate(txtLienDate.Text) = False) Then
            MsgBox("Unable to process your request. Invalid Lien date specified.", MsgBoxStyle.Exclamation, "Error")
            txtLienDate.SelectAll()
            txtLienDate.Focus()
            Exit Sub
        End If
        confirmMessage = "Please confirm you want to: "
        If Save_Att <> "" And cboLienAttorney.Text = "" Then
            confirmMessage &= vbCrLf & "   Remove Lien Attorney?"
            Confirm = True
        ElseIf Save_Att <> "" And Save_Att.Trim <> cboLienAttorney.Text.Trim Then
            confirmMessage &= vbCrLf & "   Change Lien Attorney?"
            Confirm = True
        End If
        If cboLienAttorney.Text <> "" Then
            If Save_date <> "" And Save_date <> txtLienDate.Text Then
                confirmMessage &= vbCrLf & "   Change Lien Date?"
                Confirm = True
            End If
        End If
        If Confirm Then
            If gCurrentEmployee.PositionID > 3 Then
                frmSupervisorApproval.LabelMsg.Text = confirmMessage
                If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    frmSupervisorApproval.Dispose()
                    Exit Sub
                End If
                ApprovedByName = frmSupervisorApproval.SupervisorName
                frmSupervisorApproval.Dispose()
            Else
                If MsgBox(confirmMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
                ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
            End If
        End If

        If IsDate(txtLienDate.Text) = False Then
            ldate = Now.Date.ToString("MM/dd/yyyy")
        Else
            ldate = CDate(txtLienDate.Text)
        End If

        If Save_Att <> "" And cboLienAttorney.Text = "" Then
            gSQLUpdateData("Update Bills set Lien_attorney_id = 0, Lien_date=Null, Lien_comments='' Where BillID = " & Bill_ID)
            If Not save_lvi Is Nothing Then
                save_lvi.SubItems(34).Text = ""
                save_lvi.SubItems(34).Tag = ""
                save_lvi.SubItems(35).Text = ""
            End If
            update_bill_comments(Bill_ID, "Lien Attorney: " & Save_Att & " Removed.")
        Else
            gSQLUpdateData("Update Bills set Lien_attorney_id = " & CType(cboLienAttorney.SelectedItem, ValueDescription).Value & ", Lien_date='" & ldate.ToString("MM/dd/yyyy") & "', Lien_comments='" & txtLienComments.Text.ToSafeSQLString() & "' Where BillID = " & Bill_ID)
            If Not save_lvi Is Nothing Then
                save_lvi.SubItems(34).Text = CType(cboLienAttorney.SelectedItem, ValueDescription).Description
                save_lvi.SubItems(34).Tag = txtLienComments.Text
                save_lvi.SubItems(35).Text = ldate.ToString("MM/dd/yyyy")
            End If
            If Save_Att = "" Then
                update_bill_comments(Bill_ID, "Lien Attorney: " & cboLienAttorney.Text & " Assigned." & IIf(txtLienComments.Text.Trim.Length > 0, vbCrLf & "Lien Comments: " & txtLienComments.Text, ""))
                frmBillToAttorneyLien.BillId = Bill_ID
                frmBillToAttorneyLien.MinimizeBox = False
                frmBillToAttorneyLien.MaximizeBox = False
                frmBillToAttorneyLien.ShowDialog(Me)
                frmBillToAttorneyLien.Dispose()
            Else
                If Save_Att.ToString.ToUpper <> cboLienAttorney.Text.ToUpper Then
                    update_bill_comments(Bill_ID, "Lien Attorney Updated From: " & Save_Att & " To: " & cboLienAttorney.Text)
                End If
                If Save_date <> "" And Save_date <> txtLienDate.Text Then
                    update_bill_comments(Bill_ID, "Lien Date Updated From: " & Save_date & " To: " & txtLienDate.Text)
                End If
                If savecomments.ToUpper <> txtLienComments.Text.ToUpper Then
                    update_bill_comments(Bill_ID, "Lien Comments Updated: " & txtLienComments.Text)
                End If
            End If

        End If
        DialogResult = DialogResult.OK
        Close()
    End Sub
    Private Sub update_bill_comments(Bill_ID As Integer, comment As String)
        Dim TR As DataRow
        Using TA = New SqlClient.SqlDataAdapter("SELECT * FROM BillComments Where 1=2", gConnectionString)
            Using CB = New SqlClient.SqlCommandBuilder(TA)
                Using dTab = New DataTable("BillComments")
                    TA.Fill(dTab)
                    TR = dTab.NewRow
                    TR("BillID") = Bill_ID
                    TR("Comment") = comment
                    TR("InsertedBy") = gCurrentEmployee.EmpID.ToString
                    TR("InsertedDT") = Now
                    TR("ReminderCompleteInd") = 0
                    TR("ReminderCompleteBy") = 0
                    dTab.Rows.Add(TR)
                    TA.UpdateCommand = CB.GetUpdateCommand(True)
                    Try
                        TA.Update(dTab)
                        dTab.AcceptChanges()
                    Catch ex As Exception

                        log.Error(ex.Message, ex)
                        Exit Sub
                    End Try
                    dTab.Dispose() : CB.Dispose() : TA.Dispose()
                End Using
            End Using
        End Using
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub frmBillingLienAttorney_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Find_Data(billid As Integer, att As String, lian_date As String, lien_comments As String, lvi As ListViewItem)
        Bill_ID = billid
        Save_Att = att
        Save_date = lian_date
        save_lvi = lvi
        If att <> "" Then
            cboLienAttorney.SelectedIndex = cboLienAttorney.FindStringExact(att)
            lblAction.Text = "Review/Update Lien Attorney"
            lblAction.ForeColor = Color.Green
            ButtonPrint.Visible = True
        Else
            ButtonPrint.Visible = False
            Dim pat_att As String = gSQLGetSingleValueString("select rtrim(Attorney) from Patients where PatientID = " & CType(lvi.Tag, ValueDescription).Value1)
            If pat_att <> "" Then
                cboLienAttorney.SelectedIndex = cboLienAttorney.FindStringExact(pat_att)
            Else
                cboLienAttorney.SelectedIndex = -1
            End If
            lblAction.ForeColor = Color.Red
            lblAction.Text = "Assign Lien Attorney"
        End If
        If IsDate(lian_date) Then
            txtLienDate.Text = CDate(lian_date).ToString("MM/dd/yyyy")
        Else
            txtLienDate.Text = Now.Date.ToString("MM/dd/yyyy")
        End If
        txtLienComments.Text = lien_comments
    End Sub
    Public Sub Load_Data(ShowRemoveLien As Boolean)
        Dim reader As SqlClient.SqlDataReader
        cboLienAttorney.Items.Clear()
        LabelRemove.Visible = ShowRemoveLien
        reader = gSQLGetDataReader("SELECT        CompanyID, ltrim(rtrim(CompanyName)) as CompanyName FROM InsuranceCompanies WHERE CaseTypeID = 5 ORDER BY CompanyName")
        If reader Is Nothing Then Exit Sub
        Do Until reader.Read = False
            cboLienAttorney.Items.Add(New ValueDescription(CLng(Val(reader("CompanyID").ToString)), reader("CompanyName").ToString))
        Loop
        reader.Close() : reader.Dispose()

    End Sub
    Private Sub Clear_Controls()
        On Error Resume Next
        gLoop_Clear_Controls(Me, cboLienAttorney, txtLienDate, txtLienComments)
        FpSpread1.ActiveSheet.RowCount = 0
    End Sub
    Private Sub cboLienAttorney_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLienAttorney.SelectedIndexChanged
        Timer1.Enabled = False
        Timer1.Enabled = True
    End Sub
    Private Sub Load_Ins_Addresses(id As Long)
        Dim Reader As SqlClient.SqlDataReader

        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.SuspendLayout()
        With FpSpread1.ActiveSheet
            .RowCount = 0
            Reader = gSQLGetDataReader("Select * from InsuranceCompanyAddresses Where CompanyID=" & id)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                .RowCount = .RowCount + 1
                .SetText(.RowCount - 1, 0, Reader("Address").ToString)
                .SetText(.RowCount - 1, 1, Reader("City").ToString)
                .SetText(.RowCount - 1, 2, Reader("State").ToString)
                .SetText(.RowCount - 1, 3, Reader("Zip").ToString)
            Loop
            .GrayAreaBackColor = Color.WhiteSmoke
            FpSpread1.ResumeLayout(True)
        End With
        Reader.Close() : Reader.Dispose()
        Cursor = Cursors.Default
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader

        Clear_Controls()
        cboLienAttorney.Focus()
        If cboLienAttorney.SelectedIndex = -1 Then Exit Sub
        If CType(cboLienAttorney.SelectedItem, ValueDescription).Value = -1 Then Exit Sub

        ID = CType(cboLienAttorney.SelectedItem, ValueDescription).Value

        Reader = gSQLGetDataReader("Select * from InsuranceCompanies Where CompanyID=" & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            txtPhone1.Text = "" & Reader("Phone1").ToString
            txtPhone2.Text = "" & Reader("Phone2").ToString
            txtFax1.Text = "" & Reader("Fax1").ToString
            txtFax2.Text = "" & Reader("Fax2").ToString
            txtEmail.Text = "" & Reader("eMail").ToString
            txtContact1.Text = "" & Reader("Contact1").ToString
            txtContact2.Text = "" & Reader("Contact2").ToString
            txtContact1Phone.Text = "" & Reader("Contact1Phone").ToString
            txtContact2Phone.Text = "" & Reader("Contact2Phone").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        FpSpread1.Enabled = False
        Load_Ins_Addresses(ID)
        Cursor = Cursors.Default
        FpSpread1.Enabled = True

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If MonthCalendar1.Visible = True Then
            MonthCalendar1.Visible = False
            Return
        End If
        MonthCalendar1.Visible = True
        MonthCalendar1.Focus()
        If IsDate(txtLienDate.Text) Then
            MonthCalendar1.SelectionRange.Start = Now.Date
        End If
        'txtLienDate.Text = Now.Date.ToString("MM/dd/yyyy")
    End Sub

    Private Sub MonthCalendar1_Leave(sender As Object, e As EventArgs) Handles MonthCalendar1.Leave
        MonthCalendar1.Visible = False
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged

    End Sub

    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        txtLienDate.Text = MonthCalendar1.SelectionRange.Start.ToString("MM/dd/yyyy")
        MonthCalendar1.Visible = False
    End Sub

    Private Sub MonthCalendar1_KeyDown(sender As Object, e As KeyEventArgs) Handles MonthCalendar1.KeyDown
        If e.KeyCode = Keys.Escape Then
            MonthCalendar1.Visible = False
        End If
    End Sub


    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click, txtContact2.Click, txtContact1Phone.Click, txtContact1.Click, FpSpread1.Click, PictureBox1.Click, Panel3.Click, Panel2.Click, MyBase.Click, txtPhone2.Click, txtPhone1.Click, txtFax2.Click, txtFax1.Click, txtEmail.Click, txtContact2Phone.Click
        If MonthCalendar1.Visible = True Then
            MonthCalendar1.Visible = False
            Return
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        frmBillToAttorneyLien.BillId = Bill_ID
        frmBillToAttorneyLien.MinimizeBox = False
        frmBillToAttorneyLien.MaximizeBox = False
        frmBillToAttorneyLien.ShowDialog(Me)
        frmBillToAttorneyLien.Dispose()
    End Sub
End Class