Imports System.Reflection
Imports log4net

Public Class frmOfficeMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode
    Private ExamTab As TabPage

    Private Sub Load_Offices()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem

        Reader = gSQLGetDataReader("Select * from Offices where officeid = " & gOfficeID & " Order by OfficeName ")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewOffices.Items.Add(Reader("OfficeName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
            LI.Tag = Reader("OfficeID").ToString
            If Val(Reader("OfficeID").ToString) = gOfficeID Then
                LI.BackColor = Color.LightGreen
            End If
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewOffices.Items.Count > 0 Then
            ListViewOffices.Items(0).Selected = True
            ListViewOffices.Items(0).EnsureVisible()
            ' ListView1_SelectedIndexChanged(Nothing, Nothing)
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
        End If
    End Sub

    Private Sub load_spread_Emails()
        Dim Reader As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Reader = gSQLGetDataReader("SELECT EmpID, isnull(Fname,'')+''+isnull(Lname,'') + '   ['+eMail +']' as Empl, eMail FROM Employees WHERE (eMail <> '') ORDER BY EmpID, Fname, MI, Lname")
        If Reader Is Nothing Then Exit Sub
        Dim Arlst As New ArrayList
        Dim ArlstData As New ArrayList

        Do Until Reader.Read = False
            Arlst.Add(Reader("Empl").ToString)
            ArlstData.Add(Reader("eMail").ToString)
        Loop
        cmbocell.Items = Arlst.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell.Editable = True
        cmbocell.MaxDrop = 12
        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
        Reader.Close() : Reader.Dispose()

    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim I As Integer

        load_spread_Emails()

        Reader = gSQLGetDataReader("SELECT     Employees.EmpID, Employees.Fname + ' ' + Employees.Lname + ' ' + Employees.Alias AS EmpName FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE EmployeeOffice.OfficeID = " & gOfficeID & " AND Employees.BillingPrv = 1 ORDER BY EmpName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboNF2MainBillingProviderID.Items.Add(New ValueDescription(Reader("EmpID").ToString, Reader("EmpName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()

        Reader = gSQLGetDataReader("SELECT OfficeTypeID, Description FROM OfficeTypes order by OfficeTypeID")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboOfficeType.Items.Add(New ValueDescription(Reader("OfficeTypeID").ToString, Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()

        Reader = gSQLGetDataReader("Select DISTINCT State, ShowOrder from States Order by ShowOrder")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxState.Items.Add(Reader("State").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        Reader = gSQLGetDataReader("Select TwilioMessageTypeId, Description from OfficeTwilioMessageTypes Order by TwilioMessageTypeId")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboMessageType.Items.Add(New ValueDescription(Reader("TwilioMessageTypeId").ToString, Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()

        Reader = gSQLGetDataReader("Select DiagName, DiagID from Diagnostics Order by DiagName")
        If Reader Is Nothing Then Exit Sub

        Dim Arlst As New ArrayList
        Dim ArlstData As New ArrayList

        Do Until Reader.Read = False
            Arlst.Add(Reader("DiagName").ToString)
            ArlstData.Add(Reader("DiagID").ToString)
        Loop
        cmbocell.Items = Arlst.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 10
        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
        FpSpread1.ActiveSheet.Columns(0).CellType = cmbocell
        Reader.Close() : Reader.Dispose()
        For I = 0 To FpSpread1.ActiveSheet.Rows.Count - 1
            FpSpread1.ActiveSheet.Rows(I).BackColor = Color.WhiteSmoke
        Next
        For I = 0 To 23
            ComboBoxStartTime.Items.Add(New ValueDescription(I, CDate(I & ":00").ToString("hh tt")))
        Next
        For I = 1 To 24
            ComboBoxDayHours.Items.Add(New ValueDescription(I, I & " Hours"))
        Next
        For I = 1 To 14
            ComboBoxAttorneyNoConfirmationAge.Items.Add(New ValueDescription(I, I & " Days"))
            ComboBoxBillingRequestWarningAge.Items.Add(New ValueDescription(I, I & " Days"))
        Next

        ComboBoxInterval.Items.Add(New ValueDescription(5, "5 Minutes"))
        ComboBoxInterval.Items.Add(New ValueDescription(10, "10 Minutes"))
        ComboBoxInterval.Items.Add(New ValueDescription(15, "15 Minutes"))
        ComboBoxInterval.Items.Add(New ValueDescription(20, "20 Minutes"))
        ComboBoxInterval.Items.Add(New ValueDescription(30, "30 Minutes"))
        ComboBoxInterval.Items.Add(New ValueDescription(60, "60 Minutes"))

        ComboBoxPatients.Items.Add(New ValueDescription(1, "1 Paitients"))
        ComboBoxPatients.Items.Add(New ValueDescription(2, "2 Paitients"))
        ComboBoxPatients.Items.Add(New ValueDescription(3, "3 Paitients"))
        ComboBoxPatients.Items.Add(New ValueDescription(4, "4 Paitients"))
        ComboBoxPatients.Items.Add(New ValueDescription(5, "5 Paitients"))
        ComboBoxPatients.Items.Add(New ValueDescription(6, "6 Paitients"))
        ComboBoxPatients.Items.Add(New ValueDescription(7, "7 Paitients"))
        ComboBoxPatients.Items.Add(New ValueDescription(8, "8 Paitients"))
        ComboBoxPatients.Items.Add(New ValueDescription(9, "9 Paitients"))
        ComboBoxPatients.Items.Add(New ValueDescription(10, "10 Paitients"))

        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(-1, "Unlimited"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(1, "1 Procedure"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(2, "2 Procedures"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(3, "3 Procedures"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(4, "4 Procedures"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(5, "5 Procedures"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(6, "6 Procedures"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(7, "7 Procedures"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(8, "8 Procedures"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(9, "9 Procedures"))
        ComboBoxProcsPerVisit.Items.Add(New ValueDescription(10, "10 Procedures"))
        For I = 1 To 180
            ComboBoxDOAAge.Items.Add(New ValueDescription(I, I))
        Next

        ComboBoxNoShowHours.Items.Add(New ValueDescription(1, "1"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(2, "2"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(3, "3"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(4, "4"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(5, "5"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(6, "6"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(7, "7"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(8, "8"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(9, "9"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(10, "10"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(11, "11"))
        ComboBoxNoShowHours.Items.Add(New ValueDescription(12, "12"))

        For I = 1 To 90
            ComboBoxBillingMinDays.Items.Add(I)
            ComboBoxBillingMaxDays.Items.Add(I)
            ComboBoxNF2MaxAge.Items.Add(I)
            ComboBoxNF2MinAge.Items.Add(I)

        Next
        For I = 1 To 30
            ComboBoxMRIDays.Items.Add(I)
            ComboBoxCancelationWarning.Items.Add(I)
            ComboBoxCancelationDrop.Items.Add(I)
        Next

        For I = 1 To 21
            ComboBoxMinAge.Items.Add(I)
            ComboBoxUnderAge.Items.Add(I)
            ComboBoxMinNoFaultDays.Items.Add(I)
        Next

        For I = 0 To 100
            ComboBoxCashDiscountPct.Items.Add(I)
        Next
        For I = 0 To 300 Step 5
            ComboBoxImageDiskPriceForInsuranceCompany.Items.Add(New ValueDescription(I, "$" & I & ".00"))
            ComboBoxImageDiskPriceForMedicalOffice.Items.Add(New ValueDescription(I, "$" & I & ".00"))
            ComboBoxImageDiskPriceCash.Items.Add(New ValueDescription(I, "$" & I & ".00"))
        Next
        For I = 0 To 180 Step 10
            ComboBoxIdleTime.Items.Add(New ValueDescription(I, I & " Sec."))
        Next

        ComboBoxNFDefaultBillingCompany.Items.Clear()
        ComboBoxWCDefaultBillingCompany.Items.Clear()
        ComboBoxPrivateDefaultBillingCompany.Items.Clear()
        Reader = gSQLGetDataReader("SELECT     BillingCompanyID, CompanyName FROM BillingCompanies ORDER BY CompanyName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxNFDefaultBillingCompany.Items.Add(New ValueDescription(CLng(Val(Reader("BillingCompanyID").ToString)), Reader("CompanyName").ToString))
            ComboBoxWCDefaultBillingCompany.Items.Add(New ValueDescription(CLng(Val(Reader("BillingCompanyID").ToString)), Reader("CompanyName").ToString))
            ComboBoxPrivateDefaultBillingCompany.Items.Add(New ValueDescription(CLng(Val(Reader("BillingCompanyID").ToString)), Reader("CompanyName").ToString))

        Loop
        Reader.Close() : Reader.Dispose()

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewOffices.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ListViewOffices.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        If ListViewOffices.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Clear_Controls()
        cmdEdit.Enabled = True
        cmdDelete.Enabled = True
        ID = CLng(ListViewOffices.SelectedItems(0).Tag)
        SaveSelectedItem = ListViewOffices.SelectedItems(0)
        Reader = gSQLGetDataReader("Select * from Offices Where OfficeID=" & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False

            CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
            txtOfficeName.Text = "" & Reader("OfficeName").ToString
            txtMRNAbbreviation.Text = "" & Reader("MRNAbbreviation").ToString
            gFindComboItemByValue(cboOfficeType, CLng(Reader("OfficeTypeID").ToString), True)
            cboOfficeType.Tag = CLng(Reader("OfficeTypeID").ToString)
            ComboBoxNF2MinAge.Text = Val(Reader("NF2MinAge").ToString)
            ComboBoxNF2MaxAge.Text = Val(Reader("NF2MaxAge").ToString)

            txtAddress1.Text = "" & Reader("Address1").ToString
            txtAddress2.Text = "" & Reader("Address2").ToString
            txtCity.Text = "" & Reader("City").ToString
            ComboBoxState.Text = "" & Reader("State").ToString
            txtZip.Text = "" & Reader("Zip").ToString
            txtPhone1.Text = "" & Reader("Phone1").ToString
            txtPhone2.Text = "" & Reader("Phone2").ToString
            txtFax1.Text = "" & Reader("Fax1").ToString
            txtFax2.Text = "" & Reader("Fax2").ToString
            txtEmail.Text = "" & Reader("eMail").ToString
            txtWebAddress.Text = "" & Reader("WebAddress").ToString
            txtSMTPUID.Text = Reader("SMTPUID").ToString
            txtSMTPPWD.Text = Reader("SMTPPWD").ToString
            txtSMTPPWDConf.Text = Reader("SMTPPWD").ToString
            txtSMTPHost.Text = Reader("SMTPHost").ToString
            txtSMTPPort.Text = Val(Reader("SMTPPort").ToString)
            txtSMTPFromAddress.Text = Reader("SMTPFromAddress").ToString
            chkSMPTAsync.Checked = Val(Reader("SMTPSendAsync").ToString)
            chkCheckAddress.Checked = Val(Reader("CheckAddress").ToString)
            ComboBoxStartTime.Text = CDate(Reader("StartTime").ToString & ":00").ToString("hh tt")
            If IsColumnExist(Reader, "TwilioFromPhoneNumber") Then
                txtTwilioFromPhoneNumber.Text = Reader("TwilioFromPhoneNumber").ToString
                txtTwilioAccountSid.Text = Reader("TwilioAccountSid").ToString
                txtTwilioAuthToken.Text = Reader("TwilioAuthToken").ToString
                txtTwilioBin.Text = Reader("TwilioBin").ToString
                gFindComboItemByValue(cboMessageType, CLng("0" & Reader("TwilioMessageTypeId")), True)
            End If

            gFindComboItemByValue(cboNF2MainBillingProviderID, Val(Reader("NF2MainBillingProviderID").ToString), True)

            gFindComboItemByValue(ComboBoxDayHours, CLng(Reader("WorkDayHours").ToString), True)
            gFindComboItemByValue(ComboBoxInterval, CLng(Reader("SplitInterval").ToString), True)
            gFindComboItemByValue(ComboBoxPatients, CLng(Reader("NumberPatientsPerInterval").ToString), True)
            gFindComboItemByValue(ComboBoxProcsPerVisit, CLng(Reader("ProcsPerVisit").ToString), True)
            gFindComboItemByValue(ComboBoxDOAAge, CLng(Reader("DOAAge").ToString), True)
            gFindComboItemByValue(ComboBoxNoShowHours, CLng(Reader("NoShowHours").ToString), True)
            gFindComboItemByValue(ComboBoxAttorneyNoConfirmationAge, CLng(Reader("AttorneyNoConfirmationAge")), True)
            gFindComboItemByValue(ComboBoxBillingRequestWarningAge, CLng(Reader("BillingRequestWarningAge")), True)
            lblNF3Template.Text = "NF3 Template " & Val(Reader("NF3Template").ToString)

            ComboBoxBillingMinDays.Text = Val(Reader("BillingMinDays").ToString)
            ComboBoxBillingMaxDays.Text = Val(Reader("BillingMaxDays").ToString)

            ComboBoxImageDiskPriceForInsuranceCompany.Text = "$" & Val(Reader("ImageDiskPriceForInsuranceCompany").ToString) & ".00"
            ComboBoxImageDiskPriceForMedicalOffice.Text = "$" & Val(Reader("ImageDiskPriceForMedicalOffice").ToString) & ".00"
            ComboBoxImageDiskPriceCash.Text = "$" & Val(Reader("ImageDiskPriceCash").ToString) & ".00"

            ComboBoxMinAge.Text = Reader("MinAge").ToString
            ComboBoxUnderAge.Text = Reader("UnderAge").ToString
            ComboBoxMinNoFaultDays.Text = Reader("MinNoFaultDays").ToString
            ComboBoxCashDiscountPct.Text = Reader("CashDiscountPct").ToString
            ComboBoxMRIDays.Text = Reader("NFBetweenMRIDays").ToString
            gFindComboItemByValue(ComboBoxNFDefaultBillingCompany, Reader("BillingNFDefaultBillingCompany").ToString, True)
            gFindComboItemByValue(ComboBoxWCDefaultBillingCompany, Reader("BillingWCDefaultBillingCompany").ToString, True)
            gFindComboItemByValue(ComboBoxPrivateDefaultBillingCompany, Reader("BillingPrivateDefaultBillingCompany").ToString, True)
            chkNFAllowChange.Checked = CBool(Reader("BillingNFDefaultBillingCompanyAllowChange").ToString)
            chkEnableElectronicBillFiling.Checked = CBool(Val(Reader("EnableElectronicBillFiling").ToString))
            chkWCAllowChange.Checked = CBool(Reader("BillingWCDefaultBillingCompanyAllowChange").ToString)
            chkPRAllowChange.Checked = CBool(Reader("BillingPrivateDefaultBillingCompanyAllowChange").ToString)
            ComboBoxCancelationWarning.Text = Val(Reader("CancelationWarning").ToString)
            ComboBoxCancelationDrop.Text = Val(Reader("CancelationDrop").ToString)
            txtSystemAutoUpdatePath.Text = Reader("SystemAutoUpdatePath").ToString
            txtSystemLibraryPath.Text = Reader("SystemLibraryPath").ToString

            txtSysAdminUID.Text = Reader("SysAdminUID").ToString
            txtSysAdminPWD.Text = Reader("SysAdminPWD").ToString
            txtSysAdminPWDConfirm.Text = Reader("SysAdminPWD").ToString
            chkPadded.Checked = Reader("PACSPatientIDPadded").ToString
            chkPACSAltNumberRequired.Checked = Reader("PACSAltNumberRequired").ToString
            If Reader("Logo") Is DBNull.Value Then
                PictureBoxPCLogo.Image = Nothing
            Else
                Dim arrayImage() As Byte = CType(Reader("Logo"), Byte())
                Dim ms As New IO.MemoryStream(arrayImage)
                PictureBoxPCLogo.Image = Image.FromStream(ms)
                PictureBoxPCLogo.Refresh()
            End If
            chkSimplifiedBilling.Checked = CBool(Val("" & Reader("SimplifiedBilling").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        FpSpread1.ActiveSheet.RowCount = 0
        Reader = gSQLGetDataReader("SELECT Su, Mo, Tu, WE, Th, Fr, Sa, ID, OfficeDiagnostics.DiagID, DiagName FROM OfficeDiagnostics inner join Diagnostics on OfficeDiagnostics.DiagID=Diagnostics.DiagID WHERE OfficeDiagnostics.OfficeID = " & ID)
        If Reader Is Nothing Then Exit Sub
        FpSpread1.SuspendLayout()
        Do Until Reader.Read = False
            FpSpread1.ActiveSheet.RowCount = FpSpread1.ActiveSheet.RowCount + 1
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 0).Tag = "" & Reader("ID").ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 0).Text = "" & Reader("DiagName").ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 0).Value = "" & Reader("DiagID").ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 1).Text = Val(Reader("Su").ToString).ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 2).Text = Val(Reader("Mo").ToString).ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 3).Text = Val(Reader("Tu").ToString).ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 4).Text = Val(Reader("We").ToString).ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 5).Text = Val(Reader("Th").ToString).ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 6).Text = Val(Reader("Fr").ToString).ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 7).Text = Val(Reader("Sa").ToString).ToString
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 0).BackColor = Color.WhiteSmoke
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 0).Locked = True
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).Locked = True
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).CellType = New FarPoint.Win.Spread.CellType.ButtonCellType
            CType(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).CellType, FarPoint.Win.Spread.CellType.ButtonCellType).Text = ""
            Application.DoEvents()
        Loop
        Reader.Close() : Reader.Dispose()
        FpSpread1.ActiveSheet.GrayAreaBackColor = Color.WhiteSmoke
        FpSpread1.ActiveSheet.RowCount = FpSpread1.ActiveSheet.RowCount + 1
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 0).BackColor = Color.WhiteSmoke
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 0).Locked = False
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).Locked = True
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).CellType = New FarPoint.Win.Spread.CellType.ButtonCellType
        CType(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).CellType, FarPoint.Win.Spread.CellType.ButtonCellType).Text = "X"
        Cursor = Cursors.Default
        FpSpread1.ResumeLayout(True)
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me)
        cboMessageType.SelectedIndex = 0
        FpSpread1.ActiveSheet.RowCount = 0
        FpSpread1.ActiveSheet.RowCount = 1
        ComboBoxAttorneyNoConfirmationAge.SelectedIndex = 4
        ComboBoxBillingRequestWarningAge.SelectedIndex = 2
        ComboBoxBillingMinDays.Text = "30"
        ComboBoxBillingMaxDays.Text = "40"
        ComboBoxImageDiskPriceForInsuranceCompany.Text = "$150.00"
        ComboBoxImageDiskPriceForMedicalOffice.Text = "$150.00"
        ComboBoxImageDiskPriceCash.Text = "$75.00"
        ComboBoxIdleTime.Text = "30 Sec."
        ComboBoxNFDefaultBillingCompany.SelectedIndex = 0
        ComboBoxWCDefaultBillingCompany.SelectedIndex = 0
        ComboBoxPrivateDefaultBillingCompany.SelectedIndex = 0
        ComboBoxCancelationWarning.SelectedIndex = 0
        ComboBoxCancelationDrop.SelectedIndex = 0
        PictureBoxPCLogo.Image = Nothing
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        gLoop_Enable_Controls(Me, En)
        ListViewOffices.Enabled = Not En
        cmdAddNew.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        Button2.Enabled = En
        Button3.Enabled = En
        chkCheckAddress.Enabled = En
        cmdSelectPicturePCLogo.Enabled = En
        cmdRemovePCLogo.Enabled = En
        cboMessageType.Enabled = En
        txtMRNAbbreviation.Enabled = En
        ComboBoxCashDiscountPct.Enabled = En
        ComboBoxBillingMaxDays.Enabled = En
        ComboBoxBillingMinDays.Enabled = En
        ComboBoxImageDiskPriceForInsuranceCompany.Enabled = En
        ComboBoxImageDiskPriceForMedicalOffice.Enabled = En
        ComboBoxImageDiskPriceCash.Enabled = En
        ComboBoxIdleTime.Enabled = En
        ComboBoxNFDefaultBillingCompany.Enabled = En
        ComboBoxWCDefaultBillingCompany.Enabled = En
        ComboBoxPrivateDefaultBillingCompany.Enabled = En
        ComboBoxNF2MinAge.Enabled = En
        ComboBoxNF2MaxAge.Enabled = En
        chkPadded.Enabled = En
        chkPACSAltNumberRequired.Enabled = En
        If En = False Then
            If ListViewOffices.Items.Count > 0 Then
                cmdEdit.Enabled = True
                cmdDelete.Enabled = True
            Else
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            End If
        Else
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
        End If
        FpSpread1.Enabled = En
        FpSpread1.Enabled = Not En

        For I As Integer = 0 To FpSpread1.ActiveSheet.Rows.Count - 1
            FpSpread1.ActiveSheet.Rows(I).BackColor = IIf(En, Color.White, Color.WhiteSmoke)
        Next
        If FpSpread1.ActiveSheet.RowCount > 0 Then
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 0).BackColor = IIf(En, Color.White, Color.WhiteSmoke)
        End If
        If txtMRNAbbreviation.Text.Length > 0 Then txtMRNAbbreviation.Enabled = False
        txtSystemAutoUpdatePath.Enabled = En
        FpSpread1.Enabled = En
        txtSMTPPWDConf.Enabled = En
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        cboMessageType.SelectedIndex = 0
        ComboBoxState.Text = gDefaultState
        CheckBoxActiveInd.Checked = True
        ComboBoxProcsPerVisit.SelectedIndex = 2
        ComboBoxDOAAge.SelectedIndex = 30
        ComboBoxNoShowHours.SelectedIndex = 1
        ComboBoxCashDiscountPct.SelectedIndex = 0
        TabControl1.SelectedIndex = 0
        cboOfficeType.SelectedIndex = 0
        ComboBoxNF2MinAge.SelectedIndex = 0
        ComboBoxNF2MaxAge.SelectedIndex = 0
        cboOfficeType.Tag = ""
        txtOfficeName.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdCancel.Click
        OpMode = AddEditMode.None
        Enable_Controls(False)
        gLoop_ResetErrors_Controls(ErrorProvider1, Me)
        If Not SaveSelectedItem Is Nothing Then
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        Else
            If ListViewOffices.Items.Count > 0 Then
                ListViewOffices.Items(0).Selected = True
                ListViewOffices.Items(0).EnsureVisible()
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdEdit.Click
        OpMode = AddEditMode.Edit
        Enable_Controls(True)

        cboOfficeType_SelectedIndexChanged(Nothing, Nothing)
        If TabControl1.SelectedIndex = 0 Then
            txtOfficeName.Focus()
        Else
            FpSpread1.Focus()
        End If
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdUpdate.Click
        Dim I As Integer
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Ret As String
        Dim RetID As String
        Dim RetTag As String
        Dim ProcCount As Integer = 0
        Dim Reader As SqlClient.SqlDataReader
        Dim Su As Integer
        Dim Mo As Integer
        Dim Tu As Integer
        Dim W As Integer
        Dim Th As Integer
        Dim Fr As Integer
        Dim Sa As Integer
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If
            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
            End If
            gLoop_Trim_Controls(Me)
            'gLoop_Text_PropperCase(Me, txtWebAddress, txtSystemAutoUpdatePath, txtSysAdminUID, txtSysAdminPWD)

            If gOfficeID = ID.ToString And CheckBoxActiveInd.Checked = False Then
                TabControl1.SelectedIndex = 0
                If MsgBox("Attention" & vbCrLf & vbCrLf & "You have set the current office as not active!" & vbCrLf & vbCrLf & "Administrator only will be able to login to the system!" & vbCrLf & vbCrLf & "Do you want to continue update?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    CheckBoxActiveInd.Focus()
                    ErrorProvider1.SetError(CheckBoxActiveInd, "Current Office set as Not Active")
                    Exit Sub
                End If
            End If
            If txtOfficeName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtOfficeName, "Unable to process update. The Office Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Office Name is required.", MsgBoxStyle.Exclamation)
                txtOfficeName.Focus()
                Exit Sub
            End If
            If txtMRNAbbreviation.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtMRNAbbreviation, "Unable to process update. The Office MRN Abbreviation is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Office MRN Abbreviation is required.", MsgBoxStyle.Exclamation)
                txtMRNAbbreviation.Focus()
                Exit Sub
            End If

            If cboOfficeType.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(cboOfficeType, "Unable to process update. The Office Type is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Office Type is required.", MsgBoxStyle.Exclamation)
                cboOfficeType.Focus()
                Exit Sub
            End If
            If txtEmail.Text <> "" AndAlso gEmailCheck(txtEmail.Text) = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtEmail, "Unable to process update. Invalid Email address specified.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Email address specified.", MsgBoxStyle.Exclamation)
                txtEmail.Focus()
                Exit Sub
            End If
            If txtSMTPPort.Text <> "" Then
                If IsNumeric(txtSMTPPort.Text) = False Then
                    TabControl1.TabPages("EMAIL").Select()
                    ErrorProvider1.SetError(txtSMTPPort, "Unable to process update. Invalid SMTP Port Number specified.")
                    MsgBox("Unable to process update." & vbCrLf & "Invalid SMTP Port Number specified.", MsgBoxStyle.Exclamation)
                    txtSMTPPort.Focus()
                    Exit Sub
                End If
            End If
            If txtSMTPFromAddress.Text <> "" AndAlso gEmailCheck(txtSMTPFromAddress.Text) = False Then
                TabControl1.TabPages("EMAIL").Select()
                ErrorProvider1.SetError(txtSMTPFromAddress, "Unable to process update. Invalid SMTP From Email Address specified.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid SMTP From Email Address specified.", MsgBoxStyle.Exclamation)
                txtSMTPFromAddress.Focus()
                Exit Sub
            End If
            If txtSMTPPWD.Text <> txtSMTPPWDConf.Text Then
                TabControl1.TabPages("EMAIL").Select()
                ErrorProvider1.SetError(txtSMTPPWD, "Unable to process update. SMTP Password does not match Password confirmation.")
                ErrorProvider1.SetError(txtSMTPPWDConf, "Unable to process update. SMTP Password does not match Password confirmation.")
                MsgBox("Unable to process update." & vbCrLf & "SMTP Password does not match Password confirmation.", MsgBoxStyle.Exclamation)
                txtSMTPPWD.Focus()
                Exit Sub
            End If

            If OpMode = AddEditMode.Edit Then
                If Val(cboOfficeType.Tag) > 0 Then
                    If Val(cboOfficeType.Tag) <> CType(cboOfficeType.SelectedItem, ValueDescription).Value Then
                        If MsgBox("You have changed the type of the office." & vbCrLf & "The new office type is " & CType(cboOfficeType.SelectedItem, ValueDescription).Description & vbCrLf & vbCrLf & "Please confirm.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            TabControl1.SelectedIndex = 0
                            cboOfficeType.Focus()
                            Exit Sub
                        End If
                    End If
                End If
                Reader = gSQLGetDataReader("Select * from Offices Where OfficeID<>" & ID & " and OfficeName='" & txtOfficeName.Text.ToSafeSQLString() & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from Offices Where OfficeName='" & txtOfficeName.Text.ToSafeSQLString() & "'")
            End If
            If Reader.Read() = True Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtOfficeName, "Unable to process update. The The Office Name is already inuse.")
                MsgBox("Unable to process update." & vbCrLf & "The Office Name is already inuse.", MsgBoxStyle.Exclamation)
                txtOfficeName.Focus()
                txtOfficeName.SelectAll()
                Exit Sub
            End If
            If OpMode = AddEditMode.Edit Then
                Reader = gSQLGetDataReader("Select * from Offices Where OfficeID<>" & ID & " and MRNAbbreviation='" & txtMRNAbbreviation.Text.ToSafeSQLString() & "'")
            Else
                Reader = gSQLGetDataReader("Select * from Offices Where MRNAbbreviation='" & txtMRNAbbreviation.Text.ToSafeSQLString() & "'")
            End If
            If Reader.Read() = True Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtMRNAbbreviation, "Unable to process update. The The specified MRN Abbreviation is already inuse.")
                MsgBox("Unable to process update." & vbCrLf & "The The specified MRN Abbreviation is already inuse.", MsgBoxStyle.Exclamation)
                txtMRNAbbreviation.Focus()
                txtMRNAbbreviation.SelectAll()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()
            If CType(cboOfficeType.SelectedItem, ValueDescription).Value = 1 Or CType(cboOfficeType.SelectedItem, ValueDescription).Value = 3 Then ' Radiology
                Dim C As Integer
                Dim Ret1 As String
                With FpSpread1.ActiveSheet
                    For I = 0 To .RowCount - 1
                        Ret = .Cells(I, 0).Text
                        For C = I + 1 To .RowCount - 1
                            Ret1 = .Cells(C, 0).Text
                            If Ret = Ret1 Then
                                TabControl1.SelectedIndex = 1
                                MsgBox("Unable to process update." & vbCrLf & "Duplicate Diagnostic.", MsgBoxStyle.Exclamation)
                                .SetActiveCell(C, 0)
                                .Cells(C, 0).ForeColor = Color.Red
                                FpSpread1.Focus()
                                Exit Sub
                            End If
                        Next
                    Next
                End With
            Else 'None Radiology - No Schedule
                FpSpread1.ActiveSheet.RowCount = 0
            End If
            If ComboBoxStartTime.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(ComboBoxStartTime, "Unable to process update. The Office Start Time is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Office Start Time is required.", MsgBoxStyle.Exclamation)
                ComboBoxStartTime.Focus()
                Exit Sub
            End If
            If ComboBoxDayHours.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(ComboBoxDayHours, "Unable to process update. The Office Day Hours is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Office Day Hours is required.", MsgBoxStyle.Exclamation)
                ComboBoxDayHours.Focus()
                Exit Sub
            End If
            If ComboBoxInterval.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(ComboBoxInterval, "Unable to process update. The Office Schedule Interval is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Office Schedule Interval is required.", MsgBoxStyle.Exclamation)
                ComboBoxInterval.Focus()
                Exit Sub
            End If
            If ComboBoxPatients.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(ComboBoxPatients, "Unable to process update. The Interval Patients is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Interval Patients is required.", MsgBoxStyle.Exclamation)
                ComboBoxPatients.Focus()
                Exit Sub
            End If

            If ComboBoxCancelationWarning.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ComboBoxCancelationWarning, "Unable to process update. The Cancelation / Reschedule Warning should be selected.")
                MsgBox("Unable to process update." & vbCrLf & "The Cancelation / Reschedule Warning should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxCancelationWarning.Focus()
                Exit Sub
            End If
            If ComboBoxCancelationDrop.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ComboBoxCancelationDrop, "Unable to process update. The Cancelation / Reschedule Drop should be selected.")
                MsgBox("Unable to process update." & vbCrLf & "The Cancelation / Reschedule Drop should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxCancelationDrop.Focus()
                Exit Sub
            End If

            If ComboBoxMinAge.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ComboBoxMinAge, "Unable to process update. The Minimum Patients Age is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Minimum Patients Age is required.", MsgBoxStyle.Exclamation)
                ComboBoxMinAge.Focus()
                Exit Sub
            End If

            If ComboBoxUnderAge.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ComboBoxUnderAge, "Unable to process update. The Underage Patients Age is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Underage Patients Age is required.", MsgBoxStyle.Exclamation)
                ComboBoxUnderAge.Focus()
                Exit Sub
            End If
            If ComboBoxMinNoFaultDays.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ComboBoxMinNoFaultDays, "Unable to process update. The Minimum NoFault First Procedure Days is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Minimum NoFault First Procedure Days is required.", MsgBoxStyle.Exclamation)
                ComboBoxMinNoFaultDays.Focus()
                Exit Sub
            End If
            If ComboBoxDOAAge.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ComboBoxDOAAge, "Unable to process update. The NoFault DOA Age Days is required.")
                MsgBox("Unable to process update." & vbCrLf & "The NoFault DOA Age Days is required.", MsgBoxStyle.Exclamation)
                ComboBoxDOAAge.Focus()
                Exit Sub
            End If
            If ComboBoxNoShowHours.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ComboBoxNoShowHours, "Unable to process update. The NoShow Hours is required.")
                MsgBox("Unable to process update." & vbCrLf & "The NoShow Hours is required.", MsgBoxStyle.Exclamation)
                ComboBoxNoShowHours.Focus()
                Exit Sub
            End If
            If chkSimplifiedBilling.Checked Then
                TabControl1.SelectedIndex = 3
                If MsgBox("You have checked [Simplified Billing]." & vbCrLf & "Please Confirm.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    chkSimplifiedBilling.Focus()
                    Exit Sub
                End If
            End If
            If CType(cboOfficeType.SelectedItem, ValueDescription).Value = 2 Then
                If ComboBoxNF2MinAge.SelectedIndex = -1 Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(ComboBoxNF2MinAge, "Unable to process update. The NF2 Min Age is required.")
                    MsgBox("Unable to process update." & vbCrLf & "The NF2 Min Age is required.", MsgBoxStyle.Exclamation)
                    ComboBoxNF2MinAge.Focus()
                    Exit Sub
                End If
                If ComboBoxNF2MaxAge.SelectedIndex = -1 Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(ComboBoxNF2MaxAge, "Unable to process update. The NF2 Max Age is required.")
                    MsgBox("Unable to process update." & vbCrLf & "The NF2 Max Age is required.", MsgBoxStyle.Exclamation)
                    ComboBoxNF2MaxAge.Focus()
                    Exit Sub
                End If
            End If
            If txtSysAdminPWD.Text.Trim().Length > 0 Then
                If txtSysAdminPWD.Text <> txtSysAdminPWDConfirm.Text Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(txtSysAdminPWD, "Unable to process update. THe system adminitrator password does not match.")
                    ErrorProvider1.SetError(txtSysAdminPWDConfirm, "Unable to process update. THe system adminitrator password does not match.")
                    MsgBox("Unable to process update." & vbCrLf & "Unable to process update. THe system adminitrator password does not match.", MsgBoxStyle.Exclamation)
                    ComboBoxNF2MaxAge.Focus()
                    Exit Sub

                End If
            End If
            If cboNF2MainBillingProviderID.SelectedIndex = -1 Then
                If MsgBox("You have not specified the default Main Billing Provider." & vbCrLf & "You can specify it later." & vbCrLf & vbCrLf & "You will not be able to print Patient's envilopes until you will setup the default Billing Provider.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    TabControl1.SelectedIndex = 3
                    cboNF2MainBillingProviderID.Focus()
                    Exit Sub
                End If
            End If
            If CType(cboOfficeType.SelectedItem, ValueDescription).Value = 1 Or CType(cboOfficeType.SelectedItem, ValueDescription).Value = 3 Then ' Radiology
                With FpSpread1.ActiveSheet
Recheck:
                    For I = 0 To .RowCount - 1
                        Ret = .Cells(I, 0).Text
                        RetTag = .Cells(I, 0).Tag
                        Ret = Trim(Ret)

                        If Ret = "" And Val(RetTag) <> 0 Then
                            TabControl1.SelectedIndex = 1
                            MsgBox("Unable to process update." & vbCrLf & "The Procedure name is required." & vbCrLf & "If you need to delete an existing procedure, please contact your system administrator.", MsgBoxStyle.Exclamation)
                            .SetActiveCell(1, 0)
                            FpSpread1.Focus()
                            FpSpread1.EditMode = True
                            Exit Sub
                        End If
                        If Ret <> "" Then
                            ProcCount += 1
                        End If
                        If Ret = "" And Val(RetTag) = 0 And I <> .RowCount - 1 Then
                            .RemoveRows(I, 1)
                            GoTo Recheck
                        End If
                    Next
                End With
                If ProcCount = 0 Then
                    TabControl1.SelectedIndex = 1
                    If MsgBox("Warning!" & vbCrLf & "The Procedure for the current office has not been defined." & vbCrLf & "You will not be able to schedule appointments for this office." & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        FpSpread1.Focus()
                        Exit Sub
                    End If
                End If
            End If
            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM Offices Where OfficeID= " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Offices")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            If TR.Table.Columns.Contains("TwilioFromPhoneNumber") Then
                TR("TwilioFromPhoneNumber") = txtTwilioFromPhoneNumber.Text
                TR("TwilioAccountSid") = txtTwilioAccountSid.Text
                TR("TwilioAuthToken") = txtTwilioAuthToken.Text
                TR("TwilioBin") = txtTwilioBin.Text
                If cboMessageType.SelectedIndex > 0 Then
                    TR("TwilioMessageTypeId") = CType(cboMessageType.SelectedItem, ValueDescription).Value
                Else
                    TR("TwilioMessageTypeId") = 0
                End If

            End If
            TR("OfficeName") = txtOfficeName.Text.ToSafeSQLString()
            TR("MRNAbbreviation") = txtMRNAbbreviation.Text.ToSafeSQLString()

            TR("OfficeTypeID") = CType(cboOfficeType.SelectedItem, ValueDescription).Value

            TR("Address1") = txtAddress1.Text
            TR("Address2") = txtAddress2.Text
            TR("City") = txtCity.Text
            TR("State") = ComboBoxState.Text
            If txtZip.MaskCompleted Then TR("Zip") = txtZip.Text Else TR("Zip") = ""
            If txtPhone1.MaskCompleted Then TR("Phone1") = txtPhone1.Text Else TR("Phone1") = ""
            If txtPhone2.MaskCompleted Then TR("Phone2") = txtPhone2.Text Else TR("Phone2") = ""
            If txtFax1.MaskCompleted Then TR("Fax1") = txtFax1.Text Else TR("Fax1") = ""
            If txtFax2.MaskCompleted Then TR("Fax2") = txtFax2.Text Else TR("Fax2") = ""
            TR("eMail") = txtEmail.Text
            TR("WebAddress") = txtWebAddress.Text
            'TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
            TR("ActiveInd") = 1
            If cboNF2MainBillingProviderID.SelectedIndex > -1 Then
                TR("NF2MainBillingProviderID") = CType(cboNF2MainBillingProviderID.SelectedItem, ValueDescription).Value
            Else
                TR("NF2MainBillingProviderID") = 0
            End If

            TR("StartTime") = CType(ComboBoxStartTime.SelectedItem, ValueDescription).Value
            TR("WorkDayHours") = CType(ComboBoxDayHours.SelectedItem, ValueDescription).Value
            TR("SplitInterval") = CType(ComboBoxInterval.SelectedItem, ValueDescription).Value
            TR("NumberPatientsPerInterval") = CType(ComboBoxPatients.SelectedItem, ValueDescription).Value
            TR("ProcsPerVisit") = CType(ComboBoxProcsPerVisit.SelectedItem, ValueDescription).Value
            TR("MinAge") = Val(ComboBoxMinAge.Text)
            TR("UnderAge") = Val(ComboBoxUnderAge.Text)
            TR("MinNoFaultDays") = Val(ComboBoxMinNoFaultDays.Text)
            TR("BillingMaxDays") = Val(ComboBoxBillingMaxDays.Text)
            TR("AttorneyNoConfirmationAge") = CType(ComboBoxAttorneyNoConfirmationAge.SelectedItem, ValueDescription).Value
            TR("BillingRequestWarningAge") = CType(ComboBoxBillingRequestWarningAge.SelectedItem, ValueDescription).Value
            TR("BillingMinDays") = Val(ComboBoxBillingMinDays.Text)
            TR("SimplifiedBilling") = IIf(chkSimplifiedBilling.Checked, 1, 0)

            TR("ImageDiskPriceForInsuranceCompany") = CType(ComboBoxImageDiskPriceForInsuranceCompany.SelectedItem, ValueDescription).Value
            TR("ImageDiskPriceForMedicalOffice") = CType(ComboBoxImageDiskPriceForMedicalOffice.SelectedItem, ValueDescription).Value
            TR("ImageDiskPriceCash") = CType(ComboBoxImageDiskPriceCash.SelectedItem, ValueDescription).Value

            TR("DOAAge") = CType(ComboBoxDOAAge.SelectedItem, ValueDescription).Value
            TR("NoShowHours") = CType(ComboBoxNoShowHours.SelectedItem, ValueDescription).Value
            TR("CashDiscountPct") = ComboBoxCashDiscountPct.Text
            TR("IdleTime") = CType(ComboBoxIdleTime.SelectedItem, ValueDescription).Value
            TR("BillingNFDefaultBillingCompany") = CType(ComboBoxNFDefaultBillingCompany.SelectedItem, ValueDescription).Value
            TR("BillingWCDefaultBillingCompany") = CType(ComboBoxWCDefaultBillingCompany.SelectedItem, ValueDescription).Value
            TR("BillingPrivateDefaultBillingCompany") = CType(ComboBoxPrivateDefaultBillingCompany.SelectedItem, ValueDescription).Value
            TR("BillingNFDefaultBillingCompanyAllowChange") = Math.Abs(CInt(chkNFAllowChange.Checked))
            TR("EnableElectronicBillFiling") = Math.Abs(CInt(chkEnableElectronicBillFiling.Checked))
            TR("BillingWCDefaultBillingCompanyAllowChange") = Math.Abs(CInt(chkWCAllowChange.Checked))
            TR("BillingPrivateDefaultBillingCompanyAllowChange") = Math.Abs(CInt(chkPRAllowChange.Checked))
            TR("CheckAddress") = 0 ' Math.Abs(CInt(chkCheckAddress.Checked))
            TR("NFBetweenMRIDays") = Val(ComboBoxMRIDays.Text)
            TR("CancelationWarning") = Val(ComboBoxCancelationWarning.Text)
            TR("CancelationDrop") = Val(ComboBoxCancelationDrop.Text)

            If CType(cboOfficeType.SelectedItem, ValueDescription).Value = 2 Then
                TR("NF2MinAge") = Val(ComboBoxNF2MinAge.Text)
                TR("NF2MaxAge") = Val(ComboBoxNF2MaxAge.Text)
            End If

            TR("SystemAutoUpdatePath") = txtSystemAutoUpdatePath.Text
            TR("SystemLibraryPath") = txtSystemLibraryPath.Text
            TR("SysAdminUID") = txtSysAdminUID.Text
            TR("SysAdminPWD") = txtSysAdminPWD.Text

            TR("SMTPUID") = txtSMTPUID.Text
            TR("SMTPPWD") = txtSMTPPWD.Text
            TR("SMTPHost") = txtSMTPHost.Text
            TR("SMTPPort") = Val(txtSMTPPort.Text)
            TR("SMTPFromAddress") = txtSMTPFromAddress.Text
            TR("SMTPSendAsync") = IIf(chkSMPTAsync.Checked, 1, 0)
            TR("PACSPatientIDPadded") = IIf(chkPadded.Checked, 1, 0)
            TR("PACSAltNumberRequired") = IIf(chkPACSAltNumberRequired.Checked, 1, 0)

            ''' Update PC Logo
            If PictureBoxPCLogo.Image Is Nothing Then
                TR("Logo") = DBNull.Value
                TR("LogoInd") = 0
            Else
                Dim ms As New IO.MemoryStream
                PictureBoxPCLogo.Image.Save(ms, Imaging.ImageFormat.Png)
                Dim arrImage() As Byte = ms.GetBuffer
                TR("Logo") = arrImage
                TR("LogoInd") = 1
                ms.Close()

            End If

            If OpMode = AddEditMode.AddNew Then
                dTab.Rows.Add(TR)
            End If
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

            If OpMode = AddEditMode.AddNew Then
                Reader = gSQLGetDataReader("Select * from Offices Where OfficeID = IDENT_CURRENT('Offices')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListViewOffices.Items.Add(Reader("OfficeName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("OfficeID").ToString
                    If ListViewOffices.SelectedItems.Count > 0 Then ListViewOffices.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                    ID = CLng(Val(Reader("OfficeID").ToString))
                    SaveSelectedItem = LI
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                If CheckBoxActiveInd.Checked = True Then
                    SaveSelectedItem.ImageIndex = 1
                Else
                    SaveSelectedItem.ImageIndex = 0
                End If
                SaveSelectedItem.Text = txtOfficeName.Text
            End If
            If CType(cboOfficeType.SelectedItem, ValueDescription).Value = 1 Or CType(cboOfficeType.SelectedItem, ValueDescription).Value = 3 Then ' Radiology
                TA = New SqlClient.SqlDataAdapter("SELECT Su, Mo, Tu, We, Th, Fr, Sa, ID, DiagID, OfficeID FROM OfficeDiagnostics Where OfficeID=" & ID, gConnectionString)
                CB = New SqlClient.SqlCommandBuilder(TA)
                CB.ConflictOption = ConflictOption.OverwriteChanges
                dTab = New DataTable("OfficeDiagnostics")
                TA.Fill(dTab)
                With FpSpread1.ActiveSheet
                    For I = 0 To .RowCount - 1
                        Ret = .Cells(I, 0).Text
                        RetID = .Cells(I, 0).Value()
                        RetTag = .Cells(I, 0).Tag
                        Ret = Trim(Ret)
                        Su = CInt(Math.Abs(Val(.Cells(I, 1).Value)))
                        Mo = CInt(Math.Abs(Val(.Cells(I, 2).Value)))
                        Tu = CInt(Math.Abs(Val(.Cells(I, 3).Value)))
                        W = CInt(Math.Abs(Val(.Cells(I, 4).Value)))
                        Th = CInt(Math.Abs(Val(.Cells(I, 5).Value)))
                        Fr = CInt(Math.Abs(Val(.Cells(I, 6).Value)))
                        Sa = CInt(Math.Abs(Val(.Cells(I, 7).Value)))
                        If Ret <> "" Then
                            If Val(RetTag) > 0 Then
                                For Each TR In dTab.Rows
                                    If Val(TR("ID")) = Val(RetTag) Then
                                        TR("DiagID") = Trim(RetID)
                                        TR("Su") = Su
                                        TR("Mo") = Mo
                                        TR("Tu") = Tu
                                        TR("We") = W
                                        TR("Th") = Th
                                        TR("Fr") = Fr
                                        TR("Sa") = Sa
                                        Exit For
                                    End If
                                Next
                            Else
                                TR = dTab.NewRow
                                TR("OfficeID") = ID
                                TR("DiagID") = Trim(RetID)
                                TR("DiagID") = Trim(RetID)
                                TR("Su") = Su
                                TR("Mo") = Mo
                                TR("Tu") = Tu
                                TR("We") = W
                                TR("Th") = Th
                                TR("Fr") = Fr
                                TR("Sa") = Sa
                                dTab.Rows.Add(TR)
                            End If
                        End If
                    Next
                End With
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
            Else ' None Radiology - No Schedule
                gSQLDeleteRecord("DELETE FROM OfficeDiagnostics Where OfficeID=" & ID)
            End If

            If ID = CLng(gOfficeID) Then
                gTwilioFromPhoneNumber = txtTwilioFromPhoneNumber.Text
                gTwilioAccountSid = txtTwilioAccountSid.Text
                gTwilioAuthToken = txtTwilioAuthToken.Text
                gTwilioBin = txtTwilioBin.Text
                If cboMessageType.SelectedIndex > 0 Then
                    gTwilioMessageTypeId = CType(cboMessageType.SelectedItem, ValueDescription).Value
                Else
                    gTwilioMessageTypeId = 0
                End If

                gMinAge = CInt(Val(ComboBoxMinAge.Text))
                gUnderAge = CInt(Val(ComboBoxUnderAge.Text))
                gMinNoFaultDays = CInt(Val(ComboBoxMinNoFaultDays.Text))
                gCashDiscountPct = ComboBoxCashDiscountPct.Text
                gProcsPerVisit = CType(ComboBoxProcsPerVisit.SelectedItem, ValueDescription).Value
                gMinAge = Val(ComboBoxMinAge.Text)
                gMinNoFaultDays = Val(ComboBoxMinNoFaultDays.Text)
                gNFBetweenMRIDays = Val(ComboBoxMRIDays.Text)
                gUnderAge = Val(ComboBoxUnderAge.Text)
                gDOAAge = CType(ComboBoxDOAAge.SelectedItem, ValueDescription).Value
                gNoShowHours = CType(ComboBoxNoShowHours.SelectedItem, ValueDescription).Value
                gAttorneyNoConfirmationAge = CType(ComboBoxAttorneyNoConfirmationAge.SelectedItem, ValueDescription).Value
                gBillingRequestWarningAge = CType(ComboBoxBillingRequestWarningAge.SelectedItem, ValueDescription).Value
                gPACSPatientIDPadded = IIf(chkPadded.Checked, 1, 0)
                gPACSAltNumberRequired = IIf(chkPACSAltNumberRequired.Checked, 1, 0)
                gSimplifiedBilling = IIf(chkSimplifiedBilling.Checked, 1, 0)
                gSystemIdleTime = CType(ComboBoxIdleTime.SelectedItem, ValueDescription).Value
                gImageDiskPriceForInsuranceCompany = CType(ComboBoxImageDiskPriceForInsuranceCompany.SelectedItem, ValueDescription).Value
                gImageDiskPriceForMedicalOffice = CType(ComboBoxImageDiskPriceForMedicalOffice.SelectedItem, ValueDescription).Value
                gImageDiskPriceCash = CType(ComboBoxImageDiskPriceCash.SelectedItem, ValueDescription).Value

                gEnableElectronicBillFiling = IIf(chkEnableElectronicBillFiling.Checked, 1, 0)
                gOfficeURL = txtWebAddress.Text
                gBillingMinDays = Val(ComboBoxBillingMinDays.Text)
                gBillingMaxDays = Val(ComboBoxBillingMaxDays.Text)

                gBillingNFDefaultBillingCompany = CType(ComboBoxNFDefaultBillingCompany.SelectedItem, ValueDescription).Value
                gBillingWCDefaultBillingCompany = CType(ComboBoxWCDefaultBillingCompany.SelectedItem, ValueDescription).Value
                gBillingPrivateDefaultBillingCompany = CType(ComboBoxPrivateDefaultBillingCompany.SelectedItem, ValueDescription).Value

                gBillingNFDefaultBillingCompanyAllowChange = Math.Abs(CInt(chkNFAllowChange.Checked))
                gBillingWCDefaultBillingCompanyAllowChange = Math.Abs(CInt(chkWCAllowChange.Checked))
                gBillingPrivateDefaultBillingCompanyAllowChange = Math.Abs(CInt(chkPRAllowChange.Checked))
                gCheckAddress = chkCheckAddress.Checked
                gCancelationWarning = Val(ComboBoxCancelationWarning.Text)
                gCancelationDrop = Val(ComboBoxCancelationDrop.Text)

                gNF2MinAge = Val(ComboBoxNF2MinAge.Text)
                gNF2MaxAge = Val(ComboBoxNF2MaxAge.Text)
                gSystemAutoUpdatePath = txtSystemAutoUpdatePath.Text
                gSystemLibraryPath = txtSystemLibraryPath.Text
                gSysAdminUID = txtSysAdminUID.Text.Trim
                gSysAdminPWD = txtSysAdminPWD.Text.Trim

                gSMTPUID = txtSMTPUID.Text
                gSMTPPWD = txtSMTPPWD.Text
                gSMTPHost = txtSMTPHost.Text
                gSMTPPort = Val(txtSMTPPort.Text)
                gSMTPFromAddress = txtSMTPFromAddress.Text
                gSMTPAsync = IIf(chkSMPTAsync.Checked, 1, 0)
                gRestart = True
            End If
            OpMode = AddEditMode.None
            Enable_Controls(False)
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            If ListViewOffices.SelectedItems.Count > 0 Then
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListViewOffices.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Office selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the office " & ListViewOffices.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable an Office.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ID = CLng(ListViewOffices.SelectedItems(0).Tag)
        If gSQLDeleteRecord("DELETE FROM Offices WHERE OfficeID=" & ID) Then
            ListViewOffices.Items.Remove(ListViewOffices.SelectedItems(0))
            SaveSelectedItem = Nothing
            If ListViewOffices.SelectedItems.Count > 0 Then
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            Else
                Clear_Controls()
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            End If
        End If

    End Sub

    Private Sub frmOfficeMaintenance_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(ByVal sender As Object, ByVal e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdUpdate.Enabled Then
            If MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub frmOfficeMaintenance_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        gSetup_GotFocus(Me)
        Load_Data()
        Load_Offices()
        Cursor = Cursors.Default
        Application.DoEvents()
        txtAddress1.AutoCompleteCustomSource = gAutocompleteAddress
        txtCity.AutoCompleteCustomSource = gAutocompleteCity
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.ActiveSheet.GrayAreaBackColor = Color.WhiteSmoke
        ToolTip1.SetToolTip(picSecurityInfo, "Windows Administrative User Name and Password is required by the" & vbCrLf & "System Auto Update to copy update in the Windows system folders")
        ToolTip1.SetToolTip(txtSysAdminUID, "Windows Administrative User Name and Password is required by the" & vbCrLf & "System Auto Update to copy update in the Windows system folders")
        ToolTip1.SetToolTip(txtSysAdminPWD, "Windows Administrative User Name and Password is required by the" & vbCrLf & "System Auto Update to copy update in the Windows system folders")
        Enable_Controls(False)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdClose.Click
        Close()

    End Sub

    Private Sub txtOfficeName_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtOfficeName.TextChanged
        ErrorProvider1.SetError(txtOfficeName, "")
    End Sub

    Private Sub txtAddress1_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtAddress1.TextChanged
        ErrorProvider1.SetError(txtAddress1, "")
    End Sub

    Private Sub txtAddress2_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtAddress2.TextChanged
        ErrorProvider1.SetError(txtAddress2, "")
    End Sub

    Private Sub txtCity_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtCity.TextChanged
        ErrorProvider1.SetError(txtCity, "")
    End Sub

    Private Sub ComboBoxState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxState.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxState, "")
    End Sub

    Private Sub txtZip_MaskInputRejected(ByVal sender As System.Object, ByVal e As Windows.Forms.MaskInputRejectedEventArgs) Handles txtZip.MaskInputRejected

    End Sub

    Private Sub ComboBoxStartTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxStartTime.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxStartTime, "")
    End Sub

    Private Sub ComboBoxDayHours_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxDayHours.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxDayHours, "")
    End Sub

    Private Sub ComboBoxInterval_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxInterval.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxInterval, "")
    End Sub

    Private Sub ComboBoxPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxPatients.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxPatients, "")
    End Sub

    Private Sub FpSpread1_ButtonClicked(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ButtonClicked

        If e.Column < FpSpread1.ActiveSheet.ColumnCount - 1 Then Exit Sub
        If FpSpread1.ActiveSheet.Cells(e.Row, 0).Tag = "" Then
            FpSpread1.ActiveSheet.RemoveRows(e.Row, 1)
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).Locked = True
        End If
    End Sub

    Private Sub FpSpread1_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ComboCloseUp
        FpSpread1.ActiveSheet.Cells(e.Row, 0).ForeColor = Color.Black
    End Sub

    Private Sub FpSpread1_EditChange(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.EditChange
        If OpMode = AddEditMode.None Then Exit Sub
        If Val(FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Tag) = 0 Then
            If FpSpread1.ActiveSheet.RowCount = e.Row + 1 Then
                If FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Text <> "" Then
                    FpSpread1.ActiveSheet.Cells(e.Row, 8).Locked = False
                    FpSpread1.ActiveSheet.RowCount = FpSpread1.ActiveSheet.RowCount + 1
                    FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 0).Locked = False
                    FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).Locked = True
                    FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).CellType = New FarPoint.Win.Spread.CellType.ButtonCellType
                    CType(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).CellType, FarPoint.Win.Spread.CellType.ButtonCellType).Text = ""
                    FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 2, 8).CellType = New FarPoint.Win.Spread.CellType.ButtonCellType
                    CType(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 2, 8).CellType, FarPoint.Win.Spread.CellType.ButtonCellType).Text = "X"
                    CType(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 2, 8).CellType, FarPoint.Win.Spread.CellType.ButtonCellType).TextColor = Color.Red

                End If
            ElseIf FpSpread1.ActiveSheet.RowCount = e.Row + 2 Then
                If FpSpread1.ActiveSheet.Cells(e.Row, 0).Text = "" Then
                    FpSpread1.ActiveSheet.RowCount = FpSpread1.ActiveSheet.RowCount - 1
                    FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.RowCount - 1, 8).Locked = True
                End If
            End If
        End If
        If FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Text = "" And Val(FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Tag) <> 0 Then
            FpSpread1.ActiveSheet.Cells(e.Row, e.Column).BackColor = Color.LightPink
        Else
            FpSpread1.ActiveSheet.Cells(e.Row, e.Column).BackColor = Color.White
        End If
    End Sub

    Private Sub ComboBoxMinAge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxMinAge.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxMinAge, "")
    End Sub

    Private Sub ComboBoxUnderAge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxUnderAge.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxUnderAge, "")
    End Sub

    Private Sub ComboBoxMinNoFaultDays_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxMinNoFaultDays.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxMinNoFaultDays, "")
    End Sub

    Private Sub ComboBoxDOAAge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxDOAAge.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxDOAAge, "")
    End Sub

    Private Sub CheckBoxActiveInd_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles CheckBoxActiveInd.CheckedChanged
        ErrorProvider1.SetError(CheckBoxActiveInd, "")
    End Sub

    Private Sub ComboBoxNoShowHours_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxNoShowHours.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxNoShowHours, "")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click
        frmHolidaysMaintenance.ShowDialog(Me)
        frmHolidaysMaintenance.Dispose()
    End Sub

    Private Sub cboOfficeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cboOfficeType.SelectedIndexChanged
        ErrorProvider1.SetError(cboOfficeType, "")
        If cboOfficeType.SelectedIndex = -1 Then Exit Sub
        If OpMode <> AddEditMode.None Then
            ComboBoxCancelationWarning.Enabled = True
            ComboBoxCancelationDrop.Enabled = True
            ComboBoxMinNoFaultDays.Enabled = True
            ComboBoxDOAAge.Enabled = True
            ComboBoxMRIDays.Enabled = True
            ComboBoxCashDiscountPct.Enabled = True
            ComboBoxImageDiskPriceForInsuranceCompany.Enabled = True
            ComboBoxImageDiskPriceForMedicalOffice.Enabled = True
            ComboBoxImageDiskPriceCash.Enabled = True
            ComboBoxNoShowHours.Enabled = True
        End If
        ComboBoxNF2MinAge.Enabled = False
        ComboBoxNF2MaxAge.Enabled = False
        ComboBoxNF2MinAge.SelectedIndex = 0
        ComboBoxNF2MaxAge.SelectedIndex = 0
    End Sub

    Private Sub ComboBoxNF2MinAge_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxNF2MinAge.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxNF2MinAge, "")
    End Sub

    Private Sub ComboBoxNF2MaxAge_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxNF2MaxAge.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxNF2MaxAge, "")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer
        If txtSystemAutoUpdatePath.Text <> "" Then
            Dim dir As New IO.DirectoryInfo(txtSystemAutoUpdatePath.Text)
            If dir.Exists Then
                FolderBrowserDialog1.SelectedPath = txtSystemAutoUpdatePath.Text
            End If
        End If
        If FolderBrowserDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            txtSystemAutoUpdatePath.Text = FolderBrowserDialog1.SelectedPath
            ToolTip1.SetToolTip(txtSystemAutoUpdatePath, txtSystemAutoUpdatePath.Text)
        End If

    End Sub

    Private Sub txtSystemAutoUpdatePath_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtSystemAutoUpdatePath.DoubleClick
        If Button2.Enabled Then Button2_Click(Nothing, Nothing)
    End Sub

    Private Sub txtSystemAutoUpdatePath_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSystemAutoUpdatePath.TextChanged
        If txtSystemAutoUpdatePath.Text <> "" Then
            txtSysAdminUID.BackColor = Color.FromArgb(255, 255, 192)
            txtSysAdminPWD.BackColor = Color.FromArgb(255, 255, 192)
        Else
            txtSysAdminUID.BackColor = Color.FromKnownColor(KnownColor.Window)
            txtSysAdminPWD.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
    End Sub

    Private Sub txtWebAddress_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtWebAddress.TextChanged
        ErrorProvider1.SetError(txtWebAddress, "")
    End Sub

    Private Sub txtEmail_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtEmail.TextChanged
        ErrorProvider1.SetError(txtEmail, "")
    End Sub

    Private Sub txtSMTPFromAddress_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtSMTPFromAddress.TextChanged
        ErrorProvider1.SetError(txtSMTPFromAddress, "")
    End Sub

    Private Sub txtSMTPPort_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtSMTPPort.TextChanged
        ErrorProvider1.SetError(txtSMTPPort, "")
    End Sub

    Private Sub FpSpread1_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellClick

    End Sub

    Private Sub chkSimplifiedBilling_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkSimplifiedBilling.CheckedChanged
        If chkSimplifiedBilling.Checked Then
            lblSimplifiedBilling.ForeColor = Color.Red
        Else
            lblSimplifiedBilling.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ComboBoxNFDefaultBillingCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBoxNFDefaultBillingCompany.SelectedIndexChanged
        If ComboBoxNFDefaultBillingCompany.SelectedIndex > 0 Then
            chkSimplifiedBilling.Visible = True
            lblSimplifiedBilling.Visible = True
        Else
            chkSimplifiedBilling.Visible = False
            lblSimplifiedBilling.Visible = False
            chkSimplifiedBilling.Checked = False
        End If

    End Sub

    Private Sub txtSysAdminUID_TextChanged(sender As Object, e As EventArgs) Handles txtSysAdminUID.TextChanged

    End Sub

    Private Sub txtSysAdminPWD_TextChanged(sender As Object, e As EventArgs) Handles txtSysAdminPWD.TextChanged
        ErrorProvider1.SetError(txtSysAdminPWD, "")
        ErrorProvider1.SetError(txtSysAdminPWDConfirm, "")

    End Sub

    Private Sub txtSysAdminPWDConfirm_TextChanged(sender As Object, e As EventArgs) Handles txtSysAdminPWDConfirm.TextChanged
        ErrorProvider1.SetError(txtSysAdminPWD, "")
        ErrorProvider1.SetError(txtSysAdminPWDConfirm, "")
    End Sub

    Private Sub txtMRNAbbreviation_TextChanged(sender As Object, e As EventArgs) Handles txtMRNAbbreviation.TextChanged
        ErrorProvider1.SetError(txtMRNAbbreviation, "")
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        ContextMenuStrip1.Show(PictureBox4, New Point(0, 0))
    End Sub

    Private Sub CopyInforInformationToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyInforInformationToClipboardToolStripMenuItem.Click
        Clipboard.Clear()
        Clipboard.SetText(ToolTip1.GetToolTip(PictureBox4))
    End Sub

    Private Sub NavigateTwilioURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NavigateTwilioURLToolStripMenuItem.Click
        Process.Start("https://www.twilio.com/console/dev-tools/twiml-bins")
    End Sub

    Private Sub cmdSelectPicturePCLogo_Click(sender As Object, e As EventArgs) Handles cmdSelectPicturePCLogo.Click
        Dim strFileName As String
        If Not PictureBoxPCLogo.Image Is Nothing Then
            If MsgBox("Please confirm you want to overwrite the existing Office Logo?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        'openFD.InitialDirectory = "C:\"
        openFD.Title = "Select PC Logo File."
        openFD.Filter = "Picture Files (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png"
        Dim DidWork As Integer = openFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = openFD.FileName
            PictureBoxPCLogo.Image = Image.FromFile(strFileName)
            openFD.Reset()
        End If
    End Sub

    Private Sub cmdRemovePCLogo_Click(sender As Object, e As EventArgs) Handles cmdRemovePCLogo.Click
        If Not PictureBoxPCLogo.Image Is Nothing Then
            If MsgBox("Are you sure you want to remove the PC Logo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        PictureBoxPCLogo.Image = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer
        If txtSystemLibraryPath.Text <> "" Then
            Dim dir As New IO.DirectoryInfo(txtSystemLibraryPath.Text)
            If dir.Exists Then
                FolderBrowserDialog1.SelectedPath = txtSystemLibraryPath.Text
            End If
        End If
        If FolderBrowserDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            txtSystemLibraryPath.Text = FolderBrowserDialog1.SelectedPath
            ToolTip1.SetToolTip(txtSystemLibraryPath, txtSystemLibraryPath.Text)
        End If
    End Sub

    Private Sub txtSystemLibraryPath_DoubleClick(sender As Object, e As EventArgs) Handles txtSystemLibraryPath.DoubleClick
        If Button3.Enabled Then Button3_Click(Nothing, Nothing)
    End Sub

    Private Sub txtSMTPPWD_TextChanged(sender As Object, e As EventArgs) Handles txtSMTPPWD.TextChanged
        ErrorProvider1.SetError(txtSMTPPWD, "")
        ErrorProvider1.SetError(txtSMTPPWDConf, "")

    End Sub

    Private Sub txtSMTPPWDConf_TextChanged(sender As Object, e As EventArgs) Handles txtSMTPPWDConf.TextChanged
        ErrorProvider1.SetError(txtSMTPPWD, "")
        ErrorProvider1.SetError(txtSMTPPWDConf, "")

    End Sub
End Class