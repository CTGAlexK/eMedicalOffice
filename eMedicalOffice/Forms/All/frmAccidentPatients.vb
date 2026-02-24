Imports System.Reflection
Imports log4net

Public Class frmAccidentPatients
    Public PatientID As Long
    Public DOA As String
    Public PolicyNumber As String
    Public InsuranceCompanyID As Long
    Public Loading As Boolean
    Public GroupID As Long

    Public Sub Load_Data()
        Dim log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
        Dim Reader As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ComboText As String() = {""}
        Dim ComboValue As String() = {""}
        Dim Items() As String = {""}
        Dim I As Integer = 0
        Try
            Loading = True
            ComboBoxSearchCaseStatus.Items.Clear()
            Reader = gSQLGetDataReader("SELECT CaseStatusID, Description FROM CaseStatuses Order By ShowOrder")
            If Reader Is Nothing Then Exit Sub
            ComboBoxSearchCaseStatus.Items.Add(New ValueDescription(0, "All Statuses"))
            Do Until Reader.Read = False
                ComboBoxSearchCaseStatus.Items.Add(New ValueDescription(CLng(Val(Reader("CaseStatusID").ToString)), Reader("Description").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
            ComboBoxSearchCaseType.Items.Clear()
            ComboBoxSearchCaseType.Items.Add(New ValueDescription(0, "All Types"))
            Reader = gSQLGetDataReader("Select CaseTypeID, Description from CaseTypes where CaseTypeID =1 or CaseTypeID =2 or CaseTypeID =5")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxSearchCaseType.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Description").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
            ComboBoxSearchCaseStatus.SelectedIndex = 0
            ComboBoxSearchCaseType.SelectedIndex = 0
            Loading = False
            Load_PatientsSelectd()
            GroupID = gSQLGetSingleValue("Select GroupID From PatientAccidentGroups where PatientID = " & PatientID)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Load_PatientsSelectd()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem

        ListViewPatientsSelected.BeginUpdate()
        ListViewPatientsSelected.Items.Clear()
        If GroupID = 0 Then
            ListViewPatientsSelected.EndUpdate()
            Exit Sub
        End If
        SQL = "SELECT DISTINCT  Patients.DOB,  Patients.PatientID, Patients.FName, Patients.LName, Patients.MI, Patients.CaseStatusID, InsuranceCompanies.CompanyName, Patients.DOA, Patients.ClaimNumber, Patients.PolicyNumber "
        SQL &= " FROM         Patients INNER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID "
        SQL &= " Where PatientID<> " & PatientID & " AND PatientID in (select PatientID from PatientAccidentGroups where GroupID=" & GroupID & ")"
        SQL &= " Order by FName, LName"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then ListViewPatientsSelected.EndUpdate() : Exit Sub
        ListViewPatientsSelected.ListViewItemSorter = Nothing
        If Reader.HasRows Then
            Do Until Reader.Read = False

                LI = ListViewPatientsSelected.Items.Add(Reader("PatientID").ToString, CInt(Val(Reader("CaseStatusID").ToString) - 1))
                LI.SubItems.Add(Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString)
                LI.SubItems.Add(FormatDateTime(Reader("DOB").ToString, DateFormat.ShortDate))
                LI.SubItems.Add(FormatDateTime(Reader("DOA").ToString, DateFormat.ShortDate))
                LI.SubItems.Add(Reader("ClaimNumber").ToString)
                LI.SubItems.Add(Reader("PolicyNumber").ToString)
                LI.SubItems.Add(Reader("CompanyName").ToString)
                LI.Tag = "" & Reader("PatientID").ToString
                If Val(Reader("CaseStatusID").ToString) <> 1 Then
                    LI.ForeColor = Color.Red
                Else
                    LI.ForeColor = Color.Black
                End If
            Loop
            ListViewPatientsSelected.EndUpdate()
        Else
            ListViewPatientsSelected.EndUpdate()
        End If
        Reader.Close() : Reader.Dispose()

    End Sub

    Public Sub Load_Patients()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Dim PName() As String
        Dim SQLPNAME As String = ""
        Dim PatientIDs As String
        If Loading Then Exit Sub
        ListViewPatients.BeginUpdate()
        ListViewPatients.Items.Clear()
        If ComboBoxSearchCaseStatus.SelectedItem Is Nothing Or ComboBoxSearchCaseType.SelectedItem Is Nothing Then
            ListViewPatients.EndUpdate()
            Exit Sub
        End If
        PatientIDs = PatientID & ", "
        For Each LI In ListViewPatientsSelected.Items
            PatientIDs &= LI.Tag & ", "
        Next
        PatientIDs = PatientIDs.Mid(1, Len(PatientIDs) - 2)
        SQL = " SELECT     Patients.InsuranceCompanyID, Patients.PatientID, Patients.DOB, Patients.FName, Patients.LName, Patients.MI, Patients.CaseStatusID, InsuranceCompanies.CompanyName, Patients.DOA, Patients.ClaimNumber, Patients.PolicyNumber FROM Patients  LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID  WHERE Patients.OfficeID=" & gOfficeID & " and PatientID not in  (" & PatientIDs & ") "
        If CheckBox2.Checked Then
            If InsuranceCompanyID <> 0 Then
                SQL &= " and (Patients.InsuranceCompanyID  = " & InsuranceCompanyID & " OR "
                SQL &= " Patients.InsuranceCompanyID   IS NULL) "
            End If
        End If
        If CheckBox1.Checked Then
            If IsDate(DOA) <> 0 Then
                SQL &= " and datediff(d,Patients.DOA,'" & DOA & "') = 0 "
            End If
        End If
        If CheckBox3.Checked Then
            SQL &= " AND (Patients.PolicyNumber = '" & PolicyNumber.ToSafeSQLString() & "' or Patients.PolicyNumber is null )  "
        End If
        If TextBoxSearch.Text.Trim <> "" Then
            If IsNumeric(TextBoxSearch.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(TextBoxSearch.Text.Trim) & " "
            Else
                PName = Split(TextBoxSearch.Text.Trim.ToSafeSQLString(), " ")
                Select Case PName.Length
                    Case 1
                        If PName(0).Trim = "*" Then PName(0) = ""
                        SQL &= " and (Patients.FName Like '" & PName(0).Trim & "%' or Patients.LName Like '" & PName(0) & "%') "
                    Case 2
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.LName Like '" & PName(0).Trim & "%')"
                        SQL &= " )"
                    Case 3
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "

                        SQL &= " )"
                End Select
            End If
        End If
        If CType(ComboBoxSearchCaseStatus.SelectedItem, ValueDescription).Value > 0 Then
            SQL &= " AND CaseStatusID=" & CType(ComboBoxSearchCaseStatus.SelectedItem, ValueDescription).Value
        End If

        If CType(ComboBoxSearchCaseType.SelectedItem, ValueDescription).Value > 0 Then
            SQL &= " AND Patients.CaseTypeID=" & CType(ComboBoxSearchCaseType.SelectedItem, ValueDescription).Value
        Else
            SQL &= " AND (Patients.CaseTypeID = 1 Or Patients.CaseTypeID = 2 Or Patients.CaseTypeID = 5) "
        End If

        SQL &= " Order by FName, LName"
        Reader = gSQLGetDataReader(SQL)
        Dim SI As ListViewItem.ListViewSubItem
        If Reader Is Nothing Then ListViewPatients.EndUpdate() : Exit Sub
        ListViewPatients.ListViewItemSorter = Nothing
        If Reader.HasRows Then
            Do Until Reader.Read = False

                LI = ListViewPatients.Items.Add(Reader("PatientID").ToString, CInt(Val(Reader("CaseStatusID").ToString) - 1))
                LI.UseItemStyleForSubItems = False
                LI.SubItems.Add(Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString)
                If IsDate(Reader("DOB").ToString) Then
                    LI.SubItems.Add(CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy"))
                Else
                    LI.SubItems.Add("")
                End If

                If IsDate(Reader("DOA").ToString) Then
                    SI = LI.SubItems.Add(CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy"))
                    If IsDate(DOA) Then
                        If CDate(DOA).ToString("MM/dd/yyyy") <> CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy") Then
                            SI.ForeColor = Color.Red
                        End If
                    Else
                        SI.ForeColor = Color.Red
                    End If
                Else
                    SI = LI.SubItems.Add("")
                End If

                LI.SubItems.Add(Reader("ClaimNumber").ToString)
                SI = LI.SubItems.Add(Reader("PolicyNumber").ToString)
                If PolicyNumber <> Reader("PolicyNumber").ToString Then
                    SI.ForeColor = Color.Red
                End If
                SI = LI.SubItems.Add(Reader("CompanyName").ToString)
                If Val(InsuranceCompanyID) <> Val(Reader("InsuranceCompanyID").ToString) Then
                    SI.ForeColor = Color.Red
                End If
                LI.Tag = "" & Reader("PatientID").ToString
                If Val(Reader("CaseStatusID").ToString) <> 1 Then
                    LI.ForeColor = Color.Red
                Else
                    LI.ForeColor = Color.Black
                End If
            Loop
            ListViewPatients.EndUpdate()
        Else
            ListViewPatients.EndUpdate()
        End If
        Reader.Close() : Reader.Dispose()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        Load_Patients()
    End Sub

    Private Sub frmAccidentPatients_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Changed = True Then
            If MsgBox("You have not updated the Accident Related Patients Group." & vbCrLf & vbCrLf & "Discard Changes?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gListview_Settings(Me, ListViewPatientsSelected, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
    End Sub

    Private Sub frmAccidentPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewPatientsSelected, ReadWrite.sRead)
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        Load_Data()

        If InsuranceCompanyID = 0 Then
            CheckBox2.Checked = False
            CheckBox2.Enabled = False
        Else
            CheckBox2.Checked = True
            CheckBox2.Enabled = True
        End If
        If IsDate(DOA) = False Or DOA = "" Then
            CheckBox1.Checked = False
            CheckBox1.Enabled = False
        Else
            CheckBox1.Checked = True
            CheckBox1.Enabled = True
        End If
        If PolicyNumber.Trim = "" Then
            CheckBox3.Checked = False
            CheckBox3.Enabled = False
        Else
            CheckBox3.Checked = True
            CheckBox3.Enabled = True
        End If

    End Sub

    Private Sub ComboBoxSearchCaseStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxSearchCaseStatus.SelectedIndexChanged
        Load_Patients()
    End Sub

    Private Sub ComboBoxSearchCaseType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxSearchCaseType.SelectedIndexChanged
        Load_Patients()
    End Sub

    Private Sub ListViewPatients_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles ListViewPatients.ColumnWidthChanged

    End Sub

    Private Sub ListViewPatients_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ListViewPatients.ColumnWidthChanging
        ListViewPatientsSelected.Columns(e.ColumnIndex).Width = ListViewPatients.Columns(e.ColumnIndex).Width
    End Sub

    Private Sub ListViewPatients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatients.DoubleClick
        Dim SourceLI As ListViewItem
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        SourceLI = ListViewPatients.SelectedItems(0)
        If gSQLGetSingleValue("select Count(*) as C from PatientAccidentGroups Where GroupID <> " & Val(GroupID) & " and PatientID = " & Val(SourceLI.Tag)) > 0 Then
            MsgBox("Unable to assign patient " & SourceLI.SubItems(1).Text & " to the current current Accident Group." & vbCrLf & vbCrLf & "This patient is already assigned to the different Accident group.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        For Each LI In ListViewPatientsSelected.Items
            If CDate(LI.SubItems(3).Text) <> CDate(SourceLI.SubItems(3).Text) Then
                MsgBox("Unable to add patient " & SourceLI.SubItems(1).Text & " to the current accident group." & vbCrLf & "Only patients with the same DOA allowed.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If LI.SubItems(5).Text <> SourceLI.SubItems(5).Text Then
                MsgBox("Unable to add patient " & SourceLI.SubItems(1).Text & " to the current accident group." & vbCrLf & "Only patients with the same Policy Number allowed.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If LI.SubItems(6).Text <> SourceLI.SubItems(6).Text Then
                MsgBox("Unable to add patient " & SourceLI.SubItems(1).Text & " to the current accident group." & vbCrLf & "Only patients with the same Insurance Company allowed.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Next

        LI = ListViewPatientsSelected.Items.Add(SourceLI.Clone)
        ListViewPatients.Items.Remove(SourceLI)
        LI.Selected = True
        LI.EnsureVisible()
        gHighlightListviewItem(ListViewPatientsSelected, True)
        Changed = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button1.Enabled = False
        Label3.Visible = Button2.Enabled
    End Sub

    Private Changed As Boolean

    Private Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged
        gHighlightListviewItem(ListViewPatients)
    End Sub

    Private Sub ListViewPatientsSelected_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ListViewPatientsSelected.ColumnWidthChanging
        ListViewPatients.Columns(e.ColumnIndex).Width = ListViewPatientsSelected.Columns(e.ColumnIndex).Width
    End Sub

    Private Sub ListViewPatientsSelected_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatientsSelected.DoubleClick
        Dim SourceLI As ListViewItem
        Dim LI As ListViewItem
        If ListViewPatientsSelected.SelectedItems.Count = 0 Then Exit Sub
        SourceLI = ListViewPatientsSelected.SelectedItems(0)
        LI = ListViewPatients.Items.Add(SourceLI.Clone)
        LI.UseItemStyleForSubItems = False

        ListViewPatientsSelected.Items.Remove(SourceLI)
        LI.Selected = True
        LI.EnsureVisible()
        gHighlightListviewItem(ListViewPatients)
        Changed = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button1.Enabled = False
        Label3.Visible = Button2.Enabled
    End Sub

    Private Sub ListViewPatientsSelected_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatientsSelected.SelectedIndexChanged
        gHighlightListviewItem(ListViewPatientsSelected)
    End Sub

    Private Sub ButtonDn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDn.Click
        ListViewPatients_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ButtonUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUp.Click
        ListViewPatientsSelected_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Load_Patients()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim PatID As Long
        Dim LI As ListViewItem
        If GroupID > 0 Then
            gSQLDeleteRecord("DELETE From PatientAccidentGroups Where GroupID = " & GroupID)
        Else
            GroupID = gSQLGetSingleValue("select top 1 (found.GroupID + 1) nextid from (select GroupID from PatientAccidentGroups union select 0) found where not exists (select * from PatientAccidentGroups blocking where blocking.GroupID = found.GroupID + 1)     order by nextid asc ")
        End If
        If ListViewPatientsSelected.Items.Count > 0 Then
            gSQLUpdateData("INSERT INTO PatientAccidentGroups (GroupID, PatientID, UpdatedBy) VALUES(" & GroupID & "," & PatientID & ", " & gCurrentEmployee.EmpID & ")")
            For Each LI In ListViewPatientsSelected.Items
                gSQLUpdateData("INSERT INTO PatientAccidentGroups (GroupID, PatientID, UpdatedBy) VALUES(" & GroupID & "," & LI.Tag & ", " & gCurrentEmployee.EmpID & ")")
            Next
        End If
        Changed = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button1.Enabled = True
        Label3.Visible = Button2.Enabled
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MsgBox("Please confirm you want to cancel all changes?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Load_PatientsSelectd()
        Load_Patients()
        Changed = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button1.Enabled = True
        Label3.Visible = Button2.Enabled
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        If Changed = True Then
            MsgBox("Unable to copy insurance information while the Patient's Group assigment in progress." & "Please click the 'Update' or 'Cancel' button first.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewPatientsSelected.Items.Count = 0 Then
            MsgBox("Unable to copy insurance information. No Accident Related Patients selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to copy all insurance information from " & lblPatient.Text & " to " & ListViewPatientsSelected.Items.Count & " Accident Related Patients?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim PatientIDs = ""
        For Each LI In ListViewPatientsSelected.Items
            PatientIDs &= LI.Tag & ", "
        Next
        If PatientIDs <> "" Then
            PatientIDs = PatientIDs.Mid(1, Len(PatientIDs) - 2)
        End If

        SQL = "SELECT ClaimNumber, PolicyNumber, ClaimAddressID, RelationToInsuredID, PolicyHolderFName, PolicyHolderMI, PolicyHolderLName, PolicyHolderAddress, PolicyHolderCity, PolicyHolderState, PolicyHolderZip, PolicyHolderPhone, AdjusterName, AdjusterPhone, AdjusterComments, DOA "
        SQL &= " FROM Patients "
        SQL &= " WHERE PatientID=" & PatientID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then
            MsgBox("Unexpected Error. Please try again.", MsgBoxStyle.Critical)
        End If
        If Reader.HasRows = False Then
            MsgBox("Unexpected Error. Please contact system administrator.", MsgBoxStyle.Critical)
        End If
        Reader.Read()
        If PatientIDs.Trim <> "" Then
            If IsDate(Reader("DOA")) Then
                gSQLUpdateData("UPDATE Patients Set ClaimNumber='" & Reader("ClaimNumber").ToString.ToSafeSQLString() & "', PolicyNumber='" & Reader("PolicyNumber").ToString.ToSafeSQLString() & "', ClaimAddressID=" & Val(Reader("ClaimAddressID").ToString) & ", RelationToInsuredID=" & Val(Reader("RelationToInsuredID").ToString) & ", PolicyHolderFName='" & Reader("PolicyHolderFName").ToString.ToSafeSQLString() & "', PolicyHolderMI='" & Reader("PolicyHolderMI").ToString.ToSafeSQLString() & "', PolicyHolderLName='" & Reader("PolicyHolderLName").ToString.ToSafeSQLString() & "', PolicyHolderAddress='" & Reader("PolicyHolderAddress").ToString.ToSafeSQLString() & "', PolicyHolderCity='" & Reader("PolicyHolderCity").ToString.ToSafeSQLString() & "', PolicyHolderState='" & Reader("PolicyHolderState").ToString.ToSafeSQLString() & "', PolicyHolderZip='" & Reader("PolicyHolderZip").ToString.ToSafeSQLString() & "', PolicyHolderPhone='" & Reader("PolicyHolderPhone").ToString.ToSafeSQLString() & "', AdjusterName='" & Reader("AdjusterName").ToString.ToSafeSQLString() & "', AdjusterPhone='" & Reader("AdjusterPhone").ToString.ToSafeSQLString() & "', AdjusterComments='" & Reader("AdjusterComments").ToString.ToSafeSQLString() & "', DOA='" & Reader("DOA") & "'  WHERE PatientID in (" & PatientIDs & ")")
            Else
                gSQLUpdateData("UPDATE Patients Set ClaimNumber='" & Reader("ClaimNumber").ToString.ToSafeSQLString() & "', PolicyNumber='" & Reader("PolicyNumber").ToString.ToSafeSQLString() & "', ClaimAddressID=" & Val(Reader("ClaimAddressID").ToString) & ", RelationToInsuredID=" & Val(Reader("RelationToInsuredID").ToString) & ", PolicyHolderFName='" & Reader("PolicyHolderFName").ToString.ToSafeSQLString() & "', PolicyHolderMI='" & Reader("PolicyHolderMI").ToString.ToSafeSQLString() & "', PolicyHolderLName='" & Reader("PolicyHolderLName").ToString.ToSafeSQLString() & "', PolicyHolderAddress='" & Reader("PolicyHolderAddress").ToString.ToSafeSQLString() & "', PolicyHolderCity='" & Reader("PolicyHolderCity").ToString.ToSafeSQLString() & "', PolicyHolderState='" & Reader("PolicyHolderState").ToString.ToSafeSQLString() & "', PolicyHolderZip='" & Reader("PolicyHolderZip").ToString.ToSafeSQLString() & "', PolicyHolderPhone='" & Reader("PolicyHolderPhone").ToString.ToSafeSQLString() & "', AdjusterName='" & Reader("AdjusterName").ToString.ToSafeSQLString() & "', AdjusterPhone='" & Reader("AdjusterPhone").ToString.ToSafeSQLString() & "', AdjusterComments='" & Reader("AdjusterComments").ToString.ToSafeSQLString() & "'  WHERE PatientID in (" & PatientIDs & ")")
            End If
        End If
        Reader.Close()
        Reader = Nothing

        Load_PatientsSelectd()
        Button1.Enabled = False

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Load_Patients()
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Load_Patients()
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Load_Patients()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        If Changed = True Then
            MsgBox("Unable to copy Police Report while the Patient's Group assigment in progress." & "Please click the 'Update' or 'Cancel' button first.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewPatientsSelected.Items.Count = 0 Then
            MsgBox("Unable to copy Police Report. No Accident Related Patients selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to copy the Police Report from " & lblPatient.Text & " to " & ListViewPatientsSelected.Items.Count & " Accident Related Patients?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        For Each LI In ListViewPatientsSelected.Items
            SQL = "insert into Documents (PatientID, DocumentName, DocumentProfileID, DocumentImage, InsertedBy, InsertedDate) "
            SQL &= " select " & Val(LI.Tag) & " as PatientID, DocumentName, DocumentProfileID, DocumentImage, " & gCurrentEmployee.EmpID & " as InsertedBy, getdate() as InsertedDate from Documents where DocumentProfileID=4 and PatientID=" & PatientID
            gSQLUpdateData(SQL)
            SQL = "UPDATE Patients SET PoliceReportReceived = 1 where PatientID = " & Val(LI.Tag)
            gSQLUpdateData(SQL)
        Next
        Load_PatientsSelectd()
        Button5.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim SQL As String
        Dim reader As SqlClient.SqlDataReader
        Timer1.Enabled = False
        Load_Patients()
        If gSQLGetSingleValue("SELECT count(PatientID) FROM Documents WHERE DocumentProfileID = 4 AND PatientID = " & PatientID) = 0 Then
            Button5.Enabled = False
            Button5.Text = "No Policy Report Found"
        End If
        SQL = "SELECT InsuranceCompanyID FROM Patients WHERE PatientID=" & PatientID
        reader = gSQLGetDataReader(SQL)
        If reader Is Nothing Then
            Button1.Enabled = False
        End If
        If reader.HasRows = False Then
            Button1.Enabled = False
        End If

        If Val(reader("InsuranceCompanyID").ToString) Then
            Button1.Enabled = False
            Button1.Text = "No Insurance Company Selected"
        End If
        reader.Close()
        reader = Nothing
    End Sub

End Class