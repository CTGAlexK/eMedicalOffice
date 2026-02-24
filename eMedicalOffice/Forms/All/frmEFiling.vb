Imports System.Data.SqlClient
Imports System.IO
Imports System.Text

Public Class frmEFiling
    Public SelectedFileName As String
    Public BillIds As String()
    Dim BillIndex As Integer = 0
    Dim SelectedFolder As String = ""
    Private Sub ShowPayer(PayerId As String)
        If PayerId.Trim.Length = 0 Then Return
        Filter_Payers("")
        For Each item As ListViewItem In ListView1.Items
            If item.SubItems(1).Text.ToUpper = PayerId Then
                item.Selected = True
                item.EnsureVisible()
                Exit For
            End If
        Next
    End Sub
    Private Sub frmSelectPayers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelInfo.Top = 150
        Filter_Payers("")
        TimerLoad.Enabled = True
        ProgressBar1.Value = 0
        ListView1.HideSelection = True
        CheckBox1.Visible = BillIds.Count > 1
    End Sub
    Public Sub Filter_Payers(Filter As String)
        Dim FilteredList As List(Of Payer) = New List(Of Payer)
        ListView1.SuspendLayout()
        ListView1.Items.Clear()
        If Filter.Length = 0 Then
            FilteredList.AddRange(PayersList)
        Else
            If RadioButton1.Checked Then
                FilteredList = PayersList.Where(Function(x) x.PayerName.StartsWith(Filter, StringComparison.InvariantCultureIgnoreCase) Or x.PayerId.Equals(Filter, StringComparison.InvariantCultureIgnoreCase)).ToList()
            Else
                FilteredList = PayersList.Where(Function(x) x.States.ToUpper.Contains(Filter.ToUpper)).ToList()
            End If
        End If
        For Each item As Payer In FilteredList
            Dim lvi As ListViewItem = ListView1.Items.Add(item.PayerName)
            lvi.SubItems.Add(item.PayerId)
            lvi.SubItems.Add(item.States)
            lvi.SubItems.Add(item.Professional)
            lvi.SubItems.Add(item.Institutional)
            lvi.SubItems.Add(item.PharmacyRx)
            lvi.SubItems.Add(item.WorkComp)
            lvi.SubItems.Add(item.Automotive)
            lvi.SubItems.Add(item.EOB)
        Next
        ListView1.ResumeLayout()
        LastSelectedIndex = -1
        TextBox1.Focus()
        If ListView1.Items.Count = 1 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            LastSelectedIndex = 0
            ListView1.Focus()
        End If

    End Sub
    Private Sub ShowBill(billid As Integer)
        If CheckBox1.Checked = False Then PanelInfo.Top = 21
        lblBillId.Text = ""
        lblType.Text = ""
        lblPatientId.Text = ""
        lblinsurance.Text = ""
        Application.DoEvents()
        Dim reader As SqlDataReader = gSQLGetDataReader("select PayerId, billid, CaseTypes.Abbreviation, Patients.PatientID, rtrim(Patients.FName) + ' ' + rtrim(Patients.LName) as PatName , InsuranceCompanies.CompanyName from Bills inner join Patients on bills.PatientID = patients.PatientID inner join CaseTypes on bills.CaseTypeID = CaseTypes.CaseTypeID left outer join InsuranceCompanies on bills.InsCompanyID = InsuranceCompanies.CompanyID where billid = " & billid)
        If reader.HasRows Then
            reader.Read()
            lblBillId.Text = reader("billid").ToString
            lblType.Text = reader("Abbreviation").ToString
            lblPatientId.Text = reader("PatientID").ToString
            lblinsurance.Text = reader("CompanyName").ToString
            If reader("PayerId").ToString.Trim.Length > 0 And CheckBox1.Checked = False Then
                RadioButton1.Checked = True
                Filter_Payers(reader("PayerId").ToString.Trim)
                If ListView1.Items.Count > 0 Then
                    lblWait.Text = ("Select payer for bill: " & billid).ToUpper
                Else
                    Filter_Payers("")
                End If
            Else
                Filter_Payers("")
            End If
        End If

        lblNumber.Text = BillIndex + 1 & " of " & BillIds.Count
        If CheckBox1.Checked = False Then
            For i As Decimal = 31 To 0 Step -0.5
                PanelInfo.Top = i
                PanelInfo.Refresh()
            Next
        Else
            PanelInfo.Top = 0
            Application.DoEvents()
        End If

        reader.Close()
    End Sub
    Dim DoNotPrompt As Boolean = False
    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to continue." & vbCrLf & vbCrLf & "Please select a payer.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Directory.Exists(SelectedFolder) = False Then
            MsgBox("Invalid output folder. Please select a valid output folder and try again...", MsgBoxStyle.Exclamation, "Oops")
            btnChangePath_Click(Nothing, Nothing)
        End If
        If CheckBox1.Checked And DoNotPrompt = False Then
            If MsgBox("You have selected " & vbCrLf & vbCrLf & ListView1.SelectedItems(0).Text & vbCrLf & vbCrLf & "as a payer for all " & BillIds.Count & " bills." & vbCrLf & vbCrLf & "Continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirm...") = MsgBoxResult.No Then
                CheckBox1.Checked = False
                DoNotPrompt = False
                Return
            End If
            DoNotPrompt = True
        End If


        lblWait.Visible = True
        lblWait.Refresh()

        Dim selectedPayerId As String = ListView1.SelectedItems(0).SubItems(1).Text.Replace("'", "")
        Dim selectedPayerName As String = ListView1.SelectedItems(0).SubItems(0).Text.Replace("'", "")
        Dim SelectedFileName As String = ""

        Dim id As Integer = BillIds(BillIndex)
        SelectedFileName = Path.Combine(SelectedFolder, id & "-" & Now.ToString("yyyyMMdd") & ".csv")
        If File.Exists(SelectedFileName) Then
            Try
                File.Delete(SelectedFileName)
            Catch ex As Exception
                MsgBox("e-File " & SelectedFileName & vbCrLf & " is already exist and may be locked by another application. Please delete that file and try again.", MsgBoxStyle.Exclamation, "Oops")
                Return
            End Try
        End If
        Using DT As DataTable = gSQLGetDataSet(GeteFileSQL(id, selectedPayerId, selectedPayerName)).Tables(0)
            Dim TotalString As String = ""
            Dim efileid As String = ""
            Dim RowNumber As Integer
            For Each row As DataRow In DT.Rows
                RowNumber = RowNumber + 1
                For i = 0 To DT.Columns.Count - 1
                    Dim Data As String
                    ''''   Go through lines in bill and for every line - put just one letter A, B, C, D.....
                    If DT.Columns(i).ColumnName.ToUpper() = "DK" Then
                        Data = Char.ToUpper(Chr(RowNumber + 64))
                        'Select Case DT.Rows.Count
                        '    Case 1
                        '        Data = "A"
                        '    Case 2
                        '        Data = "AB"
                        '    Case 3
                        '        Data = "ABC"
                        '    Case 4
                        '        Data = "ABCD"
                        '    Case 5
                        '        Data = "ABCDE"
                        '    Case 6
                        '        Data = "ABCDEF"
                        '    Case 7
                        '        Data = "ABCDEFG"
                        '    Case 8
                        '        Data = "ABCDEFGH"
                        '    Case 9
                        '        Data = "ABCDEFGHI"
                        '    Case 10
                        '        Data = "ABCDEFGHIJ"
                        'End Select
                    Else
                        Data = row(i).ToString.Trim.Replace(vbCr, "").Replace(vbLf, "")
                    End If


                    TotalString = TotalString & Data & ","
                Next
                TotalString = TotalString & vbCrLf
                efileid = row(0).ToString
            Next
            File.WriteAllText(SelectedFileName, TotalString)
            Dim SQL As String = " UPDATE BILLS Set BillStatusID = 2 Where BillStatusID = 1  And BillID = " & id & " "
            SQL &= " update Bills set efileId = '" & efileid & "', efileDate=getdate() where BillID = " & id & " "
            SQL &= " INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) values(" & id & ", 'e-File Created: " & efileid & "'," & gCurrentEmployee.EmpID & ",getdate()) "
            SQL &= " INSERT INTO BillEFiles ([efileid], [billid], [Data]) VALUES ('" & efileid & "'," & id & ",'" & TotalString.Replace("'", "''") & "')"
            gSQLUpdateData(SQL)
            DT.Dispose()
        End Using

        If BillIndex = BillIds.Length - 1 Then
            ProgressBar1.Value = BillIds.Length
            ProgressBar1.Refresh()
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            If BillIds.Length = 1 Then
                MsgBox("e-File file has been created in the folder: " & SelectedFolder, MsgBoxStyle.Exclamation)
            Else
                MsgBox("e-File file(s) creation complete." & vbCrLf & BillIds.Count & " files created in the folder: " & SelectedFolder, MsgBoxStyle.Exclamation)
            End If
            DoNotPrompt = False
            Process.Start(SelectedFolder)
            DialogResult = DialogResult.OK
            Return
        End If

        BillIndex = BillIndex + 1
        id = BillIds(BillIndex)
        ProgressBar1.Value = BillIndex
        ProgressBar1.Refresh()
        Application.DoEvents()
        ProgressBar1.Refresh()
        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()
        ShowBill(id)
        lblWait.Text = ("Select payer for the next bill: " & id).ToUpper
        cmdUpdate.Text = "Process Next Bill"
        lblWait.Visible = True
        Application.DoEvents()
        If CheckBox1.Checked Then
            cmdUpdate_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TimerSearch.Enabled = False
        TimerSearch.Enabled = True
    End Sub

    Private Sub TimerSearch_Tick(sender As Object, e As EventArgs) Handles TimerSearch.Tick
        TimerSearch.Enabled = False
        Filter_Payers(TextBox1.Text)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If TextBox1.Text.Length > 0 Then TimerSearch.Enabled = True
    End Sub
    Private Sub AutosizeColumns()
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub ToolStripAutoResize_Click(sender As Object, e As EventArgs) Handles ToolStripAutoResize.Click
        ListView1.SuspendLayout()
        AutosizeColumns()
        Application.DoEvents()
        ListView1.ResumeLayout()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            cmdUpdate_Click(Nothing, Nothing)
        End If
    End Sub
    Private Function GeteFileSQL(billid As Integer, selectedPayerId As String, selectedPayerName As String)
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append("	declare @GUID varchar(255)	")
        sb.Append("	SET @GUID = NEWID()	")
        sb.Append("	 SELECT @GUID as 'A', 	")
        sb.Append("	 '" & selectedPayerId & "' as 'B', 	")
        sb.Append("	 '" & selectedPayerName.Replace(",", " ") & "' as 'C', 	")
        sb.Append("	 REPLACE(InsuranceCompanyAddresses.AddressName,',',' ') as 'D', 	")
        sb.Append("	 REPLACE(InsuranceCompanyAddresses.AddressName2,',',' ') as 'E', 	")
        sb.Append("	 InsuranceCompanyAddresses.City as 'F', 	")
        sb.Append("	 InsuranceCompanyAddresses.State as 'G', 	")
        sb.Append("	 InsuranceCompanyAddresses.Zip as 'H',	")
        sb.Append("	 7 as 'I', 	")
        sb.Append("	 '999999999' as 'J', 	")
        sb.Append("	 REPLACE(Patients.LName,',',' ') as 'K', 	")
        sb.Append("	 RePLACE(Patients.FName,',',' ') as 'L',	")
        sb.Append("	 REPLACE(Patients.MI,',',' ') as 'M', 	")
        sb.Append("	 CONVERT(char(10), Patients.DOB,126) as 'N', 	")
        sb.Append("	 case when Patients.Sex='M' then 1 else 2 end as 'O',	")
        sb.Append("	 case Patients.CaseTypeID when 2 then 2 else 1 end as 'P',	")
        sb.Append("	 case Patients.CaseTypeID when 2 then REPLACE(Patients.EmployerName,',',' ') else REPLACE(Patients.PolicyHolderLName,',',' ') end as 'Q',	")
        sb.Append("	 case Patients.CaseTypeID when 2 then '' else REPLACE(Patients.PolicyHolderFName,',',' ') end as 'R',	")
        sb.Append("	 case Patients.CaseTypeID when 2 then '' else Patients.PolicyHolderMI end as 'S',	")
        sb.Append("	 Patients.Address1 as 'T', 	")
        sb.Append("	 Patients.City as 'U', 	")
        sb.Append("	 Patients.State as 'V', 	")
        sb.Append("	 Patients.Zip as 'W',	")
        sb.Append("	 replace(replace(replace(replace(replace(Patients.Phone1,'(',''),')',''),'-',''),' ',''),',',' ') as 'X',	")
        sb.Append("	  case Patients.CaseTypeID when 2 then 4 else 1 end as 'Y',	")
        sb.Append("	  case Patients.CaseTypeID when 2 then replace(EmployerAddress,',',' ') else case when PolicyHolderFName = Patients.fname and PolicyHolderLName = Patients.LName then replace(Patients.Address1,',',' ') else replace(PolicyHolderAddress,',',' ') end end as 'Z',	")
        sb.Append("	  case Patients.CaseTypeID when 2 then EmployerAddressCity else case when PolicyHolderFName = Patients.fname and PolicyHolderLName = Patients.LName then Patients.City else PolicyHolderCity end end as 'AA',	")
        sb.Append("	  case Patients.CaseTypeID when 2 then EmployerAddressState else case when PolicyHolderFName = Patients.fname and PolicyHolderLName = Patients.LName then Patients.State else PolicyHolderState end end as 'AB',	")
        sb.Append("	  case Patients.CaseTypeID when 2 then EmployerAddressZip else case when PolicyHolderFName = Patients.fname and PolicyHolderLName = Patients.LName then Patients.Zip else PolicyHolderZip end end as 'AC',	")
        sb.Append("	  '' as 'AD', 	")
        sb.Append("	  '' as 'AE', 	")
        sb.Append("	  '' as 'AF', 	")
        sb.Append("	  '' as 'AG', 	")
        sb.Append("	  '' as 'AH', 	")
        sb.Append("	  '' as 'AI', 	")
        sb.Append("	  case Patients.CaseTypeID when  2  then 1 else 2 end as 'AJ',	")
        sb.Append("	  case Patients.CaseTypeID when 2  then 2 else 1 end as 'AK',	")
        sb.Append("	  Patients.StateOfAccident as 'AL', 	")
        sb.Append("	  2 as 'AM', 	")
        sb.Append("	  '' as 'AN',	")
        sb.Append("	  '' as 'AO',	")
        sb.Append("	  case when PolicyHolderFName = Patients.fname and PolicyHolderLName = Patients.LName then CONVERT(char(10), Patients.DOB,126)  else '' end as 'AP',	")
        sb.Append("	  case when PolicyHolderFName = Patients.fname and PolicyHolderLName = Patients.LName then   case when Patients.Sex ='M' then '1' else '2' end else '' end as 'AQ',	")
        sb.Append("	  replace(Patients.ClaimNumber,',',' ') as 'AR',	")
        sb.Append("	  '' as 'AS',	")
        sb.Append("	  '' as 'AT',	")
        sb.Append("	  1 as 'AU',	")
        sb.Append("	  CONVERT(char(10), BillDate,126) as 'AV',	")
        sb.Append("	  '' as 'AW',	")
        sb.Append("	  CONVERT(char(10), DOA,126)  as 'AX',	")
        sb.Append("	  '' as 'AY',	")
        sb.Append("	  '' as 'AZ',	")
        sb.Append("	  '' as 'BA',	")
        sb.Append("	  '' as 'BB',	")
        sb.Append("	  '' as 'BC',	")
        sb.Append("	  '' as 'BD',	")
        sb.Append("	  '' as 'BE',	")
        sb.Append("	  '' as 'BF',	")
        sb.Append("	  '' as 'BG',	")
        sb.Append("	  '' as 'BH',	")
        sb.Append("	  '' as 'BI',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 0 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BJ',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 1 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BK',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 2 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BL',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 3 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BM',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 4 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BN',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 5 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BO',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 6 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BP',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 7 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BQ',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 8 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BR',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 9 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BS',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 10 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BT',	")
        sb.Append("	replace((select ICDCode from BillDiagnosis where BillDiagnosis.BillID=Bills.BillID order by PatientProcedureID OFFSET 11 rows FETCH NEXT 1 ROWS ONLY),',',' ') as 'BU',	")
        sb.Append("	  '' as 'BV',	")
        sb.Append("	  '' as 'BW',	")
        sb.Append("	  '' as 'BX',	")
        sb.Append("	BP.CorporationTaxID as 'BY',	")
        sb.Append("	2 as 'BZ',	")
        sb.Append("	patients.PatientID as 'CA',	")
        sb.Append("	1 as 'CB',	")
        sb.Append("	Bills.BillAmount as 'CC',	")
        sb.Append("	0 as 'CD',	")
        sb.Append("	1 as 'CE',	")
        sb.Append("	replace(rtrim(TR.Fname) + ' ' + rtrim(TR.Lname),',',' ') as 'CF',	")
        sb.Append("	CONVERT(char(10), Bills.BillDate,126)  as 'CG',	")
        sb.Append("	REPLACE(BP.CorporationName,',',' ') as 'CH',	")
        sb.Append("	REPLACE(Offices.Address1,',',' ') as 'CI',	")
        sb.Append("	REPLACE(Offices.Address2,',',' ') as 'CJ',	")
        sb.Append("	Offices.City as 'CK',	")
        sb.Append("	Offices.State as 'CL',	")
        sb.Append("	Offices.Zip as 'CM',	")
        sb.Append("	replace(replace(replace(replace(replace(Offices.Phone1,'(',''),')',''),'-',''),' ',''),',',' ') as 'CN',	")
        sb.Append("	'' as 'CO',	")
        sb.Append("	'' as 'CP',	")
        sb.Append("	REPLACE(BP.CorporationName,',',' ') as 'CQ',	")
        sb.Append("	REPLACE(BP.CorporationAddress1,',',' ') as 'CR',	")
        sb.Append("	REPLACE(BP.CorporationAddress2,',',' ') as 'CS',	")
        sb.Append("	BP.CorporationCity as 'CT',	")
        sb.Append("	BP.CorporationState as 'CU',	")
        sb.Append("	BP.CorporationZip as 'CV',	")
        sb.Append("	replace(replace(replace(replace(Offices.Phone1,'(',''),')',''),'-',''),' ','') as 'CW',	")
        sb.Append("	replace(bp.WCProviderNPI,',',' ') as 'CX',	")
        sb.Append("	'' as 'CY',	")
        sb.Append("	ROW_NUMBER() OVER(ORDER BY BillProcedures.PatientProcedureID) as 'CZ',	")
        sb.Append("	CONVERT(char(10), Schedule.ScheduleDateTime,126) as 'DA',	")
        sb.Append("	CONVERT(char(10), Schedule.ScheduleDateTime,126) as 'DB',	")
        sb.Append("	11 as 'DC',	")
        sb.Append("	'' as 'DD',	")
        sb.Append("	replace(BillProcedures.Code,',',' ') as 'DE',	")
        sb.Append("	replace(Procedures.Modifier,',',' ') as 'DF',	")
        sb.Append("	'' as 'DG',	")
        sb.Append("	'' as 'DH',	")
        sb.Append("	'' as 'DI',	")
        sb.Append("	'' as 'DJ',	")
        sb.Append("	replace((select TOP 1 ICDCode from BillDiagnosis where BillDiagnosis.PatientProcedureID=BillProcedures.PatientProcedureID),',',' ') as 'DK',	")
        sb.Append("	BillProcedures.WCCost as 'DL',	")
        sb.Append("	1 as 'DM',	")
        sb.Append("	'' as 'DN',	")
        sb.Append("	'' as 'DO',	")
        sb.Append("	'' as 'DP',	")
        sb.Append("	'' as 'DQ',	")
        sb.Append("	'' as 'DR',	")
        sb.Append("	'' as 'DS',	")
        sb.Append("	10 as 'DT',	")
        sb.Append("	replace(TR.WCProviderNPI,',',' ') as 'DU',	")
        sb.Append("	'' as 'DV',	")
        sb.Append("	'' as 'DW',	")
        sb.Append("	'' as 'DX',	")
        sb.Append("	replace(rtrim(TR.Lname ),',',' ') as 'DY',	")
        sb.Append("	'' as 'DZ',	")
        sb.Append("	'' as 'EA',	")
        sb.Append("	'' as 'EB',	")
        sb.Append("	'' as 'EC',	")
        sb.Append("	'' as 'ED',	")
        sb.Append("	'' as 'EE',	")
        sb.Append("	'CR-DRA' as 'EF',	")
        sb.Append("	'' as 'EG',	")
        sb.Append("	'' as 'EH',	")
        sb.Append("	'' as 'EI',	")
        sb.Append("	'' as 'EJ',	")
        sb.Append("	'' as 'EK',	")
        sb.Append("	'' as 'EL',	")
        sb.Append("	'' as 'EM',	")
        sb.Append("	Patients.WCCaseNumber as 'EN',	")
        sb.Append("	'' as 'EO'	")
        'sb.Append("	'' as 'EP',	")
        'sb.Append("	'' as 'EQ'	")
        sb.Append("	 FROM Bills INNER JOIN Patients Patients ON Bills.PatientID=Patients.PatientID 	")
        sb.Append("	 LEFT OUTER JOIN InsuranceCompanyAddresses ON Bills.InsAddressID=InsuranceCompanyAddresses.AddressID	")
        sb.Append("	 LEFT OUTER JOIN  BillProcedures on bills.BillID = BillProcedures.BillID	")
        sb.Append("	 LEFT OUTER JOIN  Procedures on Procedures.ProcID = BillProcedures.ProcID	")
        sb.Append("	 LEFT OUTER JOIN  PatientProcedures on BillProcedures.PatientProcedureID = PatientProcedures.PatientProcedureID	")
        sb.Append("	 LEFT OUTER JOIN  Employees BP on PatientProcedures.BillingProviderID = BP.EmpID	")
        sb.Append("	 LEFT OUTER JOIN  Employees TR on PatientProcedures.TreatingProviderID = TR.EmpID	")
        sb.Append("	 LEFT OUTER JOIN  Offices on PatientProcedures.OfficeID = Offices.OfficeID	")
        sb.Append("	 LEFT OUTER JOIN  Schedule on Schedule.ScheduleID = PatientProcedures.ScheduleID	")
        sb.Append("	  WHERE  Bills.BillID=	" & billid)
        Return sb.ToString()
    End Function

    Private Sub TimerLoad_Tick(sender As Object, e As EventArgs) Handles TimerLoad.Tick
        TimerLoad.Enabled = False
        SelectedFolder = My.Settings.eFileInitFolder
        If SelectedFolder.Length = 0 Or Directory.Exists(SelectedFolder) = False Then
            Dim fd As New FolderBrowserDialog
            fd.SelectedPath = SelectedFolder
            fd.ShowNewFolderButton = True
            fd.Description = "Select the e-File(s) output location"
            If fd.ShowDialog() = DialogResult.OK Then
                SelectedFolder = fd.SelectedPath
                My.Settings.eFileInitFolder = SelectedFolder
                My.Settings.Save()
            End If
        End If
        lblWait.Text = ("Select payer for the bill: " & BillIds(0) & "  (" & BillIndex + 1 & " of " & BillIds.Count & ")").ToUpper
        lblNumber.Text = BillIndex + 1 & " of " & BillIds.Count
        ProgressBar1.Maximum = BillIds.Count
        ProgressBar1.Value = BillIndex
        lblWait.Visible = True
        ShowBill(BillIds(0))
        cmdUpdate.Enabled = SelectedFolder.Length > 0
    End Sub

    Private Sub btnChangePath_Click(sender As Object, e As EventArgs) Handles btnChangePath.Click
        ListView1.Focus()
        Application.DoEvents()
        Dim fd As New FolderBrowserDialog
        fd.SelectedPath = My.Settings.eFileInitFolder
        fd.ShowNewFolderButton = True
        fd.Description = "Select e-File CSV files to be located folder"
        If fd.ShowDialog() = DialogResult.OK Then
            SelectedFolder = fd.SelectedPath
            My.Settings.eFileInitFolder = SelectedFolder
            My.Settings.Save()
        End If
        cmdUpdate.Enabled = SelectedFolder.Length > 0
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    Private Sub frmSelectPayer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If BillIndex < BillIds.Length - 1 Then
            If MsgBox("Process is not complete." & vbCrLf & vbCrLf & "e-Files has not been created for all selected bills." & vbCrLf & vbCrLf & "Terminate process?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.No Then
                e.Cancel = True
                Return
            End If
        End If
        BillIndex = 0
    End Sub
    Dim LastSelectedIndex As Integer
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If LastSelectedIndex > -1 Then
            ListView1.Items(LastSelectedIndex).BackColor = Color.Empty
            ListView1.Items(LastSelectedIndex).ForeColor = Color.Black
        End If
        If ListView1.SelectedItems.Count > 0 Then
            ListView1.SelectedItems(0).BackColor = Color.FromName("Highlight")
            ListView1.SelectedItems(0).ForeColor = Color.White
            LastSelectedIndex = ListView1.SelectedItems(0).Index
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TimerSearch.Enabled = False
        TimerSearch.Enabled = True
        TextBox1.Focus()
    End Sub
End Class