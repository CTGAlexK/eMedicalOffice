Imports System.Reflection
Imports log4net

Public Class frmProperties
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_ScannerImages()
        Load_Printers()
        Load_SysInfo()
        Load_SQLServerInfo()
        Load_Offices()
        Load_DB_Info()
        CheckBoxDebugMode.Checked = gDebugMode
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(0, " OFF"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(30, "30 Min"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(60, "60 Min"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(90, "90 Min"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(120, "2 Hours"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(180, "3 Hours"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(240, "4 Hours"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(300, "5 Hours"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(360, "6 Hours"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(420, "7 Hours"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(480, "8 Hours"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(540, "9 Hours"))
        ComboBoxIdleShutdown.Items.Add(New ValueDescription(600, "10 Hours"))
        gFindComboItemByValue(ComboBoxIdleShutdown, gIdleShutDown, True)
        chkShiftEnvelopeTop.Checked = gEnvelopShiftToCenter
        chkEnvelopeIgonePageSize.Checked = gEnvelopNoPageSize
    End Sub

    Private Sub Load_ScannerImages()
        cboScannerImage.Items.Add(New ValueDescription(1, "Scanner1"))
        cboScannerImage.Items.Add(New ValueDescription(2, "Scanner2"))
        cboScannerImage.Items.Add(New ValueDescription(3, "Scanner3"))
        cboScannerImage.Items.Add(New ValueDescription(4, "Scanner4"))
        cboScannerImage.Items.Add(New ValueDescription(5, "Scanner5"))
        cboScannerImage.Items.Add(New ValueDescription(6, "Scanner6"))
        cboScannerImage.Items.Add(New ValueDescription(7, "Scanner7"))
        cboScannerImage.Items.Add(New ValueDescription(7, "Scanner8"))
        cboScannerImage.Items.Add(New ValueDescription(7, "Scanner9"))
        cboScannerImage.Items.Add(New ValueDescription(7, "Scanner10"))
        cboScannerImage.Items.Add(New ValueDescription(7, "Scanner11"))
        cboScannerImage.Items.Add(New ValueDescription(7, "Scanner12"))
        cboScannerImage.Items.Add(New ValueDescription(7, "Scanner13"))
        cboScannerImage.Items.Add(New ValueDescription(7, "Scanner14"))
        cboScannerImage.SelectedIndex = -1

    End Sub

    Private Sub Load_DB_Info()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("GetDatabaseTablesInfo")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewDB.Items.Add(Reader("TableName").ToString.Trim)
            LI.SubItems.Add(Reader("NRows").ToString.Trim)
            LI.SubItems.Add(gFormatFileSize(Val(Reader("TableSize").ToString.Trim) * 1024))
            If Val(Reader("TableSize").ToString.Trim) * 1024 > 1000 Then
                LI.ForeColor = Color.Green
            End If
            If Val(Reader("TableSize").ToString.Trim) * 1024 > 1000000 Then
                LI.ForeColor = Color.Blue
            End If
            If Val(Reader("TableSize").ToString.Trim) * 1024 > 1000000000 Then
                LI.ForeColor = Color.Red
            End If

        Loop
        Reader.Close() : Reader.Dispose()

    End Sub

    Private Sub Load_Printers()
        Dim P As String
        Try
            For Each P In Printing.PrinterSettings.InstalledPrinters
                ComboBoxLabelPrinter.Items.Add(P)
                ComboBoxNF3Printer.Items.Add(P)
                ComboBoxOtherPrinter.Items.Add(P)
                ComboBoxBillingEnvelope.Items.Add(P)
                ComboBoxLabelOnCD.Items.Add(P)
            Next

            ComboBoxLabelOnCD.Text = gCDLabelPrinter
            ComboBoxLabelPrinter.Text = gPrinterFileLabel
            ComboBoxNF3Printer.Text = gPrinterNF3
            ComboBoxOtherPrinter.Text = gPrinterOtherDocuments
            ComboBoxBillingEnvelope.Text = gPrinterBillingEnvelope
            ComboBoxPrintLabel.SelectedIndex = gPrintPatientLabel
            txtWebFaxAddress.Text = gWebFaxAddress
            chkLeadingOne.Checked = gWebFaxLeadingOne
            cboScannerMode.Items.Add("Use TWAIN Native Driver")
            cboScannerMode.Items.Add("Use Scanner Management Program")
            cboScannerMode.SelectedIndex = gScannerMode
            txtScannerFolder.Text = gScannerFolder
            cboEnvelopPaperType.Items.Add(New ValueDescription(20, "#10 Envelope, 4 1/8- by 9 1/2-inches"))
            cboEnvelopPaperType.Items.Add(New ValueDescription(261, "Post Card Large"))

            gFindComboItemByValue(cboEnvelopPaperType, gEnvelopPaperType, True)
            cboCDEnvelopeLabel.Items.Add(New ValueDescription(0, "DK-1201 1.1 x 3.5(1-1/7 x 3-1/2)"))
            cboCDEnvelopeLabel.Items.Add(New ValueDescription(1, "DK-2205 2.4 x Cont(2-3/7 - Cont)"))
            cboCDEnvelopeLabel.Items.Add(New ValueDescription(2, "DK-1209 1.1 x 2.4(1-1/7 x 2-3/7)"))
            gFindComboItemByValue(cboCDEnvelopeLabel, gCDEnvelopeLabelType, True)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Load Printers")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Load_Offices()
        txtOffice.Text = gOfficeName
        'Dim Reader As SqlClient.SqlDataReader
        'Reader = gSQLGetDataReader("Select * from Offices Where ActiveInd=1 Order By OfficeName")
        'If Reader Is Nothing Then Exit Sub
        'Do Until Reader.Read = False
        '    ComboBoxOffice.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)), Reader("OfficeName").ToString, Reader("Email").ToString))
        'Loop
        'Reader.Close() : Reader.Dispose()
        'gFindComboItemByValue(ComboBoxOffice, gOfficeID, True)
        'ComboBoxOffice.Tag = gOfficeID
    End Sub

    Private Sub Load_SysInfo()
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title & " Radiology Edition"
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version: {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = "Copyright: " & My.Application.Info.Copyright
        Me.LabelCompanyName.Text = "Company: " & My.Application.Info.CompanyName
    End Sub

    Private Sub Load_SQLServerInfo()
        txtSQLServer.Text = gSqlServerName
        txtSQLServerDatabaseName.Text = gSQLServerDatabase
        txtSQLServerUID.Text = gSQLServerUID
        txtSQLServerPassword.Text = gSQLServerPassword

        txtPACSSQLServer.Text = gPACSSQLServerName
        txtPACSSQLServerDatabaseName.Text = gPACSSQLServerDatabase
        txtPACSSQLServerUID.Text = gPACSSQLServerUID
        txtPACSSQLServerPassword.Text = gPACSSQLServerPassword
        txtPACSPath.Text = gPACSPath
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Try
            If Update_Data() = True Then
                DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Function Update_Data() As Boolean
        'SQL Server
        Dim Restart As Boolean
        Dim lConnectionString As String
        txtSQLServer.Text = txtSQLServer.Text.Trim.ToString
        txtSQLServerDatabaseName.Text = txtSQLServerDatabaseName.Text.Trim.ToString
        txtSQLServerUID.Text = txtSQLServerUID.Text.Trim.ToString
        txtSQLServerPassword.Text = txtSQLServerPassword.Text.Trim.ToString
        txtPACSSQLServer.Text = txtPACSSQLServer.Text.Trim.ToString
        txtPACSSQLServerDatabaseName.Text = txtPACSSQLServerDatabaseName.Text.Trim.ToString
        txtPACSSQLServerUID.Text = txtPACSSQLServerUID.Text.Trim.ToString
        txtPACSSQLServerPassword.Text = txtPACSSQLServerPassword.Text.Trim.ToString

        'If ComboBoxOffice.SelectedIndex = -1 Then
        '    TabControl1.SelectedIndex = 0
        '    ErrorProvider1.SetError(ComboBoxOffice, "Incomplete Setup Information. The current office should be selected.")
        '    MsgBox("Incomplete Setup Information. The current office should be selected.", MsgBoxStyle.Exclamation)
        '    ComboBoxOffice.Focus()
        '    Exit Function
        'End If

        If CheckBoxDebugMode.Checked Then
            TabControl1.SelectedIndex = 0
            If MsgBox("Attention." & vbCrLf & vbCrLf & "The system in debug mode." & vbCrLf & vbCrLf & "Continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Function
            End If
        End If

        If txtSQLServer.Text = "" Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(txtSQLServer, "Incomplete Setup Information. The SQL Server Name is required.")
            MsgBox("Incomplete Setup Information. The SQL Server Name is required.", MsgBoxStyle.Exclamation)
            txtSQLServer.Focus()
            Exit Function
        End If
        If txtSQLServerDatabaseName.Text = "" Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(txtSQLServerDatabaseName, "Incomplete Setup Information. The SQL Server Database Name is required.")
            MsgBox("Incomplete Setup Information. The SQL Server Database Name is required.", MsgBoxStyle.Exclamation)
            txtSQLServerDatabaseName.Focus()
            Exit Function
        End If
        If txtSQLServerUID.Text = "" Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(txtSQLServerUID, "Incomplete Setup Information. The SQL Server User ID is required.")
            MsgBox("Incomplete Setup Information. The SQL Server User ID is required.", MsgBoxStyle.Exclamation)
            txtSQLServerUID.Focus()
            Exit Function
        End If
        lConnectionString = "Server=" & txtSQLServer.Text & ";Database=" & txtSQLServerDatabaseName.Text & ";User ID=" & txtSQLServerUID.Text & ";Password=" & txtSQLServerPassword.Text & ";Trusted_Connection=False"
        Application.DoEvents()
        If gValidateConnection(lConnectionString) = False Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(txtSQLServer, "Invalid Database Information.")
            ErrorProvider1.SetError(txtSQLServerDatabaseName, "Invalid Database Information.")
            ErrorProvider1.SetError(txtSQLServerUID, "Invalid Database Information.")
            ErrorProvider1.SetError(txtSQLServerPassword, "Invalid Database Information.")

            Exit Function
        End If
        If ComboBoxPrintLabel.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 2
            ErrorProvider1.SetError(ComboBoxPrintLabel, "Value should be selected.")
            MsgBox("Incomplete Setup Information. Value should be selected.", MsgBoxStyle.Exclamation)
            ComboBoxPrintLabel.Focus()
            Exit Function
        End If

        If ComboBoxLabelPrinter.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 2
            ErrorProvider1.SetError(ComboBoxLabelPrinter, "Label Printer Should be selected.")
            MsgBox("Incomplete Setup Information. Label Printer Should be selected.", MsgBoxStyle.Exclamation)
            ComboBoxLabelPrinter.Focus()
            Exit Function
        End If

        If ComboBoxLabelPrinter.SelectedIndex > -1 Then
            Dim objPrint As New System.Drawing.Printing.PrinterSettings
            Dim strPrinters As String
            Dim printerformat As System.Drawing.Printing.PaperSize

            For Each printer As String In objPrint.InstalledPrinters

                If printer = ComboBoxLabelPrinter.Text Then

                    Dim PrinterObj As New System.Drawing.Printing.PrinterSettings()
                    PrinterObj.PrinterName = printer
                    If PrinterObj.DefaultPageSettings.PaperSize.Width > 500 And PrinterObj.DefaultPageSettings.PaperSize.Height > 600 Then
                        TabControl1.SelectedIndex = 2
                        ErrorProvider1.SetError(ComboBoxLabelPrinter, "The selected File Label Default Printer does not looks like a label printer." & vbCrLf & "Most Likely it should be a Brother Label printer.")
                        If MsgBox("The selected File Label Default Printer does not looks like a label printer." & vbCrLf & vbCrLf & "Most Likely it should be a Brother Label printer." & vbCrLf & vbCrLf & "The selected printer paper size:   " & PrinterObj.DefaultPageSettings.PaperSize.Width / 100 & Chr(34) & " X " & PrinterObj.DefaultPageSettings.PaperSize.Height / 100 & Chr(34) & vbCrLf & vbCrLf & "Would you like to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            ComboBoxLabelPrinter.Focus()
                            Exit Function
                        End If
                        ErrorProvider1.SetError(ComboBoxLabelPrinter, "")
                    End If
                End If
            Next
        End If

        'cboCDEnvelopeLabel

        If ComboBoxNF3Printer.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 2
            ErrorProvider1.SetError(ComboBoxNF3Printer, "NF3 Form Printer Should be selected.")
            MsgBox("Incomplete Setup Information. NF3 Form Printer Should be selected.", MsgBoxStyle.Exclamation)
            ComboBoxNF3Printer.Focus()
            Exit Function
        End If

        If ComboBoxBillingEnvelope.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 2
            ErrorProvider1.SetError(ComboBoxBillingEnvelope, "Billing Envelope Printer Should be selected.")
            MsgBox("Incomplete Setup Information. Billing Envelope Printer Should be selected.", MsgBoxStyle.Exclamation)
            ComboBoxBillingEnvelope.Focus()
            Exit Function
        End If
        If cboEnvelopPaperType.SelectedIndex = -1 Then
            cboEnvelopPaperType.SelectedIndex = 0
        End If

        If ComboBoxBillingEnvelope.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 2
            ErrorProvider1.SetError(ComboBoxBillingEnvelope, "Other Documents Printer Should be selected.")
            MsgBox("Incomplete Setup Information. Other Documents Printer Should be selected.", MsgBoxStyle.Exclamation)
            ComboBoxBillingEnvelope.Focus()
            Exit Function
        End If
        If cboScannerMode.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 2
            ErrorProvider1.SetError(ComboBoxBillingEnvelope, "Scanner Mode Should be selected.")
            MsgBox("Incomplete Setup Information. Scanner Mode Should be selected.", MsgBoxStyle.Exclamation)
            cboScannerMode.Focus()
            Exit Function
        End If

        If cboScannerMode.SelectedIndex = 1 Then
            If txtScannerFolder.Text.Trim = "" Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ButtonSelectScannerFolder, "Scanner Output Folder should be specified.")
                MsgBox("Incomplete Setup Information. Scanner Output Folder should be specified", MsgBoxStyle.Exclamation)
                ButtonSelectScannerFolder.Focus()
                Exit Function
            End If
            If cboScannerImage.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ComboBoxBillingEnvelope, "Scanner Image should be specified.")
                MsgBox("Incomplete Setup Information. Scanner Image should be specified", MsgBoxStyle.Exclamation)
                cboScannerImage.Focus()
                Exit Function
            End If
        End If
        Dim CDB As String
        Dim clsBurn As CDBurnClass
        Try
            clsBurn = New CDBurnClass
            CDB = clsBurn.Check_CDBurner()
        Catch ex As Exception
            CDB = "No CD Burner Detected."
        End Try
        If CDB = "" Then
            If txtPACSSQLServer.Text <> "" Or txtPACSSQLServerDatabaseName.Text <> "" Or txtPACSSQLServerUID.Text <> "" Or (Dir(txtPACSPath.Text, FileAttribute.Directory) <> "" And txtPACSPath.Text <> "") Then
                If txtPACSSQLServer.Text = "" Then
                    TabControl1.SelectedIndex = 3
                    ErrorProvider1.SetError(txtPACSSQLServer, "Incomplete CD Burner Setup Information. The PACS SQL Server Name is required.")
                    MsgBox("Incomplete CD Burner Setup Information. The PACS SQL Server Name is required.", MsgBoxStyle.Exclamation)
                    txtPACSSQLServer.Focus()
                    Exit Function
                End If
                If txtPACSSQLServerDatabaseName.Text = "" Then
                    TabControl1.SelectedIndex = 3
                    ErrorProvider1.SetError(txtPACSSQLServerDatabaseName, "Incomplete CD Burner Setup Information. The PACS Database Name is required.")
                    MsgBox("Incomplete CD Burner Setup Information. The PACS Database Name is required.", MsgBoxStyle.Exclamation)
                    txtPACSSQLServerDatabaseName.Focus()
                    Exit Function
                End If
                If txtPACSSQLServerUID.Text = "" Then
                    TabControl1.SelectedIndex = 3
                    ErrorProvider1.SetError(txtPACSSQLServerUID, "Incomplete CD Burner Setup Information. The PACS Database User ID is required.")
                    MsgBox("Incomplete CD Burner Setup Information. The PACS Database User ID is required.", MsgBoxStyle.Exclamation)
                    txtPACSSQLServerUID.Focus()
                    Exit Function
                End If
                lConnectionString = "Server=" & txtPACSSQLServer.Text & ";Database=" & txtPACSSQLServerDatabaseName.Text & ";User ID=" & txtPACSSQLServerUID.Text & ";Password=" & txtPACSSQLServerPassword.Text & ";Trusted_Connection=False"
                Application.DoEvents()
                If gValidateConnection(lConnectionString) = False Then
                    TabControl1.SelectedIndex = 3
                    ErrorProvider1.SetError(txtPACSSQLServer, "Invalid PACS Database Information.")
                    ErrorProvider1.SetError(txtPACSSQLServerDatabaseName, "Invalid PACS Database Information.")
                    ErrorProvider1.SetError(txtPACSSQLServerUID, "Invalid PACS Database Information.")
                    ErrorProvider1.SetError(txtPACSSQLServerPassword, "Invalid PACS Database Information.")
                    Exit Function
                End If
                gPACSSQLServerName = txtPACSSQLServer.Text
                gPACSSQLServerDatabase = txtPACSSQLServerDatabaseName.Text
                gPACSSQLServerUID = txtPACSSQLServerUID.Text
                gPACSSQLServerPassword = txtPACSSQLServerPassword.Text

                gPACSPath = txtPACSPath.Text
                If gPACSSQLServerName <> "" And gPACSSQLServerDatabase <> "" And gPACSSQLServerUID <> "" Then
                    gPacsConnectionString = "Server=" & gPACSSQLServerName & ";Database=" & gPACSSQLServerDatabase & ";User ID=" & gPACSSQLServerUID & ";Password=" & gPACSSQLServerPassword & ";Trusted_Connection=False; Max Pool Size=500"
                Else
                    gPacsConnectionString = ""
                End If
            Else
                gPACSSQLServerName = txtPACSSQLServer.Text
                gPACSSQLServerDatabase = txtPACSSQLServerDatabaseName.Text
                gPACSSQLServerUID = txtPACSSQLServerUID.Text
                gPACSSQLServerPassword = txtPACSSQLServerPassword.Text
            End If
        Else
            gPacsConnectionString = ""
            MsgBox("Attention." & vbCrLf & "Image CDs Recording functionality will be disabled." & vbCrLf & CDB, MsgBoxStyle.Information)
        End If
        gIdleShutDown = CType(ComboBoxIdleShutdown.SelectedItem, ValueDescription).Value
        gScannerMode = cboScannerMode.SelectedIndex
        gScannerFolder = txtScannerFolder.Text
        gDebugMode = CheckBoxDebugMode.Checked
        gScannerImageIndex = cboScannerImage.SelectedIndex
        gPrintPatientLabel = ComboBoxPrintLabel.SelectedIndex
        gPrinterFileLabel = CheckPrinter(ComboBoxLabelPrinter.Text)
        gPrinterNF3 = CheckPrinter(ComboBoxNF3Printer.Text)
        gPrinterOtherDocuments = CheckPrinter(ComboBoxOtherPrinter.Text)
        gPrinterBillingEnvelope = CheckPrinter(ComboBoxBillingEnvelope.Text)
        gCDLabelPrinter = CheckPrinter(ComboBoxLabelOnCD.Text)
        gWebFaxAddress = txtWebFaxAddress.Text
        gWebFaxLeadingOne = chkLeadingOne.Checked
        gEnvelopPaperType = CType(cboEnvelopPaperType.SelectedItem, ValueDescription).Value
        gCDEnvelopeLabelType = CType(cboCDEnvelopeLabel.SelectedItem, ValueDescription).Value
        gEnvelopShiftToCenter = chkShiftEnvelopeTop.Checked
        gEnvelopNoPageSize = chkEnvelopeIgonePageSize.Checked
        'If gOfficeID <> CType(ComboBoxOffice.SelectedItem, ValueDescription).Value.ToString Then gRestart = True
        If gSqlServerName <> txtSQLServer.Text Then gRestart = True
        If gSQLServerUID <> txtSQLServerUID.Text Then gRestart = True

        'gOfficeName = ComboBoxOffice.Text
        'gOfficeID = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value.ToString
        'gOfficeEmail = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value1.ToString
        MDIForm1Win8.lblOffice.Text = " " & gOfficeName & "    "
        Cursor = Cursors.Default
        gSqlServerName = txtSQLServer.Text
        gSQLServerDatabase = txtSQLServerDatabaseName.Text
        gSQLServerUID = txtSQLServerUID.Text
        gSQLServerPassword = txtSQLServerPassword.Text
        If gSqlServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
            gConnectionString = "Server=" & gSqlServerName & ";Database=" & gSQLServerDatabase & ";User ID=" & gSQLServerUID & ";Password=" & gSQLServerPassword & ";Trusted_Connection=False; Max Pool Size=500"
        End If
        gSettings(ReadWrite.sWrite)
        Update_Data = True
    End Function

    Private Sub txtSQLServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLServer.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub txtSQLServerUID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLServerUID.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub txtSQLServerDatabaseName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLServerDatabaseName.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub txtSQLServerPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLServerPassword.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub cboScannerMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScannerMode.SelectedIndexChanged
        If cboScannerMode.SelectedIndex = 1 Then
            PanelScanner.Enabled = True
            cboScannerImage.Enabled = True
            If gScannerImageIndex = -1 Then
                cboScannerImage.SelectedIndex = 1
            Else
                cboScannerImage.SelectedIndex = gScannerImageIndex
            End If
        Else
            PanelScanner.Enabled = False
            cboScannerImage.Enabled = False
            cboScannerImage.SelectedIndex = -1
        End If
    End Sub

    Private Sub ButtonSelectScannerFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelectScannerFolder.Click

        If txtScannerFolder.Text <> "" AndAlso IO.Directory.Exists(txtScannerFolder.Text) Then
            FolderBrowserDialog1.SelectedPath = txtScannerFolder.Text
        End If
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtScannerFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub txtScannerFolder_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScannerFolder.DoubleClick
        ButtonSelectScannerFolder_Click(Nothing, Nothing)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Shell("MSINFO32.EXE", AppWinStyle.NormalFocus)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtPACSPath.Text <> "" AndAlso IO.Directory.Exists(txtPACSPath.Text) Then
            FolderBrowserDialog1.SelectedPath = txtPACSPath.Text
        End If
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPACSPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DisplayMapDriveDialog(Me.Handle)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSupervisorApproval.LabelMsg.Text = "Delete License Information from the current workstation." & vbCrLf & vbCrLf & "System restart is required."
        If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
            frmSupervisorApproval.Dispose()
            Exit Sub
        End If
        frmSupervisorApproval.Dispose()
        gRestart = True
        gSettings(ReadWrite.sWrite)
    End Sub

    Private Sub PictureBoxScanner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxScanner.Click

    End Sub

    Private Sub cboScannerImage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScannerImage.SelectedIndexChanged
        Select Case cboScannerImage.SelectedIndex
            Case -1
                PictureBoxScanner.Image = Nothing
            Case 0
                PictureBoxScanner.Image = My.Resources.Scanner1
            Case 1
                PictureBoxScanner.Image = My.Resources.Scanner2
            Case 2
                PictureBoxScanner.Image = My.Resources.Scanner3
            Case 3
                PictureBoxScanner.Image = My.Resources.Scanner4
            Case 4
                PictureBoxScanner.Image = My.Resources.Scanner5
            Case 5
                PictureBoxScanner.Image = My.Resources.Scanner6
            Case 6
                PictureBoxScanner.Image = My.Resources.Scanner7
            Case 7
                PictureBoxScanner.Image = My.Resources.Scanner8
            Case 8
                PictureBoxScanner.Image = My.Resources.Scanner9
            Case 9
                PictureBoxScanner.Image = My.Resources.Scanner10
            Case 10
                PictureBoxScanner.Image = My.Resources.Scanner11
            Case 11
                PictureBoxScanner.Image = My.Resources.Scanner12
            Case 12
                PictureBoxScanner.Image = My.Resources.Scanner13
            Case 13
                PictureBoxScanner.Image = My.Resources.Scanner14
            Case 14
                PictureBoxScanner.Image = My.Resources.Scanner15
        End Select
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim msg As String
        msg = "Warning!" & vbCrLf & vbCrLf
        msg &= "This actions will remove database connection settings from the current computer and cannot be undone!" & vbCrLf & vbCrLf
        msg &= "After procedure completed eMedicalOffice will be terminated and new eMedicalOffice setup configuration will be required." & vbCrLf & vbCrLf
        msg &= "Please confirm you want to remove eMedicalOffice settings?"
        If MsgBox(msg, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Return
        End If

        frmSupervisorApproval.LabelMsg.Text = "Delete the System Registration from the current workstation." & vbCrLf & vbCrLf & "System restart will be required."
        If frmSupervisorApproval.ShowDialog <> DialogResult.OK Then
            frmSupervisorApproval.Dispose()
            Exit Sub
        End If
        frmSupervisorApproval.Dispose()
        gRestart = True
        On Error Resume Next
        DeleteSetting(My.Application.Info.ProductName)
        gAppConfig.DeleteSetting("SQLServerName")
        gAppConfig.DeleteSetting("SQLServerDatabase")
        gAppConfig.DeleteSetting("SQLServerUID")
        gAppConfig.DeleteSetting("SQLServerPassword")
        gAppConfig.DeleteSetting("OfficeID")
        gAppConfig.DeleteSetting("OfficeName")
        gAppConfig.DeleteSetting("MultiOfficeMode")
        If gOffices.Count > 0 Then
            For Each o As Office In gOffices
                gAppConfig.DeleteSetting("SQLServerName_" & o.OfficeID)
                gAppConfig.DeleteSetting("SQLServerDatabase_" & o.OfficeID)
                gAppConfig.DeleteSetting("SQLServerUID_" & o.OfficeID)
                gAppConfig.DeleteSetting("SQLServerPassword_" & o.OfficeID)
                gAppConfig.DeleteSetting("OfficeID_" & o.OfficeID)
                gAppConfig.DeleteSetting("OfficeName_" & o.OfficeID)
            Next
        End If
        End
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckBoxDebugMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxDebugMode.CheckedChanged
        CheckBoxDebugMode.ForeColor = IIf(CheckBoxDebugMode.Checked, Color.Red, Color.Black)
    End Sub

    Private Sub ComboBoxLabelPrinter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxLabelPrinter.SelectedIndexChanged
        Try
            ErrorProvider1.SetError(ComboBoxLabelPrinter, "")
            If ComboBoxLabelPrinter.SelectedIndex > -1 Then
                Dim objPrint As New System.Drawing.Printing.PrinterSettings
                Dim strPrinters As String
                Dim printerformat As System.Drawing.Printing.PaperSize

                For Each printer As String In objPrint.InstalledPrinters

                    Try
                        If printer = ComboBoxLabelPrinter.Text Then

                            Dim PrinterObj As New Printing.PrinterSettings()
                            PrinterObj.PrinterName = printer
                            If PrinterObj.DefaultPageSettings.PaperSize.Width > 500 And PrinterObj.DefaultPageSettings.PaperSize.Height > 600 Then
                                ErrorProvider1.SetError(ComboBoxLabelPrinter, "The selected File Label Default Printer does not looks like a label printer." & vbCrLf & "Most Likely it should be a Brother Label printer.")
                                If ComboBoxLabelPrinter.CanFocus Then
                                    MsgBox("The selected File Label Default Printer does not looks like a label printer." & vbCrLf & vbCrLf & "The selected printer paper size:   " & PrinterObj.DefaultPageSettings.PaperSize.Width / 100 & Chr(34) & " X " & PrinterObj.DefaultPageSettings.PaperSize.Height / 100 & Chr(34) & vbCrLf & vbCrLf & "Please check the selected printer specifications.", MsgBoxStyle.Exclamation)
                                End If
                            End If
                        End If
                    Catch ex As Exception

                    End Try

                Next
            End If
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Load Printers")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ComboBoxOtherPrinter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxOtherPrinter.SelectedIndexChanged

    End Sub

    Private Sub Label31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label31.Click

    End Sub

    Private Sub ComboBoxBillingEnvelope_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxBillingEnvelope.SelectedIndexChanged

    End Sub

    Private Sub Label34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label34.Click

    End Sub

    Private Sub cboEnvelopPaperType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEnvelopPaperType.SelectedIndexChanged

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub cboCDEnvelopeLabel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCDEnvelopeLabel.SelectedIndexChanged
        Select Case cboCDEnvelopeLabel.SelectedIndex
            Case 0
                PictureBoxLabel.Image = My.Resources.DK1201
            Case 1
                PictureBoxLabel.Image = My.Resources.DK2205
            Case 2
                PictureBoxLabel.Image = My.Resources.DK1209
            Case Else
                PictureBoxLabel.Image = Nothing

        End Select

    End Sub

    Private Sub chkEnvelopeIgonePageSize_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnvelopeIgonePageSize.CheckedChanged
        If chkEnvelopeIgonePageSize.Checked Then
            chkEnvelopeIgonePageSize.ForeColor = Color.Red
        Else
            chkEnvelopeIgonePageSize.ForeColor = Color.Black
        End If
    End Sub
End Class