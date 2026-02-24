Imports System.Reflection
Imports log4net

Public Class frmReplaceProcedure
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientID As Long
    Public PatientProcedureID As Long
    Public OldProcId As Long
    Public OldProcName As String
    Public CaseType As Integer
    Private SupervisorName As String
    Public CalledListViewProcedures As ListView
    Public CalledFrom As String = False

    Private Sub frmBillingChangeBillDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
    End Sub
    Private Sub Load_Data()
        Try
            Dim Reader As SqlClient.SqlDataReader
            Dim SQL As String

            SQL = "SELECT DiagID, DiagName FROM Diagnostics Where  ActiveInd =1 and DiagTypeID=1 or DiagTypeID=3 and Diagnostics.OfficeID=" & gOfficeID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxDiagIDSearch.Items.Add(New ValueDescription(CLng(Val(Reader("DiagID").ToString)), Reader("DiagName").ToString))
            Loop
            If Val(GetSetting(My.Application.Info.ProductName, "Settings", "AddProcedureLastTypeIndex", 0)) <= ComboBoxDiagIDSearch.Items.Count - 1 Then
                ComboBoxDiagIDSearch.SelectedIndex = GetSetting(My.Application.Info.ProductName, "Settings", "AddProcedureLastTypeIndex", 0)
            End If
            If CaseType = 1 Then
                LabelCaseType.Text = "NOFAULT CASE"
            ElseIf CaseType = 2 Then
                LabelCaseType.Text = "WORKERS COMP CASE"
            Else
                LabelCaseType.Text = ""
            End If


ExitSub:
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)

        End Try
    End Sub
    Private Sub Load_Procedures()
        Dim filterByCaseType
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        ListViewProcedures.Items.Clear()
        If ComboBoxDiagIDSearch.SelectedIndex = -1 Then Exit Sub
        If ComboBoxDiagIDSearch.SelectedItem Is Nothing Then Exit Sub
        Dim ForBillingOnly As String
        If CaseType = 1 Then
            filterByCaseType = " and NFCost > 0 "
        End If
        If CaseType = 2 Then
            filterByCaseType = " and WCCost > 0 "
        End If
        If CheckBox1.Checked Then
            ForBillingOnly = " and isnull(Procedures.ForBillingOnly,0)=1"
        End If
        Dim PriceFieldName As String = "NFCost"
        If CaseType = 1 Then
            PriceFieldName = "NFCost"
        ElseIf CaseType = 2 Then
            PriceFieldName = "WCCost"
        ElseIf CaseType = 3 Then
            PriceFieldName = "PRCost"
        End If


        If IsNumeric(TextBoxSearch.Text) Then
            Reader = gSQLGetDataReader("Select " & PriceFieldName & ", ProcedureTypeID, Procedures.DiagID, Procedures.ProcID, Procedures.ProcName, Procedures.ProcDescription, Procedures.Code from Procedures Where Procedures.ActiveInd=1  and Procedures.DiagID=" & CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value & "  and (Procedures.Code like '%" & TextBoxSearch.Text & "%') " & filterByCaseType & ForBillingOnly & " Order by ProcName")
        Else
            Reader = gSQLGetDataReader("Select " & PriceFieldName & ",ProcedureTypeID, Procedures.DiagID, Procedures.ProcID, Procedures.ProcName, Procedures.ProcDescription, Procedures.Code from Procedures Where  Procedures.ActiveInd=1  and Procedures.DiagID=" & CType(ComboBoxDiagIDSearch.SelectedItem, ValueDescription).Value & "  and (ProcName like '%" & TextBoxSearch.Text & "%') " & filterByCaseType & ForBillingOnly & "  Order by ProcName")
        End If
        If Reader Is Nothing Then Exit Sub
        ListViewProcedures.BeginUpdate()
        Do Until Reader.Read = False
            LI = ListViewProcedures.Items.Add(Reader("ProcName").ToString, 0)
            LI.SubItems.Add(Reader("Code").ToString).Tag = Reader("ProcedureTypeID").ToString
            LI.SubItems.Add(Convert.ToDecimal(Reader(PriceFieldName)).ToString("c"))
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
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub
        If ListViewProcedures.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No procedure selected.", MsgBoxStyle.Exclamation)
            ListViewProcedures.Focus()
            Exit Sub
        End If
        Dim LI As ListViewItem = ListViewProcedures.SelectedItems(0)
        Dim NewProcID As Long = Val(LI.Tag)
        Dim NewProcName As String = LI.Text
        Dim NewProcTypeName As String = ComboBoxDiagIDSearch.Text
        If OldProcId = Val(LI.Tag) Then
            MsgBox("Unable to process your request." & vbCrLf & "The same procedure selected.", MsgBoxStyle.Exclamation)
            ListViewProcedures.Focus()
            Exit Sub
        End If
        Dim OldProcCode As String = gSQLGetSingleValueString("SELECT Procedures.Code from Procedures where Procedures.ProcID = " & OldProcId)
        Dim PriceFieldName As String = "NFCost"
        If CaseType = 1 Then
            PriceFieldName = "NFCost"
        ElseIf CaseType = 2 Then
            PriceFieldName = "WCCost"
        ElseIf CaseType = 3 Then
            PriceFieldName = "PRCost"
        End If
        Dim NewPrice As Double = gSQLGetSingleValue("SELECT " & PriceFieldName & " from Procedures where Procedures.ProcID = " & NewProcID)


        gUpdate_Profile_Log(PatientID, PatientLogTypes.tProceduresRemoved, "Procedure: " & OldProcName & "  " & OldProcCode & " Replaced With " & LI.Text & "  " & LI.SubItems(1).Text, SupervisorName)
        gSQLUpdateData("Update PatientProcedures Set billingPrice = " & NewPrice & ", ProcID = " & NewProcID & " where PatientProcedureID=" & PatientProcedureID)
        If CalledFrom = "PatientMaintenance" Then
            CalledListViewProcedures.SelectedItems(0).SubItems(1).Text = NewProcName
            CalledListViewProcedures.SelectedItems(0).SubItems(5).Text = NewProcTypeName
            ListViewProcedures.SelectedItems(0).Tag = NewProcID
        ElseIf CalledFrom = "Billing" Then
            CalledListViewProcedures.SelectedItems(0).SubItems(2).Text = NewPrice
            CalledListViewProcedures.SelectedItems(0).SubItems(1).Text = NewProcName
            CalledListViewProcedures.SelectedItems(0).Tag = NewProcID
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        txtPassword.PasswordChar = "*"
    End Sub

    Private Sub ComboBoxDiagIDSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDiagIDSearch.SelectedIndexChanged
        Load_Procedures()
    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        Load_Procedures()
    End Sub

    Private Sub ListViewProcedures_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewProcedures.SelectedIndexChanged
        LabelNewProc.Text = ""
        If ListViewProcedures.SelectedItems.Count = 0 Then Exit Sub
        LabelNewProc.Text = ListViewProcedures.SelectedItems(0).Text.ToUpper()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Load_Procedures()
    End Sub

    Private Sub txtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserName.TextChanged

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class