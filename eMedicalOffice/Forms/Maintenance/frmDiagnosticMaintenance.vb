Imports System.Reflection
Imports log4net

Public Class frmDiagnosticMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private m_SortingColumn As ColumnHeader
    Private OpMode As AddEditMode
    Private FormulaOpMode As AddEditMode

    Private Sub frmDiagnosticMaintenance_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        gSQLUpdateData("InitialiseDummyProcedures")
        Dispose()
    End Sub

    Private Sub frmEmployeeMaintenance_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        gWindow_Settings(Me, ReadWrite.sRead, True)
        gSetup_GotFocus(Me)
        Application.DoEvents()

        'AddHandler cboInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        'AddHandler cboInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave
        'AddHandler cboInsuranceCompanyIDSearch.KeyUp, AddressOf sSearchComboBox_KeyUp
        'AddHandler cboInsuranceCompanyIDSearch.Leave, AddressOf sSearchComboBox_Leave

        load_insurances_search()
        Load_Data()
        Load_Diagnostics()
        load_insurances()
        m_SortingColumn = ListViewFormulas.Columns(0)
        m_SortingColumn.ImageKey = "SORT1"
        Cursor = Cursors.Default
        Application.DoEvents()

    End Sub

    Private Sub load_insurances_search()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        cboInsuranceCompanyIDSearch.Items.Clear()
        cboInsuranceCompanyIDSearch.Text = ""
        With cboInsuranceCompanyIDSearch
            SQL = "Select CompanyID, CompanyName, CaseTypeID FROM InsuranceCompanies "
            SQL &= " ORDER BY CompanyName "
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then GoTo ExitSub
            .Items.Add(New ValueDescription(0, "All Companies"))
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString, "", Reader("CaseTypeID").ToString))
            Loop
            If .Items.Count = 0 Then
                .DropDownHeight = 20
            End If
        End With
        Reader.Close() : Reader.Dispose()
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Private Sub load_insurances()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        cboInsuranceCompanyID.Items.Clear()
        cboInsuranceCompanyID.Text = ""
        If cboCaseTypes.SelectedIndex = -1 Then Return
        Dim CaseTypeID = (CType(cboCaseTypes.SelectedItem, ValueDescription)).Value
        With cboInsuranceCompanyID
            SQL = "Select CompanyID, CompanyName, CaseTypeID FROM InsuranceCompanies Where CaseTypeID= " & CaseTypeID
            SQL &= " ORDER BY CompanyName "
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then GoTo ExitSub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString, "", Reader("CaseTypeID").ToString))
            Loop
            If .Items.Count = 0 Then
                .DropDownHeight = 20
            End If
        End With
        Reader.Close() : Reader.Dispose()
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If cmdUpdate.Enabled Or PanelFormula.Tag = "" Then
            If MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gWindow_Settings(Me, ReadWrite.sWrite, True)
    End Sub

    Private Sub Load_Diagnostics()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("Select DiagID, DiagName, DiagDescription, ActiveInd from Diagnostics Where Diagnostics.OfficeID= " & gOfficeID & " Order by DiagName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("DiagName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
            LI.ToolTipText = "" & Reader("DiagDescription").ToString
            LI.Tag = "" & Reader("DiagID").ToString
        Loop
        Reader.Close() : Reader.Dispose()

        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            ListView1_SelectedIndexChanged(Nothing, Nothing)
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
        End If
    End Sub

    Private Sub Load_Formulas()
        If (ListView1.SelectedItems.Count = 0) Then Return
        Dim DiagnosticID As Integer = CLng(ListView1.SelectedItems(0).Tag)
        Dim InsuranceCompanyId As Integer = 0
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim Lvi As ListViewItem.ListViewSubItem
        Dim SQL As String
        If cboInsuranceCompanyIDSearch.SelectedIndex > 0 Then
            InsuranceCompanyId = CType(cboInsuranceCompanyIDSearch.SelectedItem, ValueDescription).Value
        End If
        m_SortingColumn = Nothing
        ListViewFormulas.Items.Clear()
        SQL = "SELECT        DiagnosticsAgreementFormulas.Id, DiagnosticsAgreementFormulas.ProcedureNumber, DiagnosticsAgreementFormulas.FormulaTypeID, DiagnosticsAgreementFormulas.Formula, Employees.Fname, Employees.Lname, DiagnosticsAgreementFormulas.CreatedDate, CaseTypes.Abbreviation, Diagnostics.DiagName, InsuranceCompanies.CompanyName "
        SQL &= ", DiagnosticsAgreementFormulas.FormulaValue , DiagnosticsAgreementFormulas.InsuranceCompanyID, DiagnosticsAgreementFormulas.DiagID, DiagnosticsAgreementFormulas.CaseTypeID "
        SQL &= "                FROM            DiagnosticsAgreementFormulas INNER JOIN "
        SQL &= "                Employees ON DiagnosticsAgreementFormulas.CreatedById = Employees.EmpID INNER JOIN "
        SQL &= "                CaseTypes ON DiagnosticsAgreementFormulas.CaseTypeID = CaseTypes.CaseTypeID INNER JOIN "
        SQL &= "                Diagnostics ON DiagnosticsAgreementFormulas.DiagID = Diagnostics.DiagID INNER JOIN "
        SQL &= "                InsuranceCompanies ON DiagnosticsAgreementFormulas.InsuranceCompanyID = InsuranceCompanies.CompanyID "
        SQL &= "                WHERE        DiagnosticsAgreementFormulas.OfficeID = " & gOfficeID & " AND DiagnosticsAgreementFormulas.DiagID = " & DiagnosticID & " "
        If InsuranceCompanyId > 0 Then
            SQL &= " AND DiagnosticsAgreementFormulas.InsuranceCompanyID = " & InsuranceCompanyId
        End If
        SQL &= "                ORDER BY DiagnosticsAgreementFormulas.DiagID, DiagnosticsAgreementFormulas.InsuranceCompanyID, DiagnosticsAgreementFormulas.CaseTypeID "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Dim af As New AgreementFormula
            af.ID = Reader("ID")
            af.Abbreviation = Reader("Abbreviation").ToString()
            af.DiagName = Reader("DiagName").ToString()
            af.InsuranceCompanyName = Reader("CompanyName").ToString
            af.FormulaTypeID = Reader("FormulaTypeID")
            af.ProcedureNumber = Reader("ProcedureNumber")
            af.Formula = Reader("Formula").ToString
            af.CreatedByName = Reader("Fname").ToString.Trim() & " " & Reader("Lname").ToString.Trim()
            af.CreatedDate = CDate(Reader("CreatedDate"))
            af.InsuranceCompanyID = Reader("InsuranceCompanyID")
            af.DiagID = Reader("DiagID")
            af.CaseTypeId = Reader("CaseTypeID")
            af.OfficeID = gOfficeID
            af.FormulaValue = Val(Reader("FormulaValue").ToString())

            LI = ListViewFormulas.Items.Add(af.Abbreviation)
            LI.SubItems.Add(af.DiagName)
            LI.SubItems.Add(af.InsuranceCompanyName)
            LI.SubItems.Add(IIf(af.FormulaTypeID = 1, "PCT", "FX"))
            LI.SubItems.Add(af.ProcedureNumber)
            LI.SubItems.Add(af.Formula)
            LI.SubItems.Add(af.CreatedByName)
            LI.SubItems.Add(af.CreatedDate.ToString("MM/dd/yyyy"))
            LI.Tag = af
        Loop
        m_SortingColumn = ListViewFormulas.Columns(0)
        m_SortingColumn.ImageKey = "SORT1"
        If ListViewFormulas.Items.Count > 0 Then
            ListViewFormulas.Items(0).Selected = True
            ListViewFormulas.Items(0).EnsureVisible()
        End If
        gListViewRestoreDefaultColumnWidth(ListViewFormulas)
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Try
            SQL = "SELECT DiagTypeID, Description FROM DiagnosticTypes where DiagTypeID=" & gOfficeTypeID & " order by Description"
            Reader = gSQLGetDataReader(SQL)
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    cboOfficeType.Items.Add(New ValueDescription(CLng(Val(Reader("DiagTypeID").ToString)), Reader("Description").ToString))
                Loop
            End If
            'SQL = "SELECT CaseTypeID, Description, Abbreviation FROM CaseTypes WHERE CaseTypeID < 4 ORDER BY ShowOrder"
            ' Load NoFault only
            SQL = "SELECT CaseTypeID, Description, Abbreviation FROM CaseTypes WHERE CaseTypeID = 1 ORDER BY ShowOrder"
            Reader = gSQLGetDataReader(SQL)
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    cboCaseTypes.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Description").ToString, Reader("Abbreviation").ToString))
                Loop
            End If

            SQL = "SELECT     Fname+' '+Lname+' '+ Alias as DName, EmpID FROM Employees WHERE NoFaultInd = 1 AND BillingPrv = 1 and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")"
            Reader = gSQLGetDataReader(SQL)
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    cboBillingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString))
                Loop
                cboBillingProvider.Items.Add(New ValueDescription(0, "Not Specified"))
            End If
            SQL = "SELECT     Fname+' '+Lname+' '+ Alias as DName, EmpID FROM Employees WHERE NoFaultInd = 1 AND TreatmentPrv = 1 and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")"
            Reader = gSQLGetDataReader(SQL)
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    cboTreatingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString))
                Loop
                cboTreatingProvider.Items.Add(New ValueDescription(0, "Not Specified"))
            End If

            For I As Integer = 0 To 60
                cboInterval.Items.Add(I)
            Next
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListView1.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        gHighlightListviewItem(ListView1, False, False, Color.FromKnownColor(KnownColor.Highlight), Color.FromKnownColor(KnownColor.HighlightText))
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Clear_Controls()
        cmdEdit.Enabled = True
        cmdDelete.Enabled = True
        Try
            ID = CLng(ListView1.SelectedItems(0).Tag)
            SaveSelectedItem = ListView1.SelectedItems(0)
            Reader = gSQLGetDataReader("Select * from Diagnostics Where DiagID=" & ID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
                txtDiagName.Text = Reader("DiagName").ToString
                txtDiagDescription.Text = Reader("DiagDescription").ToString
                gFindComboItemByValue(cboOfficeType, Val(Reader("DiagTypeID").ToString), True)
                If Val(Reader("BillingProviderID").ToString) > 0 Then
                    gFindComboItemByValue(cboBillingProvider, CLng(Val(Reader("BillingProviderID").ToString)), True)
                Else
                    cboBillingProvider.SelectedIndex = -1
                End If
                If Val(Reader("TreatingProviderID").ToString) > 0 Then
                    gFindComboItemByValue(cboTreatingProvider, CLng(Val(Reader("TreatingProviderID").ToString)), True)
                Else
                    cboTreatingProvider.SelectedIndex = -1
                End If
                txtAbbreviation.Text = Reader("DiagAbbreviation").ToString
                cboInterval.Text = Val(Reader("DiagIntervalDays").ToString)
                CheckBox1.Checked = Val(Reader("Day1").ToString)
                CheckBox2.Checked = Val(Reader("Day2").ToString)
                CheckBox3.Checked = Val(Reader("Day3").ToString)
                CheckBox4.Checked = Val(Reader("Day4").ToString)
                CheckBox5.Checked = Val(Reader("Day5").ToString)
                CheckBox6.Checked = Val(Reader("Day6").ToString)
                CheckBox7.Checked = Val(Reader("Day7").ToString)
            Loop
            Reader.Close() : Reader.Dispose()
            cboInsuranceCompanyIDSearch.SelectedIndex = 0
            Load_Formulas()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me, TextBoxSearch, cboInsuranceCompanyIDSearch)
        CheckBox1.Checked = True
        CheckBox2.Checked = True
        CheckBox3.Checked = True
        CheckBox4.Checked = True
        CheckBox5.Checked = True
        CheckBox6.Checked = True
        CheckBox7.Checked = True
        cboInterval.SelectedIndex = 0
        cboInsuranceCompanyIDSearch.SelectedIndex = 0
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        gLoop_Enable_Controls(Me, En)
        TextBoxSearch.Enabled = Not En
        ListView1.Enabled = Not En
        cmdAddNew.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        PanelFormula.Enabled = True
        If En = False Then
            If ListView1.Items.Count > 0 Then
                cmdEdit.Enabled = True
                cmdDelete.Enabled = True
            Else
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            End If
        Else
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
            If cboOfficeType.SelectedIndex = -1 Then
                cboBillingProvider.Enabled = False
                cboTreatingProvider.Enabled = False
            Else
                If OpMode <> AddEditMode.None Then cboBillingProvider.Enabled = CType(cboOfficeType.SelectedItem, ValueDescription).Value <> 3
                If OpMode <> AddEditMode.None Then cboTreatingProvider.Enabled = CType(cboOfficeType.SelectedItem, ValueDescription).Value <> 3
            End If

        End If

    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdAddNew.Click
        If PanelFormula.Tag = "" Then
            TabControl1.SelectedIndex = 1
            MsgBox("Unable to process update. The Agreement Formula editor is opened." & vbCrLf & "Please update or cancel formula.", MsgBoxStyle.Exclamation)
            Return
        End If

        TabControl1.SelectedIndex = 0
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        CheckBoxActiveInd.Checked = True
        cboOfficeType.SelectedIndex = -1
        cboBillingProvider.SelectedIndex = -1
        txtAbbreviation.Text = ""
        txtDiagName.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdCancel.Click
        OpMode = AddEditMode.None
        Enable_Controls(False)
        PanelFormulaEdit.Visible = False
        PanelFormula.Visible = True
        PanelFormula.Tag = "1"
        If Not SaveSelectedItem Is Nothing Then
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        Else
            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Selected = True
                ListView1.Items(0).EnsureVisible()
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
        gLoop_ResetErrors_Controls(ErrorProvider1, Me)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdEdit.Click
        If PanelFormula.Tag = "" Then
            TabControl1.SelectedIndex = 1
            MsgBox("Unable to process update. The Agreement Formula editor is opened." & vbCrLf & "Please update or cancel formula.", MsgBoxStyle.Exclamation)
            Return
        End If
        TabControl1.SelectedIndex = 0
        OpMode = AddEditMode.Edit
        Enable_Controls(True)
        txtDiagName.Enabled = False
        txtDiagName.Focus()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If
            gLoop_Trim_Controls(Me)
            If PanelFormula.Tag = "" Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process update. The Agreement Formula editor is opened." & vbCrLf & "Please update or cancel formula.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If cboOfficeType.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(cboOfficeType, "Unable to process update. The Office Type is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Diagnostic Type is required.", MsgBoxStyle.Exclamation)
                cboOfficeType.Focus()
                Exit Sub
            End If
            If txtDiagName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtDiagName, "Unable to process update. The Diagnostic Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Diagnostic Name is required.", MsgBoxStyle.Exclamation)
                txtDiagName.Focus()
                Exit Sub
            End If
            If txtAbbreviation.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtAbbreviation, "Unable to process update. The Diagnostic Abbreviation is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Diagnostic Abbreviation is required.", MsgBoxStyle.Exclamation)
                txtAbbreviation.Focus()
                Exit Sub
            End If

            If cboInterval.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(cboInterval, "Unable to process update. The Diagnostic Interval should be selected.")
                MsgBox("Unable to process update." & vbCrLf & "The Diagnostic Interval should be selected.", MsgBoxStyle.Exclamation)
                txtAbbreviation.Focus()
                Exit Sub
            End If

            If CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False Then
                TabControl1.SelectedIndex = 0
                MsgBox("Unable to update. You have not selected any Diagnostic Day.", MsgBoxStyle.Exclamation)
                CheckBox1.Focus()
                Exit Sub
            End If

            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from Diagnostics Where DiagTypeID = " & CType(cboOfficeType.SelectedItem, ValueDescription).Value & " and OfficeID=" & gOfficeID & " and  DiagID<>" & ID & " and DiagName='" & txtDiagName.Text.ToSafeSQLString() & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from Diagnostics Where DiagTypeID = " & CType(cboOfficeType.SelectedItem, ValueDescription).Value & " and OfficeID=" & gOfficeID & " and DiagName='" & txtDiagName.Text.ToSafeSQLString() & "'")
            End If
            If Reader.Read() = True Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtDiagName, "Unable to process update. The Diagnostic Name is already exist.")
                MsgBox("Unable to process update." & vbCrLf & "The Diagnostic Name is already exist.", MsgBoxStyle.Exclamation)
                txtDiagName.Focus()
                txtDiagName.SelectAll()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()

            Dim TA As New SqlClient.SqlDataAdapter("Select * from Diagnostics Where DiagID = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Diagnostics")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("DiagName") = txtDiagName.Text
            TR("DiagDescription") = txtDiagDescription.Text
            TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
            TR("DiagTypeID") = CType(cboOfficeType.SelectedItem, ValueDescription).Value
            If cboBillingProvider.SelectedIndex > -1 Then
                TR("BillingProviderID") = CType(cboBillingProvider.SelectedItem, ValueDescription).Value
            Else
                TR("BillingProviderID") = 0
            End If
            If cboTreatingProvider.SelectedIndex > -1 Then
                TR("TreatingProviderID") = CType(cboTreatingProvider.SelectedItem, ValueDescription).Value
            Else
                TR("TreatingProviderID") = 0
            End If

            TR("OTCompanyID") = 0

            TR("DiagIntervalDays") = Val(cboInterval.Text)
            TR("DiagAbbreviation") = txtAbbreviation.Text.Trim
            TR("OfficeID") = gOfficeID
            TR("CountByVisitInd") = 0
            TR("Day1") = Math.Abs(Val(CheckBox1.Checked))
            TR("Day2") = Math.Abs(Val(CheckBox2.Checked))
            TR("Day3") = Math.Abs(Val(CheckBox3.Checked))
            TR("Day4") = Math.Abs(Val(CheckBox4.Checked))
            TR("Day5") = Math.Abs(Val(CheckBox5.Checked))
            TR("Day6") = Math.Abs(Val(CheckBox6.Checked))
            TR("Day7") = Math.Abs(Val(CheckBox7.Checked))
            TR("ForBillingOnlyInd") = 0

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

                Reader = gSQLGetDataReader("Select * from Diagnostics Where DiagID = IDENT_CURRENT('Diagnostics')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("DiagName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("DiagID").ToString
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                    SaveSelectedItem = LI
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                SaveSelectedItem.Text = txtDiagName.Text
            End If
            If CheckBoxActiveInd.Checked = True Then
                ListView1.SelectedItems(0).ImageIndex = 1
            Else
                ListView1.SelectedItems(0).ImageIndex = 0
            End If
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

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Diagnostic selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        TabControl1.SelectedIndex = 0
        If MsgBox("Please confirm you want to delete the Diagnostic " & ListView1.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable Employee.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Try
            ID = CLng(ListView1.SelectedItems(0).Tag)
            If gSQLDeleteRecord("DELETE FROM Diagnostics WHERE DiagID=" & ID) Then
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
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdClose.Click
        Close()

    End Sub

    Private Sub txtDiagName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDiagName.TextChanged
        ErrorProvider1.SetError(txtDiagName, "")
    End Sub

    Private Sub txtDiagDescription_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDiagDescription.TextChanged
        ErrorProvider1.SetError(txtDiagDescription, "")
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch)
    End Sub

    Private Sub cboOfficeType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboOfficeType.SelectedIndexChanged
        ErrorProvider1.SetError(cboOfficeType, "")
        If cboOfficeType.SelectedIndex = -1 Then
            cboBillingProvider.Enabled = False
            cboTreatingProvider.Enabled = False
        Else
            If OpMode <> AddEditMode.None Then cboBillingProvider.Enabled = CType(cboOfficeType.SelectedItem, ValueDescription).Value <> 3
            If OpMode <> AddEditMode.None Then cboTreatingProvider.Enabled = CType(cboOfficeType.SelectedItem, ValueDescription).Value <> 3
        End If

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub cboBillingProvider_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboBillingProvider.SelectedIndexChanged
        ErrorProvider1.SetError(cboBillingProvider, "")
    End Sub

    Private Sub txtAbbreviation_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAbbreviation.TextChanged
        ErrorProvider1.SetError(txtAbbreviation, "")
    End Sub

    Private Sub cboInterval_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboInterval.SelectedIndexChanged
        ErrorProvider1.SetError(cboInterval, "")
    End Sub

    Private Sub buttonFormulaAdd_Click(sender As Object, e As EventArgs) Handles buttonFormulaAdd.Click

        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "The Diagnostic is not selected.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Return
        End If
        If OpMode = AddEditMode.AddNew Then
            MsgBox("Unable to process your request." & vbCrLf & "Please complete the Diagnostic 'Add New' process first.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Return
        End If
        FormulaOpMode = AddEditMode.AddNew
        ''gFindComboItemByValue(cboCaseTypes,1,True)
        cboCaseTypes.SelectedIndex = 0
        load_insurances()
        cboInsuranceCompanyID.SelectedIndex = -1
        txtFormula.Text = ""
        RadioButtonPercent.Checked = True
        NumericUpDown1.Text = "1"
        NumericUpDownPercent.Value = 1
        NumericUpDownPercent.Enabled = True
        NumericUpDownFixed.Value = 1
        NumericUpDownFixed.Enabled = False
        PanelFormulaEdit.Visible = True
        PanelFormula.Visible = False
        cboCaseTypes.Enabled = False
        PanelFormula.Tag = ""
        cboInsuranceCompanyID.Focus()
        setup_formula()

    End Sub

    Private Sub buttonFormulaCancel_Click(sender As Object, e As EventArgs) Handles buttonFormulaCancel.Click
        If MsgBox("Discard Changes?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.No Then
            Exit Sub
        End If
        ListViewFormulas.Enabled = True
        FormulaOpMode = AddEditMode.None
        PanelFormulaEdit.Visible = False
        PanelFormula.Visible = True
        PanelFormula.Tag = "1"
    End Sub

    Private Sub buttonDeleteFormula_Click(sender As Object, e As EventArgs) Handles buttonDeleteFormula.Click
        Dim retId As Integer
        Dim retIns As String
        Dim retFormula As String
        If ListViewFormulas.SelectedItems.Count = 0 Then
            MessageBox.Show(Me, "Unable to complete your request." & vbCrLf & "No Agreement formula selected.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim LV As ListViewItem = ListViewFormulas.SelectedItems(0)
        Dim af As AgreementFormula
        af = CType(LV.Tag, AgreementFormula)
        retId = af.ID
        retIns = af.InsuranceCompanyName
        retFormula = af.Formula
        If MessageBox.Show(Me, "Please confirm you want to remove Agreement Formula:" & vbCrLf & retIns & vbCrLf & retFormula, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If
        gSQLUpdateData("Delete from DiagnosticsAgreementFormulas where ID = " & retId)
        ListViewFormulas.Items.Remove(LV)
    End Sub

    Private Sub buttonUpdateFormula_Click(sender As Object, e As EventArgs) Handles buttonUpdateFormula.Click
        Dim af As AgreementFormula
        If txtFormula.Text = "" Then
            MsgBox("Invalid formula...", MsgBoxStyle.Critical, "Formula Information")
            Return
        End If
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to update formula." & vbCrLf & "The Diagnostic is not selected.", MsgBoxStyle.Exclamation, "Oh...")
            ListView1.Focus()
            Return
        End If
        If FormulaOpMode = AddEditMode.Edit Then
            If ListViewFormulas.SelectedItems.Count = 0 Then
                MsgBox("Unable to update formula." & vbCrLf & "No Formula selected.", MsgBoxStyle.Exclamation, "Oh...")
                ListView1.Focus()
                Return
            End If
        End If

        If cboCaseTypes.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 1
            MsgBox("Unable to update formula." & vbCrLf & "The Case Type should be selected.", MsgBoxStyle.Exclamation, "Oh...")
            cboCaseTypes.Focus()
            Return
        End If

        cboInsuranceCompanyID.SelectedIndex = cboInsuranceCompanyID.FindStringExact(cboInsuranceCompanyID.Text)
        If cboInsuranceCompanyID.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 1
            MsgBox("Unable to update formula." & vbCrLf & "The Insurance Company should be selected.", MsgBoxStyle.Exclamation, "Oh...")
            cboInsuranceCompanyID.Focus()
            Return
        End If

        If CheckFormula(True, False) = False Then
            Return
        End If
        Dim LI As ListViewItem
        If FormulaOpMode = AddEditMode.AddNew Then
            af = New AgreementFormula
            LI = ListViewFormulas.Items.Add("")
        Else
            af = CType(ListViewFormulas.SelectedItems(0).Tag, AgreementFormula)
            LI = ListViewFormulas.SelectedItems(0)
        End If
        af.DiagID = Int(ListView1.SelectedItems(0).Tag)
        af.DiagName = ListView1.SelectedItems(0).Text
        af.CaseTypeId = (CType(cboCaseTypes.SelectedItem, ValueDescription)).Value
        af.CaseType = cboCaseTypes.Text
        af.Abbreviation = CType(cboCaseTypes.SelectedItem, ValueDescription).Value1
        af.InsuranceCompanyID = (CType(cboInsuranceCompanyID.SelectedItem, ValueDescription)).Value
        af.InsuranceCompanyName = (CType(cboInsuranceCompanyID.SelectedItem, ValueDescription)).Description
        af.OfficeID = gOfficeID
        af.CreatedByName = gCurrentEmployee.FName.Trim() & " " & gCurrentEmployee.LName.Trim()
        af.ProcedureNumber = NumericUpDown1.Value
        af.FormulaTypeID = IIf(RadioButtonPercent.Checked, 1, 2)
        af.Formula = Replace(txtFormula.Text, "$Price", "")
        af.FormulaValue = IIf(RadioButtonPercent.Checked, NumericUpDownPercent.Value, NumericUpDownFixed.Value)
        af.CreatedById = gCurrentEmployee.EmpID
        Dim SQL As String
        SQL = "SELECT count(*) c FROM DiagnosticsAgreementFormulas WHERE "
        SQL &= "OfficeID = " & af.OfficeID & " AND "
        SQL &= "DiagID = " & af.DiagID & " AND "
        SQL &= "InsuranceCompanyID = " & af.InsuranceCompanyID & " AND "
        SQL &= "CaseTypeID = " & af.CaseTypeId & " AND "
        SQL &= "ProcedureNumber = " & af.ProcedureNumber & " AND "
        SQL &= "ID <> " & af.ID
        If gSQLGetSingleValue(SQL) > 0 Then
            Dim msg As String
            TabControl1.SelectedIndex = 1
            msg = "Unable to update an Agreement Formula." & vbCrLf & vbCrLf & "The Agreement Formula for:" & vbCrLf & vbCrLf
            msg &= "Case: " & af.CaseType & vbCrLf
            msg &= "Diagnostic: " & af.DiagName & vbCrLf
            msg &= "Insurance Company: " & af.InsuranceCompanyName & vbCrLf
            msg &= "Procedure Number: " & af.ProcedureNumber & vbCrLf & vbCrLf
            msg &= "Is already exists..." & vbCrLf & vbCrLf
            msg &= "If you need to update an Agreement Formula, delete it and re-create new formula with the new values."

            MsgBox(msg, MsgBoxStyle.Critical, "Duplicate Formula")
            cboInsuranceCompanyID.Focus()
            Return
        End If

        Try
            If FormulaOpMode = AddEditMode.AddNew Then
                SQL = "INSERT INTO [DiagnosticsAgreementFormulas] ([OfficeID],[DiagID],[InsuranceCompanyID],[CaseTypeID],[ProcedureNumber],[FormulaTypeID],[Formula], [FormulaValue], [CreatedById]) VALUES "
                SQL &= " ( " & gOfficeID & ", " & af.DiagID & ", " & af.InsuranceCompanyID & ", " & af.CaseTypeId & ", " & af.ProcedureNumber & ", " & af.FormulaTypeID & ", '" & af.Formula & "', " & af.FormulaValue & ", " & af.CreatedById & ")"
            Else
                SQL = " UPDATE [dbo].[DiagnosticsAgreementFormulas] "
                SQL &= " SET [OfficeID] = " & af.OfficeID
                SQL &= " ,[DiagID] = " & af.DiagID
                SQL &= " ,[InsuranceCompanyID] = " & af.InsuranceCompanyID
                SQL &= " ,[CaseTypeID] = " & af.CaseTypeId
                SQL &= " ,[ProcedureNumber] = " & af.ProcedureNumber
                SQL &= " ,[FormulaTypeID] = " & af.FormulaTypeID
                SQL &= " ,[Formula] = '" & af.Formula & "'"
                SQL &= " ,[FormulaValue] = " & af.FormulaValue
                SQL &= " ,[CreatedById] = " & af.CreatedById
                SQL &= " ,[CreatedDate] = getdate()"
                SQL &= " WHERE ID = " & af.ID
            End If
            If gSQLUpdateData(SQL) = False Then Return
            If FormulaOpMode = AddEditMode.AddNew Then
                af.ID = gSQLGetSingleValue("Select IDENT_CURRENT('DiagnosticsAgreementFormulas')")
            End If
            LI.Text = af.Abbreviation
            LI.SubItems.Add(af.DiagName)
            LI.SubItems.Add(af.InsuranceCompanyName)
            LI.SubItems.Add(IIf(af.FormulaTypeID = 1, "PCT", "FX"))
            LI.SubItems.Add(af.ProcedureNumber)
            LI.SubItems.Add(af.Formula)
            LI.SubItems.Add(af.CreatedByName)
            LI.SubItems.Add(af.CreatedDate.ToString("MM/dd/yyyy"))
            LI.Tag = af

            cboInsuranceCompanyIDSearch.SelectedIndex = 0
            Load_Formulas()
            For Each item As ListViewItem In ListViewFormulas.Items
                If Val((item.Tag.ToString())) = af.ID Then
                    item.Selected = True
                    item.EnsureVisible()
                End If
            Next
            PanelFormulaEdit.Visible = False
            PanelFormula.Visible = True
            PanelFormula.Tag = "1"
            FormulaOpMode = AddEditMode.None
            ListViewFormulas.Enabled = True
            ListViewFormulas.Focus()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try

    End Sub

    Private Sub cboInsuranceCompanyID_KeyUp(sender As Object, e As KeyEventArgs) Handles cboInsuranceCompanyID.KeyUp
        gComboboxAutoComplete(cboInsuranceCompanyID, e, True)
    End Sub

    Private Sub setup_formula()
        If RadioButtonPercent.Checked Then
            txtFormula.Text = "$Price / 100 * " & NumericUpDownPercent.Value
        Else
            txtFormula.Text = "$Price * 0 + " & NumericUpDownFixed.Value
        End If

    End Sub

    Private Sub RadioButtonPercent_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonPercent.CheckedChanged
        If RadioButtonPercent.Checked Then
            NumericUpDownPercent.Enabled = True
            NumericUpDownPercent.BackColor = Color.White
            NumericUpDownFixed.BackColor = Color.LightGray
            NumericUpDownFixed.Enabled = False
            NumericUpDownPercent.Focus()
        Else
            NumericUpDownPercent.BackColor = Color.LightGray
            NumericUpDownFixed.BackColor = Color.White
            NumericUpDownPercent.Enabled = False
            NumericUpDownFixed.Enabled = True
            NumericUpDownFixed.Focus()
        End If
        setup_formula()
    End Sub

    Private Sub NumericUpDownPercent_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownPercent.ValueChanged
        setup_formula()
    End Sub

    Private Sub NumericUpDownFixed_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownFixed.ValueChanged
        setup_formula()
    End Sub

    Private Sub ButtonProcessFormula_Click(sender As Object, e As EventArgs) Handles ButtonProcessFormula.Click
        CheckFormula(True, True)
    End Sub

    Private Function CheckFormula(showErrorMessages As Boolean, showFinalCalculationMessage As Boolean) As Boolean
        Dim lvi As ListViewItem
        If txtFormula.Text = "" Then
            If showErrorMessages Then
                MsgBox("Invalid formula...", MsgBoxStyle.Critical, "Formula Information")
            End If
            Return False
        End If
        If ListView1.SelectedItems.Count = 0 Then
            If showErrorMessages Then
                MsgBox("Unable to process formula." & vbCrLf & "The Diagnostic is not selected selected.", MsgBoxStyle.Exclamation)
                ListView1.Focus()
            End If
            Return False
        End If
        lvi = ListView1.SelectedItems(0)
        cboCaseTypes.SelectedIndex = cboCaseTypes.FindStringExact(cboCaseTypes.Text)
        If cboCaseTypes.SelectedIndex = -1 Then
            If showErrorMessages Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process formula." & vbCrLf & "The Case Type should be selected.", MsgBoxStyle.Exclamation)
                cboCaseTypes.Focus()
            End If
            Return False
        End If
        cboInsuranceCompanyID.SelectedIndex = cboInsuranceCompanyID.FindStringExact(cboInsuranceCompanyID.Text)
        If cboInsuranceCompanyID.SelectedIndex = -1 Then
            If showErrorMessages Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process formula." & vbCrLf & "The Insurance Company should be selected.", MsgBoxStyle.Exclamation)
                cboInsuranceCompanyID.Focus()
            End If
            Return False
        End If

        Dim msg As String
        Dim dt = New DataTable()
        Dim newprice As Decimal
        Dim DiagnosticName As String = lvi.Text
        Const SampleProcedurePrice As Decimal = 898.23
        Dim CaseTypeName As String = cboCaseTypes.Text
        Dim InsuranceCompany As String = cboInsuranceCompanyID.Text
        Dim Formula As String = Replace(txtFormula.Text, "$Price", "")
        Try
            newprice = CDec(dt.Compute(SampleProcedurePrice & Formula, ""))
            If showFinalCalculationMessage Then
                msg = CaseTypeName & " - " & DiagnosticName & " Formula Calculation Example:" & vbCrLf & vbCrLf
                msg &= "Assume the " & CaseTypeName & " - " & DiagnosticName & " procedure price is $" & SampleProcedurePrice & vbCrLf
                msg &= "The formula is [$" & SampleProcedurePrice & Formula & "]" & vbCrLf & vbCrLf
                msg &= "The " & CaseTypeName & " agreement price for the" & vbCrLf & InsuranceCompany & vbCrLf & "will be: $" & Math.Round(newprice, 2) & vbCrLf
                MsgBox(msg, MsgBoxStyle.Information, "Formula Information")
            End If
        Catch ex As Exception
            msg = ex.Message
            MsgBox(msg, MsgBoxStyle.Critical, "Formula Information")
            Return False
        End Try
        Return True
    End Function

    Private Sub cboCaseTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCaseTypes.SelectedIndexChanged
        load_insurances()
    End Sub

    Private Sub ListViewFormulas_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewFormulas.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewFormulas.Columns(e.Column)
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
        ListViewFormulas.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewFormulas.Sort()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBoxAutoReasize.Click
        gListViewRestoreDefaultColumnWidth(ListViewFormulas)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        PictureBoxAutoReasize.Visible = TabControl1.SelectedIndex = 1
    End Sub

    Private Sub cboInsuranceCompanyIDSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles cboInsuranceCompanyIDSearch.KeyUp
        gComboboxAutoComplete(cboInsuranceCompanyIDSearch, e, True)
    End Sub

    Private Sub cboInsuranceCompanyIDSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInsuranceCompanyIDSearch.SelectedIndexChanged
        cboInsuranceCompanyIDSearch.FindStringExact(cboInsuranceCompanyIDSearch.Text)
        Load_Formulas()
    End Sub

    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        cboInsuranceCompanyIDSearch.FindStringExact(cboInsuranceCompanyIDSearch.Text)
        Load_Formulas()
    End Sub

    Private Sub cboInsuranceCompanyIDSearch_TextChanged(sender As Object, e As EventArgs) Handles cboInsuranceCompanyIDSearch.TextChanged
    End Sub

    Private Sub ListViewFormulas_MouseDown(sender As Object, e As MouseEventArgs) Handles ListViewFormulas.MouseDown
        Dim ret As ListViewHitTestInfo = ListViewFormulas.HitTest(New Point(e.X, e.Y))
        If Not ret.Item Is Nothing Then
            ret.Item.Selected = True
            ret.Item.EnsureVisible()
        End If
    End Sub

    Private Sub ContextMenuStripCustomizeToolStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripCustomizeToolStrip.Opening
        If ListViewFormulas.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub CustomizeToolbarDeleteFormula_Click(sender As Object, e As EventArgs) Handles CustomizeToolbarDeleteFormula.Click
        buttonDeleteFormula_Click(Nothing, Nothing)
    End Sub

    Private Sub buttonFormulaEdit_Click(sender As Object, e As EventArgs) Handles buttonFormulaEdit.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "The Diagnostic is not selected.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Return
        End If
        If ListViewFormulas.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "The Diagnostic is not selected.", MsgBoxStyle.Exclamation)
            ListViewFormulas.Focus()
            Return
        End If
        If OpMode = AddEditMode.AddNew Then
            MsgBox("Unable to process your request." & vbCrLf & "Please complete the Diagnostic 'Add New' process first.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Return
        End If
        FormulaOpMode = AddEditMode.AddNew
        Dim af As AgreementFormula
        af = CType(ListViewFormulas.SelectedItems(0).Tag, AgreementFormula)

        'gFindComboItemByValue(cboCaseTypes,af.CaseTypeId,True)
        cboCaseTypes.SelectedIndex = 0
        load_insurances()
        gFindComboItemByValue(cboInsuranceCompanyID, af.InsuranceCompanyID, True)
        txtFormula.Text = af.Formula
        If af.FormulaTypeID = 1 Then
            RadioButtonPercent.Checked = True
            NumericUpDownPercent.Enabled = True
            NumericUpDownPercent.Value = af.FormulaValue
            NumericUpDownFixed.Value = "0"
        Else
            RadioButtonFixed.Checked = True
            NumericUpDownFixed.Enabled = False
            NumericUpDownFixed.Value = af.FormulaValue
            NumericUpDownPercent.Value = "0"
        End If
        NumericUpDown1.Text = af.ProcedureNumber
        PanelFormulaEdit.Visible = True
        PanelFormula.Visible = False
        PanelFormula.Tag = ""
        ListViewFormulas.Enabled = False
        cboCaseTypes.Enabled = False
        FormulaOpMode = AddEditMode.Edit
        cboInsuranceCompanyID.Focus()
        setup_formula()

    End Sub

    Private Sub ListViewFormulas_DoubleClick(sender As Object, e As EventArgs) Handles ListViewFormulas.DoubleClick
        If ListViewFormulas.SelectedItems.Count = 0 Then Return
        buttonFormulaEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If ListViewFormulas.SelectedItems.Count = 0 Then
            Return
        End If
        buttonFormulaEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting

    End Sub

End Class