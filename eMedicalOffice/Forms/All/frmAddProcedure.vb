Imports System.Reflection
Imports log4net

Public Class frmAddProcedure
    Public ExcludeExistingProcedures As String
    Public CaseType As Integer
    Public CalledListViewProcedures As ListView
    Public DiagID As Long = 0
    Public ReferringCompanyID As Long
    Public ReferringDoctorIndex As Long
    Public ReferringDoctorName As String
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmAddProcedure_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ComboBoxBillingProvider.Invalidate()
        ComboBoxBillingProvider.Refresh()
    End Sub

    Private Sub frmAddProcedure_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

    End Sub

    Private Sub frmAddProcedure_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'gListview_Settings(Me, ListViewProcedures, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", "AddProcedureLastTypeIndex", ComboBoxDiagIDSearch.SelectedIndex)

    End Sub

    Private Sub frmAddProcedure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePickerProcDate.Value = Now
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            DateTimePickerProcDate.Visible = False
            LabelProcDate.Visible = False
            If gOfficeTypeID = 3 Then
                ListViewProcedures.Height = 235
                PanelPreCertification.Visible = True
            Else
                ListViewProcedures.Height = 262
                PanelPreCertification.Visible = False
            End If
        End If
        If CaseType = 1 Then
            LabelCaseType.Text = "NF"
        ElseIf CaseType = 2 Then
            LabelCaseType.Text = "WC"
        Else
            LabelCaseType.Text = ""
        End If
        Load_Data()

        'gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead)
    End Sub

    Private Sub Load_Data()
        Try
            Dim Reader As SqlClient.SqlDataReader

            Dim SQL As String
            SQL = "SELECT     Fname+' '+Lname +' '+ Alias as DName, EmpID,ReferralColor FROM Employees WHERE ActiveInd=1 and NoFaultInd = 1 AND BillingPrv = 1 and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")"
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxBillingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString, Reader("ReferralColor").ToString))
            Loop
            ComboBoxBillingProvider.SelectedIndex = -1
            Reader.Close() : Reader.Dispose()
            ComboBoxTreatingProviderID.Items.Clear()
            Reader = gSQLGetDataReader("SELECT   Employees.EmpID,   Employees.Fname, Employees.Lname, Employees.Alias, Employees.BillingPrv, Employees.TreatmentPrv FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE  TreatmentPrv=1 and Employees.ActiveInd = 1 and   (Employees.PositionID = 5) AND (EmployeeOffice.OfficeID = " & gOfficeID & ")")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxTreatingProviderID.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("FName").ToString & " " & Reader("LName").ToString & " " & Reader("Alias").ToString))
            Loop
            Reader.Close() : Reader.Dispose()

            SQL = "SELECT DiagID, DiagName FROM Diagnostics Where  ActiveInd =1 and DiagTypeID=1 or DiagTypeID=3 and Diagnostics.OfficeID=" & gOfficeID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            'ComboBoxDiagIDSearch.Items.Add(New ValueDescription(0, "Show All"))
            Do Until Reader.Read = False
                ComboBoxDiagIDSearch.Items.Add(New ValueDescription(CLng(Val(Reader("DiagID").ToString)), Reader("DiagName").ToString))
            Loop
            If Val(GetSetting(My.Application.Info.ProductName, "Settings", "AddProcedureLastTypeIndex", 0)) <= ComboBoxDiagIDSearch.Items.Count - 1 Then
                ComboBoxDiagIDSearch.SelectedIndex = GetSetting(My.Application.Info.ProductName, "Settings", "AddProcedureLastTypeIndex", 0)
            End If

            If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
                ComboBoxReferringDoctor.Items.Clear()
                ComboBoxReferringDoctor.Text = ""
                Reader = gSQLGetDataReader("Select distinct * from ReferringOffices Where ReferringOffices.OfficeID =" & ReferringCompanyID)
                If Reader Is Nothing Then GoTo ExitSub
                Do Until Reader.Read = False

                    For d As Integer = 1 To gReferringOfficeDoctors
                        If Reader("Doctor" + d.ToString()).ToString.Trim <> "" Then
                            ComboBoxReferringDoctor.Items.Add(New ValueDescription(0, Reader("Doctor" + d.ToString()).ToString.Trim, Reader("Doctor" + d.ToString() + "Phone").ToString.Trim))
                        End If
                    Next

                Loop
                Reader.Close() : Reader.Dispose()
                If ComboBoxReferringDoctor.Items.Count = 1 Then
                    ComboBoxReferringDoctor.SelectedIndex = 0
                    ComboBoxReferringDoctor.Enabled = False
                Else
                    ComboBoxReferringDoctor.Enabled = True
                    If ReferringDoctorName = "" Then
                        If ComboBoxReferringDoctor.Items.Count > 0 Then
                            ComboBoxReferringDoctor.SelectedIndex = ReferringDoctorIndex
                        End If
                    Else
                        ComboBoxReferringDoctor.SelectedIndex = gFindComboItemByDescription(ComboBoxReferringDoctor, ReferringDoctorName, True)
                    End If
                End If
            End If

            If ComboBoxBillingProvider.SelectedIndex = -1 And ComboBoxBillingProvider.Items.Count = 1 Then
                ComboBoxBillingProvider.SelectedIndex = 0
            End If
            If ComboBoxTreatingProviderID.SelectedIndex = -1 And ComboBoxTreatingProviderID.Items.Count = 1 Then
                ComboBoxTreatingProviderID.SelectedIndex = 0
            End If
            If ComboBoxReferringDoctor.SelectedIndex = -1 And ComboBoxReferringDoctor.Items.Count = 1 Then
                ComboBoxReferringDoctor.SelectedIndex = 0
            End If

ExitSub:
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)

        End Try
        If DiagID > 0 Then
            gFindComboItemByValue(ComboBoxDiagIDSearch, DiagID, True)
            ComboBoxDiagIDSearch.Enabled = False
        End If
    End Sub

    Private Sub ComboBoxDiagIDSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDiagIDSearch.SelectedIndexChanged
        TextBoxSearch.Text = ""
        Load_Procedures()
        If ComboBoxDiagIDSearch.SelectedItem Is Nothing Then
            ComboBoxBillingProvider.SelectedIndex = -1
            Exit Sub
        End If
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = "SELECT BillingProviderID, TreatingProviderID  FROM Diagnostics WHERE DiagID=" & CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then
            ComboBoxBillingProvider.SelectedIndex = -1
            ComboBoxTreatingProviderID.SelectedIndex = -1
            Exit Sub
        End If
        If Reader.HasRows = False Then
            ComboBoxBillingProvider.SelectedIndex = -1
            ComboBoxTreatingProviderID.SelectedIndex = -1
            Exit Sub
        End If
        Reader.Read()
        gFindComboItemByValue(ComboBoxBillingProvider, Val(Reader("BillingProviderID").ToString), True)
        gFindComboItemByValue(ComboBoxTreatingProviderID, Val(Reader("TreatingProviderID").ToString), True)
    End Sub

    Private Sub Load_Procedures()
        Dim filterByCaseType
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        ListViewProcedures.Items.Clear()
        If ComboBoxDiagIDSearch.SelectedItem Is Nothing Then Exit Sub
        If CaseType <> 1 Then ExcludeExistingProcedures = ""
        If CaseType = 1 Then
            filterByCaseType = " and NFCost > 0 "
        End If
        If CaseType = 2 Then
            filterByCaseType = " and WCCost > 0 "
        End If
        If IsNumeric(TextBoxSearch.Text) Then
            If CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value = 0 Then
                Reader = gSQLGetDataReader("Select ProcedureTypeID, Procedures.DiagID, Procedures.ProcID, Procedures.ProcName,Procedures.ProcDescription, Procedures.Code from Procedures inner join Diagnostics on Procedures.DiagID=Diagnostics.DiagID Where  isnull(Procedures.ForBillingOnly,0)=0 and Diagnostics.OfficeID=" & gOfficeID & " and Procedures.ActiveInd=1 and (Procedures.Code like '%" & TextBoxSearch.Text & "%') " & ExcludeExistingProcedures & " " & filterByCaseType & " Order by ProcName")
            Else
                Reader = gSQLGetDataReader("Select ProcedureTypeID, Procedures.DiagID, Procedures.ProcID, Procedures.ProcName, Procedures.ProcDescription, Procedures.Code from Procedures Where isnull(Procedures.ForBillingOnly,0)=0 and Procedures.ActiveInd=1  and Procedures.DiagID=" & CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value & "  and (Procedures.Code like '%" & TextBoxSearch.Text & "%') " & ExcludeExistingProcedures & " " & filterByCaseType & " Order by ProcName")
            End If
        Else
            If CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value = 0 Then
                Reader = gSQLGetDataReader("Select ProcedureTypeID, Procedures.DiagID, Procedures.ProcID, Procedures.ProcName,Procedures.ProcDescription, Procedures.Code from Procedures inner join Diagnostics on Procedures.DiagID=Diagnostics.DiagID Where  isnull(Procedures.ForBillingOnly,0)=0 and Diagnostics.OfficeID=" & gOfficeID & " and Procedures.ActiveInd=1 and (ProcName like '%" & TextBoxSearch.Text & "%') " & ExcludeExistingProcedures & " " & filterByCaseType & " Order by ProcName")
            Else
                Reader = gSQLGetDataReader("Select ProcedureTypeID, Procedures.DiagID, Procedures.ProcID, Procedures.ProcName, Procedures.ProcDescription, Procedures.Code from Procedures Where  isnull(Procedures.ForBillingOnly,0)=0 and Procedures.ActiveInd=1  and Procedures.DiagID=" & CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value & "  and (ProcName like '%" & TextBoxSearch.Text & "%') " & ExcludeExistingProcedures & " " & filterByCaseType & "  Order by ProcName")
            End If
        End If
        If Reader Is Nothing Then Exit Sub
        ListViewProcedures.BeginUpdate()
        Do Until Reader.Read = False
            LI = ListViewProcedures.Items.Add(Reader("ProcName").ToString, 0)
            LI.SubItems.Add(Reader("Code").ToString).Tag = Reader("ProcedureTypeID").ToString
            LI.Tag = "" & Reader("ProcID").ToString
            LI.ImageKey = "" & Reader("DiagID").ToString ' Used to store DiagID...
            LI.Name = Reader("ProcedureTypeID").ToString
            If Val(Reader("ProcedureTypeID").ToString) = 3 Or Val(Reader("ProcedureTypeID").ToString) = 4 Then
                LI.ForeColor = Color.Blue
            End If
        Loop
        ListViewProcedures.EndUpdate()
        Reader.Close() : Reader.Dispose()
        Application.DoEvents()
        If ListViewProcedures.Items.Count > 0 Then
            cmdAdd.Enabled = True
            ListViewProcedures.Items(0).Selected = True
            ListViewProcedures.Items(0).EnsureVisible()
        Else
            cmdAdd.Enabled = False
        End If
    End Sub

    Private Sub TextBoxSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxSearch.KeyDown
        If e.KeyValue = 13 Then
            If ListViewProcedures.SelectedItems.Count > 0 Then
                cmdAdd_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        'gSearchListView(ListViewProcedures, TextBoxSearch, False, 1)
        Load_Procedures()
    End Sub

    Dim ProcAdded As Boolean

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim NewLI As ListViewItem
        Dim LI As ListViewItem
        Dim SaveIndex As Integer
        If ListViewProcedures.SelectedItems.Count = 0 Then
            MsgBox("Unable to add procedure. No procedure selected.", MsgBoxStyle.Critical)
            ListViewProcedures.Focus()
            Exit Sub
        End If
        If ComboBoxBillingProvider.SelectedIndex = -1 Then
            MsgBox("Unable to add procedure. No Billing Provider selected.", MsgBoxStyle.Critical)
            ComboBoxBillingProvider.Focus()
            Exit Sub
        End If

        If ComboBoxTreatingProviderID.SelectedIndex = -1 Then
            MsgBox("Unable to add procedure. No Treating Provider selected.", MsgBoxStyle.Critical)
            ComboBoxTreatingProviderID.Focus()
            Exit Sub
        End If
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            Add_Radiology()
        Else
            Add_Medical()
        End If
    End Sub

    Private Sub Add_Radiology()
        Dim NewLI As ListViewItem
        Dim LI As ListViewItem
        Dim sLI As ListViewItem.ListViewSubItem
        Dim SaveIndex As Integer
        If ComboBoxReferringDoctor.SelectedIndex = -1 Then
            MsgBox("Unable to add procedure. No Referring Doctor selected.", MsgBoxStyle.Critical)
            ComboBoxReferringDoctor.Focus()
            Exit Sub
        End If
        If Not CalledListViewProcedures.FindItemWithText(ListViewProcedures.SelectedItems(0).Text) Is Nothing Then
            If MsgBox("The " & CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Description & " / " & ListViewProcedures.SelectedItems(0).Text & vbCrLf & " is already in the patient procedures list." & vbCrLf & "Do you want to add another one?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If ExcludeExistingProcedures = "" Then
            ExcludeExistingProcedures = " AND ProcID NOT IN (" & ListViewProcedures.SelectedItems(0).Tag & ")"
        Else
            ExcludeExistingProcedures = ExcludeExistingProcedures.Remove(ExcludeExistingProcedures.Length - 1, 1)
            ExcludeExistingProcedures = ExcludeExistingProcedures & " ," & ListViewProcedures.SelectedItems(0).Tag & ")"
        End If

        Try
            SaveIndex = ListViewProcedures.SelectedItems(0).Index

            If DiagID > 0 Then   ' Called from the schedule popup
                NewLI = CalledListViewProcedures.Items.Add(ListViewProcedures.SelectedItems(0).Text)
                NewLI.Tag = CLng(ListViewProcedures.SelectedItems(0).Tag)
                NewLI.SubItems.Add("")
                NewLI.UseItemStyleForSubItems = False
                NewLI.ForeColor = Color.Blue
                NewLI.SubItems.Add(CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Description)
                NewLI.SubItems(2).Tag = CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value
                NewLI.SubItems.Add(CType(ComboBoxReferringDoctor.SelectedItem, ValueDescription).Description)
                NewLI.SubItems(3).Tag = CType(ComboBoxReferringDoctor.SelectedItem, ValueDescription).Value1
                NewLI.SubItems.Add(CType(ComboBoxBillingProvider.SelectedItem, ValueDescription).Description)
                NewLI.SubItems(4).Tag = CType(ComboBoxBillingProvider.SelectedItem, ValueDescription).Value
                If gOfficeTypeID = 3 Then
                    If CheckBoxPreCertification.Checked Then
                        sLI = NewLI.SubItems.Add(Now.ToShortDateString)
                        sLI.BackColor = Color.LightGreen
                    Else
                        sLI = NewLI.SubItems.Add("")
                        sLI.BackColor = Color.LightPink
                    End If
                Else
                    NewLI.SubItems.Add("")
                End If

                NewLI.Selected = True
                NewLI.EnsureVisible()
            Else
                NewLI = CalledListViewProcedures.Items.Add("")
                NewLI.UseItemStyleForSubItems = False
                NewLI.SubItems.Add(ListViewProcedures.SelectedItems(0).Text)
                NewLI.SubItems(1).Tag = ListViewProcedures.SelectedItems(0).Tag
                NewLI.Name = ListViewProcedures.SelectedItems(0).ImageKey ' Used to store DiagID...
                NewLI.ImageIndex = 0
                NewLI.SubItems.Add(CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Description)
                NewLI.SubItems(2).Tag = CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value
                NewLI.SubItems.Add(CType(ComboBoxBillingProvider.SelectedItem, ValueDescription).Description)
                NewLI.SubItems(3).Tag = CType(ComboBoxBillingProvider.SelectedItem, ValueDescription).Value
                NewLI.SubItems.Add(CType(ComboBoxReferringDoctor.SelectedItem, ValueDescription).Description)
                NewLI.SubItems(4).Tag = CType(ComboBoxReferringDoctor.SelectedItem, ValueDescription).Value1
                NewLI.SubItems.Add(CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Description).Tag = CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value
                NewLI.ForeColor = ListViewProcedures.SelectedItems(0).ForeColor
                NewLI.SubItems.Add("") ' Comments
                NewLI.SubItems.Add("") ' Accession #
                If gOfficeTypeID = 3 Then
                    If CheckBoxPreCertification.Checked Then
                        sLI = NewLI.SubItems.Add(Now.ToShortDateString)
                        sLI.BackColor = Color.LightGreen
                    Else
                        sLI = NewLI.SubItems.Add("")
                        sLI.BackColor = Color.LightPink
                    End If
                End If
                If CaseType = 1 Then ListViewProcedures.Items.Remove(ListViewProcedures.SelectedItems(0))
                If ListViewProcedures.Items.Count > 0 Then
                    If ListViewProcedures.Items.Count - 1 >= SaveIndex Then
                        ListViewProcedures.Items(SaveIndex).Selected = True
                    Else
                        ListViewProcedures.Items(SaveIndex - 1).Selected = True
                    End If
                End If
                NewLI.Selected = True
                NewLI.EnsureVisible()
                ProcAdded = True
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try

    End Sub

    Private Sub Add_Medical()
        Dim NewLI As ListViewItem
        Dim LI As ListViewItem
        Dim SaveIndex As Integer
        Dim InitFound As Boolean
        Dim sDiagID As String
        Dim sDiagName As String
        Dim sProcID As String
        Dim sProcName As String
        Dim sProcDate As String
        Dim sProcType As Integer

        Dim RefProcID As Integer

        Dim dDiagID As String
        Dim dDiagName As String
        Dim dProcID As String
        Dim dProcName As String
        Dim dProcDate As String
        Dim dProcType As Integer

        '2 Procedure
        '3 Initial Evaluation
        '4 FollowUp
        sProcType = ListViewProcedures.SelectedItems(0).Name.ToString
        sDiagID = CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value
        sDiagName = CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Description
        sProcID = ListViewProcedures.SelectedItems(0).Tag
        sProcName = ListViewProcedures.SelectedItems(0).Text
        sProcDate = DateTimePickerProcDate.Value.Date
        If CDate(DateTimePickerProcDate.Value.Date) > Now.Date Then
            MsgBox("Invalid procedure date. the procedure date can not be future date.", MsgBoxStyle.Exclamation)
            DateTimePickerProcDate.Focus()
            Exit Sub
        End If
        If Val(ListViewProcedures.SelectedItems(0).SubItems(1).Text) = 0 Then
            MsgBox("Unable to add procedure " & sProcName & vbCrLf & "Incomplete procedure information." & vbCrLf & "Procedure Code 0", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        RefProcID = gSQLGetSingleValue("SELECT PrescribedByProcID From Procedures Where ProcID = " & sProcID)

        'ProcType
        '1	Test
        '2	Procedure
        '3	Initial Evaluation
        '4	Follow Up Evaluation
        '5	Service
        '6	Supply
        ' Check For Initial
        For Each LI In CalledListViewProcedures.Items
            dProcType = LI.Name.ToString
            If IsDate(LI.SubItems(0).Text) Then
                dProcDate = CDate(LI.SubItems(0).Text)
            Else
                dProcDate = Now.Date
            End If
            dProcID = Val(LI.SubItems(0).Tag)
            dProcName = LI.SubItems(1).Text
            dDiagID = LI.SubItems(4).Tag
            dDiagName = LI.SubItems(4).Text
            If dDiagID = sDiagID Then
                'If dProcType = sProcType Then
                If dProcType = 3 Then
                    InitFound = True
                End If
            End If
            If RefProcID <> 0 Then
                InitFound = True
            End If
            ' Check for duplicate procedure
            If CDate(sProcDate) = CDate(dProcDate) And sDiagID = dDiagID Then
                If sDiagID = dDiagID Then
                    If sProcID = dProcID Then
                        MsgBox("Unable to add procedure " & sProcName & vbCrLf & "Duplicate Procedure" & vbCrLf & vbCrLf & "the only one " & sDiagName & " / " & sProcName & " allowed per day.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                End If
                If sProcType = 4 And dProcType = 3 Then
                    MsgBox("Unable to add Follow Up Evaluation and Initial Evaluation at the same date.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If

        Next
        If InitFound Then
            'Initial Evaluation is already found
            If sProcType = 3 Then
                MsgBox("The Initial Evaluation for the " & sDiagName & vbCrLf & " has been previously completed." & vbCrLf & vbCrLf & vbCrLf & "The only one Initial Evaluation per " & sDiagName & " is allowed.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            If sProcType <> 3 Then
                'Initial Evaluation is not found
                MsgBox("Unable to add procedure " & sDiagName & " / " & sProcName & vbCrLf & vbCrLf & "The Initial Evaluation for the " & sDiagName & " has not been completted.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

        If CaseType = 1 Then
            If ExcludeExistingProcedures = "" Then
                ExcludeExistingProcedures = " AND ProcID NOT IN (" & ListViewProcedures.SelectedItems(0).Tag & ")"
            Else
                ExcludeExistingProcedures = ExcludeExistingProcedures.Remove(ExcludeExistingProcedures.Length - 1, 1)
                ExcludeExistingProcedures = ExcludeExistingProcedures & " ," & ListViewProcedures.SelectedItems(0).Tag & ")"
            End If
        End If
        Try
            SaveIndex = ListViewProcedures.SelectedItems(0).Index
            NewLI = CalledListViewProcedures.Items.Add(DateTimePickerProcDate.Value.Date)
            NewLI.SubItems.Add(ListViewProcedures.SelectedItems(0).Text)
            NewLI.SubItems(1).Tag = ListViewProcedures.SelectedItems(0).Tag
            NewLI.Name = ListViewProcedures.SelectedItems(0).Name
            NewLI.ImageIndex = 2
            NewLI.SubItems.Add(CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Description)
            NewLI.SubItems(2).Tag = CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value
            NewLI.SubItems.Add(CType(ComboBoxBillingProvider.SelectedItem, ValueDescription).Description)
            NewLI.SubItems(3).Tag = CType(ComboBoxBillingProvider.SelectedItem, ValueDescription).Value
            NewLI.SubItems.Add(CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Description).Tag = CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value
            NewLI.ForeColor = ListViewProcedures.SelectedItems(0).ForeColor
            If ListViewProcedures.Items.Count > 0 Then
                If ListViewProcedures.Items.Count - 1 >= SaveIndex Then
                    ListViewProcedures.Items(SaveIndex).Selected = True
                Else
                    ListViewProcedures.Items(SaveIndex - 1).Selected = True
                End If
            End If
            ProcAdded = True
            NewLI.Selected = True
            NewLI.EnsureVisible()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try

    End Sub

    Private Sub ListViewProcedures_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewProcedures.DoubleClick
        If ListViewProcedures.SelectedItems.Count > 0 Then
            cmdAdd_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewProcedures_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewProcedures.KeyDown
        'ComboBoxBillingProvider.Focus()
        If e.KeyValue = 13 Then
            If ListViewProcedures.SelectedItems.Count > 0 Then
                cmdAdd_Click(Nothing, Nothing)
            End If
        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub ListViewProcedures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewProcedures.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxReferringDoctor_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBoxReferringDoctor.DrawItem

    End Sub

    Private Sub ComboBoxReferringDoctor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxReferringDoctor.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxBillingProvider_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBoxBillingProvider.DrawItem
        If e.Index < 0 Then
            e.DrawBackground()
            e.DrawFocusRectangle()
            Exit Sub
        End If
        Dim CurrentColor As Color

        CurrentColor = Color.FromArgb(CType(ComboBoxBillingProvider.Items(e.Index), ValueDescription).Value1)
        'Dim SizeRect As Rectangle = New Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height)
        Dim SizeRect As Rectangle = New Rectangle(e.Bounds.Width - 40, e.Bounds.Top + 2, 40, e.Bounds.Height - 4)
        Dim ComboBrush As Brush
        e.DrawBackground()
        e.DrawFocusRectangle()
        e.Graphics.FillRectangle(New SolidBrush(CurrentColor), SizeRect)
        ' change brush color if item is selected
        ComboBrush = Brushes.Black
        e.Graphics.DrawString(CType(ComboBoxBillingProvider.Items(e.Index), ValueDescription).Description, ComboBoxBillingProvider.Font, ComboBrush, e.Bounds.Left, ((e.Bounds.Height - ComboBoxBillingProvider.Font.Height) \ 2) + e.Bounds.Top)

    End Sub

    Private Sub ComboBoxBillingProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxBillingProvider.SelectedIndexChanged

    End Sub

End Class