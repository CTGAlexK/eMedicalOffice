Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Enterprise
Imports log4net

Public Class frmAttorneyDocumentsAccess
    Public PatientID As Integer
    Public BillID As Integer
    Public BillStatusID As Integer
    Public SaveCaseType As Integer
    Public AttorneyID As Integer
    Public AttorneyName As String
    Public AttorneyIndex As Integer
    Public CalledLI As ListViewItem
    Private m_SortingColumn As ColumnHeader
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmAttorneyDocumentsAccess_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewDocs, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewLog, ReadWrite.sWrite)
        If RadioButton2.Checked = True Then
            gAppConfig.SaveSetting("LastArbitrationLetigation", 1)
        Else
            gAppConfig.SaveSetting("LastArbitrationLetigation", 0)
        End If
        pdfViewer.CloseDocument(False)
    End Sub

    Private Sub frmAttorneyDocumentsAccess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'gWindow_Settings(Me, ReadWrite.sRead)
        gListview_Settings(Me, ListViewDocs, ReadWrite.sRead)
        gListview_Settings(Me, ListViewLog, ReadWrite.sRead)
        If gAppConfig.GetValueInt("LastArbitrationLetigation", 0) = 0 Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If

        Load_Data()

        If AttorneyID > 0 Then
            gFindComboItemByValue(cboAttorneysCompanyID, AttorneyID, True)
            PanelAttorney.Visible = False
        Else
            cboAttorneysCompanyID.SelectedIndex = AttorneyIndex
            PanelAttorney.Visible = True
            TextBoxComments.Text = "Please process this bill and assign your computer system [Attorney Case #] ASAP. Thanks."
        End If
        TimerLoadDocuments.Enabled = True
        lblDemo.Visible = Not SystemFunctions.WebAttorneyDocuments
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim DisMsg As String
        Try
            With cboAttorneysCompanyID.Items
                .Clear()
                If AttorneyID = 0 Then
                    Reader = gSQLGetDataReader("Select ActiveInd, CompanyID, CompanyName, AttorneyFName+' '+AttorneyLName as AttorneyName from Attorneys INNER JOIN WebLogins ON Attorneys.CompanyID = WebLogins.UserID AND Attorneys.OfficeID = WebLogins.OfficeID Where UserTypeID = 6 and ActiveInd=1 and Attorneys.OfficeID=" & gOfficeID)
                Else
                    cboAttorneysCompanyID.Enabled = False
                    Reader = gSQLGetDataReader("Select ActiveInd, CompanyID, CompanyName, AttorneyFName+' '+AttorneyLName as AttorneyName from Attorneys INNER JOIN WebLogins ON Attorneys.CompanyID = WebLogins.UserID AND Attorneys.OfficeID = WebLogins.OfficeID Where UserTypeID = 6 and Attorneys.OfficeID=" & gOfficeID)
                End If
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    DisMsg = ""
                    If Val(Reader("ActiveInd").ToString) = 0 Then
                        DisMsg = "     [Not Active]"
                    End If
                    .Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString & " - " & Reader("AttorneyName").ToString & DisMsg))
                Loop
            End With
            Reader.Close() : Reader.Dispose()

        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim AddDocuments As String
        Dim RemoveDocuments As String
        Dim Message As String
        Dim MessageComplete As String
        Dim LI As ListViewItem
        Dim Doc As DocInfo
        Dim SQL As String
        Dim AccessDate As String = Now.Date.ToShortDateString
        Dim UpdateDocOnly As Boolean
        If PanelNoMoreCollection.Visible Then
            If MsgBox("Attention!" & vbCrLf & "This Bill is marked as No More Collection!" & "Please confirm your action?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If cboAttorneysCompanyID.SelectedIndex = -1 Then
            MsgBox("Unable to process your request." & vbCrLf & "No Attorney Selected", MsgBoxStyle.Exclamation)
            cboAttorneysCompanyID.Focus()
            Exit Sub
        End If
        Dim SelectedAttorneyID As Integer = CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value
        Dim AttorneyName As String = CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Description
        Dim RemoveCount As Integer
        Dim AddCount As Integer
        For Each LI In ListViewDocs.CheckedItems
            If LI.SubItems(1).Text = "" Then
                AddDocuments &= vbCrLf & LI.Text
                AddCount = AddCount + 1
            End If
        Next

        For Each LI In ListViewDocs.Items
            If LI.Checked = False And LI.SubItems(1).Text <> "" Then
                RemoveDocuments &= vbCrLf & LI.Text
                RemoveCount = RemoveCount + 1
            End If
        Next
        If AddDocuments = "" And RemoveDocuments = "" Then
            If TextBoxComments.Tag = TextBoxComments.Text Then
                MsgBox("Unable to process your request. Nothing changed.", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                UpdateDocOnly = True
            End If
        End If

        If UpdateDocOnly = False Then
            If AddCount > 10 Then
                If AddDocuments <> "" Then
                    Message &= vbCrLf & "Grant Access to the " & AddCount & " documents."
                    MessageComplete &= vbCrLf & "Access has been Granted to the " & AddCount & " documents."
                End If
            Else
                If AddDocuments <> "" Then
                    Message &= vbCrLf & "Grant Access to the following documents:"
                    Message &= AddDocuments & vbCrLf
                    MessageComplete &= vbCrLf & "Access has been Granted to the following documents:"
                    MessageComplete &= AddDocuments & vbCrLf

                End If
            End If
            If RemoveCount > 10 Then
                If RemoveDocuments <> "" Then
                    Message &= vbCrLf & "Suspend Access to " & RemoveCount & " documents."
                    MessageComplete &= vbCrLf & "Access to " & RemoveCount & " documents has been Suspended."
                End If
            Else
                If RemoveDocuments <> "" Then
                    Message &= vbCrLf & "Suspend Access to the following documents:"
                    Message &= RemoveDocuments & vbCrLf
                    MessageComplete &= vbCrLf & "Access to the following documents has been Suspended:"
                    MessageComplete &= RemoveDocuments & vbCrLf

                End If
            End If
            Message &= vbCrLf & vbCrLf & "To Attorney:" & vbCrLf
            Message &= cboAttorneysCompanyID.Text & vbCrLf & vbCrLf
            Message &= vbCrLf & vbCrLf & "Attention: Before releasing any medical records, the patient should sign an appropriate release authorizing the disclosure of information."
            If PanelAttorney.Visible = True And CheckBoxAttorney.Checked Then
                Message &= vbCrLf & vbCrLf & "The Attorney - " & cboAttorneysCompanyID.Text & vbCrLf & "will be assigned to the Bill # " & BillID
            End If
            If AddDocuments <> "" Or RemoveDocuments <> "" Then
                If MsgBox("Please confirm you want to:" & vbCrLf & Message, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            If SystemFunctions.WebAttorneyDocuments = False Then
                MsgBox("Attention:" & vbCrLf & "This function is in the Demo Mode. No updates allowed." & vbCrLf & vbCrLf & "Please contact the Software Developer to obtain the proper license to use this function.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            For Each LI In ListViewDocs.Items
                Doc = CType(LI.Tag, DocInfo)
                If LI.Checked Then
                    If Doc.WebDocID = 0 Then
                        SQL = "INSERT INTO AttorneyDocumentsAccess "
                        SQL &= "(StatusID, StatusDate, AttorneyID, DocumentID, DocumentProfileID, PatientID, BillID, DocName, AccessDate, CreatedBy) "
                        SQL &= " VALUES (0,'" & AccessDate & "', " & SelectedAttorneyID & ", " & Doc.DocumentID & ", " & Doc.DocumentProfileID & ", " & PatientID & ", " & BillID & ", '" & Doc.DocumentName.ToSafeSQLString() & "', '" & AccessDate & "', " & gCurrentEmployee.EmpID & ")"
                        gSQLUpdateData(SQL)
                        Doc.WebDocID = gSQLGetSingleValue("Select IDENT_CURRENT('AttorneyDocumentsAccess')")
                        CType(LI.Tag, DocInfo).WebDocID = Doc.WebDocID
                        LI.SubItems(1).Text = AccessDate
                        LI.SubItems(2).Text = "New"
                        '''!!!
                        SQL = "INSERT INTO AttorneyDocumentsAccessLog (BillID, WebDocID, DocumentName , StatusID, StatusDate, ChangedBy) VALUES(" & BillID & ", " & Doc.WebDocID & ", '" & Doc.DocumentName.ToSafeSQLString() & "',0, getdate(), '" & gCurrentEmployee.FName & " " & gCurrentEmployee.LName & "')"
                        gSQLUpdateData(SQL)
                    End If
                Else
                    If Doc.WebDocID > 0 Then
                        SQL = "INSERT INTO AttorneyDocumentsAccessLog (BillID, WebDocID, DocumentName, StatusID, StatusDate, ChangedBy) VALUES(" & BillID & ", " & Doc.WebDocID & ", '" & Doc.DocumentName.ToSafeSQLString() & "',3, getdate(), '" & gCurrentEmployee.FName & " " & gCurrentEmployee.LName & "')"
                        gSQLUpdateData(SQL)
                        SQL = "DELETE From AttorneyDocumentsAccess Where WebDocID = " & Doc.WebDocID
                        gSQLUpdateData(SQL)
                        LI.SubItems(1).Text = ""
                        LI.SubItems(2).Text = ""
                        CType(LI.Tag, DocInfo).WebDocID = 0
                    End If
                End If
            Next
            If PanelAttorney.Visible = True And CheckBoxAttorney.Checked Then
                Dim BillStatus As String
                Dim StatusID As Integer
                If RadioButton1.Checked Then
                    BillStatus = "Attorney L"
                    StatusID = 4
                Else
                    BillStatus = "Attorney A"
                    StatusID = 5
                End If
                With CalledLI
                    gSQLUpdateData("Update Bills set AttorneyCaseNumber=Null, AttorneyCaseNumberDate=Null, BillStatusID=" & StatusID & ", AttorneyDate = getdate(), AttorneyCompanyID = " & SelectedAttorneyID & " WHERE BillID = " & BillID)

                    gUpdate_Profile_Log(PatientID, PatientLogTypes.tAttorneyAssigned, "Attorney Assigned. Bill Status:" & BillStatus)
                    If BillStatusID <> 3 Then
                        .SubItems(9).BackColor = Color.DarkOrange
                        .SubItems(9).Text = BillStatus
                        .SubItems(9).Tag = StatusID
                    End If
                    .SubItems(12).Text = AttorneyName
                    .SubItems(12).Tag = SelectedAttorneyID
                    .SubItems(19).Text = ""
                    .SubItems(26).Text = ""
                    .SubItems(13).Text = Now.ToShortDateString
                    .SubItems(19).BackColor = Color.PeachPuff
                    .SubItems(26).BackColor = Color.PeachPuff
                End With
                PanelAttorney.Visible = False
                AttorneyID = SelectedAttorneyID
            End If
            TabControl1_SelectedIndexChanged(Nothing, Nothing)
        End If
        If ListViewDocs.CheckedItems.Count = 0 Then TextBoxComments.Text = ""
        If TextBoxComments.Text.Trim <> TextBoxComments.Tag.Trim Then
            gSQLDeleteRecord("delete from AttorneyDocumentsComments where BillID=" & BillID & " and AttorneyID=" & SelectedAttorneyID)
            If TextBoxComments.Text.Trim <> "" Then
                gSQLUpdateData("INSERT INTO AttorneyDocumentsComments (BillID, AttorneyID, Comment) values(" & BillID & ", " & SelectedAttorneyID & ", '" & TextBoxComments.Text.Trim.ToSafeSQLString() & "')")
                If UpdateDocOnly Then
                    MsgBox("The Attorney message has been updated.", MsgBoxStyle.Information)
                End If
            Else
                If UpdateDocOnly Then
                    MsgBox("The Attorney message has been removed.", MsgBoxStyle.Information)
                End If
            End If
        End If
        TextBoxComments.Tag = TextBoxComments.Text.Trim
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tOther, MessageComplete)
        'If MessageComplete <> "" Then
        '    MsgBox("Update Complete." & vbCrLf & vbCrLf & MessageComplete, MsgBoxStyle.Information)
        'End If
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Load_Documents()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewDocs.Items.Clear()
        Loading = True
        Try
            'SQL = "SELECT     DocumentID, PatientID, DocumentName, DocumentProfileID, InsertedDate FROM         Documents Where PatientID=" & PatientID & "Order by DocumentID"

            SQL = "SELECT DocumentID, PatientID, DocumentName, DocumentProfileID, InsertedDate FROM Documents WHERE DocumentProfileID <> 99 and DocumentProfileID <> 98  and PatientID = " & PatientID & " ORDER BY DocumentID"

        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                LI = ListViewDocs.Items.Add(Reader("DocumentName").ToString.Trim)
                LI.SubItems.Add("")
                LI.SubItems.Add("")
                LI.Tag = New DocInfo(Val(Reader("DocumentID").ToString), Val(Reader("DocumentProfileID").ToString), Reader("DocumentName").ToString.Trim, 0)
            Loop
        End If
        ' POM's
        If chkAllPOMs.Checked Then
            SQL = "SELECT  DISTINCT  Bills.BillID, POM.CreatedDT, POM.POMID,  Bills.ServiceFrom, Bills.ServiceTo FROM POM INNER JOIN Bills ON POM.POMID = Bills.POMID WHERE Bills.PatientID = " & PatientID
        Else
            SQL = "SELECT  DISTINCT  Bills.BillID, POM.CreatedDT, POM.POMID FROM POM INNER JOIN Bills ON POM.POMID = Bills.POMID WHERE (POMImage IS NOT NULL) and Bills.PatientID = " & PatientID & " and Bills.BillID = " & BillID
        End If
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                If chkAllPOMs.Checked Then
                    Dim sFrom As String
                    Dim sTo As String
                    If IsDate(Reader("ServiceFrom")) Then
                        sFrom = CDate(Reader("ServiceFrom")).ToString("MM/dd")
                    End If
                    If IsDate(Reader("ServiceTo")) Then
                        sTo = CDate(Reader("ServiceTo")).ToString("MM/dd")
                    End If

                    LI = ListViewDocs.Items.Add("POM - " & Reader("BillID").ToString & " " & sFrom & " - " & sTo)
                Else
                    LI = ListViewDocs.Items.Add("POM")
                End If
                LI.ForeColor = Color.Blue
                LI.SubItems.Add("")
                LI.SubItems.Add("")
                LI.Tag = Reader("POMID").ToString
                LI.Tag = New DocInfo(Val(Reader("POMID").ToString), 6, "POM", 0)
            Loop
        End If
        ' CDPOM's
        SQL = "SELECT  ImageDiskRequests.BillID, CDPOM.POMID, CDPOM.CreatedDT, CDPOM.CreateBy, CDPOM.RegisteredDT, CDPOM.RegisteredBy, CDPOM.POMImage, CDPOM.TS FROM CDPOM INNER JOIN ImageDiskRequests ON CDPOM.POMID = ImageDiskRequests.POMID WHERE (POMImage IS NOT NULL) and ImageDiskRequests.PatientID = " & PatientID & " and ImageDiskRequests.BillID = " & BillID
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                LI = ListViewDocs.Items.Add("CD POM")
                LI.ForeColor = Color.Blue
                LI.SubItems.Add("")
                LI.SubItems.Add("")
                LI.Tag = New DocInfo(Val(Reader("POMID").ToString), 18, "CD POM", 0)
            Loop
        End If

        SQL = "SELECT DocumentID, PatientID, DocumentName, DocumentProfileID, InsertedDate FROM Documents WHERE DocumentProfileID = 99 and PatientID = " & PatientID & " AND DocumentName = '" & "Bill # " & BillID & "'"
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            If Reader.HasRows Then
                Do Until Reader.Read = False
                    LI = ListViewDocs.Items.Add(Reader("DocumentName").ToString.Trim)
                    LI.SubItems.Add("")
                    LI.SubItems.Add("")
                    LI.Tag = New DocInfo(Val(Reader("DocumentID").ToString), Val(Reader("DocumentProfileID").ToString), Reader("DocumentName").ToString.Trim, 0)
                    LI.ForeColor = Color.Magenta
                Loop
            Else
                LI = ListViewDocs.Items.Add("Bill # " & BillID)
                LI.SubItems.Add("")
                LI.SubItems.Add("")
                LI.Tag = New DocInfo(0, -1, "", 0)
                LI.ForeColor = Color.Magenta
            End If
        End If

        SQL = "SELECT DocumentID, PatientID, DocumentName, DocumentProfileID, InsertedDate FROM Documents WHERE DocumentProfileID = 98 and PatientID = " & PatientID & " AND DocumentName = '" & "Information For Bill # " & BillID & "'"
        Reader = gSQLGetDataReader(SQL)
        If Not Reader Is Nothing Then
            If Reader.HasRows Then
                Do Until Reader.Read = False
                    LI = ListViewDocs.Items.Add(Reader("DocumentName").ToString.Trim)
                    LI.SubItems.Add("")
                    LI.SubItems.Add("")
                    LI.Tag = New DocInfo(Val(Reader("DocumentID").ToString), Val(Reader("DocumentProfileID").ToString), Reader("DocumentName").ToString.Trim, 0)
                    LI.ForeColor = Color.Magenta
                Loop
            Else
                LI = ListViewDocs.Items.Add("Information For Bill # " & BillID)
                LI.SubItems.Add("")
                LI.SubItems.Add("")
                LI.Tag = New DocInfo(0, -2, "", 0)
                LI.ForeColor = Color.BlueViolet
            End If
        End If

        If ListViewDocs.Items.Count > 0 Then
            Dim ea As ColumnClickEventArgs = New ColumnClickEventArgs(0)
            ListViewDocs_ColumnClick(ListViewDocs, ea)

        End If

            'If ListViewDocs.Items.Count > 0 Then
            '    On Error GoTo er
            '    ListViewDocs.Items(0).Selected = True
            '    ListViewDocs.Items(0).EnsureVisible()
            '    ListViewDocs_SelectedIndexChanged(Nothing, Nothing)
            'End If

        Catch ex As Exception
            log.Error(ex)
        End Try
        Loading = False
er:

    End Sub

    Private SaveSelectedindex As Integer

    Private Sub ListViewDocs_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewDocs.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewDocs.Columns(e.Column)
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
        ListViewDocs.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewDocs.Sort()
    End Sub

    Private Sub ListViewDocs_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewDocs.ItemChecked
        If Loading Then Exit Sub
        If e.Item.Checked Then
            If cboAttorneysCompanyID.SelectedIndex = -1 Then
                e.Item.Checked = False
                cboAttorneysCompanyID.BackColor = Color.Red
                MsgBox("Unable to select a document." & vbCrLf & "No attorney selected.", MsgBoxStyle.Exclamation)
                cboAttorneysCompanyID.BackColor = Color.White
                cboAttorneysCompanyID.Focus()
                Exit Sub
            End If
        End If
        e.Item.EnsureVisible()
        e.Item.Selected = True
    End Sub

    Private Loading As Boolean

    Private Sub EnableControls(ByVal En As Boolean)
        cmdUpdate.Enabled = En
        ButtonSaveToHD.Enabled = En
        cmdClose.Enabled = En
        ToolStrip2.Enabled = En
    End Sub

    Private Sub ListViewDocs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewDocs.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim MyFile As IO.FileInfo
        Dim Doc As DocInfo
        If ListViewDocs.SelectedItems.Count = 0 Then Exit Sub
        If Loading Then
            If SaveSelectedindex = 0 Then Exit Sub
            ListViewDocs.Items(SaveSelectedindex).Selected = True
            Exit Sub
        End If
        ListViewDocs.Enabled = False
        PanelDocumentWait.Visible = True
        PanelDocumentWait.BringToFront()
        SaveSelectedindex = ListViewDocs.SelectedItems(0).Index
        gHighlightListviewItem(ListViewDocs, True, False)
        lblLoading.Visible = True
        PictureBoxLoading.Visible = True
        Application.DoEvents()
        If ListViewDocs.SelectedItems.Count = 0 Then
            lblFileSize.Text = ""
            pdfViewer.CloseDocument()
            ListViewDocs.Enabled = True
            PanelDocumentWait.Visible = False
            Exit Sub
        End If
        Doc = CType(ListViewDocs.SelectedItems(0).Tag, DocInfo)
LoadDocument:
        EnableControls(False)
        Select Case Doc.DocumentProfileID
            Case -1 ' Generate Bill
                lblLoading.Text = "Producing Bill # " & BillID & ". Please Wait..."
                Application.DoEvents()
                Dim Ret As Integer
                Ret = Setup_Crystal_Report_Bill()
                lblLoading.Text = "Loading Data. Please Wait..."
                Application.DoEvents()
                If Ret > 0 Then
                    CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentProfileID = 99
                    CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentID = Ret
                    CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentName = "Bill # " & BillID
                    GoTo LoadDocument
                End If
            Case -2 ' Generate Bill Information
                lblLoading.Text = "Producing Information For Bill # " & BillID & ". Please Wait..."
                Application.DoEvents()
                Dim Ret As Integer
                Ret = Setup_Crystal_Report_Bill_Information()
                lblLoading.Text = "Loading Data. Please Wait..."
                Application.DoEvents()
                If Ret > 0 Then
                    CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentProfileID = 98
                    CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentID = Ret
                    CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentName = "Information For Bill # " & BillID
                    GoTo LoadDocument
                End If
            Case 6
                Reader = gSQLGetDataReader("SELECT POMImage FROM POM where POMID=" & Doc.DocumentID)
                If Reader Is Nothing Then
                    MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Critical)
                    EnableControls(True)
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If
                If Reader.HasRows Then
                    Cursor = Cursors.WaitCursor
                    Reader.Read()
                    If Reader("POMImage") Is DBNull.Value Then
                        MsgBox("Unexpected Error." & vbCrLf & "The POM image is invalid or damaged." & vbCrLf & "Please ReScan the document." & vbCrLf & vbCrLf & "The current/invalid document image will be deleted.", MsgBoxStyle.Exclamation)
                        ListViewDocs.SelectedItems(0).Remove()
                        pdfViewer.CloseDocument()
                        pdfViewer.Visible = True
                        lblFileSize.Text = ""
                        Cursor = Cursors.Default
                        EnableControls(True)
                        ListViewDocs.Enabled = True
                        PanelDocumentWait.Visible = False
                        Exit Sub
                    End If
                    Dim arrayImage() As Byte = CType(Reader("POMImage"), Byte())
                    Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", Doc.DocumentName)
                    If System.IO.File.Exists(FName) Then
                        pdfViewer.Visible = True
                        pdfViewer.LoadDocument(FName)
                        pdfViewer.Tag = FName
                        MyFile = New IO.FileInfo(FName)
                        lblFileSize.Text = "Document Size: " & gFormatFileSize(MyFile.Length)
                        'pdfViewer.Visible = True
                        TimerPdfRefresh.Enabled = True
                        Cursor = Cursors.Default
                    End If
                Else
                    MsgBox("Unexpected error. No POM Image Found. Please call system administrator.", MsgBoxStyle.Critical)
                    EnableControls(True)
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If
            Case 18
                Reader = gSQLGetDataReader("SELECT POMImage FROM CDPOM where POMID=" & Doc.DocumentID)
                If Reader Is Nothing Then
                    MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Critical)
                    EnableControls(True)
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If
                If Reader.HasRows Then
                    Cursor = Cursors.WaitCursor
                    Reader.Read()
                    If Reader("POMImage") Is DBNull.Value Then
                        MsgBox("Unexpected Error. The CD POM image is invalid or damaged. Please ReScan the document." & vbCrLf & vbCrLf & "The current/invalid document image will be deleted.")
                        gSQLUpdateData("DELETE FROM CDPOM where (POMImage IS NULL) and POMID=" & Doc.DocumentID)
                        ListViewDocs.SelectedItems(0).Remove()
                        pdfViewer.CloseDocument()
                        pdfViewer.Visible = True
                        lblFileSize.Text = ""
                        Cursor = Cursors.Default
                        EnableControls(True)
                        ListViewDocs.Enabled = True
                        PanelDocumentWait.Visible = False
                        Exit Sub
                    End If
                    Dim arrayImage() As Byte = CType(Reader("POMImage"), Byte())
                    Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", Doc.DocumentName)
                    If System.IO.File.Exists(FName) Then
                        pdfViewer.Visible = True
                        pdfViewer.LoadDocument(FName)
                        pdfViewer.Tag = FName
                        MyFile = New IO.FileInfo(FName)
                        lblFileSize.Text = "Document Size: " & gFormatFileSize(MyFile.Length)
                        'pdfViewer.Visible = True
                        TimerPdfRefresh.Enabled = True
                        Cursor = Cursors.Default
                    End If
                Else
                    MsgBox("Unexpected error. No POM Image Found. Please call system administrator.", MsgBoxStyle.Critical)
                    EnableControls(True)
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If

            Case Else
                SQL = "SELECT DocumentImage   FROM         Documents Where DocumentID=" & Doc.DocumentID
                Reader = gSQLGetDataReader(SQL)
                If Reader Is Nothing Then
                    EnableControls(True)
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If
                If Reader.HasRows Then
                    Cursor = Cursors.WaitCursor
                    Reader.Read()
                    If Reader("DocumentImage") Is DBNull.Value Then
                        MsgBox("Unexpected Error. The Document image is invalid or damaged. Please ReScan the document." & vbCrLf & vbCrLf & "The current/invalid document image will be deleted.")
                        gSQLUpdateData("DELETE FROM Documents where DocumentID=" & Doc.DocumentID)
                        ListViewDocs.SelectedItems(0).Remove()
                        pdfViewer.CloseDocument()
                        pdfViewer.Visible = True
                        Cursor = Cursors.Default
                        lblFileSize.Text = ""
                    Else
                        Dim arrayImage() As Byte = CType(Reader("DocumentImage"), Byte())
                        Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", Doc.DocumentName)
                        If System.IO.File.Exists(FName) Then
                            pdfViewer.Visible = True
                            pdfViewer.LoadDocument(FName)
                            pdfViewer.Tag = FName
                            MyFile = New IO.FileInfo(FName)
                            lblFileSize.Text = "Document Size: " & gFormatFileSize(MyFile.Length)
                            TimerPdfRefresh.Enabled = True
                        End If
                    End If
                End If
        End Select
        Cursor = Cursors.Default
        ListViewDocs.Enabled = True
        PanelDocumentWait.Visible = False
        lblLoading.Visible = False
        PictureBoxLoading.Visible = False
        EnableControls(True)
    End Sub

    Public Function Setup_Crystal_Report_Bill() As Integer
        Dim CR As ReportDocument
        Dim I As Integer
        Dim sBills As String
        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        Try
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            If SaveCaseType = 2 Then
                If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
                    CR = New rptWCRadiology
                Else
                    MsgBox("The WC billing For PT Office is under construction." & vbCrLf & "Please produce this bill manually", MsgBoxStyle.Information)
                    Exit Function
                End If
            Else
                If gNF3Template = 1 Then
                    CR = New rptNF3
                Else
                    CR = New rptNF3Ver2
                End If
            End If
            If SetupCrystalSecurityInfo(CR) = False Then Exit Function

            crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            crParameterFieldLocation = crParameterFieldDefinitions.Item("BillID")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            crParameterDiscreteValue.Value = BillID.ToString
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            CR.SetParameterValue("NoSignature", 0)
            CR.SetParameterValue("NoCover", 1)
            If gPrinterNF3 <> "" Then CR.PrintOptions.PrinterName = gPrinterNF3
            CrystalReportViewer1.ReportSource = CR
            If gPrinterNF3 <> "" Then
                CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterNF3
            End If
            Dim DestinationLoc As String = System.IO.Path.GetTempFileName.ToString
            Dim LStr As String = ""
            DestinationLoc = DestinationLoc.Replace("tmp", "PDF")
            If FileIO.FileSystem.FileExists(DestinationLoc) Then
                FileIO.FileSystem.DeleteFile(DestinationLoc)
            End If

            CrDiskFileDestinationOptions.DiskFileName = DestinationLoc
            CrExportOptions = CR.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            CR.Export()

            Dim Sql As String

            Dim TA As SqlClient.SqlDataAdapter
            Dim CB As SqlClient.SqlCommandBuilder
            TA = New SqlClient.SqlDataAdapter("SELECT   * FROM Documents Where 1=2", gConnectionString)
            CB = New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Documents")

            TA.Fill(dTab)
            TR = dTab.NewRow
            TR("PatientID") = PatientID
            TR("DocumentProfileID") = 99
            TR("DocumentImage") = System.IO.File.ReadAllBytes(DestinationLoc)
            TR("DocumentName") = "Bill # " & BillID
            TR("InsertedBy") = gCurrentEmployee.EmpID
            TR("InsertedDate") = FormatDateTime(Now, DateFormat.ShortDate)
            TR("PatientProcedureID") = 0
            dTab.Rows.Add(TR)
            Try
                TA.Update(dTab)
                dTab.AcceptChanges()
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Exit Function
            End Try
            dTab.Dispose() : CB.Dispose() : TA.Dispose()
            Setup_Crystal_Report_Bill = gSQLGetSingleValue("SELECT IDENT_CURRENT('Documents')")
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Function

    Public Function Setup_Crystal_Report_Bill_Information() As Integer
        Dim CR As ReportDocument
        Dim I As Integer
        Dim sBills As String
        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        Try
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            CR = New rptNF3Information
            If SetupCrystalSecurityInfo(CR) = False Then Exit Function

            crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            crParameterFieldLocation = crParameterFieldDefinitions.Item("BillID")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            crParameterDiscreteValue.Value = BillID.ToString
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            If gPrinterNF3 <> "" Then CR.PrintOptions.PrinterName = gPrinterNF3
            CrystalReportViewer1.ReportSource = CR
            If gPrinterNF3 <> "" Then
                CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterNF3
            End If
            Dim DestinationLoc As String = System.IO.Path.GetTempFileName.ToString
            Dim LStr As String = ""
            DestinationLoc = DestinationLoc.Replace("tmp", "PDF")
            If FileIO.FileSystem.FileExists(DestinationLoc) Then
                FileIO.FileSystem.DeleteFile(DestinationLoc)
            End If

            CrDiskFileDestinationOptions.DiskFileName = DestinationLoc
            CrExportOptions = CR.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            CR.Export()

            Dim Sql As String

            Dim TA As SqlClient.SqlDataAdapter
            Dim CB As SqlClient.SqlCommandBuilder
            TA = New SqlClient.SqlDataAdapter("SELECT   * FROM Documents Where 1=2", gConnectionString)
            CB = New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Documents")

            TA.Fill(dTab)
            TR = dTab.NewRow
            TR("PatientID") = PatientID
            TR("DocumentProfileID") = 98
            TR("DocumentImage") = System.IO.File.ReadAllBytes(DestinationLoc)
            TR("DocumentName") = "Information For Bill # " & BillID
            TR("InsertedBy") = gCurrentEmployee.EmpID
            TR("InsertedDate") = FormatDateTime(Now, DateFormat.ShortDate)
            TR("PatientProcedureID") = 0
            dTab.Rows.Add(TR)
            Try
                TA.Update(dTab)
                dTab.AcceptChanges()
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Exit Function
            End Try
            dTab.Dispose() : CB.Dispose() : TA.Dispose()
            Setup_Crystal_Report_Bill_Information = gSQLGetSingleValue("SELECT IDENT_CURRENT('Documents')")
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Function

    Private Sub TimerPdfRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerPdfRefresh.Tick
        TimerPdfRefresh.Enabled = False
        pdfViewer.Visible = True
        pdfViewer.Show()
        pdfViewer.BringToFront()
        pdfViewer.Update()
    End Sub

    Private Sub TimerLoadDocuments_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLoadDocuments.Tick
        TimerLoadDocuments.Enabled = False
        Load_Documents()
        Application.DoEvents()
        If cboAttorneysCompanyID.Items.Count = 1 Then
            cboAttorneysCompanyID.SelectedIndex = 0
        End If
        If cboAttorneysCompanyID.SelectedIndex > -1 Then
            cboAttorneysCompanyID_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ToolStripButtonSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSaveAs.Click
        Dim Fname As String
        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to Save. No document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If System.IO.File.Exists(pdfViewer.Tag) = False Then
            MsgBox("Unexpected Error. Unable to save file. Please select a document and try again.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If pdfViewer.Tag.ToString().Right(3).ToUpper() = "PDF" Then    ' To keep compatible with previous JPG file versions
            SaveFileDialog1.Filter = "Adobe Acrobat File (*.pdf)|*.pdf"
            SaveFileDialog1.DefaultExt = "pdf"
            Fname = ListViewDocs.SelectedItems(0).Text & " " & PatientID & ".pdf"
        Else
            SaveFileDialog1.Filter = "JPEG FIle (*.jpg)|*.jpg"
            SaveFileDialog1.DefaultExt = "jpg"
            Fname = ListViewDocs.SelectedItems(0).Text & " " & PatientID & ".jpg"
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
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try

            'Dim P As New ProcessStartInfo()
            'With P
            '.FileName = SaveFileDialog1.FileName
            '.UseShellExecute = True
            'End With
            'Process.Start(P)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Fname As String
        Dim Subject As String
        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Document selected.")
            Exit Sub
        End If
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to process your request. No Document Loaded.")
            Exit Sub
        End If
        Subject = "Document: " & ListViewDocs.SelectedItems(0).Text & ", Patient: " & lblPatient.Text
        Fname = pdfViewer.Tag
        Try
            gFax(Me, "", Subject, Fname, gOfficeFax)
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tOther, "Fax " & ListViewDocs.SelectedItems(0).Text & "Has Been Sent.")
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ToolStripButtonEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonEmail.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to send email. No document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Subject = "Attached: " & ListViewDocs.SelectedItems(0).Text & " " & lblPatient.Text
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
            .pdfViewer.Dock = DockStyle.Fill
            .pdfViewer.LoadDocument(pdfViewer.Tag.ToString())
            .ShowDialog(Me)
        End With
        frmDocumentPreview.Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim p = pdfViewer.Document.CreatePrintDocument
        PrintDialog1.Document = p
        PrintDialog1.PrinterSettings = p.PrinterSettings
        PrintDialog1.AllowSomePages = True
        PrintDialog1.AllowPrintToFile = True
        PrintDialog1.UseEXDialog = False
        If PrintDialog1.ShowDialog(Me) = DialogResult.OK Then
            Dim printPrvDlg As PrintPreviewDialog = New PrintPreviewDialog()
            p.PrinterSettings = PrintDialog1.PrinterSettings
            printPrvDlg.Document = p
            printPrvDlg.StartPosition = FormStartPosition.CenterParent
            printPrvDlg.Width = 500
            printPrvDlg.Height = 600
            If printPrvDlg.ShowDialog(Me) = DialogResult.OK Then
                p.Print()
            End If
        End If
        'pdfViewer.PrintDocument(me)
    End Sub

    Private Sub cboAttorneysCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAttorneysCompanyID.SelectedIndexChanged
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim Doc As DocInfo
        Dim AttorneyID As Integer
        Loading = True
        For Each LI In ListViewDocs.CheckedItems
            LI.Checked = False
            LI.SubItems(1).Text = ""
        Next
        If cboAttorneysCompanyID.SelectedIndex = -1 Then
            Exit Sub
        End If
        m_SortingColumn = Nothing
        ListViewDocs.Columns(0).ImageKey = "SORT0"
        ListViewDocs.Columns(1).ImageKey = "SORT0"
        ListViewDocs.Columns(2).ImageKey = "SORT0"

        AttorneyID = CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value
        For Each LI In ListViewDocs.Items
            Doc = CType(LI.Tag, DocInfo)
            Reader = gSQLGetDataReader("SELECT AttorneyDocumentsAccess.WebDocID, AttorneyDocumentsAccess.AccessDate, AttorneyDocumentsStatuses.Description FROM AttorneyDocumentsAccess INNER JOIN AttorneyDocumentsStatuses ON AttorneyDocumentsAccess.StatusID = AttorneyDocumentsStatuses.StatusID where DocumentProfileID = " & Doc.DocumentProfileID & " and DocumentID=" & Doc.DocumentID & " and PatientID = " & PatientID & " and BillID = " & BillID)
            If Reader.HasRows Then
                LI.Checked = True
                Reader.Read()
                LI.SubItems(1).Text = CDate(Reader("AccessDate").ToString).ToShortDateString
                LI.SubItems(2).Text = Reader("Description").ToString
                Doc.WebDocID = Val(Reader("WebDocID").ToString)
            End If
        Next

        TextBoxComments.Text = gSQLGetSingleValueString("select Comment from AttorneyDocumentsComments Where BillID=" & BillID & " and AttorneyID=" & AttorneyID).Trim
        TextBoxComments.Tag = TextBoxComments.Text.Trim
        If PanelAttorney.Visible = True Then
            If TextBoxComments.Text = "" Then TextBoxComments.Text = "Please process this bill and assign your computer system [Attorney Case #] ASAP. Thanks."
        End If

        cmdUpdate.Enabled = True
        ' Check If Item Selected
        Loading = False

    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        If cboAttorneysCompanyID.SelectedIndex = -1 Then
            cboAttorneysCompanyID.BackColor = Color.Red
            MsgBox("Unable to process your request." & vbCrLf & "No attorney selected.", MsgBoxStyle.Exclamation)
            cboAttorneysCompanyID.BackColor = Color.White
            cboAttorneysCompanyID.Focus()
            Exit Sub
        End If
        Loading = True
        ListViewDocs.BeginUpdate()
        For Each LI In ListViewDocs.Items
            LI.Checked = False
        Next
        ListViewDocs.EndUpdate()
        Loading = False
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim SQL As String = ""
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        If BillID = 0 Then Exit Sub
        If TabControl1.SelectedIndex = 1 Then
            ListViewLog.Items.Clear()
            SQL = " SELECT   AttorneyDocumentsAccessLog.StatusID,   AttorneyDocumentsAccessLog.DocumentName, AttorneyDocumentsAccessLog.BillID, AttorneyDocumentsStatuses.Description, AttorneyDocumentsAccessLog.StatusDate, AttorneyDocumentsAccessLog.ChangedBy "
            SQL &= " FROM         AttorneyDocumentsAccessLog INNER JOIN AttorneyDocumentsStatuses ON AttorneyDocumentsAccessLog.StatusID = AttorneyDocumentsStatuses.StatusID "
            SQL &= " WHERE BillID = " & BillID
            SQL &= " ORDER BY ID DESC "
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListViewLog.Items.Add(ListViewLog.Items.Count + 1)
                LI.SubItems.Add(BillID)
                LI.SubItems.Add(Reader("DocumentName").ToString.Trim)
                LI.SubItems.Add(Reader("Description").ToString.Trim)
                LI.SubItems.Add(CDate(Reader("StatusDate").ToString).ToShortDateString)
                LI.SubItems.Add(Reader("ChangedBy").ToString.Trim)
                If Val(Reader("StatusID").ToString) = 3 Then
                    LI.ForeColor = Color.Red
                End If
            Loop
            Reader.Close()
            Reader = Nothing
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBoxComments.Text = ""
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonSaveToHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveToHD.Click
        Dim doc As DocInfo
        Dim reader As SqlClient.SqlDataReader
        Dim sql As String
        Dim fileName As String
        Dim fName As String
        Dim duplicateFileCount As Integer
        If ListViewDocs.CheckedItems.Count = 0 Then
            MsgBox("Unable to process your request. No documents checked", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim destFolder As String
        If LastSelectedDocExportFolder <> "" Then
            If IO.Directory.Exists(LastSelectedDocExportFolder) Then
                FolderBrowserDialog1.SelectedPath = LastSelectedDocExportFolder
            End If
        End If
        If FolderBrowserDialog1.ShowDialog(Me) = DialogResult.Cancel Then Exit Sub
        ButtonSaveToHD.Enabled = False
        lblLoading.Visible = True
        PictureBoxLoading.Visible = True
        Application.DoEvents()
        destFolder = FolderBrowserDialog1.SelectedPath
        LastSelectedDocExportFolder = destFolder
        If destFolder.EndsWith("\") = False Then destFolder &= "\"
        Dim patName = gSQLGetSingleValueString("select cast(PatientID as varchar(10))+'_'+rTrim(isnull(LName,'')) + '_'++rTrim(isnull(FName,'')) from Patients where PatientID = " & PatientID)
        If patName = "" Then patName = PatientID
        patName = gFixFileName(patName)
        destFolder &= patName & "\"

        If IO.Directory.Exists(destFolder) = False Then
            IO.Directory.CreateDirectory(destFolder)
        Else
            gDeleteAllFiles(destFolder, "*.*", False, True)
        End If

        For Each LI In ListViewDocs.CheckedItems
LoadDocument:
            fName = ""
            duplicateFileCount = 0
            doc = CType(LI.Tag, DocInfo)
            lblLoading.Text = "Loading " & doc.DocumentName & ". Please Wait..."
            Select Case doc.DocumentProfileID
                Case -1 ' Generate Bill
                    lblLoading.Text = "Producing Bill # " & BillID & ". Please Wait..."
                    Application.DoEvents()
                    Dim Ret As Integer
                    Ret = Setup_Crystal_Report_Bill()
                    lblLoading.Text = "Loading Data. Please Wait..."
                    Application.DoEvents()
                    If Ret > 0 Then
                        CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentProfileID = 99
                        CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentID = Ret
                        CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentName = "Bill # " & BillID
                        GoTo LoadDocument
                    End If
                Case -2 ' Generate Bill Information
                    lblLoading.Text = "Producing Information For Bill # " & BillID & ". Please Wait..."
                    Application.DoEvents()
                    Dim Ret As Integer
                    Ret = Setup_Crystal_Report_Bill_Information()
                    lblLoading.Text = "Loading Data. Please Wait..."
                    Application.DoEvents()
                    If Ret > 0 Then
                        CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentProfileID = 98
                        CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentID = Ret
                        CType(ListViewDocs.SelectedItems(0).Tag, DocInfo).DocumentName = "Information For Bill # " & BillID
                        GoTo LoadDocument
                    End If
                Case 6
                    reader = gSQLGetDataReader("SELECT POMImage FROM POM where POMID=" & doc.DocumentID)
                    If reader Is Nothing Then
                        MsgBox("Unexpected error. " & vbCrLf & "Unable to load document: " & doc.DocumentName & vbCrLf & vbCrLf & "Please call system administrator." & vbCrLf & vbCrLf & "The next document will be processed.", MsgBoxStyle.Critical)
                        Continue For
                    End If
                    If reader.HasRows Then
                        Cursor = Cursors.WaitCursor
                        reader.Read()
                        If reader("POMImage") Is DBNull.Value Then
                            MsgBox("Unexpected error. " & vbCrLf & "Unable to load document: " & doc.DocumentName & vbCrLf & vbCrLf & "Please call system administrator." & vbCrLf & vbCrLf & "The next document will be processed.", MsgBoxStyle.Critical)
                            Continue For
                        End If
                        Dim arrayImage() As Byte = CType(reader("POMImage"), Byte())
                        fName = gSQLWriteFileFromArray(arrayImage, "PDF", doc.DocumentName)
                    Else
                        MsgBox("Unexpected error. " & vbCrLf & "Unable to load document: " & doc.DocumentName & vbCrLf & vbCrLf & "Please call system administrator." & vbCrLf & vbCrLf & "The next document will be processed.", MsgBoxStyle.Critical)
                        Continue For
                    End If
                Case 18
                    reader = gSQLGetDataReader("SELECT POMImage FROM CDPOM where POMID=" & doc.DocumentID)
                    If reader Is Nothing Then
                        MsgBox("Unexpected error. " & vbCrLf & "Unable to load document: " & doc.DocumentName & vbCrLf & vbCrLf & "Please call system administrator." & vbCrLf & vbCrLf & "The next document will be processed.", MsgBoxStyle.Critical)
                        Continue For
                    End If
                    If reader.HasRows Then
                        Cursor = Cursors.WaitCursor
                        reader.Read()
                        If reader("POMImage") Is DBNull.Value Then
                            MsgBox("Unexpected error. " & vbCrLf & "Unable to load document: " & doc.DocumentName & vbCrLf & vbCrLf & "Please call system administrator." & vbCrLf & vbCrLf & "The next document will be processed.", MsgBoxStyle.Critical)
                            Continue For
                        End If
                        Dim arrayImage() As Byte = CType(reader("POMImage"), Byte())
                        fName = gSQLWriteFileFromArray(arrayImage, "PDF", doc.DocumentName)
                    Else
                        MsgBox("Unexpected error. " & vbCrLf & "Unable to load document: " & doc.DocumentName & vbCrLf & vbCrLf & "Please call system administrator." & vbCrLf & vbCrLf & "The next document will be processed.", MsgBoxStyle.Critical)
                        Continue For
                    End If

                Case Else
                    sql = "SELECT DocumentImage   FROM         Documents Where DocumentID=" & doc.DocumentID
                    reader = gSQLGetDataReader(sql)
                    If reader Is Nothing Then
                        MsgBox("Unexpected error. " & vbCrLf & "Unable to load document: " & doc.DocumentName & vbCrLf & vbCrLf & "Please call system administrator." & vbCrLf & vbCrLf & "The next document will be processed.", MsgBoxStyle.Critical)
                        Continue For
                    End If
                    If reader.HasRows Then
                        Cursor = Cursors.WaitCursor
                        reader.Read()
                        If reader("DocumentImage") Is DBNull.Value Then
                            MsgBox("Unexpected error. " & vbCrLf & "Unable to load document: " & doc.DocumentName & vbCrLf & vbCrLf & "Please call system administrator." & vbCrLf & vbCrLf & "The next document will be processed.", MsgBoxStyle.Critical)
                            Continue For
                        End If
                        Dim arrayImage() As Byte = CType(reader("DocumentImage"), Byte())
                        fName = gSQLWriteFileFromArray(arrayImage, "PDF", doc.DocumentName)
                    Else
                        MsgBox("Unexpected error. " & vbCrLf & "Unable to load document: " & doc.DocumentName & vbCrLf & vbCrLf & "Please call system administrator." & vbCrLf & vbCrLf & "The next document will be processed.", MsgBoxStyle.Critical)
                        Continue For
                    End If
            End Select
            If fName <> "" And IO.File.Exists(fName) Then
                Try
                    fileName = destFolder & gFixFileName(doc.DocumentName) & ".pdf"
recheck:
                    If IO.File.Exists(fileName) Then
                        duplicateFileCount += 1
                        fileName = destFolder & gFixFileName(doc.DocumentName) & "(" & duplicateFileCount & ").pdf"
                        GoTo recheck
                    End If
                    IO.File.Copy(fName, fileName)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString(), MsgBoxStyle.Exclamation)
                End Try

            End If
        Next
        lblLoading.Text = "Data Export Complete."
        Process.Start("explorer.exe", destFolder)
        ButtonSaveToHD.Enabled = True
        lblLoading.Visible = False
        PictureBoxLoading.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        If cboAttorneysCompanyID.SelectedIndex = -1 Then
            cboAttorneysCompanyID.BackColor = Color.Red
            MsgBox("Unable to select a document." & vbCrLf & "No attorney selected.", MsgBoxStyle.Exclamation)
            cboAttorneysCompanyID.BackColor = Color.White
            cboAttorneysCompanyID.Focus()
            Exit Sub
        End If
        For Each LVI As ListViewItem In ListViewDocs.Items
            LVI.Checked = True
            LVI.Selected = True
            LVI.EnsureVisible()
        Next

    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim Doc As DocInfo
        RebuildDocumentToolStripMenuItem.Visible = True
        RebuildDocumentToolStripMenuItemSeparator.Visible = True
        If ListViewDocs.SelectedItems.Count = 0 Then
            RebuildDocumentToolStripMenuItem.Visible = False
            RebuildDocumentToolStripMenuItemSeparator.Visible = False
            Exit Sub
        End If
        Doc = CType(ListViewDocs.SelectedItems(0).Tag, DocInfo)
        If Doc.DocumentProfileID <> 98 And Doc.DocumentProfileID <> 99 Then
            RebuildDocumentToolStripMenuItem.Visible = False
            RebuildDocumentToolStripMenuItemSeparator.Visible = False
            Exit Sub
        End If

    End Sub

    Private Sub RebuildDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RebuildDocumentToolStripMenuItem.Click
        Dim Doc As DocInfo
        Doc = CType(ListViewDocs.SelectedItems(0).Tag, DocInfo)
        If Doc.DocumentProfileID = 98 Then
            Doc.DocumentProfileID = -2
        End If
        If Doc.DocumentProfileID = 99 Then
            Doc.DocumentProfileID = -1
        End If
        pdfViewer.CloseDocument()
        Application.DoEvents()
        ListViewDocs_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub lblLoading_Click(sender As Object, e As EventArgs) Handles lblLoading.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub chkAllPOMs_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllPOMs.CheckedChanged
        TimerLoadDocuments.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

End Class