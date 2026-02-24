Public Class frmBillingProcedureCHange
    Public PatientID As Integer
    Public ProcID As Integer
    Public ProcCode As String
    Public PatientProcedureID As Integer
    Public ProcedureName As String
    Public DiagID As Integer
    Public ForBillingOnly As Integer
    Public CalledForm As frmBilling
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim ScheduleID As Integer
        Dim NewProcID As Integer
        Dim LI As ListViewItem
        Dim SupervisorName As String
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No procedure selected.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)
        If ProcID = Val(LI.Tag) Then
            MsgBox("Unable to process your request." & vbCrLf & "The same procedure selected.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Exit Sub
        End If

        If CalledForm.AdminAuthorizedByName = "" Then
            Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
            If Suppervisor.SupervisorName = "" Then Exit Sub
            If SupervisorName = "" Then Exit Sub
        Else
            SupervisorName = CalledForm.AdminAuthorizedByName
        End If
        If MsgBox("Attention!" & vbCrLf & "You want to replace" & vbCrLf & vbCrLf & "Procedure: " & ProcedureName & vbCrLf & vbCrLf & "with" & vbCrLf & vbCrLf & "Procedure: " & ListView1.SelectedItems(0).Text & vbCrLf & vbCrLf & "Please confirm.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        NewProcID = LI.Tag
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tProceduresRemoved, "Procedure: " & ProcedureName & "  " & ProcCode & " Replaced With " & LI.Text & "  " & LI.SubItems(1).Text, SupervisorName)
        gSQLUpdateData("Update PatientProcedures Set ProcID = " & NewProcID & " where PatientProcedureID=" & PatientProcedureID)
        If CheckBoxKeepAuthorized.Checked Then
            CalledForm.AdminAuthorizedByName = SupervisorName
        Else
            CalledForm.AdminAuthorizedByName = ""
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub frmBillingProcedureCHange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Procedures()
    End Sub
    Private Sub Load_Procedures()
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        ListView1.Items.Clear()
        SQL = "select ProcID, ProcName, Code, NFCost, WCCost, PRCost from Procedures Where ActiveInd=1 and DiagID=" & DiagID
        If ForBillingOnly = 0 Then
            SQL &= " and (ProcID=" & ProcID & ")"
        Else
            SQL &= " and (ForBillingOnly=" & ForBillingOnly & " or ProcID=" & ForBillingOnly & ")"
        End If
        SQL &= " Order by ProcName"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("ProcName").ToString.Trim)
            LI.SubItems.Add(Reader("Code").ToString.Trim)
            LI.SubItems.Add(Val(Reader("NFCost").ToString).ToString("c"))
            LI.SubItems.Add(Val(Reader("WCCost").ToString).ToString("c"))
            LI.SubItems.Add(Val(Reader("PRCost").ToString).ToString("c"))

            LI.Tag = Val(Reader("ProcID").ToString.Trim)
        Loop

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Procedures()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Procedures()
    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Procedures()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub
End Class