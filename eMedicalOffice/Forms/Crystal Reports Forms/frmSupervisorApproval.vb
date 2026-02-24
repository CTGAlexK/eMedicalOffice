Public Class frmSupervisorApproval
    Public SupervisorID As Long
    Public SupervisorName As String
    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

        If Validate_Supervisor() = True Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Function Validate_Supervisor() As Boolean
        Dim SQl As String
        Dim Reader As SqlClient.SqlDataReader
        If txtUserName.Text = "" Then
            ErrorProvider1.SetError(txtUserName, "Unable to process login. The Login User Name is required.")
            LabelError.Text = "The Supervisor User Name is required."
            Beep()
            txtUserName.Focus()
            Exit Function
        End If
        If txtPassword.Text = "" Then
            ErrorProvider1.SetError(txtPassword, "Unable to process login. The Login Password is required.")
            LabelError.Text = "The Supervisor  is required."
            Beep()
            txtPassword.Focus()
            Exit Function
        End If
        SQl = "Select Fname, Lname , Employees.EmpID, Password, PositionID From Employees inner join EmployeeOffice on Employees.EmpID=EmployeeOffice.EmpID inner join Offices on Offices.OfficeID=EmployeeOffice.OfficeID Where Employees.ActiveInd=1 and UID='" & RBC(txtUserName.Text) & "' AND EmployeeOffice.OfficeID=" & gOfficeID
        Reader = gSQLGetDataReader(SQl)
        If Reader Is Nothing Then Exit Function
        If Reader.Read = False Then
            ErrorProvider1.SetError(txtUserName, "Invalid Security Information.")
            ErrorProvider1.SetError(txtPassword, "Invalid Security Information.")
            Beep()
            LabelError.Text = "Invalid Security Information."
            txtUserName.Focus()
            Reader.Close()
            Exit Function
        Else
            If txtPassword.Text <> gEncrypt(Reader("Password").ToString) Then
                ErrorProvider1.SetError(txtUserName, "Invalid Security Information.")
                ErrorProvider1.SetError(txtPassword, "Invalid Security Information.")
                Beep()
                LabelError.Text = "Invalid Security Information."
                txtUserName.Focus()
                Reader.Close()
                Exit Function
            End If
            If Val(Reader("PositionID").ToString) > 1 Then
                ErrorProvider1.SetError(txtUserName, "Not authorized to approve this schedule.")
                ErrorProvider1.SetError(txtPassword, "Not authorized to approve this schedule.")
                Beep()
                LabelError.Text = "Not authorized to approve this transaction."
                txtUserName.Focus()
                Reader.Close()
                Exit Function
            End If
            SupervisorName = Reader("Fname").ToString.Trim & " " & Reader("Lname").ToString.Trim
            SupervisorID = Val(Reader("EmpID").ToString)
            Validate_Supervisor = True
            Reader.Close()
        End If
    End Function
    Private Sub txtUserName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.TextChanged
        ErrorProvider1.SetError(txtUserName, "")
        ErrorProvider1.SetError(txtPassword, "")
        LabelError.Text = ""
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        ErrorProvider1.SetError(txtUserName, "")
        ErrorProvider1.SetError(txtPassword, "")
        LabelError.Text = ""
    End Sub

    Private Sub frmSupervisorApproval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class