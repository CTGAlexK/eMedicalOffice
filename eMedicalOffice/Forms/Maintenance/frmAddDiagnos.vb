Imports System.Reflection
Imports log4net

Public Class frmAddDiagnos

    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public CalledForm As Object

    Private Sub txtAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtICDDescription.TextChanged
        ErrorProvider1.SetError(txtICDDescription, "")
    End Sub

    Private Sub txtICDGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtICDGroup.TextChanged
        ErrorProvider1.SetError(txtICDGroup, "")
    End Sub

    Private Sub txtClaimZip_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Try
            Dim Reader As SqlClient.SqlDataReader
            gLoop_Trim_Controls(Me)
            If txtICDCode.Text = "" Then
                ErrorProvider1.SetError(txtICDCode, "The ICDCode is required.")
                MsgBox("Unable to update. The ICDCode is required.", MsgBoxStyle.Exclamation)
                txtICDCode.Focus()
                Exit Sub
            End If
            If IsNumeric(txtICDCode.Text) = False Then
                ErrorProvider1.SetError(txtICDCode, "Invalid ICDCode.")
                MsgBox("Unable to update. Invalid ICDCode. The ICDCode should be numeric value.", MsgBoxStyle.Exclamation)
                txtICDCode.Focus()
                Exit Sub
            End If

            Reader = gSQLGetDataReader("Select count(*) as C from Diagnosis Where ICDCode = '" & txtICDCode.Text & "'")
            If Reader Is Nothing Then Exit Sub
            Reader.Read()
            If Reader("C") > 0 Then
                ErrorProvider1.SetError(txtICDCode, "Duplicate ICDCode.")
                MsgBox("Unable to update. Duplicate ICDCode.", MsgBoxStyle.Exclamation)
                txtICDCode.Focus()
                Reader.Close() : Reader.Dispose()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()

            If txtICDGroup.Text = "" Then
                ErrorProvider1.SetError(txtICDGroup, "The ICDGroup is required.")
                MsgBox("Unable to update. The ICDGroup is required.", MsgBoxStyle.Exclamation)
                txtICDGroup.Focus()
                Exit Sub
            End If
            If txtICDDescription.Text = "" Then
                ErrorProvider1.SetError(txtICDDescription, "The ICDDescription is required.")
                MsgBox("Unable to update. The ICDDescription is required.", MsgBoxStyle.Exclamation)
                txtICDDescription.Focus()
                Exit Sub
            End If
            If txtICDGroup.Text = "" Then
                ErrorProvider1.SetError(txtICDGroup, "The ICDGroup is required.")
                MsgBox("Unable to update. The ICDGroup is required.", MsgBoxStyle.Exclamation)
                txtICDGroup.Focus()
                Exit Sub
            End If

            If txtICDDescription.Text = "" Then
                ErrorProvider1.SetError(txtICDDescription, "The Address Name should be specified.")
                MsgBox("Unable to update. The Address Name should be specified.", MsgBoxStyle.Exclamation)
                txtICDDescription.Focus()
                Exit Sub
            End If
            Reader = gSQLGetDataReader("Select count(*) as C from Diagnosis Where ICDDescription = '" & txtICDDescription.Text.ToSafeSQLString() & "'")
            If Reader Is Nothing Then Exit Sub
            Reader.Read()
            If Reader("C") > 0 Then
                ErrorProvider1.SetError(txtICDDescription, "Duplicate ICDDescription.")
                MsgBox("Unable to update. Duplicate ICDDescription.", MsgBoxStyle.Exclamation)
                txtICDDescription.Focus()
                Reader.Close() : Reader.Dispose()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()

            Dim TA As New SqlClient.SqlDataAdapter("SELECT  * FROM Diagnosis Where 1=2", gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Diagnosis")

            TA.Fill(dTab)
            TR = dTab.NewRow
            TR("ICDCode") = txtICDCode.Text
            TR("ICDGroup") = txtICDGroup.Text
            TR("ICDDescription") = txtICDDescription.Text
            TR("ChangedBy") = gCurrentEmployee.EmpID
            TR("ChangedDT") = Now.ToString("MM/dd/yyyy")
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
            CalledForm.DiagnosID = gSQLGetSingleValue("Select IDENT_CURRENT('Diagnosis')")
            Me.DialogResult = Windows.Forms.DialogResult.OK
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

    Private Sub tctICDCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtICDCode.TextChanged
        ErrorProvider1.SetError(txtICDCode, "")
    End Sub

    Private Sub frmAddDiagnos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_data()
    End Sub

    Private Sub Load_data()
        Dim Reader As SqlClient.SqlDataReader
        Dim lAutocomplete As New AutoCompleteStringCollection()
        Dim lAutocomplete1 As New AutoCompleteStringCollection()
        Reader = gSQLGetDataReader("SELECT  DISTINCT   ICDGroup FROM Diagnosis Where (ICDGroup IS NOT NULL) and ICDGroup <> '' ORDER BY ICDGroup")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            lAutocomplete.Add(Reader("ICDGroup").ToString)

        Loop
        txtICDGroup.AutoCompleteCustomSource = lAutocomplete
        Reader.Close() : Reader.Dispose()
        Reader = gSQLGetDataReader("SELECT  DISTINCT   ICDDescription FROM Diagnosis Where (ICDDescription IS NOT NULL) and ICDDescription <> '' ORDER BY ICDDescription")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            lAutocomplete1.Add(Reader("ICDDescription").ToString)

        Loop
        txtICDDescription.AutoCompleteCustomSource = lAutocomplete1
        Reader.Close() : Reader.Dispose()

    End Sub

End Class