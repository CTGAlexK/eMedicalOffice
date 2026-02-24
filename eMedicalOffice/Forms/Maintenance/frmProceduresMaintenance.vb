Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Reflection
Imports log4net

Public Class frmProcedureMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode
    Private m_SortingColumn As ColumnHeader
    Private m_SortingColumn1 As ColumnHeader
    Private SkipLoad As Boolean

    Private Sub frmProcedureMaintenance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub

    Private Sub frmEmployeeMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        gSetup_GotFocus(Me)
        gListview_Settings(Me, ListViewDiagnosis, ReadWrite.sRead)
        gListview_Settings(Me, ListViewDiagnosisSelected, ReadWrite.sRead)
        Application.DoEvents()
        Load_Data()
        Cursor = Cursors.Default
        m_SortingColumn = ListViewDiagnosis.Columns(2)
        m_SortingColumn1 = ListViewDiagnosisSelected.Columns(2)
        Application.DoEvents()
        txtProcName.AutoCompleteCustomSource = gAutocompleteProcName
        lblNYNFWarning.Visible = gOfficeTypeID = 1
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewDiagnosis, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewDiagnosisSelected, ReadWrite.sWrite)
        If cmdUpdate.Enabled Then
            If _
                MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) =
                MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Load_Procedures()
        Dim Reader As SqlDataReader
        Dim LI As ListViewItem
        Dim Img As Integer
        ListView1.Items.Clear()
        If ComboBoxDiagIDSearch.SelectedItem Is Nothing Then Exit Sub
        If CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value = 0 Then
            Reader =
                gSQLGetDataReader(
                    "SELECT    Procedures.ProcID, Procedures.ProcName, Procedures.ProcDescription, Procedures.ActiveInd FROM Procedures INNER JOIN Diagnostics ON Procedures.DiagID = Diagnostics.DiagID WHERE ProcedureTypeID<>0 and Diagnostics.OfficeID = " &
                    gOfficeID & " ORDER BY Procedures.ProcName ")
        Else
            Reader =
                gSQLGetDataReader(
                    "Select ProcID, ProcName, ProcDescription, ActiveInd from Procedures Where ProcedureTypeID<>0 and DiagID=" &
                    CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value.ToString & " Order by ProcName")
        End If
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Img = CInt(Val("" & Reader("ActiveInd").ToString))
            LI = ListView1.Items.Add(Reader("ProcName").ToString, Img)
            LI.ToolTipText = "" & Reader("ProcName").ToString
            LI.Tag = "" & Reader("ProcID").ToString
        Loop
        Reader.Close()
        Reader.Dispose()
        Application.DoEvents()
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            ListView1_SelectedIndexChanged(Nothing, Nothing)
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
        Else
            Clear_Controls()
        End If
    End Sub

    Private LoadingFlag As Boolean

    Private Sub Load_Data()
        Dim Reader As SqlDataReader
        Dim SQL As String
        Dim I As Integer

        SQL =
            "SELECT     Diagnostics.DiagID, Diagnostics.DiagName, Diagnostics.DiagTypeID, DiagnosticTypes.Description FROM Diagnostics INNER JOIN DiagnosticTypes ON Diagnostics.DiagTypeID = DiagnosticTypes.DiagTypeID Where OfficeID = " &
            gOfficeID & " ORDER BY DiagnosticTypes.Description, Diagnostics.DiagName"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ComboBoxDiagIDSearch.Items.Add(New ValueDescription(0, "Show All"))
        Do Until Reader.Read = False
            ComboBoxDiagIDSearch.Items.Add(New ValueDescription(CLng(Val(Reader("DiagID").ToString)),
                                                                Reader("DiagName").ToString,
                                                                Reader("DiagTypeID").ToString))
            ComboBoxDiagID.Items.Add(New ValueDescription(CLng(Val(Reader("DiagID").ToString)),
                                                          Reader("DiagName").ToString, Reader("DiagTypeID").ToString))
        Loop
        For I = 0 To 60
            cboMinDays.Items.Add(I)
            cboInterval.Items.Add(I)
        Next
        ComboBoxDiagIDSearch.SelectedIndex = 0
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private DoNotSearch As Boolean

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlDataReader
        If SkipLoad Then Exit Sub
        gHighlightListviewItem(ListView1, False, False, Color.FromKnownColor(KnownColor.Highlight), Color.FromKnownColor(KnownColor.HighlightText))
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        TextBoxSearchDiagnos.Text = ""
        Application.DoEvents()
        ID = CLng(ListView1.SelectedItems(0).Tag)
        SaveSelectedItem = ListView1.SelectedItems(0)
        Clear_Controls()
        cmdEdit.Enabled = True
        cmdDelete.Enabled = True
        Reader = gSQLGetDataReader("Select * from Procedures Where ProcID=" & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
            txtProcName.Text = "" & Reader("ProcName").ToString
            LabelProcedureName.Text = "" & Reader("ProcName").ToString & " Diagnosis"
            txtProcDescription.Text = "" & Reader("ProcDescription").ToString
            gFindComboItemByValue(ComboBoxDiagID, CLng(Val(Reader("DiagID").ToString)), True)
            cboMinDays.Text = "" & Reader("MinDaysFromDOA").ToString
            cboInterval.Text = Val(Reader("ProcedureIntervalDays").ToString)
            txtCode.Text = "" & Reader("Code").ToString
            txtModifier.Text = "" & Reader("Modifier").ToString
            txtComments.Text = "" & Reader("Comments").ToString
            txtNFPrice.Text = CType(Val(Reader("NFCost").ToString).ToString, Double).ToString("N2")
            txtWCPrice.Text = CType(Val(Reader("WCCost").ToString).ToString, Double).ToString("N2")
            txtPRPrice.Text = CType(Val(Reader("PRCost").ToString).ToString, Double).ToString("N2")
            txtAbbr.Text = "" & Reader("Abbr").ToString
        Loop
        Reader.Close()
        Reader.Dispose()
        Load_Diagnosis(ID)
        Load_DiagnosisSelected(ID)
        Cursor = Cursors.Default
    End Sub

    Private Sub Load_Diagnosis(ID As Long, Optional ByVal SearchText As String = "")
        Dim Reader As SqlDataReader
        Dim Li As ListViewItem
        Dim SQL As String
        Dim D = ""
        For Each Li In ListViewDiagnosisSelected.Items
            D = D & Li.Tag & ", "
        Next
        If D <> "" Then
            D = D.Mid(1, Len(D) - 2)
        End If
        ListViewDiagnosis.Items.Clear()
        SQL =
            "SELECT     DignosisID, ICDCode, ICDDescription, ICDGroup FROM Diagnosis WHERE ActiveInd=1 and DignosisID NOT IN "
        SQL = SQL &
              " (SELECT     ProcedureDiagnosis.DignosisID FROM ProcedureDiagnosis WHERE ProcedureDiagnosis.ProcID = " &
              ID & ") "
        If D <> "" Then
            SQL = SQL & "  and DignosisID NOT IN  (" & D & ")"
        End If

        SearchText = SearchText.Trim
        If SearchText <> "" Then
            If IsNumeric(SearchText) Then
                SQL = SQL & " AND ICDCode Like '" & SearchText.ToSafeSQLString() & "%'"
            Else
                SQL = SQL & " AND ICDDescription Like '" & SearchText.ToSafeSQLString() & "%' or ICDGroup Like '" & SearchText.ToSafeSQLString() &
                      "%'"

            End If
        End If
        SQL = SQL & " ORDER BY ICDGroup, ICDDescription"
        Reader = gSQLGetDataReader(SQL)

        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Li = ListViewDiagnosis.Items.Add(Reader("ICDCode").ToString)
            Li.SubItems.Add(Reader("ICDDescription").ToString)
            Li.SubItems.Add(Reader("ICDGroup").ToString)
            Li.Tag = Reader("DignosisID").ToString
        Loop
        Reader.Close()
        Reader.Dispose()
    End Sub

    Private Sub Load_DiagnosisSelected(ID As Long)
        Dim Reader As SqlDataReader
        Dim SQL As String
        Dim Li As ListViewItem
        ListViewDiagnosisSelected.Items.Clear()
        SQL =
            " SELECT     Diagnosis.DignosisID, Diagnosis.ICDCode, Diagnosis.ICDDescription, Diagnosis.ICDGroup, ProcedureDiagnosis.ProcID FROM Diagnosis LEFT OUTER JOIN ProcedureDiagnosis ON Diagnosis.DignosisID = ProcedureDiagnosis.DignosisID "
        SQL = SQL & " WHERE ProcedureDiagnosis.ProcID = " & ID & " ORDER BY ICDGroup, ICDDescription"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Li = ListViewDiagnosisSelected.Items.Add(Reader("ICDCode").ToString)
            Li.SubItems.Add(Reader("ICDDescription").ToString)
            Li.SubItems.Add(Reader("ICDGroup").ToString)
            Li.Tag = Reader("DignosisID").ToString
        Loop
        Reader.Close()
        Reader.Dispose()
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me, ComboBoxDiagIDSearch, TextBoxSearch)
        LabelProcedureName.Text = ""
        ComboBoxDiagID.SelectedIndex = -1
        cboMinDays.SelectedIndex = 0
        cboInterval.SelectedIndex = 0
        txtNFPrice.Text = 0
        txtWCPrice.Text = 0
        txtPRPrice.Text = 0
    End Sub

    Private Sub Enable_Controls(En As Boolean)
        gLoop_Enable_Controls(Me, En)

        ListView1.Enabled = Not En
        cmdAddNew.Enabled = Not En
        ButtonRefresh.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        ButtonDuplicate.Enabled = Not En
        ButtonDn.Enabled = En
        ButtonUp.Enabled = En
        ButtonAddDiagnos.Enabled = En
        ListViewDiagnosis.BackColor = IIf(En, Color.White, Color.WhiteSmoke)
        ListViewDiagnosisSelected.BackColor = IIf(En, Color.White, Color.WhiteSmoke)
        ComboBoxDiagIDSearch.Enabled = Not En
        ComboBoxDiagID.Enabled = En
        TextBoxSearch.Enabled = Not En
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
        End If
    End Sub

    Private Sub cmdAddNew_Click(sender As Object, e As EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        CheckBoxActiveInd.Checked = True
        ListViewDiagnosisSelected.Items.Clear()
        Load_Diagnosis(-1)
        txtProcName.Focus()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        If MsgBox("Discard Changes?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.No _
            Then
            Exit Sub
        End If
        OpMode = AddEditMode.None
        Enable_Controls(False)

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

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        OpMode = AddEditMode.Edit
        Enable_Controls(True)

        txtProcName.Focus()
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Reader As SqlDataReader
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                TabControl1.SelectedIndex = 0
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If
            gLoop_Trim_Controls(Me)

            If ComboBoxDiagID.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(ComboBoxDiagID,
                                        "Unable to process update. The Procedure Diagnostic should be selected.")
                MsgBox("Unable to process update. The Procedure Diagnostic should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxDiagID.Focus()
                Exit Sub
            End If
            If txtProcName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtProcName, "Unable to process update. The Procedure Name is required.")
                MsgBox("Unable to process update. The Procedure Name is required.", MsgBoxStyle.Exclamation)
                txtProcName.Focus()
                Exit Sub
            End If

            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                '    Reader = gSQLGetDataReader("Select * from Procedures Where DiagID = " & CType(ComboBoxDiagID.SelectedItem, ValueDescription).Value & " and  ProcedureTypeID = " & CType(cboProcedureTypeID.SelectedItem, ValueDescription).Value & " and ProcID<>" & ID & " and ProcName='" & RBC(txtProcName.Text) & "'")
            Else
                ID = -1
                '    Reader = gSQLGetDataReader("Select * from Procedures Where ProcName='" & RBC(txtProcName.Text) & "'")

                'If Reader.Read() = True Then
                '    ErrorProvider1.SetError(txtProcName, "Unable to process update. The Procedure Name is already exist.")
                '    MsgBox("Unable to process update. The Procedure Name is already exist.", MsgBoxStyle.Exclamation)
                '    txtProcName.Focus()
                '    txtProcName.SelectAll()
                '    Exit Sub
                'End If
            End If
            If txtModifier.Text <> "" And txtModifier.Text.Length <> 2 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtModifier, "Unable to process update. The Procedure Modifier should be 2 digits value.")
                MsgBox("Unable to process update. The Procedure Modifier should be 2 digits value.", MsgBoxStyle.Exclamation)
                txtModifier.Focus()
                Exit Sub
            End If
            If _
                Val(CType(ComboBoxDiagID.SelectedItem, ValueDescription).Value1) <> 3 And
                Val(CType(ComboBoxDiagID.SelectedItem, ValueDescription).Value1) <> 4 Then
                If txtCode.Text = "" Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtCode, "Unable to process update. The Procedure Code is required.")
                    MsgBox("Unable to process update. The Procedure Code is required.", MsgBoxStyle.Exclamation)
                    txtCode.Focus()
                    Exit Sub
                End If
                If IsNumeric(txtCode.Text) = False Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtCode,
                                            "Unable to process update. Invalid Procedure Code specified. The Procedure Code should be numeric value.")
                    MsgBox(
                        "Unable to process update. Invalid Procedure Code specified.  The Procedure Code should be numeric value.",
                        MsgBoxStyle.Exclamation)
                    txtCode.Focus()
                    txtCode.SelectAll()
                    Exit Sub
                End If
                If cboMinDays.SelectedIndex = -1 Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(cboMinDays,
                                            "Unable to process update. The Procedure No Fault minimum days from DOA should be selected.")
                    MsgBox("Unable to process update. The Procedure No Fault minimum days from DOA should be selected.",
                           MsgBoxStyle.Exclamation)
                    cboMinDays.Focus()
                    Exit Sub
                End If

                If cboInterval.SelectedIndex = -1 Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(cboInterval,
                                            "Unable to process update. The Procedure Interval should be selected.")
                    MsgBox("Unable to process update. The Procedure Interval should be selected.",
                           MsgBoxStyle.Exclamation)
                    cboMinDays.Focus()
                    Exit Sub
                End If
                If txtNFPrice.Text = "" Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtNFPrice,
                                            "Unable to process update. The Procedure No Fault Price is required.")
                    MsgBox("Unable to process update. The Procedure No Fault Price is required.",
                           MsgBoxStyle.Exclamation)
                    txtNFPrice.Focus()
                    Exit Sub
                End If
                If IsNumeric(txtNFPrice.Text) = False Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtNFPrice,
                                            "Unable to process update. Invalid Procedure No Fault Price. The Procedure Procedure No Fault Price should be numeric value.")
                    MsgBox(
                        "Unable to process update. Invali Procedure No Fault Price. The Procedure No Fault Price should be numeric value.",
                        MsgBoxStyle.Exclamation)
                    txtNFPrice.Focus()
                    txtNFPrice.SelectAll()
                    Exit Sub
                End If

                If txtWCPrice.Text = "" Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtWCPrice,
                                            "Unable to process update. The Procedure Working Compnsation Price is required.")
                    MsgBox("Unable to process update. The Procedure Working Compensation Price is required.",
                           MsgBoxStyle.Exclamation)
                    txtWCPrice.Focus()
                    Exit Sub
                End If
                If IsNumeric(txtWCPrice.Text) = False Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtWCPrice,
                                            "Unable to process update. Invalid Procedure Working Compensation Price. The Procedure Procedure No Fault Price should be numeric value.")
                    MsgBox(
                        "Unable to process update. Invali Procedure Working Compensation Price. The Procedure Working Compensation Price should be numeric value.",
                        MsgBoxStyle.Exclamation)
                    txtWCPrice.Focus()
                    txtWCPrice.SelectAll()
                    Exit Sub
                End If

                If txtPRPrice.Text = "" Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtPRPrice,
                                            "Unable to process update. The Procedure Private Insurance Price is required.")
                    MsgBox("Unable to process update. The Procedure Private Insurance Price is required.",
                           MsgBoxStyle.Exclamation)
                    txtPRPrice.Focus()
                    Exit Sub
                End If
                If IsNumeric(txtPRPrice.Text) = False Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtPRPrice,
                                            "Unable to process update. Invalid Procedure Private Insurance Price. The Procedure Procedure No Fault Price should be numeric value.")
                    MsgBox(
                        "Unable to process update. Invali Procedure Private Insurance Price. The Procedure Private Insurance Price should be numeric value.",
                        MsgBoxStyle.Exclamation)
                    txtPRPrice.Focus()
                    txtPRPrice.SelectAll()
                    Exit Sub
                End If
            End If

            'Reader.Close():  Reader.Dispose()

            Dim TA As New SqlDataAdapter("Select * from Procedures Where ProcID = " & ID, gConnectionString)
            Dim CB As New SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Procedures")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("ProcName") = txtProcName.Text
            TR("ProcDescription") = txtProcDescription.Text
            TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
            TR("DiagID") = CType(ComboBoxDiagID.SelectedItem, ValueDescription).Value
            TR("MinDaysFromDOA") = Val(cboMinDays.Text)
            TR("ProcedureIntervalDays") = Val(cboInterval.Text)
            TR("Code") = Val(txtCode.Text)
            TR("Modifier") = txtModifier.Text

            TR("Comments") = txtComments.Text.Trim
            If IsNumeric(txtNFPrice.Text) Then
                TR("NFCost") = CType(txtNFPrice.Text, Double).ToString("N2")
            Else
                TR("NFCost") = 0
            End If
            If IsNumeric(txtWCPrice.Text) Then
                TR("WCCost") = CType(txtWCPrice.Text, Double).ToString("N2")
            Else
                TR("WCCost") = 0
            End If
            If IsNumeric(txtPRPrice.Text) Then
                TR("PRCost") = CType(txtPRPrice.Text, Double).ToString("N2")
            Else
                TR("PRCost") = 0
            End If
            TR("ProcedureTypeID") = 1
            TR("PrescribedByProcID") = 0
            TR("Abbr") = txtAbbr.Text.Trim.ToUpper
            TR("ForBillingOnly") = 0
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
            SkipLoad = True
            If OpMode = AddEditMode.AddNew Then

                Reader =
                    gSQLGetDataReader("Select * from Procedures Where ProcID = IDENT_CURRENT('Procedures')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("ProcName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.ToolTipText = "" & Reader("ProcName").ToString
                    LI.Tag = "" & Reader("ProcID").ToString
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()

                    ID = CLng(Val(Reader("ProcID").ToString))
                    SaveSelectedItem = LI
                Loop
                Reader.Close()
                Reader.Dispose()
            Else
                SaveSelectedItem.Text = txtProcName.Text
            End If
            SkipLoad = False
            If CheckBoxActiveInd.Checked = True Then
                ListView1.SelectedItems(0).ImageIndex = 1
            Else
                ListView1.SelectedItems(0).ImageIndex = 0
            End If
            gSQLUpdateData("Delete From ProcedureDiagnosis where ProcID=" & ID)
            For Each LI In ListViewDiagnosisSelected.Items
                gSQLUpdateData(
                    "INSERT INTO ProcedureDiagnosis (DignosisID, ProcID,ChangedBy, ChangedDT) VALUES(" & LI.Tag & ", " &
                    ID & ", " & gCurrentEmployee.EmpID & ", '" & Now.ToString("MM/dd/yyyy") & "')")
            Next

            OpMode = AddEditMode.None
            ListView1_SelectedIndexChanged(Nothing, Nothing)
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

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        ID = CLng(ListView1.SelectedItems(0).Tag)
        If gSQLGetSingleValue("select count(*) from PatientProcedures Where ProcID=" & ID) Then
            MsgBox("Unable to delete the selected procedure." & vbCrLf & "This procedure is already in use.",
                   MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If _
            MsgBox(
                "Please confirm you want to delete the Procedure " & ListView1.SelectedItems(0).Text & "?" & vbCrLf &
                vbCrLf & "It is highly recommended to use the Active Indicator to disable procedure instead.",
                MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        If gSQLDeleteRecord("DELETE FROM Procedures WHERE ProcID=" & ID) Then
            gSQLDeleteRecord("DELETE FROM ProcedureDiagnosis WHERE ProcID = " & ID)
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

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    Private Sub txtProcName_TextChanged(sender As Object, e As EventArgs) Handles txtProcName.TextChanged
        ErrorProvider1.SetError(txtProcName, "")
        LabelProcedureName.Text = txtProcName.Text & " Diagnosis"
    End Sub

    Private Sub txtProcDescription_TextChanged(sender As Object, e As EventArgs) Handles txtProcDescription.TextChanged
        ErrorProvider1.SetError(txtProcDescription, "")
    End Sub

    Private Sub ComboBoxProcedureType_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles ComboBoxDiagIDSearch.SelectedIndexChanged
        Load_Procedures()
    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch)
    End Sub

    Private Sub txtProcedurePrice_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles txtNFPrice.KeyPress, txtWCPrice.KeyPress, txtPRPrice.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, sender)
    End Sub

    Private Sub txtProcedurePrice_TextChanged(sender As Object, e As EventArgs) _
        Handles txtNFPrice.TextChanged, txtWCPrice.TextChanged, txtPRPrice.TextChanged
        ErrorProvider1.SetError(sender, "")
        picNFPrice.Visible = False
        picWCPrice.Visible = False
        txtNFPrice.BackColor = Color.White
        picWCPrice.BackColor = Color.White
        If Val(txtNFPrice.Text) = 0 Then
            picNFPrice.Visible = True
            txtNFPrice.BackColor = Color.Bisque
        End If
        If Val(txtWCPrice.Text) = 0 Then
            picWCPrice.Visible = True
            picWCPrice.BackColor = Color.Bisque
        End If

        'If sender Is txtNFPrice And OpMode = AddEditMode.AddNew Then
        '    If IsNumeric(txtNFPrice.Text) Then
        '        If Val(txtNFPrice.Text) > 0 And txtWCPrice.Text = "" Then
        '            txtWCPrice.Text = txtNFPrice.Text
        '        End If
        '        If Val(txtPRPrice.Text) > 0 Then
        '            txtPRPrice.Text = txtNFPrice.Text
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, sender)
    End Sub

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        ErrorProvider1.SetError(txtCode, "")
    End Sub

    Private Sub TextBoxSearchDiagnos_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSearchDiagnos.KeyDown
        If e.KeyCode = 40 And ListViewDiagnosis.Items.Count > 0 Then
            ListViewDiagnosis.Focus()
            ListViewDiagnosis.Items(0).Selected = True
        End If
    End Sub

    Private Sub TextBoxSearchDiagnos_TextChanged(sender As Object, e As EventArgs) _
        Handles TextBoxSearchDiagnos.TextChanged
        Dim ID As Long
        If TextBoxSearchDiagnos.Enabled = False Then Exit Sub
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        ID = CLng(ListView1.SelectedItems(0).Tag)
        If OpMode = AddEditMode.AddNew Then
            Load_Diagnosis(-1, TextBoxSearchDiagnos.Text)
        Else
            Load_Diagnosis(ID, TextBoxSearchDiagnos.Text)
        End If
        If ListViewDiagnosis.Items.Count = 0 Then
            TextBoxSearchDiagnos.BackColor = Color.LightCoral
            TextBoxSearchDiagnos.Text = TextBoxSearchDiagnos.Text.Mid(1, TextBoxSearchDiagnos.Text.Length - 1)
            TextBoxSearchDiagnos.SelectionStart = TextBoxSearchDiagnos.Text.Length
            Beep()
            Timer2.Enabled = True
            Exit Sub
        End If

        Exit Sub
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        TextBoxSearchDiagnos.BackColor = Color.White
    End Sub

    Private Sub ListViewDiagnosis_ColumnClick(sender As Object, e As ColumnClickEventArgs) _
        Handles ListViewDiagnosis.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewDiagnosis.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = Windows.Forms.SortOrder.Ascending
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
                    sort_order = Windows.Forms.SortOrder.Descending
                Else
                    sort_order = Windows.Forms.SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = Windows.Forms.SortOrder.Ascending
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
        If sort_order = Windows.Forms.SortOrder.Ascending Then
            m_SortingColumn.ImageKey = "SORT1"
        Else
            m_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewDiagnosis.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewDiagnosis.Sort()
    End Sub

    Private Sub ListViewDiagnosis_DoubleClick(sender As Object, e As EventArgs) Handles ListViewDiagnosis.DoubleClick
        Dim LI As ListViewItem
        Dim LINew As ListViewItem
        If OpMode = AddEditMode.None Then Exit Sub
        If ListViewDiagnosis.SelectedItems.Count = 0 Then Exit Sub
        ListViewDiagnosis.Focus()
        Application.DoEvents()
        LI = ListViewDiagnosis.SelectedItems(0)
        LINew = ListViewDiagnosisSelected.Items.Add(LI.Clone)
        LINew.Selected = True
        LINew.EnsureVisible()
        Dim SaveIndex As Integer = LI.Index
        ListViewDiagnosis.Items.Remove(LI)
        If ListViewDiagnosis.Items.Count > 0 Then
            If ListViewDiagnosis.Items.Count > SaveIndex Then
                ListViewDiagnosis.Items(SaveIndex).Selected = True
                ListViewDiagnosis.Items(SaveIndex).EnsureVisible()
            Else
                ListViewDiagnosis.Items(SaveIndex - 1).Selected = True
                ListViewDiagnosis.Items(SaveIndex - 1).EnsureVisible()
            End If
        End If
    End Sub

    Private Sub ListViewDiagnosisSelected_ColumnClick(sender As Object, e As ColumnClickEventArgs) _
        Handles ListViewDiagnosisSelected.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewDiagnosisSelected.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As Windows.Forms.SortOrder
        If m_SortingColumn1 Is Nothing Then
            ' New column. Sort ascending.
            sort_order = Windows.Forms.SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn1) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumn1.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumn1.ImageKey = "SORT1" Then
                    sort_order = Windows.Forms.SortOrder.Descending
                Else
                    sort_order = Windows.Forms.SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = Windows.Forms.SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumn1.Text =             m_SortingColumn1.Text.Mid(2)
            m_SortingColumn1.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumn1 = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumn1.Text = "> " & m_SortingColumn1.Text
        'Else
        'm_SortingColumn1.Text = "< " & m_SortingColumn1.Text
        'End If
        If sort_order = Windows.Forms.SortOrder.Ascending Then
            m_SortingColumn1.ImageKey = "SORT1"
        Else
            m_SortingColumn1.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewDiagnosisSelected.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewDiagnosisSelected.Sort()
    End Sub

    Private Sub ListViewDiagnosisSelected_DoubleClick(sender As Object, e As EventArgs) _
        Handles ListViewDiagnosisSelected.DoubleClick
        Dim LI As ListViewItem
        Dim LINew As ListViewItem
        If OpMode = AddEditMode.None Then Exit Sub
        If ListViewDiagnosisSelected.SelectedItems.Count = 0 Then Exit Sub
        LI = ListViewDiagnosisSelected.SelectedItems(0)
        LINew = ListViewDiagnosis.Items.Add(LI.Clone)
        LINew.Selected = True
        LINew.EnsureVisible()
        ListViewDiagnosisSelected.Focus()

        Application.DoEvents()
        Dim SaveIndex As Integer = LI.Index
        ListViewDiagnosisSelected.Items.Remove(LI)
        If ListViewDiagnosisSelected.Items.Count > 0 Then
            If ListViewDiagnosisSelected.Items.Count > SaveIndex Then
                ListViewDiagnosisSelected.Items(SaveIndex).Selected = True
                ListViewDiagnosisSelected.Items(SaveIndex).EnsureVisible()
            Else
                ListViewDiagnosisSelected.Items(SaveIndex - 1).Selected = True
                ListViewDiagnosisSelected.Items(SaveIndex - 1).EnsureVisible()
            End If
        End If
    End Sub

    Private Sub ListViewDiagnosisSelected_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles ListViewDiagnosisSelected.KeyDown
        If e.KeyCode = 13 Then
            ListViewDiagnosisSelected_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewDiagnosisSelected_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles ListViewDiagnosisSelected.SelectedIndexChanged
    End Sub

    Private Sub ListViewDiagnosis_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewDiagnosis.KeyDown
        If e.KeyCode = 13 Then
            ListViewDiagnosis_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub ButtonDn_Click(sender As Object, e As EventArgs) Handles ButtonDn.Click
        ListViewDiagnosis_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ButtonUp_Click(sender As Object, e As EventArgs) Handles ButtonUp.Click
        ListViewDiagnosisSelected_DoubleClick(Nothing, Nothing)
    End Sub

    Public DiagnosID As Long

    Private Sub ButtonAddDiagnos_Click(sender As Object, e As EventArgs) Handles ButtonAddDiagnos.Click
        Dim LI As ListViewItem
        Dim SQL As String
        frmAddDiagnos.CalledForm = Me
        If frmAddDiagnos.ShowDialog = DialogResult.OK Then
            SQL = "SELECT DignosisID, ICDCode, ICDDescription, ICDGroup FROM Diagnosis WHERE DignosisID = " & DiagnosID
            Dim Reader As SqlDataReader = gSQLGetDataReader(SQL)
            If Reader.HasRows Then
                Reader.Read()
                LI = ListViewDiagnosis.Items.Add(Reader("ICDCode").ToString)
                LI.SubItems.Add(Reader("ICDDescription").ToString)
                LI.SubItems.Add(Reader("ICDGroup").ToString)
                LI.Tag = Reader("DignosisID").ToString
                LI.Selected = True
                LI.EnsureVisible()
                ListViewDiagnosis.Focus()
                Reader.Close()
                Reader.Dispose()
            End If
        End If
    End Sub

    Private Sub ComboBoxDiagID_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles ComboBoxDiagID.SelectedIndexChanged
        If ComboBoxDiagID.SelectedIndex = -1 Then Exit Sub
    End Sub

    Private Sub cboMinDays_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboMinDays.SelectedIndexChanged
        ErrorProvider1.SetError(cboMinDays, "")
    End Sub

    Private Sub cboInterval_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboInterval.SelectedIndexChanged
        ErrorProvider1.SetError(cboInterval, "")
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
        If gCurrentEmployee.PositionID > 3 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub DuplicateProcedureToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles DuplicateProcedureToolStripMenuItem.Click
        ButtonDuplicate_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonDuplicate_Click(sender As Object, e As EventArgs) Handles ButtonDuplicate.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        cmdEdit_Click(Nothing, Nothing)
        ComboBoxDiagID.Enabled = False
        OpMode = AddEditMode.AddNew
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        Load_Procedures()
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ret As DialogResult = frmProceduresBatch.ShowDialog(Me)
        If ret = DialogResult.OK Then
            TextBoxSearch.Text = ""
            Load_Data()
            Load_Procedures()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class