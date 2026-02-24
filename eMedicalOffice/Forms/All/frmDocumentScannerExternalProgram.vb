Imports System.Runtime.InteropServices.Marshal
Imports System.IO
Imports System.Reflection
Imports log4net
Imports System.Data.SqlClient
Imports PdfiumViewer

Public Class frmDocumentScannerExternalProgram
    Public PatientID As Long
    Public CaseTypeID As Long
    Public LoadListView As ListView
    Public IniDocProfile As String
    Public PoliceReportCheck As CheckBox
    Public InitialReportCheck As CheckBox
    Public DocDisplay As PdfiumViewer.PdfViewer
    Public BillID As String
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    'Private pdfViewer As New WebBrowser
    Private pdfViewer As New PdfiumViewer.PdfViewer()

    Public Sub DisposeExplorer()
        On Error Resume Next
        'pdfViewer.Stop
        pdfViewer.CloseDocument
        pdfViewer.Dispose()
        pdfViewer = Nothing
    End Sub

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If pdfViewer.Tag <> "" Then
            If MsgBox("The scanned document has not been saved to the Patient's profile. Discard document Image?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gWindow_Settings(Me, ReadWrite.sWrite)
        pdfViewer.CloseDocument
        If pdfViewer.Tag <> "" Then
            pdfViewer.CloseDocument
            pdfViewer.Tag = ""
            Application.DoEvents()
            If File.Exists(pdfViewer.Tag) Then
                System.Threading.Thread.Sleep(1000)
retry:
                If gDeleteFile(pdfViewer.Tag) = False Then
                    Threading.Thread.Sleep(500)
                    pdfViewer.CloseDocument
                    Application.DoEvents()
                    GoTo retry
                End If
            End If
        End If
        'pdfViewer.Stop
        pdfViewer.CloseDocument
        pdfViewer.Dispose()
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'pdfViewer = New WebBrowser
        pdfViewer = New PdfiumViewer.PdfViewer()
        PanelExplorer.Controls.Add(pdfViewer)
        pdfViewer.Dock = DockStyle.Fill
        pdfViewer.ZoomMode = PdfViewerZoomMode.FitWidth
        pdfViewer.ShowBookmarks = False
        gWindow_Settings(Me, ReadWrite.sRead)
        Application.DoEvents()

        Load_Data()
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Application.DoEvents()
        Try
            SkipProfile = True
            Reader = gSQLGetDataReader("SELECT ProfileID, DocumentName, NameEditableInd, DiagID FROM DocumentProfiles Where ActiveInd=1 ORDER BY ShowOrder, DocumentName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxDocProfile.Items.Add(New ValueDescription(Val(Reader("ProfileID").ToString), Reader("DocumentName").ToString, Val(Reader("NameEditableInd").ToString), Val(Reader("DiagID").ToString)))
            Loop
            Reader.Close() : Reader.Dispose()
            SkipProfile = False
            If IniDocProfile = 0 Then
                ComboBoxDocProfile.SelectedIndex = -1
            Else
                ComboBoxDocProfile.Enabled = False
                txtDocumentName.Enabled = False
                gFindComboItemByValue(ComboBoxDocProfile, IniDocProfile, True)
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub cmdScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click
        Dim DocumentProfileID As Long
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        If ComboBoxDocProfile.SelectedIndex = -1 Then
            MsgBox("Unable to scan." & vbCrLf & vbCrLf & "The Document Profile should be selected.", MsgBoxStyle.Exclamation)
            If ComboBoxDocProfile.Enabled Then ComboBoxDocProfile.Focus()
            Return
        End If
        DocumentProfileID = CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value
        If txtDocumentName.Text.Trim = "" Then
            If DocumentProfileID = 5 Then
                MsgBox("Unable to scan." & vbCrLf & vbCrLf & "The Check Number is Required.", MsgBoxStyle.Exclamation)
            ElseIf DocumentProfileID = 6 Then ' POM
                MsgBox("Unable to scan." & vbCrLf & vbCrLf & "The POM number is Required.", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Unable to scan." & vbCrLf & vbCrLf & "No Document Name specified.", MsgBoxStyle.Exclamation)
            End If

            txtDocumentName.Focus()
            Return
        Else
            Select Case DocumentProfileID
                Case 5
                    If PatientID > 0 Then ' Payment Check
                        If gSQLGetSingleValue("Select count(*) from Documents Where DocumentName = '" & txtDocumentName.Text.Trim.ToSafeSQLString() & "' and PatientID=" & PatientID) > 0 Then
                            MsgBox("Unable to scan." & vbCrLf & vbCrLf & "Duplicate Check" & vbCrLf & vbCrLf & "The specified Check Number image has been already scanned to the Patient's profile.", MsgBoxStyle.Exclamation, "Duplicate Check")
                            txtDocumentName.Focus()
                            Exit Sub
                        End If
                    End If
                    Reader = gSQLGetDataReader("SELECT BillPayments.PaymentID, BillPayments.CheckNumber FROM BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE rtrim(BillPayments.CheckNumber)='" & txtDocumentName.Text.Trim.ToSafeSQLString() & "' and Bills.PatientID = " & PatientID)
                    If Reader.HasRows = False Then
                        If gSQLGetSingleValue("SELECT count(*) FROM  BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE Bills.PatientID = " & PatientID) = 0 Then
                            MsgBox("Unable to scan." & vbCrLf & vbCrLf & "The specified Check Number has NOT been added to the Patient's bill payments." & vbCrLf & vbCrLf & "Please inform the Manager ASAP!", MsgBoxStyle.Critical, "Payment Not Found")
                            Exit Sub
                        End If
                        MsgBox("Unable to scan." & vbCrLf & vbCrLf & "The specified Check Numer has NOT been assigned to the current patient bills." & vbCrLf & vbCrLf & "Please verify the the Check Number." & vbCrLf & vbCrLf & "If the Check Number is correct please inform the Manager ASAP!", MsgBoxStyle.Critical, "Check Number Not Found")
                        ButtonFixCheck.Visible = True
                        Exit Sub
                    End If

                Case 6
                    If PatientID <> 0 Then
                        SQL = "SELECT  DISTINCT  Bills.BillID, POM.CreatedDT, POM.POMID FROM POM INNER JOIN Bills ON POM.POMID = Bills.POMID WHERE Bills.PatientID = " & PatientID & " and POM.POMID = " & Val(txtDocumentName.Text.Trim)
                    Else
                        SQL = "SELECT COUNT(*) FROM POM Where POMID = " & Val(txtDocumentName.Text.Trim.ToSafeSQLString())
                    End If
                    If gSQLGetSingleValue(SQL) = 0 Then
                        MsgBox("Unable to scan. Invalid POM Number." & vbCrLf & vbCrLf & "The specified POM number has not been registered.", MsgBoxStyle.Exclamation)
                        txtDocumentName.SelectAll()
                        txtDocumentName.Focus()
                        Exit Sub
                    End If
                    If gSQLGetSingleValue("SELECT COUNT(*) FROM POM Where (POMImage IS NOT NULL) and POMID = " & Val(txtDocumentName.Text.Trim)) > 0 Then
                        If MsgBox("Attention!" & vbCrLf & vbCrLf & "The POM #" & Val(txtDocumentName.Text.Trim) & " has already been scanned." & vbCrLf & "Do you want to overwrite POM image?" & vbCrLf & vbCrLf & "Supervisor Authorization Required", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            txtDocumentName.SelectAll()
                            txtDocumentName.Focus()
                            Exit Sub
                        End If
                    End If
                Case 18
                    If gSQLGetSingleValue("SELECT COUNT(*) FROM CDPOM Where POMID = " & Val(txtDocumentName.Text.Trim)) = 0 Then
                        MsgBox("Unable to scan. Invalid CD POM Number." & vbCrLf & vbCrLf & "The specified CD POM number has not been registered.", MsgBoxStyle.Exclamation)
                        txtDocumentName.SelectAll()
                        txtDocumentName.Focus()
                        Exit Sub
                    End If
                    If gSQLGetSingleValue("SELECT COUNT(*) FROM CDPOM Where (POMImage IS NOT NULL) and POMID = " & Val(txtDocumentName.Text.Trim)) > 0 Then
                        If MsgBox("Attention!" & vbCrLf & vbCrLf & "The CD POM #" & Val(txtDocumentName.Text.Trim) & " has already been scanned." & vbCrLf & "Do you want to overwrite POM image?" & vbCrLf & vbCrLf & "Supervisor Authorization Required", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            txtDocumentName.SelectAll()
                            txtDocumentName.Focus()
                            Exit Sub
                        End If
                    End If
            End Select
        End If
        If cboPatientProcedure.Visible And PatientID > 0 Then
            If cboPatientProcedure.SelectedIndex = -1 Then
                MsgBox("Unable to update Patient's profile." & vbCrLf & "The Patient's  Report Related Procedure should be selected.", MsgBoxStyle.Exclamation)
                cboPatientProcedure.Focus()
                Exit Sub
            End If
        End If

        If pdfViewer.Tag <> "" Then
            If MsgBox("Please confirm you want to rescan the document Image?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        'If BrowserIsNotBusy(pdfViewer) = False Then
        '    MsgBox("Unable to proceed. The IE Resources are locked by another application(s).", MsgBoxStyle.Exclamation)
        '    Return
        'End If
        cmdUpdate.Enabled = False
        LabelLoading.Text = "Scan In Progress. Please wait..."
        pdfViewer.CloseDocument
        'If BrowserIsNotBusy(pdfViewer) = False Then
        '    MsgBox("Unable to proceed. The IE Resources are locked by another application(s).", MsgBoxStyle.Exclamation)
        '    Return
        'End If
        pdfViewer.Tag = ""
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value = 5 Then
            frmDocumentScannerDialog.DialogText = "Please place the Check Number: " & txtDocumentName.Text & " into the  document feeder and click the Green Scan button."
        Else
            frmDocumentScannerDialog.DialogText = "Place the " & CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Description & " into the Scanner document feeder and click the Green Scan button."
        End If
        Try
            frmDocumentScannerDialog.CalledViewer = pdfViewer
            If frmDocumentScannerDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim myFile As New FileInfo(pdfViewer.Tag)
                Dim fileSize As Long = myFile.Length
                LabelLoading.Text = "Scan Complete. File Size:" & gFormatFileSize(fileSize)
                LabelLoading.Visible = True
                cmdUpdate.Enabled = True
            End If
            frmDocumentScannerDialog.Dispose()
        Catch ex As Exception

        End Try

StopScanning:
        Cursor = Cursors.Default
        If LabelLoading.Text = "Scan In Progress. Please wait..." Then LabelLoading.Text = ""
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub ComboBoxScanner_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = True
    End Sub

    Private Sub PictureBoxFront_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        cmdScan_Click(Nothing, Nothing)
    End Sub

    Private Sub PictureBoxBack_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        cmdScan_Click(Nothing, Nothing)
    End Sub

    Private Sub Update_ProofOfMail(ByVal ProfileID As Integer)
        Dim Confirmed As Boolean = False
        Dim POMTable As String
        If ProfileID = 6 Then
            POMTable = "POM"
        Else
            POMTable = "CDPOM"
        End If
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to update. No POM image scanned.")
            Exit Sub
        End If
        If txtDocumentName.Text.Trim = "" Then
            MsgBox("Unable to scan. POM Number Should be Specified.", MsgBoxStyle.Exclamation)
            txtDocumentName.Focus()
            Exit Sub
        End If
        If IsNumeric(txtDocumentName.Text.Trim) = False Then
            MsgBox("Unable to scan. POM Number Should be numeric Value.", MsgBoxStyle.Exclamation)
            txtDocumentName.Focus()
            txtDocumentName.SelectAll()
            Exit Sub
        End If
        Dim SQL As String
        If PatientID <> 0 Then
            SQL = "SELECT  DISTINCT  Bills.BillID, " & POMTable & ".CreatedDT, " & POMTable & ".POMID FROM " & POMTable & " INNER JOIN Bills ON " & POMTable & ".POMID = Bills.POMID WHERE Bills.PatientID = " & PatientID & " and " & POMTable & ".POMID = " & Val(txtDocumentName.Text.Trim)
        Else
            SQL = "SELECT COUNT(*) FROM " & POMTable & " Where POMID = " & Val(txtDocumentName.Text.Trim)
        End If
        If gSQLGetSingleValue(SQL) = 0 Then
            If PatientID <> 0 Then
                MsgBox("Unable to process update." & vbCrLf & vbCrLf & "Invalid POM Number." & vbCrLf & "The specified POM number has not been registered within the Patient's bills.", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Unable process update." & vbCrLf & vbCrLf & "Invalid POM Number." & vbCrLf & "The specified POM number is not found in the registered POM numbers list.", MsgBoxStyle.Exclamation)
            End If
            txtDocumentName.Focus()
            txtDocumentName.SelectAll()
            Exit Sub
        End If
        If gSQLGetSingleValue("SELECT COUNT(*) FROM " & POMTable & " Where (POMImage IS NOT NULL) and POMID = " & Val(txtDocumentName.Text.Trim)) > 0 Then
            If gCurrentEmployee.PositionID > 3 Then
                frmSupervisorApproval.LabelMsg.Text = "The POM #" & Val(txtDocumentName.Text.Trim) & " is already exist." & vbCrLf & "Are you authorizing to overwrite POM image?"
                If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    frmSupervisorApproval.Dispose()
                    Exit Sub
                End If
                frmSupervisorApproval.Dispose()
            Else
                If MsgBox("Attention!" & vbCrLf & vbCrLf & "The POM #" & Val(txtDocumentName.Text.Trim) & " is already exist." & vbCrLf & vbCrLf & "Are you authorizing to overwrite POM image?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    txtDocumentName.Focus()
                    Return
                End If
            End If

            Confirmed = True
        End If
        If Confirmed = False Then
            If MsgBox("Please confirm the loaded image is the POM #" & txtDocumentName.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                txtDocumentName.Focus()
                Exit Sub
            End If
        End If

        Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM " & POMTable & " Where POMID=" & Val(txtDocumentName.Text.Trim), gConnectionString)
        Dim CB As New SqlClient.SqlCommandBuilder(TA)
        CB.ConflictOption = ConflictOption.OverwriteChanges
        Dim TR As DataRow
        Dim dTab As New DataTable(POMTable)

        TA.Fill(dTab)
        TR = dTab.Rows(0)

        Dim arrImage() As Byte
        arrImage = gSQLReadFileToArray(pdfViewer.Tag)
        TR("POMImage") = arrImage
        TR("RegisteredBy") = gCurrentEmployee.EmpID
        TR("RegisteredDT") = Now
        Try
            TA.Update(dTab)
            dTab.AcceptChanges()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Exit Sub
        End Try
        dTab.Dispose() : CB.Dispose() : TA.Dispose()
        If ProfileID = 6 Then gSQLUpdateData("Update Bills set BillStatusID = 2 Where POMID=" & Val(txtDocumentName.Text.Trim))

        If Not LoadListView Is Nothing Then
            Dim LI As ListViewItem = LoadListView.Items.Add("Bill# " & Val(txtDocumentName.Text) & " POM")
            LI.SubItems.Add(FormatDateTime(Now, DateFormat.ShortDate))
            LI.Tag = Val(txtDocumentName.Text.Trim)
            LI.SubItems(1).Tag = ProfileID
            LI.Selected = True
            LI.EnsureVisible()
        End If
        pdfViewer.Tag = ""
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Reader As SqlClient.SqlDataReader
        Dim DocumentProfileID As Long
        If ComboBoxDocProfile.SelectedIndex = -1 Then
            MsgBox("Unable to scan. The Document Profile should be selected.", MsgBoxStyle.Exclamation)
            If ComboBoxDocProfile.Enabled Then ComboBoxDocProfile.Focus()
            Return
        End If
        DocumentProfileID = CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to update Patient's profile." & vbCrLf & "No document image scanned.")
            Exit Sub
        End If
        If IO.File.Exists(pdfViewer.Tag) = False Then
            MsgBox("Unable to update Patient's profile." & vbCrLf & "Scanned file not found." & vbCrLf & vbCrLf & "Please ReScan the document again.")
            Exit Sub
        End If
        If txtDocumentName.Text.Trim = "" Then
            If DocumentProfileID = 5 Then
                MsgBox("Unable to update patient's profile." & vbCrLf & "The Check Number is required.", MsgBoxStyle.Exclamation)
            ElseIf DocumentProfileID <> 6 And DocumentProfileID <> 18 Then  ' CDPOM / POM processed separately
                MsgBox("Unable to update Patient's profile." & vbCrLf & "No Document Name specified.", MsgBoxStyle.Exclamation)
            End If
            txtDocumentName.Focus()
            Return
        ElseIf DocumentProfileID = 5 And PatientID > 0 Then ' Payment Check
            If gSQLGetSingleValue("Select count(*) from Documents Where DocumentName = '" & txtDocumentName.Text.Trim.ToSafeSQLString() & "' and PatientID=" & PatientID) > 0 Then
                MsgBox("Unable to process update." & vbCrLf & vbCrLf & "Duplicate Check" & vbCrLf & vbCrLf & "The specified Check Number image has been already scanned to the Patient's profile.", MsgBoxStyle.Exclamation, "Duplicate Check")
                txtDocumentName.Focus()
                Exit Sub
            End If
            Reader = gSQLGetDataReader("SELECT BillPayments.PaymentID, BillPayments.CheckNumber FROM BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE rtrim(BillPayments.CheckNumber)='" & txtDocumentName.Text.Trim.ToSafeSQLString() & "' and Bills.PatientID = " & PatientID)
            If Reader.HasRows = False Then
                If gSQLGetSingleValue("SELECT count(*) FROM  BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE Bills.PatientID = " & PatientID) = 0 Then
                    MsgBox("Unable to process update." & vbCrLf & vbCrLf & "This specified Check Number has NOT been added to the Patient's bill payments." & vbCrLf & vbCrLf & "Please inform the Manager ASAP!", MsgBoxStyle.Critical, "Payment Not Found")
                    Exit Sub
                End If
                MsgBox("Unable to process update." & vbCrLf & vbCrLf & "The specified Check Numer has NOT been assigned to the current patient bills." & vbCrLf & vbCrLf & "Please verify the the Check Number." & vbCrLf & vbCrLf & "If the Check Number is correct please inform the Manager ASAP!", MsgBoxStyle.Critical, "Check Number Not Found")
                ButtonFixCheck.Visible = True
                Exit Sub
            End If
        End If

        If DocumentProfileID = 6 Or DocumentProfileID = 18 Then ' CDPOM / POM Processed Separatelly
            Update_ProofOfMail(DocumentProfileID)
            Exit Sub
        End If

        If cboPatientProcedure.Visible And PatientID > 0 Then
            If cboPatientProcedure.SelectedIndex = -1 Then
                MsgBox("Unable to update Patient's profile." & vbCrLf & "The Patient's Report Related Procedure should be selected.", MsgBoxStyle.Exclamation)
                cboPatientProcedure.Focus()
                Exit Sub
            Else
                If MsgBox("Please confirm the scanned document is " & vbCrLf & CType(cboPatientProcedure.SelectedItem, ValueDescription).Description & " Report?") = MsgBoxResult.No Then
                    cboPatientProcedure.Focus()
                    Exit Sub
                End If
                If Val(CType(cboPatientProcedure.SelectedItem, ValueDescription).Value1) <> 2 Then
                    gSQLUpdateData("Update PatientProcedures set ProcedureStatusID = 2, UpdatedDT=getdate(), UpdatedByEmpID=" & gCurrentEmployee.EmpID & " WHERE PatientProcedureID = " & Val(CType(cboPatientProcedure.SelectedItem, ValueDescription).Value))
                    gUpdate_Profile_Log(PatientID, PatientLogTypes.tScheduleCompleted, "Procedure Set as Complete on Report Scanning.")
                End If
            End If
        End If

        Dim arrImage() As Byte
        arrImage = gSQLReadFileToArray(pdfViewer.Tag)
        Dim RetryCount As Integer = 0
        '' Updated to use command because Timeout
        Dim Sql As String
        Sql = "INSERT INTO Documents (PatientID, DocumentProfileID, DocumentImage, DocumentName, InsertedBy, InsertedDate, PatientProcedureID) "
        Sql = Sql & " VALUES(@PatientID, @DocumentProfileID, @DocumentImage, @DocumentName, @InsertedBy, @InsertedDate, @PatientProcedureID)"
Retry:
        Try
            RetryCount = RetryCount + 1
            Using adoConnect = New SqlConnection(gConnectionString & "; Connection Timeout=60")
                adoConnect.Open()
                Using cmd = New SqlCommand(Sql, adoConnect)
                    cmd.CommandTimeout = 60
                    cmd.Parameters.AddWithValue("@PatientID", PatientID)
                    cmd.Parameters.AddWithValue("@DocumentProfileID", DocumentProfileID)
                    cmd.Parameters.AddWithValue("@DocumentImage", arrImage)
                    cmd.Parameters.AddWithValue("@DocumentName", txtDocumentName.Text)
                    cmd.Parameters.AddWithValue("@InsertedBy", gCurrentEmployee.EmpID)
                    cmd.Parameters.AddWithValue("@InsertedDate", FormatDateTime(Now, DateFormat.ShortDate))
                    If cboPatientProcedure.Visible And PatientID > 0 Then
                        cmd.Parameters.AddWithValue("@PatientProcedureID", Val(CType(cboPatientProcedure.SelectedItem, ValueDescription).Value))
                    Else
                        cmd.Parameters.AddWithValue("@PatientProcedureID", 0)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            If RetryCount > 20 Then
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Exit Sub
            End If
            Try
                SqlConnection.ClearAllPools()
            Catch
            End Try
            Threading.Thread.Sleep(500)
            GoTo Retry
        End Try

        Dim TA As SqlClient.SqlDataAdapter
        Dim CB As SqlClient.SqlCommandBuilder
        TA = New SqlClient.SqlDataAdapter("SELECT  * FROM Documents Where 1=2", gConnectionString)
        CB = New SqlClient.SqlCommandBuilder(TA)
        CB.ConflictOption = ConflictOption.OverwriteChanges
        Dim TR As DataRow
        Dim dTab As New DataTable("Documents")

        'TA.Fill(dTab)
        'TR = dTab.NewRow

        'TR("PatientID") = PatientID
        'TR("DocumentProfileID") = DocumentProfileID
        'TR("DocumentImage") = arrImage
        'TR("DocumentName") = txtDocumentName.Text
        'TR("InsertedBy") = gCurrentEmployee.EmpID
        'TR("InsertedDate") = FormatDateTime(Now, DateFormat.ShortDate)
        'If cboPatientProcedure.Visible And PatientID > 0 Then
        '    TR("PatientProcedureID") = Val(CType(cboPatientProcedure.SelectedItem, ValueDescription).Value)
        'Else
        '    TR("PatientProcedureID") = 0
        'End If
        'dTab.Rows.Add(TR)
        'Try
        '    TA.Update(dTab)
        '    dTab.AcceptChanges()
        'Catch ex As Exception
        '    gProcess_Log(ex.Message, ex.StackTrace, True)
        '    Exit Sub
        'End Try
        'dTab.Dispose() : CB.Dispose() : TA.Dispose()
        Dim NewDocID As Long
        NewDocID = gSQLGetSingleValue("Select IDENT_CURRENT('Documents')")
        If Not LoadListView Is Nothing Then
            Dim LI As ListViewItem = LoadListView.Items.Add(txtDocumentName.Text)
            LI.SubItems.Add(FormatDateTime(Now, DateFormat.ShortDate))
            LI.Tag = NewDocID
            LI.SubItems(1).Tag = DocumentProfileID
            Dim si = LI.SubItems.Add("+")
            si.Tag = arrImage
            LI.Selected = True
            LI.EnsureVisible()
            If CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value = 7 And PatientID <> 0 Then ' Preauthorization
                gSQLUpdateData("Update Patients set PreAuthorizationDocID = " & Val(LI.Tag) & " Where PatientID=" & PatientID)
            End If
        End If
        Dim GroupUpdated As Boolean
        Dim PatIDS As String
        Dim PatCount As Integer
        Dim PatMessage As String

        If DocumentProfileID = 7 And PatientID <> 0 Then ' Preauthorization
            gSQLUpdateData("Update Patients set PreAuthorizationDocID = " & NewDocID & " Where PatientID=" & PatientID)
        ElseIf DocumentProfileID = 13 And PatientID <> 0 Then
            gSQLUpdateData("Update Patients set NF2Date = getdate() Where PatientID=" & PatientID)
        ElseIf DocumentProfileID = 11 And PatientID > 0 Then
            gSQLUpdateData("Update Patients set InitialReportReceived = 1 Where PatientID=" & PatientID)
            If Not InitialReportCheck Is Nothing Then
                InitialReportCheck.Tag = 1
                InitialReportCheck.Checked = True
                InitialReportCheck.ForeColor = Color.Black
            End If
        ElseIf DocumentProfileID = 4 And PatientID > 0 Then
            If Not PoliceReportCheck Is Nothing Then
                PoliceReportCheck.Tag = 1
                PoliceReportCheck.Checked = True
                PoliceReportCheck.ForeColor = Color.Black
            End If
            gSQLUpdateData("Update Patients set PoliceReportReceived = 1 Where PatientID=" & PatientID)

            Sql = "SELECT DISTINCT PatientAccidentGroups.PatientID FROM PatientAccidentGroups INNER JOIN PatientAccidentGroups AS PatientAccidentGroups_1 ON PatientAccidentGroups.GroupID = PatientAccidentGroups_1.GroupID "
            Sql &= " WHERE PatientAccidentGroups_1.PatientID = " & PatientID & " AND PatientAccidentGroups.PatientID <> " & PatientID & " AND PatientAccidentGroups.PatientID NOT IN (SELECT     PatientID FROM Documents WHERE DocumentProfileID = - 6 OR DocumentName = 'Police Report')"
            Reader = gSQLGetDataReader(Sql)
            If Not Reader Is Nothing Then
                Dim SQLInsert As String
                TA = New SqlClient.SqlDataAdapter("SELECT * FROM Documents Where 1=2", gConnectionString)
                CB = New SqlClient.SqlCommandBuilder(TA)
                CB.ConflictOption = ConflictOption.OverwriteChanges
                dTab = New DataTable("Documents")
                TA.Fill(dTab)
                Do Until Reader.Read = False
                    SQLInsert = "INSERT INTO Documents (PatientID, DocumentProfileID, DocumentImage, DocumentName, InsertedBy, InsertedDate, PatientProcedureID)"
                    SQLInsert = SQLInsert & " SELECT " & Val(Reader("PatientID").ToString) & " as PatientID, DocumentProfileID, DocumentImage, DocumentName, InsertedBy, InsertedDate, PatientProcedureID from Documents "
                    SQLInsert = SQLInsert & " WHERE DocumentID = " & NewDocID
                    gSQLUpdateData(SQLInsert)
                    'TR = dTab.NewRow
                    'TR("PatientID") = Val(Reader("PatientID").ToString)
                    'TR("DocumentProfileID") = DocumentProfileID
                    'TR("DocumentImage") = arrImage
                    'TR("DocumentName") = "Police Report"
                    'TR("InsertedBy") = gCurrentEmployee.EmpID
                    'TR("InsertedDate") = Now.ToString("MM/dd/yyyy")
                    'dTab.Rows.Add(TR)
                    GroupUpdated = True
                    PatMessage = PatIDS & "Patient#: " & Reader("PatientID").ToString & ", " & gSQLGetSingleValueString("SELECT rtrim(FName)+' '+rtrim(MI)+' '+rtrim(Lname)+' '+rtrim(Suffix) as PatName From Patients WHERE PAtientID=" & Reader("PatientID").ToString).ToString.Trim.Replace("  ", " ") & vbCrLf
                    PatIDS = PatIDS & ", " & Reader("PatientID").ToString
                    gSQLUpdateData("Update Patients set PoliceReportReceived = 1 Where PatientID=" & Reader("PatientID").ToString)
                    PatCount = PatCount + 1
                Loop
                If GroupUpdated Then
                    'TA.Update(dTab)
                    'dTab.AcceptChanges()
                End If
                If GroupUpdated Then
                    PatIDS = PatIDS.Mid(2)
                    If PatCount = 1 Then
                        MsgBox("The Police Report has been also added to the" & vbCrLf & "following Accident Related Patient:" & vbCrLf & vbCrLf & PatMessage, MsgBoxStyle.Information)
                    Else
                        MsgBox("The Police Report has been also added to the" & vbCrLf & "following Accident Related Patients:" & vbCrLf & vbCrLf & PatMessage, MsgBoxStyle.Information)
                    End If
                End If
            End If
        End If
        dTab.Dispose() : CB.Dispose() : TA.Dispose()

        If Not DocDisplay Is Nothing Then
            DocDisplay.Tag = pdfViewer.Tag
            DocDisplay.LoadDocument(pdfViewer.Tag.ToString())
        End If
        pdfViewer.Tag = ""
        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Close()
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        On Error Resume Next
        Dim p = pdfViewer.Document.CreatePrintDocument
        PrintDialog1.Document = p
        PrintDialog1.PrinterSettings = p.PrinterSettings
        PrintDialog1.AllowSomePages = True
        PrintDialog1.AllowPrintToFile = True
        PrintDialog1.UseEXDialog = False
        If PrintDialog1.ShowDialog(Me) = DialogResult.OK Then
            Dim printPrvDlg As PrintPreviewDialog = New PrintPreviewDialog()
            p.PrinterSettings = PrintDialog1.PrinterSettings
            printPrvDlg.Document = p
            printPrvDlg.StartPosition = FormStartPosition.CenterParent
            printPrvDlg.Width = 500
            printPrvDlg.Height = 600
            If printPrvDlg.ShowDialog(Me) = DialogResult.OK Then
                p.Print()
            End If
        End If
        'pdfViewer.ShowPrintDialog()
        'pdfViewer.PrintDocument(Me)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim p = pdfViewer.Document.CreatePrintDocument
        PrintDialog1.Document = p
        PrintDialog1.PrinterSettings = p.PrinterSettings
        PrintDialog1.AllowSomePages = True
        PrintDialog1.AllowPrintToFile = True
        PrintDialog1.UseEXDialog = False
        If PrintDialog1.ShowDialog(Me) = DialogResult.OK Then
            Dim printPrvDlg As PrintPreviewDialog = New PrintPreviewDialog()
            p.PrinterSettings = PrintDialog1.PrinterSettings
            printPrvDlg.Document = p
            printPrvDlg.StartPosition = FormStartPosition.CenterParent
            printPrvDlg.Width = 500
            printPrvDlg.Height = 600
            If printPrvDlg.ShowDialog(Me) = DialogResult.OK Then
                p.Print()
            End If
        End If
        'pdfViewer.ShowPrintDialog()
        'pdfViewer.PrintDocument(Me)
    End Sub

    Private Sub ReScanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReScanToolStripMenuItem.Click
        cmdScan_Click(Nothing, Nothing)
    End Sub

    Dim LastSelected As Integer
    Dim SkipProfile As Boolean

    Private Sub ComboBoxDocProfile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDocProfile.SelectedIndexChanged
        Dim DocumentProfileID As Long
        If SkipProfile = True Then Exit Sub
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        If pdfViewer.Tag <> "" Then
            If MsgBox("Discard document image?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                SkipProfile = True
                ComboBoxDocProfile.SelectedIndex = LastSelected
                SkipProfile = False
                Exit Sub
            End If
        End If
        If ComboBoxDocProfile.SelectedIndex = -1 Then
            txtDocumentName.Enabled = False
            Label1.Text = "Document Name"
            Exit Sub
        End If
        Label1.Text = CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Description.ToUpper
        If pdfViewer.Tag <> "" Then
            pdfViewer.CloseDocument()
            pdfViewer.Tag = ""
        End If
        DocumentProfileID = CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value
        Label3.Text = "Document Name"
        Select Case DocumentProfileID
            Case 5 ' Payment Check
                Label3.Text = "Check Number"
                txtDocumentName.Text = ""
                txtDocumentName.Enabled = True
            Case 6 ' POM
                Label3.Text = "POM Number"
                txtDocumentName.Text = ""
                txtDocumentName.Enabled = True
            Case 9
                Label3.Text = "Denial For Bill #:"
                'txtDocumentName.Text = "Denial For Bill #:" & BillID
                txtDocumentName.Enabled = True
            Case 18 ' CD POM
                Label3.Text = "CD POM Number"
                txtDocumentName.Text = ""
                txtDocumentName.Enabled = True
            Case Else
                txtDocumentName.Text = CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Description
        End Select
        txtDocumentName.Enabled = CBool(CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value1)
        If txtDocumentName.Enabled Then
            txtDocumentName.Focus()
        Else
            cmdScan.Focus()
        End If
        If ImageList1.Images.IndexOfKey("K" & CStr(CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value)) > -1 Then
            PictureBox1.Image = ImageList1.Images("K" & CStr(CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value))
        Else
            PictureBox1.Image = ImageList1.Images("K17")
        End If
        If Val(CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Fld1) > 0 And PatientID > 0 Then
            cboPatientProcedure.Items.Clear()
            SQL = "SELECT     PatientProcedures.PatientProcedureID, Procedures.ProcName, Schedule.ScheduleDateTime, PatientProcedures.ProcedureStatusID  "
            SQL &= " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
            SQL &= " WHERE   PatientProcedures.OfficeID=" & gOfficeID & " AND  PatientProcedures.DiagID = " & Val(CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Fld1) & " AND PatientProcedures.ProcedureStatusID<>3 AND PatientProcedures.PAtientID=" & PatientID & " ORDER BY Procedures.ProcName, PatientProcedures.DiagID "
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                cboPatientProcedure.Items.Add(New ValueDescription((Reader("PatientProcedureID").ToString), CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yy") & " " & Reader("ProcName").ToString, Val(Reader("ProcedureStatusID").ToString)))
            Loop
            cboPatientProcedure.Visible = True
            LabelPatientProcedure.Visible = True
            PictureBoxInfo.Visible = True
        Else
            cboPatientProcedure.Visible = False
            LabelPatientProcedure.Visible = False
            PictureBoxInfo.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to process your request. No Document Scanned")
        End If
        Subject = "Attached: " & txtDocumentName.Text & " PDF Document"
        Fname = pdfViewer.Tag
        Try

            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to process your request. No Document Scanned")
        End If
        Subject = "Attached: " & txtDocumentName.Text & " PDF Document"
        Fname = pdfViewer.Tag
        Try
            gFax(Me, "", "Attached: Document", pdfViewer.Tag, gOfficeFax)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub IExplorer1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub ButtonFixCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFixCheck.Click
        Dim ApprovedByID As Long
        Dim ApprovedByName As String
        If gCurrentEmployee.PositionID > 3 Then
            frmSupervisorApproval.LabelMsg.Text = "Administrative Function Access" & vbCrLf & "Change Payment Check Number"
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByID = frmSupervisorApproval.SupervisorID
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            ApprovedByID = gCurrentEmployee.EmpID
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        frmBillingPaymentChangeCheckNumber.ApprovedByName = ApprovedByName
        frmBillingPaymentChangeCheckNumber.PatientID = PatientID
        frmBillingPaymentChangeCheckNumber.txtCheckNumber.Text = txtDocumentName.Text.Trim

        If frmBillingPaymentChangeCheckNumber.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ButtonFixCheck.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FName As String
        Dim FTitle As String
        Dim DocumentProfileID As Long
        If ComboBoxDocProfile.SelectedIndex = -1 Then
            MsgBox("Unable to import the document file." & vbCrLf & vbCrLf & "The Document Profile should be selected.", MsgBoxStyle.Exclamation)
            If ComboBoxDocProfile.Enabled Then ComboBoxDocProfile.Focus()
            Return
        End If
        DocumentProfileID = CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value
        If txtDocumentName.Text.Trim = "" Then
            If DocumentProfileID = 5 Then
                MsgBox("Unable to import the document file." & vbCrLf & vbCrLf & "The Check Number is Required.", MsgBoxStyle.Exclamation)
            ElseIf DocumentProfileID = 6 Then ' POM
                MsgBox("Unable to import the document file." & vbCrLf & vbCrLf & "The POM number is Required.", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Unable to import the document file." & vbCrLf & vbCrLf & "No Document Name specified.", MsgBoxStyle.Exclamation)
            End If

            txtDocumentName.Focus()
            Return
        End If
        If pdfViewer.Tag <> "" Then
            If MsgBox("Please confirm you want to reload the document Image?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Try

            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                FName = OpenFileDialog1.FileName
                Dim Ext As String = IO.Path.GetExtension(FName).ToString.ToUpper
                DocumentProfileID = DocumentProfileID
                Dim MyFile As New FileInfo(FName)
                Dim FileSize As Long = MyFile.Length
                FTitle = Replace(Replace(Replace(MyFile.Name, MyFile.Extension, ""), "_", ""), "  ", "")
                FTitle = StrConv(FTitle, VbStrConv.ProperCase)
                If txtDocumentName.Enabled And txtDocumentName.Text = "" Then
                    txtDocumentName.Text = FTitle
                End If
                LabelLoading.Text = "File Size:" & gFormatFileSize(FileSize)
                LabelLoading.Visible = True
                pdfViewer.CloseDocument
                pdfViewer.LoadDocument(FName)
                pdfViewer.Tag = FName
                cmdUpdate.Enabled = True
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

End Class