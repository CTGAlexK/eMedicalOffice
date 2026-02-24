Public Class frmQuickSearch
    Private KeyDn As Boolean
    Private Loading As Boolean

    Private Sub TextBoxSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxSearch.GotFocus
        TextBoxSearch.SelectAll()
    End Sub

    Private Sub TextBoxSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxSearch.KeyDown
        If e.KeyCode = 40 Then
            If ListViewPatients.SelectedItems.Count > 0 Then
                ListViewPatients.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        If Loading = True Then Exit Sub
        If TextBoxSearch.Text.Trim <> "" Then
            Loading = True
            If IsNumeric(TextBoxSearch.Text) = False And RadioButton1.Checked = True Then
                RadioButton2.Checked = True
            ElseIf IsNumeric(TextBoxSearch.Text) = True And RadioButton2.Checked = True Then
                RadioButton1.Checked = True
            End If
            Loading = False
        Else
            Loading = True
            ListViewPatients.Items.Clear()
            Clear_Details()
            Loading = False
            If txtDOA.MaskCompleted = False And txtDOB.MaskCompleted = False Then Exit Sub
        End If
        If TextBoxSearch.Text.Trim <> "" Or txtDOA.MaskCompleted Or txtDOB.MaskCompleted Then
            Loading = True
            Seach_Data()
            Loading = False
        End If
    End Sub

    Private Sub ListViewPatients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatients.DoubleClick
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        ListViewPatients.Enabled = False
        BtnOk_Click(Nothing, Nothing)
        ListViewPatients.Enabled = True
    End Sub

    Private Sub ListViewPatients_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewPatients.KeyUp
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = False
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub Seach_Data()
        On Error GoTo er
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String = ""
        Dim S As String
        Dim PName() As String
        ListViewPatients.Items.Clear()
        SQL = "Select PatientID, CaseStatusID,FName,LName, NoMoreAppointmentsInd, DOB from Patients Where Patients.OfficeID = " & gOfficeID
        If txtDOA.MaskCompleted Then
            SQL &= " and DOA ='" & txtDOA.Text & "'"
        End If
        If txtDOB.MaskCompleted Then
            SQL &= " and DOB ='" & txtDOB.Text & "'"
        End If
        If TextBoxSearch.Text <> "" Then
            S = TextBoxSearch.Text.ToSafeSQLString()
            If RadioButton1.Checked Then
                SQL &= " and PatientID like '" & S & "%' "
            End If
            If RadioButton2.Checked Then
                PName = Split(S, " ")
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

            If RadioButton3.Checked Then
                SQL &= " and ( PolicyNumber like '" & S & "%' or "
                SQL &= " PolicyNumber1 like '" & S & "%' )"
            End If
            If RadioButton4.Checked Then
                SQL &= " and ( ClaimNumber like '" & S & "%' or "
                SQL &= " ClaimNumber1 like '" & S & "%' )"
            End If
            If RadioButton5.Checked Then
                SQL &= " and SSN like '%" & S & "%' "
            End If
            If RadioButton6.Checked Then
                SQL &= " and ( Phone1 like '" & S & "%' or "
                SQL &= " Phone2 like '" & S & "%' or "
                SQL &= " CellPhone like '" & S & "%' )"
            End If
            If RadioButton7.Checked Then
                SQL &= " AND Patients.PatientID IN (SELECT PatientID FROM PatientProcedures WHERE  PatientProcedures.PACSAltNumber = '" & S & "%')"
            End If
        End If
        If ComboBoxStatus.SelectedIndex = 1 Then
            SQL &= " and CaseStatusID = 1 "
        ElseIf ComboBoxStatus.SelectedIndex = 2 Then
            SQL &= " and CaseStatusID <> 1 "
        End If
        If ComboBoxCaseType.SelectedIndex > 0 Then
            SQL &= " and CaseTypeID = " & CType(ComboBoxCaseType.SelectedItem, ValueDescription).Value
        End If
        'If ComboBoxSearchPeriod.SelectedIndex > 0 Then
        '    SQL &= " and Datediff(m,InsertedDT,getdate())<=" & ComboBoxSearchPeriod.SelectedIndex
        'End If

        SQL &= " Order by FName, LName"

        Reader = gSQLGetDataReader(SQL)

        If Reader Is Nothing Then Exit Sub
        ListViewPatients.BeginUpdate()
        Do Until Reader.Read = False
            LI = ListViewPatients.Items.Add(Reader("PatientID").ToString, CInt(Val(Reader("CaseStatusID").ToString) - 1))
            LI.SubItems.Add(Reader("FName").ToString & " " & Reader("LName").ToString)
            LI.SubItems.Add(CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy"))
            LI.ToolTipText = Reader("FName").ToString & " " & Reader("LName").ToString
            LI.Tag = "" & Reader("PatientID").ToString
            If Val(Reader("NoMoreAppointmentsInd").ToString) <> 0 Then
                LI.ForeColor = Color.Red
            End If
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
        Else
            Clear_Details()
        End If
        Cursor = Cursors.Default
        ListViewPatients.EndUpdate()
        Exit Sub
er:
        ListViewPatients.EndUpdate()
    End Sub

    Public Sub Clear_Details()
        Dim I As Integer
        Dim SPHeight As Integer
        FpSpreadDetails_Sheet1.RowCount = 12
        For I = 0 To FpSpreadDetails_Sheet1.RowCount - 1
            FpSpreadDetails_Sheet1.Cells(I, 0).ForeColor = Color.Black
            FpSpreadDetails_Sheet1.Cells(I, 1).ForeColor = Color.Black
            FpSpreadDetails_Sheet1.SetText(I, 1, "")
            FpSpreadDetails_Sheet1.SetRowHeight(I, CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight))
            SPHeight = SPHeight + CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight)
        Next
        If FpSpreadDetails.Height <> SPHeight Then FpSpreadDetails.Height = SPHeight
        If FpSpreadProcedures.ActiveSheet.RowCount <> 0 Then FpSpreadProcedures.ActiveSheet.RowCount = 0
    End Sub

    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click

    End Sub

    Private Sub Label21_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label21.GotFocus
        txtDOA.Focus()
    End Sub

    Private Sub ListViewPatients_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewPatients.KeyDown
        If e.KeyCode = 38 Then
            If ListViewPatients.SelectedItems.Count > 0 AndAlso ListViewPatients.SelectedItems(0).Index = 0 Then
                TextBoxSearch.Focus()
                TextBoxSearch.SelectAll()
                KeyDn = False
                ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
                Exit Sub
            End If
        End If
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = True
        End If
    End Sub

    Private Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged
        LockWindowUpdate(Me.Handle)
        Panel3.SuspendLayout()
        Dim LI As ListViewItem
        Clear_Details()
        If KeyDn = False Then
            If ListViewPatients.SelectedItems.Count > 0 Then
                LI = ListViewPatients.SelectedItems(0)
                Loading = True
                Show_Details(CLng(Val(LI.Tag)))
                Loading = False
            End If
        End If
        LockWindowUpdate(0)
        Panel3.ResumeLayout(True)
    End Sub

    Public Sub Show_Details(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim lCell As String
        Dim I As Integer
        Dim SPHeight As Integer

        SQL = "SELECT PolicyNumber,ClaimNumber,SSN, ClaimEffectiveDT, CaseTypes.Description as CaseType, Patients.NoMoreAppointmentsInd, Patients.CaseTypeID,   Patients.DOA, Patients.ParentsRequiredInd, Patients.PatientID,  Patients.FName, Patients.MI, Patients.LName, Patients.DOB, Patients.Phone1, Patients.Phone2, Patients.CellPhone, Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, InsuranceCompanies_1.CompanyName AS Insurance1, InsuranceCompanies.CompanyName AS Insurance2, "
        SQL = SQL & " Patients.ReferringDoctor, ReferringOffices.OfficeName AS ReferringCompany, ReferringOffices.Phone1 AS RefPhone1, ReferringOffices.Phone2 AS RefPhone2, ReferringOffices.Phone3 AS RefPhone3, "
        SQL = SQL & " TransportationCompanies.CompanyName AS Transportation, TransportationCompanies.Phone1 AS TransPhone1, TransportationCompanies.Phone2 AS TransPhone2, TransportationCompanies.Phone3 AS TransPhone3, Patients.Comments "
        SQL = SQL & " FROM Patients LEFT OUTER JOIN TransportationCompanies ON Patients.TransportationCompanyID = TransportationCompanies.CompanyID LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID1 = InsuranceCompanies.CompanyID LEFT OUTER JOIN InsuranceCompanies AS InsuranceCompanies_1 ON Patients.InsuranceCompanyID = InsuranceCompanies_1.CompanyID Inner Join CaseTypes on Patients.CaseTypeID = CaseTypes.CaseTypeID "
        SQL = SQL & " WHERE Patients.PatientID = " & ID
        Reader = gSQLGetDataReader(SQL.ToString())
        SPHeight = FpSpreadDetails.Height
        If Reader Is Nothing Then GoTo ExitSub
        Panel3.SuspendLayout()
        FpSpreadDetails.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        FpSpreadProcedures.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        With FpSpreadDetails_Sheet1

            Do Until Reader.Read = False
                If Val(Reader("CaseTypeID").ToString) = 4 Then
                    .SetText(0, 1, Reader("PatientID").ToString & " / " & Reader("CaseType").ToString & " / Payment Required")
                    .Cells(0, 0).ForeColor = Color.Red
                    .Cells(0, 1).ForeColor = Color.Red
                Else
                    .SetText(0, 1, Reader("PatientID").ToString & " / " & Reader("CaseType").ToString)
                    .Cells(0, 0).ForeColor = Color.Black
                    .Cells(0, 1).ForeColor = Color.Black
                End If
                .Cells(0, 1).Tag = Val(Reader("CaseTypeID").ToString)
                .Cells(1, 0).ForeColor = Color.Black
                .Cells(1, 1).ForeColor = Color.Black

                If IsDate(Reader("DOA").ToString) Then
                    .SetText(1, 1, CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy"))
                    If Val(Reader("CaseTypeID").ToString) < 3 Then
                        If DateDiff(DateInterval.Day, CDate(Reader("DOA").ToString), Now) >= Val(gDOAAge) Then
                            .SetText(1, 1, CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy") & "  " & "Insurance Verification Required!")
                            .Cells(1, 0).ForeColor = Color.Red
                            .Cells(1, 1).ForeColor = Color.Red
                        End If
                    End If
                End If

                If Reader("PolicyNumber").ToString <> "" Then .SetText(2, 1, Reader("PolicyNumber").ToString)
                If Reader("ClaimNumber").ToString <> "" Then .SetText(3, 1, Reader("ClaimNumber").ToString)
                If Reader("SSN").ToString <> "" Then .SetText(4, 1, Reader("SSN").ToString)

                If Reader("Phone1").ToString <> "" Then .SetText(5, 1, Reader("Phone1").ToString)
                If Reader("CellPhone").ToString <> "" Then .SetText(6, 1, Reader("CellPhone").ToString)
                If Reader("Phone2").ToString <> "" Then .SetText(7, 1, Reader("Phone2").ToString)
                .SetText(8, 1, Reader("Address1").ToString & " " & Reader("Address2").ToString & IIf(Reader("City").ToString <> "", ", " & Reader("City").ToString, "").ToString & IIf(Reader("State").ToString <> "", ", " & Reader("State").ToString, "").ToString & IIf(Replace(Reader("Zip").ToString, "_", "") <> "", ", " & Reader("Zip").ToString, "").ToString)
                lCell = Reader("ReferringCompany").ToString
                lCell = lCell & IIf(Reader("RefPhone1").ToString <> "" And Reader("RefPhone1").ToString <> "", vbCrLf & Reader("RefPhone1").ToString, "").ToString
                lCell = lCell & IIf(Reader("RefPhone2").ToString <> "" And Reader("RefPhone2").ToString <> "", vbCrLf & Reader("RefPhone2").ToString, "").ToString
                lCell = lCell & IIf(Reader("RefPhone3").ToString <> "" And Reader("RefPhone3").ToString <> "", vbCrLf & Reader("RefPhone3").ToString, "").ToString
                lCell = lCell & IIf(Reader("ReferringDoctor").ToString <> "", vbCrLf & Reader("ReferringDoctor").ToString, "").ToString
                .SetText(9, 1, lCell)
                lCell = Reader("Transportation").ToString
                lCell = lCell & IIf(Reader("TransPhone1").ToString <> "" And Reader("TransPhone1").ToString <> "", vbCrLf & Reader("TransPhone1").ToString, "").ToString
                lCell = lCell & IIf(Reader("TransPhone2").ToString <> "" And Reader("TransPhone2").ToString <> "", vbCrLf & Reader("TransPhone2").ToString, "").ToString
                lCell = lCell & IIf(Reader("TransPhone3").ToString <> "" And Reader("TransPhone3").ToString <> "", vbCrLf & Reader("TransPhone3").ToString, "").ToString
                .SetText(10, 1, lCell)
                .SetText(11, 1, Reader("Comments").ToString)
                .Cells(11, 1).ForeColor = Color.Chocolate
                If Val(Reader("ParentsRequiredInd").ToString) = 1 Then
                    .RowCount = .RowCount + 1
                    .SetText(.RowCount - 1, 0, "Attention")
                    .SetText(.RowCount - 1, 1, "Underage Patient - " & gYearsFromDate(Reader("DOB").ToString) & " years old. Parents presence required")
                    .Cells(.RowCount - 1, 0).ForeColor = Color.Red
                    .Cells(.RowCount - 1, 1).ForeColor = Color.Red
                End If
                If Val(Reader("NoMoreAppointmentsInd").ToString) > 0 Then
                    .RowCount = .RowCount + 1
                    .SetText(.RowCount - 1, 0, "Attention")
                    .SetText(.RowCount - 1, 1, "No More Appointments!")
                    .Cells(.RowCount - 1, 0).ForeColor = Color.Red
                    .Cells(.RowCount - 1, 1).ForeColor = Color.Red

                End If
                SPHeight = 0
                For I = 0 To .RowCount - 1
                    .SetRowHeight(I, CInt(.Rows(I).GetPreferredHeight))
                    SPHeight = SPHeight + CInt(.Rows(I).GetPreferredHeight)
                Next

            Loop
        End With
        SPHeight = SPHeight
        If FpSpreadDetails.Height <> SPHeight Then FpSpreadDetails.Height = SPHeight
        SQL = "SELECT     PatientProcedures.PatientProcedureID, PatientProcedures.ProcID, PatientProcedures.DiagID, PatientProcedures.ProcedureStatusID, Procedures.ProcName, Schedule.ScheduleDateTime "
        SQL = SQL & " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Patients on PatientProcedures.PatientID = Patients.PatientID"
        SQL = SQL & " WHERE isnull(NoMoreAppointmentsInd,0)=0 and PatientProcedures.PatientID = " & ID
        SQL = SQL & " Order by PatientProcedures.ProcID "
        Reader = gSQLGetDataReader(SQL.ToString())
        FpSpreadProcedures.ActiveSheet.RowCount = 0
        If Reader Is Nothing Then Panel3.ResumeLayout(True) : GoTo ExitSub
        With FpSpreadProcedures.ActiveSheet
            .RowCount = 0
            Do Until Reader.Read = False
                .RowCount = .RowCount + 1
                .SetText(.RowCount - 1, 0, Val(Reader("ProcedureStatusID").ToString).ToString)
                .SetText(.RowCount - 1, 1, Reader("ProcName").ToString)
                If Reader("ScheduleDateTime").ToString <> "" Then
                    If Val(Reader("ProcedureStatusID").ToString) = 1 And DateDiff(DateInterval.Hour, CDate(Reader("ScheduleDateTime")), Now) > gNoShowHours Then
                        .SetText(.RowCount - 1, 2, "NS " & CDate(Reader("ScheduleDateTime")).ToString("MM/dd/yy hh:mm tt"))
                        .Cells(.RowCount - 1, 1).ForeColor = Color.DarkRed
                        .Cells(.RowCount - 1, 2).ForeColor = Color.DarkRed
                        '.Cells(.RowCount - 1, 1).Font = New Font(FpSpreadProcedures.Font, FontStyle.Bold)
                        '.Cells(.RowCount - 1, 2).Font = New Font(FpSpreadProcedures.Font, FontStyle.Bold)
                    Else
                        .SetText(.RowCount - 1, 2, CDate(Reader("ScheduleDateTime")).ToString("MM/dd/yy hh:mm tt"))
                    End If
                End If
                .SetRowHeight(.RowCount - 1, CInt(.Rows(.RowCount - 1).GetPreferredHeight + 2))
            Loop
        End With
ExitSub:
        Panel3.ResumeLayout(True)
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmQuickSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TextBoxSearch.Focus()
    End Sub

    Private Sub frmQuickSearch_BackgroundImageLayoutChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackgroundImageLayoutChanged

    End Sub

    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 7 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        ListViewPatients.Font = F
    End Sub

    Private Sub frmQuickSearch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(My.Application.Info.ProductName, "Settings", "LastQSearchCaseStatusIndex", ComboBoxCaseType.SelectedIndex)
    End Sub

    Private Sub frmQuickSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
        SetFont()
    End Sub

    Private Sub Load_Data()
        Loading = True
        ComboBoxCaseType.Items.Clear()
        ComboBoxCaseType.Items.AddRange(gCaseTypes)
        ComboBoxCaseType.SelectedIndex = CInt(GetSetting(My.Application.Info.ProductName, "Settings", "LastQSearchCaseStatusIndex", "0"))
        ComboBoxStatus.SelectedIndex = 1
        Loading = False
    End Sub

    Private Sub ComboBoxStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxStatus.SelectedIndexChanged
        TextBoxSearch_TextChanged(Nothing, Nothing)
        If Loading Then Exit Sub
        Seach_Data()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Me.UseWaitCursor = True
        Application.DoEvents()
        LI = ListViewPatients.SelectedItems(0)
        Using Frm = New frmPatient
            Frm.InitialTab = 0
            Frm.InitialPatientName = LI.Text
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Me.UseWaitCursor = False
            Frm.ShowDialog(Me)
        End Using

        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    frm.WindowState = FormWindowState.Normal
        '    frm.BringToFront()
        '    Exit Sub
        'Else
        '    frmPatient.InitialTab = 0
        '    frmPatient.InitialPatientName = LI.Text
        '    frmPatient.ShowDialog(Me)
        'End If
    End Sub

    Private Sub ButtonReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReport.Click
        Dim ID As Long
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim PatID(0) As Long
        PatID(0) = ListViewPatients.SelectedItems(0).Tag
        frmPatientInformationReport.Setup_report(PatID)
        Cursor = Cursors.Default
        frmPatientInformationReport.MinimizeBox = False
        frmPatientInformationReport.MaximizeBox = False

        frmPatientInformationReport.ShowDialog(Me)
        frmPatientInformationReport.Dispose()
    End Sub

    Private Sub ToolStripComboBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxCaseType.SelectedIndexChanged
        TextBoxSearch_TextChanged(Nothing, Nothing)
        If Loading Then Exit Sub
        Seach_Data()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Loading Then Exit Sub
        TextBoxSearch.Text = ""
        TextBoxSearch.Focus()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Loading Then Exit Sub
        TextBoxSearch.Text = ""
        TextBoxSearch.Focus()
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        TextBoxSearch.Text = ""
        TextBoxSearch.Focus()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        TextBoxSearch.Text = ""
        TextBoxSearch.Focus()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        TextBoxSearch.Text = ""
        TextBoxSearch.Focus()
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        TextBoxSearch.Text = ""
        TextBoxSearch.Focus()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub FpSpreadDetails_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)

    End Sub

    Private LastIndex As Integer

    Private Sub txtDOA_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDOA.MaskInputRejected

    End Sub

    Private Sub txtDOA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDOA.TextChanged
        If txtDOA.MaskCompleted Then
            TextBoxSearch_TextChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtDOB_TextChanged(sender As Object, e As EventArgs) Handles txtDOB.TextChanged
        If txtDOB.MaskCompleted Then
            TextBoxSearch_TextChanged(Nothing, Nothing)
        End If
    End Sub

End Class