Public Class frmBillingChangeBillAmount
    Public BillID As Long
    Public CaseTypeID As Long
    Public CaseTypeName As String
    Public CalledBillAmountSI As ListViewItem.ListViewSubItem
    Public CalledBillBalanceSI As ListViewItem.ListViewSubItem
    Public PaidAmount As Double
    Public PatientID As Long
    Private SupervisorName As String
    Private Sub frmBillingChangeBillDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Public Sub LoadProcedures()
        Dim sql As String =
            "SELECT BillProcedures.PatientProcedureID, BillProcedures.ProcName, 
                    BillProcedures.NFCost, BillProcedures.WCCost, BillProcedures.PRCost, 
                    Procedures.NFCost AS NewNFCost, Procedures.WCCost AS NewWCCost, Procedures.PRCost AS NewPRCost, 
                    '' AS AdjustedPrice
             FROM BillProcedures
             INNER JOIN bills ON bills.BillID = BillProcedures.BillID
             INNER JOIN Procedures ON Procedures.ProcID = BillProcedures.ProcID
             WHERE bills.BillID = " & BillID

        Dim ds As DataSet = gSQLGetDataSet(sql)
        Dim dt As DataTable = ds.Tables(0)
        Dim NFCellColor As Color = Color.FromArgb(231, 245, 233)
        Dim WCCellColor As Color = Color.FromArgb(231, 245, 233)
        Dim PRCellColor As Color = Color.FromArgb(231, 245, 233)
        Select Case CaseTypeID
            Case 1 : NFCellColor = Color.FromArgb(190, 210, 194)
            Case 2 : WCCellColor = Color.FromArgb(190, 210, 194)
            Case 3 : PRCellColor = Color.FromArgb(190, 210, 194)
            Case Else
                NFCellColor = Color.FromArgb(205, 235, 211)
        End Select

        dgv.DataSource = Nothing
        dgv.Columns.Clear()
        dgv.AutoGenerateColumns = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        ' PatientProcedureID (hidden)
        dgv.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "PatientProcedureID",
            .HeaderText = "PatientProcedureID",
            .DataPropertyName = "PatientProcedureID",
            .Visible = False
        })

        ' ProcName
        Dim col As New DataGridViewTextBoxColumn() With {
            .Name = "ProcName",
            .HeaderText = "Bill Procedure",
            .DataPropertyName = "ProcName",
            .Width = 200,
            .ReadOnly = True,
            .SortMode = DataGridViewColumnSortMode.NotSortable
        }
        col.DefaultCellStyle.BackColor = Color.LightGray
        dgv.Columns.Add(col)
        ' Existing costs (read-only)
        col = New DataGridViewTextBoxColumn() With {
            .Name = "NFCost",
            .HeaderText = "Bill NF",
            .DataPropertyName = "NFCost",
            .ReadOnly = True,
            .Width = 65,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight},
            .SortMode = DataGridViewColumnSortMode.NotSortable
        }
        col.DefaultCellStyle.BackColor = Color.LightGray
        dgv.Columns.Add(col)


        col = New DataGridViewTextBoxColumn() With {
            .Name = "WCCost",
            .HeaderText = "Bill WC",
            .DataPropertyName = "WCCost",
            .ReadOnly = True,
            .Width = 65,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight},
            .SortMode = DataGridViewColumnSortMode.NotSortable
        }
        col.DefaultCellStyle.BackColor = Color.LightGray
        dgv.Columns.Add(col)

        col = New DataGridViewTextBoxColumn() With {
            .Name = "PRCost",
            .HeaderText = "Bill PR",
            .DataPropertyName = "PRCost",
            .ReadOnly = True,
            .Width = 65,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight},
            .SortMode = DataGridViewColumnSortMode.NotSortable
        }
        col.DefaultCellStyle.BackColor = Color.LightGray
        dgv.Columns.Add(col)


        ' New* costs (read-only)
        col = New DataGridViewTextBoxColumn() With {
            .Name = "NewNFCost",
            .HeaderText = "NF",
            .DataPropertyName = "NewNFCost",
            .ReadOnly = True,
            .Width = 70,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight},
            .SortMode = DataGridViewColumnSortMode.NotSortable
        }
        col.DefaultCellStyle.BackColor = NFCellColor
        dgv.Columns.Add(col)

        col = New DataGridViewTextBoxColumn() With {
            .Name = "NewWCCost",
            .HeaderText = "WC",
            .DataPropertyName = "NewWCCost",
            .ReadOnly = True,
            .Width = 70,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight},
            .SortMode = DataGridViewColumnSortMode.NotSortable
        }
        col.DefaultCellStyle.BackColor = WCCellColor
        dgv.Columns.Add(col)

        col = New DataGridViewTextBoxColumn() With {
            .Name = "NewPRCost",
            .HeaderText = "PR",
            .DataPropertyName = "NewPRCost",
            .ReadOnly = True,
            .Width = 70,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight},
            .SortMode = DataGridViewColumnSortMode.NotSortable
        }
        col.DefaultCellStyle.BackColor = PRCellColor
        dgv.Columns.Add(col)

        Dim grdHeader As String
        Select Case CaseTypeID
            Case 1 : grdHeader = "Adjusted NF"
            Case 2 : grdHeader = "Adjusted WC"
            Case 3 : grdHeader = "Adjusted PR"
            Case Else
                grdHeader = "Adjusted NF"
        End Select
        ' Ignore Previous Code
        'grdHeader = "Adjusted Bill"
        ' AdjustedPrice editable
        col = New DataGridViewTextBoxColumn() With {
            .Name = "AdjustedPrice",
            .HeaderText = grdHeader,
            .DataPropertyName = "AdjustedPrice",
            .ReadOnly = False,
            .Width = 100,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight},
            .SortMode = DataGridViewColumnSortMode.NotSortable
        }
        col.DefaultCellStyle.Format = "C2"
        dgv.Columns.Add(col)
        dgv.DataSource = dt

        ' Make sure AdjustedPrice is empty
        For Each r As DataGridViewRow In dgv.Rows
            If Not r.IsNewRow Then
                If r.Cells("AdjustedPrice").Value Is Nothing Then r.Cells("AdjustedPrice").Value = ""
            End If
        Next

        CalculateTotal()
    End Sub
    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
        ' Only apply for AdjustedPrice column
        If dgv.CurrentCell.ColumnIndex = dgv.Columns("AdjustedPrice").Index Then
            Dim tb As TextBox = TryCast(e.Control, TextBox)
            If tb IsNot Nothing Then
                ' Remove existing handler first to avoid adding multiple
                RemoveHandler tb.KeyPress, AddressOf AdjustedPrice_KeyPress
                ' Add handler
                AddHandler tb.KeyPress, AddressOf AdjustedPrice_KeyPress
            End If
        End If
    End Sub
    Private Sub AdjustedPrice_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tb As TextBox = DirectCast(sender, TextBox)
        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ControlChars.Back Then
            ' Allow digits and backspace
            Return
        ElseIf e.KeyChar = "."c Then
            ' Allow only one decimal point
            If tb.Text.Contains(".") Then e.Handled = True
        Else
            ' Block everything else
            e.Handled = True
        End If
    End Sub
    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim colName As String = dgv.Columns(e.ColumnIndex).Name

        If colName = "NewNFCost" OrElse colName = "NewWCCost" OrElse colName = "NewPRCost" Then
            Dim value As Object = dgv.Rows(e.RowIndex).Cells(colName).Value
            dgv.Rows(e.RowIndex).Cells("AdjustedPrice").Value = If(value Is Nothing, "", Math.Round(value, 2))
            CalculateTotal()
        End If
    End Sub

    Private Sub dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        If e.RowIndex >= 0 AndAlso dgv.Columns(e.ColumnIndex).Name = "AdjustedPrice" Then
            CalculateTotal()
        End If
    End Sub

    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        If dgv.Columns(e.ColumnIndex).Name = "AdjustedPrice" Then
            Dim val As Decimal
            If Decimal.TryParse(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value?.ToString(), val) Then
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = val
            Else
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = DBNull.Value
            End If
            CalculateTotal()
        End If
    End Sub

    Private Sub CalculateTotal()
        Dim total As Decimal = 0D

        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For

            Dim adjStr As String = If(row.Cells("AdjustedPrice").Value, "").ToString().Trim()
            If adjStr <> "" Then
                Dim adjVal As Decimal = 0
                Decimal.TryParse(adjStr, adjVal)
                total += adjVal
            Else
                Select Case CaseTypeID
                    Case 1 : total += Convert.ToDecimal(If(row.Cells("NFCost").Value, 0D))
                    Case 2 : total += Convert.ToDecimal(If(row.Cells("WCCost").Value, 0D))
                    Case 3 : total += Convert.ToDecimal(If(row.Cells("PRCost").Value, 0D))
                    Case Else
                        total += Convert.ToDecimal(If(row.Cells("NFCost").Value, 0D))
                End Select
            End If
        Next

        txtNewAmount.Text = total.ToString("N2")
    End Sub


    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Suppervisor As New SupperApproval
        Suppervisor.SupervisorID = gCurrentEmployee.UID
        Suppervisor.SupervisorName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        If PanelSuppervisorApproval.Visible Then
            Suppervisor = Validate_Supervisor(txtUserName, txtPassword)
            If Suppervisor.SupervisorName = "" Then Exit Sub
        End If

        If IsNumeric(txtNewAmount.Text) = False Or txtNewAmount.Text.Trim = "" Then
            MsgBox("Unable to process update." & vbCrLf & "Invalid New bill amount!")
            txtNewAmount.Focus()
            Exit Sub
        End If
        Dim msg As String
        If chkUpdateBillProcedures.Checked Then
            msg = "Please confirm you want to update procedures and bill Amount to " & txtNewAmount.Text & "?"
        Else
            msg = "Please confirm you want to update bill Amount to " & txtNewAmount.Text & "?"
        End If
        If MsgBox(msg, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If chkUpdateBillProcedures.Checked Then
            Dim columnToUpdate As String = ""
            Select Case CaseTypeID
                Case 1 : columnToUpdate = "NFCost"
                Case 2 : columnToUpdate = "WCCost"
                Case 3 : columnToUpdate = "PRCost"
                Case Else
                    columnToUpdate = "NFCost"
            End Select

            Dim updatedCount As Integer = 0
            For Each row As DataGridViewRow In dgv.Rows
                If row.IsNewRow Then Continue For

                Dim adjStr As String = If(row.Cells("AdjustedPrice").Value, "").ToString().Trim()
                If adjStr = "" Then Continue For

                Dim adjVal As Decimal = 0
                If Not Decimal.TryParse(adjStr, adjVal) Then Continue For
                If adjVal > 0 Then
                    Dim patientProcID As Integer = Convert.ToInt32(row.Cells("PatientProcedureID").Value)
                    Dim sqlUpdate As String =
                    $"UPDATE BillProcedures SET {columnToUpdate} = {adjVal.ToString(System.Globalization.CultureInfo.InvariantCulture)} WHERE PatientProcedureID = {patientProcID}"
                    gSQLUpdateData(sqlUpdate)
                End If
            Next
        End If
        SaveSuppervisorApprovalBorBillAmountChange = chkSaveApproval.Checked
        If Val(txtNewAmount.Text) > 0 Then
            gSQLUpdateData("Update Bills Set BillAmount = '" & Val(txtNewAmount.Text) & "' where BillID = " & BillID)
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillChanged, "Bill Amount Updated. Old Bill Amount: " & CalledBillAmountSI.Text & " New Bill Amount: " & Val(txtNewAmount.Text), SupervisorName)
            CalledBillAmountSI.Text = Val(txtNewAmount.Text)
            CalledBillBalanceSI.Text = Val(txtNewAmount.Text) - PaidAmount
        End If
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles PanelSuppervisorApproval.Paint

    End Sub

    Private Sub txtNewAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewAmount.KeyPress
        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ControlChars.Back Then
            Return
        ElseIf e.KeyChar = "."c Then
            If txtNewAmount.Text.Contains(".") Then e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub dgv_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgv.CurrentCellDirtyStateChanged
        If dgv.IsCurrentCellDirty Then
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        dgv.EndEdit()  ' Commit any pending edit
    End Sub
    Private Sub frmBillingChangeBillAmount_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        dgv.EndEdit()  ' Commit any pending edit
        dgv.CurrentCell = Nothing
    End Sub
    Private Sub dgv_Leave(sender As Object, e As EventArgs) Handles dgv.Leave
        ' Commit edit only when leaving the grid entirely
        If dgv.IsCurrentCellInEditMode Then
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
End Class