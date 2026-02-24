Public Class frmPaymentsChart
    Private LoadingFlag As Boolean
    Private Sub frmPaymentsChart_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        SaveSetting(Application.ProductName, "Settings", "PaymentChartDateFromChecked", DateTimePickerFrom.Checked)
        SaveSetting(Application.ProductName, "Settings", "PaymentChartDateToChecked", DateTimePickerTo.Checked)
        If ComboType.SelectedIndex = -1 Then
            SaveSetting(Application.ProductName, "Settings", "PaymentChartType", 0)
        Else
            SaveSetting(Application.ProductName, "Settings", "PaymentChartType", ComboType.SelectedIndex)
        End If
        SaveSetting(Application.ProductName, "Settings", "PaymentChartDateFrom", DateTimePickerFrom.Value)
        SaveSetting(Application.ProductName, "Settings", "PaymentChartDateTo", DateTimePickerTo.Value)

    End Sub

    Private Sub frmPaymentsChart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadingFlag = True
        Load_Data()
        gWindow_Settings(Me, ReadWrite.sRead)
        DateTimePickerFrom.Value = GetSetting(Application.ProductName, "Settings", "PaymentChartDateFrom", DateAdd(DateInterval.Month, -1, Now))
        DateTimePickerTo.Value = GetSetting(Application.ProductName, "Settings", "PaymentChartDateTo", Now)
        DateTimePickerFrom.Checked = GetSetting(Application.ProductName, "Settings", "PaymentChartDateFromChecked", True)
        DateTimePickerTo.Checked = GetSetting(Application.ProductName, "Settings", "PaymentChartDateToChecked", True)
        ComboType.SelectedIndex = GetSetting(Application.ProductName, "Settings", "PaymentChartType", 0)
        LoadingFlag = False
        Load_Chart()
    End Sub
    Private Sub Load_Data()
        ComboType.Items.Add("Daily Payments")
        ComboType.Items.Add("Weekly Payments")
        ComboType.Items.Add("Monthly Payments")
        ComboType.Items.Add("Yearly Payments")
        Dim Reader As SqlClient.SqlDataReader
        With cboInsuranceCompanyID
            .Items.Clear()
            .Items.Add(New ValueDescription(0, "All"))
            .Items.Add(New ValueDescription(-1, "-----------------------------------------INSURANCE GROUPS-----------------------------------------"))
            .SelectedIndex = 0
            .DropDownHeight = 226
            .DropDownWidth = 400
            Application.DoEvents()
            Reader = gSQLGetDataReader("SELECT DISTINCT  GroupID, Description FROM InsuranceCompaniesGroups ORDER BY Description")
            If Reader Is Nothing Then GoTo ExitSub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("GroupID").ToString)), Reader("Description").ToString & " - Group", "0"))
            Loop
            If .Items.Count > 0 Then
                .Items.Add(New ValueDescription(-1, "--------------------------------------INSURANCE COMPANIES--------------------------------------"))
            End If
            Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies ORDER BY CompanyName")
            If Reader Is Nothing Then GoTo ExitSub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString, "1"))
            Loop
        End With
        Reader.Close() : Reader.Dispose()

ExitSub:
    End Sub

    Private Sub Load_Chart()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        If ComboType.SelectedIndex = -1 Then Exit Sub
        Dim FromSelected As Boolean
        Select Case ComboType.SelectedIndex
            Case 0
                SQL = "SELECT convert(varchar,PaymentDate,1) as DT, SUM(PaymentAmount) AS Amt "
                SQL &= " FROM BillPayments inner join Bills on BillPayments.BillID = Bills.BillID Where 1=1 "
                If DateTimePickerFrom.Checked Then
                    SQL &= " and PaymentDate >= '" & DateTimePickerFrom.Value.ToShortDateString & "' "
                End If
                If DateTimePickerTo.Checked Then
                    SQL &= " and PaymentDate <= '" & DateTimePickerTo.Value.ToShortDateString & "' "
                End If
                If cboInsuranceCompanyID.SelectedIndex > 0 Then
                    If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value1 = "0" Then
                        SQL &= " AND Bills.InsCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & ") "
                    Else
                        SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
                    End If
                End If
                SQL &= " group by convert(varchar,PaymentDate,1) "
                SQL &= " order by convert(varchar,PaymentDate,1) "

            Case 1
                SQL = "SELECT DATEPART( week, PaymentDate ) as DT, SUM(PaymentAmount) AS Amt "
                SQL &= " FROM BillPayments inner join Bills on BillPayments.BillID = Bills.BillID Where 1=1 "
                If DateTimePickerFrom.Checked Then
                    SQL &= " and PaymentDate >= '" & DateTimePickerFrom.Value.ToShortDateString & "' "
                End If
                If DateTimePickerTo.Checked Then
                    SQL &= " and PaymentDate <= '" & DateTimePickerTo.Value.ToShortDateString & "' "
                End If
                If cboInsuranceCompanyID.SelectedIndex > 0 Then
                    If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value1 = "0" Then
                        SQL &= " AND Bills.InsCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & ") "
                    Else
                        SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
                    End If
                End If
                SQL &= " group by DATEPART( week, PaymentDate ) "
                SQL &= " order by DATEPART( week, PaymentDate ) "

            Case 2
                SQL = " SELECT cast(DATEPART(MONTH ,PaymentDate) as varchar(10)) + '/' + cast(DATEPART(YEAR ,PaymentDate) as varchar(10)) as DT, SUM(PaymentAmount) AS Amt "
                SQL &= " FROM BillPayments inner join Bills on BillPayments.BillID = Bills.BillID Where 1=1 "
                If DateTimePickerFrom.Checked Then
                    SQL &= " and PaymentDate >= '" & DateTimePickerFrom.Value.ToShortDateString & "' "
                End If
                If DateTimePickerTo.Checked Then
                    SQL &= " and PaymentDate <= '" & DateTimePickerTo.Value.ToShortDateString & "' "
                End If
                If cboInsuranceCompanyID.SelectedIndex > 0 Then
                    If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value1 = "0" Then
                        SQL &= " AND Bills.InsCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & ") "
                    Else
                        SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
                    End If
                End If
                SQL &= " group by cast(DATEPART(MONTH ,PaymentDate) as varchar(10)) + '/' + cast(DATEPART(YEAR ,PaymentDate) as varchar(10)) "
                SQL &= " order by cast(DATEPART(MONTH ,PaymentDate) as varchar(10)) + '/' + cast(DATEPART(YEAR ,PaymentDate) as varchar(10))  "
            Case 3
                SQL &= " SELECT DATEPART(YEAR ,PaymentDate)  as DT, SUM(PaymentAmount) AS Amt "
                SQL &= " FROM BillPayments inner join Bills on BillPayments.BillID = Bills.BillID Where 1=1 "
                If DateTimePickerFrom.Checked Then
                    SQL &= " and PaymentDate >= '" & DateTimePickerFrom.Value.ToShortDateString & "' "
                End If
                If DateTimePickerTo.Checked Then
                    SQL &= " and PaymentDate <= '" & DateTimePickerTo.Value.ToShortDateString & "' "
                End If
                If cboInsuranceCompanyID.SelectedIndex > 0 Then
                    If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value1 = "0" Then
                        SQL &= " AND Bills.InsCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & ") "
                    Else
                        SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
                    End If
                End If
                SQL &= " group by DATEPART(YEAR ,PaymentDate) "
                SQL &= " order by DATEPART(YEAR ,PaymentDate) "
        End Select

        Dim DS As DataSet
        'Reader = gSQLGetDataReader(SQL)
        DS = gSQLGetDataSet(SQL)
        Chart1.DataSource = DS.Tables(0)
        Chart1.Series(0).XValueMember = "DT"
        Chart1.Series(0).YValueMembers = "Amt"
        Chart1.DataBind()


    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Load_Chart()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub ComboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboType.SelectedIndexChanged
        If LoadingFlag Then Exit Sub
        If ComboType.SelectedIndex = -1 Then Exit Sub
        Load_Chart()
    End Sub

    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerFrom.ValueChanged
        If LoadingFlag Then Exit Sub
        Load_Chart()
    End Sub

    Private Sub DateTimePickerTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerTo.ValueChanged
        If LoadingFlag Then Exit Sub
        Load_Chart()
    End Sub

    Private Sub cboInsuranceCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceCompanyID.SelectedIndexChanged
        If LoadingFlag Then Exit Sub
        If cboInsuranceCompanyID.SelectedIndex > -1 Then
            If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value = -1 Then
                cboInsuranceCompanyID.SelectedIndex = 0
            End If
        End If
        Load_Chart()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Chart1.Printing.PageSetup()
        Chart1.Printing.Print(True)
    End Sub
End Class