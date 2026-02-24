Public Class frmReminder
    Public RequestID As Long
    Public RequestStatus As Long
    Public ActionsCount As Long
    Public PatientID As Long
    Public RequestTypeID As Long

    Private Sub frmReminder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        Me.StartPosition = FormStartPosition.CenterScreen
        Timer1.Enabled = True
        If RequestTypeID = 1 Then
            ToolStrip3.Visible = True
            ToolStrip2.Visible = False
        Else
            ToolStrip3.Visible = False
            ToolStrip2.Visible = True
        End If
    End Sub
    Public Sub Load_Statuses()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = "SELECT     StatusID, Description, SecurityLevel FROM BillingRequestStatuses WHERE SecurityLevel >= " & gCurrentEmployee.PositionID

        Reader = gSQLGetDataReader(SQL.ToString())
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                ComboBoxStatus.Items.Add(New ValueDescription(Reader("StatusID"), Reader("Description")))
            Loop
        End If
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.03
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
        End If

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmActionsPool.txtBox = TextBoxNewAction
        frmActionsPool.ShowDialog(Me)
        frmActionsPool.Dispose()
    End Sub

    Private Sub ListViewrequestActions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewrequestActions.SelectedIndexChanged
        TextBox1.Text = ""
        If ListViewrequestActions.SelectedItems.Count = 0 Then Exit Sub
        TextBox1.Text = ListViewrequestActions.SelectedItems(0).SubItems(1).Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBoxNewAction.Text.Trim = "" Then
            MsgBox("Unable to add action. Please specify the New Action information", MsgBoxStyle.Exclamation)
            TextBoxNewAction.Focus()
            Exit Sub
        End If
        Dim LI As ListViewItem
        LI = ListViewrequestActions.Items.Add(FormatDateTime(Now, DateFormat.ShortDate))
        LI.SubItems.Add(TextBoxNewAction.Text)
        LI.SubItems.Add(gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
        LI.Selected = True
        LI.EnsureVisible()
        TextBoxNewAction.Text = ""
        TextBoxNewAction.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim I As Integer
        Dim LI As ListViewItem
        If ComboBoxStatus.SelectedIndex = -1 Then
            MsgBox("Unable to update Request. Please select a request status.", MsgBoxStyle.Exclamation)
            ComboBoxStatus.Focus()
            Exit Sub
        End If
        If ListViewrequestActions.Items.Count = 0 And RequestStatus = CType(ComboBoxStatus.SelectedItem, ValueDescription).Value Then
            MsgBox("Unable to update Request. No New request actions specified.")
            Exit Sub
        End If
        If ListViewrequestActions.Items.Count = ActionsCount And RequestStatus = CType(ComboBoxStatus.SelectedItem, ValueDescription).Value Then
            MsgBox("Unable to update Request. Nothing to update.")
            Exit Sub
        End If
        If RequestStatus <> CType(ComboBoxStatus.SelectedItem, ValueDescription).Value Then
            If MsgBox("Please confirm the request status: " & CType(ComboBoxStatus.SelectedItem, ValueDescription).Description, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                ComboBoxStatus.Focus()
                Exit Sub
            End If
            gSQLUpdateData("UPDATE BillingRequests Set StatusDate = getdate(), RequestStatusID = " & CType(ComboBoxStatus.SelectedItem, ValueDescription).Value & " Where RequestID=" & RequestID)
            RequestStatus = CType(ComboBoxStatus.SelectedItem, ValueDescription).Value
        End If

        For Each LI In ListViewrequestActions.Items
            If Val(LI.Tag) = 0 Then
                gSQLUpdateData("INSERT INTO BillingRequestActions (RequestID, Description, CreatedBy) VALUES(" & RequestID & ", '" & LI.SubItems(1).Text.ToSafeSQLString() & "', " & gCurrentEmployee.EmpID & ")")
            End If
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ToolStripButtonReferral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonReferral.Click
        If gScannerMode = 1 Then
            ScanDocumentFromScannerApplication(1)
        Else
            ScanDocumentFromScanner(1)

        End If
    End Sub

    Private Sub ToolStripButtonAOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAOB.Click
        If gScannerMode = 1 Then
            ScanDocumentFromScannerApplication(3)
        Else
            ScanDocumentFromScanner(3)
        End If
    End Sub
    Private Sub ScanDocumentFromScanner(ByVal DocProfileID As Integer)
        frmDocumentScannerPDF.IniDocProfile = DocProfileID
        frmDocumentScannerPDF.PatientID = PatientID
        If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim LI As ListViewItem
                LI = ListViewrequestActions.Items.Add(FormatDateTime(Now, DateFormat.ShortDate))
                LI.SubItems.Add(IIf(DocProfileID = 1, "Referral Added", "AOB Added"))
                LI.SubItems.Add(gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
                LI.Selected = True
                LI.EnsureVisible()
                TextBoxNewAction.Focus()
            End If
        End If
        frmDocumentScannerPDF.Dispose()
    End Sub
    Private Sub ScanDocumentFromScannerApplication(ByVal DocProfileID As Integer)
        If gScannerFolder = "" Then
            MsgBox("Unable to scan. The Scanner Folder has not been specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IO.Directory.Exists(gScannerFolder) = False Then
            MsgBox("Unable to scan. Invalid Scanner Folder specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        frmDocumentScannerExternalProgram.IniDocProfile = DocProfileID
        frmDocumentScannerExternalProgram.PatientID = PatientID
        If frmDocumentScannerExternalProgram.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim LI As ListViewItem
                LI = ListViewrequestActions.Items.Add(FormatDateTime(Now, DateFormat.ShortDate))
                LI.SubItems.Add(IIf(DocProfileID = 1, "Referral Added", "AOB Added"))
                LI.SubItems.Add(gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
                LI.Selected = True
                LI.EnsureVisible()
                TextBoxNewAction.Focus()
            End If

        End If
        frmDocumentScannerExternalProgram.Dispose()
    End Sub
    Private Sub ToolStripButtonOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonOther.Click
        Dim CaseTypeID As Long = 0
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("Select CaseTypeID from Patients where PatientID = " & PatientID)
        If Not Reader Is Nothing Then
            If Reader.HasRows Then
                Reader.Read()
                frmDocumentScannerPDF.CaseTypeID = Val(Reader("CaseTypeID".ToString))
            End If
        End If
        frmDocumentScannerPDF.txtDocumentName.Text = "Chart " & Now.ToString("MM/dd/yy hh:mm")
        frmDocumentScannerPDF.PatientID = PatientID
        frmDocumentScannerPDF.LoadListView = Nothing
        If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim LI As ListViewItem
            LI = ListViewrequestActions.Items.Add(FormatDateTime(Now, DateFormat.ShortDate))
            LI.SubItems.Add(frmDocumentScannerPDF.DocName & " Added")
            LI.SubItems.Add(gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
            LI.Selected = True
            LI.EnsureVisible()
            TextBoxNewAction.Focus()

        End If
        frmDocumentScannerPDF.Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        frmImageDiskRequest.Load_Data()
        frmImageDiskRequest.TextBoxSearch.Text = PatientID
        frmImageDiskRequest.Load_Patients()
        If frmImageDiskRequest.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim LI As ListViewItem
            LI = ListViewrequestActions.Items.Add(FormatDateTime(Now, DateFormat.ShortDate))
            LI.SubItems.Add("CD Invoice Created")
            LI.SubItems.Add(gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
            LI.Selected = True
            LI.EnsureVisible()
            TextBoxNewAction.Focus()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmImageDiskProcessing.ShowDialog(Me)
        frmImageDiskProcessing.Dispose()
    End Sub
End Class