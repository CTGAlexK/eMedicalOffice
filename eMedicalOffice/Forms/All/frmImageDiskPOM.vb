Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmImageDiskPOM
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmImageDiskPOM_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewCDs, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
        pdfViewer.CloseDocument(False)
    End Sub

    Private Sub frmImageDiskPOM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            Load_Requests()
        End If
    End Sub

    Private Sub frmImageDiskProcessing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
        gListview_Settings(Me, ListViewCDs, ReadWrite.sRead)
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead)
        gWindow_Settings(Me, ReadWrite.sRead)
        pdfViewer.CloseDocument()
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""

        cboPOM.Items.Add(New ValueDescription(0, "Show All"))
        cboPOM.Items.Add(New ValueDescription(1, "No POM"))
        cboPOM.Items.Add(New ValueDescription(2, "POM"))
        cboPOM.SelectedIndex = 0
        cboRecepient.Items.Clear()
        SQL = "SELECT DISTINCT Recepient From ImageDiskRequests where ImageDiskRequests.OfficeID = " & gOfficeID & " Order By Recepient"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboRecepient.Items.Add(StrConv(Reader("Recepient").ToString, VbStrConv.ProperCase))
        Loop
        Reader.Close() : Reader.Dispose()
        'Setup_Combo()
    End Sub

    Private Sub Load_Requests()
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        On Error GoTo er
        LastPOMID = 0
        ListViewCDs.Items.Clear()
        ListViewProcedures.Items.Clear()
        LabelInvoices.Text = "Search in Progress..."
        If pdfViewer.Tag <> "" Then
            pdfViewer.CloseDocument()
            pdfViewer.Tag = ""
        End If
        If txtPOMNo.Text <> "" And IsNumeric(txtPOMNo.Text) = False Then
            MsgBox("Invalid POM number. The POM NUmber should be numeric value.")
            txtPOMNo.Focus()
            Exit Sub
        End If
        Dim PName() As String
        SQL = "SELECT     CDPOM.POMImage, ImageDiskRequests.POMID, ImageDiskRequests.RequestTypeID, ImageDiskRequests.PaidAmount, ImageDiskRequests.InvoiceAmount, ImageDiskRequests.ID, ImageDiskRequests.RequestDT, ImageDiskRequestsStatuses.Description AS Status, ImageDiskRequests.StatusID, ImageDiskRequests.Recepient, Patients.FName + ' ' + Patients.LName AS PName "
        SQL &= " FROM         ImageDiskRequests INNER JOIN "
        SQL &= "                       ImageDiskRequestsStatuses ON ImageDiskRequests.StatusID = ImageDiskRequestsStatuses.StatusID INNER JOIN "
        SQL &= "                       Patients ON ImageDiskRequests.PatientID = Patients.PatientID LEFT OUTER JOIN "
        SQL &= "                       CDPOM ON ImageDiskRequests.POMID = CDPOM.POMID "
        SQL &= " WHERE ImageDiskRequests.OfficeID=" & gOfficeID & " "
        If txtrequestID.Text.Trim <> "" Then
            If IsNumeric(txtrequestID.Text) Then
                SQL &= " AND ImageDiskRequests.ID = " & Val(txtrequestID.Text.Trim)
                GoTo Search
            Else
                PName = Split(txtrequestID.Text.ToSafeSQLString(), " ")
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
        If IsNumeric(txtPOMNo.Text.Trim) And txtPOMNo.Text <> "" Then
            SQL &= " AND ImageDiskRequests.POMID  = " & Val(txtPOMNo.Text.Trim) & " "
            GoTo Search
        End If

        If cboPOM.SelectedIndex = 1 Then
            SQL &= " AND (ImageDiskRequests.POMID = 0 or ImageDiskRequests.POMID IS NULL) "
        ElseIf cboPOM.SelectedIndex = 2 Then
            SQL &= " AND (ImageDiskRequests.POMID <> 0 and ImageDiskRequests.POMID IS NOT NULL) "
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
Search:
        SQL &= " ORDER BY ImageDiskRequests.ID "
        Reader = gSQLGetDataReader(SQL)
        Dim R As Integer = 0
        Dim LI As ListViewItem
        ListViewCDs.Items.Clear()
        Dim LIS As ListViewItem.ListViewSubItem
        Do Until Reader.Read = False
            LI = ListViewCDs.Items.Add(Reader("ID").ToString)
            LI.Tag = Reader("ID").ToString
            LI.SubItems.Add(FormatDateTime(Reader("RequestDT").ToString, DateFormat.GeneralDate))
            LI.SubItems.Add(Reader("Recepient").ToString)
            LI.SubItems.Add(Reader("PName").ToString)
            LI.SubItems.Add(Reader("InvoiceAmount").ToString)
            LI.SubItems.Add(Reader("Status").ToString)
            LI.SubItems.Add(Reader("POMID").ToString)
            If Val(Reader("POMID").ToString) > 0 Then
                If Reader("POMImage") Is DBNull.Value Then
                    LIS = LI.SubItems.Add("POM Scan Pending")
                    LIS.Tag = DBNull.Value
                    gSetListItemColor(LI, Color.DarkOrange)
                    'gSetListItemForeColor(LI, Color.White)
                Else
                    gSetListItemColor(LI, Color.MediumAquamarine)
                    gSetListItemForeColor(LI, Color.White)
                    LIS = LI.SubItems.Add("Complete")
                    LIS.Tag = Reader("POMImage").ToString
                End If
            Else
                LIS = LI.SubItems.Add("No POM")
                LIS.Tag = DBNull.Value
            End If
        Loop

        If ListViewCDs.Items.Count > 0 Then
            LabelInvoices.Text = ListViewCDs.Items.Count & " Invoice(s)"
            ListViewCDs.Items(0).Selected = True
            ListViewCDs.Items(0).EnsureVisible()
            Load_Procedures(Val(ListViewCDs.Items(0).Tag))
        Else
            LabelInvoices.Text = "No Invoices Found"
        End If
        Exit Sub
er:
        MsgBox(Err.Description, MsgBoxStyle.Exclamation)

    End Sub

    Private Sub Load_Procedures(ByVal RequestID As Integer)
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        Dim ID As Long
        Dim LI As ListViewItem
        SQL = "SELECT   ImageDiskProcedures.ID, Procedures.ProcName, ImageDiskProcedureStatuses.Description AS Status, ImageDiskProcedures.StatusID"
        SQL &= " FROM         ImageDiskProcedures INNER JOIN PatientProcedures ON ImageDiskProcedures.PatientProcedureID = PatientProcedures.PatientProcedureID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN ImageDiskProcedureStatuses ON ImageDiskProcedures.StatusID = ImageDiskProcedureStatuses.StatusID "
        SQL &= " WHERE ImageDiskProcedures.RequestID  = " & RequestID
        Reader = gSQLGetDataReader(SQL)
        Dim R As Integer = 0
        ListViewProcedures.Items.Clear()
        Do Until Reader.Read = False
            LI = ListViewProcedures.Items.Add(Reader("ProcName").ToString)
            LI.SubItems.Add(Reader("Status").ToString)

        Loop
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label7.Text = "Checked: 0"
        Load_Requests()
        LastPOMID = 0
        ErrorProvider1.SetError(lblError1, "")
        ErrorProvider1.SetError(lblError2, "")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtPOMNo.Text = ""

        txtrequestID.Text = ""
        cboPOM.SelectedIndex = 1
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        ListViewCDs.Items.Clear()
        ListViewProcedures.Items.Clear()
        cboRecepient.Text = ""
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cboRecepient_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRecepient.KeyUp
        gComboboxAutoComplete(cboRecepient, e, True)
    End Sub

    Private Sub cboRecepient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRecepient.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmImageDiskReport.ShowDialog(Me)
        frmImageDiskReport.Dispose()
    End Sub

    Private Sub ListViewCDs_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewCDs.ItemChecked
        If e.Item.BackColor = Color.MediumAquamarine And e.Item.Checked Then
            MsgBox("Unable to create POM for this Disk. The POM is already created.", MsgBoxStyle.Exclamation)
            e.Item.Checked = False
            ListViewCDs.Focus()
        End If
        Label7.Text = "Checked: " & ListViewCDs.CheckedItems.Count

    End Sub

    Private Sub ListViewCDs_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewCDs.LostFocus

    End Sub

    Private LastPOMID As Long

    Private Sub ListViewCDs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewCDs.SelectedIndexChanged
        Dim reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim POMID As Long
        'gHighlightListviewItem(ListViewCDs, False, True)
        If ListViewCDs.SelectedItems.Count > 0 Then
            Load_Procedures(Val(ListViewCDs.SelectedItems(0).Tag))
            If ListViewCDs.SelectedItems(0).SubItems(7).Tag Is DBNull.Value Then
                If pdfViewer.Tag <> "" Then
                    pdfViewer.CloseDocument()
                    pdfViewer.Tag = ""
                    LastPOMID = 0
                End If
                lblFileSize.Text = ""
            Else
                If IsNumeric(ListViewCDs.SelectedItems(0).SubItems(6).Text) Then
                    POMID = Val(ListViewCDs.SelectedItems(0).SubItems(6).Text)
                    If POMID <> LastPOMID Then
                        SQL = "SELECT POMImage from CDPOM where POMID = " & POMID
                        LastPOMID = POMID
                        reader = gSQLGetDataReader(SQL)
                        If reader.HasRows Then
                            reader.Read()

                            Dim arrayImage() As Byte = CType(reader("POMImage"), Byte())
                            Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", "CDPOM")
                            If System.IO.File.Exists(FName) Then
                                pdfViewer.LoadDocument(FName)
                                pdfViewer.Tag = FName
                                Dim MyFile As IO.FileInfo
                                MyFile = New IO.FileInfo(FName)
                                lblFileSize.Text = gFormatFileSize(MyFile.Length)
                                Cursor = Cursors.Default
                            End If
                        Else
                            If pdfViewer.Tag <> "" Then
                                pdfViewer.CloseDocument()
                                pdfViewer.Tag = ""
                                LastPOMID = 0
                            End If
                        End If
                    End If
                Else
                    If pdfViewer.Tag <> "" Then
                        pdfViewer.CloseDocument()
                        pdfViewer.Tag = ""
                        LastPOMID = 0
                    End If
                End If
            End If
        End If
        ListViewCDs.Focus()
    End Sub

    Private Sub ButtonCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCompleted.Click

        Dim LI As ListViewItem
        Dim CDID() As String = Nothing
        Dim I As Integer = 0
        Dim BP As New Hashtable
        If ListViewCDs.CheckedItems.Count = 0 Then
            MsgBox("Unable to produce POM. No CD Invoices checked." & vbCrLf & "Please check the CD Invoice(s) and try again.", MsgBoxStyle.Critical)
            ListViewCDs.Focus()
            Exit Sub
        End If
        'If ListViewCDs.CheckedItems.Count > 12 Then
        '    MsgBox("Unable to produce POM. No More then 12 CD Invoices can be printed on one POM.", MsgBoxStyle.Critical)
        '    ListViewCDs.Focus()
        '    Exit Sub
        'End If

        For Each LI In ListViewCDs.CheckedItems
            If LI.SubItems(2).Text = "" Then
                LI.Selected = True
                LI.EnsureVisible()
                MsgBox("Unable to produce Proof Of Mail for the CD Request if the recipient is not specified.", MsgBoxStyle.Exclamation)
                ListViewCDs.Focus()
                Exit Sub
            End If
        Next

        For Each LI In ListViewCDs.CheckedItems
            If BP.Contains("BP" & LI.SubItems(2).Tag) = False Then
                BP.Add("BP" & LI.SubItems(2).Tag, 0)
            End If
            BP.Item("BP" & LI.SubItems(2).Tag) += 1
        Next
        For I = 0 To BP.Values.Count - 1
            If BP.Values(I) > 15 Then
                MsgBox("Unable to produce POM." & vbCrLf & vbCrLf & "No More then 15 Invoices can be printed on one POM" & vbCrLf & "per Billing Provider", MsgBoxStyle.Critical)
                ListViewCDs.Focus()
                Exit Sub
            End If
        Next
        I = 0

        For Each LI In ListViewCDs.CheckedItems
            ReDim Preserve CDID(I)
            CDID(I) = Val(LI.Tag)
            I = I + 1
        Next

        gSQLUpdateData("INSERT INTO CDPOM (CreateBy) VALUES(" & gCurrentEmployee.EmpID & ")")
        Dim POMID As Long = gSQLGetSingleValue("Select IDENT_CURRENT('CDPOM')")

        frmCDPOM.Setup_report(CDID, POMID)
        frmCDPOM.ShowDialog(Me)
        frmCDPOM.Dispose()
        If MsgBox("The POM Registration Number has been generated." & vbCrLf & "Please confirm Image CD POM has been printed.", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            gSQLUpdateData("UPDATE ImageDiskRequests SET POMID=" & POMID & " WHERE ID in (" & String.Join(", ", CDID) & ")")
            For Each LI In ListViewCDs.CheckedItems
                gSetListItemColor(LI, Color.MediumAquamarine)
                gSetListItemForeColor(LI, Color.White)
                LI.SubItems(6).Text = POMID
                LI.SubItems(6).Tag = POMID
            Next
        Else
            gSQLUpdateData("DELETE FROM POM WHERE POMID=" & POMID)
            MsgBox("The CD POM Registration Number has been deleted." & vbCrLf & "If generated POM was printed, it should be destroyed.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub ButtonLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLabels.Click
        Dim CR As ReportDocument
        Dim InvoiceID As String
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim I As Integer = 0
        If ListViewCDs.CheckedItems.Count = 0 And ListViewCDs.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce Shipping Labels. No CD Invoices checked /selected." & vbCrLf & "Please check the CD Invoice(s) and try again.", MsgBoxStyle.Critical)
            ListViewCDs.Focus()
            Exit Sub
        End If
        ButtonLabels.Enabled = False

        If ListViewCDs.CheckedItems.Count = 0 Then
            Dim LI As ListViewItem
            InvoiceID = Val(ListViewCDs.SelectedItems(0).Tag)
            Try
                If gCDEnvelopeLabelType = 1 Then
                    CR = New rptImageDiskEnvelopeLabel
                Else
                    CR = New rptCDShippingLabel
                End If

                If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
                CR.SetParameterValue("CDInvoiceID", InvoiceID)
                If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
                CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
                CR.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
            CR = Nothing
        Else
            Dim LI As ListViewItem
            For Each LI In ListViewCDs.CheckedItems
                InvoiceID = Val(LI.Tag)
                Try
                    If gCDEnvelopeLabelType = 1 Then
                        CR = New rptImageDiskEnvelopeLabel
                    Else
                        CR = New rptCDShippingLabel
                    End If

                    If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
                    CR.SetParameterValue("CDInvoiceID", InvoiceID)
                    If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
                    CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
                    CR.PrintToPrinter(1, False, 0, 0)
                Catch ex As Exception
                    TopMost = False
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    log.Error(ex.Message, ex)
                End Try
                CR = Nothing
            Next
        End If

        Cursor = Cursors.Default
        ButtonLabels.Enabled = True
    End Sub

    Private Sub IExplorer1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        pdfViewer.Visible = True
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to print POM" & vbCrLf & "No POM image is loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        pdfViewer.PrintDocument(Me)
    End Sub

    Public SelectedEmailRecipient As Integer

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Reader As SqlClient.SqlDataReader
        Dim EmailAddress As String
        If ListViewCDs.SelectedItems.Count = 0 Then
            MsgBox("Unable to send email. No document selected.", MsgBoxStyle.Exclamation)
            ListViewCDs.Focus()
            Exit Sub
        End If
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to email POM" & vbCrLf & "No POM image is loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Subject = "Message From " & gOfficeName & " Image Disk Proof Of Mail for Patient: " & ListViewCDs.SelectedItems(0).SubItems(3).Text
        Reader = gSQLGetDataReader("SELECT     Bills.AttorneyCompanyID, Attorneys.CompanyName, Attorneys.eMail FROM ImageDiskRequests INNER JOIN Bills ON ImageDiskRequests.BillID = Bills.BillID INNER JOIN Attorneys ON Bills.AttorneyCompanyID = Attorneys.CompanyID WHERE ImageDiskRequests.ID = " & Val(ListViewCDs.SelectedItems(0).Tag))
        SelectedEmailRecipient = -1
        If Not Reader Is Nothing Then
            If Reader.HasRows Then
                Reader.Read()
                If Reader("eMail").ToString <> "" Then
                    frmImageDiskPOMEmailAddress.RadioButton1.Text = Reader("CompanyName").ToString
                    frmImageDiskPOMEmailAddress.CalledForm = Me
                    frmImageDiskPOMEmailAddress.ShowDialog(Me)
                    frmImageDiskPOMEmailAddress.Dispose()
                    If SelectedEmailRecipient = -1 Then
                        Exit Sub
                    End If
                    If SelectedEmailRecipient = 1 Then
                        EmailAddress = Reader("eMail").ToString
                    End If
                End If
            End If
        End If
        Try
            Dim fileAttachements(0) As String
            fileAttachements(0) = pdfViewer.Tag
            Msg.SendMail(fileAttachements, Subject, Subject, EmailAddress)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

End Class