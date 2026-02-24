Public Class frmPatientsChart
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
        DateTimePickerFrom.Value = DateAdd(DateInterval.Month, -1, Now)
        DateTimePickerTo.Value = Now
        LoadingFlag = False
        ComboType1.SelectedIndex = 0
        Load_Chart()
    End Sub
    Private Sub Load_Data()
        ComboType.Items.Add("Daily")
        ComboType.Items.Add("Monthly")
        ComboType.SelectedIndex = 0

        cboStatus.Items.Add("All")
        cboStatus.Items.Add("Treated")
        cboStatus.SelectedIndex = 0

        Dim Reader As SqlClient.SqlDataReader
        With cboReferringOfficesID
            .Items.Clear()
            .Items.Add(New ValueDescription(0, "All"))
            .SelectedIndex = 0
            .DropDownHeight = 226
            .DropDownWidth = 400
            Application.DoEvents()
            Reader = gSQLGetDataReader("SELECT     OfficeID, OfficeName FROM         ReferringOffices ORDER BY OfficeName")
            If Reader Is Nothing Then GoTo ExitSub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)), Reader("OfficeName").ToString))
            Loop
        End With
ExitSub:
    End Sub

    Private Sub Load_ReferralChart()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        If ComboType.SelectedIndex = -1 Then Exit Sub
        Dim FromSelected As Boolean
        Dim C As Integer
        Dim Status As String
        If cboStatus.SelectedIndex > 0 Then
            Status = " AND PatientID in (SELECT PatientID FROM PatientProcedures WHERE ProcedureStatusID = 2) "
        End If
        Select Case ComboType.SelectedIndex
            Case 0
                SQL = "SELECT convert(varchar,InsertedDT,1) as DT, count(PatientID) AS Amt "
                If cboReferringOfficesID.SelectedIndex > 0 Then
                    SQL &= " FROM Patients inner join ReferringOffices on Patients.ReferringCompanyID = ReferringOffices.OfficeID Where 1=1 "
                Else
                    SQL &= " FROM Patients Where 1=1 "
                End If

                If DateTimePickerFrom.Checked Then
                    SQL &= " and InsertedDT >= '" & DateTimePickerFrom.Value.ToShortDateString & "' "
                End If
                If DateTimePickerTo.Checked Then
                    SQL &= " and InsertedDT <= '" & DateTimePickerTo.Value.ToShortDateString & "' "
                End If
                If cboReferringOfficesID.SelectedIndex > 0 Then
                    SQL &= " AND ReferringCompanyID = " & CType(cboReferringOfficesID.SelectedItem, ValueDescription).Value & " "
                End If
                SQL &= Status
                SQL &= " group by convert(varchar,InsertedDT,1) "
                SQL &= " order by convert(varchar,InsertedDT,1) "


            Case 1
                SQL = "SELECT cast(DATEPART(MONTH ,InsertedDT) as varchar(10)) + '/' + cast(DATEPART(YEAR ,InsertedDT) as varchar(10)) as DT, count(PatientID) AS Amt "
                If cboReferringOfficesID.SelectedIndex > 0 Then
                    SQL &= " FROM Patients inner join ReferringOffices on Patients.ReferringCompanyID = ReferringOffices.OfficeID Where 1=1 "
                Else
                    SQL &= " FROM Patients Where 1=1 "
                End If
                If DateTimePickerFrom.Checked Then
                    SQL &= " and InsertedDT >= '" & DateTimePickerFrom.Value.ToShortDateString & "' "
                End If
                If DateTimePickerTo.Checked Then
                    SQL &= " and InsertedDT <= '" & DateTimePickerTo.Value.ToShortDateString & "' "
                End If
                If cboReferringOfficesID.SelectedIndex > 0 Then
                    SQL &= " AND ReferringCompanyID = " & CType(cboReferringOfficesID.SelectedItem, ValueDescription).Value & " "
                End If
                SQL &= Status
                SQL &= " group by cast(DATEPART(MONTH ,InsertedDT) as varchar(10)) + '/' + cast(DATEPART(YEAR ,InsertedDT) as varchar(10)) "
                SQL &= " order by cast(DATEPART(MONTH ,InsertedDT) as varchar(10)) + '/' + cast(DATEPART(YEAR ,InsertedDT) as varchar(10))  "
        End Select


        Dim DS As DataSet
        'Reader = gSQLGetDataReader(SQL)
        DS = gSQLGetDataSet(SQL)
        Chart1.DataSource = DS.Tables(0)
        Chart1.Series(0).XValueMember = "DT"
        Chart1.Series(0).YValueMembers = "Amt"
        Chart1.DataBind()
        Chart1.Titles(0).Alignment = ContentAlignment.BottomCenter
        Chart1.Titles(0).Docking = DataVisualization.Charting.Docking.Bottom

        Dim dr As DataRow
        For Each dr In DS.Tables(0).Rows
            C = C + Val(dr.Item(1).ToString)
        Next
        Chart1.Titles(0).Text = "Total Patients Found: " & C

    End Sub
    Private Sub Load_PatientProceduresChart()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        If ComboType.SelectedIndex = -1 Then Exit Sub
        Dim FromSelected As Boolean
        Dim C As Integer
        Dim Status As String
        Select Case ComboType.SelectedIndex
            Case 0
                SQL = "SELECT convert(varchar,Schedule.ScheduleDateTime,1) as DT, count(PatientProcedures.PatientID) AS Amt from PatientProcedures inner join Schedule on PatientProcedures.ScheduleID = Schedule.ScheduleID inner join Patients on Patients.PatientID = PatientProcedures.PatientID Where 1=1 "

                If DateTimePickerFrom.Checked Then
                    SQL &= " and Schedule.ScheduleDateTime >= '" & DateTimePickerFrom.Value.ToShortDateString & "' "
                End If
                If DateTimePickerTo.Checked Then
                    SQL &= " and Schedule.ScheduleDateTime <= '" & DateTimePickerTo.Value.ToShortDateString & "' "
                End If
                If cboReferringOfficesID.SelectedIndex > 0 Then
                    SQL &= " AND ReferringCompanyID = " & CType(cboReferringOfficesID.SelectedItem, ValueDescription).Value & " "
                End If
                If cboStatus.SelectedIndex > 0 Then
                    SQL &= " AND ProcedureStatusID = 2 "
                End If
                SQL &= " group by convert(varchar,Schedule.ScheduleDateTime,1) "
                SQL &= " order by convert(varchar,Schedule.ScheduleDateTime,1) "


            Case 1
                SQL = "SELECT cast(DATEPART(MONTH ,Schedule.ScheduleDateTime) as varchar(10)) + '/' + cast(DATEPART(YEAR ,Schedule.ScheduleDateTime) as varchar(10)) as DT, count(PatientProcedures.PatientID) AS Amt  from PatientProcedures inner join Schedule on PatientProcedures.ScheduleID = Schedule.ScheduleID inner join Patients on Patients.PatientID = PatientProcedures.PatientID Where 1=1 "
                If DateTimePickerFrom.Checked Then
                    SQL &= " and Schedule.ScheduleDateTime >= '" & DateTimePickerFrom.Value.ToShortDateString & "' "
                End If
                If DateTimePickerTo.Checked Then
                    SQL &= " and Schedule.ScheduleDateTime <= '" & DateTimePickerTo.Value.ToShortDateString & "' "
                End If
                If cboReferringOfficesID.SelectedIndex > 0 Then
                    SQL &= " AND ReferringCompanyID = " & CType(cboReferringOfficesID.SelectedItem, ValueDescription).Value & " "
                End If
                If cboStatus.SelectedIndex > 0 Then
                    SQL &= " AND ProcedureStatusID = 2 "
                End If
                SQL &= " group by cast(DATEPART(MONTH ,Schedule.ScheduleDateTime) as varchar(10)) + '/' + cast(DATEPART(YEAR ,Schedule.ScheduleDateTime) as varchar(10)) "
                SQL &= " order by cast(DATEPART(MONTH ,Schedule.ScheduleDateTime) as varchar(10)) + '/' + cast(DATEPART(YEAR ,Schedule.ScheduleDateTime) as varchar(10))  "
        End Select


        Dim DS As DataSet
        'Reader = gSQLGetDataReader(SQL)
        DS = gSQLGetDataSet(SQL)
        Chart1.DataSource = DS.Tables(0)
        Chart1.Series(0).XValueMember = "DT"
        Chart1.Series(0).YValueMembers = "Amt"
        Chart1.DataBind()
        Chart1.Titles(0).Alignment = ContentAlignment.BottomCenter
        Chart1.Titles(0).Docking = DataVisualization.Charting.Docking.Bottom

        Dim dr As DataRow
        For Each dr In DS.Tables(0).Rows
            C = C + Val(dr.Item(1).ToString)
        Next
        Chart1.Titles(0).Text = $"Total {IIf(cboStatus.SelectedIndex > 0, " Completed ", "")} Procedures Found: " & C

    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Load_Chart()
    End Sub
    Private Sub Load_Chart()
        Cursor = Cursors.WaitCursor
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        If ComboType1.SelectedIndex = 0 Then
            Load_ReferralChart()
        Else
            Load_PatientProceduresChart()
        End If
        Cursor = Cursors.Default
        Cursor.Current = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub ComboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboType.SelectedIndexChanged
        If LoadingFlag Then Exit Sub
        If ComboType.SelectedIndex = -1 Then Exit Sub
        Load_Chart()
        cmdLoad.Focus()
    End Sub

    Private Sub DateTimePickerFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerFrom.TextChanged

    End Sub

    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerFrom.ValueChanged
        If LoadingFlag Then Exit Sub
        Load_Chart()
    End Sub

    Private Sub DateTimePickerTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerTo.ValueChanged
        If LoadingFlag Then Exit Sub
        Load_Chart()
    End Sub

    Private Sub cboInsuranceCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReferringOfficesID.SelectedIndexChanged
        If LoadingFlag Then Exit Sub
        Load_Chart()
        cmdLoad.Focus()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Chart1.Printing.PageSetup()
        Chart1.Printing.Print(True)
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        If LoadingFlag Then Exit Sub
        Load_Chart()
        cmdLoad.Focus()
    End Sub

    Private Sub ComboType1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboType1.SelectedIndexChanged
        If LoadingFlag Then Exit Sub
        If ComboType.SelectedIndex = -1 Then Exit Sub
        Load_Chart()
        cmdLoad.Focus()
    End Sub
End Class