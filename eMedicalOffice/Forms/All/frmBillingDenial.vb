Public Class frmBillingDenial
    Public CalledForm As Object
    Public BillID As Long
    Public SLI As ListViewItem

    Private Sub txtComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged
        ErrorProvider1.SetError(txtComments, "")
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim SQL As String = ""
        Dim BillComents As String = ""
        Dim LI As ListViewItem
        Dim DenialRemoved
        Dim RemoveDenialsCount As Integer
        Dim NewDenialFound As Boolean
        Dim DenialFound As Boolean
        Dim ChangesFound As Boolean
        Dim VD As ValueDescription
        'If Val(Label2.Tag) <> 0 Then
        '    If MsgBox("The Selected bill is already has been denied." & vbCrLf & "Do you want to overwrite the denial reason?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If
        For Each LI In ListViewProcedures.Items
            If LI.ForeColor = Color.OrangeRed Then
                ChangesFound = True
                If LI.SubItems(3).Text <> "" Then
                    NewDenialFound = True
                    Exit For
                End If
            End If
        Next
        Dim WarningShown As Boolean
        If CheckBox1.Checked Then
            If MsgBox("Please confirm this Patient will be set as No More Appointments." & vbCrLf & vbCrLf & "All future scheduled appointments will be deleted.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            WarningShown = True
        Else
            If CheckBox2.Checked = False Then
                If MsgBox("Please confirm this Patient will remain Active and future scheduled appointments are accepted.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                WarningShown = True
            End If
        End If
        If CheckBox3.Checked And CBool(Val(CheckBox3.Tag)) = False Then
            If MsgBox("Please confirm you want to colse this bill." & vbCrLf & "No fruther collection will be pursued for this bill!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            WarningShown = True
        End If
        If CheckBox2.Checked And WarningShown = False Then
            CheckBox1.Checked = True
            If MsgBox("Please confirm this Patient's profile will be closed." & vbCrLf & vbCrLf & "All future scheduled appointments will be deleted.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If

        ' Update Patient Profile
        If CheckBox2.Checked Then
            gSQLUpdateData("UPDATE PATIENTS SET NoMoreAppointmentsInd=1 , CaseStatusDate=getdate(), CaseStatusID=4 where PatientID=" & Val(Me.Tag))
            gUpdate_Profile_Log(Val(Me.Tag), PatientLogTypes.tStatusChange, "Case Stopped From Maintenance")
        Else
            gSQLUpdateData("UPDATE PATIENTS SET NoMoreAppointmentsInd=0 , CaseStatusDate=getdate(), CaseStatusID=1 where PatientID=" & Val(Me.Tag))
            gUpdate_Profile_Log(Val(Me.Tag), PatientLogTypes.tStatusChange, "Case Reopened From Denial Maintenance")
            If CheckBox1.Checked Then
                gSQLUpdateData("UPDATE PATIENTS SET NoMoreAppointmentsInd=1 where PatientID=" & Val(Me.Tag))
                gUpdate_Profile_Log(Val(Me.Tag), PatientLogTypes.tNoMoreSchedules, "No More Appointments From Denial Maintenance")
            Else
                gSQLUpdateData("UPDATE PATIENTS SET NoMoreAppointmentsInd=0 where PatientID=" & Val(Me.Tag))
                gUpdate_Profile_Log(Val(Me.Tag), PatientLogTypes.tNoMoreSchedules, "No More Appointments Removed From Maintenance")
            End If
        End If

        If CheckBox1.Checked Or CheckBox2.Checked Then
            gDeleteFutureAppointments(Val(Me.Tag))
        End If
        ' Update Procedures
        ''''' Return Back to denial per procedure
        Dim BillComment As String
        Dim C As Integer
        For Each LI In ListViewProcedures.Items
            If LI.ForeColor = Color.OrangeRed Then
                If LI.SubItems(3).Text <> "" Then
                    VD = CType(LI.SubItems(3).Tag, ValueDescription)
                    SQL = "UPDATE PatientProcedures set DenialBackInd=" & VD.Value1 & ", DenialDate = getdate(), Comments='" & LI.SubItems(3).Text.ToSafeSQLString() & "', DeniedInd=" & VD.Value & " where PatientProcedureID = " & Val(LI.Tag)
                    gSQLUpdateData(SQL)
                    BillComment = BillComment & "Proc Denied. " & LI.SubItems(3).Text.ToSafeSQLString() & vbCrLf
                Else
                    SQL = "UPDATE PatientProcedures set DenialBackInd=0, DenialDate = Null, Comments=Null, DeniedInd=Null where PatientProcedureID = " & Val(LI.Tag)
                    gSQLUpdateData(SQL)
                End If
            Else
                C = C + 1
                If LI.SubItems(3).Text <> "" Then
                    BillComment = BillComment & C & ". Proc Denied. " & LI.SubItems(3).Text.ToSafeSQLString() & vbCrLf
                End If
            End If
        Next

        'gSQLUpdateData("DELETE FROM BillComments where BillID=" & BillID)
        If BillComment <> "" Then
            gSQLUpdateData("INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) VALUES(" & BillID & ", '" & BillComment.ToSafeSQLString() & "', " & gCurrentEmployee.EmpID & ", getdate())")
            '' Update Bill
            SQL = "UPDATE Bills Set DenialComments='" & BillComment.ToSafeSQLString() & "', DenialFound=1 where BillID= " & BillID
            gSQLUpdateData(SQL)
            gSetListItemColor(SLI, Color.PaleGoldenrod)
        Else
            SQL = "UPDATE Bills Set DenialComments='', DenialFound=0 where BillID= " & BillID
            gSQLUpdateData(SQL)
            gSetListItemColor(SLI, Color.White)
        End If
        If CheckBox3.Checked Then
            SQL = "UPDATE Bills Set BillStatusID=8, NoMoreCollection=1 where BillID= " & BillID
            gSQLUpdateData(SQL)
        Else
            If CBool(CheckBox3.Checked) = True Then
                SQL = "UPDATE Bills Set BillStatusID=4, NoMoreCollection=0 where BillID= " & BillID
                gSQLUpdateData(SQL)
            End If
        End If

        Me.Close()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmBillingDenial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        pdfViewer.CloseDocument()
    End Sub

    Private Sub frmAddDiagnos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_data()
        'gWindow_Settings(Me, ReadWrite.sRead)
    End Sub

    Dim DenialsFound As Integer

    Private Sub Load_data()
        Dim Reader As SqlClient.SqlDataReader
        Dim IDs As String = ""
        Dim SQL As String
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        CheckBox3.Tag = False
        Label2.Text = "Bill # " & BillID
        SQL = "SELECT  Bills.NoMoreCollection, Bills.DenialComments, BillDenialReasons.Description as DenialReason,   PatientProcedures.PatientID, BillProcedures.PatientProcedureID,   Bills.BillAmount, Bills.BillDate, Bills.BillID, PatientProcedures.ProcID, Procedures.ProcName, Schedule.ScheduleDateTime, PatientProcedures.DenialDate, PatientProcedures.Comments, PatientProcedures.DeniedInd, PatientProcedures.DenialBackInd "
        SQL &= " FROM         Bills INNER JOIN BillProcedures ON Bills.BillID = BillProcedures.BillID INNER JOIN PatientProcedures ON BillProcedures.PatientProcedureID = PatientProcedures.PatientProcedureID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID LEFT OUTER JOIN BillDenialReasons on PatientProcedures.DeniedInd = BillDenialReasons.ID"
        SQL &= " WHERE BillProcedures.BillID = " & BillID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            CheckBox3.Checked = CBool(Reader("NoMoreCollection").ToString)
            CheckBox3.Tag = CBool(Reader("NoMoreCollection").ToString)
            If Val(Me.Tag) = 0 Then
                Me.Tag = Reader("PatientID").ToString
                If IsDate(Reader("DenialDate").ToString) Then
                    'gFindComboItemByValue(ComboBoxDenialReasons, Val(Reader("DeniedInd").ToString), True)
                    'Label2.Text = Label2.Text & "  Denial Date: " & CDate(Reader("DenialDate").ToString).ToShortDateString & "  Reason: " & Reader("DenialReason").ToString
                    Label2.Tag = "1"
                    'cmdUpdate.Enabled = False
                    'CheckBox1.Enabled = False
                    'CheckBox2.Enabled = False
                    'ComboBoxDenialReasons.Enabled = False
                    'txtComments.Enabled = False
                End If

            End If
            LI = ListViewProcedures.Items.Add(FormatDateTime(Reader("ScheduleDateTime").ToString, 2))
            LI.UseItemStyleForSubItems = True
            LI.Tag = Val(Reader("PatientProcedureID").ToString)
            LI.SubItems.Add(Reader("ProcName").ToString).Tag = "1"
            If IsDate(Reader("DenialDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("DenialDate").ToString).ToShortDateString)
                LI.ForeColor = Color.Red
            Else
                LI.SubItems.Add("")
            End If
            SI = LI.SubItems.Add(Reader("Comments").ToString)
            SI.Tag = New ValueDescription(Val(Reader("DeniedInd").ToString), Reader("Comments").ToString, Val(Reader("DenialBackInd").ToString))
        Loop
        Reader = gSQLGetDataReader("SELECT  Bills.DenialComments FROM Bills WHERE BillID = " & BillID)
        If Not Reader Is Nothing Then
            If Reader.HasRows Then
                Reader.Read()
                txtComments.Text = Reader("DenialComments").ToString
            End If
        End If

        Reader = gSQLGetDataReader("SELECT NoMoreAppointmentsInd, CaseStatusID FROM Patients Where PatientID = " & Val(Me.Tag))
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            CheckBox1.Checked = Val(Reader("NoMoreAppointmentsInd").ToString)
            CheckBox1.Tag = Val(Reader("NoMoreAppointmentsInd").ToString) = 1
            CheckBox2.Checked = Val(Reader("CaseStatusID").ToString) = 4
            CheckBox2.Tag = Val(Reader("CaseStatusID").ToString) = 4

        End If
    End Sub

    Private Sub txtComments_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtComments.Validating

    End Sub

    Private Sub ListViewProcedures_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewProcedures.DoubleClick
        Button3_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewProcedures_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewProcedures.ItemCheck

    End Sub

    Private Sub ListViewProcedures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewProcedures.SelectedIndexChanged

    End Sub

    Private Function ScanDocumentFromScanner(ByVal DocProfileID As Integer) As Boolean
        Dim PatientID As Long
        frmDocumentScannerPDF.BillID = BillID
        frmDocumentScannerPDF.DocDisplay = pdfViewer
        frmDocumentScannerPDF.IniDocProfile = DocProfileID
        frmDocumentScannerPDF.PatientID = Val(Me.Tag)
        If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ScanDocumentFromScanner = True
        End If
        frmDocumentScannerPDF.Dispose()
    End Function

    Private Function ScanDocumentFromScannerApplication(ByVal DocProfileID As Integer) As Boolean
        Dim PatientID As Long
        If gScannerFolder = "" Then
            MsgBox("Unable to scan. The Scanner Folder has not been specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Function
        End If
        If IO.Directory.Exists(gScannerFolder) = False Then
            MsgBox("Unable to scan. Invalid Scanner Folder specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Function
        End If
        frmDocumentScannerExternalProgram.BillID = BillID
        frmDocumentScannerExternalProgram.DocDisplay = pdfViewer
        frmDocumentScannerExternalProgram.IniDocProfile = DocProfileID
        frmDocumentScannerExternalProgram.PatientID = Val(Me.Tag)

        If frmDocumentScannerExternalProgram.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ScanDocumentFromScannerApplication = True
        End If
        frmDocumentScannerExternalProgram.Dispose()
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Ret As Boolean
        pdfViewer.Tag = ""
        Me.Opacity = 0
        Application.DoEvents()
        If gScannerMode = 1 Then
            Ret = ScanDocumentFromScannerApplication(9)
        Else
            Ret = ScanDocumentFromScanner(9)
        End If
        If Ret = True Then
            Button1.Enabled = False
            If pdfViewer.Tag <> "" Then
                Me.Width = 1086
                Me.CenterToParent()
            End If
        End If
        Application.DoEvents()
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.1
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        With frmDocumentPreview
            .TextBoxReading.Visible = False
            .pdfViewer.Visible = True
            .pdfViewer.Dock = DockStyle.Fill
            .pdfViewer.LoadDocument(pdfViewer.Tag.ToString())
            .ShowDialog(Me)
        End With
        frmDocumentPreview.Dispose()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim C As Integer
        Dim ret As DialogResult
        If ListViewProcedures.SelectedItems.Count = 0 Then
            MsgBox("Unable to process procedure denial. No Procedure selected.", MsgBoxStyle.Exclamation)
            ListViewProcedures.Focus()
            Exit Sub
        End If
        frmBillingDenialAddEdit.frm = Me
        frmBillingDenialAddEdit.LI = ListViewProcedures.SelectedItems(0)
        frmBillingDenialAddEdit.LV = ListViewProcedures
        ret = frmBillingDenialAddEdit.ShowDialog(Me)
        frmBillingDenialAddEdit.Dispose()
        txtComments.Text = ""
        For Each LI In ListViewProcedures.Items
            If LI.SubItems(3).Text <> "" Then
                C = C + 1
                txtComments.Text = txtComments.Text & C & ". Proc Denied. " & LI.SubItems(3).Text & vbCrLf
            End If
        Next
        If ret = Windows.Forms.DialogResult.OK Then
            TabControl1.SelectedIndex = 1
            Application.DoEvents()
            TabControl1.Refresh()
            Application.DoEvents()
            TabPage2.Refresh()
            Application.DoEvents()
            Button1_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub SetProcedureDenialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetProcedureDenialToolStripMenuItem.Click
        Button3_Click(Nothing, Nothing)
    End Sub

End Class

'Public Class frmBillingDenial
'    Public CalledForm As Object
'    Public BillID As Long
'    Public SLI As ListViewItem
'    Private Sub txtComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged
'        ErrorProvider1.SetError(txtComments, "")
'    End Sub

'    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
'        Dim SQL As String = ""
'        Dim BillComents As String = ""
'        Dim LI As ListViewItem
'        Dim DenialRemoved
'        Dim RemoveDenialsCount As Integer
'        'Try
'        If ListViewProcedures.CheckedItems.Count = 0 Then
'            If DenialsFound > 0 Then
'                If MsgBox("Please confirm you want to remove Denial from unchecked bill procedure(s)?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
'                    Exit Sub
'                End If
'            Else
'                MsgBox("No changes made for update.", MsgBoxStyle.Exclamation)
'                Exit Sub
'            End If
'        Else
'            For Each LI In ListViewProcedures.Items
'                If LI.Checked And CType(LI.SubItems(3).Tag, ValueDescription).Value = 0 Then
'                    LI.Selected = True
'                    LI.EnsureVisible()
'                    MsgBox("Unable to process your request." & vbCrLf & "The procedure " & LI.SubItems(1).Text & " checked as Denial." & vbCrLf & "The Denial Reason should be selected.", MsgBoxStyle.Critical)
'                    ComboBoxDenialReasons.Focus()
'                    Exit Sub
'                End If
'                If Val(LI.SubItems(1).Tag) = 1 And LI.Checked = False Then
'                    RemoveDenialsCount = RemoveDenialsCount + 1
'                End If
'            Next
'            If RemoveDenialsCount > 0 Then
'                If MsgBox("Please confirm you want to remove Denial from " & RemoveDenialsCount & " bill procedure(s)?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
'                    Exit Sub
'                End If
'            End If
'        End If
'        Dim WarningShown As Boolean
'        If CheckBox1.Checked Then
'            If MsgBox("Please confirm this Patient will be set as No More Appointments." & vbCrLf & vbCrLf & "All future scheduled appointments will be deleted.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
'            WarningShown = True
'        Else
'            If CheckBox2.Checked = False Then
'                If MsgBox("Please confirm this Patient will remain Active and future scheduled appointments are accepted.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
'                WarningShown = True
'            End If
'        End If

'        If CheckBox2.Checked And WarningShown = False Then
'            CheckBox1.Checked = True
'            If MsgBox("Please confirm this Patient's profile will be closed." & vbCrLf & vbCrLf & "All future scheduled appointments will be deleted.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
'        End If
'        SQL = "UPDATE PatientProcedures set DenialBackInd=0, DenialDate = Null, Comments='', DeniedInd=0 where PatientProcedureID in (Select PatientProcedureID From BillProcedures where BillID = " & BillID & ")"
'        gSQLUpdateData(SQL)

'        If CheckBox2.Checked Then
'            gSQLUpdateData("UPDATE PATIENTS SET NoMoreAppointmentsInd=1 , CaseStatusDate=getdate(), CaseStatusID=4 where PatientID=" & Val(Me.Tag))
'            gUpdate_Profile_Log(Val(Me.Tag), PatientLogTypes.tStatusChange, "Case Stopped From Maintenance")
'        Else
'            gSQLUpdateData("UPDATE PATIENTS SET NoMoreAppointmentsInd=0 , CaseStatusDate=getdate(), CaseStatusID=1 where PatientID=" & Val(Me.Tag))
'            gUpdate_Profile_Log(Val(Me.Tag), PatientLogTypes.tStatusChange, "Case Reopened From Denial Maintenance")
'            If CheckBox1.Checked Then
'                gSQLUpdateData("UPDATE PATIENTS SET NoMoreAppointmentsInd=1 where PatientID=" & Val(Me.Tag))
'                gUpdate_Profile_Log(Val(Me.Tag), PatientLogTypes.tNoMoreSchedules, "No More Appointments From Denial Maintenance")
'            Else
'                gSQLUpdateData("UPDATE PATIENTS SET NoMoreAppointmentsInd=0 where PatientID=" & Val(Me.Tag))
'                gUpdate_Profile_Log(Val(Me.Tag), PatientLogTypes.tNoMoreSchedules, "No More Appointments Removed From Maintenance")
'            End If
'        End If

'        If CheckBox1.Checked Or CheckBox2.Checked Then
'            gDeleteFutureAppointments(Val(Me.Tag))
'        End If
'        Dim DenialFoundInd As Boolean
'            For Each LI In ListViewProcedures.Items
'                If LI.Checked Then
'                SQL = "UPDATE PatientProcedures set DenialDate = getdate(), DenialBackInd=" & CType(LI.SubItems(3).Tag, ValueDescription).Value1 & ", Comments='" & RBC(CType(LI.SubItems(3).Tag, ValueDescription).Description & IIf(LI.SubItems(3).Text <> "", vbCrLf & RBC(LI.SubItems(3).Text), "")) & "', DeniedInd=" & CType(LI.SubItems(3).Tag, ValueDescription).Value & " where PatientProcedureID = " & LI.Tag
'                    gSQLUpdateData(SQL)
'                    gSetListItemForeColor(LI, Color.Red)
'                gSQLUpdateData("INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) VALUES(" & BillID & ", '" & RBC(LI.SubItems(1).Text & " Denied - " & CType(LI.SubItems(3).Tag, ValueDescription).Description & IIf(LI.SubItems(3).Text <> "", vbCrLf & RBC(LI.SubItems(3).Text), "")) & "', " & gCurrentEmployee.EmpID & ", getdate())")
'                DenialFoundInd = True
'                End If
'        Next
'        If DenialFoundInd Then
'            gSQLUpdateData("UPDATE Bills Set DenialFound=1 where BillID= " & BillID)
'            gSetListItemColor(SLI, Color.PaleGoldenrod)
'        Else
'            gSQLUpdateData("UPDATE Bills Set DenialFound=0 where BillID= " & BillID)
'        End If
'        Me.Close()
'    End Sub
'    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
'        Me.Close()
'    End Sub

'    Private Sub frmBillingDenial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
'        gWindow_Settings(Me, ReadWrite.sWrite)
'    End Sub
'    Private Sub frmAddDiagnos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Load_data()
'        gWindow_Settings(Me, ReadWrite.sRead)
'    End Sub
'    Dim DenialsFound As Integer
'    Private Sub Load_data()
'        Dim Reader As SqlClient.SqlDataReader
'        Dim IDs As String = ""
'        Dim SQL As String
'        Dim LI As ListViewItem

'        Reader = gSQLGetDataReader("SELECT ID, Description, DenialBackInd FROM         BillDenialReasons ORDER BY SortOrder")
'        If Reader Is Nothing Then Exit Sub
'        Do Until Reader.Read = False
'            ComboBoxDenialReasons.Items.Add(New ValueDescription(Reader("ID").ToString, Reader("Description").ToString, Val(Reader("DenialBackInd").ToString)))
'        Loop
'        Reader.Close() : Reader.Dispose()
'        SQL = "SELECT  BillDenialReasons.Description as DenialReason,   PatientProcedures.PatientID, BillProcedures.PatientProcedureID,   Bills.BillAmount, Bills.BillDate, Bills.BillID, PatientProcedures.ProcID, Procedures.ProcName, Schedule.ScheduleDateTime, PatientProcedures.DenialDate, PatientProcedures.Comments, PatientProcedures.DeniedInd, PatientProcedures.DenialBackInd "
'        SQL &= " FROM         Bills INNER JOIN BillProcedures ON Bills.BillID = BillProcedures.BillID INNER JOIN PatientProcedures ON BillProcedures.PatientProcedureID = PatientProcedures.PatientProcedureID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID LEFT OUTER JOIN BillDenialReasons on PatientProcedures.DeniedInd = BillDenialReasons.ID"
'        SQL &= " WHERE BillProcedures.BillID = " & BillID
'        Reader = gSQLGetDataReader(SQL)
'        If Reader Is Nothing Then Exit Sub
'        Do Until Reader.Read = False
'            LI = ListViewProcedures.Items.Add(FormatDateTime(Reader("ScheduleDateTime").ToString, 2))
'            LI.Tag = Val(Reader("PatientProcedureID").ToString)
'            LI.SubItems.Add(Reader("ProcName").ToString).Tag = "1"
'            LI.ToolTipText = Reader("Comments").ToString
'            LI.SubItems.Add(Reader("DenialDate").ToString)
'            LI.SubItems.Add(Reader("Comments").ToString)
'            Me.Tag = Reader("PatientID").ToString
'            lblBillTotal.Text = CDbl(Reader("BillAmount").ToString).ToString("c")
'            lblBillDate.Text = FormatDateTime(Reader("BillDate").ToString, 2)

'            LI.SubItems(3).Tag = New ValueDescription(Val(Reader("DeniedInd").ToString), Reader("DenialReason").ToString, Val(Reader("DenialBackInd").ToString))

'            If Val(Reader("DeniedInd").ToString) > 0 Then
'                DenialsFound = DenialsFound + 1
'                LI.Checked = True
'                gSetListItemForeColor(LI, Color.Red)
'            End If

'        Loop

'        If ListViewProcedures.Items.Count = 1 Then
'            ListViewProcedures.Items(0).Checked = True
'        End If
'        If ListViewProcedures.Items.Count > 0 Then
'            ListViewProcedures.Items(0).Selected = True
'            ListViewProcedures.Items(0).EnsureVisible()
'            ListViewProcedures_SelectedIndexChanged(Nothing, Nothing)
'        End If

'    End Sub

'    Private Sub ComboBoxInsuranceCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDenialReasons.SelectedIndexChanged
'        ErrorProvider1.SetError(ComboBoxDenialReasons, "")
'        If ListViewProcedures.SelectedItems.Count = 0 Then Exit Sub
'        If ComboBoxDenialReasons.SelectedIndex = -1 Then Exit Sub
'        ListViewProcedures.SelectedItems(0).SubItems(3).Tag = New ValueDescription(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value, CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description, Val(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value1))

'    End Sub

'    Private Sub txtComments_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtComments.Validating
'        If ListViewProcedures.SelectedItems.Count > 0 Then
'            ListViewProcedures.SelectedItems(0).SubItems(3).Text = txtComments.Text.Trim
'            If ComboBoxDenialReasons.SelectedIndex > -1 Then ListViewProcedures.SelectedItems(0).SubItems(3).Tag = New ValueDescription(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value, CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description, Val(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value1))
'        End If
'    End Sub

'    Private Sub ListViewProcedures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewProcedures.SelectedIndexChanged
'        If ListViewProcedures.SelectedItems.Count = 0 Then
'            ComboBoxDenialReasons.SelectedIndex = -1
'            txtComments.Text = ""
'            Exit Sub
'        End If
'        If ListViewProcedures.SelectedItems.Count > 0 Then
'            If Val(CType(ListViewProcedures.SelectedItems(0).SubItems(3).Tag, ValueDescription).Value) > 0 Then
'                gFindComboItemByValue(ComboBoxDenialReasons, Val(CType(ListViewProcedures.SelectedItems(0).SubItems(3).Tag, ValueDescription).Value), True)
'            Else
'                ComboBoxDenialReasons.SelectedIndex = -1
'            End If
'            txtComments.Text = ListViewProcedures.SelectedItems(0).SubItems(3).Text
'        End If
'    End Sub
'End Class