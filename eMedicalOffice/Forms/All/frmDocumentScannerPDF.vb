Imports System.Runtime.InteropServices.Marshal
Imports System.IO
Imports System.Reflection
Imports log4net
Imports PdfiumViewer

Public Class frmDocumentScannerPDF
    Public PatientID As Long
    Public CaseTypeID As Long
    Public LoadListView As ListView
    Public PoliceReportCheck As CheckBox
    Public InitialReportCheck As CheckBox
    Public IniDocProfile As Integer
    Declare Function DeleteObject Lib "gdi32.dll" (ByVal hObject As IntPtr) As Boolean
    Dim hDib As IntPtr = IntPtr.Zero
    Dim DocColor As Integer = 0
    Dim DocSize As Double = 0
    Dim DocResolution As Integer = 0
    Dim JpegQuality As Integer = 0
    Dim TrimBorder As Double = 0
    Public DocName As String
    Public DocDisplay As PdfViewer
    Public BillID As String
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Function RefreshSourceList() As Boolean
        Dim n As Boolean, i As Integer
        Dim S As String, Def As String
        Dim LastIndex As Integer = CInt(Val(GetSetting(My.Application.Info.ProductName, "Settings", "LastDocScanner", "-1")))
        Dim SaveSelectedIndex As Integer = 0
        Def = EZTwain.DefaultSourceName
        ComboBoxScanner.Items.Clear()
        n = EZTwain.GetSourceList()
        Do
            S = EZTwain.NextSourceName()
            If S.Length = 0 Then Exit Do
            i = ComboBoxScanner.Items.Add(S)
            If S = Def Then
                SaveSelectedIndex = i
            End If
        Loop
        If ComboBoxScanner.Items.Count > 0 Then
            RefreshSourceList = True
            If LastIndex <= ComboBoxScanner.Items.Count - 1 Then
                ComboBoxScanner.SelectedIndex = LastIndex
            Else
                ComboBoxScanner.SelectedIndex = i
            End If
        Else
            LabelLoading.Text = "No scanner found. The only Import Document function is available."
            Label1.Text = "IMPORT DOCUMENT"
            ComboBoxScanner.Enabled = False
        End If
    End Function

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If hDib <> System.IntPtr.Zero Or pdfViewer.Tag <> "" Then
            If MsgBox("The scanned document has not been saved to the Patient's profile. Discard document Image?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        pdfViewer.CloseDocument()
        Err.Clear()
        On Error Resume Next

        SaveSetting(My.Application.Info.ProductName, "Settings", "LastDocScanner", ComboBoxScanner.SelectedIndex.ToString)
        SaveSetting(My.Application.Info.ProductName, "Settings", "LastDocSource", ComboBoxFeeder.SelectedIndex.ToString)

        gWindow_Settings(Me, ReadWrite.sWrite)
        Dim DeleteFileName As String
        pdfViewer.CloseDocument()
        Err.Clear()
        On Error Resume Next

        If pdfViewer.Tag <> "" Then
            DeleteFileName = pdfViewer.Tag
            pdfViewer.CloseDocument()
            pdfViewer.Dispose()
            pdfViewer = Nothing

            GC.Collect()
            System.Threading.Thread.Sleep(200)
            GC.Collect()
            Application.DoEvents()
            If File.Exists(DeleteFileName) Then
                System.Threading.Thread.Sleep(200)
retry:
                Err.Clear()
                On Error Resume Next

                If gDeleteFile(DeleteFileName) = False Then
                    System.Threading.Thread.Sleep(500)
                    On Error Resume Next
                    pdfViewer.CloseDocument()
                    Application.DoEvents()
                    GoTo retry
                End If
            End If
        End If
    End Sub

    Dim LastDocProfile As Integer

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        Load_Data()
        If RefreshSourceList() = False Then Exit Sub
        Application.DoEvents()
        ComboBoxFeeder.SelectedIndex = CInt(GetSetting(My.Application.Info.ProductName, "Settings", "LastDocSource", "0"))

        LabelLoading.Text = ""
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Application.DoEvents()
        Try
            SkipProfile = True
            Reader = gSQLGetDataReader("SELECT ProfileID, DocumentName, NameEditableInd, DiagID FROM DocumentProfiles where ActiveInd=1 ORDER BY ShowOrder, DocumentName")
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
        If Not hDib.Equals(IntPtr.Zero) Then
            EZTwain.DIB_Free(hDib)
        End If
    End Sub

    Private Sub cmdScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click
        Dim SQL As String
        Dim RetOpenSource As Boolean
        Dim DocumentProfileID As Long
        Dim Reader As SqlClient.SqlDataReader
        Dim S As String
        Dim FName As String
        If ComboBoxScanner.SelectedIndex < 0 Then
            MsgBox("Unable to scan." & vbCrLf & vbCrLf & "No Scanner selected.", MsgBoxStyle.Exclamation)
            ComboBoxScanner.Focus()
            Return
        End If
        If ComboBoxFeeder.SelectedIndex < 0 Then
            MsgBox("Unable to scan." & vbCrLf & vbCrLf & "No Document Source selected.", MsgBoxStyle.Exclamation)
            ComboBoxFeeder.Focus()
            Return
        End If
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
                    Reader = gSQLGetDataReader("SELECT BillPayments.PaymentID, BillPayments.CheckNumber FROM BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE rtrim(BillPayments.CheckNumber)='" & txtDocumentName.Text.Trim & "' and Bills.PatientID = " & PatientID)
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
                        SQL = "SELECT COUNT(*) FROM POM Where POMID = " & Val(txtDocumentName.Text.Trim)
                    End If
                    If gSQLGetSingleValue(SQL) = 0 Then
                        If PatientID <> 0 Then
                            MsgBox("Unable to scan. Invalid POM Number." & vbCrLf & vbCrLf & "The specified POM number has not been registered for the current Patient's Profile.", MsgBoxStyle.Exclamation)
                        Else
                            MsgBox("Unable to scan. Invalid POM Number." & vbCrLf & vbCrLf & "The specified POM number has not been registered.", MsgBoxStyle.Exclamation)
                        End If
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
                MsgBox("Unable to update Patient's profile." & vbCrLf & "The Patient's Report Related Procedure should be selected.", MsgBoxStyle.Exclamation)
                cboPatientProcedure.Focus()
                Exit Sub
            End If
        End If

        If hDib <> System.IntPtr.Zero Or pdfViewer.Tag <> "" Then
            If MsgBox("Please confirm you want to rescan the document Image?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        SaveSetting(My.Application.Info.ProductName, "Settings", "DuplexScanning", chkDuplexScanning.Checked)
        LabelLoading.Text = "Scan In Progress. Please wait..."
        txtDocumentName.Enabled = False
        cmdScan.Enabled = False
        ComboBoxScanner.Enabled = False
        ComboBoxFeeder.Enabled = False
        ComboBoxDocProfile.Enabled = False
        txtDocumentName.Enabled = False
        ButtonPrint.Enabled = False
        cmdClose.Enabled = False
        pdfViewer.CloseDocument()
        pdfViewer.Tag = ""

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        S = ComboBoxScanner.Items.Item(ComboBoxScanner.SelectedIndex).ToString
        'EZTwain.SetHideUI(True)
        If EZTwain.State = EZTwain.TWAIN_SOURCE_OPEN Then
            RetOpenSource = True
        Else
            RetOpenSource = EZTwain.OpenSource(S)
        End If

        If RetOpenSource Then
            If EZTwain.GetCapBool(EZTwain.CAP_DEVICEONLINE, True) = False Then
                MsgBox("Unable to scan. The " & ComboBoxScanner.Text & " is appear to be Off Line.", MsgBoxStyle.Exclamation)
                GoTo StopScanning
            End If

            ''''  Start Scanning Process
            If ComboBoxFeeder.SelectedIndex = 0 Then
                FName = ScanFromFeeder()
            Else
                FName = ScanFromFlatBed()
            End If
            Try
                If FName.Trim <> "" Then
                    Dim MyFile As New FileInfo(FName)
                    Dim FileSize As Long = MyFile.Length
                    LabelLoading.Text = "Scan Complete. File Size:" & gFormatFileSize(FileSize)
                    LabelLoading.Visible = True
                    pdfViewer.LoadDocument(FName)
                    pdfViewer.Tag = FName
                    cmdUpdate.Enabled = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)

            End Try
        Else
            MsgBox("Unable to scan. The " & ComboBoxScanner.Text & " is appear to be Off Line.", MsgBoxStyle.Exclamation)
        End If
StopScanning:
        Try
            EZTwain.CloseSource()
        Catch ex As Exception

        End Try

        Cursor = Cursors.Arrow
        cmdScan.Enabled = True
        ComboBoxScanner.Enabled = True
        ComboBoxFeeder.Enabled = True
        If IniDocProfile = 0 Then
            ComboBoxDocProfile.Enabled = True
        End If
        Select Case CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Value
            Case 5 ' Payment Check
                txtDocumentName.Enabled = True
            Case 6 ' POM
                txtDocumentName.Enabled = True
            Case 9
                txtDocumentName.Enabled = True
            Case Is = 18 ' CD POM
                txtDocumentName.Enabled = True
            Case Else
                txtDocumentName.Enabled = False
        End Select
        ButtonPrint.Enabled = True
        cmdClose.Enabled = True
        If LabelLoading.Text = "Scan In Progress. Please wait..." Then LabelLoading.Text = ""
    End Sub

    Private Function ScanFromFeeder() As String
        ''''''''''''''
        Dim I As Integer
        ScanFromFeeder = ""
        EZTwain.SelectFeeder(True)
        EZTwain.SetMultiTransfer(True)
        If EZTwain.IsPaperDetectable Then
            If EZTwain.IsFeederLoaded = False Then
                If MsgBox("Unable to scan." & vbCrLf & "No document loaded. Please place a document in the document feeder and click the OK button." & vbCrLf & "Otherwise click Cancel.", MsgBoxStyle.Information + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                    ScanFromFeeder = ""
                    Exit Function
                End If
            End If
        End If
        ''''''''''''''
        EZTwain.SetPaperSize(DocSize)
        EZTwain.PDF_SelectPageSize(DocSize)
        Dim L As Double, T As Double, R As Double, B As Double
        Call EZTwain.GetDefaultImageLayout(L, T, R, B)
        Call EZTwain.SetImageLayout(L + TrimBorder, T + TrimBorder, R - (TrimBorder * 2), B - (TrimBorder * 2))
        Call EZTwain.SetRegion(L + TrimBorder, T + TrimBorder, R - (TrimBorder * 2), B - (TrimBorder * 2))

        Call EZTwain.SetCompression(True)
        Call EZTwain.SetBrightness(-20)
        Call EZTwain.SetContrast(100)
        If EZTwain.GetDuplexSupport <> 0 Then
            If chkDuplexScanning.Checked Then
                Call EZTwain.EnableDuplex(True)
            Else
                Call EZTwain.EnableDuplex(False)
            End If
        End If
        Dim C
        If DocColor = 0 Then
            Call EZTwain.SetPixelType(EZTwain.TWPT_BW)
            Call EZTwain.SetBitDepth(8)
            C = EZTwain.TWPT_BW
        ElseIf DocColor = 1 Then
            Call EZTwain.SetPixelType(EZTwain.TWPT_GRAY)
            Call EZTwain.SetBitDepth(8)
            C = EZTwain.TWPT_GRAY
        Else
            Call EZTwain.SetPixelType(EZTwain.TWPT_RGB)
            Call EZTwain.SetBitDepth(24)
            C = EZTwain.TWPT_RGB
        End If
        EZTwain.SetResolution(DocResolution)
        EZTwain.SetJpegQuality(JpegQuality)
        EZTwain.SetXferCount(-1)
        EZTwain.SetAutoScan(True)
        EZTwain.SetMultiTransfer(True)
        EZTwain.SetPdfTitle(gOfficeName)
        EZTwain.SetPdfAuthor(gOfficeName)
        EZTwain.SetPdfSubject(txtDocumentName.Text)
        EZTwain.SetPdfCreator(gOfficeName)
        EZTwain.PDF_SetCreator(gOfficeName)
        EZTwain.PDF_SetCompression(C, EZTwain.COMPRESSION_JPEG)

        Dim FName As String = System.IO.Path.GetTempFileName.ToString
        FName = FName.Replace("tmp", "pdf")
        Try
            EZTwain.BeginMultipageFile(FName)
            Do
                hDib = EZTwain.Acquire(Me.Handle())
                If hDib = System.IntPtr.Zero Then
                    Exit Do
                End If
                I = I + 1
                EZTwain.LastErrorCode()
                EZTwain.DibWritePage(hDib)
                EZTwain.LastErrorCode()
                EZTwain.DIB_Free(hDib)
            Loop While Not EZTwain.IsDone()
            EZTwain.EndMultipageFile()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        LabelLoading.Text = ""
        If EZTwain.LastErrorCode = 0 Or EZTwain.IsDone = True Then
            If I = 0 Then
                Return ""
            Else
                Return FName
            End If
        Else
            TopMost = False
            MsgBox(EZTwain.LastErrorText.ToString & " " & EZTwain.LastErrorText, MsgBoxStyle.Critical, "Error")
            log.Error(EZTwain.LastErrorText.ToString & " " & EZTwain.LastErrorText)
        End If
    End Function

    Private Function ScanFromFlatBed() As String
        ScanFromFlatBed = ""
        ''''''''''''''
        EZTwain.SelectFeeder(False)
        EZTwain.SetAutoFeed(False)
        EZTwain.SetAutoScan(False)
        EZTwain.SetMultiTransfer(False)
        ''''''''''''''
        EZTwain.SetPaperSize(DocSize)
        EZTwain.PDF_SelectPageSize(DocSize)

        Dim L As Double, T As Double, R As Double, B As Double
        Call EZTwain.GetDefaultImageLayout(L, T, R, B)
        Call EZTwain.SetImageLayout(L + TrimBorder, T + TrimBorder, R - (TrimBorder * 2), B - (TrimBorder * 2))
        Call EZTwain.SetRegion(L + TrimBorder, T + TrimBorder, R - (TrimBorder * 2), B - (TrimBorder * 2))

        Call EZTwain.SetCompression(True)
        Call EZTwain.SetBrightness(-20)
        'Call EZTwain.SetContrast(100)
        Dim C As Long
        If DocColor = 0 Then
            Call EZTwain.SetPixelType(EZTwain.TWPT_BW)
            Call EZTwain.SetBitDepth(8)
            C = EZTwain.TWPT_BW
        ElseIf DocColor = 1 Then
            Call EZTwain.SetPixelType(EZTwain.TWPT_GRAY)
            Call EZTwain.SetBitDepth(8)
            C = EZTwain.TWPT_GRAY
        Else
            Call EZTwain.SetPixelType(EZTwain.TWPT_RGB)
            Call EZTwain.SetBitDepth(24)
            C = EZTwain.TWPT_RGB
        End If

        EZTwain.SetResolution(DocResolution)
        EZTwain.SetJpegQuality(JpegQuality)
        EZTwain.SetXferCount(-1)
        EZTwain.SetPdfTitle(gOfficeName)
        EZTwain.SetPdfAuthor(gOfficeName)
        EZTwain.SetPdfSubject(txtDocumentName.Text)
        EZTwain.SetPdfCreator(gOfficeName)
        EZTwain.PDF_SetCompression(C, EZTwain.COMPRESSION_JPEG)
        Try
            hDib = EZTwain.Acquire(Me.Handle())
            If Not hDib.Equals(IntPtr.Zero) Then
                Dim FName As String = System.IO.Path.GetTempFileName.ToString
                FName = FName.Replace("tmp", "pdf")
                EZTwain.DIB_WriteToPdf(hDib, FName)
                If EZTwain.LastErrorCode = 0 Then
                    Return FName
                    'System.IO.File.Delete(FName)
                Else
                    TopMost = False
                    MsgBox(EZTwain.LastErrorText.ToString & " " & EZTwain.LastErrorText, MsgBoxStyle.Critical, "Error")
                    log.Error(EZTwain.LastErrorText.ToString & " " & EZTwain.LastErrorText)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub ComboBoxScanner_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxScanner.SelectedIndexChanged
        If ComboBoxScanner.SelectedIndex > -1 Then
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim S As String
        Timer1.Enabled = False
        Try
            chkDuplexScanning.Checked = False
            chkDuplexScanning.Enabled = False

            S = ComboBoxScanner.Items.Item(ComboBoxScanner.SelectedIndex).ToString
            If EZTwain.SourceName = S And EZTwain.State = EZTwain.TWAIN_SOURCE_OPEN Then
                GoTo ExitSub
            End If
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            If EZTwain.State = EZTwain.TWAIN_SOURCE_OPEN Then
                EZTwain.CloseSource()
            End If
            EZTwain.SetHideUI(True)
            EZTwain.OpenSource(S)
            If EZTwain.LastErrorCode <> 0 Then
                Cursor = Cursors.Default
                gShowWait(False, PanelWait, Me)
                Me.Hide()
                MsgBox("Possible solution:" & vbCrLf & vbCrLf & "1. Check if the Scanner Powered On." & vbCrLf & "2. Check the Scanner - Computer connection." & vbCrLf & "3. Try to restart the Scanner." & vbCrLf & "4. Try to restart the Computer." & vbCrLf & vbCrLf & vbCrLf & "If the problem still persists, call the system administrator.", MsgBoxStyle.Information + MsgBoxStyle.SystemModal)
                Me.Show()
                ComboBoxScanner.SelectedIndex = -1
                cmdScan.Enabled = False
                ComboBoxFeeder.Enabled = False
                LabelLoading.Text = ""
                Exit Sub
            End If
            cmdScan.Enabled = True
            ComboBoxFeeder.Enabled = True
            If EZTwain.GetDuplexSupport <> 0 Then
                chkDuplexScanning.Checked = GetSetting(My.Application.Info.ProductName, "Settings", "DuplexScanning", True)
                chkDuplexScanning.Enabled = True
            End If
        Catch ex As Exception

        End Try

ExitSub:
        Cursor = Cursors.Default
        gShowWait(False, PanelWait, Me)
        LabelLoading.Text = ""
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
                MsgBox("Unable to process update." & vbCrLf & vbCrLf & "Invalid POM Number." & vbCrLf & "The specified POM number is not found in the registered POM numbers list.", MsgBoxStyle.Exclamation)
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
                    txtDocumentName.SelectAll()
                    Exit Sub
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

        hDib = System.IntPtr.Zero
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
            MsgBox("Unable to update Patient's profile." & vbCrLf & "No document image scanned.", MsgBoxStyle.Exclamation)
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
                MsgBox("Unable to process update." & vbCrLf & vbCrLf & "Duplicate Check" & vbCrLf & vbCrLf & "The specified Check Number image already has been added to the Patient's profile.", MsgBoxStyle.Exclamation, "Duplicate Check")
                txtDocumentName.Focus()
                Exit Sub
            End If
            Reader = gSQLGetDataReader("SELECT BillPayments.PaymentID, BillPayments.CheckNumber FROM BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE rtrim(BillPayments.CheckNumber)='" & txtDocumentName.Text.Trim & "' and Bills.PatientID = " & PatientID)
            If Reader.HasRows = False Then
                If gSQLGetSingleValue("SELECT count(*) FROM  BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID WHERE Bills.PatientID = " & PatientID) = 0 Then
                    MsgBox("Unable to process update." & vbCrLf & vbCrLf & "This Check has NOT been added to the Patient's bill payments." & vbCrLf & vbCrLf & "Please inform the Manager ASAP!", MsgBoxStyle.Critical, "Payment Not Found")
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
                MsgBox("Unable to update Patient's profile." & vbCrLf & "The Patient's  Report Related Procedure should be selected.", MsgBoxStyle.Exclamation)
                cboPatientProcedure.Focus()
                Exit Sub
            Else
                If MsgBox("Please confirm the scanned document is " & vbCrLf & CType(cboPatientProcedure.SelectedItem, ValueDescription).Description & " Report?") = MsgBoxResult.No Then
                    cboPatientProcedure.Focus()
                    Exit Sub
                End If
                If Val(CType(cboPatientProcedure.SelectedItem, ValueDescription).Value1) <> 2 Then
                    gSQLUpdateData("Update PatientProcedures set ProcedureStatusID = 2, UpdatedDT=getdate(), UpdatedByEmpID=" & gCurrentEmployee.EmpID & " WHERE PatientProcedureID = " & Val(CType(cboPatientProcedure.SelectedItem, ValueDescription).Value))
                    gUpdate_Profile_Log(PatientID, PatientLogTypes.tScheduleCompleted, "Report Scanned. Procedure Set as Complete.")
                End If
            End If
        End If
        Dim arrImage() As Byte

        arrImage = gSQLReadFileToArray(pdfViewer.Tag)

        Dim Sql As String
        Sql = "INSERT INTO Documents (PatientID, DocumentProfileID, DocumentImage, DocumentName, InsertedBy, InsertedDate, PatientProcedureID) "
        Sql = Sql & " VALUES(@PatientID, @DocumentProfileID, @DocumentImage, @DocumentName, @InsertedBy, @InsertedDate, @PatientProcedureID)"
        Try
            Using adoConnect = New SqlClient.SqlConnection(gConnectionString & "; Connection Timeout=60")
                adoConnect.Open()
                Using cmd = New SqlClient.SqlCommand(Sql, adoConnect)
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
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Exit Sub
        End Try

        Dim TA As SqlClient.SqlDataAdapter
        Dim CB As SqlClient.SqlCommandBuilder
        TA = New SqlClient.SqlDataAdapter("SELECT   * FROM Documents Where 1=2", gConnectionString)
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
        dTab.Dispose() : CB.Dispose() : TA.Dispose()
        Dim NewDocID As Long
        NewDocID = gSQLGetSingleValue("Select IDENT_CURRENT('Documents')")
        If Not LoadListView Is Nothing Then
            Dim LI As ListViewItem = LoadListView.Items.Add(txtDocumentName.Text)
            LI.SubItems.Add(FormatDateTime(Now, DateFormat.ShortDate))
            LI.Tag = NewDocID
            LI.SubItems(1).Tag = DocumentProfileID
            'Dim si = LI.SubItems.Add("+")
            Dim si = LI.SubItems.Add(gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
            si.Tag = arrImage
            LI.Selected = True
            LI.EnsureVisible()
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
                    PatIDS = PatIDS.Mid(3)
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
        hDib = System.IntPtr.Zero
        pdfViewer.Tag = ""

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
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
        'pdfViewer.PrintDocument(me)
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
        'pdfViewer.PrintDocument(me)
    End Sub

    Private Sub ReScanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReScanToolStripMenuItem.Click
        cmdScan_Click(Nothing, Nothing)
    End Sub

    Dim LastSelected As Integer
    Dim SkipProfile As Boolean

    Private Sub ComboBoxCardProfile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDocProfile.SelectedIndexChanged
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
                txtDocumentName.Text = "Denial For Bill #:" & BillID
                txtDocumentName.Enabled = True
            Case Is = 18 ' CD POM
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
        Reader = gSQLGetDataReader("Select * FROM DocumentProfiles WHERE ProfileID = " & DocumentProfileID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            DocSize = CDbl(Reader("DocSize").ToString)
            DocColor = CInt(Val(Reader("DocColor").ToString))
            DocResolution = CInt(Val(Reader("DocResolution").ToString))
            JpegQuality = CInt(Val(Reader("JpegQuality").ToString))
            TrimBorder = Val(Reader("TrimBorder").ToString)
        Loop
        If Val(CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Fld1) > 0 And PatientID > 0 Then
            cboPatientProcedure.Items.Clear()
            SQL = "SELECT     PatientProcedures.PatientProcedureID, Procedures.ProcName, Schedule.ScheduleDateTime, PatientProcedures.ProcedureStatusID "
            SQL &= " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
            SQL &= " WHERE   PatientProcedures.OfficeID=" & gOfficeID & " AND  PatientProcedures.DiagID = " & Val(CType(ComboBoxDocProfile.SelectedItem, ValueDescription).Fld1) & " AND PatientProcedures.ProcedureStatusID<>3 AND PatientProcedures.PAtientID=" & PatientID & " ORDER BY Procedures.ProcName, PatientProcedures.DiagID "
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                cboPatientProcedure.Items.Add(New ValueDescription((Reader("PatientProcedureID").ToString), CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yy") & " " & Reader("ProcName").ToString, Val(Reader("ProcedureStatusID").ToString)))
            Loop
            cboPatientProcedure.Visible = True
            LabelPatientProcedure.Visible = True
        Else
            cboPatientProcedure.Visible = False
            LabelPatientProcedure.Visible = False
        End If

    End Sub

    Private Sub txtDocumentName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocumentName.TextChanged

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
        If hDib <> System.IntPtr.Zero Or pdfViewer.Tag <> "" Then
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