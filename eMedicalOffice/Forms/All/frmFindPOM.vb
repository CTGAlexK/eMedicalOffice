Imports System.Reflection
Imports log4net

Public Class frmFindPOM
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        pdfViewer.CloseDocument()
        Find_Data()
    End Sub

    Private Sub Find_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        ListViewPOM.Items.Clear()
        ListViewBills.Items.Clear()
        pdfViewer.Tag = ""
        pdfViewer.CloseDocument()
        Cursor = Cursors.WaitCursor
        SQL = "SELECT DISTINCT POM.POMID, POM.CreatedDT, POM.RegisteredDT "
        SQL &= " FROM POM INNER JOIN Bills ON POM.POMID = Bills.POMID INNER JOIN Patients ON Bills.PatientID = Patients.PatientID"
        SQL &= " WHERE Bills.OfficeID = " & gOfficeID
        If IsNumeric(txtPOMNumber.Text) Then
            SQL &= " AND POM.POMID = " & Val(txtPOMNumber.Text) & " "
        End If

        If IsNumeric(txtBillNumber.Text) Then
            SQL &= " AND Bills.BillID = " & Val(txtBillNumber.Text) & " "
        End If
        If cboInsuranceCompanyID.SelectedIndex > 0 Then
            SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
        End If

        If txtSearch.Text <> "" Then
            If IsNumeric(txtSearch.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(txtSearch.Text) & " "
            Else
                SQL &= " AND (Patients.FName Like '" & txtSearch.Text & "%' or Patients.LName Like '" & txtSearch.Text & "%') "
            End If
        End If

        Reader = gSQLGetDataReader(SQL)
        Cursor = Cursors.Default
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewPOM.Items.Add(Reader("POMID").ToString)
            LI.Tag = Reader("POMID").ToString
            LI.SubItems.Add(Reader("CreatedDT").ToString)
            If Reader("RegisteredDT").ToString = "" Then
                LI.SubItems.Add("Scan Pending")
                LI.ForeColor = Color.Red
            Else
                LI.SubItems.Add(Reader("RegisteredDT").ToString)
            End If

        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewPOM.Items.Count > 0 Then
            ListViewPOM.Items(0).Selected = True
            ListViewPOM.Items(0).EnsureVisible()
            ListViewPOM_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub frmFindPOM_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewPOM, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewBills, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
        pdfViewer.CloseDocument(False)
    End Sub

    Private Sub frmFindPOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        Application.DoEvents()
        gListview_Settings(Me, ListViewPOM, ReadWrite.sRead)
        gListview_Settings(Me, ListViewBills, ReadWrite.sRead)
        pdfViewer.CloseDocument()
        Timer1.Enabled = True
    End Sub

    Private Sub Load_Data()
        Dim I As Integer = 0
        cboInsuranceCompanyID.Items.Clear()
        cboInsuranceCompanyID.Items.Add(New ValueDescription(0, "All"))
        cboInsuranceCompanyID.SelectedIndex = 0
        cboInsuranceCompanyID.DropDownHeight = 106
        Dim Reader As SqlClient.SqlDataReader
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies ORDER BY CompanyName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboInsuranceCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString))
        Loop
        If cboInsuranceCompanyID.Items.Count = 0 Then
            cboInsuranceCompanyID.DropDownHeight = 20
        End If
        Reader.Close() : Reader.Dispose()
        Cursor = Cursors.Default
    End Sub

    Private Sub ListViewPOM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPOM.SelectedIndexChanged
        If ListViewPOM.SelectedItems.Count = 0 Then Exit Sub
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        ListViewBills.Items.Clear()
        Cursor = Cursors.WaitCursor
        SQL = "SELECT     BillID, BillDate FROM Bills WHERE POMID = " & Val(ListViewPOM.SelectedItems(0).Tag)
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                LI = ListViewBills.Items.Add(Reader("BillID").ToString)
                LI.Tag = Reader("BillID").ToString
                If IsDate(Reader("BillDate").ToString) Then
                    LI.SubItems.Add(CDate(Reader("BillDate").ToString).ToShortDateString)
                Else
                    LI.SubItems.Add("")
                End If
            Loop
            Reader.Close() : Reader.Dispose()
        End If
        SQL = "SELECT POMImage FROM POM where POMID=" & Val(ListViewPOM.SelectedItems(0).Tag)
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then
            MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Critical)
            Cursor = Cursors.Default
            Exit Sub
        End If
        If Reader.HasRows Then
            Reader.Read()
            If IsDBNull(Reader("POMImage")) = False Then

                Dim arrayImage() As Byte = CType(Reader("POMImage"), Byte())
                Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", "POM")
                If System.IO.File.Exists(FName) Then
                    Tag = Val(ListViewPOM.SelectedItems(0).Tag)
                    pdfViewer.Tag = FName
                    Application.DoEvents()
                    'pdfViewer.setShowScrollbars(True)
                    Application.DoEvents()
                    pdfViewer.LoadDocument(FName)
                    'pdfViewer.setView("FitH")
                    'pdfViewer.setLayoutMode("SinglePage")
                    Application.DoEvents()
                    pdfViewer.Refresh()
                    'pdfViewer.setShowToolbar(True)
                    Application.DoEvents()
                    pdfViewer.Visible = True
                    ListViewPOM.Focus()
                End If
            Else
                pdfViewer.CloseDocument()
            End If
        Else
            pdfViewer.CloseDocument()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        If pdfViewer.Tag = "" Or ListViewPOM.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No document loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        pdfViewer.PrintDocument(Me)
    End Sub

    Private Sub ButtoneMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtoneMail.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        If pdfViewer.Tag = "" Or ListViewPOM.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No document loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Subject = "Attached: POM #" & ListViewPOM.SelectedItems(0).Text & " PDF File"
        Fname = pdfViewer.Tag
        Try

            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If pdfViewer.Tag = "" Or ListViewPOM.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No document loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        SaveFileDialog1.InitialDirectory = GetSetting(My.Application.Info.ProductName, "Settings", "POMLastFilePath", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))

        If pdfViewer.Tag.ToString().Right(3).ToUpper() = "PDF" Then    ' To keep compatible with previous JPG file versions
            SaveFileDialog1.Filter = "Adobe Acrobat File (*.pdf)|*.pdf"
            SaveFileDialog1.DefaultExt = "pdf"
            SaveFileDialog1.FileName = "POM-" & ListViewPOM.SelectedItems(0).Text & ".pdf"
        Else
            SaveFileDialog1.Filter = "JPEG FIle (*.jpg)|*.jpg"
            SaveFileDialog1.DefaultExt = "jpg"
            SaveFileDialog1.FileName = "POM-" & ListViewPOM.SelectedItems(0).Text & ".jpg"
        End If

        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.AutoUpgradeEnabled = True
        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                If System.IO.File.Exists(SaveFileDialog1.FileName) Then
                    IO.File.Delete(SaveFileDialog1.FileName)
                End If
                If pdfViewer.Tag.ToString().Right(3).ToUpper() = "PDF" Then
                    IO.File.Copy(pdfViewer.Tag, SaveFileDialog1.FileName)
                Else
                    Image.FromFile(pdfViewer.Tag).Save(SaveFileDialog1.FileName)
                End If

                SaveSetting(My.Application.Info.ProductName, "Settings", "POMLastFilePath", System.IO.Path.GetDirectoryName(SaveFileDialog1.FileName))
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try

        End If
    End Sub

    Private Sub cboInsuranceCompanyID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboInsuranceCompanyID.KeyUp
        gComboboxAutoComplete(cboInsuranceCompanyID, e, True)
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        txtPOMNumber.Text = ""
        txtBillNumber.Text = ""
        txtSearch.Text = ""
        cboInsuranceCompanyID.SelectedIndex = 0
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.05
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
            Load_Data()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pdfViewer.Tag = "" Or ListViewPOM.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No document loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        With frmPOMPreview
            .Tag = Tag
            .pdfViewer.Tag = pdfViewer.Tag
            .ShowDialog(Me)
            .Dispose()
        End With
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFax.Click
        If pdfViewer.Tag = "" Or ListViewPOM.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No document loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        gFax(Me, "", "Attached: POM #" & Tag & " PDF File", pdfViewer.Tag, gOfficeFax)
    End Sub

    Private Sub cboInsuranceCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceCompanyID.SelectedIndexChanged

    End Sub

End Class