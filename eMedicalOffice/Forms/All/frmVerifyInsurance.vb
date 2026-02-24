Public Class frmVerifyInsurance

    Private Sub frmVerifyInsurance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub frmVerifyInsurance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        AddHandler cboInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave

        Load_Data()

    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        With cboInsuranceCompanyID
            .Items.Clear()
            .Items.Add(New ValueDescription(0, "All"))
            .Items.Add(New ValueDescription(-1, "-----------------------------------------INSURANCE GROUPS-----------------------------------------"))
            .SelectedIndex = 0
            .DropDownHeight = 106
            Application.DoEvents()

            Reader = gSQLGetDataReader("SELECT DISTINCT  GroupID, Description FROM InsuranceCompaniesGroups ORDER BY Description")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("GroupID").ToString)), Reader("Description").ToString & " - Group", "0"))
            Loop
            If .Items.Count > 0 Then
                .Items.Add(New ValueDescription(-1, "--------------------------------------INSURANCE COMPANIES--------------------------------------"))
            End If
            Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies ORDER BY CompanyName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString, "1"))
            Loop
            If .Items.Count = 0 Then
                .DropDownHeight = 20
            End If
        End With
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cboInsuranceCompanyID.SelectedIndex = 0
        txtPatient.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Find_Profiles()
    End Sub

    Private Sub Find_Profiles()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim PName() As String
        Dim I As Integer
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem

        SQL = "SELECT   Patients.PatientID, ISNULL(Patients.FName, '') + '  ' + ISNULL(Patients.LName, '') + ' ' + ISNULL(Patients.MI, '') AS PatName, Patients.DOB, Patients.StateOfAccident, "
        SQL &= "        Patients.DOA, InsuranceCompanies.CompanyName, isnull(InsuranceCompanies.Phone1,'') + '  ' + isnull(InsuranceCompanies.Phone2,'') as Contact, Patients.AdjusterName, Patients.AdjusterPhone, "
        SQL &= "        Patients.ClaimNumber, Patients.PolicyNumber, Patients.InsuranceVerifyed, Patients.Comments"
        SQL &= " FROM         Patients INNER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID "
        SQL &= " WHERE Patients.InsuranceVerifyed = 0 "

        If txtPatient.Text.Trim <> "" Then
            If IsNumeric(txtPatient.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(txtPatient.Text) & " "
            Else
                PName = Split(txtPatient.Text.ToSafeSQLString(), " ")
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

        If cboInsuranceCompanyID.SelectedIndex > 0 Then
            If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value1 = "0" Then
                SQL &= " AND Patients.InsuranceCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & ") "
            Else
                SQL &= " AND Patients.InsuranceCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
            End If
        End If
        SQL &= " ORDER BY InsuranceCompanies.CompanyID, AdjusterName, DOA"

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListView1.SuspendLayout()
        ListView1.Items.Clear()
        ListView1.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("PatientID").ToString)
            LI.UseItemStyleForSubItems = False
            LI.Tag = Val(Reader("PatientID").ToString)
            LI.SubItems.Add(Reader("PatName").ToString)
            If IsDate(Reader("DOB").ToString) Then
                LI.SubItems.Add(CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add("").BackColor = Color.FromArgb(50, 255, 192, 128)
            End If
            LI.SubItems.Add(Reader("StateOfAccident").ToString)
            If IsDate(Reader("DOA").ToString) Then
                LI.SubItems.Add(CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add("").BackColor = Color.FromArgb(50, 255, 192, 128)
            End If
            LI.SubItems.Add(Reader("CompanyName").ToString)
            LI.SubItems.Add(Reader("Contact").ToString)
            LI.SubItems.Add(Reader("AdjusterName").ToString)
            If Reader("AdjusterPhone").ToString <> "(___) ___-____ Ext. _____" Then
                LI.SubItems.Add(Reader("AdjusterPhone").ToString)
            Else
                LI.SubItems.Add("")
            End If
            SI = LI.SubItems.Add(Reader("PolicyNumber").ToString)
            If Reader("PolicyNumber").ToString = "" Then SI.BackColor = Color.FromArgb(50, 255, 192, 128)
            SI = LI.SubItems.Add(Reader("ClaimNumber").ToString)
            If Reader("ClaimNumber").ToString = "" Then SI.BackColor = Color.FromArgb(50, 255, 192, 128)
            SI = LI.SubItems.Add(Replace(Reader("Comments").ToString, vbCrLf, " "))
            SI.Tag = Reader("Comments").ToString
        Loop
        Reader.Close()
        Reader = Nothing
        ListView1.ResumeLayout(True)

    End Sub

    Private Sub cboInsuranceCompanyID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboInsuranceCompanyID.KeyUp
        gComboboxAutoComplete(cboInsuranceCompanyID, e, True)
    End Sub

    Private Sub cboInsuranceCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceCompanyID.SelectedIndexChanged
        If cboInsuranceCompanyID.SelectedIndex > -1 Then
            If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value = -1 Then
                cboInsuranceCompanyID.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Dim LI As ListViewItem
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        LI = ListView1.SelectedItems(0)
        LI.EnsureVisible()
        LI.Selected = True
        Using frm As frmVerivyInsuranceCompanyDetails = New frmVerivyInsuranceCompanyDetails

            With frm
                .LI = LI
                .LV = ListView1
                .lblPatient.Text = "Patient: " & LI.Text & "  " & LI.SubItems(1).Text
                .lblPatient.Tag = LI.Tag
                .lblInsurance.Text = "Insurance: " & LI.SubItems(5).Text
                .lblInsuranceContact.Text = LI.SubItems(6).Text
                .lblAdjuster.Text = "Adjuster: " & LI.SubItems(7).Text
                .lblAdjusterContact.Text = LI.SubItems(8).Text
                .txtPolicyNumber.Text = LI.SubItems(9).Text
                .txtClaimNumber.Text = LI.SubItems(10).Text
                .txtComments.Text = LI.SubItems(11).Tag
                If LI.BackColor = Color.LightGreen Then
                    .CheckBox1.Checked = True
                End If
                .MinimizeBox = False
                .MaximizeBox = False
                .ShowDialog(Me)
            End With
            frm.Dispose()
        End Using
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListView1.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub OpenInfuranceInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenInfuranceInformationToolStripMenuItem.Click
        ListView1_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ButtonTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListView1_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub OpenPatientsProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSelectedPatientInfo1.Click
        Dim LI As ListViewItem
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.MinimizeBox = False
            NewFrm.InitialPatientName = LI.Text
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
    End Sub

End Class