Imports System.Reflection
Imports log4net

Public Class frmInsuranceMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Public PreSelectedInsuranceID As Long = 0
    Public AddNewFlag As Boolean
    Public AddNewCaseType As Integer = -1
    Private OpMode As AddEditMode
    Dim CellTypeCombobox As New FarPoint.Win.Spread.CellType.ComboBoxCellType

    Public Sub Load_Companies()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        imgWait1.Visible = True
        ListView1.BeginUpdate()
        ListView1.SuspendLayout()
        ListView1.Items.Clear()
        Dim SQL As String
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            SQL = "Select * from InsuranceCompanies Where 1=1 "
            If PreSelectedInsuranceID > 0 Then

                SQL &= " AND CompanyID=" & PreSelectedInsuranceID & " "
            Else
                If ComboBoxCaseTypes.SelectedIndex > 0 Then
                    If CType(ComboBoxCaseTypes.SelectedItem, ValueDescription).Value > 0 Then
                        SQL &= " AND CaseTypeID=" & CType(ComboBoxCaseTypes.SelectedItem, ValueDescription).Value & " "
                    End If
                End If
                If TextBoxSearch.Text <> "*" Then
                    'SQL &= " and (CompanyName like '" & RBC(TextBoxSearch.Text) & "%' or CompanyName like '% " & RBC(TextBoxSearch.Text) & "%')"
                    SQL &= " and (CompanyName like '" & TextBoxSearch.Text.ToSafeSQLString() & "%') "
                End If
                If ComboBoxAcceptance.SelectedIndex > 0 Then
                    SQL &= " AND AcceptanceID=" & CType(ComboBoxAcceptance.SelectedItem, ValueDescription).Value & " "
                End If
            End If
            SQL &= " Order by CompanyName "
            Reader = gSQLGetDataReader(SQL)

            If Reader Is Nothing Then
                Exit Sub
                ListView1.ResumeLayout()
            End If

            Do Until Reader.Read = False
                If Val(Reader("DMV").ToString) > 0 Then
                    LI = ListView1.Items.Add(Reader("DMV").ToString.PadLeft(3, "0"c), CInt(Val("" & Reader("ActiveInd").ToString)))
                Else
                    LI = ListView1.Items.Add("", CInt(Val("" & Reader("ActiveInd").ToString)))
                End If
                LI.SubItems.Add(Reader("CompanyName").ToString)
                LI.ToolTipText = Reader("CompanyName").ToString
                LI.Tag = "" & Reader("CompanyID").ToString
                Select Case Val(Reader("AcceptanceID").ToString)
                    Case 1
                        LI.ForeColor = Color.DarkOrange
                        If LI.ImageIndex = 1 Then LI.ImageIndex = 5
                    Case 2
                        LI.ForeColor = Color.DarkRed
                        If LI.ImageIndex = 1 Then LI.ImageIndex = 6
                        'Case Else
                        'LI.ForeColor = Color.Black
                End Select
            Loop
            Reader.Close() : Reader.Dispose()
            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Selected = True
                ListView1.Items(0).EnsureVisible()
                ' ListView1_SelectedIndexChanged(Nothing, Nothing)
                cmdEdit.Enabled = gCurrentEmployee.PositionID < 3
                cmdDelete.Enabled = gCurrentEmployee.PositionID < 3
            Else
                Clear_Controls()
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
        ListView1.ResumeLayout()
        ListView1.EndUpdate()
        Cursor = Cursors.Default
        imgWait1.Visible = False
    End Sub

    Private lStates As String
    Dim PayerNames As AutoCompleteStringCollection = New AutoCompleteStringCollection()
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ComboText As String() = {""}
        Dim ComboValue As String() = {""}
        Dim Items() As String = {""}
        Dim I As Integer = 0
        ComboBoxPatientTypeID.Items.Clear()
        ComboBoxPatientTypeID.Items.Add(New ValueDescription(0, "None"))

        Reader = gSQLGetDataReader("Select PatientTypeID, Description from PatientTypes")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxPatientTypeID.Items.Add(New ValueDescription(CLng(Val(Reader("PatientTypeID").ToString)),
                                                                    Reader("Description").ToString))

        Loop
        Reader.Close()

        Reader = gSQLGetDataReader("SELECT CaseTypeID, Description FROM CaseTypes Where CaseTypeID<> 4 ")
        If Reader Is Nothing Then Exit Sub
        Load_InsuranceGroups()
        ComboBoxPatientTypeID.SelectedIndex = 0
        ComboBoxCaseTypes.Items.Add(New ValueDescription(0, "All"))
        Do Until Reader.Read = False
            ComboBoxCaseTypes.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID".ToString))), Reader("Description").ToString))
            ComboBoxCaseType.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Description").ToString))
        Loop

        Reader.Close() : Reader.Dispose()

        Reader = gSQLGetDataReader("SELECT AcceptanceID, Description FROM InsuranceCompanyAcceptance")
        If Reader Is Nothing Then Exit Sub
        ComboBoxAcceptance.Items.Add(New ValueDescription(0, "All"))
        Do Until Reader.Read = False
            ComboBoxAcceptanceID.Items.Add(New ValueDescription(CLng(Val(Reader("AcceptanceID".ToString))), Reader("Description").ToString))
            ComboBoxAcceptance.Items.Add(New ValueDescription(CLng(Val(Reader("AcceptanceID".ToString))), Reader("Description").ToString))
        Loop
        ComboBoxAcceptance.SelectedIndex = 0
        Reader.Close() : Reader.Dispose()

        Reader = gSQLGetDataReader("Select DISTINCT State , ShowOrder from States Order by ShowOrder")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ReDim Preserve Items(I)
            Items(I) = Reader("State").ToString
            I = I + 1

        Loop
        CellTypeCombobox.Items = Items
        Reader.Close() : Reader.Dispose()
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        FpSpread1.ActiveSheet.GrayAreaBackColor = Color.WhiteSmoke
        FpSpread1.ActiveSheet.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).BackColor = Color.WhiteSmoke
        cboEfiling.Items.Clear()
        PayerNames.Clear()

        For Each p As Payer In PayersList
            cboEfiling.Items.Add(New ValueDescription(0, p.PayerName, p.PayerId))
            PayerNames.Add(p.PayerName)
        Next
        cboEfiling.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboEfiling.AutoCompleteSource = AutoCompleteSource.CustomSource
        cboEfiling.AutoCompleteCustomSource = PayerNames

    End Sub

    Private Sub Load_InsuranceGroups()
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("SELECT GroupID, Description FROM InsuranceCompaniesGroups order by Description ")
        cboInsuranceGrooups.Items.Clear()
        cboInsuranceGrooups.Items.Add(New ValueDescription(0, "None"))
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboInsuranceGrooups.Items.Add(New ValueDescription(CLng(Val(Reader("GroupID".ToString))), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private m_SortingColumn As ColumnHeader

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListView1.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
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
        ListView1.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView1.Sort()

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If gCurrentEmployee.PositionID < 3 Then Exit Sub
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = True
        End If
    End Sub

    Private Sub ListView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyUp
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = False
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private KeyDn As Boolean

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If KeyDn = True Then Exit Sub
        Cursor = Cursors.WaitCursor
        If OpMode <> AddEditMode.None Then Exit Sub
        Clear_Controls()
        cmdEdit.Enabled = gCurrentEmployee.PositionID < 3
        cmdDelete.Enabled = gCurrentEmployee.PositionID < 3
        ID = CLng(ListView1.SelectedItems(0).Tag)
        SaveSelectedItem = ListView1.SelectedItems(0)
        Reader = gSQLGetDataReader("Select * from InsuranceCompanies Where CompanyID=" & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
            txtCompanyName.Text = "" & Reader("CompanyName").ToString
            txtPhone1.Text = "" & Reader("Phone1").ToString
            txtPhone2.Text = "" & Reader("Phone2").ToString
            txtFax1.Text = "" & Reader("Fax1").ToString
            txtFax2.Text = "" & Reader("Fax2").ToString
            txtEmail.Text = "" & Reader("eMail").ToString
            txtComments.Text = "" & Reader("Comments").ToString
            txtMessage.Text = "" & Reader("Message").ToString
            txtContact1.Text = "" & Reader("Contact1").ToString
            txtContact2.Text = "" & Reader("Contact2").ToString
            txtDMV.Text = "" & Reader("DMV").ToString.PadLeft(3, "0"c)
            txtNAIC.Text = "" & Reader("NAIC").ToString
            txtContact1Phone.Text = "" & Reader("Contact1Phone").ToString
            txtContact2Phone.Text = "" & Reader("Contact2Phone").ToString
            gFindComboItemByValue(ComboBoxPatientTypeID, CLng(Val(Reader("RejectID").ToString)), True)
            gFindComboItemByValue(ComboBoxCaseType, CLng(Val(Reader("CaseTypeID").ToString)), True)
            gFindComboItemByValue(ComboBoxAcceptanceID, CLng(Val(Reader("AcceptanceID").ToString)), True)
            gFindComboItemByValue(cboInsuranceGrooups, CLng(Val(Reader("GroupID").ToString)), True)
            If Reader("PayerId").ToString.Trim.Length > 0 Then gFindPayerbyPayerId(cboEfiling, Reader("PayerId").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        Load_Ins_Addresses()
        Cursor = Cursors.Default
    End Sub

    Private Sub Load_Ins_Addresses()
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        ID = CLng(ListView1.SelectedItems(0).Tag)
        SaveSelectedItem = ListView1.SelectedItems(0)

        If KeyDn = True Then Exit Sub
        Cursor = Cursors.WaitCursor

        FpSpread1.InterfaceRenderer = Nothing

        FpSpread1.SuspendLayout()
        With FpSpread1.ActiveSheet
            .RowCount = 0
            Reader = gSQLGetDataReader("Select * from InsuranceCompanyAddresses Where CompanyID=" & ID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                .RowCount = .RowCount + 1
                .Cells(.RowCount - 1, 0).Tag = Reader("AddressID").ToString
                .SetText(.RowCount - 1, 0, Val(Reader("AddressID").ToString))
                .SetText(.RowCount - 1, 1, Reader("AddressName").ToString)
                .SetText(.RowCount - 1, 2, Reader("AddressName2").ToString)

                .SetText(.RowCount - 1, 3, Reader("Address").ToString)
                .SetText(.RowCount - 1, 4, Reader("City").ToString)
                .SetText(.RowCount - 1, 5, Reader("State").ToString)
                .SetText(.RowCount - 1, 6, Reader("Zip").ToString)
                .SetText(.RowCount - 1, 7, Val(Reader("ActiveInd").ToString))

                If gSQLGetSingleValue("SELECT count(*) from Bills where InsAddressID = " & Val(Reader("AddressID").ToString)) > 0 Then
                    .Cells(.RowCount - 1, 8).CellType = New FarPoint.Win.Spread.CellType.EditBaseCellType
                    .Cells(.RowCount - 1, 8).Locked = True
                    .Cells(.RowCount - 1, 8).BackColor = Color.WhiteSmoke
                End If
                .Cells(.RowCount - 1, 0, .RowCount - 1, .ColumnCount - 1).BackColor = Color.WhiteSmoke
                .Cells(.RowCount - 1, 0, .RowCount - 1, .ColumnCount - 1).Font = New Font(FpSpread1.Font, FontStyle.Bold)
            Loop
            .RowCount = .RowCount + 1
            .Cells(0, 0, .RowCount - 1, .ColumnCount - 1).BackColor = Color.WhiteSmoke
            .GrayAreaBackColor = Color.WhiteSmoke
            FpSpread1.ResumeLayout(True)
        End With
        Reader.Close() : Reader.Dispose()
        Cursor = Cursors.Default
    End Sub

    Private Sub Clear_Controls()
        On Error Resume Next
        gLoop_Clear_Controls(Me, TextBoxSearch, ComboBoxCaseTypes, ComboBoxAcceptance, ComboBoxPatientTypeID)
        FpSpread1.ActiveSheet.RowCount = 0
        FpSpread1.ActiveSheet.RowCount = 1
        ComboBoxPatientTypeID.SelectedIndex = 0
        cboInsuranceGrooups.SelectedIndex = 0
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        gLoop_Enable_Controls(Me, En)

        TextBoxSearch.Enabled = Not En
        ComboBoxCaseTypes.Enabled = Not En
        cmdAddInsuranceGroup.Enabled = En
        ListView1.Enabled = Not En

        cmdAddNew.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        If En = False Then
            If ListView1.Items.Count > 0 Then
                cmdEdit.Enabled = gCurrentEmployee.PositionID < 3
                cmdDelete.Enabled = gCurrentEmployee.PositionID < 3
            Else
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            End If
        Else
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
        End If
        FpSpread1.SuspendLayout()

        If En = True Then
            FpSpread1.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
            FpSpread1.ActiveSheet.GrayAreaBackColor = Color.White
            FpSpread1.ActiveSheet.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).BackColor = Color.White
        Else
            FpSpread1.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
            FpSpread1.ActiveSheet.GrayAreaBackColor = Color.WhiteSmoke
            FpSpread1.ActiveSheet.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).BackColor = Color.WhiteSmoke
            FpSpread1.ActiveSheet.Cells(0, 1, FpSpread1.ActiveSheet.RowCount - 1, 1).BackColor = Color.WhiteSmoke
        End If
        FpSpread1.ResumeLayout(True)
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        CheckBoxActiveInd.Checked = True
        ComboBoxAcceptanceID.SelectedIndex = 0
        txtCompanyName.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        OpMode = AddEditMode.None
        Enable_Controls(False)
        gLoop_ResetErrors_Controls(ErrorProvider1, Me)
        If Not SaveSelectedItem Is Nothing Then
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        Else
            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Selected = True
                ListView1.Items(0).EnsureVisible()
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If gCurrentEmployee.PositionID > 2 Then Exit Sub
        OpMode = AddEditMode.Edit
        Enable_Controls(True)
        ComboBoxCaseType_SelectedIndexChanged(Nothing, Nothing)
        txtCompanyName.Focus()
        txtCompanyName.SelectAll()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim ProcCount As Integer = 0
        Dim Reader As SqlClient.SqlDataReader
        Dim I As Integer
        Dim RetID As String
        Dim Ret1 As String
        Dim Ret2 As String
        Dim Ret3 As String
        Dim Ret4 As String
        Dim Ret5 As String
        Dim Ret6 As String
        Dim RetActive
        Dim NewRow As Boolean
        Dim InsAddressFound As Boolean
        Try

            gLoop_Trim_Controls(Me)
            gLoop_Text_PropperCase(Me, txtDMV, txtNAIC)
            txtDMV.Text = Val(txtDMV.Text)
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If

            If ComboBoxCaseType.SelectedIndex < 0 Then
                ErrorProvider1.SetError(ComboBoxCaseType, "Unable to process update. The Insurance Type is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Insurance Type is required.", MsgBoxStyle.Exclamation)
                ComboBoxCaseType.Focus()
                Exit Sub
            End If
            If txtCompanyName.Text = "" Then
                ErrorProvider1.SetError(txtCompanyName, "Unable to process update. The Office Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Insurance Company Name is required.", MsgBoxStyle.Exclamation)
                txtCompanyName.Focus()
                Exit Sub
            End If
            If ComboBoxPatientTypeID.SelectedIndex = -1 Then
                ComboBoxPatientTypeID.SelectedIndex = 0
            End If
            If CType(ComboBoxCaseType.SelectedItem, ValueDescription).Value = 1 Then
                If ComboBoxAcceptanceID.SelectedIndex < 0 Then
                    ErrorProvider1.SetError(ComboBoxAcceptanceID, "Unable to process update. The Insurance Company Acceptance should be selected.")
                    MsgBox("Unable to process update." & vbCrLf & "The Insurance Company Acceptance should be selected.", MsgBoxStyle.Exclamation)
                    ComboBoxAcceptanceID.Focus()
                    Exit Sub
                End If
                If txtDMV.Text = "" Then
                    ErrorProvider1.SetError(txtDMV, "Unable to process update. The Insurance Company Code is required.")
                    MsgBox("Unable to process update." & vbCrLf & "The Insurance Company Code is required.", MsgBoxStyle.Exclamation)
                    txtDMV.Focus()
                    Exit Sub
                End If

            End If

            If txtEmail.Text <> "" AndAlso gEmailCheck(txtEmail.Text) = False Then
                ErrorProvider1.SetError(txtEmail, "Unable to process update. Invalid Email address specified.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Email address specified.", MsgBoxStyle.Exclamation)
                txtEmail.Focus()
                Exit Sub
            End If
            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from InsuranceCompanies Where CompanyID<>" & ID & " and CompanyName='" & txtCompanyName.Text.ToSafeSQLString() & "' and CaseTypeID = " & CType(ComboBoxCaseType.SelectedItem, ValueDescription).Value)
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from InsuranceCompanies Where CompanyName='" & txtCompanyName.Text.ToSafeSQLString() & "' and CaseTypeID = " & CType(ComboBoxCaseType.SelectedItem, ValueDescription).Value)
            End If
            If Reader.HasRows Then
                ErrorProvider1.SetError(txtCompanyName, "Unable to process update." & vbCrLf & "The Insurance Company " & txtCompanyName.Text & " is already exists.")
                MsgBox("Unable to process update." & vbCrLf & "The Insurance Company Name is inuse.", MsgBoxStyle.Exclamation)
                txtCompanyName.Focus()
                txtCompanyName.SelectAll()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()
            If cboInsuranceGrooups.SelectedIndex = -1 Then cboInsuranceGrooups.SelectedIndex = 0

            Dim AddressFound As Boolean = False
            With FpSpread1.ActiveSheet
                For I = 0 To .RowCount - 1
                    RetID = .Cells(I, 0).Tag
                    Ret1 = Trim(.Cells(I, 1).Text)
                    Ret2 = Trim(.Cells(I, 2).Text)
                    Ret3 = Trim(.Cells(I, 3).Text)
                    Ret4 = Trim(.Cells(I, 4).Text)
                    Ret5 = Trim(.Cells(I, 5).Text)
                    Ret6 = Trim(.Cells(I, 6).Text)
                    If IIf(Trim(.Cells(I, 7).Text) = "True", 1, 0) = 1 Then
                        AddressFound = True
                    End If
                    If Ret1 = "" And Ret2 = "" And Ret4 = "" And Ret5 = "" And Ret6 = "" And RetID = "" Then
                        GoTo GetNextAddress
                    End If
                    If Ret1 = "" Then
                        MsgBox("Unable to process update." & vbCrLf & "The Insurance Address Name should be specified.", MsgBoxStyle.Exclamation)
                        FpSpread1.Focus()
                        .SetActiveCell(I, 1)
                        Exit Sub
                    End If
                    If Ret3 = "" Then
                        MsgBox("Unable to process update." & vbCrLf & "The Insurance Address should be specified.", MsgBoxStyle.Exclamation)
                        FpSpread1.Focus()
                        .SetActiveCell(I, 3)
                        Exit Sub
                    End If
                    If Ret4 = "" Then
                        MsgBox("Unable to process update." & vbCrLf & "The Insurance Address City should be specified.", MsgBoxStyle.Exclamation)
                        FpSpread1.Focus()
                        .SetActiveCell(I, 4)
                        Exit Sub
                    End If
                    If Ret5 = "" Then
                        MsgBox("Unable to process update." & vbCrLf & "The Insurance Address State should be specified.", MsgBoxStyle.Exclamation)
                        FpSpread1.Focus()
                        .SetActiveCell(I, 5)
                        Exit Sub
                    End If
                    If Ret6 = "" Then
                        MsgBox("Unable to process update." & vbCrLf & "The Insurance Address Zip Code should be specified.", MsgBoxStyle.Exclamation)
                        FpSpread1.Focus()
                        .SetActiveCell(I, 6)
                        Exit Sub
                    End If
                    InsAddressFound = True

GetNextAddress:
                Next
            End With

            If InsAddressFound = False Or AddressFound = False Then
                MsgBox("Unable to process update." & vbCrLf & "At least one Active Insurance Address should be specified.", MsgBoxStyle.Exclamation)
                FpSpread1.Focus()
                Exit Sub
            End If
            Dim PayeeId As String
            If cboEfiling.Text <> "" Then cboEfiling.SelectedIndex = cboEfiling.FindString(cboEfiling.Text)
            If cboEfiling.SelectedIndex > -1 Then
                PayeeId = CType(cboEfiling.SelectedItem, ValueDescription).Value1
                If CType(ComboBoxCaseType.SelectedItem, ValueDescription).Value = 2 Then
                    If gSQLGetSingleValueString("Select WorkComp from CariskPayers where PayerId='" & PayeeId & "'") = "N" Then
                        If MsgBox("The selected e-File payer:" & vbCrLf & "[" & cboEfiling.Text & "]" & vbCrLf & "the WorkComp indicator is set to 'NO'" & vbCrLf & vbCrLf & "Continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Return
                        End If
                    End If
                End If
            End If
            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM InsuranceCompanies Where CompanyID= " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("InsuranceCompanies")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("CompanyName") = txtCompanyName.Text.Trim()
            TR("DMV") = Val(txtDMV.Text)
            If IsNumeric(txtNAIC.Text) Then TR("NAIC") = txtNAIC.Text
            If txtPhone1.MaskCompleted Then TR("Phone1") = txtPhone1.Text Else TR("Phone1") = ""
            If txtPhone2.MaskCompleted Then TR("Phone2") = txtPhone2.Text Else TR("Phone2") = ""
            If txtFax1.MaskCompleted Then TR("Fax1") = txtFax1.Text Else TR("Fax1") = ""
            If txtFax2.MaskCompleted Then TR("Fax2") = txtFax2.Text Else TR("Fax2") = ""
            TR("eMail") = txtEmail.Text.Trim()
            TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
            TR("Comments") = txtComments.Text.Trim()
            TR("Message") = txtMessage.Text.Trim()
            TR("CaseTypeID") = CType(ComboBoxCaseType.SelectedItem, ValueDescription).Value
            TR("AcceptanceID") = CType(ComboBoxAcceptanceID.SelectedItem, ValueDescription).Value
            TR("RejectID") = CType(ComboBoxPatientTypeID.SelectedItem, ValueDescription).Value
            TR("Contact1") = txtContact1.Text.Trim()
            TR("Contact2") = txtContact2.Text.Trim()

            TR("Contact1Phone") = txtContact1Phone.Text
            TR("Contact2Phone") = txtContact2Phone.Text
            TR("GroupID") = CType(cboInsuranceGrooups.SelectedItem, ValueDescription).Value
            TR("PayerId") = PayeeId
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
                Reader = gSQLGetDataReader("Select * from InsuranceCompanies Where CompanyID = IDENT_CURRENT('InsuranceCompanies')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("DMV").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("CompanyID").ToString
                    LI.SubItems.Add(Reader("CompanyName").ToString)
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ID = CLng(Val(Reader("CompanyID").ToString))
                    SaveSelectedItem = LI
                    Select Case Val(Reader("AcceptanceID").ToString)
                        Case 1
                            SaveSelectedItem.ForeColor = Color.DarkOrange
                            If SaveSelectedItem.ImageIndex = 1 Then SaveSelectedItem.ImageIndex = 5
                        Case 2
                            SaveSelectedItem.ForeColor = Color.DarkRed
                            If SaveSelectedItem.ImageIndex = 1 Then SaveSelectedItem.ImageIndex = 6
                        Case Else
                            SaveSelectedItem.ForeColor = Color.Black
                    End Select
                Loop
                Reader.Close() : Reader.Dispose()
            Else

                If CheckBoxActiveInd.Checked = True Then
                    SaveSelectedItem.ImageIndex = 1
                Else
                    SaveSelectedItem.ImageIndex = 0
                End If
                SaveSelectedItem.SubItems(1).Text = txtCompanyName.Text
                SaveSelectedItem.Text = txtDMV.Text
                Select Case CType(ComboBoxAcceptanceID.SelectedItem, ValueDescription).Value
                    Case 1
                        SaveSelectedItem.ForeColor = Color.DarkOrange
                        If SaveSelectedItem.ImageIndex = 1 Then SaveSelectedItem.ImageIndex = 5
                    Case 2
                        SaveSelectedItem.ForeColor = Color.DarkRed
                        If SaveSelectedItem.ImageIndex = 1 Then SaveSelectedItem.ImageIndex = 6
                    Case Else
                        SaveSelectedItem.ForeColor = Color.Black
                End Select
            End If

            TA = New SqlClient.SqlDataAdapter("SELECT * FROM InsuranceCompanyAddresses Where CompanyID = " & ID, gConnectionString)
            CB = New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            dTab = New DataTable("InsuranceCompanyAddresses")
            TA.Fill(dTab)
            With FpSpread1.ActiveSheet
                For I = 0 To .RowCount - 1
                    RetID = .Cells(I, 0).Tag
                    Ret1 = Trim(.Cells(I, 1).Text)
                    Ret2 = Trim(.Cells(I, 2).Text)
                    Ret3 = Trim(.Cells(I, 3).Text)
                    Ret4 = Trim(.Cells(I, 4).Text)
                    Ret5 = Trim(.Cells(I, 5).Text)
                    Ret6 = Trim(.Cells(I, 6).Text)
                    RetActive = IIf(Trim(.Cells(I, 7).Text) = "True", 1, 0)
                    If Ret1 = "" And Ret3 = "" And Ret4 = "" And Ret5 = "" And Ret6 = "" And RetID = "" Then
                        GoTo GetNextAddress1
                    End If
                    NewRow = False
                    If OpMode = AddEditMode.AddNew Then
                        TR = dTab.NewRow
                        NewRow = True
                    Else
                        If Val(RetID) = 0 Then
                            NewRow = True
                            TR = dTab.NewRow
                        Else
                            TR = dTab.Select("AddressID=" & RetID)(0)
                        End If

                    End If
                    TR("CompanyID") = ID
                    TR("AddressName") = Ret1.ToSafeSQLString().ToUpper
                    TR("AddressName2") = Ret2.ToSafeSQLString().ToUpper
                    TR("Address") = Ret3.ToSafeSQLString().ToUpper
                    TR("City") = Ret4.ToSafeSQLString().ToUpper
                    TR("State") = Ret5.ToSafeSQLString().ToUpper
                    TR("Zip") = Ret6.ToSafeSQLString().ToUpper
                    TR("ActiveInd") = RetActive
                    If NewRow = True Then
                        dTab.Rows.Add(TR)
                    End If
GetNextAddress1:
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
            dTab.Dispose() : CB.Dispose() : TA.Dispose()

            OpMode = AddEditMode.None
            Enable_Controls(False)
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            If ListView1.SelectedItems.Count > 0 Then
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Office selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the office " & ListView1.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable an Office.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ID = CLng(ListView1.SelectedItems(0).Tag)
        If gSQLDeleteRecord("DELETE FROM InsuranceCompanies WHERE CompanyID=" & ID) Then
            ListView1.Items.Remove(ListView1.SelectedItems(0))
            SaveSelectedItem = Nothing
            If ListView1.SelectedItems.Count > 0 Then
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            Else
                Clear_Controls()
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            End If
        End If

    End Sub

    Private Sub frmInsuranceMaintenance_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
        TextBoxSearch.Focus()
    End Sub

    Private Sub frmInsuranceMaintenance_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub

    Private Sub frmInsuranceMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmInsuranceMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gSpread_Settings(Me, FpSpread1, ReadWrite.sWrite)
        If cmdUpdate.Enabled Then
            If MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

    End Sub

    Private Sub frmOfficeMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_SortingColumn = ListView1.Columns(1)
        txtCompanyName.AutoCompleteCustomSource = gAutocompleteInsuranceCompanies

        AddHandler cboInsuranceGrooups.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInsuranceGrooups.Leave, AddressOf sSearchComboBox_Leave
        Button1.Visible = gCurrentEmployee.PositionID < 3
        cmdAddInsuranceGroup.Visible = gCurrentEmployee.PositionID < 3
        cmdAddNew.Visible = gCurrentEmployee.PositionID < 3
        cmdEdit.Visible = gCurrentEmployee.PositionID < 3
        cmdDelete.Visible = gCurrentEmployee.PositionID < 3
        cmdCancel.Visible = gCurrentEmployee.PositionID < 3
        cmdUpdate.Visible = gCurrentEmployee.PositionID < 3
        LabelReadOnly.Visible = Not (gCurrentEmployee.PositionID < 3)
        Timer1.Enabled = True

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub txtCompanyName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompanyName.TextChanged
        ErrorProvider1.SetError(txtCompanyName, "")
    End Sub

    Private Sub TextBoxSearch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxSearch.LostFocus

    End Sub

    Private Sub Search_Companies(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        TimerSearch.Enabled = False
        FpSpread1.Enabled = False
        LabelTotal.Text = ""
        If TextBoxSearch.Text = "" Then
            ListView1.Items.Clear()
            Clear_Controls()
            FpSpread1.Enabled = True
            Loading = False
            Exit Sub
        End If
        TimerSearch.Enabled = True
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim LI As ListViewItem = Nothing
        If ListView1.Items.Count = 0 Then
            TextBoxSearch.Text = ""
            Exit Sub
        End If
        If TextBoxSearch.Text = "" Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            TextBoxSearch.Focus()
            TextBoxSearch.SelectionStart = TextBoxSearch.Text.Length
            Exit Sub
        End If
        'LI = ListView1.FindItemWithText(TextBox1.Text)
        For Each LIs As ListViewItem In ListView1.Items
            If InStr(LIs.Text, TextBoxSearch.Text, CompareMethod.Text) > 0 Or InStr(LIs.SubItems(1).Text, TextBoxSearch.Text, CompareMethod.Text) > 0 Then
                LI = LIs
                Exit For
            End If
        Next
        If Not LI Is Nothing Then
            LI.Selected = True
            LI.EnsureVisible()
        Else
            'ListView1.Items(0).Selected = True
            'ListView1.Items(0).EnsureVisible()
            TextBoxSearch.BackColor = Color.LightCoral
            TextBoxSearch.Text = TextBoxSearch.Text.Mid(1, TextBoxSearch.Text.Length - 1)
            Timer2.Enabled = True
        End If
        TextBoxSearch.Focus()
        TextBoxSearch.SelectionStart = TextBoxSearch.Text.Length
    End Sub

    Private Sub txtDMV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDMV.TextChanged
        ErrorProvider1.SetError(txtDMV, "")
    End Sub

    Private Sub txtNAIC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNAIC.TextChanged
        ErrorProvider1.SetError(txtNAIC, "")
    End Sub

    Private Sub FpSpread1_ButtonClicked(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ButtonClicked
        Dim RetID As String = Trim(FpSpread1.ActiveSheet.Cells(e.Row, 0).Tag)
        Dim Ret1 As String = Trim(FpSpread1.ActiveSheet.Cells(e.Row, 1).Text)
        Dim Ret2 As String = Trim(FpSpread1.ActiveSheet.Cells(e.Row, 2).Text)
        Dim Ret3 As String = Trim(FpSpread1.ActiveSheet.Cells(e.Row, 3).Text)
        Dim Ret4 As String = Trim(FpSpread1.ActiveSheet.Cells(e.Row, 4).Text)
        Dim Ret5 As String = Trim(FpSpread1.ActiveSheet.Cells(e.Row, 5).Text)
        Dim Ret6 As String = Trim(FpSpread1.ActiveSheet.Cells(e.Row, 6).Text)

        If e.Column < 8 Then Exit Sub
        If gSQLGetSingleValue("SELECT count(*) from Bills where InsAddressID = " & Val(RetID)) > 0 Then
            MsgBox("Unable to delete this address. This address is already in use in the existing bill(s).")
        End If
        If MsgBox("Are you sure you want to remove the Insurance Company Address" & vbCrLf & vbCrLf & Ret1 & " - " & Ret3 & ", " & Ret4 & ", " & Ret5 & ", " & Ret6, MsgBoxStyle.Critical Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If Val(RetID) > 0 Then
            gSQLUpdateData("DELETE FROM InsuranceCompanyAddresses where AddressID=" & Val(RetID))
        End If
        If e.Row = FpSpread1.ActiveSheet.RowCount - 1 Then
            FpSpread1.ActiveSheet.Cells(e.Row, 0).Text = ""
            FpSpread1.ActiveSheet.Cells(e.Row, 1).Text = ""
            FpSpread1.ActiveSheet.Cells(e.Row, 2).Text = ""
            FpSpread1.ActiveSheet.Cells(e.Row, 3).Text = ""
            FpSpread1.ActiveSheet.Cells(e.Row, 4).Text = ""
            FpSpread1.ActiveSheet.Cells(e.Row, 5).Text = ""
            FpSpread1.ActiveSheet.Cells(e.Row, 6).Text = ""
            FpSpread1.ActiveSheet.Cells(e.Row, 7).Text = "0"
            Exit Sub
        End If
        FpSpread1.ActiveSheet.RemoveRows(e.Row, 1)
    End Sub

    Private Sub FpSpread1_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ComboCloseUp
        Dim Ret1 As String = FpSpread1.ActiveSheet.Cells(e.Row, 1).Text
        Dim Ret2 As String = FpSpread1.ActiveSheet.Cells(e.Row, 2).Text
        Dim Ret3 As String = FpSpread1.ActiveSheet.Cells(e.Row, 3).Text
        Dim Ret4 As String = FpSpread1.ActiveSheet.Cells(e.Row, 4).Text
        Dim Ret5 As String = FpSpread1.ActiveSheet.Cells(e.Row, 5).Text
        If Ret1 <> "" And Ret2 <> "" And Ret3 <> "" And Ret4 <> "" And Ret5 <> "" And e.Row = FpSpread1.ActiveSheet.RowCount - 1 Then
            FpSpread1.ActiveSheet.RowCount = FpSpread1.ActiveSheet.RowCount + 1
        End If
    End Sub

    Private Sub FpSpread1_EditChange(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.EditChange
        FpSpread1_ComboCloseUp(sender, e)
    End Sub

    Private Sub FpSpread1_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellClick

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Loading = True
        gSetup_GotFocus(Me)
        Load_Data()

        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        FpSpread1.ActiveSheet.GrayAreaBackColor = Color.WhiteSmoke
        FpSpread1.ActiveSheet.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 4).BackColor = Color.WhiteSmoke
        CellTypeCombobox.Editable = False
        CellTypeCombobox.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
        CellTypeCombobox.ListAlignment = FarPoint.Win.ListAlignment.Left
        FpSpread1.ActiveSheet.Columns(FpSpread1.ActiveSheet.ColumnCount - 4).CellType = CellTypeCombobox
        gSpread_Settings(Me, FpSpread1, ReadWrite.sRead)
        ComboBoxCaseTypes.SelectedIndex = 0
        TextBoxSearch.Focus()

        Loading = False
    End Sub

    Private Sub FpSpread1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpread1.GotFocus

    End Sub

    Private Sub ComboBoxCaseTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxCaseTypes.SelectedIndexChanged
        If Loading = True Then Exit Sub
        TimerSearch_Tick(Nothing, Nothing)
    End Sub

    Private Sub ComboBoxCaseType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxCaseType.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxCaseType, "")
        If ComboBoxCaseType.SelectedIndex < 0 Then Exit Sub
        If CType(ComboBoxCaseType.SelectedItem, ValueDescription).Value = 5 Then
            txtDMV.Enabled = False
            txtNAIC.Enabled = False
            ComboBoxAcceptanceID.Enabled = False
            txtDMV.Text = ""
            txtNAIC.Text = ""
            ComboBoxAcceptanceID.SelectedIndex = 0
            cboInsuranceGrooups.SelectedIndex = 0
        Else
            If OpMode <> AddEditMode.None Then
                cboInsuranceGrooups.Enabled = True
                cmdAddInsuranceGroup.Enabled = True

                txtDMV.Enabled = True
                txtNAIC.Enabled = True
                cboInsuranceGrooups.Enabled = True
                cmdAddInsuranceGroup.Enabled = True
                ComboBoxAcceptanceID.Enabled = True
            End If
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        TextBoxSearch.BackColor = Color.White
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmReplaceInsAddress.ShowDialog(Me)
        Load_Ins_Addresses()
        frmReplaceInsAddress.Dispose()
        Cursor = Cursors.Default

    End Sub

    Private Sub cmdAddInsuranceAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddInsuranceGroup.Click

        If frmInsuranceCompaniesGroups.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Load_InsuranceGroups()
            cboInsuranceGrooups.Text = frmInsuranceCompaniesGroups.RetGroupName
        End If
        frmInsuranceCompaniesGroups.Dispose()
    End Sub

    Private Sub cboInsuranceGrooups_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboInsuranceGrooups.KeyUp
        gComboboxAutoComplete(cboInsuranceGrooups, e, True)
    End Sub

    Private Sub cboInsuranceGrooups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceGrooups.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxAcceptance_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxAcceptance.SelectedIndexChanged
        If Loading Then Exit Sub
        TimerSearch_Tick(Nothing, Nothing)
    End Sub

    Private Loading As Boolean

    Private Sub TimerSearch_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSearch.Tick
        TimerSearch.Enabled = False
        If Loading Then Exit Sub
        If TextBoxSearch.Text = "" And PreSelectedInsuranceID = 0 Then
            ListView1.Items.Clear()
            Clear_Controls()
            FpSpread1.Enabled = True
            Exit Sub
        End If
        Loading = True
        LabelTotal.Text = ""
        TimerSearch.Enabled = False
        Load_Companies()
        LabelTotal.Text = ListView1.Items.Count
        FpSpread1.Enabled = True
        Loading = False
        PreSelectedInsuranceID = 0
        If AddNewFlag Then
            cmdAddNew_Click(Nothing, Nothing)
            If AddNewCaseType > -1 Then
                ComboBoxCaseType.SelectedIndex = gFindComboItemByValue(ComboBoxCaseType, AddNewCaseType)
            End If
            If txtCompanyName.CanFocus Then txtCompanyName.Focus()
        End If
    End Sub

End Class