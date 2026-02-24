Public Class frmImportPatientsProviders
    Public Result As DialogResult
    Public ForceClose As Boolean
    Public Sub Load_Data(TypeId As Integer)
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        ComboBoxBillingProvider.Items.Clear()
        ComboBoxTreatingProviderID.Items.Clear()
        ComboBoxReferringCompanyID.Items.Clear()
        SQL = "SELECT     Fname+' '+Lname +' '+ Alias as DName, EmpID,ReferralColor FROM Employees WHERE ActiveInd=1 and BillingPrv = 1 "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxBillingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString, Reader("ReferralColor").ToString))
        Loop
        ComboBoxBillingProvider.SelectedIndex = -1
        Reader.Close() : Reader.Dispose()
        ComboBoxTreatingProviderID.Items.Clear()
        Reader = gSQLGetDataReader("SELECT   EmpID,   Fname, Lname, Alias, BillingPrv, TreatmentPrv FROM Employees WHERE  TreatmentPrv=1 and ActiveInd = 1")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxTreatingProviderID.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("FName").ToString & " " & Reader("LName").ToString & " " & Reader("Alias").ToString))
        Loop
        Reader.Close() : Reader.Dispose()

        SQL = "Select OfficeID, OfficeName from ReferringOffices  order by OfficeName"
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxReferringCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)),
                                                                      Reader("OfficeName").ToString))
        Loop
        Reader.Close()
        Reader.Dispose()
    End Sub
    Public Sub Open_Data(Procedure As String, DiagId As Integer, BPName As String, TRName As String, ReferringDoctor As String, RefOffice As String)
        Result = DialogResult.Cancel
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        If ComboBoxBillingProvider.Items.Count = 1 Then
            ComboBoxBillingProvider.SelectedIndex = 0
        End If
        If ComboBoxTreatingProviderID.Items.Count = 1 Then
            ComboBoxTreatingProviderID.SelectedIndex = 0
        End If
        If ComboBoxReferringCompanyID.Items.Count = 1 Then
            ComboBoxReferringCompanyID.SelectedIndex = 0
        End If
        cboProcedure.Items.Clear()
        Reader = gSQLGetDataReader("SELECT   ProcName, ProcId FROM Procedures WHERE  DiagId = " & DiagId & " and ActiveInd = 1")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboProcedure.Items.Add(New ValueDescription(CLng(Val(Reader("ProcId").ToString)), Reader("ProcName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboProcedure.SelectedIndex = gFindComboItemByText(cboProcedure, Procedure, True)
        txtProcedure.Text = Procedure
        txtBillingProvider.Text = BPName
        txtTreatingProvider.Text = TRName
        txtReferringOffice.Text = RefOffice
        txtReferringDoctor.Text = ReferringDoctor
    End Sub
    Public Sub Reset_Data()
        ComboBoxTreatingProviderID.SelectedIndex = -1
        ComboBoxReferringCompanyID.SelectedIndex = -1
    End Sub
    Private Sub frmImportPatientsProviders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmImportPatientsProviders_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason <> CloseReason.MdiFormClosing And ForceClose = False Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub ComboBoxReferringCompanyID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxReferringCompanyID.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader
        ComboBoxReferringDoctor.Items.Clear()
        ComboBoxReferringDoctor.Text = ""
        If ComboBoxReferringCompanyID.SelectedIndex = -1 Then Return
        Dim ReferringCompanyID = CType(ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value
        Reader = gSQLGetDataReader("Select distinct * from ReferringOffices Where ReferringOffices.OfficeID =" & ReferringCompanyID)
        If Reader Is Nothing Then Return
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
        End If
    End Sub

    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click

        If cboProcedure.SelectedIndex = -1 Then
            MsgBox("Incomplete procedure information" & vbCrLf & "Procedure Name should be selected", MsgBoxStyle.Critical, "Error")
            cboProcedure.Focus()
            cboProcedure.DroppedDown = True
            Return
        End If

        If ComboBoxBillingProvider.SelectedIndex = -1 Then
            MsgBox("Incomplete procedure information" & vbCrLf & "Billing Provider should be selected", MsgBoxStyle.Critical, "Error")
            ComboBoxBillingProvider.Focus()
            ComboBoxBillingProvider.DroppedDown = True
            Return
        End If
        If ComboBoxTreatingProviderID.SelectedIndex = -1 Then
            MsgBox("Incomplete procedure information" & vbCrLf & "Treating Provider should be selected", MsgBoxStyle.Critical, "Error")
            ComboBoxTreatingProviderID.Focus()
            ComboBoxTreatingProviderID.DroppedDown = True
            Return
        End If
        If ComboBoxReferringCompanyID.SelectedIndex = -1 Then
            MsgBox("Incomplete procedure information" & vbCrLf & "Referring Company should be selected", MsgBoxStyle.Critical, "Error")
            ComboBoxReferringCompanyID.Focus()
            ComboBoxReferringCompanyID.DroppedDown = True
            Return
        End If


        If ComboBoxReferringDoctor.SelectedIndex = -1 Then
            MsgBox("Incomplete procedure information" & vbCrLf & "Referring Doctor should be selected", MsgBoxStyle.Critical, "Error")
            ComboBoxReferringDoctor.Focus()
            ComboBoxReferringDoctor.DroppedDown = True
            Return
        End If


        Result = DialogResult.Yes
        Hide()
    End Sub

    Private Sub cmdAddInsuranceAddress_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Using frm As New frmReferringOfficesMaintenance
            Dim SaveSelectedIndex As Integer = -1
            frm.ShowDialog(Me)
            Dim SQL As String
            Dim Reader As SqlClient.SqlDataReader
            ComboBoxReferringCompanyID.Items.Clear()
            SQL = "Select OfficeID, OfficeName from ReferringOffices  order by OfficeName"
            Reader = gSQLGetDataReaderAsync(SQL).Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxReferringCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)),
                                                                      Reader("OfficeName").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxReferringCompanyID.SelectedIndex = SaveSelectedIndex
        End Using
        Cursor = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Using frm As New frmReferringOfficesMaintenance
            Dim SaveSelectedIndex As Integer = -1
            If ComboBoxReferringCompanyID.SelectedIndex > 0 Then
                SaveSelectedIndex = ComboBoxReferringCompanyID.SelectedIndex
                frm.RefOffice = ComboBoxReferringCompanyID.Text
                frm.TabControl1.SelectedIndex = 1
            End If
            frm.ShowDialog(Me)
            Dim SQL As String
            Dim Reader As SqlClient.SqlDataReader
            ComboBoxReferringCompanyID.Items.Clear()
            SQL = "Select OfficeID, OfficeName from ReferringOffices  order by OfficeName"
            Reader = gSQLGetDataReaderAsync(SQL).Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxReferringCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)),
                                                                      Reader("OfficeName").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxReferringCompanyID.SelectedIndex = SaveSelectedIndex
        End Using
        Cursor = Cursors.Default
        Application.DoEvents()

    End Sub
End Class