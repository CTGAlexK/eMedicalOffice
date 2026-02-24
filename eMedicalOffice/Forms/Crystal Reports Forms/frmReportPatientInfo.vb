Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmReportPatientInfo
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private m_SortingColumn As ColumnHeader
    Private m_SortingColumnLog As ColumnHeader
    Private m_SortingColumnAppointmentsLog As ColumnHeader
    Private m_SortingColumnDocuments As ColumnHeader
    Private m_SortingColumnComments As ColumnHeader
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode
    Private KeyDn As Boolean
    Private SaveCaseStatusID As Integer 'Used to see if case status changed - update Case Status Date
    Private lPatientID() As Long

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ComboText As String() = {""}
        Dim ComboValue As String() = {""}
        Dim Items() As String = {""}
        Dim I As Integer = 0
        ComboBoxSearchCaseStatus.Items.Clear()
        Reader = gSQLGetDataReader("SELECT CaseStatusID, Description FROM CaseStatuses Order By ShowOrder")
        If Reader Is Nothing Then Exit Sub
        ComboBoxSearchCaseStatus.Items.Add(New ValueDescription(0, "All Patients"))
        Do Until Reader.Read = False
            ComboBoxSearchCaseStatus.Items.Add(New ValueDescription(CLng(Val(Reader("CaseStatusID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        ComboBoxSearchCaseType.Items.Clear()
        ComboBoxSearchCaseType.Items.Add(New ValueDescription(0, "All Types"))
        Reader = gSQLGetDataReader("Select CaseTypeID, Description from CaseTypes")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxSearchCaseType.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        ComboBoxSearchCaseStatus.SelectedIndex = 0
        ComboBoxSearchCaseType.SelectedIndex = 0

    End Sub

    Private Sub frmPatient_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", "Reports\PatientInfoShowProceduresSearch", CheckBoxShowProcedures.Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "Reports\PatientInfoShowTransportationSearch", CheckBoxShowBills.Checked)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub

    Public Sub frmPatient_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DoubleBuffered = True
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        gWindow_Settings(Me, ReadWrite.sRead)
        Load_Data()
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewPatients.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewPatients.Columns(e.Column)
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
        ListViewPatients.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewPatients.Sort()

    End Sub

    Public Sub Load_Patients()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Dim PName
        If TextBoxSearch.Text.Trim = "" Then
            ListViewPatients.Items.Clear()
            Exit Sub
        End If

        ListViewPatients.BeginUpdate()
        ListViewPatients.Items.Clear()
        SQL = " Select PatientID, FName,LName, MI, CaseStatusID, NoMoreAppointmentsInd  from Patients  WHERE OfficeID= " & gOfficeID
        If TextBoxSearch.Text.Trim <> "" Then
            If IsNumeric(TextBoxSearch.Text) Then
                SQL &= " and Patients.PatientID = " & Val(TextBoxSearch.Text.Trim) & " "
            Else
                PName = Split(TextBoxSearch.Text.Trim.ToSafeSQLString(), " ")
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
        If CType(ComboBoxSearchCaseStatus.SelectedItem, ValueDescription).Value > 0 Then
            SQL &= " AND CaseStatusID=" & CType(ComboBoxSearchCaseStatus.SelectedItem, ValueDescription).Value
        End If

        If CType(ComboBoxSearchCaseType.SelectedItem, ValueDescription).Value > 0 Then
            SQL &= " AND CaseTypeID=" & CType(ComboBoxSearchCaseType.SelectedItem, ValueDescription).Value
        End If
        SQL &= " Order by FName, LName"
        Reader = gSQLGetDataReader(SQL)

        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewPatients.Items.Add(Reader("PatientID").ToString, CInt(Val(Reader("CaseStatusID").ToString) - 1))
            With LI
                .SubItems.Add(Reader("FName").ToString & " " & Reader("LName").ToString)
                .ToolTipText = Reader("FName").ToString & " " & Reader("LName").ToString
                .Tag = "" & Reader("PatientID").ToString
                If Val(Reader("NoMoreAppointmentsInd").ToString) <> 0 Or Val(Reader("CaseStatusID").ToString) <> 1 Then
                    .ForeColor = Color.Red
                End If
            End With
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
        End If
        Cursor = Cursors.Default
        ListViewPatients.EndUpdate()
    End Sub

    Private Sub ComboBoxCaseStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxSearchCaseStatus.SelectedIndexChanged
        Load_Patients()
    End Sub

    Private Sub TimerLoad_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLoad.Tick
        TimerLoad.Enabled = False
        If ComboBoxSearchCaseStatus.Items.Count > 0 Then
            ComboBoxSearchCaseStatus.SelectedIndex = 1
        End If

    End Sub

    Public Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        Load_Patients()
        If ListViewPatients.Items.Count = 0 Then
            LabelFound.Text = ""
        Else
            LabelFound.Text = "Found: " & ListViewPatients.Items.Count
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        TextBoxSearch.BackColor = Color.White
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If CrystalReportViewer1.ReportSource Is Nothing Then
                MsgBox("Unable to Print report. No report has been loaded. Please select a patient and click the Load Button.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.PrintReport()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private CR As ReportDocument = New eMedicalOffice.rptPatientInfo

    Public Sub Setup_report(ByVal PatientID() As String)
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Try
            If PatientID.Length > 100 Then
                MsgBox("Unable to produce report." & vbCrLf & "To many patients selected." & vbCrLf & "Please select up to 100 patients a time.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            CR = New rptPatientInfo

            Me.MinimizeBox = False
            'ConInfo.ConnectionInfo.UserID = gSQLServerUID
            'ConInfo.ConnectionInfo.Password = gSQLServerPassword
            'ConInfo.ConnectionInfo.ServerName = gSQLServerName
            'ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase

            'For intCounter = 0 To CR.Database.Tables.Count - 1

            '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
            '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
            '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSQLServerName
            '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
            '    Application.DoEvents()
            '    CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
            '    Application.DoEvents()
            'Next
            'CR.Refresh()

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub

            CR.SetParameterValue("PatientID", PatientID)
            CR.SetParameterValue("ShowTransportation", Math.Abs(Val(CheckBoxShowBills.Checked))) ' Used to show Bills
            CR.SetParameterValue("ShowProcedures", Math.Abs(Val(CheckBoxShowProcedures.Checked)))
            CR.SetParameterValue("ShowComments", Math.Abs(Val(CheckBoxShowComments.Checked)))
            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.ReportSource = CR
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim ID As Long
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        gShowWait(True, PanelWait, CrystalReportViewer1)
        ID = ListViewPatients.SelectedItems(0).Tag
        Button1.Enabled = False
        ListViewPatients.Enabled = False
        ComboBoxSearchCaseStatus.Enabled = False
        btnPrint.Enabled = False
        Cursor = Cursors.WaitCursor
        Me.SuspendLayout()
        Application.DoEvents()
        Dim PAtID() As String = Nothing
        Dim I As Integer = 0
        If ListViewPatients.CheckedItems.Count = 0 And ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce Bill. No bills checked / selected. Please check the bill(s) and try again.", MsgBoxStyle.Critical)
            ListViewPatients.Focus()
            Exit Sub
        End If

        Dim LI As ListViewItem
        If ListViewPatients.CheckedItems.Count = 0 Then
            ReDim Preserve PAtID(0)
            PAtID(I) = ListViewPatients.SelectedItems(0).Tag
        Else
            For Each LI In ListViewPatients.CheckedItems
                ReDim Preserve PAtID(I)
                PAtID(I) = LI.Tag
                I = I + 1
            Next
        End If

        Setup_report(PAtID)
        Me.ResumeLayout()
        Button1.Enabled = True
        ListViewPatients.Enabled = True
        ComboBoxSearchCaseStatus.Enabled = True
        btnPrint.Enabled = True
        Cursor = Cursors.Default
        gShowWait(False, PanelWait)
    End Sub

    Private Sub CheckBoxShowProcedures_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxShowProcedures.CheckedChanged
        If Loading = True Then Exit Sub
        ToolStripButton2_Click(Nothing, Nothing)
    End Sub

    Private Sub CheckBoxShowTransportation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxShowBills.CheckedChanged
        If Loading = True Then Exit Sub
        ToolStripButton2_Click(Nothing, Nothing)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Email report. No report has been loaded. Please select a patient and click the Load Button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim PatientName As String
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " /Patients Information Report/ Attached: Patient Info PDF File"
        Fname = System.IO.Path.GetTempPath & "\PatientsInformationReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"

Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname = Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)

            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ListViewPatients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatients.DoubleClick
        ToolStripButton2_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Email report. No report has been loaded. Please select a patient and click the Load Button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim PatientName As String
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String

        Subject = "Message From " & gOfficeName & " /Patients Information Report/ Attached: Patient Info PDF File"
        Fname = System.IO.Path.GetTempPath & "\PatientsInformationReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname = Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ComboBoxSearchCaseType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxSearchCaseType.SelectedIndexChanged
        Load_Patients()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        For Each LI In ListViewPatients.Items
            LI.Checked = True
        Next
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim LI As ListViewItem
        For Each LI In ListViewPatients.CheckedItems
            LI.Checked = False
        Next
    End Sub

    Private Sub CheckBoxShowComments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxShowComments.CheckedChanged
        If Loading = True Then Exit Sub
        ToolStripButton2_Click(Nothing, Nothing)
    End Sub

    Private Sub CheckBoxShowBills_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Loading = True Then Exit Sub
        ToolStripButton2_Click(Nothing, Nothing)
    End Sub

End Class