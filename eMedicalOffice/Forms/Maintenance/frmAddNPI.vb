Imports System.Reflection
Imports log4net

Public Class frmAddNPI
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public CalledForm As Object
    Public ID As Long

    Private Sub txtNPI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNPI.TextChanged
        ErrorProvider1.SetError(txtNPI, "")
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Try
            Dim Reader As SqlClient.SqlDataReader
            Dim li As ListViewItem
            gLoop_Trim_Controls(Me)
            If ComboBoxInsuranceCompany.SelectedIndex = -1 Then
                ErrorProvider1.SetError(ComboBoxInsuranceCompany, "The Insurance Company should be selected.")
                MsgBox("Unable to update. The Insurance Company should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxInsuranceCompany.Focus()
                Exit Sub
            End If
            If txtNPI.Text = "" Then
                ErrorProvider1.SetError(txtNPI, "The Address Name should be specified.")
                MsgBox("Unable to update. The Address Name should be specified.", MsgBoxStyle.Exclamation)
                txtNPI.Focus()
                Exit Sub
            End If
            Reader = gSQLGetDataReader("Select count(*) as C from DoctorInsuranceNPI Where NPI = '" & txtNPI.Text.ToSafeSQLString() & "' and EmpID <> " & ID)
            If Reader Is Nothing Then Exit Sub
            Reader.Read()
            If Reader("C") > 0 Then
                ErrorProvider1.SetError(txtNPI, "Duplicate NPI Number.")
                MsgBox("Unable to update. Duplicate NPI Number. This NPI is already assigned to another doctor.", MsgBoxStyle.Exclamation)
                txtNPI.Focus()
                Reader.Close() : Reader.Dispose()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()
            For Each li In frmEmployeeMaintenance.ListViewNPI.Items
                If li.SubItems(1).Text = txtNPI.Text Then
                    ErrorProvider1.SetError(txtNPI, "Duplicate NPI Number.")
                    MsgBox("Unable to update. Duplicate NPI Number. This NPI is already assigned to this doctor.", MsgBoxStyle.Exclamation)
                    txtNPI.Focus()
                    Reader.Close() : Reader.Dispose()
                    Exit Sub
                End If
            Next

            li = frmEmployeeMaintenance.ListViewNPI.Items.Add(CType(ComboBoxInsuranceCompany.SelectedItem, ValueDescription).Description)
            li.SubItems.Add(txtNPI.Text)
            li.Selected = True
            li.EnsureVisible()
            li.Tag = CType(ComboBoxInsuranceCompany.SelectedItem, ValueDescription).Value
            Reader.Close() : Reader.Dispose()
            Me.Close()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ComboBoxAddressName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        sSearchComboBox_KeyUp(sender, e, False)
    End Sub

    Private Sub ComboBoxAddressName_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmAddDiagnos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_data()
    End Sub

    Private Sub Load_data()
        Dim Reader As SqlClient.SqlDataReader
        Dim lAutocomplete As New AutoCompleteStringCollection()
        Dim lAutocomplete1 As New AutoCompleteStringCollection()
        Dim IDs As String = ""
        Dim LI As ListViewItem
        For Each LI In frmEmployeeMaintenance.ListViewNPI.Items
            IDs = IDs & LI.Tag & ", "
        Next

        If IDs.Length > 0 Then
            IDs = IDs.Mid(1, IDs.Length - 2)
        Else
            IDs = 0
        End If
        Reader = gSQLGetDataReader("SELECT     CompanyID, CompanyName FROM InsuranceCompanies WHERE CaseTypeID = 3 AND CompanyID NOT IN (" & IDs & ") ORDER BY CompanyName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxInsuranceCompany.Items.Add(New ValueDescription(Reader("CompanyID").ToString, Reader("CompanyName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub ComboBoxInsuranceCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxInsuranceCompany.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxInsuranceCompany, "")
    End Sub

End Class