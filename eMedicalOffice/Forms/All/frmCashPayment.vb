Imports System.Reflection
Imports log4net

Public Class frmCashPayment
    Public ScheduleID As Long = 0
    Private ToBePaidAmount As Double = 0
    Private Discount As Integer
    Private PatientID As Long
    Private ProceduresCount As Integer
    Private ProcedureDateFrom As String
    Private ProcedureDateTo As String
    Private PaidAmount As Decimal = 0
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmCashPayment_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmCashPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PaidAmount = gSQLGetSingleValue("SELECT     sum(BillPayments.PaymentAmount) as PaidAmount FROM Bills INNER JOIN BillPayments ON Bills.BillID = BillPayments.BillID WHERE Bills.ScheduleID = " & ScheduleID)
        Load_Data()
        Load_Procedures()

        If PaidAmount > 0 Then
            If ToBePaidAmount <= PaidAmount Then
                PanelPaid.BackColor = Color.LimeGreen
                TextBoxAmount.BackColor = Color.LimeGreen
                LabelAmountPaid.Text = "Procedure(s) Paid In Full: " & PaidAmount.ToString("C")
            Else
                LabelAmountPaid.Text = "Partial Payment Collected: " & PaidAmount.ToString("C")
                PanelPaid.BackColor = Color.Honeydew
            End If
        Else
            LabelAmountPaid.Text = "Payment Required"
            PanelPaid.BackColor = Color.Wheat
        End If
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Try
            SQL = "SELECT     PaymentTypeID, Description FROM BillPaymentTypes WHERE     (ActiveInd = 1 and CashPaymentTypeInd=1)"
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxPaymentType.Items.Add(New ValueDescription(Reader("PaymentTypeID").ToString, Reader("Description").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Load_Procedures()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim TotalPrice As Double = 0
        Dim TotalDiscountPrice As Double = 0
        Dim R As Integer = 0
        SQL = "SELECT Schedule.ScheduleDateTime, PatientProcedures.PatientProcedureID, PatientProcedures.PatientID, Procedures.ProcName, Procedures.NFCost AS Price, Offices.CashDiscountPct /100 as Discount, Procedures.NFCost - Procedures.NFCost / 100 * Offices.CashDiscountPct AS DiscountPrice"
        SQL &= " FROM Schedule INNER JOIN "
        SQL &= "      PatientProcedures ON Schedule.ScheduleID = PatientProcedures.ScheduleID INNER JOIN"
        SQL &= "      Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN"
        SQL &= "      Offices ON PatientProcedures.OfficeID = Offices.OfficeID "
        SQL &= " WHERE Schedule.ScheduleID=" & ScheduleID
        SQL &= " ORDER BY Schedule.ScheduleDateTime"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        With FpSpreadProcedures.ActiveSheet
            .RowCount = 0
            Do Until Reader.Read = False
                PatientID = Val(Reader("PatientID").ToString)
                Discount = Val(Reader("Discount").ToString)
                If .RowCount = 0 Then
                    ProcedureDateFrom = FormatDateTime(Reader("ScheduleDateTime").ToString, DateFormat.ShortDate)
                End If
                .RowCount += 1
                .Cells(R, 0).Text = Reader("ProcName").ToString
                .Cells(R, 0).Tag = Reader("PatientProcedureID").ToString
                .Cells(R, 1).Text = Val(Reader("Price").ToString)
                TotalPrice += Val(Reader("Price").ToString)
                .Cells(R, 2).Text = Val(Reader("Discount").ToString)
                .Cells(R, 3).Text = Val(Reader("DiscountPrice").ToString)
                TotalDiscountPrice += Val(Reader("DiscountPrice").ToString)
                ProcedureDateTo = FormatDateTime(Reader("ScheduleDateTime").ToString, DateFormat.ShortDate)
                R += 1
            Loop

            ProceduresCount = R
            .RowCount += 1
            .Cells(R, 0).Text = "Total"
            .Rows(R).Font = New Font(FpSpreadProcedures.Font, FontStyle.Bold)
            .Rows(R).BackColor = Color.WhiteSmoke
            .Cells(R, 1).Text = TotalPrice
            .Cells(R, 3).Text = TotalDiscountPrice
            .Cells(R, 3).BackColor = Color.PaleGreen
        End With

        ToBePaidAmount = Math.Round(TotalDiscountPrice - PaidAmount, 2)
        If ToBePaidAmount < 0 Then ToBePaidAmount = 0
        TextBoxAmount.Text = ToBePaidAmount
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub TextBoxAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAmount.GotFocus
        TextBoxAmount.SelectAll()
    End Sub

    Private Sub TextBoxAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAmount.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, TextBoxAmount)
    End Sub

    Private Sub TextBoxAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAmount.LostFocus
        If IsNumeric(TextBoxAmount.Text) Then TextBoxAmount.Text = CDbl(TextBoxAmount.Text).ToString("c").Mid(2)
    End Sub

    Private Sub TextBoxAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxAmount.TextChanged
        ErrorProvider1.SetError(TextBoxAmount, "")
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ApprovedByID As Long = 0
        Dim ApprovedByName As String = ""
        Dim SQL As String = ""
        Dim R As Integer = 0
        Dim BillID As Long = 0
        Dim PatientProcedureID As Long = 0
        Dim Comments As String = ""
        Dim SattlementInd As Integer
        Dim FoundBillID As Integer

        If ComboBoxPaymentType.SelectedIndex = -1 Then
            MsgBox("The Payment Type should be selected.", MsgBoxStyle.Exclamation)
            ErrorProvider1.SetError(ComboBoxPaymentType, "The Payment Type should be selected.")
            ComboBoxPaymentType.Focus()
            Exit Sub
        End If
        If IsNumeric(TextBoxAmount.Text) = False Then
            MsgBox("Invalid Paid amount specified" & vbCrLf & "The amount should be numeric value only!", MsgBoxStyle.Exclamation)
            ErrorProvider1.SetError(TextBoxAmount, "Invalid Paid amount specified. The amount should be numeric value only!")
            TextBoxAmount.Focus()
            Exit Sub
        End If
        If Val(TextBoxAmount.Text) = 0 Then
            MsgBox("Invalid Paid amount specified" & vbCrLf & "The amount should be grater then 0!", MsgBoxStyle.Exclamation)
            ErrorProvider1.SetError(TextBoxAmount, "Invalid Paid amount specified. The amount should be grater then 0!")
            TextBoxAmount.Focus()
            Exit Sub
        End If

        If ToBePaidAmount = 0 And Val(TextBoxAmount.Text) > 0 Then
            If MsgBox("Attention!" & vbCrLf & vbCrLf & "The specified procedure(s) has been pais in full!" & vbCrLf & vbCrLf & "Please confirm the extra " & Val(TextBoxAmount.Text).ToString("c") & " payment?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        'If ToBePaidAmount < Val(TextBoxAmount.Text) Then
        '    MsgBox("Invalid Paid amount specified" & vbCrLf & "The amount can not be grater then calculated price!", MsgBoxStyle.Exclamation)
        '    ErrorProvider1.SetError(TextBoxAmount, "Invalid Paid amount specified" & vbCrLf & "The amount can not be grater then calculated price")
        '    TextBoxAmount.Focus()
        '    Exit Sub
        'End If
        TextBoxAmount.Text = CDbl(TextBoxAmount.Text).ToString("c").Mid(2)

        If ToBePaidAmount > CDbl(TextBoxAmount.Text) Then
            If gCurrentEmployee.PositionID > 3 Then
                frmSupervisorApproval.LabelMsg.Text = "The payment required amount: " & ToBePaidAmount.ToString("c") & "    Amount Offered: " & CDbl(TextBoxAmount.Text).ToString("c")
                If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    frmSupervisorApproval.Dispose()
                    Exit Sub
                End If
                ApprovedByID = frmSupervisorApproval.SupervisorID
                ApprovedByName = frmSupervisorApproval.SupervisorName
                frmSupervisorApproval.Dispose()
                Comments = "Cash Bill Approved By " & ApprovedByName
            Else
                If MsgBox("The payment required amount: " & ToBePaidAmount.ToString("c") & vbCrLf & "Amount Offered: " & CDbl(TextBoxAmount.Text).ToString("c") & vbCrLf & vbCrLf & "Are you approving this payment amount?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = vbNo Then
                    TextBoxAmount.Focus()
                    Exit Sub
                End If
            End If
            Comments = "Cash Bill Approved By " & gCurrentEmployee.FName & " " & gCurrentEmployee.LName
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tCashPaymentReceived, "Cash Payment Received " & CDbl(TextBoxAmount.Text).ToString("c"), "Approved by " & ApprovedByName)
            SattlementInd = 1
        Else
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tCashPaymentReceived, "Cash Payment Received " & CDbl(TextBoxAmount.Text).ToString("c"))
        End If

        If IsDate(ProcedureDateFrom) = False Then ProcedureDateFrom = FormatDateTime(Date.Today, DateFormat.ShortDate)
        If IsDate(ProcedureDateTo) = False Then ProcedureDateTo = FormatDateTime(Date.Today, DateFormat.ShortDate)

        Dim InsCompanyID As Long
        Dim ReaderIns As SqlClient.SqlDataReader
        Dim InsuranceCompanyID As Integer
        ReaderIns = gSQLGetDataReader("Select InsuranceCompanyID From Patients where PatientID =" & PatientID)
        If ReaderIns.HasRows Then
            ReaderIns.Read()
            InsuranceCompanyID = Val(ReaderIns("InsuranceCompanyID").ToString)
        End If
        ReaderIns.Close()

        FoundBillID = gSQLGetSingleValue("select BillID from Bills Where ScheduleID = " & ScheduleID)

        If FoundBillID = 0 Then
            SQL = "INSERT INTO Bills "
            SQL &= " (ScheduleID, PatientID, CaseTypeID, BillAmount, BillDiscountPct, BillProcedures, BillStatusID, BillDate, InsCompanyID, ServiceFrom, ServiceTo, PaidAmount ) "
            SQL &= " VALUES     (" & ScheduleID & ", " & PatientID & ",4," & ToBePaidAmount & "," & Discount & "," & ProceduresCount & "," & 3 & ",getdate(), " & InsuranceCompanyID & ", '" & ProcedureDateFrom & "', '" & ProcedureDateTo & "', " & CDbl(PaidAmount) + CDbl(TextBoxAmount.Text) & ") "
            gSQLUpdateData(SQL)
            BillID = gSQLGetSingleValue("Select IDENT_CURRENT('Bills')")
            With FpSpreadProcedures.ActiveSheet
                For R = 0 To .RowCount - 2
                    PatientProcedureID = Val(.Cells(R, 0).Tag)
                    SQL = "INSERT INTO BillProcedures (BillID, PatientProcedureID) VALUES(" & BillID & ", " & PatientProcedureID & ")"
                    gSQLUpdateData(SQL)
                Next
            End With
        Else
            SQL = " UPDATE Bills set PaidAmount = " & CDbl(PaidAmount) + CDbl(TextBoxAmount.Text) & " Where BillID = " & FoundBillID
            BillID = FoundBillID
        End If

        If SattlementInd = 0 Then
            SQL = "INSERT INTO BillPayments (BillID, CheckNumber, PaymentTypeID, PaymentDate, PaymentAmount) VALUES(" & BillID & ", 'CASH'," & CType(ComboBoxPaymentType.SelectedItem, ValueDescription).Value & " , getdate()," & CDbl(TextBoxAmount.Text) & ")"
        Else
            SQL = "INSERT INTO BillPayments (BillID, CheckNumber, PaymentTypeID, PaymentDate, PaymentAmount, NoteID, Note) VALUES(" & BillID & ", 'CASH'," & CType(ComboBoxPaymentType.SelectedItem, ValueDescription).Value & " , getdate()," & CDbl(TextBoxAmount.Text) & ", 1, 'Settlement')"
        End If

        gSQLUpdateData(SQL)

        frmCashReceipt.Setup_report(BillID)
        frmCashReceipt.ShowDialog(Me)
        frmCashReceipt.Dispose()
        ''' Process Bill
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ComboBoxPaymentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPaymentType.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxPaymentType, "")
    End Sub

    Private Sub FpSpreadProcedures_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadProcedures.CellClick

    End Sub

End Class