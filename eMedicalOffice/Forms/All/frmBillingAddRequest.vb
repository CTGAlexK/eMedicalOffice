Public Class frmBillingAddRequest
    Public BillID As Long
    Public PatientID As Long
    Public BillAttorney As String
    Public BillInsurance As String

    Private Sub frmBillingAddRequest_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ChangesMade = True And FpSpreadRequests.ActiveSheet.RowCount > 1 Then
            If MsgBox("Discard Changes?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gSpread_Settings(Me, FpSpreadRequests, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub
    Private Sub frmBillingAddRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
        Load_Requests()
        gWindow_Settings(Me, ReadWrite.sRead)
        gSpread_Settings(Me, FpSpreadRequests, ReadWrite.sRead)
    End Sub

    Private Sub Load_Data()
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim Arlst As New ArrayList
        Dim ArlstData As New ArrayList
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Arlst.Add("")
        ArlstData.Add("")
        SQL = "select * from BillingRequestTypes Order By ShowOrder"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Arlst.Add(Reader("Description").ToString)
            ArlstData.Add(Reader("RequestTypeID").ToString)
        Loop
        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.String
        cmbocell.Items = Arlst.Clone.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.Clone.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
        cmbocell.Editable = True
        cmbocell.MaxDrop = 20
        FpSpreadRequests.ActiveSheet.Columns(0).CellType = cmbocell
        ''''''''''''''''''''''''''''''''''''

        cmbocell = New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Arlst.Clear()
        ArlstData.Clear()
        Arlst.Add("")
        If BillAttorney <> "" Then Arlst.Add(BillAttorney)
        If BillInsurance <> "" Then Arlst.Add(BillInsurance)
        Arlst.Add("Report To Manager When Done ASAP")


        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.String
        cmbocell.Items = Arlst.Clone.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
        cmbocell.Editable = True
        cmbocell.MaxDrop = 20
        FpSpreadRequests.ActiveSheet.Columns(1).CellType = cmbocell

        '''''''''''''''''''''''''''''''''''
        cmbocell = New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Arlst.Clear()
        ArlstData.Clear()
        SQL = "SELECT     EmpID, Fname + ' ' + Lname AS EmpName, PositionID  FROM Employees WHERE PositionID <> 5 and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ") ORDER BY PositionID, EmpName "
        Reader = gSQLGetDataReader(SQL)
        Arlst.Add("")
        ArlstData.Add("0")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Arlst.Add(Reader("EmpName").ToString)
            ArlstData.Add(Reader("EmpID").ToString)
        Loop

        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
        cmbocell.Items = Arlst.Clone.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.Clone.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 20
        FpSpreadRequests.ActiveSheet.Columns(2).CellType = cmbocell
        '''''''''''''''''''''''''''''''''''

        cmbocell = New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Arlst.Clear()
        ArlstData.Clear()
        Arlst.Add("")
        ArlstData.Add("0")
        SQL = "SELECT     StatusID, Description FROM         BillingRequestStatuses order by StatusID "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Arlst.Add(Reader("Description").ToString)
            ArlstData.Add(Reader("StatusID").ToString)
        Loop

        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
        cmbocell.Items = Arlst.Clone.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.Clone.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 20
        FpSpreadRequests.ActiveSheet.Columns(5).CellType = cmbocell




        '''''''''''''''''''''''''
    End Sub

    Private Sub Load_Requests()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        FpSpreadRequests.ActiveSheet.RowCount = 0
        If BillID = 0 Then
            SQL = "SELECT Employees.Fname + ' ' +Employees.LName as EmpName, Priority, CDProcedures, RequestID, BillID, PatientID ,RequestTypeID, RequestDescription, RequestFrom, ResponsibleEmpID, RequestDate, RequestStatusID, StatusDate  FROM BillingRequests inner join Employees on BillingRequests.ResponsibleEmpID = Employees.EmpID Where PatientID  = " & Val(PatientID)
        Else
            SQL = " SELECT Employees.Fname + ' ' +Employees.LName as EmpName, Priority, CDProcedures, RequestID, BillID, PatientID ,RequestTypeID, RequestDescription, RequestFrom, ResponsibleEmpID, RequestDate, RequestStatusID, StatusDate  FROM BillingRequests inner join Employees on BillingRequests.ResponsibleEmpID = Employees.EmpID Where BillID = " & BillID
        End If
        'SQL = "SELECT Priority, CDProcedures, RequestID, BillID, PatientID ,RequestTypeID, RequestDescription, RequestFrom, ResponsibleEmpID, RequestDate, RequestStatusID, StatusDate  FROM BillingRequests Where BillID = " & BillID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Dim cmbocell

        cmbocell = New FarPoint.Win.Spread.CellType.TextCellType

        Do Until Reader.Read = False
            R = R + 1
            FpSpreadRequests.ActiveSheet.RowCount = R
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).CellType = cmbocell
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 1).CellType = cmbocell
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 2).CellType = cmbocell
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).Text = Reader("RequestDescription").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).Tag = Reader("RequestID").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 1).Text = Reader("RequestFrom").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 2).Text = Reader("EmpName").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 3).Text = FormatDateTime(Reader("RequestDate").ToString, DateFormat.GeneralDate)
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 4).Value = Reader("Priority").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 4).Tag = Reader("Priority").ToString

            FpSpreadRequests.ActiveSheet.Cells(R - 1, 5).Value = Reader("RequestStatusID").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 5).Tag = Reader("RequestStatusID").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 6).Text = FormatDateTime(Reader("StatusDate").ToString, DateFormat.GeneralDate)
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 7).Text = Reader("CDProcedures").ToString


            FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).Locked = True : FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).BackColor = Color.WhiteSmoke
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 1).Locked = True : FpSpreadRequests.ActiveSheet.Cells(R - 1, 1).BackColor = Color.WhiteSmoke
            'FpSpreadRequests.ActiveSheet.Cells(R - 1, 2).Locked = True : FpSpreadRequests.ActiveSheet.Cells(R - 1, 2).BackColor = Color.WhiteSmoke
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 3).Locked = True : FpSpreadRequests.ActiveSheet.Cells(R - 1, 3).BackColor = Color.WhiteSmoke
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 4).Locked = True : FpSpreadRequests.ActiveSheet.Cells(R - 1, 4).BackColor = Color.WhiteSmoke

            If gCurrentEmployee.PositionID > 2 Then
                FpSpreadRequests.ActiveSheet.Cells(R - 1, 5).Locked = True : FpSpreadRequests.ActiveSheet.Cells(R - 1, 5).BackColor = Color.WhiteSmoke
            End If
            'FpSpreadRequests.ActiveSheet.Cells(R - 1, 5).Locked = True : FpSpreadRequests.ActiveSheet.Cells(R - 1, 6).BackColor = Color.WhiteSmoke
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 6).Locked = True : FpSpreadRequests.ActiveSheet.Cells(R - 1, 7).BackColor = Color.WhiteSmoke
        Loop
        FpSpreadRequests.ActiveSheet.RowCount = FpSpreadRequests.ActiveSheet.RowCount + 1
        cmbocell = New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim Arlst As New ArrayList
        Dim ArlstData As New ArrayList
        Arlst.Add("New")
        ArlstData.Add("1")
        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
        cmbocell.Items = Arlst.Clone.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.Clone.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 20
        FpSpreadRequests.ActiveSheet.Cells(FpSpreadRequests.ActiveSheet.RowCount - 1, 5).CellType = cmbocell
        FpSpreadRequests.ActiveSheet.Cells(FpSpreadRequests.ActiveSheet.RowCount - 1, 5).Value = 1
        FpSpreadRequests.ActiveSheet.Cells(FpSpreadRequests.ActiveSheet.RowCount - 1, 4).Value = 0
        ChangesMade = False
        If FpSpreadRequests.ActiveSheet.RowCount > 0 Then
            Dim e As New FarPoint.Win.Spread.EnterCellEventArgs(Nothing, 0, 0)
            FpSpreadRequests_EnterCell(Nothing, e)
        End If

    End Sub
    Private ChangesMade As Boolean
    Private Sub FpSpreadRequests_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpreadRequests.ComboCloseUp
        edata = e
        Timer1.Enabled = False
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQL As String
        Dim RowIndex As Integer
        Dim RequestDescription As String
        Dim RequestTypeID As Integer
        Dim RequestFrom As String
        Dim ResponsibleEmpID As Long
        Dim RequestStatusID As Long
        Dim Priority As Long
        Dim CDProcedures As String
        Dim RequestID As Long
        Dim Reader As SqlClient.SqlDataReader
        Dim SavePriority As Long
        Dim SaveRequestStatusID As Long



        For RowIndex = 0 To FpSpreadRequests.ActiveSheet.RowCount - 2
            RequestTypeID = 0
            RequestID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 0).Tag)
            RequestDescription = FpSpreadRequests.ActiveSheet.Cells(RowIndex, 0).Text.Trim
            RequestTypeID = gSQLGetSingleValue("SELECT     RequestTypeID FROM         BillingRequestTypes Where Description = '" & RequestDescription.ToSafeSQLString() & "'")
            RequestFrom = FpSpreadRequests.ActiveSheet.Cells(RowIndex, 1).Text
            ResponsibleEmpID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 2).Value)
            Priority = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 4).Value)
            RequestStatusID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 5).Value)
            CDProcedures = FpSpreadRequests.ActiveSheet.Cells(RowIndex, 7).Text
            SaveRequestStatusID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 5).Tag)


            If Val(RequestID) = 0 Then
                If RequestDescription <> "" And RequestFrom <> "" And Val(ResponsibleEmpID) <> 0 And Val(RequestStatusID) <> 0 Then
                    SQL = " INSERT INTO BillingRequests (Priority, BillID,PatientID,RequestTypeID, RequestDescription,RequestFrom,ResponsibleEmpID,RequestDate,RequestStatusID,StatusDate,CDProcedures) "
                    SQL = SQL & " VALUES(" & Priority & ", " & BillID & ", " & PatientID & ", " & RequestTypeID & ", '" & RequestDescription.ToSafeSQLString() & "', '" & RequestFrom.ToSafeSQLString() & "', " & Val(ResponsibleEmpID) & ", getdate(), " & Val(RequestStatusID) & ", getdate(), '" & CDProcedures.ToSafeSQLString() & "')"
                    gSQLUpdateData(SQL)
                    gUpdate_Profile_Log(PatientID, PatientLogTypes.tRequestCreated)
                Else
                    MsgBox("Unable to process your request. Incomplete Request Information.", MsgBoxStyle.Exclamation)
                    gSpreadActivateCell(FpSpreadRequests, RowIndex, 0)
                    Exit Sub
                End If
            Else
                If Val(RequestStatusID) <> 0 Then
                    If Val(SaveRequestStatusID) <> Val(RequestStatusID) Then
                        FpSpreadRequests.ActiveSheet.Cells(RowIndex, 6).Text = FormatDateTime(Now, DateFormat.GeneralDate)
                        gSQLUpdateData("Update BillingRequests Set RequestStatusID = " & Val(RequestStatusID) & ", StatusDate = getdate() Where RequestID = " & Val(RequestID))
                        Select Case Val(RequestStatusID)
                            Case 1  'New
                                gUpdate_Profile_Log(PatientID, PatientLogTypes.tRequestCreated, "Request Status Change Request Created")
                            Case 2  'Inprogress
                                gUpdate_Profile_Log(PatientID, PatientLogTypes.tRequestInProgress, "Request Status Change Request In Progress")
                            Case 3  'Complete
                                gUpdate_Profile_Log(PatientID, PatientLogTypes.tRequestCompleted, "Request Status Change Request Completed")
                            Case 4  'Canceled
                                gUpdate_Profile_Log(PatientID, PatientLogTypes.tScheduleCanceled, "Request Status Change Schedule Canceled")
                        End Select
                    End If
                Else
                    MsgBox("Unable to process your request. Incomplete Request Information.", MsgBoxStyle.Exclamation)
                    gSpreadActivateCell(FpSpreadRequests, RowIndex, 5)
                    Exit Sub
                End If
            End If
        Next
        ChangesMade = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub FpSpreadRequests_EnterCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EnterCellEventArgs) Handles FpSpreadRequests.EnterCell
        Dim RequestID As Long
        Dim RowIndex = e.Row
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewActions.Items.Clear()
        RequestID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 0).Tag)
        If RequestID = 0 Then Exit Sub
        SQL = "SELECT Fname+' '+Fname as EmpName, RequestActionID, RequestID, Description, RequestActionDate FROM BillingRequestActions inner join Employees on BillingRequestActions.CreatedBy = Employees.EmpID where RequestID = " & RequestID

        Reader = gSQLGetDataReader(SQL)
        ListViewActions.Items.Clear()
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Do Until Reader.Read = False
                LI = ListViewActions.Items.Add(FormatDateTime(Reader("RequestActionDate").ToString, DateFormat.ShortDate))
                LI.Tag = Reader("RequestActionID").ToString
                LI.SubItems.Add(Reader("Description").ToString)
                LI.SubItems.Add(Reader("EmpName").ToString)
                LI.ToolTipText = Reader("Description").ToString
            Loop
        End If

        Reader.Close() : Reader.Dispose()
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FpSpreadRequests_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadRequests.CellClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If gScannerMode = 1 Then
            ScanDocumentFromScannerApplication(0)
        Else
            ScanDocumentFromScanner(0)

        End If
    End Sub

    Private Sub ScanDocumentFromScanner(ByVal DocProfileID As Integer)
        Dim Reader As SqlClient.SqlDataReader
        Dim DocProfID As Integer
        Reader = gSQLGetDataReader("Select ProfileID From DocumentProfiles where DocumentName='Billing Request'")
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            DocProfID = Val(Reader("ProfileID").ToString)
        Else
            DocProfID = 17 ' Document
        End If


        frmDocumentScannerPDF.IniDocProfile = DocProfID
        frmDocumentScannerPDF.PatientID = PatientID
        If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            gSQLUpdateData("UPDATE Documents set PatientID = " & PatientID & " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
        End If
        frmDocumentScannerPDF.Dispose()
    End Sub
    Private Sub ScanDocumentFromScannerApplication(ByVal DocProfileID As Integer)
        If gScannerFolder = "" Then
            MsgBox("Unable to scan. The Scanner Folder has not been specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IO.Directory.Exists(gScannerFolder) = False Then
            MsgBox("Unable to scan. Invalid Scanner Folder specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim Reader As SqlClient.SqlDataReader
        Dim DocProfID As Integer
        Reader = gSQLGetDataReader("Select ProfileID From DocumentProfiles where DocumentName='Billing Request'")
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            DocProfID = Val(Reader("ProfileID").ToString)
        Else
            DocProfID = 17 ' Document
        End If
        frmDocumentScannerExternalProgram.IniDocProfile = DocProfID
        frmDocumentScannerExternalProgram.PatientID = PatientID
        If frmDocumentScannerExternalProgram.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            gSQLUpdateData("UPDATE Documents set PatientID = " & PatientID & " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
        End If
        frmDocumentScannerExternalProgram.Dispose()
    End Sub
    Dim edata As FarPoint.Win.Spread.EditorNotifyEventArgs
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim SQL As String
        Dim RowIndex As Integer = FpSpreadRequests.ActiveSheet.ActiveCell.Row.Index
        Dim RequestDescription = FpSpreadRequests.ActiveSheet.Cells(RowIndex, 0).Text
        Dim RequestTypeID As Integer = gSQLGetSingleValue("SELECT     RequestTypeID FROM         BillingRequestTypes Where Description = '" & RequestDescription.ToSafeSQLString() & "'")


        Dim RequestFrom = FpSpreadRequests.ActiveSheet.Cells(RowIndex, 1).Text
        Dim ResponsibleEmpID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 2).Value)
        Dim Priority = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 4).Value)
        Dim RequestStatusID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 5).Value)
        Dim RequestStatusCD = FpSpreadRequests.ActiveSheet.Cells(RowIndex, 6).Text
        Dim RequestID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 0).Tag)
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim Arlst As New ArrayList
        Dim ArlstData As New ArrayList
        Dim Reader As SqlClient.SqlDataReader
        ChangesMade = True
        If RowIndex = FpSpreadRequests.ActiveSheet.RowCount - 1 Then
            If edata.Column = 0 Then
                If RequestTypeID = 1 And RequestID = 0 Then
                    frmBillingRequestCdProcedures.ProcCell = FpSpreadRequests.ActiveSheet.Cells(RowIndex, 7)
                    frmBillingRequestCdProcedures.Load_Procedures(PatientID, BillID)
                    If frmBillingRequestCdProcedures.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                        If RequestStatusCD = "" Then
                            FpSpreadRequests.ActiveSheet.Cells(RowIndex, 0).Value = ""
                        End If
                    End If
                End If
                If RequestTypeID <> 1 And RequestID = 0 Then
                    FpSpreadRequests.ActiveSheet.Cells(RowIndex, 7).Text = ""
                End If
            End If
            If RequestDescription <> "" And RequestFrom <> "" And Val(ResponsibleEmpID) <> 0 And Val(RequestStatusID) <> 0 Then
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 3).Text = FormatDateTime(Now, DateFormat.GeneralDate)
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 6).Text = FormatDateTime(Now, DateFormat.GeneralDate)

                cmbocell = New FarPoint.Win.Spread.CellType.ComboBoxCellType
                Arlst.Clear()
                ArlstData.Clear()
                SQL = "SELECT     StatusID, Description FROM         BillingRequestStatuses order by StatusID "
                Reader = gSQLGetDataReader(SQL)
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    Arlst.Add(Reader("Description").ToString)
                    ArlstData.Add(Reader("StatusID").ToString)
                Loop

                cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
                cmbocell.Items = Arlst.Clone.ToArray(GetType(String))
                cmbocell.ItemData = ArlstData.Clone.ToArray(GetType(String))
                cmbocell.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
                cmbocell.Editable = False
                cmbocell.MaxDrop = 20
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 5).CellType = cmbocell
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 3).Text = FormatDateTime(Now, DateFormat.GeneralDate)
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 6).Text = FormatDateTime(Now, DateFormat.GeneralDate)
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 0).Locked = True : FpSpreadRequests.ActiveSheet.Cells(RowIndex, 0).BackColor = Color.WhiteSmoke
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 1).Locked = True : FpSpreadRequests.ActiveSheet.Cells(RowIndex, 1).BackColor = Color.WhiteSmoke
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 2).Locked = True : FpSpreadRequests.ActiveSheet.Cells(RowIndex, 2).BackColor = Color.WhiteSmoke
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 3).Locked = True : FpSpreadRequests.ActiveSheet.Cells(RowIndex, 3).BackColor = Color.WhiteSmoke
                If gCurrentEmployee.PositionID > 2 Then
                    FpSpreadRequests.ActiveSheet.Cells(RowIndex, 4).Locked = True : FpSpreadRequests.ActiveSheet.Cells(RowIndex, 4).BackColor = Color.WhiteSmoke
                    FpSpreadRequests.ActiveSheet.Cells(RowIndex, 5).Locked = True : FpSpreadRequests.ActiveSheet.Cells(RowIndex, 5).BackColor = Color.WhiteSmoke
                End If
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 6).Locked = True : FpSpreadRequests.ActiveSheet.Cells(RowIndex, 6).BackColor = Color.WhiteSmoke
                FpSpreadRequests.ActiveSheet.Cells(RowIndex, 7).Locked = True : FpSpreadRequests.ActiveSheet.Cells(RowIndex, 7).BackColor = Color.WhiteSmoke

                FpSpreadRequests.ActiveSheet.RowCount = FpSpreadRequests.ActiveSheet.RowCount + 1
                cmbocell = New FarPoint.Win.Spread.CellType.ComboBoxCellType
                Arlst = New ArrayList
                ArlstData = New ArrayList
                Arlst.Add("New")
                ArlstData.Add("1")
                cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
                cmbocell.Items = Arlst.Clone.ToArray(GetType(String))
                cmbocell.ItemData = ArlstData.Clone.ToArray(GetType(String))
                cmbocell.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
                cmbocell.Editable = False
                cmbocell.MaxDrop = 20

                FpSpreadRequests.ActiveSheet.Cells(FpSpreadRequests.ActiveSheet.RowCount - 1, 5).CellType = cmbocell
                FpSpreadRequests.ActiveSheet.Cells(FpSpreadRequests.ActiveSheet.RowCount - 1, 5).Value = 1
                FpSpreadRequests.ActiveSheet.Cells(FpSpreadRequests.ActiveSheet.RowCount - 1, 4).Value = 0
            End If
        End If
    End Sub
End Class