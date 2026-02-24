Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports System.IO
Imports System.Threading.Tasks

Public Class frmImportPatients
    Private SQLConnection As String
    Public CallerForm As frmPatient
    Dim tempFileName As String
    Public PatientsProviders As frmImportPatientsProviders = New frmImportPatientsProviders
    Public m_SortingColumn As ColumnHeader
    Private Sub frmImportPatients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewPatients.HideSelection = True
        tempFileName = Path.Combine(Path.GetTempPath(), gOfficeID & "emo.json")
        PanelConnection.Visible = True
        Application.DoEvents()
        Left = 0
        Top = CallerForm.Top
        Height = CallerForm.Height
        TopMost = True
        m_SortingColumn = ListViewPatients.Columns(0)
        Timer1.Enabled = True
    End Sub
    Private Sub Load_Data()
        '        Try
        '            Dim Reader As SqlClient.SqlDataReader

        '            Dim SQL As String
        '            SQL = "SELECT     Fname+' '+Lname +' '+ Alias as DName, EmpID,ReferralColor FROM Employees WHERE ActiveInd=1 BillingPrv = 1)"
        '            Reader = gSQLGetDataReader(SQL)
        '            If Reader Is Nothing Then Exit Sub
        '            Do Until Reader.Read = False
        '                ComboBoxBillingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString, Reader("ReferralColor").ToString))
        '            Loop
        '            ComboBoxBillingProvider.SelectedIndex = -1
        '            Reader.Close() : Reader.Dispose()
        '            ComboBoxTreatingProviderID.Items.Clear()
        '            Reader = gSQLGetDataReader("SELECT   Employees.EmpID,   Employees.Fname, Employees.Lname, Employees.Alias, Employees.BillingPrv, Employees.TreatmentPrv FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE  TreatmentPrv=1 and Employees.ActiveInd = 1 ")
        '            If Reader Is Nothing Then Exit Sub
        '            Do Until Reader.Read = False
        '                ComboBoxTreatingProviderID.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("FName").ToString & " " & Reader("LName").ToString & " " & Reader("Alias").ToString))
        '            Loop
        '            Reader.Close() : Reader.Dispose()


        '            If ComboBoxBillingProvider.Items.Count = 1 Then
        '                ComboBoxBillingProvider.SelectedIndex = 0
        '            End If
        '            If ComboBoxTreatingProviderID.Items.Count = 1 Then
        '                ComboBoxTreatingProviderID.SelectedIndex = 0
        '            End If

        'ExitSub:
        '        Catch ex As Exception
        '            TopMost = False
        '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '        End Try

    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            lblCount.Text = ""
            Dim ccb As New SqlConnectionStringBuilder
            ccb.DataSource = txtDataSource.Text
            ccb.UserID = txtUserID.Text
            ccb.Password = txtPassword.Text
            ccb.InitialCatalog = txtDatabase.Text
            ccb.ConnectRetryCount = 2
            ccb.IntegratedSecurity = False
            ccb.Pooling = False
            cmdCopy.Enabled = False
            cmdPrint.Enabled = False
            imgWait1.Visible = True
            imgWait1.Refresh()
            If ValidateConnection(ccb.ConnectionString) Then
                SQLConnection = ccb.ConnectionString
                PatientsProviders.Load_Data(0)
                Load_Data()
                Load_Patients()
                SaveToJsonFile(ccb, tempFileName)
                If ListViewPatients.Items.Count > 0 Then
                    cmdCopy.Enabled = True
                    cmdPrint.Enabled = True
                End If
            End If
            imgWait1.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Error")
        End Try
    End Sub
    Public Sub Load_Patients()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Dim PName() As String
        ListViewPatients.BeginUpdate()
        ListViewPatients.Items.Clear()
        cmdCopy.Enabled = False
        SQL = " Select Abbreviation, Suffix, PatientID, FName,LName, MI, CaseStatusID, NoMoreAppointmentsInd, IMEStatusID, DOB, DOA  from Patients LEFT OUTER JOIN CaseTypes on CaseTypes.CaseTypeID=Patients.CaseTypeID "
        SQL &= " Order by PatientID"
        Reader = SQLGetDataReader(SQL)

        If Reader Is Nothing Then ListViewPatients.EndUpdate() : Exit Sub
        ListViewPatients.ListViewItemSorter = Nothing
        Dim Lst As List(Of ListViewItem) = New List(Of ListViewItem)
        If Reader.HasRows Then
            Do Until Reader.Read = False

                'LI = ListViewPatients.Items.Add(Reader("PatientID").ToString,CInt(Val(Reader("CaseStatusID").ToString) - 1))
                LI = New ListViewItem(Reader("PatientID").ToString, CInt(Val(Reader("CaseStatusID").ToString) - 1))
                If Reader("Suffix").ToString <> "" Then
                    LI.SubItems.Add(Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString & " " & Reader("Suffix").ToString)
                Else
                    LI.SubItems.Add(Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString)
                End If
                LI.ToolTipText = Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString & " " & Reader("Suffix").ToString
                LI.Tag = "" & Reader("PatientID").ToString
                LI.SubItems.Add(Reader("Abbreviation").ToString)
                If Val(Reader("IMEStatusID").ToString) = 1 Then
                    LI.ImageKey = "CHECK"
                Else
                    LI.ImageKey = "SORT0"
                End If
                'If gSQLGetSingleValue("Select count(*) from Patients where FName='" & Reader("FName").ToString.Trim & "' and LName='" & Reader("LName").ToString.Trim & "' and DOB='" & Reader("DOB").ToString.Trim & "' and DOA='" & Reader("DOA").ToString.Trim & "'") > 0 Then
                '    LI.BackColor = Color.YellowGreen
                'End If


                Lst.Add(LI)
            Loop
        End If
        ListViewPatients.Items.AddRange(Lst.ToArray)
        ListViewPatients.EndUpdate()
        lblCount.Text = Lst.Count & " Patients Loaded"
        Reader.Close()
        Reader.Dispose()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
            cmdCopy.Enabled = True
        Else
            cmdCopy.Enabled = False
        End If
        Cursor = Cursors.Default
    End Sub


    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        Dim Reader As SqlClient.SqlDataReader
        Dim ID As Long
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to copy" & vbCrLf & "No patient selected", MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
            Return
        End If
        If CallerForm.cmdUpdate.Enabled Then
            MsgBox("Unable to copy" & vbCrLf & "Please complete started process by clicking update or cancel button on the patient maintenance form.", MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
            Return
        End If

        ID = CLng(ListViewPatients.SelectedItems(0).Tag)
        Reader = SQLGetDataReader("Select FName, LName, DOB, DOA from Patients Where PatientID= " & ID)
        Reader.Read()
        If gSQLGetSingleValue("Select count(*) from Patients where FName='" & Reader("FName").ToString.Trim & "' and LName='" & Reader("LName").ToString.Trim & "' and DOB='" & Reader("DOB").ToString.Trim & "' and DOA='" & Reader("DOA").ToString.Trim & "'") > 0 Then
            CallerForm.TextBoxSearch.Text = Reader("FName").ToString.Trim & " " & Reader("LName").ToString.Trim

            If MsgBox("Attention duplicate record found!" & vbCrLf & vbCrLf & "Patient " & Reader("FName").ToString.Trim & " " & Reader("LName").ToString.Trim & vbCrLf & "DOB: " & CDate(Reader("DOB")).ToString("MM/dd/yyyy") & vbCrLf & "DOA: " & CDate(Reader("DOA")).ToString("MM/dd/yyyy") & vbCrLf & "is already exists." & vbCrLf & vbCrLf & "Continue import patient?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Attention") = MsgBoxResult.No Then
                If ListViewPatients.SelectedItems(0).ImageKey <> "CHECK" Then
                    If MsgBox("Mark patient " & Reader("FName").ToString.Trim & " " & Reader("LName").ToString.Trim & " as processed?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Attention") = MsgBoxResult.Yes Then
                        SQLUpdateData("Update Patients Set IMEStatusID=1 Where PatientId = " & ID)
                        ListViewPatients.SelectedItems(0).ImageKey = "CHECK"
                    End If
                End If
                Return
            End If
        End If

        CallerForm.cmdAddNew_Click(Nothing, Nothing)

        With CallerForm
            If Load_PatientProcedures() = False Then Return



            .LabelPreCertification.Visible = False
            .Loading = True

            .txtDOB.ForeColor = Color.Black
            .LabelDOB.ForeColor = Color.Black
            .LabelDOB.Text = "DOB"
            .lblNoMoreAppointmentsInd.ForeColor = Color.Black
            .SavePatientInsCompanyID = -1
            .SavePatientInsCompanyID1 = -1
            .ComboBoxClaimAddress.Items.Clear()
            .ToolStripButtonUnlockReading.Enabled = False
            .SaveSelectedItem = ListViewPatients.SelectedItems(0)
            Reader =
                SQLGetDataReader("Select Patients.*, Employees.FName +' '+ Employees.LName as UpdatedBy from Patients LEFT OUTER JOIN Employees on Patients.UpdatedByEmpID = Employees.EmpID Where PatientID=" & ID)
            'If Reader Is Nothing Then LockWindowUpdate(0) : Exit Sub
            .TabControl1.SuspendLayout()
            Reader.Read()
            .txtVehicleOwner.Text = Reader("VehicleOwner").ToString
            .txtPlaceOfAccident.Text = Reader("PlaceOfAccident").ToString
            If IsDate(Reader("TOA").ToString) Then .txtTOA.Text = CDate(Reader("TOA").ToString).ToString("HH:mm")
            .cboInjury.Text = Reader("Injury").ToString
            .txtPatientID.Text = Reader("PatientID").ToString
            .txtInsertedDT.Text = CDate(Reader("InsertedDT").ToString).ToString("MM/dd/yy")
            If IsDate(Reader("CaseStatusDate").ToString) Then
                .txtCaseStatusDT.Text = CDate(Reader("CaseStatusDate").ToString).ToString("MM/dd/yy")
            Else
                .txtCaseStatusDT.Text = ""
            End If
            gFindComboItemByValue(.ComboBoxCaseStatusID, CLng(Val(Reader("CaseStatusID").ToString)), True)
            .SaveCaseStatusID = CInt(Val(Reader("CaseStatusID").ToString))

            .TextBoxWebUid.Text = "PNT" & Reader("PatientID").ToString
            .TextBoxWebPassword.Text = Reader("WebPassword").ToString

            .txtFName.Text = Reader("FName").ToString
            .txtMI.Text = Reader("MI").ToString
            .txtLName.Text = Reader("LName").ToString
            .cboSuffix.Text = Reader("Suffix").ToString
            If IsDate(Reader("DOB").ToString) Then .txtDOB.Text = CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy")
            .ComboBoxSex.Text = Reader("Sex").ToString
            .txtSSN.Text = Reader("SSN").ToString
            .txtAddress1.Text = Reader("Address1").ToString
            .txtAddress2.Text = Reader("Address2").ToString
            .txtCity.Text = Reader("City").ToString
            .ComboBoxState.Text = Reader("State").ToString
            .ComboBoxStateOfAccident.Text = Reader("StateOfAccident").ToString
            .txtZip.Text = Reader("Zip").ToString
            .txtPhone1.Text = Reader("Phone1").ToString
            .txtPhone2.Text = Reader("Phone2").ToString
            .txtCellPhone.Text = Reader("CellPhone").ToString
            .txtEmail.Text = Reader("Email").ToString
            .txtComments.Text = Reader("Comments").ToString

            gFindComboItemByValue(.ComboBoxCaseTypeID, CLng(Val(Reader("CaseTypeID").ToString)), True)


            .CheckBoxNoMoreAppointmentsInd.Tag = CBool(Val(Reader("NoMoreAppointmentsInd").ToString))
            .chkInitialReportReceived.Checked = CBool(Val(Reader("InitialReportReceived").ToString))
            .chkInitialReportReceived.ForeColor = IIf(.chkInitialReportReceived.Checked, Color.Black, Color.Red)
            .chkPoliceReportReceived.Tag = Val(Reader("PoliceReportReceived").ToString)
            .chkPoliceReportReceived.Checked = CBool(Val(Reader("PoliceReportReceived").ToString))
            .chkPoliceReportReceived.ForeColor = IIf(.chkPoliceReportReceived.Checked, Color.Black, Color.Red)
            'CheckBoxAtWorkTime.Checked = CBool(Val(Reader("AtWorkTime").ToString))
            gFindComboItemByValue(.ComboBoxMaritalStatusID, CLng(Val(Reader("MaritalStatusID").ToString)), True)
            gFindComboItemByValue(.ComboBoxEmploymentStatusID, CLng(Val(Reader("EmploymentStatusID").ToString)), True)
            .txtOccupation.Text = Reader("Occupation").ToString
            .txtEmployerName.Text = Reader("EmployerName").ToString
            .txtEmployerAddress.Text = Reader("EmployerAddress").ToString
            .txtEmployerAddressCity.Text = Reader("EmployerAddressCity").ToString
            .cboEmployerAddressState.Text = Reader("EmployerAddressState").ToString
            .txtEmployerAddressZip.Text = Reader("EmployerAddressZip").ToString

            .txtEmployerPhone.Text = Reader("EmployerPhone").ToString
            If IsDate(Reader("DOA").ToString) Then .txtDOA.Text = CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy")
            If IsDate(Reader("ClaimEffectiveDT").ToString) Then _
                .txtClaimEffectiveDT.Text = CDate(Reader("ClaimEffectiveDT").ToString).ToString("MM/dd/yyyy")
            .txtClaimNumber.Text = Reader("ClaimNumber").ToString
            .txtClaimNumber1.Text = Reader("ClaimNumber1").ToString

            .txtPolicyHolderSSN.Text = Reader("PolicyHolderSSN").ToString
            .txtPolicyHolderSSN1.Text = Reader("PolicyHolderSSN1").ToString

            .txtPolicyHolderEmployerName.Text = Reader("PolicyHolderEmployerName").ToString
            .txtPolicyHolderEmployerName1.Text = Reader("PolicyHolderEmployerName1").ToString

            .txtPolicyHolderEmployerAddress.Text = Reader("PolicyHolderEmployerAddress").ToString
            .txtPolicyHolderEmployerAddress1.Text = Reader("PolicyHolderEmployerAddress1").ToString

            .txtPolicyHolderOccupation.Text = Reader("PolicyHolderOccupation").ToString
            .txtPolicyHolderOccupation1.Text = Reader("PolicyHolderOccupation1").ToString

            .txtPolicyHolderEmployerPhone.Text = Reader("PolicyHolderEmployerPhone").ToString
            .txtPolicyHolderEmployerPhone1.Text = Reader("PolicyHolderEmployerPhone1").ToString

            .txtPolicyHolderOtherDependents.Text = Reader("PolicyHolderOtherDependents").ToString
            .txtPolicyHolderOtherDependents1.Text = Reader("PolicyHolderOtherDependents1").ToString

            If IsDate(Reader("PolicyHolderBirthDate").ToString) Then _
                .txtPolicyHolderBirthDate.Text = CDate(Reader("PolicyHolderBirthDate").ToString).ToString("MM/dd/yyyy")
            If IsDate(Reader("PolicyHolderBirthDate1").ToString) Then _
                .txtPolicyHolderBirthDate1.Text = CDate(Reader("PolicyHolderBirthDate1").ToString).ToString("MM/dd/yyyy")

            .cboPatientAttorney.SelectedIndex = gFindComboItemByText(.cboPatientAttorney, Reader("Attorney").ToString.Trim, True)
            If .cboPatientAttorney.SelectedIndex = -1 Then .cboPatientAttorney.Text = Reader("Attorney").ToString.Trim

            .txtEmergencyInfo.Text = Reader("EmergencyInfo").ToString
            gFindComboItemByValue(.ComboBoxInjuryID, CLng(Val(Reader("InjuryID").ToString)), True)
            gFindComboItemByValue(.ComboBoxPatientTypeID, CLng(Val(Reader("PatientTypeID").ToString)), True)
            If .ComboBoxPatientTypeID.SelectedIndex > -1 Then
                .SavePatientTypeID = CLng(Val(Reader("PatientTypeID").ToString))
            End If
            'gFindComboItemByValue(.ComboBoxReferringCompanyID, CLng(Val(Reader("ReferringCompanyID").ToString)), True)
            '.ComboBoxReferringCompanyID.Tag = CLng(Val(Reader("ReferringCompanyID").ToString))
            '.ComboBoxReferringDoctor.SelectedIndex = gFindComboItemByDescription(.ComboBoxReferringDoctor, Reader("ReferringDoctor").ToString.Trim, True)
            'If .ComboBoxReferringDoctor.SelectedIndex = -1 Then
            ' .ComboBoxReferringDoctor.Text = Reader("ReferringDoctor").ToString.Trim
            'End If
            gFindComboItemByValue(.ComboBoxTransportationCompanyID, CLng(Val(Reader("TransportationCompanyID").ToString)), True)

            'txtUpdatedDT.Text = CDate(Reader("UpdatedDT").ToString).ToString("MM/dd/yy")
            gFindComboItemByValue(.ComboBoxPatientTypeID, CLng(Val(Reader("PatientTypeID").ToString)), True)

            'INSURANCE COMPANY / CLAIM
            'Primary Insurance
            gFindComboItemByValue(.cboBillingCompany, CLng(Val(Reader("BillingCompanyID").ToString)), True)


            .SaveCasyTypeID = CLng(Val(Reader("CaseTypeID").ToString))

            Dim InsuranceCompanyName As String = SQLGetSingleValueString("select CompanyName from InsuranceCompanies where CompanyID = " & Val(Reader("InsuranceCompanyID").ToString))
            .ComboBoxInsuranceCompanyID.SelectedIndex = gFindComboItemByDescription(.ComboBoxInsuranceCompanyID, InsuranceCompanyName, True)
            'gFindComboItemByValue(.ComboBoxInsuranceCompanyID, CLng(Val(Reader("InsuranceCompanyID").ToString)), True)
            'If .ComboBoxInsuranceCompanyID.SelectedIndex > -1 Then _
            '.SavePatientInsCompanyID = CType(.ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value

            .txtPolicyNumber.Text = Reader("PolicyNumber").ToString
            .txtIDNumber.Text = Reader("IDNumber").ToString
            .txtGroupNumber.Text = Reader("GroupNumber").ToString

            .txtPolicyHolderFName.Text = Reader("PolicyHolderFName").ToString
            .txtPolicyHolderMI.Text = Reader("PolicyHolderMI").ToString
            .txtPolicyHolderLName.Text = Reader("PolicyHolderLName").ToString
            .txtPolicyHolderAddress.Text = Reader("PolicyHolderAddress").ToString
            .txtPolicyHolderCity.Text = Reader("PolicyHolderCity").ToString
            .ComboBoxPolicyHolderState.Text = Reader("PolicyHolderState").ToString
            .txtPolicyHolderZip.Text = Reader("PolicyHolderZip").ToString
            .txtPolicyHolderPhone.Text = Reader("PolicyHolderPhone").ToString

            .txtAdjuster.Text = Reader("AdjusterName").ToString
            .txtAdjusterPhone.Text = Reader("AdjusterPhone").ToString
            .txtAdjusterComments.Text = Reader("AdjusterComments").ToString

            'Secondary Insurance
            'gFindComboItemByValue(.ComboBoxInsuranceCompanyID1, CLng(Val(Reader("InsuranceCompanyID1").ToString)), True)
            'If .ComboBoxInsuranceCompanyID1.SelectedIndex > -1 Then _
            '    .SavePatientInsCompanyID1 = CType(.ComboBoxInsuranceCompanyID1.SelectedItem, ValueDescription).Value
            .txtPolicyNumber1.Text = Reader("PolicyNumber1").ToString
            .txtIDNumber1.Text = Reader("IDNumber1").ToString
            .txtGroupNumber1.Text = Reader("GroupNumber1").ToString
            gFindComboItemByValue(.ComboBoxRelationToInsuredID1, CLng(Val(Reader("RelationToInsuredID1").ToString)), True)
            .txtPolicyHolderFName1.Text = Reader("PolicyHolderFName1").ToString
            .txtPolicyHolderMI1.Text = Reader("PolicyHolderMI1").ToString
            .txtPolicyHolderLName1.Text = Reader("PolicyHolderLName1").ToString
            .txtPolicyHolderAddress1.Text = Reader("PolicyHolderAddress1").ToString
            .txtPolicyHolderCity1.Text = Reader("PolicyHolderCity1").ToString

            .txtAdjuster1.Text = Reader("AdjusterName1").ToString
            .txtAdjusterPhone1.Text = Reader("AdjusterPhone1").ToString
            .txtAdjusterComments1.Text = Reader("AdjusterComments1").ToString

            .ComboBoxPolicyHolderState1.Text = Reader("PolicyHolderState1").ToString
            .txtPolicyHolderZip1.Text = Reader("PolicyHolderZip1").ToString
            .txtPolicyHolderPhone1.Text = Reader("PolicyHolderPhone1").ToString
            .CheckBoxNoMoreAppointmentsInd.Checked = CBool(Val(Reader("NoMoreAppointmentsInd").ToString))
            .CheckBoxInsuranceVerifyed.Checked = CBool(Val(Reader("InsuranceVerifyed").ToString))
            .CheckBoxInsurance1Verifyed.Checked = CBool(Val(Reader("Insurance1Verifyed").ToString))

            .txtWCCarrierCaseNumber.Text = Reader("WCCarrierCaseNumber").ToString
            .txtWCCarrierCode.Text = Reader("WCCarrierCode").ToString
            .txtWCCaseNumber.Text = Reader("WCCaseNumber").ToString
            .txtWCPatientAccountNumber.Text = Reader("WCPatientAccountNumber").ToString
            .txtWCEmployerInsuranceCarrier.Text = Reader("WCEmployerInsuranceCarrier").ToString
            .txtWCInsuranceCarrierAddress.Text = Reader("WCInsuranceCarrierAddress").ToString
            .txtWCInsuranceCarrierAddressCity.Text = Reader("WCInsuranceCarrierAddressCity").ToString
            .cboWCInsuranceCarrierAddressState.Text = Reader("WCInsuranceCarrierAddressState").ToString
            .txtWCInsuranceCarrierAddressZip.Text = Reader("WCInsuranceCarrierAddressZip").ToString

            'If Reader("LockedByIP").ToString <> "" And CInt(Val(Reader("LockByID").ToString)) <> gCurrentEmployee.EmpID Then
            '    If gPing(Reader("LockedByIP").ToString) = True Then
            '        lblLocked.Text = "Profile Readonly. Locked On " & CDate(Reader("LockDT").ToString).ToString("MM/dd/yyyy hh:mm") & "  By: " & Reader("LockedByName").ToString
            '        lblLocked.Visible = True
            '    Else
            '        lblLocked.Visible = False
            '    End If
            'End If
            .LabelEffectiveDate.ForeColor = Color.Black
            If IsDate(Reader("ClaimEffectiveDT").ToString) And IsDate(Reader("DOA").ToString) Then
                If CDate(Reader("ClaimEffectiveDT").ToString) >= CDate(Reader("DOA").ToString) Then
                    .LabelEffectiveDate.ForeColor = Color.IndianRed
                End If
            End If

            gFindComboItemByValue(.ComboBoxClaimAddress, CLng(Val(Reader("ClaimAddressID").ToString)), True)
            .ComboBoxClaimAddress.Tag = Val(Reader("ClaimAddressID").ToString)

            gFindComboItemByValue(.ComboBoxClaimAddress1, CLng(Val(Reader("ClaimAddressID1").ToString)), True)
            .ComboBoxClaimAddress1.Tag = Val(Reader("ClaimAddressID1").ToString)

            If IsDate(Reader("NF2Date").ToString) And Reader("NF2Date").ToString <> "" Then
                .chkNF2.Checked = True
                .txtNF2.Text = CDate(Reader("NF2Date").ToString).ToString("MM/dd/yy")
            Else
                .chkNF2.Checked = False
                .txtNF2.Text = ""
            End If

            If IsDate(.txtDOB.Text) Then
                If gYearsFromDate(.txtDOB.Text) < gUnderAge Then
                    .LabelDOB.ForeColor = Color.IndianRed
                    .LabelDOB.Text = "DOB Underage"
                    .txtDOB.ForeColor = Color.IndianRed
                Else
                    .LabelDOB.ForeColor = Color.Black
                    .LabelDOB.Text = "DOB"
                    .txtDOB.ForeColor = Color.Black
                End If
            Else
                .LabelDOB.ForeColor = Color.Black
                .LabelDOB.Text = "DOB"
                .txtDOB.ForeColor = Color.Black
            End If
            gFindComboItemByValue(.ComboBoxCaseTypeID, CLng(Val(Reader("CaseTypeID").ToString)), True)
            .SaveCasyTypeID = CLng(Val(Reader("CaseTypeID").ToString))
            If Val(CType(.ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value) <> 3 Then 'Private
                .txtDOA.AccessibleDescription = "1"
                .txtSSN.AccessibleDescription = ""
            Else
                .txtDOA.AccessibleDescription = ""
                .txtSSN.AccessibleDescription = "1"
            End If


            gFindComboItemByValue(.ComboBoxRelationToInsuredID1, CLng(Val(Reader("RelationToInsuredID1").ToString)), True)
            gFindComboItemByValue(.ComboBoxRelationToInsuredID, CLng(Val(Reader("RelationToInsuredID").ToString)), True)
            .TabControl1_SelectedIndexChanged(Nothing, Nothing)
            .Validate_Billing_Data()
            .Loading = False
            .TabControl1.ResumeLayout()
            If .ListViewProcedures.Columns.Count = 0 Then
                .Load_ProcedureColumns()
            End If
            If .ListViewProcedures.Columns.Count > 0 Then
                .pr_SortingColumn = .ListViewProcedures.Columns(0)
                For Each CLMN As ColumnHeader In .ListViewProcedures.Columns
                    CLMN.ImageKey = "SORT0"
                Next
                .ListViewProcedures.Columns(0).ImageKey = "SORT1"
                .ListViewProcedures.ListViewItemSorter = New ListViewComparer(0, SortOrder.Ascending)
                .ListViewProcedures.Sort()

            End If
            Process_Documents()
            gListViewRestoreDefaultColumnWidth(.ListViewPatientsRelated)
            gListViewRestoreDefaultColumnWidth(.ListViewProcedures)
            CallerForm.cmdEdit.Enabled = False
            'ComboBoxTreatingProviderID.SelectedIndex = -1
            .LoadingData = False
            SQLUpdateData("Update Patients Set IMEStatusID=1 Where PatientId = " & ID)
            ListViewPatients.SelectedItems(0).ImageKey = "CHECK"
        End With
    End Sub


    Private Sub Process_Documents(Optional ByVal DoNotSelect As Boolean = False)
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        With CallerForm
            If ListViewPatients.SelectedItems.Count = 0 Then
                Exit Sub
            End If
            .ListViewDocs.Items.Clear()
            .m_SortingColumnDocuments = .ListViewDocs.Columns(0)
            If Not .m_SortingColumnDocuments Is Nothing Then .m_SortingColumnDocuments.ImageKey = "SORT0"
            .ListViewDocs.Columns(0).ImageKey = "SORT0"
            .ListViewDocs.Columns(1).ImageKey = "SORT0"
            SQL =
                "SELECT DocumentImage, DocumentID, PatientID, DocumentName, DocumentProfileID, InsertedDate, Documents.PatientProcedureID, Employees.Fname + ' ' + Employees.Lname AS EmpName FROM " &
                " Documents LEFT OUTER JOIN Employees ON Documents.InsertedBy = Employees.EmpID " &
                " WHERE PatientID = " & ListViewPatients.SelectedItems(0).Tag & " ORDER BY DocumentID"

            Reader = SQLGetDataReader(SQL)
            .ListViewDocs.ListViewItemSorter = Nothing
            If Reader Is Nothing Then Exit Sub
            SQL = "INSERT INTO Documents (PatientID, DocumentProfileID, DocumentImage, DocumentName, InsertedBy, InsertedDate, PatientProcedureID) "
            SQL = SQL & " VALUES(@PatientID, @DocumentProfileID, @DocumentImage, @DocumentName, @InsertedBy, @InsertedDate, @PatientProcedureID)"
            Do Until Reader.Read = False
                Using adoConnect = New SqlConnection(gConnectionString & "; Connection Timeout=60")
                    adoConnect.Open()
                    Using cmd = New SqlCommand(SQL, adoConnect)
                        cmd.CommandTimeout = 60
                        cmd.Parameters.AddWithValue("@PatientID", 0)
                        cmd.Parameters.AddWithValue("@DocumentProfileID", Val(Reader("DocumentProfileID").ToString))
                        cmd.Parameters.AddWithValue("@DocumentImage", CType(Reader("DocumentImage"), Byte()))
                        cmd.Parameters.AddWithValue("@DocumentName", Reader("DocumentName").ToString)
                        cmd.Parameters.AddWithValue("@InsertedBy", gCurrentEmployee.EmpID)
                        cmd.Parameters.AddWithValue("@InsertedDate", Reader("InsertedDate").ToString)
                        cmd.Parameters.AddWithValue("@PatientProcedureID", 0)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                Dim NewDocID As Long
                NewDocID = gSQLGetSingleValue("Select IDENT_CURRENT('Documents')")
                LI = .ListViewDocs.Items.Add(Reader("DocumentName").ToString)
                LI.SubItems.Add(CDate(Reader("InsertedDate").ToString).ToString("MM/dd/yyyy"))
                LI.SubItems.Add(Reader("EmpName").ToString)
                LI.Tag = NewDocID
                LI.SubItems(1).Tag = Val(Reader("DocumentProfileID").ToString)
            Loop


            SQL = "Select ID, PatientID, Data, DocName, DocDate, Employees.Fname + ' ' + Employees.Lname AS EmpName  FROM PatientRTFDocuments  LEFT OUTER JOIN Employees ON PatientRTFDocuments.AddedBy = Employees.EmpID WHERE PatientID = " & ListViewPatients.SelectedItems(0).Tag & " order by id "

            Reader = gSQLGetDataReaderAsync(SQL).Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                SQL = "INSERT INTO PatientRTFDocuments (PatientID, Data, DocName, DocDate, AddedBy ) "
                SQL = SQL & " VALUES (" & ListViewPatients.SelectedItems(0).Tag & ", '" & Reader("Data").ToString & "', '" & Reader("DocName").ToString & "', '" & Reader("DocDate").ToString & "', " & gCurrentEmployee.EmpID & " )"
                gSQLUpdateData(SQL)
                Dim doc As RTFDocument = New RTFDocument()
                doc.ID = Val(Reader("ID").ToString)
                doc.PatientID = Reader("PatientID").ToString
                doc.DocName = Reader("DocName").ToString
                doc.Data = Reader("Data").ToString
                doc.DocDate = CDate(Reader("DocDate").ToString).ToString("MM/dd/yyyy")

                LI = .ListViewDocs.Items.Add(doc.DocName)
                LI.SubItems.Add(doc.DocDate)
                LI.SubItems.Add(Reader("EmpName").ToString)
                LI.Tag = doc
                LI.ToolTipText = doc.DocName
                LI.SubItems(1).Tag = 999
                LI.SubItems.Add("")
            Loop

            .ListViewDocs_ColumnClick(.ListViewDocs, New ColumnClickEventArgs(0))
            If .ListViewDocs.Items.Count > 0 And DoNotSelect = False Then
                .ListViewDocs.Items(0).Selected = True
                .ListViewDocs.Items(0).EnsureVisible()
                .ListViewDocs_SelectedIndexChanged(Nothing, Nothing)

            End If
            gListViewRestoreDefaultColumnWidth(.ListViewDocs)
er:
        End With
    End Sub
    Public Function Load_PatientProcedures() As Boolean
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim sLI As ListViewItem.ListViewSubItem
        Dim SQL As String
        Dim PreCertificationRequired As Boolean
        With CallerForm


            .ListViewProcedures.Items.Clear()
            If ListViewPatients.SelectedItems.Count = 0 Then
                Return False
            End If
            SQL =
                "SELECT  PatientProcedures.PreCertificationDT, PatientProcedures.PACSAltNumber, PatientProcedures.Comments, PatientProcedures.DoNotBillInd, PatientProcedures.DoNotBillAction, Diagnostics.DiagID, ProcedureTypeID, Diagnostics.DiagName ,  PatientProcedures.DoNotBillInd, PatientProcedures.BillingProviderID, PatientProcedures.ReferringDoctor, Schedule.ScheduleDateTime, PatientProcedures.ProcID, Procedures.ProcName, PatientProcedures.PatientProcedureID, PatientProcedures.ProcedureStatusID,  PatientProcedureStatuses.Description AS StatusDescription, Employees.Fname + ' ' + Employees.Lname + ' ' + Employees.Alias AS TRName, EmployeesBP.Fname + ' ' + EmployeesBP.Lname +' '+ EmployeesBP.Alias AS BPName, PatientProcedures.TreatingProviderID , ReferringOffices.OfficeName as RefOffice "
            SQL = SQL &
                  " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID LEFT OUTER JOIN Employees ON PatientProcedures.TreatingProviderID = Employees.EmpID  LEFT OUTER JOIN Employees EmployeesBP ON PatientProcedures.BillingProviderID = EmployeesBP.EmpID  LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Diagnostics on PatientProcedures.DiagID = Diagnostics.DiagID LEFT OUTER JOIN ReferringOffices on ReferringOfficeID = ReferringOffices.OfficeID "
            SQL = SQL & " Where PatientProcedures.PatientID = " & ListViewPatients.SelectedItems(0).Tag
            SQL = SQL & " ORDER BY PatientProcedures.PatientProcedureID "

            Reader = SQLGetDataReader(SQL)
            If Reader Is Nothing Then Return False
            .ListViewProcedures.ListViewItemSorter = Nothing
            PatientsProviders.Reset_Data()
            Do Until Reader.Read = False

                PatientsProviders.Open_Data(Reader("ProcName").ToString, Val(Reader("DiagId").ToString()), Reader("BPName").ToString, Reader("TRName").ToString, Reader("ReferringDoctor").ToString, Reader("RefOffice").ToString)
                PatientsProviders.StartPosition = FormStartPosition.CenterParent
                PatientsProviders.ShowDialog(Me)

                If PatientsProviders.Result <> DialogResult.Yes Then
                    .Cancel_Edit(False)
                    .ListViewProcedures.Items.Clear()
                    Return False
                End If

                Dim BillingProviderId As Integer = CType(PatientsProviders.ComboBoxBillingProvider.SelectedItem, ValueDescription).Value
                Dim BillingProviderName As String = CType(PatientsProviders.ComboBoxBillingProvider.SelectedItem, ValueDescription).Description
                Dim TreatingProviderID As Integer = CType(PatientsProviders.ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value
                Dim TreatingProviderName As String = CType(PatientsProviders.ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Description
                Dim RefferingOfficeID As Integer = CType(PatientsProviders.ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value
                Dim ReferringDoctor As String = CType(PatientsProviders.ComboBoxReferringDoctor.SelectedItem, ValueDescription).Description
                Dim ProcedureName As String = CType(PatientsProviders.cboProcedure.SelectedItem, ValueDescription).Description
                Dim ProcId As Integer = CType(PatientsProviders.cboProcedure.SelectedItem, ValueDescription).Value
                gFindComboItemByValue(.ComboBoxReferringCompanyID, CLng(RefferingOfficeID), True)
                .ComboBoxReferringCompanyID.Tag = CLng(RefferingOfficeID)
                .ComboBoxReferringDoctor.SelectedIndex = gFindComboItemByDescription(.ComboBoxReferringDoctor, ReferringDoctor, True)
                If .ComboBoxReferringDoctor.SelectedIndex = -1 Then
                    .ComboBoxReferringDoctor.Text = ReferringDoctor.ToString.Trim
                End If


                If IsDate(Reader("ScheduleDateTime").ToString) Then
                    If CDate(Reader("ScheduleDateTime").ToString).Date < Now.Date And Val(Reader("ProcedureStatusID").ToString) = 1 Then
                        LI = .ListViewProcedures.Items.Add(CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy hh:mm"), 4)
                    Else
                        LI = .ListViewProcedures.Items.Add(CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy hh:mm"), CInt(Val(Reader("ProcedureStatusID").ToString)))
                    End If
                Else
                    LI = .ListViewProcedures.Items.Add("", 0)
                End If
                'LI.SubItems(6).Tag
                If (Val(Reader("DoNotBillInd").ToString) = 1 And Val(Reader("DoNotBillAction").ToString) = 0) Or Val(Reader("ProcedureStatusID").ToString) = 3 Then
                    LI.ImageIndex = 3
                    LI.ToolTipText = "Do Not Bill / Canceled"
                Else
                    LI.ToolTipText = Reader("StatusDescription").ToString
                End If
                LI.UseItemStyleForSubItems = False
                LI.Name = Reader("ProcedureTypeID").ToString
                LI.SubItems.Add(ProcedureName)
                LI.SubItems(0).Tag = 0 'Reader("PatientProcedureID").ToString
                LI.SubItems(1).Tag = ProcId
                LI.Tag = 0

                LI.SubItems.Add(TreatingProviderName)
                LI.SubItems(2).Tag = TreatingProviderID
                LI.SubItems.Add(BillingProviderName).Tag = Val(BillingProviderId)
                LI.SubItems.Add(ReferringDoctor)
                LI.SubItems.Add(Reader("DiagName").ToString).Tag = Reader("DiagID").ToString
                If Val(Reader("ProcedureTypeID").ToString) = 3 Or Val(Reader("ProcedureTypeID").ToString) = 4 Then
                    LI.ForeColor = Color.Blue
                End If
                Dim ProcScheduleDT As ListViewItem.ListViewSubItem = LI.SubItems.Add(Replace(Reader("Comments").ToString, vbCrLf, ", "))
                ProcScheduleDT.Tag = Reader("ScheduleDateTime").ToString
                Dim ProcStatus As ListViewItem.ListViewSubItem = LI.SubItems.Add(Replace(Reader("PACSAltNumber").ToString, vbCrLf, ", "))
                ProcStatus.Tag = Val(Reader("ProcedureStatusID").ToString)

                If gOfficeTypeID = 3 Then
                    If IsDate(Reader("PreCertificationDT").ToString) Then
                        sLI = LI.SubItems.Add(CDate(Reader("PreCertificationDT").ToString).ToShortDateString)
                        sLI.BackColor = Color.LightGreen
                    Else
                        sLI = LI.SubItems.Add("")
                        sLI.BackColor = Color.LightPink
                        PreCertificationRequired = True
                    End If
                End If
                If IsDate(Reader("ScheduleDateTime").ToString) Then
                    If CDate(Reader("ScheduleDateTime").ToString).Date < Now.Date And Val(Reader("ProcedureStatusID").ToString) = 1 Then
                        LI.ToolTipText = "No Show"
                    End If
                End If

            Loop
            .LabelPreCertification.Visible = PreCertificationRequired
            Reader.Close()
            Reader.Dispose()
            If .ListViewProcedures.Items.Count > 0 Then
                .ListViewProcedures.Items(0).Selected = True
                .ListViewProcedures.Items(0).EnsureVisible()
                gListViewRestoreDefaultColumnWidth(.ListViewProcedures)
            End If
            Return True
        End With
    End Function
    Sub SaveToJsonFile(obj As Object, filePath As String)
        If File.Exists(filePath) Then
            File.Delete(filePath)
        End If
        Dim json As String = JsonConvert.SerializeObject(obj)
        File.WriteAllText(filePath, json)
    End Sub
    Function ReadFromJsonFile(Of T)(filePath As String) As T
        Dim json As String = File.ReadAllText(filePath)
        Return JsonConvert.DeserializeObject(Of T)(json)
    End Function

    Private Sub ListViewPatients_DoubleClick(sender As Object, e As EventArgs) Handles ListViewPatients.DoubleClick
        If ListViewPatients.SelectedItems.Count = 0 Then
            Return
        End If
        cmdCopy_Click(Nothing, Nothing)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        lblCount.Text = ""
        If File.Exists(tempFileName) Then
            Dim ccb As SqlConnectionStringBuilder = ReadFromJsonFile(Of SqlConnectionStringBuilder)(tempFileName)
            If Not ccb Is Nothing Then
                txtDataSource.Text = ccb.DataSource
                txtUserID.Text = ccb.UserID
                txtPassword.Text = ccb.Password
                txtDatabase.Text = ccb.InitialCatalog
                ccb.ConnectRetryCount = 2
                ccb.IntegratedSecurity = False
                ccb.Pooling = False
                cmdCopy.Enabled = False
                cmdPrint.Enabled = False

                SQLConnection = ccb.ConnectionString
                imgWait1.Visible = True
                imgWait1.Refresh()
                If ValidateConnection(SQLConnection) Then
                    lblStatus.Text = "Loading Patients..."
                    Application.DoEvents()
                    PatientsProviders.Load_Data(0)
                    Load_Data()
                    Load_Patients()
                    If ListViewPatients.Items.Count > 0 Then
                        cmdCopy.Enabled = True
                        cmdPrint.Enabled = True
                    End If

                End If
                imgWait1.Visible = False
            End If
        Else
            txtDatabase.Text = gSQLServerDatabase
        End If
    End Sub

    Private Sub ListViewPatients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewPatients.SelectedIndexChanged
        'gHighlightListviewItem(ListViewPatients, False, True)
        gHighlightListviewItem(ListViewPatients)
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    Private Sub frmImportPatients_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        If ListViewPatients.Items.Count > 0 Then
            gPrintListview(ListViewPatients, PrinterOrientation.Portrait, True, txtDatabase.Text)
        End If

    End Sub

    Private Sub ListViewPatients_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewPatients.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewPatients.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumn.Text =             m_SortingColumn.Text.Mid(2)
            m_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumn.Text = "> " & m_SortingColumn.Text
        'Else
        'm_SortingColumn.Text = "< " & m_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.ImageKey = "SORT1"
        Else
            m_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewPatients.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewPatients.Sort()
    End Sub


    ''''''''''''''''''''''''''''   DATABASE
    Public Function ValidateConnection(TestString As String) As Boolean
        Cursor = Cursors.WaitCursor
        lblStatus.Text = "Connecting Database. Please wait..."
        Application.DoEvents()
        Dim ErrorCount As Integer
Retry:
        If TestString = "" Then Exit Function
        Using Cnn As New SqlConnection(TestString)
            Cnn.ConnectionString = TestString
            Cnn.ClearPool(Cnn)
            Try
                Dim task As Task = Task.Run(Async Function()
                                                Await Cnn.OpenAsync()
                                            End Function)
                task.Wait()
                'Cnn.Open()
                Cnn.Close()
                SQLConnection = TestString
                Cursor = Cursors.Default
                lblStatus.Text = ""
                Return True
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If ErrorCount < 3 Then
                    Application.DoEvents()
                    Threading.Thread.Sleep(500)
                    GoTo Retry
                End If
                Cursor = Cursors.Default
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Error")
                lblStatus.Text = ""
                Return False
            End Try
        End Using
    End Function
    Public Function SQLGetDataReader(SQL As String) As SqlDataReader
Er:
        Dim Cnn As SqlConnection = New SqlConnection(SQLConnection)
        Dim Reader As SqlDataReader

        If Cnn Is Nothing Then
            Return Nothing
        End If
        Try
            Dim task As Task = Task.Run(Async Function()
                                            Await Cnn.OpenAsync()
                                        End Function)
            task.Wait()
            'Cnn.Open()

            Dim Cmd As New SqlCommand(SQL, Cnn)
            Dim ErrorCount As Integer
            Cmd.CommandTimeout = 300
            Reader = Cmd.ExecuteReader
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
            Return Nothing
        End Try
        Return Reader
    End Function

    Public Function SQLGetSingleValueString(SQL As String) As String
        Dim ErrorCount = 0
        Dim Ret
        Dim RetValue As String = ""
er:
        Using Cnn As SqlConnection = New SqlConnection(SQLConnection)

            Cnn.Open()

            Using Cmd As New SqlCommand(SQL, Cnn)
                Try
                    Ret = Cmd.ExecuteScalar()
                    If Ret Is Nothing Then
                        RetValue = ""
                    Else
                        If Ret Is Nothing OrElse Ret Is DBNull.Value Then
                            RetValue = ""
                        Else
                            RetValue = Ret
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                End Try
            End Using
            'End Using
            Cnn.Close()
            Return RetValue
        End Using
    End Function
    Public Function SQLUpdateData(SQL As String) As Boolean
        Dim ErrorCount = 0
        Dim Ret As Boolean = False
        Using Cnn As SqlConnection = New SqlConnection(SQLConnection)
            Cnn.Open()

            Using Cmd As New SqlCommand(SQL, Cnn)
                Try
                    Cmd.ExecuteNonQuery()
                    Ret = True
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                End Try

            End Using
            Cnn.Close()
        End Using
        Return Ret
        'End Using
    End Function

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListViewPatients.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
        ResetPatientIndicatorToolStripMenuItem.Visible = ListViewPatients.SelectedItems(0).ImageKey = "CHECK"
        ToolStripSeparator1.Visible = ListViewPatients.SelectedItems(0).ImageKey = "CHECK"
    End Sub

    Private Sub ImportPatientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportPatientToolStripMenuItem.Click
        If ListViewPatients.SelectedItems.Count = 0 Then
            Return
        End If
        cmdCopy_Click(Nothing, Nothing)
    End Sub

    Private Sub ResetPatientIndicatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetPatientIndicatorToolStripMenuItem.Click
        If ListViewPatients.SelectedItems.Count = 0 Then
            Return
        End If
        Dim ID As Long = CLng(ListViewPatients.SelectedItems(0).Tag)
        SQLUpdateData("Update Patients Set IMEStatusID=0 Where PatientId = " & ID)
        ListViewPatients.SelectedItems(0).ImageKey = "SORT0"
    End Sub
End Class
