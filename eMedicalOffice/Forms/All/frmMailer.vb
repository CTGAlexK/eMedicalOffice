Imports System.Reflection
Imports log4net

Public Class frmMailer
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private LastControl As Object

    Private Sub CheckAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAllToolStripMenuItem.Click
        For Each li As ListViewItem In ListViewAddresses.Items
            li.Checked = True
        Next
    End Sub

    Private Sub CheckNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNoneToolStripMenuItem.Click
        For Each li As ListViewItem In ListViewAddresses.Items
            li.Checked = False
        Next
    End Sub

    Private Sub ListViewAddresses_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewAddresses.ItemCheck
        TimerCount.Enabled = True
    End Sub

    Private Sub ListViewAddresses_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewAddresses.ItemChecked

    End Sub

    Private Sub ListViewAddresses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewAddresses.SelectedIndexChanged

    End Sub

    Private Sub Load_Addresses()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String = ""
        SQL = "SELECT AddressID, CompanyName, ContactName, EmailAddress1, Address1, Address2, City, State, Zip FROM         EmailerAddressBook where ActiveInd=1 "
        If txtCompanyNameSearch.Text <> "" Then
            SQL &= " and CompanyName like '" & txtCompanyNameSearch.Text.ToSafeSQLString() & "%'"
        End If
        If RadioButtonPostMail.Checked Then
            SQL &= " and isnull(Address1,'') <>''"
        Else
            SQL &= " and isnull(EmailAddress1,'') <>''"
        End If
        SQL &= " ORDER BY CompanyName"

        Reader = gSQLGetDataReader(SQL)
        ListViewAddresses.Items.Clear()
        lblCount.Text = ""
        ListViewAddresses.BeginUpdate()
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewAddresses.Items.Add(Reader("CompanyName").ToString)
            LI.Tag = New EmailerAddressInfo(Val(Reader("AddressID").ToString), Reader("CompanyName").ToString, Reader("ContactName").ToString, Reader("EmailAddress1").ToString, 0, Reader("Address1").ToString, Reader("Address2").ToString, Reader("City").ToString, Reader("State").ToString, Reader("Zip").ToString)
            LI.UseItemStyleForSubItems = True
            If RadioButtonPostMail.Checked Then
                LI.ToolTipText = Reader("Address1").ToString & " " & Reader("City").ToString & ", " & Reader("State").ToString & " " & Reader("Zip").ToString
                LI.SubItems.Add(Reader("Address1").ToString & " " & Reader("City").ToString & ", " & Reader("State").ToString & " " & Reader("Zip").ToString)
            Else
                LI.ToolTipText = Reader("EmailAddress1").ToString
                LI.SubItems.Add(Reader("EmailAddress1").ToString)
            End If
            LI.SubItems.Add("")

        Loop
        Reader.Close() : Reader.Dispose()
        ListViewAddresses.EndUpdate()
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("SELECT RWID, RWValue, RWDescription FROM EmailerReservedWords Order By RWDescription")
        ComboBoxScript.Items.Clear()
        Do Until Reader.Read = False
            ComboBoxScript.Items.Add(New ValueDescription(Val(Reader("RWID").ToString), Reader("RWDescription").ToString, Reader("RWValue").ToString))
        Loop
        ComboBoxScript.SelectedIndex = -1

        cboPriority.Items.Add("Normal")
        cboPriority.Items.Add("Low")
        cboPriority.Items.Add("High")
        cboPriority.SelectedIndex = 0

    End Sub

    Private Sub frmMailer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewAddresses, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub frmMailer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        gListview_Settings(Me, ListViewAddresses, ReadWrite.sRead)
        Load_Data()
        Load_Templates()
        Load_Addresses()
    End Sub

    Private Sub Load_Templates()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String = ""
        SQL = "SELECT     TempID, TemplateName FROM         EmailerTemplates "
        SQL &= " ORDER BY TemplateName "
        Reader = gSQLGetDataReader(SQL)
        cboTemplates.Items.Clear()
        cboTemplates.Items.Add(New ValueDescription(0, ""))
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboTemplates.Items.Add(New ValueDescription(Val(Reader("TempID").ToString), Reader("TemplateName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxScript.SelectedIndexChanged
        If ComboBoxScript.SelectedIndex = -1 Then Exit Sub
        If LastControl Is Nothing Then LastControl = txtBody
        If LastControl.Text = "" Then
            LastControl.Text = CType(ComboBoxScript.SelectedItem, ValueDescription).Value1 & " "
        Else
            LastControl.Text = LastControl.Text & " " & CType(ComboBoxScript.SelectedItem, ValueDescription).Value1 & " "
        End If
        ComboBoxScript.SelectedIndex = -1
        LastControl.SelectionStart = txtBody.Text.Length
        LastControl.Focus()
    End Sub

    Private Sub cmdSelectAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboTemplates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTemplates.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        txtSubject.Text = ""
        txtAttachement.Text = ""
        txtBody.Text = ""
        txtSubject.Text = ""
        cboPriority.SelectedIndex = -1

        If cboTemplates.SelectedIndex = -1 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        ID = CType(cboTemplates.SelectedItem, ValueDescription).Value
        Reader = gSQLGetDataReader("SELECT TempID, TemplateName, Subject, Attachement, Priority, Body FROM         EmailerTemplates Where TempID=" & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            txtSubject.Text = Reader("Subject").ToString
            txtAttachement.Text = Reader("Attachement").ToString
            txtBody.Text = Reader("Body").ToString
            txtSubject.Text = Reader("Subject").ToString
            cboPriority.SelectedIndex = Val(Reader("Priority").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        Cursor = Cursors.Default
    End Sub

    Private Sub RefreshListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshListToolStripMenuItem.Click
        Load_Addresses()
    End Sub

    Private Sub TimerCount_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCount.Tick
        TimerCount.Enabled = False
        If ListViewAddresses.CheckedItems.Count = 0 Then
            lblCount.Text = "No Addresses Checked"
        Else
            lblCount.Text = "Checked " & ListViewAddresses.CheckedItems.Count
        End If

    End Sub

    Private Sub ButtonRemoveAttachement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim ID As Long
        If cboTemplates.SelectedIndex < 1 Then
            MsgBox("Unableto update template. No template selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to update template" & CType(cboTemplates.SelectedItem, ValueDescription).Description & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
            Exit Sub
        End If
        ID = CType(cboTemplates.SelectedItem, ValueDescription).Value
        If cboPriority.SelectedIndex = -1 Then
            cboPriority.SelectedIndex = 0
        End If

        If txtBody.Text = "" Then
            MsgBox("Unable to process update. The Template Body is required.", MsgBoxStyle.Exclamation)
            txtBody.Focus()
            Exit Sub
        End If
        If txtAttachement.Text <> "" And IO.File.Exists(txtAttachement.Text) = False Then
            MsgBox("Unable to process update. The Attachement file does not exists.", MsgBoxStyle.Exclamation)
            txtAttachement.Focus()
            Exit Sub
        End If
        Dim TA As New SqlClient.SqlDataAdapter("Select * from EmailerTemplates Where TempID = " & ID, gConnectionString)
        Dim CB As New SqlClient.SqlCommandBuilder(TA)
        CB.ConflictOption = ConflictOption.OverwriteChanges
        Dim TR As DataRow
        Dim dTab As New DataTable("EmailerTemplates")

        TA.Fill(dTab)

        TR = dTab.Rows(0)
        TR("Subject") = txtSubject.Text
        TR("Body") = txtBody.Text
        TR("Priority") = cboPriority.SelectedIndex
        TR("Attachement") = txtAttachement.Text
        TA.UpdateCommand = CB.GetUpdateCommand(True)
        Try
            TA.Update(dTab)
            dTab.AcceptChanges()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Exit Sub
        End Try
        dTab.Dispose()
        CB.Dispose()
        TA.Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        frmEmailerMaintenance.ShowDialog(Me)
        frmEmailerMaintenance.Dispose()
        txtSubject.Text = ""
        txtAttachement.Text = ""
        txtBody.Text = ""
        txtSubject.Text = ""
        cboPriority.SelectedIndex = -1
        Load_Addresses()
        Load_Templates()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        txtAttachement.Text = False
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim filenameOnly As String

        If IO.File.Exists(txtAttachement.Text) Then
            FD.FileName = txtAttachement.Text
        End If
        If FD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Select Case UCase(FD.FileName.Right(3).ToUpper())
                Case "ADE", "ADP", "APP", "BAS", "BAT", "CHM", "CMD", "COM", "CPL", "CRT", "CSH", "EXE", "FXP", "HLP", "HTA", "INF", "INS", "ISP", "JS", "JSE", "KSH", "LNK", "MDB", "MDE", "MDT", "MDW", "MSC", "MSI", "MSP", "MST", "OPS", "PCD", "PIF", "PRG", "REG", "SCR", "SCT", "SHB", "SHS", "URL", "VB", "VBE", "VBS", "WSC", "WSF", "WSH"
                    filenameOnly = IO.Path.GetFileName(FD.FileName)

                    If MsgBox("Attention!" & vbCrLf & "In accordance with Microsoft's list of dangerous file extensions," & vbCrLf & "the selected file: " & filenameOnly & " most likely will be blocked by the customer's firewall." & vbCrLf & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        txtAttachement.Text = ""
                        Exit Sub
                    End If
            End Select
            txtAttachement.Text = FD.FileName
        End If

    End Sub

    Private ExitProcess As Boolean

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim AddressID As Long
        Dim LI As ListViewItem
        Dim AI As EmailerAddressInfo
        Dim msg As String
        Dim subject As String
        Dim ID As Long
        Dim PrintEnvelopes As Integer
        PrintEnvelopes = 0
        Dim EmvCount As Integer

        If Val(Button1.Tag) = 1 Then
            If MsgBox("The Bulk Mail Process is not complete." & vbCrLf & "Please confirm you want to interrupt the process?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            ExitProcess = True
            Exit Sub
        Else

            ExitProcess = False
            If RadioButtoneMail.Checked Then
                If gSMTPUID = "" Then
                    MsgBox("Unable to send Email. The SMTP User Name is not specified." & vbCrLf & "Please use the Office Maintenance Function to fix tis problem.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If gSMTPPWD = "" Then
                    MsgBox("Unable to send Email. The SMTP User Password is not specified." & vbCrLf & "Please use the Office Maintenance Function to fix tis problem.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If gSMTPHost = "" Then
                    MsgBox("Unable to send Email. The SMTP Host is not specified." & vbCrLf & "Please use the Emailer Office Function to fix tis problem.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If gSMTPFromAddress = "" Then
                    MsgBox("Unable to send Email. The SMTP From Email Address is not specified." & vbCrLf & "Please use the Office Maintenance Function to fix tis problem.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
            If ListViewAddresses.CheckedItems.Count = 0 Then
                MsgBox("Unable to process Bulk Mail. No Address Checked.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If RadioButtoneMail.Checked Then
                If txtBody.Text = "" Then
                    MsgBox("Unable to process Bulk Mail. The Template Body is empty.", MsgBoxStyle.Exclamation)
                    txtBody.Focus()
                    Exit Sub
                End If
                If txtAttachement.Text <> "" And IO.File.Exists(txtAttachement.Text) = False Then
                    MsgBox("Unable to process Bulk Mail. The Attachement file does not exists.", MsgBoxStyle.Exclamation)
                    txtAttachement.Focus()
                    Exit Sub
                End If
                If txtSubject.Text = "" Then
                    If MsgBox("The Email Message does not have a subject. Would you like to continue Bulk Mail Process?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        txtSubject.Focus()
                        Exit Sub
                    End If
                End If
                If ListViewAddresses.CheckedItems.Count = 1 Then
                    If MsgBox("Please confirm you want to process " & ListViewAddresses.CheckedItems.Count & " Email Message?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                Else
                    If MsgBox("Please confirm you want to process " & ListViewAddresses.CheckedItems.Count & " Email Messages?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            Else
                If txtBody.Text = "" Then
                    MsgBox("Unable to process Bulk Mail. The Letter Text is empty.", MsgBoxStyle.Exclamation)
                    txtBody.Focus()
                    Exit Sub
                End If
                If ListViewAddresses.CheckedItems.Count = 1 Then
                    If MsgBox("Please confirm you want to print " & ListViewAddresses.CheckedItems.Count & " letter?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                Else
                    If MsgBox("Please confirm you want to print " & ListViewAddresses.CheckedItems.Count & " letters?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
            Button1.Text = "Stop"
            Button1.Tag = 1
            Button1.Enabled = False
            cmdClose.Enabled = False

            cboTemplates.Enabled = False
            cboPriority.Enabled = False
            txtSubject.Enabled = False
            txtBody.Enabled = False
            ComboBoxScript.Enabled = False
            ToolStrip1.Enabled = False
            ToolStrip2.Enabled = False
            ListViewAddresses.Enabled = False

            ProgressBar1.Maximum = ListViewAddresses.CheckedItems.Count
            ProgressBar1.Visible = True
            Application.DoEvents()
            For Each LI In ListViewAddresses.CheckedItems
                If ExitProcess Then
                    ExitProcess = False
                    Exit For
                End If

                LI.SubItems(2).Text = "In Progress"
                LI.ForeColor = Color.Blue
                LI.Selected = True
                LI.EnsureVisible()
                AI = CType(LI.Tag, EmailerAddressInfo)
                msg = txtBody.Text
                subject = txtSubject.Text
                If AI.ContactName = "" Then AI.ContactName = "Manager"
                If AI.CompanyName = "" Then AI.ContactName = "Medical Office"
                msg = Replace(msg, "|CompanyName|", AI.CompanyName)
                msg = Replace(msg, "|ContactName|", AI.ContactName)
                msg = Replace(msg, "|DateTime|", Now)
                subject = Replace(subject, "|CompanyName|", AI.CompanyName)
                subject = Replace(subject, "|ContactName|", AI.ContactName)
                subject = Replace(subject, "|DateTime|", Now)

                gSQLDeleteRecord("Delete From EmailerPrinting Where EmpID=" & gCurrentEmployee.EmpID)
                If RadioButtoneMail.Checked Then
                    ProgressBar1.Value = ProgressBar1.Value + 1
                    Application.DoEvents()
                    If gEmailCheck(AI.EmailAddress) = True Then
                        Dim stringArray(0) As String
                        stringArray(0) = txtAttachement.Text
                        If gSendEmail(AI.EmailAddress, subject, msg, stringArray, cboPriority.SelectedIndex) Then
                            LI.ForeColor = Color.Green
                            LI.SubItems(2).Text = "Ok"
                            gSQLUpdateData("INSERT INTO EmailerLog (AddressID, SendDate, Result, TypeID) VALUES(" & AI.AddressID & " ,getdate(), 1,2)")
                        Else
                            LI.ForeColor = Color.Red
                            LI.SubItems(2).Text = "Failed"
                            gSQLUpdateData("INSERT INTO EmailerLog (AddressID, SendDate, Result, TypeID,Comments) VALUES(" & AI.AddressID & " ,getdate(), 2,2,'Email Error')")
                        End If
                    Else
                        LI.ForeColor = Color.Red
                        LI.SubItems(2).Text = "Err Email"
                        gSQLUpdateData("INSERT INTO EmailerLog (AddressID, SendDate, Result, TypeID,Comments) VALUES(" & AI.AddressID & " ,getdate(), 2,2,'Invalid Address')")
                    End If
                Else
                    If AI.Address1 <> "" And AI.City <> "" And AI.State <> "" And AI.Zip <> "" Then
                        gSQLUpdateData("INSERT INTO EmailerPrinting (AddressID,Message, EmpID, OfficeID) VALUES(" & AI.AddressID & ", '" & msg & "', " & gCurrentEmployee.EmpID & "," & gOfficeID & ")")
                        If PrintEnvelopes = 0 Or PrintEnvelopes = 1 Then
                            If PrintEnvelopes = 0 Then
                                PrintEnvelopes = 1
                                If MsgBox("Print Bulk Mail Envelope(s)?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                    PrintEnvelopes = 2
                                    GoTo NoEnvelope
                                End If
                            End If
                            ProgressBar1.Value = ProgressBar1.Value + 1
                            Application.DoEvents()
                            EmvCount = EmvCount + 1
                            ID = gSQLGetSingleValue("SELECT IDENT_CURRENT('EmailerPrinting')")
                            frmBulkMailerEnvelops.Setup_report(ID)
                            frmBulkMailerEnvelops.LabelNumber.Text = "Envelope " & EmvCount & " of " & ListViewAddresses.CheckedItems.Count

                            If frmBulkMailerEnvelops.ShowDialog(Me) <> Windows.Forms.DialogResult.OK Then
                                If ProgressBar1.Value < ListViewAddresses.CheckedItems.Count Then
                                    If MsgBox("The current envelope printing has been canceled." & vbCrLf & "Continue printing envelopes?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                        frmBulkMailerEnvelops.Dispose()
                                        Exit For
                                    End If
                                End If
                            End If
                            frmBulkMailerEnvelops.Dispose()
                            LI.ForeColor = Color.Green
                            LI.SubItems(2).Text = "Ok"
                            gSQLUpdateData("INSERT INTO EmailerLog (AddressID, SendDate, Result, TypeID) VALUES(" & AI.AddressID & " ,getdate(), 1,1)")
                        End If
NoEnvelope:
                    Else
                        LI.ForeColor = Color.Red
                        LI.SubItems(2).Text = "Err Addr"
                        gSQLUpdateData("INSERT INTO EmailerLog (AddressID, SendDate, Result, TypeID,Comments) VALUES(" & AI.AddressID & " ,getdate(), 2,1,'Incomlete Address')")
                    End If

                End If
            Next
            If RadioButtonPostMail.Checked Then
                frmBulkMailerLetter.Setup_report()
                frmBulkMailerLetter.ShowDialog(Me)
                frmBulkMailerLetter.Dispose()
                ' Print Letters

            End If
            gSQLUpdateData("DELETE FROM EmailerPrinting Where EmpID=" & gCurrentEmployee.EmpID)
        End If
        Button1.Tag = 0
        If RadioButtonPostMail.Checked Then
            Button1.Text = "Print Letters"
        Else
            Button1.Text = "Send Email"
        End If
        ExitProcess = False
        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
        Button1.Enabled = True
        cmdClose.Enabled = True
        cboTemplates.Enabled = True
        cboPriority.Enabled = True
        txtSubject.Enabled = True
        txtBody.Enabled = True
        ComboBoxScript.Enabled = True
        ToolStrip1.Enabled = True
        ToolStrip2.Enabled = True
        ListViewAddresses.Enabled = True

    End Sub

    Private Sub txtCompanyNameSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompanyNameSearch.TextChanged
        Load_Addresses()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub txtSubject_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubject.GotFocus
        LastControl = txtSubject
    End Sub

    Private Sub txtBody_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBody.GotFocus
        LastControl = txtBody
    End Sub

    Private Sub txtSubject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubject.TextChanged

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtoneMail.CheckedChanged
        Button1.Text = "Send Email"
        Label15.Visible = True
        txtAttachement.Visible = True
        ToolStrip2.Visible = True
        Load_Addresses()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPostMail.CheckedChanged
        Button1.Text = "Print Letters"
        Label15.Visible = False
        txtAttachement.Visible = False
        ToolStrip2.Visible = False
        Load_Addresses()
    End Sub

End Class