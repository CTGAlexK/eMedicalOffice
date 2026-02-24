Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmImageDiskRequest
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim SQl As String
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process order. No Patient selected.", MsgBoxStyle.Exclamation)
            ListViewPatients.Focus()
            Exit Sub
        End If
        If ListViewProcedures.SelectedItems.Count = 0 Then
            MsgBox("Unable to process order. No Procedure selected.", MsgBoxStyle.Exclamation)
            ListViewProcedures.Focus()
            Exit Sub
        End If
        If ListViewProcedures.SelectedItems(0).ForeColor = Color.DarkRed Then
            MsgBox("Unable to process order. The selected procedure has not been completed.", MsgBoxStyle.Exclamation)
            ListViewProcedures.Focus()
            Exit Sub
        End If

        If cboShipTo.SelectedIndex = -1 Then
            MsgBox("Unable to process order. The Ship To should be selected.", MsgBoxStyle.Exclamation)
            cboShipTo.Focus()
            Exit Sub
        End If
        If CType(cboShipTo.SelectedItem, ValueDescription).Value1 <> 3 Then
            If ComboBoxOther.Text = "" Then
                MsgBox("Unable to process order. the Recipient should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxOther.Focus()
                Exit Sub
            End If
            If txtCity.Text = "" Then
                MsgBox("Unable to process order. The Address City should be specified.", MsgBoxStyle.Exclamation)
                txtCity.Enabled = True
                txtCity.Focus()
                Exit Sub
            End If
            If ComboBoxState.Text = "" Then
                MsgBox("Unable to process order. The Address State should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxState.Enabled = True
                ComboBoxState.Focus()
                Exit Sub
            End If
            If txtZip.Text = "" Then
                MsgBox("Unable to process order. The Address Zip Cose should be specified.", MsgBoxStyle.Exclamation)
                txtZip.Enabled = True
                txtZip.Focus()
                Exit Sub
            End If
        End If

        If TextBoxAmount.Text = "" Then
            TextBoxAmount.Text = 0
        End If
        If IsNumeric(TextBoxAmount.Text) = False Then
            MsgBox("Unable to process order. Invalid Invoice amount specified. The Invoice amount should be numeric value.", MsgBoxStyle.Exclamation)
            TextBoxAmount.Focus()
            TextBoxAmount.SelectAll()
            Exit Sub
        End If
        If CDbl(TextBoxAmount.Text) > CDbl(TextBoxAmount.Tag) Then
            If CType(cboShipTo.SelectedItem, ValueDescription).Value1 = 3 Then
                If MsgBox("The Disk Price: " & CDbl(TextBoxAmount.Tag).ToString("c") & vbCrLf & vbCrLf & "Paid Amount : " & CDbl(TextBoxAmount.Text).ToString("c") & vbCrLf & vbCrLf & "Is it correct?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    TextBoxAmount.Focus()
                    TextBoxAmount.SelectAll()
                    Exit Sub
                End If
            Else
                If MsgBox("The Disk Price: " & CDbl(TextBoxAmount.Tag).ToString("c") & vbCrLf & vbCrLf & "The Amount To Be Invoiced: " & CDbl(TextBoxAmount.Text).ToString("c") & vbCrLf & vbCrLf & "Is it correct?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    TextBoxAmount.Focus()
                    TextBoxAmount.SelectAll()
                    Exit Sub
                End If
            End If
        End If
        If Val(TextBoxAmount.Text) < Val(TextBoxAmount.Tag) Then
            Dim ApprovedByID As Long
            Dim ApprovedByName As String
            If gCurrentEmployee.PositionID > 3 Then
                If CType(cboShipTo.SelectedItem, ValueDescription).Value1 = 3 Then
                    frmSupervisorApproval.LabelMsg.Text = "Image Disk Price: " & CDbl(TextBoxAmount.Tag).ToString("c") & vbCrLf & "Paid Amount: " & CDbl(TextBoxAmount.Text).ToString("c")
                Else
                    frmSupervisorApproval.LabelMsg.Text = "Image Disk Price: " & CDbl(TextBoxAmount.Tag).ToString("c") & vbCrLf & "Amount To Be Invoices: " & CDbl(TextBoxAmount.Text).ToString("c")
                End If
                If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    frmSupervisorApproval.Dispose()
                    Exit Sub
                End If
                ApprovedByID = frmSupervisorApproval.SupervisorID
                ApprovedByName = frmSupervisorApproval.SupervisorName
                frmSupervisorApproval.Dispose()
            Else
                If CType(cboShipTo.SelectedItem, ValueDescription).Value1 = 3 Then
                    If MsgBox("Attention " & vbCrLf & vbCrLf & "Image Disk Price: " & CDbl(TextBoxAmount.Tag).ToString("c") & vbCrLf & "Paid Amount: " & CDbl(TextBoxAmount.Text).ToString("c") & vbCrLf & vbCrLf & "Are you Authorizing this transaction?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                Else
                    If MsgBox("Attention " & vbCrLf & vbCrLf & "Image Disk Price: " & CDbl(TextBoxAmount.Tag).ToString("c") & vbCrLf & "Amount To Be Invoiced: " & CDbl(TextBoxAmount.Text).ToString("c") & vbCrLf & vbCrLf & "Are you Authorizing this transaction?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
                ApprovedByID = gCurrentEmployee.EmpID
                ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
            End If

            If CType(cboShipTo.SelectedItem, ValueDescription).Value1 = 3 Then
                gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.ImageDiskRequested, "Procedure: " & ListViewProcedures.SelectedItems(0).Text & " Disk Price: " & CDbl(TextBoxAmount.Tag).ToString("c") & " Amount Paid: " & CDbl(TextBoxAmount.Text).ToString("c"), ApprovedByName)
            Else
                gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.ImageDiskRequested, "Procedure: " & ListViewProcedures.SelectedItems(0).Text & " Disk Price: " & CDbl(TextBoxAmount.Tag).ToString("c") & " Amount Invoiced: " & CDbl(TextBoxAmount.Text).ToString("c"), ApprovedByName)
            End If
        Else
            gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.ImageDiskRequested, "Procedure: " & ListViewProcedures.SelectedItems(0).Text & " Disk Price: " & CDbl(TextBoxAmount.Tag).ToString("c") & " Amount Invoiced: " & CDbl(TextBoxAmount.Text).ToString("c"), gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
        End If
        Dim TR As DataRow
        'BillID, PatientProcedureID, InsCompanyID, ClaimAddressID, ReferringCompanyID, ReferringDoctor, PatientID, PaidAmount, RequestDT, RequestBy
        Using TA = New SqlClient.SqlDataAdapter("SELECT * FROM ImageDiskRequests Where 1=2", gConnectionString)
            Using CB = New SqlClient.SqlCommandBuilder(TA)
                CB.ConflictOption = ConflictOption.OverwriteChanges
                Using dTab = New DataTable("ImageDiskRequests")
                    TA.Fill(dTab)
                    TR = dTab.NewRow

                    TR("BillID") = Val(ListViewProcedures.SelectedItems(0).SubItems(3).Text)
                    TR("Recepient") = ComboBoxOther.Text.Trim.ToSafeSQLString()
                    TR("Address") = txtAddress.Text.Trim.ToSafeSQLString()
                    TR("City") = txtCity.Text.Trim.ToSafeSQLString()
                    TR("State") = ComboBoxState.Text.ToSafeSQLString()
                    TR("Zip") = txtZip.Text.Trim.ToSafeSQLString()
                    Select Case CType(cboShipTo.SelectedItem, ValueDescription).Value1
                        Case 1
                            TR("StatusID") = 0
                            TR("InvoiceAmount") = Val(TextBoxAmount.Text)
                            TR("InvoicePerProcedure") = Val(TextBoxAmount.Text) / ListViewProcedures.CheckedItems.Count
                            TR("PaidAmount") = 0
                        Case 2, 4
                            TR("StatusID") = 1
                            TR("InvoiceAmount") = Val(TextBoxAmount.Text)
                            TR("InvoicePerProcedure") = Val(TextBoxAmount.Text) / ListViewProcedures.CheckedItems.Count
                            TR("PaidAmount") = 0
                        Case Else
                            TR("StatusID") = 2
                            TR("InvoiceAmount") = CDbl(TextBoxAmount.Tag)
                            TR("InvoicePerProcedure") = Val(TextBoxAmount.Text) / ListViewProcedures.CheckedItems.Count
                            TR("PaidAmount") = Val(TextBoxAmount.Text)
                    End Select
                    TR("RequestTypeID") = CType(cboShipTo.SelectedItem, ValueDescription).Value1
                    TR("PatientID") = ListViewPatients.SelectedItems(0).Tag
                    TR("RequestDT") = Now.ToString
                    TR("RequestBy") = gCurrentEmployee.EmpID.ToString
                    TR("OfficeID") = gOfficeID
                    TR("StatusDT") = Now.ToString
                    TR("StatusBy") = gCurrentEmployee.EmpID.ToString
                    dTab.Rows.Add(TR)
                    TA.UpdateCommand = CB.GetUpdateCommand(True)
                    Try
                        TA.Update(dTab)
                        dTab.AcceptChanges()
                    Catch ex As Exception
                        TopMost = False
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                        log.Error(ex.Message, ex)
                    End Try
                    dTab.Dispose() : CB.Dispose() : TA.Dispose()




                End Using
            End Using
        End Using
        Dim NewID As Long = gSQLGetSingleValue("Select IDENT_CURRENT('ImageDiskRequests')")
        For Each LI In ListViewProcedures.CheckedItems
            Select Case CType(cboShipTo.SelectedItem, ValueDescription).Value1
                Case 1  ' Patient's Insurance Company
                    SQl = "INSERT INTO ImageDiskProcedures (RequestID, PatientProcedureID, StatusID) VALUES(" & NewID & ", " & Val(LI.Tag) & ",1)"
                Case Else
                    SQl = "INSERT INTO ImageDiskProcedures (RequestID, PatientProcedureID, StatusID) VALUES(" & NewID & ", " & Val(LI.Tag) & ",0)"
            End Select
            gSQLUpdateData(SQl)
        Next
        LI = ListViewOrders.Items.Add(Now.ToString("MM/dd/yy"))
        LI.Tag = NewID
        LI.SubItems.Add(ListViewProcedures.SelectedItems(0).Text)
        LI.SubItems.Add(ComboBoxOther.Text.Trim)
        Select Case CType(cboShipTo.SelectedItem, ValueDescription).Value1
            Case 1
                LI.SubItems(1).Tag = 0
                LI.SubItems.Add("Invoiced & Shipped")
                LI.ToolTipText = "Procedure: " & ListViewProcedures.SelectedItems(0).Text & vbCrLf & "Recipient: " & ComboBoxOther.Text.Trim & vbCrLf & "Status: " & "Invoiced & Shipped"
                frmImageDiskInvoice.Setup_report(LI.Tag)
                frmImageDiskInvoice.ShowDialog(Me)
                frmImageDiskInvoice.Dispose()
                If gPacsConnectionString <> "" Then
                    If MsgBox("Attention!" & vbCrLf & vbCrLf & "The image disk invoice has been created." & vbCrLf & vbCrLf & "The disk should be created and shipped with the invoice!" & vbCrLf & vbCrLf & "Would you like to Burn CD now?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        frmCDBurn.Load_Data(Val(LI.Tag))
                        frmCDBurn.ShowDialog(Me)
                        frmCDBurn.Dispose()
                    End If
                Else
                    MsgBox("Attention!" & vbCrLf & vbCrLf & "The image disk invoice has been created." & vbCrLf & vbCrLf & "The disk should be created and shipped with the invoice!", MsgBoxStyle.Exclamation)
                End If
            Case 3
                LI.SubItems(1).Tag = 2
                LI.SubItems.Add("Paid")
                LI.ToolTipText = "Procedure: " & ListViewProcedures.SelectedItems(0).Text & vbCrLf & "Recipient: " & ComboBoxOther.Text.Trim & vbCrLf & "Status: " & "Paid"
                frmImageDiskCashReceipt.Setup_report(LI.Tag)
                frmImageDiskCashReceipt.ShowDialog(Me)
                frmImageDiskCashReceipt.Dispose()
                If gPacsConnectionString <> "" Then
                    If MsgBox("The Image CD Invoice has been created.!" & vbCrLf & vbCrLf & "Would you like to Burn CD now?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        frmCDBurn.Load_Data(Val(LI.Tag))
                        frmCDBurn.ShowDialog(Me)
                        frmCDBurn.Dispose()
                    End If
                Else
                    MsgBox("The Image CD Invoice has been created.!", MsgBoxStyle.Exclamation)
                End If
            Case Else
                LI.SubItems(1).Tag = 1
                LI.SubItems.Add("Invoiced")
                LI.ToolTipText = "Procedure: " & ListViewProcedures.SelectedItems(0).Text & vbCrLf & "Recipient: " & ComboBoxOther.Text.Trim & vbCrLf & "Status: " & "Invoiced"
                frmImageDiskInvoice.Setup_report(LI.Tag)
                frmImageDiskInvoice.ShowDialog(Me)
                frmImageDiskInvoice.Dispose()
        End Select
        If CType(cboShipTo.SelectedItem, ValueDescription).Value1 = 4 And ComboBoxOther.SelectedIndex = -1 Then
            gSQLUpdateData("INSERT INTO ImageDiskOtherCompanies (CompanyName, Address, City, State, Zip) VALUES ('" & ComboBoxOther.Text.Trim.ToSafeSQLString() & "', '" & txtAddress.Text.Trim.ToSafeSQLString() & "', '" & txtCity.Text.Trim.ToSafeSQLString() & "', '" & ComboBoxState.Text.ToSafeSQLString() & "', '" & txtZip.Text.Trim.ToSafeSQLString() & "')")
            Load_Other()
        End If
        ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmRequestImageDisk_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewOrders, ReadWrite.sWrite)
    End Sub

    Private Sub frmImageDiskRequest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            Load_Patients()
        End If
    End Sub

    Private Sub frmRequestImageDisk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead)
        gListview_Settings(Me, ListViewOrders, ReadWrite.sRead)
        ButtonCDLabel.Visible = (gCDLabelPrinter.Trim <> "")
        If ComboBoxState.Items.Count = 0 Then Load_Data()
        If gPacsConnectionString = "" Then
            Button4.Visible = False
            BurnCDToolStripMenuItem.Visible = False
            ToolStripSeparator2.Visible = False
            Button4.Visible = False
        End If
        ToolStripMenuPrintCD.Visible = (gCDLabelPrinter.Trim <> "")
    End Sub

    Public Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = ""
        SQL = ""
        ComboBoxState.Items.Clear()
        Reader = gSQLGetDataReader("Select State, ShowOrder from States Order by ShowOrder")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxState.Items.Add(Reader("State").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        Load_Other()
    End Sub

    Private Sub Load_ShipTo(ByVal ID)
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        SQL = "SELECT     InsuranceCompanyAddresses.AddressName AS Ins1Name, InsuranceCompanyAddresses.Address AS Ins1Address, InsuranceCompanyAddresses.City AS Ins1City, "
        SQL &= " InsuranceCompanyAddresses.State AS Ins1State, InsuranceCompanyAddresses.Zip AS Ins1Zip, InsuranceCompanyAddresses_1.AddressName AS Ins2Name, "
        SQL &= " InsuranceCompanyAddresses_1.Address AS Ins2Address, InsuranceCompanyAddresses_1.City AS Ins2City, InsuranceCompanyAddresses_1.State AS Ins2State, "
        SQL &= " InsuranceCompanyAddresses_1.Zip AS Ins2Zip, ReferringOffices.OfficeName AS RefName, Patients.Address1 + ' ' + Patients.Address2 AS RefAddress, "
        SQL &= " ReferringOffices.City AS RefCity, ReferringOffices.State AS RefState, ReferringOffices.Zip AS RefZip, "
        SQL &= " InsuranceCompanyAddresses.AddressID AS Ins1ID, InsuranceCompanyAddresses_1.AddressID AS Ins2ID, ReferringOffices.OfficeID AS RefID "
        SQL &= " FROM         Patients LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID LEFT OUTER JOIN InsuranceCompanyAddresses InsuranceCompanyAddresses_1 ON Patients.ClaimAddressID1 = InsuranceCompanyAddresses_1.AddressID LEFT OUTER JOIN InsuranceCompanyAddresses ON Patients.ClaimAddressID = InsuranceCompanyAddresses.AddressID "
        SQL &= "  WHERE Patients.PatientID = " & ID
        cboShipTo.Items.Clear()
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            If Reader("Ins1ID").ToString <> "" Then cboShipTo.Items.Add(New ValueDescription(Reader("Ins1ID").ToString, Reader("Ins1Name").ToString, 1, Reader("Ins1Address").ToString, Reader("Ins1City").ToString, Reader("Ins1State"), Reader("Ins1Zip").ToString))
            If Reader("Ins2ID").ToString <> "" Then cboShipTo.Items.Add(New ValueDescription(Reader("Ins2ID").ToString, Reader("Ins2Name").ToString, 1, Reader("Ins2Address").ToString, Reader("Ins2City").ToString, Reader("Ins2State"), Reader("Ins2Zip").ToString))
            If Reader("RefID").ToString <> "" Then cboShipTo.Items.Add(New ValueDescription(Reader("RefID").ToString, Reader("RefName").ToString, 2, Reader("RefAddress").ToString, Reader("RefCity").ToString, Reader("RefState"), Reader("RefZip").ToString))
            cboShipTo.Items.Add(New ValueDescription(0, "Cash Payment", 3))
            cboShipTo.Items.Add(New ValueDescription(0, "Other", 4))
        End If

    End Sub

    Private Sub Load_Other()
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        ComboBoxOther.Items.Clear()
        SQL = "SELECT  1 as AddressType, AddressID as ID, AddressName as CompanyName, Address, City, State, Zip  FROM InsuranceCompanyAddresses "
        SQL &= " UNION "
        SQL &= " SELECT 2 as AddressType, ID, CompanyName, Address, City, State, Zip FROM ImageDiskOtherCompanies  Order By CompanyName"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxOther.Items.Add(New ValueDescription(Reader("ID").ToString, Reader("CompanyName").ToString, Reader("AddressType").ToString, Reader("Address").ToString, Reader("City").ToString, Reader("State").ToString, Reader("Zip").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Load_Patients()
    End Sub

    Public Sub Load_Patients()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        TextBoxSearch.Text = TextBoxSearch.Text.Trim
        TextBoxBillNumber.Text = TextBoxBillNumber.Text.Trim
        If TextBoxSearch.Text = "" And TextBoxBillNumber.Text = "" Then
            'MsgBox("Unable to search. Please specify a search criteria.", MsgBoxStyle.Exclamation)
            'TextBoxSearch.Focus()
            'Exit Sub
        End If
        cboShipTo.Enabled = False
        cboShipTo.SelectedIndex = -1
        ComboBoxOther.Enabled = False
        txtAddress.Enabled = False
        txtCity.Enabled = False
        ComboBoxState.Enabled = False
        txtZip.Enabled = False
        ComboBoxOther.SelectedIndex = -1
        ComboBoxState.SelectedIndex = -1
        ComboBoxState.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtZip.Text = ""
        ComboBoxOther.Text = ""
        cmdUpdate.Enabled = False
        TextBoxAmount.Enabled = False
        ButtonDeleteOrder.Enabled = False
        ButtonPrint.Enabled = False
        ListViewPatients.Items.Clear()
        ListViewProcedures.Items.Clear()
        ListViewOrders.Items.Clear()

        TextBoxAmount.Text = ""
        SQL = "SELECT   DISTINCT   Patients.ReferringDoctor, Patients.FName, Patients.MI, Patients.LName, Patients.PatientID FROM Patients LEFT OUTER JOIN Bills ON Patients.PatientID = Bills.PatientID "
        If IsNumeric(TextBoxBillNumber.Text) Then
            SQL &= " WHERE (Bills.BillID = " & Val(TextBoxBillNumber.Text)
            SQL = SQL & " or AttorneyCaseNumber = " & Val(TextBoxBillNumber.Text) & ")"
        Else
            If IsNumeric(TextBoxSearch.Text) Then
                SQL &= "Where Patients.PatientID = " & Val(TextBoxSearch.Text)
            Else
                SQL &= "Where FName like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' or LName like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' or SSN Like '" & TextBoxSearch.Text.ToSafeSQLString() & "%'"
            End If
        End If
        SQL &= " and Patients.OfficeID = " & gOfficeID
        SQL &= " ORDER BY Patients.FName, Patients.MI, Patients.LName"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewPatients.Items.Add(Reader("PatientID").ToString)
            LI.SubItems.Add(Reader("Fname").ToString & " " & Reader("MI").ToString & " " & Reader("Lname").ToString)
            LI.SubItems(1).Tag = Reader("ReferringDoctor").ToString
            LI.Tag = Reader("PatientID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged
        ListViewProcedures.Items.Clear()
        ListViewOrders.Items.Clear()
        '
        cboShipTo.Enabled = False
        cboShipTo.SelectedIndex = -1
        ComboBoxOther.Enabled = False
        txtAddress.Enabled = False
        txtCity.Enabled = False
        ComboBoxState.Enabled = False
        txtZip.Enabled = False
        ComboBoxOther.SelectedIndex = -1
        ComboBoxState.SelectedIndex = -1
        ComboBoxState.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtZip.Text = ""
        ComboBoxOther.Text = ""
        '
        TextBoxAmount.Text = ""
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        cmdUpdate.Enabled = False
        TextBoxAmount.Enabled = False
        ButtonDeleteOrder.Enabled = False
        ButtonPrint.Enabled = False
        Load_Procedures(Val(ListViewPatients.SelectedItems(0).Tag))
        Load_Orders(Val(ListViewPatients.SelectedItems(0).Tag))
        Load_ShipTo(Val(ListViewPatients.SelectedItems(0).Tag))
    End Sub

    Private Sub Load_Procedures(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        Dim IMG As String
        Dim ToolTip As String
        ListViewProcedures.Items.Clear()
        SQL = "SELECT DISTINCT "
        SQL &= "       Employees.EmpID, Employees.Fname + ' ' + Employees.Lname AS EmpName,        PatientProcedureStatuses.ProcedureStatusID, PatientProcedures.PatientProcedureID, BillProcedures.BillID, Procedures.ProcName, PatientProcedureStatuses.Description AS Status, Schedule.ScheduleDateTime "
        SQL &= " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID LEFT OUTER JOIN BillProcedures ON PatientProcedures.PatientProcedureID = BillProcedures.PatientProcedureID "
        SQL &= " INNER JOIN Employees ON PatientProcedures.BillingProviderID =  Employees.EmpID "
        If IsNumeric(TextBoxBillNumber.Text) Then
            SQL &= " INNER JOIN BILLS ON BillProcedures.BillID =  BILLS.BillID "
        End If
        SQL &= " WHERE (PatientProcedures.PatientID = " & ID & ")"
        If IsNumeric(TextBoxBillNumber.Text) Then
            SQL &= " AND (BillProcedures.BillID = " & Val(TextBoxBillNumber.Text)
            SQL = SQL & " or AttorneyCaseNumber = " & Val(TextBoxBillNumber.Text) & ")"
        End If
        SQL &= " ORDER BY PatientProcedureStatuses.ProcedureStatusID DESC, Procedures.ProcName ASC"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub

        Do Until Reader.Read = False
            If Val(Reader("ProcedureStatusID").ToString) = 2 Then
                IMG = "COMPLETE"
                ToolTip = "Procedure Completed"
            Else
                IMG = "INCOMPLETE"
                ToolTip = "Procedure Not Completed. Disk creation is not available."
            End If
            LI = ListViewProcedures.Items.Add(Reader("ProcName").ToString, IMG)
            LI.Tag = Reader("PatientProcedureID").ToString
            LI.ToolTipText = ToolTip
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                LI.SubItems.Add(CDate(Reader("ScheduleDateTime")).ToString("MM/dd/yy"))
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Reader("Status").ToString)
            LI.SubItems.Add(Reader("BillID").ToString)
            If Val(Reader("ProcedureStatusID").ToString) <> 2 Then
                LI.ForeColor = Color.DarkRed
            End If
            LI.SubItems.Add(Reader("EmpName").ToString).Tag = Reader("EmpID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewProcedures.Items.Count > 0 Then
            ListViewProcedures.Items(0).Selected = True
            ListViewProcedures.Items(0).EnsureVisible()
            ListViewProcedures_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewProcedures_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewProcedures.ItemChecked
        Dim Li As ListViewItem
        Dim CheckedLi As ListViewItem
        Dim SaveBillID As Long
        Dim CheckedBillID As Long
        If e.Item.ForeColor = Color.DarkRed And e.Item.Checked Then
            MsgBox("Unable to produce disk for this procedure. This procedure has not been completted.", MsgBoxStyle.Exclamation)
            e.Item.Checked = False
            Exit Sub
        End If
        If e.Item.Checked Then
            For Each Li In ListViewProcedures.CheckedItems
                If Val(Li.SubItems(4).Tag) <> e.Item.SubItems(4).Tag Then
                    MsgBox("Unable to add procedures from the different Billing Providers to the same Image Disk request." & vbCrLf & vbCrLf & "Create separate request for each Billing Provider", MsgBoxStyle.Exclamation)
                    e.Item.Checked = False
                    Exit Sub
                End If
            Next
        End If

        If ListViewProcedures.CheckedItems.Count = 0 Then
            cboShipTo.Enabled = False
            cboShipTo.SelectedIndex = -1
            cmdUpdate.Enabled = False
            TextBoxAmount.Enabled = False
            Exit Sub
        Else
            If cboShipTo.SelectedIndex > -1 Then
                Dim SV As ValueDescription = CType(cboShipTo.SelectedItem, ValueDescription)
                Select Case SV.Value1
                    Case 1 ' Insurance,
                        TextBoxAmount.Text = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                        TextBoxAmount.Tag = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                    Case 2 'Refferring Company
                        TextBoxAmount.Text = gImageDiskPriceForMedicalOffice * ListViewProcedures.CheckedItems.Count
                        TextBoxAmount.Tag = gImageDiskPriceForMedicalOffice * ListViewProcedures.CheckedItems.Count
                    Case 3  'Cash
                        TextBoxAmount.Text = gImageDiskPriceCash * ListViewProcedures.CheckedItems.Count
                        TextBoxAmount.Tag = gImageDiskPriceCash * ListViewProcedures.CheckedItems.Count
                        TextBoxAmount.Enabled = True
                    Case 4 'Other
                        TextBoxAmount.Text = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                        TextBoxAmount.Tag = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                End Select
            End If
            cboShipTo.Enabled = True
        End If
    End Sub

    Private Sub ListViewProcedures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewProcedures.SelectedIndexChanged

    End Sub

    Private Sub Load_Orders(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        SQL = "SELECT   ImageDiskRequests.BillID,  ImageDiskRequests.ID, ImageDiskRequests.RequestDT, ImageDiskRequestsStatuses.Description AS Status, ImageDiskRequests.StatusID, ImageDiskRequests.Recepient "
        SQL &= " FROM ImageDiskRequests INNER JOIN ImageDiskRequestsStatuses ON ImageDiskRequests.StatusID = ImageDiskRequestsStatuses.StatusID "
        SQL &= " WHERE ImageDiskRequests.PatientID = " & ID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            If IsDate(Reader("RequestDT")) Then
                LI = ListViewOrders.Items.Add(CDate(Reader("RequestDT")).ToString("MM/dd/yy"))
            Else
                LI = ListViewOrders.Items.Add("")
            End If
            LI.Tag = Reader("ID").ToString

            LI.SubItems.Add(Reader("Recepient").ToString.Trim)
            LI.SubItems(1).Tag = Reader("StatusID")
            LI.SubItems.Add(Reader("Status").ToString)
            LI.ToolTipText = "Recipient: " & Reader("Recepient").ToString.Trim & vbCrLf & "Status: " & Reader("Status").ToString
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub TextBoxBillNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxBillNumber.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, TextBoxBillNumber, False)
    End Sub

    Private Sub TextBoxBillNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxBillNumber.TextChanged
        If TextBoxBillNumber.Text.Trim <> "" Then
            TextBoxSearch.Text = ""
        End If
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        If TextBoxSearch.Text.Trim <> "" Then
            TextBoxBillNumber.Text = ""
        End If
    End Sub

    Private SaveToolTipItem As ListViewItem

    Private Sub ListViewOrders_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewOrders.MouseDown
        Dim HI As ListViewHitTestInfo
        HI = ListViewOrders.HitTest(e.X, e.Y)
        If HI.Item Is Nothing Then
            ListViewOrders.ContextMenuStrip = Nothing
        Else
            ListViewOrders.ContextMenuStrip = ContextMenuStrip2
        End If
    End Sub

    Private Sub Delete_Order()
        Dim CashInd As Boolean
        Dim PaidAmount As Double
        Dim ID As Long
        If ListViewOrders.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete order. No order selected.", MsgBoxStyle.Exclamation)
            ListViewOrders.Focus()
            Exit Sub
        End If
        ID = ListViewOrders.SelectedItems(0).Tag
        If ListViewOrders.SelectedItems(0).SubItems(2).Text = "Cash" Then
            PaidAmount = gSQLGetSingleValue("Select PaidAmount from ImageDiskRequests Where ID = " & ID)
            CashInd = True
        End If
        'If ListViewOrders.SelectedItems(0).SubItems(1).Tag <> 1 And ListViewOrders.SelectedItems(0).SubItems(2).Text <> "Cash" Then
        'MsgBox("Unable to delete order when order status: " & ListViewOrders.SelectedItems(0).SubItems(2).Text)
        'ListViewOrders.Focus()
        'Exit Sub
        'End If
        If MsgBox("You have requested to delete the order for the procedure: " & vbCrLf & vbCrLf & ListViewOrders.SelectedItems(0).SubItems(1).Text & vbCrLf & "Placed on " & ListViewOrders.SelectedItems(0).Text & vbCrLf & vbCrLf & "Please confirm...", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLDeleteRecord("DELETE From ImageDiskRequests Where ID = " & ID)
        ListViewOrders.Items.Remove(ListViewOrders.SelectedItems(0))
        If CashInd = True Then
            MsgBox("Order has been deleted." & vbCrLf & vbCrLf & "Please refund the amount paid: " & PaidAmount.ToString("c"), MsgBoxStyle.Information)
            gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.ImageDiskRequestRemoved, "Cash Image Disk Order Removed. Amount Refunded: " & PaidAmount.ToString("c"), gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
        Else
            MsgBox("Order has been deleted." & vbCrLf & vbCrLf & "Please destroy the printed invoice.", MsgBoxStyle.Information)
            gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.ImageDiskRequestRemoved, "Image Disk Order Removed." & PaidAmount.ToString("c"), gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
        End If
    End Sub

    Private Sub ListViewOrders_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewOrders.MouseMove
        Dim HI As ListViewHitTestInfo
        HI = ListViewOrders.HitTest(e.X, e.Y)
        If HI.Item Is Nothing Then
            SaveToolTipItem = Nothing
            ToolTip1.SetToolTip(ListViewOrders, "")
        Else
            If Not SaveToolTipItem Is HI.Item Then
                SaveToolTipItem = HI.Item
                ToolTip1.SetToolTip(ListViewOrders, HI.Item.ToolTipText)
                Debug.Print(HI.Item.Text)
            End If
        End If
    End Sub

    Private Sub ListViewOrders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewOrders.SelectedIndexChanged
        Dim LI As ListViewItem = Nothing
        If ListViewOrders.SelectedItems.Count = 0 Then
            ButtonCDLabel.Enabled = False
            ButtonPrint.Text = "Print"
            ButtonDeleteOrder.Enabled = False
            ButtonPrint.Enabled = False
            ButtonEmvelope.Enabled = False
            Button4.Enabled = False
            Exit Sub
        Else
            ButtonCDLabel.Enabled = True
            ButtonDeleteOrder.Enabled = True
            ButtonEmvelope.Enabled = False
            ButtonPrint.Enabled = True
            Button4.Enabled = True
            LI = ListViewOrders.SelectedItems(0)
        End If
        If LI.SubItems(1).Text = "Cash" Then
            ButtonEmvelope.Enabled = False
            ButtonPrint.Text = "Print Receipt"
        Else
            ButtonEmvelope.Enabled = True
            ButtonPrint.Text = "Print Invoice"
        End If

    End Sub

    Private Sub TextBoxAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAmount.GotFocus
        TextBoxAmount.SelectionStart = 0
        TextBoxAmount.SelectionLength = TextBoxAmount.Text.Length
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAmount.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, TextBoxBillNumber)
    End Sub

    Private Sub TextBoxAmount_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBoxAmount.MouseDown
        If TextBoxAmount.Text = "" Then
            OriginalPriceToolStripMenuItem.Visible = False
        Else
            If Val(TextBoxAmount.Text) <> Val(TextBoxAmount.Tag) Then
                OriginalPriceToolStripMenuItem.Visible = True
            Else
                OriginalPriceToolStripMenuItem.Visible = False
            End If
        End If
    End Sub

    Private Sub TextBoxAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxAmount.TextChanged

    End Sub

    Private Sub OriginalPriceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginalPriceToolStripMenuItem.Click
        If cboShipTo.SelectedItem Is Nothing Then
            TextBoxAmount.Text = ""
            TextBoxAmount.Tag = ""
        Else
            Dim SV As ValueDescription = CType(cboShipTo.SelectedItem, ValueDescription)
            Select Case SV.Value1
                Case 1 ' Insurance,
                    TextBoxAmount.Text = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                    TextBoxAmount.Tag = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                Case 2 'Refferring Company
                    TextBoxAmount.Text = gImageDiskPriceForMedicalOffice * ListViewProcedures.CheckedItems.Count
                    TextBoxAmount.Tag = gImageDiskPriceForMedicalOffice * ListViewProcedures.CheckedItems.Count
                Case 3  'Cash
                    TextBoxAmount.Text = gImageDiskPriceCash * ListViewProcedures.CheckedItems.Count
                    TextBoxAmount.Tag = gImageDiskPriceCash * ListViewProcedures.CheckedItems.Count
                Case 4 'Other
                    TextBoxAmount.Text = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                    TextBoxAmount.Tag = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
            End Select
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Delete_Order()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeleteOrder.Click
        Delete_Order()
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        Dim LI As ListViewItem = Nothing
        If ListViewOrders.SelectedItems.Count = 0 Then
            ButtonPrint.Text = "Print"
            MsgBox("Unable to process your request. No Order Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            LI = ListViewOrders.SelectedItems(0)
        End If
        If LI.SubItems(1).Text = "Cash" Then
            frmImageDiskCashReceipt.Setup_report(LI.Tag)
            frmImageDiskCashReceipt.ShowDialog(Me)
            frmImageDiskCashReceipt.Dispose()
        Else
            frmImageDiskInvoice.Setup_report(LI.Tag)
            frmImageDiskInvoice.ShowDialog(Me)
            frmImageDiskInvoice.Dispose()
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEmvelope.Click
        Dim LI As ListViewItem = Nothing
        Dim RequestID As Long
        If ListViewOrders.SelectedItems.Count = 0 Then
            ButtonPrint.Text = "Print"
            MsgBox("Unable to process your request. No Order Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            LI = ListViewOrders.SelectedItems(0)
        End If
        RequestID = LI.Tag

        frmImageDiskInvoiceEnvelope.Setup_report(RequestID)
        frmImageDiskInvoiceEnvelope.ShowDialog(Me)
        frmImageDiskInvoiceEnvelope.Dispose()
    End Sub

    Private Sub ComboBoxOther_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxOther.KeyUp
        'sSearchComboBox_KeyUp(ComboBoxOther, e, False)
        gComboboxAutoComplete(ComboBoxOther, e, False)
        ComboBoxOther_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cboShipTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipTo.SelectedIndexChanged
        If cboShipTo.SelectedItem Is Nothing Then
            ComboBoxOther.Enabled = False
            ComboBoxOther.SelectedIndex = -1
            ComboBoxOther.Enabled = False
            txtAddress.Enabled = False
            txtCity.Enabled = False
            ComboBoxState.Enabled = False
            txtZip.Enabled = False
            TextBoxAmount.Enabled = False
            ComboBoxOther.Text = ""
            cmdUpdate.Enabled = False
            ComboBoxState.Text = ""
            txtAddress.Text = ""
            txtCity.Text = ""
            txtZip.Text = ""
            ComboBoxOther.Text = ""
            Exit Sub
        End If
        cmdUpdate.Enabled = True
        Dim SV As ValueDescription = CType(cboShipTo.SelectedItem, ValueDescription)
        Select Case SV.Value1
            Case 1 ' Insurance,
                ComboBoxOther.SelectedIndex = -1
                TextBoxAmount.Text = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                TextBoxAmount.Tag = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                ComboBoxOther.Text = SV.Description
                txtAddress.Text = SV.Fld1
                txtCity.Text = SV.Fld2
                ComboBoxState.Text = SV.Fld3
                txtZip.Text = SV.Fld4
                ComboBoxOther.Enabled = False
                txtAddress.Enabled = False
                txtCity.Enabled = False
                ComboBoxState.Enabled = False
                txtZip.Enabled = False
                TextBoxAmount.Enabled = True
            Case 2 'Refferring Company
                ComboBoxOther.SelectedIndex = -1
                TextBoxAmount.Text = gImageDiskPriceForMedicalOffice * ListViewProcedures.CheckedItems.Count
                TextBoxAmount.Tag = gImageDiskPriceForMedicalOffice * ListViewProcedures.CheckedItems.Count
                ComboBoxOther.Text = SV.Description
                txtAddress.Text = SV.Fld1
                txtCity.Text = SV.Fld2
                ComboBoxState.Text = SV.Fld3
                txtZip.Text = SV.Fld4
                ComboBoxOther.Enabled = False
                txtAddress.Enabled = False
                txtCity.Enabled = False
                ComboBoxState.Enabled = False
                txtZip.Enabled = True
                TextBoxAmount.Enabled = True
            Case 3  'Cash
                TextBoxAmount.Text = gImageDiskPriceCash * ListViewProcedures.CheckedItems.Count
                TextBoxAmount.Tag = gImageDiskPriceCash * ListViewProcedures.CheckedItems.Count
                ComboBoxOther.Text = "Cash"
                txtAddress.Text = ""
                txtCity.Text = ""
                ComboBoxState.SelectedIndex = -1
                txtZip.Text = ""
                ComboBoxOther.Text = ""
                ComboBoxOther.Enabled = False
                txtAddress.Enabled = False
                txtCity.Enabled = False
                ComboBoxState.Enabled = False
                txtZip.Enabled = False
                TextBoxAmount.Enabled = True
            Case 4 'Other
                TextBoxAmount.Text = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                TextBoxAmount.Tag = gImageDiskPriceForInsuranceCompany * ListViewProcedures.CheckedItems.Count
                ComboBoxOther.Text = ""
                txtAddress.Text = ""
                txtCity.Text = ""
                ComboBoxState.SelectedIndex = -1
                txtZip.Text = ""
                ComboBoxOther.Text = ""
                TextBoxAmount.Enabled = False
                ComboBoxOther.Enabled = True
                txtAddress.Enabled = True
                txtCity.Enabled = True
                ComboBoxState.Enabled = True
                txtZip.Enabled = True
                TextBoxAmount.Enabled = True
        End Select
    End Sub

    Private Sub ComboBoxOther_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxOther.SelectedIndexChanged
        If ComboBoxOther.SelectedIndex = -1 Then
            txtAddress.Enabled = True
            txtCity.Enabled = True
            ComboBoxState.Enabled = True
            txtZip.Enabled = True
            txtAddress.Text = ""
            txtCity.Text = ""
            ComboBoxState.SelectedIndex = -1
            txtZip.Text = ""
        Else
            Dim SV As ValueDescription = CType(ComboBoxOther.SelectedItem, ValueDescription)
            txtAddress.Text = SV.Fld1
            txtCity.Text = SV.Fld2
            ComboBoxState.Text = SV.Fld3
            txtZip.Text = SV.Fld4
            txtAddress.Enabled = True
            txtCity.Enabled = True
            ComboBoxState.Enabled = True
            txtZip.Enabled = True
        End If
    End Sub

    Private Sub txtZip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZip.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, txtZip, False)
    End Sub

    Private Sub txtZip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZip.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim LI As ListViewItem
        If ListViewOrders.SelectedItems.Count = 0 Then
            MsgBox("Unable to Burn CD. No CD Invoice selected.")
        End If
        LI = ListViewOrders.SelectedItems(0)
        frmCDBurn.Load_Data(Val(LI.Tag))
        frmCDBurn.ShowDialog(Me)
        frmCDBurn.Dispose()
    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCDLabel.Click
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim InvoiceID As String
        Cursor = Cursors.WaitCursor
        Dim LI As ListViewItem
        Application.DoEvents()
        If ListViewOrders.SelectedItems.Count = 0 Then
            ButtonPrint.Text = "Print"
            MsgBox("Unable to print CD Label. No request selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            LI = ListViewOrders.SelectedItems(0)
        End If
        InvoiceID = LI.Tag

        Try
            CR = New rptImageCDDisk

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("RequestID", InvoiceID)
            If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gCDLabelPrinter

            CR.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click_3(sender As Object, e As EventArgs) Handles Button2.Click
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim InvoiceID As String
        Cursor = Cursors.WaitCursor
        Dim LI As ListViewItem
        Application.DoEvents()
        Application.DoEvents()
        If ListViewOrders.SelectedItems.Count = 0 Then
            ButtonPrint.Text = "Print"
            MsgBox("Unable to print CD Label. No request selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            LI = ListViewOrders.SelectedItems(0)
        End If
        InvoiceID = LI.Tag

        Try
            If gCDEnvelopeLabelType = 1 Then
                CR = New rptImageDiskEnvelopeLabel
            Else
                CR = New rptCDShippingLabel
            End If

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("CDInvoiceID", InvoiceID)
            If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
            'Set Label Size to Priter Paper Size
            Dim doctoprint As New System.Drawing.Printing.PrintDocument()
            doctoprint.PrinterSettings.PrinterName = gPrinterFileLabel
            CR.PrintOptions.PaperSize = doctoprint.DefaultPageSettings.PaperSize.RawKind
            ''''''''''''''''''''''''

            CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
            CR.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonTools_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonTools.MouseDown
        If ListViewOrders.SelectedItems.Count = 0 Then
            ListViewOrders.BackColor = Color.OrangeRed
            Application.DoEvents()
            MsgBox("Unable to process your request. No Order Selected.", MsgBoxStyle.Exclamation)
            ListViewOrders.BackColor = Color.White
            ListViewOrders.Focus()
            Exit Sub
        Else
            ContextMenuStripTools.Show(ButtonTools, e.Location)
        End If
    End Sub

    Private Sub DeleteInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteInvoiceToolStripMenuItem.Click
        Delete_Order()
    End Sub

    Private Sub PrintInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintInvoiceToolStripMenuItem.Click
        Dim LI As ListViewItem = Nothing
        If ListViewOrders.SelectedItems.Count = 0 Then
            ButtonPrint.Text = "Print"
            MsgBox("Unable to process your request. No Order Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            LI = ListViewOrders.SelectedItems(0)
        End If
        LabelWait.Visible = True
        LabelWait.Refresh()

        If LI.SubItems(1).Text = "Cash" Then
            frmImageDiskCashReceipt.Setup_report(LI.Tag)
            frmImageDiskCashReceipt.ShowDialog(Me)
            frmImageDiskCashReceipt.Dispose()
        Else
            frmImageDiskInvoice.Setup_report(LI.Tag)
            frmImageDiskInvoice.ShowDialog(Me)
            frmImageDiskInvoice.Dispose()
        End If
        LabelWait.Visible = False
        LabelWait.Refresh()

    End Sub

    Private Sub PrintInvoiceEnvilopeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintInvoiceEnvilopeToolStripMenuItem.Click
        Dim LI As ListViewItem = Nothing
        Dim RequestID As Long
        If ListViewOrders.SelectedItems.Count = 0 Then
            ButtonPrint.Text = "Print"
            MsgBox("Unable to process your request. No Order Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            LI = ListViewOrders.SelectedItems(0)
        End If
        RequestID = LI.Tag
        LabelWait.Visible = True
        LabelWait.Refresh()

        frmImageDiskInvoiceEnvelope.Setup_report(RequestID)
        frmImageDiskInvoiceEnvelope.ShowDialog(Me)
        frmImageDiskInvoiceEnvelope.Dispose()
        LabelWait.Visible = False
        LabelWait.Refresh()

    End Sub

    Private Sub PrintCDEnvelopeLabelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintCDEnvelopeLabelToolStripMenuItem.Click
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim InvoiceID As String
        Cursor = Cursors.WaitCursor
        Dim LI As ListViewItem
        Application.DoEvents()
        Application.DoEvents()
        If ListViewOrders.SelectedItems.Count = 0 Then
            ButtonPrint.Text = "Print"
            MsgBox("Unable to print CD Label. No request selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            LI = ListViewOrders.SelectedItems(0)
        End If
        InvoiceID = LI.Tag
        LabelWait.Visible = True
        LabelWait.Refresh()

        Try
            If gCDEnvelopeLabelType = 1 Then
                CR = New rptImageDiskEnvelopeLabel
            Else
                CR = New rptCDShippingLabel
            End If

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("CDInvoiceID", InvoiceID)
            If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
            'Set Label Size to Priter Paper Size
            Dim doctoprint As New System.Drawing.Printing.PrintDocument()
            doctoprint.PrinterSettings.PrinterName = gPrinterFileLabel
            CR.PrintOptions.PaperSize = doctoprint.DefaultPageSettings.PaperSize.RawKind
            ''''''''''''''''''''''''

            CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
            CR.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        LabelWait.Visible = False
        LabelWait.Refresh()

    End Sub

    Private Sub ToolStripMenuPrintCD_Click(sender As Object, e As EventArgs) Handles ToolStripMenuPrintCD.Click
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim InvoiceID As String
        Cursor = Cursors.WaitCursor
        Dim LI As ListViewItem
        Application.DoEvents()
        If ListViewOrders.SelectedItems.Count = 0 Then
            ButtonPrint.Text = "Print"
            MsgBox("Unable to print CD Label. No request selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            LI = ListViewOrders.SelectedItems(0)
        End If
        InvoiceID = LI.Tag
        LabelWait.Visible = True
        LabelWait.Refresh()

        Try
            CR = New rptImageCDDisk

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("RequestID", InvoiceID)
            If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gCDLabelPrinter

            CR.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        LabelWait.Visible = False
        LabelWait.Refresh()

    End Sub

    Private Sub BurnCDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BurnCDToolStripMenuItem.Click
        Dim LI As ListViewItem
        If ListViewOrders.SelectedItems.Count = 0 Then
            MsgBox("Unable to Burn CD. No CD Invoice selected.")
        End If
        LI = ListViewOrders.SelectedItems(0)
        LabelWait.Visible = True
        LabelWait.Refresh()
        frmCDBurn.Load_Data(Val(LI.Tag))
        frmCDBurn.ShowDialog(Me)
        frmCDBurn.Dispose()
        LabelWait.Visible = False
        LabelWait.Refresh()
    End Sub

End Class