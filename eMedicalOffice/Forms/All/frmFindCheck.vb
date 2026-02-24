Imports System.Reflection
Imports log4net

Public Class frmFindCheck
    Private m_SortingColumn As ColumnHeader
    Public CalledForm As frmBillingManagement
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmFindCheck_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewChecks, ReadWrite.sWrite)
        pdfViewer.CloseDocument(False)
    End Sub

    Private Sub frmFindCheck_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            Find_Data()
        End If
    End Sub

    Private Sub frmFindCheck_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmFindCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        Application.DoEvents()
        gListview_Settings(Me, ListViewChecks, ReadWrite.sRead)
        Timer1.Enabled = True
        pdfViewer.CloseDocument()
        m_SortingColumn = ListViewChecks.Columns(2)
    End Sub

    Private Sub Load_Data()
        Dim I As Integer = 0
        ListViewChecks.Items.Clear()
        cboInsuranceCompanyID.Items.Clear()
        cboInsuranceCompanyID.Items.Add(New ValueDescription(0, "All"))
        cboInsuranceCompanyID.Items.Add(New ValueDescription(-1, "-----------------------------------------INSURANCE GROUPS-----------------------------------------"))
        cboInsuranceCompanyID.SelectedIndex = 0
        cboInsuranceCompanyID.DropDownHeight = 106
        Dim Reader As SqlClient.SqlDataReader
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Reader = gSQLGetDataReader("SELECT DISTINCT  GroupID, Description FROM InsuranceCompaniesGroups ORDER BY Description")
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                cboInsuranceCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("GroupID").ToString)), Reader("Description").ToString & " - Group", "0"))
            Loop
        End If
        If cboInsuranceCompanyID.Items.Count > 0 Then
            cboInsuranceCompanyID.Items.Add(New ValueDescription(-1, "--------------------------------------INSURANCE COMPANIES--------------------------------------"))
        End If

        Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies ORDER BY CompanyName")
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                cboInsuranceCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString, "1"))
            Loop
        End If
        Reader.Close() : Reader.Dispose()
        Cursor = Cursors.Default
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.05
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
            Load_Data()
        End If
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        txtCheckNumber.Text = ""
        txtBillNumber.Text = ""
        txtSearch.Text = ""
        cboInsuranceCompanyID.SelectedIndex = 0
        ListViewChecks.Items.Clear()
        ListViewDocs.Items.Clear()
        pdfViewer.CloseDocument()
        ToolStripStatusLabel1.Text = ""
        ToolStripStatusLabel2.Text = ""
    End Sub

    Private Sub cboInsuranceCompanyID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboInsuranceCompanyID.KeyUp
        gComboboxAutoComplete(cboInsuranceCompanyID, e, True)
    End Sub

    Private Sub cboInsuranceCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceCompanyID.SelectedIndexChanged
        If cboInsuranceCompanyID.SelectedIndex > -1 Then
            If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value = -1 Then
                cboInsuranceCompanyID.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        Find_Data()
    End Sub

    Private Sub Find_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        Dim SQL As String
        Dim Total As Double
        txtCheckNumber.Text = txtCheckNumber.Text.Trim
        txtBillNumber.Text = txtBillNumber.Text.Trim
        txtSearch.Text = txtSearch.Text.Trim
        SQL = "SELECT Bills.PatientID,    BillPayments.PaymentAmount, BillPayments.CheckNumber, BillPayments.PaymentDate, BillPayments.BillID, Patients.FName + ' ' + Patients.LName + ', ' + Patients.MI AS PName, InsuranceCompanies.CompanyName, Bills.ServiceFrom, Bills.ServiceTo, BillPayments.PaymentID "
        SQL &= " FROM         BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID INNER JOIN Patients ON Bills.PatientID = Patients.PatientID INNER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID "
        SQL &= " WHERE Bills.OfficeID= " & gOfficeID
        If IsNumeric(txtBillNumber.Text) = False And txtBillNumber.Text <> "" Then
            MsgBox("Unable to search. The bill # should be numeric value.")
            txtBillNumber.Focus()
            txtBillNumber.SelectAll()
            Exit Sub
        End If
        ToolStripStatusLabel1.Text = "Seach In Progress. Please Wait..."
        ToolStripStatusLabel2.Text = ""
        Application.DoEvents()
        If txtCheckNumber.Text.Trim <> "" Then
            SQL &= " AND BillPayments.CheckNumber like '" & txtCheckNumber.Text.Trim.ToSafeSQLString() & "%'"
        End If
        Dim PName() As String
        If txtBillNumber.Text.Trim <> "" Then
            SQL &= " AND BillPayments.BillID =  " & Val(txtBillNumber.Text.Trim) & " "
        End If
        If txtSearch.Text <> "" Then
            If IsNumeric(txtSearch.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(txtSearch.Text) & " "
            Else
                PName = Split(txtSearch.Text.Trim.ToSafeSQLString(), " ")
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
        If cboInsuranceCompanyID.SelectedIndex > 0 Then
            If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value1 = "0" Then
                SQL &= " AND Bills.InsCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & ") "
            Else
                SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
            End If
        End If
        ListViewChecks.Items.Clear()
        ListViewChecks.SuspendLayout()
        Application.DoEvents()
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListViewChecks.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            LI = ListViewChecks.Items.Add(Reader("CheckNumber").ToString())
            'LI.SubItems.Add(Val(Reader("PaymentAmount").ToString).ToString("c"))
            SI = LI.SubItems.Add(Math.Round(Val(Reader("PaymentAmount").ToString), 2))
            SI.Tag = Reader("PatientID").ToString
            Total = Total + Val(Reader("PaymentAmount").ToString)
            LI.SubItems.Add(FormatDateTime(Reader("PaymentDate").ToString, DateFormat.ShortDate))
            LI.SubItems.Add(Reader("BillID").ToString())
            LI.SubItems.Add(Reader("PName").ToString())

            If IsDate(Reader("ServiceFrom").ToString) Then
                LI.SubItems.Add(FormatDateTime(Reader("ServiceFrom").ToString, DateFormat.ShortDate) & "  -  " & FormatDateTime(Reader("ServiceTo").ToString, DateFormat.ShortDate))
            Else
                LI.SubItems.Add("")
            End If

            LI.SubItems.Add(Reader("CompanyName").ToString())
        Loop
        ToolStripStatusLabel1.Text = "Checks Found: " & ListViewChecks.Items.Count
        ToolStripStatusLabel2.Text = "Total: " & Total.ToString("c")
        ListViewChecks.ResumeLayout()
    End Sub

    Private Sub txtBillNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBillNumber.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, txtBillNumber, False)
    End Sub

    Private Sub txtBillNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBillNumber.TextChanged

    End Sub

    Private Sub ListViewChecks_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewChecks.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewChecks.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumn.Text =             m_SortingColumn.Text.Mid(2)
            m_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumn.Text = "> " & m_SortingColumn.Text
        'Else
        'm_SortingColumn.Text = "< " & m_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.ImageKey = "SORT1"
        Else
            m_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewChecks.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewChecks.Sort()
    End Sub

    Private Sub ListViewChecks_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewChecks.DoubleClick
        If ListViewChecks.SelectedItems.Count = 0 Then Exit Sub
        If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal
        ListViewChecks.SelectedItems(0).EnsureVisible()
        If CalledForm Is Nothing Then
            frmBillingManagement.MdiParent = MDIForm1Win8
            frmBillingManagement.Size = New Size(MDIForm1Win8.Width, MDIForm1Win8.Height)
            frmBillingManagement.WindowState = FormWindowState.Maximized
            Application.DoEvents()
            frmBillingManagement.Show()
            frmBillingManagement.BringToFront()
            frmBillingManagement.WindowState = FormWindowState.Maximized
            frmBillingManagement.SearchBillID = ListViewChecks.SelectedItems(0).SubItems(3).Text
            frmBillingManagement.ButtonFind_Click(Nothing, Nothing)
            CalledForm = frmBillingManagement
            Me.Owner = frmBillingManagement
        Else
            CalledForm.SearchBillID = ListViewChecks.SelectedItems(0).SubItems(3).Text
            CalledForm.ButtonFind_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub ListViewChecks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewChecks.SelectedIndexChanged
        gHighlightListviewItem(ListViewChecks, True, False)
        Load_Documents()
    End Sub

    Private Sub Load_Documents(Optional ByVal DoNotSelect As Boolean = False)
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim PatID As Long
        Dim SQL As String
        Dim SaveLI As ListViewItem
        ListViewDocs.Items.Clear()

        If ListViewChecks.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim CheckNo As String = ListViewChecks.SelectedItems(0).Text
        PatID = Val(ListViewChecks.SelectedItems(0).SubItems(1).Tag)

        SQL = "SELECT Documents.PatientID,   Documents.DocumentID, Documents.InsertedDate, Documents.DocumentName FROM  Documents Where PatientID=" & PatID & "Order by DocumentID"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewDocs.Items.Add(Reader("DocumentName").ToString)
            If CheckNo.Trim = Reader("DocumentName").ToString.Trim Then
                SaveLI = LI
            End If
            If IsDate(Reader("InsertedDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("InsertedDate")).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add("")
            End If
            LI.Tag = Reader("DocumentID").ToString
            LI.SubItems(1).Tag = Val(Reader("PatientID").ToString)
        Loop
        If ListViewDocs.Items.Count > 0 And DoNotSelect = False Then
            On Error GoTo er
            If SaveLI Is Nothing Then
                ListViewDocs.Items(0).Selected = True
                ListViewDocs.Items(0).EnsureVisible()
            Else
                SaveLI.Selected = True
                SaveLI.EnsureVisible()
            End If
            ListViewDocs_SelectedIndexChanged(Nothing, Nothing)

er:
        End If
    End Sub

    Private Sub ButtonShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub ListViewDocs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewDocs.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        gHighlightListviewItem(ListViewDocs, True, False)
        pdfViewer.CloseDocument()
        pdfViewer.Visible = True
        If ListViewDocs.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        SQL = "SELECT DocumentImage   FROM         Documents Where DocumentID=" & ListViewDocs.SelectedItems(0).Tag
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Cursor = Cursors.Default : Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            If Reader("DocumentImage") Is DBNull.Value Then
                pdfViewer.CloseDocument()
            Else
                Dim arrayImage() As Byte = CType(Reader("DocumentImage"), Byte())
                Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", ListViewDocs.SelectedItems(0).Text)
                If System.IO.File.Exists(FName) Then
                    pdfViewer.BringToFront()
                    pdfViewer.LoadDocument(FName)
                    pdfViewer.Tag = FName
                    pdfViewer.Visible = True

                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButtonSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSaveAs.Click
        Dim Fname As String
        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to save. No document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If System.IO.File.Exists(pdfViewer.Tag) = False Then
            MsgBox("Unexpected Error. Unable to save file. Please select a document and try again.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If pdfViewer.Tag.ToString().Right(3).ToUpper() = "PDF" Then    ' To keep compatible with previous JPG file versions
            SaveFileDialog1.Filter = "Adobe Acrobat File (*.pdf)|*.pdf"
            SaveFileDialog1.DefaultExt = "pdf"
            Fname = ListViewDocs.SelectedItems(0).Text & ".pdf"
        Else
            SaveFileDialog1.Filter = "JPEG FIle (*.jpg)|*.jpg"
            SaveFileDialog1.DefaultExt = "jpg"
            Fname = ListViewDocs.SelectedItems(0).Text & ".jpg"
        End If
        Fname = gFixFileName(Fname)
        SaveFileDialog1.FileName = Fname
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                If pdfViewer.Tag.ToString().Right(3).ToUpper() = "PDF" Then
                    IO.File.Copy(pdfViewer.Tag, SaveFileDialog1.FileName)
                Else
                    Image.FromFile(pdfViewer.Tag).Save(SaveFileDialog1.FileName)
                End If
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try

            Dim P As New ProcessStartInfo()
            With P
                .FileName = SaveFileDialog1.FileName
                .UseShellExecute = True
            End With
            Process.Start(P)
        End If
    End Sub

    Private Sub ToolStripButtonEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonEmail.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to send email. No document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewChecks.SelectedItems.Count > 0 Then
            Subject = "Message From " & gOfficeName & " / Patient: " & ListViewChecks.SelectedItems(0).SubItems(4).Text
        Else
            Subject = "Message From " & gOfficeName
        End If
        If ListViewDocs.SelectedItems.Count > 0 Then
            Subject &= " / Attached: " & ListViewDocs.SelectedItems(0).Text
        End If

        Try

            Msg.SendMail(pdfViewer.Tag.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        With frmDocumentPreview
            .TextBoxReading.Visible = False
            .pdfViewer.Visible = True
            .pdfViewer.LoadDocument(pdfViewer.Tag.ToString())
            .ShowDialog(Me)
        End With
        frmDocumentPreview.Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        pdfViewer.PrintDocument(Me)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If ListViewChecks.SelectedItems.Count = 0 Then
            MsgBox("Unable to show the Bill Information. No Check Payment selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        ListViewChecks_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim LI As ListViewItem
        If ListViewChecks.SelectedItems.Count = 0 Then
            MsgBox("Unable to show the Patient's Information. No Check Payment selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewChecks.SelectedItems(0)
        Using Frm As New frmPatient

            Frm.InitialTab = 0
            Frm.InitialPatientName = LI.SubItems(1).Tag
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.ShowDialog(Me)
        End Using
        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    frm.WindowState = FormWindowState.Normal
        '    frm.BringToFront()
        '    Exit Sub
        'Else
        '    frmPatient.InitialTab = 0
        '    frmPatient.InitialPatientName = LI.SubItems(1).Tag
        '    frmPatient.ShowDialog(Me)
        'End If
    End Sub

    Private Sub IExplorer1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

End Class