Imports System.Reflection
Imports log4net

Public Class frmInsuranceAddAddress
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public InsCompanyID As Long
    Public CalledForm As Object

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ComboText As String() = {""}
        Dim ComboValue As String() = {""}
        Dim Items() As String = {""}
        Dim I As Integer = 0
        ComboBoxState.Items.Clear()
        Reader = gSQLGetDataReader("Select State, ShowOrder from States Order by ShowOrder")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxState.Items.Add(Reader("State").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        ComboBoxAddressName.Items.Clear()
        Reader = gSQLGetDataReader("SELECT AddressID, AddressName FROM dbo.InsuranceCompanyAddresses WHERE InsuranceCompanyAddresses.CompanyID in (Select CompanyID from InsuranceCompanies WHERE DIFFERENCE(CompanyName, (Select CompanyName From InsuranceCompanies WHERE CompanyID=" & InsCompanyID & ")) >3)")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxAddressName.Items.Add(New ValueDescription(Reader("AddressID").ToString, Reader("AddressName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub txtAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.TextChanged
        ErrorProvider1.SetError(txtAddress, "")
    End Sub

    Private Sub txtCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCity.TextChanged
        ErrorProvider1.SetError(txtCity, "")
    End Sub

    Private Sub txtClaimZip_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtZip.MaskInputRejected

    End Sub

    Private Sub txtClaimZip_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZip.TextChanged
        ErrorProvider1.SetError(txtZip, "")
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Reader As SqlClient.SqlDataReader
        Try

            gLoop_Trim_Controls(Me)
            gLoop_Text_PropperCase(Me, ComboBoxState)

            If ComboBoxAddressName.Text = "" Then
                ErrorProvider1.SetError(ComboBoxAddressName, "The Address Name should be specified.")
                MsgBox("Unable to update. The Address Name should be specified.", MsgBoxStyle.Exclamation)
                ComboBoxAddressName.Focus()
                Exit Sub
            End If
            Reader = gSQLGetDataReader("Select count(*) as C from InsuranceCompanyAddresses Where AddressName = '" & ComboBoxAddressName.Text.ToSafeSQLString() & "' And CompanyID = " & InsCompanyID)
            If Reader Is Nothing Then Exit Sub
            Reader.Read()
            If Reader("C") > 0 Then
                ErrorProvider1.SetError(ComboBoxAddressName, "Duplicate Address Name.")
                MsgBox("Unable to update. Duplicate Address Name.", MsgBoxStyle.Exclamation)
                ComboBoxAddressName.Focus()
                Reader.Close() : Reader.Dispose()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()
            If txtAddress.Text = "" Then
                ErrorProvider1.SetError(txtAddress, "The Address Name should be specified.")
                MsgBox("Unable to update. The Address Name should be specified.", MsgBoxStyle.Exclamation)
                txtAddress.Focus()
                Exit Sub
            End If
            If txtCity.Text = "" Then
                ErrorProvider1.SetError(txtCity, "The Address City should be specified.")
                MsgBox("Unable to update. The Address City should be specified.", MsgBoxStyle.Exclamation)
                txtCity.Focus()
                Exit Sub
            End If
            If ComboBoxState.SelectedIndex = -1 Then
                ErrorProvider1.SetError(ComboBoxState, "Address State should be selected.")
                MsgBox("Unable to update. Address State should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxState.Focus()
                Exit Sub
            End If
            If txtZip.MaskCompleted = False Then
                ErrorProvider1.SetError(txtZip, "Invalid or Missing Zip Code.")
                MsgBox("Unable to update. Invalid or Missing Zip Code.", MsgBoxStyle.Exclamation)
                txtZip.Focus()
                Exit Sub
            End If
            Dim TA As New SqlClient.SqlDataAdapter("SELECT  * FROM InsuranceCompanyAddresses Where 1=2", gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("InsuranceCompanyAddresses")

            TA.Fill(dTab)
            TR = dTab.NewRow
            TR("InsertedBy") = gCurrentEmployee.EmpID
            TR("InsertedDT") = Now.ToString("MM/dd/yy")
            TR("CompanyID") = InsCompanyID
            TR("AddressName") = ComboBoxAddressName.Text
            TR("Address") = txtAddress.Text
            TR("City") = txtCity.Text
            TR("State") = ComboBoxState.Text
            TR("Zip") = txtZip.Text
            TR("ActiveInd") = 1
            dTab.Rows.Add(TR)
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
            CalledForm.NewAddress = gSQLGetSingleValue("Select IDENT_CURRENT('InsuranceCompanyAddresses')")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ComboBoxAddressName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxAddressName.KeyUp
        sSearchComboBox_KeyUp(sender, e, False)
    End Sub

    Private Sub ComboBoxAddressName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxAddressName.Leave

    End Sub

    Private Sub ComboBoxAddressName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxAddressName.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxAddressName, "")
    End Sub

    Private Sub ComboBoxAddressName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxAddressName.TextChanged
        ErrorProvider1.SetError(ComboBoxAddressName, "")

        If ComboBoxAddressName.SelectedIndex > -1 Then
            Dim Reader As SqlClient.SqlDataReader
            Reader = gSQLGetDataReader("SELECT * from InsuranceCompanyAddresses Where AddressID = " & CType(ComboBoxAddressName.SelectedItem, ValueDescription).Value)
            If Reader Is Nothing Then Exit Sub
            If Reader.HasRows Then
                Reader.Read()
                txtAddress.Text = Reader("Address")
                txtCity.Text = Reader("City")
                ComboBoxState.Text = Reader("State")
                txtZip.Text = Reader("Zip")
            Else
                txtAddress.Text = ""
                txtCity.Text = ""
                ComboBoxState.Text = ""
                txtZip.Text = "_____"
            End If
        Else
            txtAddress.Text = ""
            txtCity.Text = ""
            ComboBoxState.SelectedIndex = -1
            txtZip.Text = "_____"
        End If
    End Sub

    Private Sub frmInsuranceAddAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

End Class