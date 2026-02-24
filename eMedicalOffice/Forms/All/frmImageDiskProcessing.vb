Imports System.Reflection
Imports System.Runtime.InteropServices
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmImageDiskProcessing
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    <DllImport("shell32.dll", EntryPoint:="SHGetFolderPathW",
       CallingConvention:=CallingConvention.StdCall)>
    Private Shared Function SHGetFolderPath(ByVal hWnd As Integer,
                          ByVal nFolder As Integer, ByVal nToken As Integer,
                          ByVal dwFlags As Integer,
                          <MarshalAs(UnmanagedType.LPTStr)> ByVal lpszPath As String) As Boolean
    End Function

    Private Sub frmImageDiskProcessing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FpSpread1.ActiveSheet.RowCount = 0
        FpSpread2.ActiveSheet.RowCount = 0
        ToolStripMenuPrintCD.Visible = (gCDLabelPrinter.Trim <> "")
        Load_Data()
        If gPacsConnectionString = "" Then
            Button4.Visible = False
            BurnCDToolStripMenuItem.Visible = False
            ToolStripSeparator2.Visible = False
        End If
        'Load_Requests()
    End Sub

    Private loading As Boolean

    Private Sub Load_Data()
        loading = True
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        If gCurrentEmployee.PositionID < 3 Then
            DeleteInvoiceToolStripMenuItem.Visible = True
        End If
        cboStatus.Items.Add(New ValueDescription(0, "Show All"))
        cboStatus.Items.Add(New ValueDescription(1, "Incomplete"))
        cboStatus.Items.Add(New ValueDescription(2, "Complete"))
        cboStatus.SelectedIndex = 0
        cboRecepient.Items.Clear()
        SQL = "SELECT DISTINCT Recepient From ImageDiskRequests Order By Recepient"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboRecepient.Items.Add(StrConv(Reader("Recepient").ToString, VbStrConv.ProperCase))
        Loop
        Reader.Close() : Reader.Dispose()
        loading = False
        'Setup_Combo()
    End Sub

    Private Sub Setup_Combo(Optional ByVal CashInd As Boolean = False)
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("SELECT StatusID, Description FROM ImageDiskProcedureStatuses " & IIf(CashInd, " WHERE StatusID <> -1", "") & " Order by ShowOrder")
        If Reader Is Nothing Then Exit Sub
        Dim Arlst As New ArrayList
        Dim ArlstData As New ArrayList

        Do Until Reader.Read = False
            Arlst.Add(Reader("Description").ToString)
            ArlstData.Add(Reader("StatusID").ToString)
        Loop

        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
        cmbocell.Items = Arlst.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 3
        cmbocell.ImageList = ImageList1
        FpSpread2.ActiveSheet.Columns(1).CellType = cmbocell

    End Sub

    Private Sub Load_Requests()
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        Dim PName() As String
        FpSpread1.ActiveSheet.RowCount = 0
        FpSpread2.ActiveSheet.RowCount = 0
        txtAmount.Text = ""
        If loading = True Then Exit Sub
        SQL = "SELECT   ImageDiskRequests.CheckNumber, ImageDiskRequests.RequestTypeID, ImageDiskRequests.PaidAmount, ImageDiskRequests.InvoiceAmount , ImageDiskRequests.ID, ImageDiskRequests.RequestDT, ImageDiskRequestsStatuses.Description AS Status, ImageDiskRequests.StatusID, ImageDiskRequests.Recepient, Patients.FName+' '+Patients.LName as PName"
        SQL &= " FROM  ImageDiskRequests left outer JOIN ImageDiskRequestsStatuses ON ImageDiskRequests.StatusID = ImageDiskRequestsStatuses.StatusID LEFT OUTER JOIN Patients on ImageDiskRequests.PatientID=Patients.PatientID "
        SQL &= " WHERE ImageDiskRequests.OfficeID = " & gOfficeID & " "
        If txtrequestID.Text.Trim <> "" Then
            If IsNumeric(txtrequestID.Text) Then
                SQL &= " AND ImageDiskRequests.ID = " & Val(txtrequestID.Text.Trim)
            Else

                PName = Split(txtrequestID.Text.Trim.ToSafeSQLString(), " ")
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
        If cboStatus.SelectedIndex = 1 Then
            SQL &= " AND (ImageDiskRequests.StatusID = 0 or ImageDiskRequests.StatusID = 1 or ImageDiskRequests.StatusID = 2) "
        ElseIf cboStatus.SelectedIndex = 2 Then
            SQL &= " AND ImageDiskRequests.StatusID = 3 "
        End If
        If DateTimePickerFrom.Checked Then
            SQL &= " AND datediff(d,ImageDiskRequests.RequestDT,'" & DateTimePickerFrom.Value.ToShortDateString & "') <= 0 "
        End If
        If DateTimePickerTo.Checked Then
            SQL &= " AND datediff(d,ImageDiskRequests.RequestDT,'" & DateTimePickerTo.Value.ToShortDateString & "') >= 0 "
        End If
        If cboRecepient.Text <> "" Then
            SQL &= " AND Recepient = '" & cboRecepient.Text.ToSafeSQLString() & "'"
        End If
        SQL &= " ORDER BY ImageDiskRequests.ID desc"
        Reader = gSQLGetDataReader(SQL)
        Dim R As Integer = 0
        With FpSpread1.ActiveSheet
            .RowCount = 0
            On Error GoTo 0
            Do Until Reader.Read = False
                R = R + 1
                .RowCount = R
                .Cells(R - 1, 0).Text = Reader("ID").ToString
                .Cells(R - 1, 1).Text = CDate(Reader("RequestDT").ToString).ToString("MM/dd/yyyy")
                .Cells(R - 1, 2).Text = Reader("Recepient").ToString
                .Cells(R - 1, 2).Tag = Reader("RequestTypeID").ToString
                .Cells(R - 1, 3).Text = Reader("PName").ToString
                .Cells(R - 1, 4).Text = Reader("InvoiceAmount").ToString
                .Cells(R - 1, 4).Tag = Val(Reader("PaidAmount").ToString)
                .Cells(R - 1, 5).Text = Reader("Status").ToString
                .Cells(R - 1, 5).Tag = Reader("StatusID").ToString
                .Cells(R - 1, 6).Text = Val(Reader("PaidAmount").ToString).ToString("c")
                .Cells(R - 1, 7).Text = Reader("CheckNumber").ToString
                If Val(Reader("RequestTypeID").ToString) = 3 Then
                    .Cells(R - 1, 0).ForeColor = Color.Blue
                    .Cells(R - 1, 1).ForeColor = Color.Blue
                    .Cells(R - 1, 2).ForeColor = Color.Blue
                    .Cells(R - 1, 3).ForeColor = Color.Blue
                    .Cells(R - 1, 4).ForeColor = Color.Blue
                    .Cells(R - 1, 5).ForeColor = Color.Blue
                End If
                Select Case Val(Reader("StatusID").ToString)
                    Case 3
                        .Cells(R - 1, 5).ForeColor = Color.Green
                End Select

            Loop
            If .RowCount > 0 Then
                .SetActiveCell(0, 0)
                Setup_Combo(.Cells(0, 2).Text = "Cash")
                Load_Procedures(.GetTag(0, 5))
                If .Cells(0, 2).Text = "Cash" Then
                    txtAmount.Text = .Cells(0, 4).Tag
                    txtAmount.Enabled = False
                End If
            End If
        End With
    End Sub

    Private Sub Load_Procedures(ByVal StatusID As Integer)
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        Dim ID As Long
        txtAmount.Text = ""
        FpSpread2.ActiveSheet.RowCount = 0
        If FpSpread1.ActiveSheet.ActiveCell Is Nothing Then Exit Sub
        ID = Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text)
        SQL = "SELECT     ImageDiskProcedures.ID, Procedures.ProcName, ImageDiskProcedureStatuses.Description AS Status, ImageDiskProcedures.StatusID"
        SQL &= " FROM         ImageDiskProcedures INNER JOIN PatientProcedures ON ImageDiskProcedures.PatientProcedureID = PatientProcedures.PatientProcedureID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN ImageDiskProcedureStatuses ON ImageDiskProcedures.StatusID = ImageDiskProcedureStatuses.StatusID "
        SQL &= " WHERE ImageDiskProcedures.RequestID  = " & ID
        Reader = gSQLGetDataReader(SQL)
        Dim R As Integer = 0
        With FpSpread2.ActiveSheet
            .RowCount = 0
            Do Until Reader.Read = False
                R = R + 1
                .RowCount = R
                .SetText(R - 1, 0, Reader("ProcName").ToString)
                .SetValue(R - 1, 1, Reader("StatusID").ToString)
                .SetTag(R - 1, 0, Reader("ID").ToString)
                If StatusID = 3 Then
                    .Cells(R - 1, 1).Locked = True
                End If
                Select Case Val(Reader("StatusID").ToString)
                    Case -1
                        .Cells(R - 1, 1).ForeColor = Color.Red
                    Case 0
                        .Cells(R - 1, 1).ForeColor = Color.Black
                    Case 1
                        .Cells(R - 1, 1).ForeColor = Color.Green
                End Select
            Loop
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Load_Requests()
        ErrorProvider1.SetError(lblError1, "")
        ErrorProvider1.SetError(lblError2, "")
        ErrorProvider1.SetError(txtAmount, "")
    End Sub

    Private Sub FpSpread1_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellClick
        Dim Rp As New FarPoint.Win.Spread.EnterCellEventArgs(e.View, e.Row, e.Column)
        FpSpread1_EnterCell(sender, Rp)
    End Sub

    Private Sub FpSpread1_EnterCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EnterCellEventArgs) Handles FpSpread1.EnterCell
        FpSpread1.ActiveSheet.SetActiveCell(e.Row, e.Column)
        Setup_Combo(FpSpread1.ActiveSheet.Cells(e.Row, 2).Text = "Cash")
        Load_Procedures(FpSpread1.ActiveSheet.Cells(e.Row, 5).Tag)
        ErrorProvider1.SetError(lblError1, "")
        ErrorProvider1.SetError(lblError2, "")
        txtAmount.Text = FpSpread1.ActiveSheet.Cells(e.Row, 4).Tag
        If FpSpread1.ActiveSheet.Cells(e.Row, 5).Tag = 3 Then
            If gCurrentEmployee.PositionID > 2 Then
                ButtonCompleted.Enabled = False
                txtAmount.Enabled = False
            Else
                ButtonCompleted.Enabled = True
                txtAmount.Enabled = True
            End If
        Else
            ButtonCompleted.Enabled = True
            txtAmount.Enabled = True
        End If
        If FpSpread1.ActiveSheet.Cells(e.Row, 2).Text = "Cash" Then
            txtAmount.Enabled = False
        End If
        Select Case Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 2).Tag)
            Case 1, 2, 4
                PrintReceiptToolStripMenuItem.Text = "Print Receipt"
            Case Else
                PrintReceiptToolStripMenuItem.Text = "Print Cash Receipt"
        End Select
        If (FpSpread1.ActiveSheet.Cells(e.Row, 4).Tag) > 0 Then
            PrintReceiptToolStripMenuItem.Enabled = True
        Else
            PrintReceiptToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub txtAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.GotFocus
        txtAmount.SelectAll()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, txtAmount, True)
    End Sub

    Private Sub txtCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCompleted.Click
        Dim R As Integer = 0
        Dim Ret As String = ""
        Dim ID As Integer
        Dim StatusID As Integer
        Dim Confirmed As Boolean
        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "No Request selected for processing.", MsgBoxStyle.Exclamation)
            ErrorProvider1.SetError(lblError1, "No Request selected for processing.")
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveCell Is Nothing Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "No Request selected for processing.", MsgBoxStyle.Exclamation)
            ErrorProvider1.SetError(lblError1, "No Request selected for processing.")
            Exit Sub
        End If
        If FpSpread2.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "No Procedure(s) selected for processing.", MsgBoxStyle.Exclamation)
            ErrorProvider1.SetError(lblError2, "No Procedure(s) selected for processing.")
            Exit Sub
        End If
        With FpSpread2.ActiveSheet
            For R = 0 To .RowCount - 1
                If .Cells(R, 1).Value = 0 Then
                    MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "Incomplete procedure(s) status information." & vbCrLf & "The procedure status should be Completed or Canceled.", MsgBoxStyle.Exclamation)
                    .SetActiveCell(R, 1)
                    FpSpread1.EditMode = True
                    FpSpread1.Focus()
                    ErrorProvider1.SetError(lblError2, "Incomplete procedure(s) status information. The procedure status should be Completed or Canceled.")
                    Exit Sub
                End If
            Next
        End With

        If FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 2).Text <> "Cash" Then
            If txtCheckNumber.Text = "" Then
                MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "Check Number is missing for the check payment!", MsgBoxStyle.Exclamation)
                txtCheckNumber.Focus()
                Exit Sub
            End If

            If txtAmount.Text.Trim = "" Then
                MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "Amount paid should be specified.", MsgBoxStyle.Exclamation)
                ErrorProvider1.SetError(txtAmount, "Amount paid should be specified.")
                txtAmount.Focus()
                Exit Sub
            End If
            If IsNumeric(txtAmount.Text) = False Then
                MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "Invalid amount paid specified.", MsgBoxStyle.Exclamation)
                ErrorProvider1.SetError(txtAmount, "Amount paid should be specified.")
                txtAmount.Focus()
                Exit Sub
            End If
            If CDbl(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Text) <> CDbl(txtAmount.Text) Then
                If MsgBox("Attention" & vbCrLf & vbCrLf & "The Invoiced Amount: " & FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Text & vbCrLf & vbCrLf & "Amount Paid: " & CDbl(txtAmount.Text).ToString("c") & vbCrLf & vbCrLf & "Please confirm...", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    txtAmount.Focus()
                    Exit Sub
                End If
                Confirmed = True
            End If

        End If
        If Confirmed = False Then
            If MsgBox("Plese confirm the Image Disk completion.", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 5).Text = "Complete"
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 5).Tag = 3
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 5).ForeColor = Color.Green
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Tag = Val(txtAmount.Text)
        Dim PaymentDate As String
        If Val(txtAmount.Text) > 0 Then
            gSQLUpdateData("Update ImageDiskRequests SET StatusID = 3, StatusDT = GETDATE(), StatusBy = " & gCurrentEmployee.EmpID & ", CheckNumber='" & txtCheckNumber.Text.ToSafeSQLString() & "', PaidAmount = " & Val(txtAmount.Text) & " WHERE ID = " & Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text))
            gSQLUpdateData("Update ImageDiskRequests SET PaymentDate= GETDATE() WHERE ID = " & Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text) & " AND PaymentDate  IS NULL")
        Else
            gSQLUpdateData("Update ImageDiskRequests SET StatusID = 3, StatusDT = GETDATE(), StatusBy = " & gCurrentEmployee.EmpID & ", PaidAmount = " & Val(txtAmount.Text) & " WHERE ID = " & Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text))
        End If

        With FpSpread2.ActiveSheet
            For R = 0 To .RowCount - 1
                ID = Val(.GetTag(R, 0))
                StatusID = Val(.GetValue(R, 1))
                gSQLUpdateData("Update ImageDiskProcedures SET StatusID = " & StatusID & " WHERE ID = " & ID)
                .Cells(R, 1).Locked = True
            Next
        End With
        If gCurrentEmployee.PositionID > 2 Then ButtonCompleted.Enabled = False
        If gCurrentEmployee.PositionID > 2 Then txtAmount.Enabled = False
        Select Case Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 2).Tag)
            Case 2, 4
                frmImageDiskCompleteLetter.Setup_report(Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text))
                frmImageDiskCompleteLetter.ShowDialog(Me)
                frmImageDiskCompleteLetter.Dispose()
        End Select
        Load_Requests()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtrequestID.Text = ""
        cboStatus.SelectedIndex = 1
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        FpSpread1.ActiveSheet.RowCount = 0
        FpSpread2.ActiveSheet.RowCount = 0
        txtAmount.Text = ""
        cboRecepient.Text = ""
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        ErrorProvider1.SetError(txtAmount, "")
    End Sub

    Private Sub FpSpread2_ComboSelChange(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread2.ComboSelChange
        ErrorProvider1.SetError(lblError2, "")
        Select Case FpSpread2.ActiveSheet.Cells(e.Row, 1).Value
            Case -1
                FpSpread2.ActiveSheet.Cells(e.Row, 1).ForeColor = Color.Red
            Case 0
                FpSpread2.ActiveSheet.Cells(e.Row, 1).ForeColor = Color.Black
            Case 1
                FpSpread2.ActiveSheet.Cells(e.Row, 1).ForeColor = Color.Green
        End Select

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub FpSpread2_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread2.CellClick

    End Sub

    Private Sub cboRecepient_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRecepient.KeyUp
        gComboboxAutoComplete(cboRecepient, e, True)
    End Sub

    Private Sub cboRecepient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRecepient.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTools.Click
        'frmImageDiskReport.ShowDialog(Me)
        'frmImageDiskReport.Dispose()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonEmvelope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtrequestID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtrequestID.KeyDown
        If e.KeyCode = 13 Then
            Button1_Click(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub txtrequestID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrequestID.KeyPress

    End Sub

    Private Sub txtrequestID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrequestID.TextChanged

    End Sub

    Private Sub ButtonDeleteInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PrintInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoiceToolStripMenuItem.Click
        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to print. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveRowIndex < 0 Then
            MsgBox("Unable to print. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Select Case Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 2).Tag)
            Case 1, 2, 4
                frmImageDiskInvoice.Setup_report(Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text))
                frmImageDiskInvoice.ShowDialog(Me)
                frmImageDiskInvoice.Dispose()
            Case Else   ' Cash
                MsgBox("Unable to print invoice for the cash order.", MsgBoxStyle.Critical)
                Exit Sub
        End Select
    End Sub

    Private Sub PrintReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReceiptToolStripMenuItem.Click
        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to print. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveRowIndex < 0 Then
            MsgBox("Unable to print. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Select Case Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 2).Tag)
            Case 1, 2, 4
                frmImageDiskCompleteLetter.Setup_report(Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text))
                frmImageDiskCompleteLetter.ShowDialog(Me)
                frmImageDiskCompleteLetter.Dispose()
            Case Else
                frmImageDiskCashReceipt.Setup_report(Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text))
                frmImageDiskCashReceipt.ShowDialog(Me)
                frmImageDiskCashReceipt.Dispose()

        End Select
    End Sub

    Private Sub PrintInvoiceEnvilopeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoiceEnvilopeToolStripMenuItem.Click
        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to print. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveRowIndex < 0 Then
            MsgBox("Unable to print. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim RequestID As Long = Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text)
        frmImageDiskInvoiceEnvelope.Setup_report(RequestID)
        frmImageDiskInvoiceEnvelope.ShowDialog(Me)
        frmImageDiskInvoiceEnvelope.Dispose()
    End Sub

    Private Sub PrintCDEnvelopeLabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCDEnvelopeLabelToolStripMenuItem.Click
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim InvoiceID As String
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to print CD Envelop Label. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveRowIndex < 0 Then
            MsgBox("Unable to print CD Envelop Label. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        InvoiceID = Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text)

        Try
            If gCDEnvelopeLabelType = 1 Then
                CR = New rptImageDiskEnvelopeLabel
            Else
                CR = New rptCDShippingLabel
            End If

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("CDInvoiceID", InvoiceID)
            If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
            'Set Label Size to Priter Paper Size
            Dim doctoprint As New System.Drawing.Printing.PrintDocument()
            doctoprint.PrinterSettings.PrinterName = gPrinterFileLabel
            CR.PrintOptions.PaperSize = doctoprint.DefaultPageSettings.PaperSize.RawKind
            ''''''''''''''''''''''''

            CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
            CR.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub DeleteInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteInvoiceToolStripMenuItem.Click
        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to print. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveRowIndex < 0 Then
            MsgBox("Unable to print. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the" & vbCrLf & "Invoice #: " & FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text & vbCrLf & "Patient: " & FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 2).Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLUpdateData("DELETE FROM ImageDiskRequests Where ID = " & Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text))
        gSQLUpdateData("DELETE FROM ImageDiskProcedures Where RequestID = " & Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text))
        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub Button4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim clsBurn As CDBurnClass
        Try
            clsBurn = New CDBurnClass
        Catch ex As Exception
            MsgBox("Unable to Record CD. " & ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
        Dim Ret As String = clsBurn.Check_CDBurner()
        If Ret <> "" Then
            MsgBox("Unable to Record CD. " & Ret, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If gPacsConnectionString = "" Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "Incomplete CD Burner Setup. Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "No Request selected for processing.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveRowIndex < 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "No Request selected for processing.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If frmCDBurn.Load_Data(Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text)) = True Then
            frmCDBurn.ShowDialog(Me)
            frmCDBurn.Dispose()
        Else
            frmCDBurn.Dispose()
        End If
    End Sub

    Private Sub ButtonTools_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonTools.MouseDown
        ContextMenuStripTools.Show(ButtonTools, e.Location)
    End Sub

    Private Sub BurnCDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BurnCDToolStripMenuItem.Click
        Button4_Click_2(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuPrintCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuPrintCD.Click
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim InvoiceID As String
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If FpSpread1.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to print CD Label. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If FpSpread1.ActiveSheet.ActiveRowIndex < 0 Then
            MsgBox("Unable to print CD Label. No request selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        InvoiceID = Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text)

        Try
            CR = New rptImageCDDisk

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("RequestID", InvoiceID)
            If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gCDLabelPrinter

            CR.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

End Class