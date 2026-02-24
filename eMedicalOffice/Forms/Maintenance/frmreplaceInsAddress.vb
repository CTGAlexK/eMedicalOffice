Public Class frmReplaceInsAddress
    Dim OldCompanyID As Long = 0
    Dim NewCompanyID As Long = 0
    Private Sub txtOldCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOldCode.TextChanged
        txtNumberOfBills.Text = ""
        txtOldAddress.ForeColor = Color.Black
        txtOldAddress.Font = txtOldCode.Font.Clone
        If txtOldCode.Text = "" Then
            txtOldAddress.Text = ""
            OldCompanyID = 0
            Exit Sub
        End If
        If IsNumeric(txtOldCode.Text) = False Then
            txtOldAddress.Text = "Wrong Insurance Address Code. The Address Code should be numeric."
            txtOldAddress.ForeColor = Color.Red
            OldCompanyID = 0
            Exit Sub
        End If

        Dim Ret As Long = gSQLGetSingleValue("SELECT count(*) FROM Bills WHERE InsAddressID = " & Val(txtOldCode.Text))
        txtNumberOfBills.Text = "Bills Found : " & Ret
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("SELECT CompanyID, AddressName +' - ' +Address + ' ' + City +', '+State+', '+Zip as Address FROM InsuranceCompanyAddresses WHERE AddressID = " & Val(txtOldCode.Text))
        If Reader.HasRows Then
            Reader.Read()
            OldCompanyID = Val(Reader("CompanyID").ToString)
            txtOldAddress.Text = StrConv(Reader("Address").ToString, VbStrConv.ProperCase)
            If CheckSameInsuranceCompany() Then
                txtOldAddress.ForeColor = Color.Black
            Else
                txtOldAddress.ForeColor = Color.Red
                txtOldAddress.Font = New Font(txtOldCode.Font, FontStyle.Strikeout)
            End If
        Else
            OldCompanyID = 0
            txtOldAddress.Text = "Insurance Address Code Not Found"
            txtOldAddress.ForeColor = Color.Red
        End If
    End Sub
    Private Sub txtNewCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewCode.TextChanged
        txtNewAddress.ForeColor = Color.Black
        txtNewAddress.Font = txtNewCode.Font.Clone
        If txtNewCode.Text = "" Then
            txtNewAddress.Text = ""
            NewCompanyID = 0
            Exit Sub
        End If
        If IsNumeric(txtNewCode.Text) = False Then
            txtNewAddress.Text = "Wrong Insurance Address Code. The Address Code should be numeric. "
            txtNewAddress.ForeColor = Color.Red
            NewCompanyID = 0
            Exit Sub
        End If
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("SELECT ActiveInd, CompanyID, AddressName +' - ' +Address + ' ' + City +', '+State+', '+Zip as Address FROM InsuranceCompanyAddresses WHERE AddressID = " & Val(txtNewCode.Text))
        If Reader.HasRows Then
            Reader.Read()
            If Val(Reader("ActiveInd").ToString) = 0 Then
                NewCompanyID = 0
                txtNewAddress.Text = "Insurance Address no longer active"
                txtNewAddress.ForeColor = Color.Red
                Exit Sub
            End If
            NewCompanyID = Val(Reader("CompanyID").ToString)
            txtNewAddress.Text = StrConv(Reader("Address").ToString, VbStrConv.ProperCase)
            If CheckSameInsuranceCompany() Then
                txtNewAddress.ForeColor = Color.Black
            Else
                txtNewAddress.ForeColor = Color.Red
                txtNewAddress.Font = New Font(txtNewCode.Font, FontStyle.Strikeout)
            End If
        Else
            NewCompanyID = 0
            txtNewAddress.Text = "Insurance Address Code Not Found"
            txtNewAddress.ForeColor = Color.Red
        End If

    End Sub
    Private Function CheckSameInsuranceCompany() As Boolean
        CheckSameInsuranceCompany = False
        If OldCompanyID = 0 Or NewCompanyID = 0 Then
            CheckSameInsuranceCompany = True
            Exit Function
        End If
        If OldCompanyID = NewCompanyID Then
            CheckSameInsuranceCompany = True
        End If
    End Function
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        '        txtNumberOfBills.Text = ""
        If IsNumeric(txtOldCode.Text) = False Then
            MsgBox("Unable to update." & vbCrLf & "The Old Insurance Address Code is required.", MsgBoxStyle.Critical)
            txtOldCode.Focus()
            Exit Sub
        End If
        If IsNumeric(txtNewCode.Text) = False Then
            MsgBox("Unable to update." & vbCrLf & "The New Insurance Address Code is required.", MsgBoxStyle.Critical)
            txtNewCode.Focus()
            Exit Sub
        End If
        If CheckSameInsuranceCompany() = False Then
            MsgBox("Unable to update." & vbCrLf & "The specified Addresses are from the different insurance companies.", MsgBoxStyle.Critical)
            txtNewCode.Focus()
            Exit Sub
        End If
        If txtNewCode.Text = txtOldCode.Text Then
            MsgBox("Unable to update." & vbCrLf & "The New Insurance Address Code is the same as the old one.", MsgBoxStyle.Critical)
            txtNewCode.Focus()
            Exit Sub
        End If

        Dim Ret As Long = gSQLGetSingleValue("SELECT count(*) FROM InsuranceCompanyAddresses WHERE AddressID = " & Val(txtOldCode.Text))
        If Ret = 0 Then
            MsgBox("Unable to update." & vbCrLf & "Invalid Old Insurance Address Code.", MsgBoxStyle.Critical)
            txtOldCode.Focus()
            Exit Sub
        End If
        Ret = 0
        Ret = gSQLGetSingleValue("SELECT count(*) FROM InsuranceCompanyAddresses WHERE ActiveInd=1 and AddressID = " & Val(txtNewCode.Text))
        If Ret = 0 Then
            MsgBox("Unable to update." & vbCrLf & "Invalid New Insurance Address Code.", MsgBoxStyle.Critical)
            txtNewCode.Focus()
            Exit Sub
        End If

        Ret = gSQLGetSingleValue("SELECT count(*) FROM Bills WHERE InsAddressID = " & Val(txtOldCode.Text))
        If Ret > 0 Then
            If MsgBox("Please confirm you want to update " & Val(ret) & " bills." & vbCrLf & "The Old Insurance Address Code: " & txtOldCode.Text & vbCrLf & "The New Insurance Address Code: " & txtNewCode.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            gSQLUpdateData("UPDATE Bills set InsAddressID = " & Val(txtNewCode.Text) & " WHERE InsAddressID = " & Val(txtOldCode.Text))
        End If
        If MsgBox("The Bills Address has been updated." & vbCrLf & vbCrLf & "Would you like to delete the old address from the database?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            gSQLUpdateData("DELETE FROM  InsuranceCompanyAddresses Where AddressID = " & Val(txtOldCode.Text))
        End If
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


End Class