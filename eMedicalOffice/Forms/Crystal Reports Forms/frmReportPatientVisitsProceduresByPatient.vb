Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmReportPatientVisitsProceduresByPatient
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        Load_Data()
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
    End Sub
    Private CR As ReportDocument = New rptPatientVisitsReportByPatient
    Public Sub Setup_report(ByVal PatientID As Long)
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Try
            CR = New rptPatientVisitsReportByPatient
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
            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.ReportSource = CR
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            gCrystalViewerTabs(CrystalReportViewer1, False)

        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub


    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If CrystalReportViewer1.Visible = False Then Exit Sub
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.PrintReport()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub DateTimePicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = True
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Email report. No report has been loaded.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Sign In Sheet For " & PatientName & ". Attached: Patient's Sign In Sheet"
        Fname = System.IO.Path.GetTempPath & "\Patient's Sign In Sheet " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Sign In Sheet For " & PatientName & ". Attached: Patient's Sign In Sheet"
        Fname = System.IO.Path.GetTempPath & "\Patient's Sign In Sheet " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Seach_Data()
    End Sub
    Public PatientID As Long
    Public PatientName As String
    Private Sub Seach_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String = ""
        PatientID = 0
        PatientName = ""
        If TextBoxSearch.Text.Trim = "" And txtDOA.MaskCompleted = False Then
            MsgBox("Unable to search. No search criteria specified.", MsgBoxStyle.Information)
            TextBoxSearch.Focus()
            Exit Sub
        End If
        SQL = "Select * from Patients Where OfficeID = " & gOfficeID
        If txtDOA.MaskCompleted Then
            SQL &= " and DOA ='" & txtDOA.Text & "'"
        End If
        Dim PName() As String
        If TextBoxSearch.Text <> "" Then
            If RadioButton1.Checked Then
                SQL &= " and PatientID like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' "
            End If
            If RadioButton2.Checked Then
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
            If RadioButton3.Checked Then
                SQL &= " and ( PolicyNumber like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' or "
                SQL &= " PolicyNumber1 like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' )"
            End If
            If RadioButton4.Checked Then
                SQL &= " and ( ClaimNumber like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' or "
                SQL &= " ClaimNumber1 like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' )"
            End If
            If RadioButton5.Checked Then
                SQL &= " and SSN like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' "
            End If
            If RadioButton6.Checked Then
                SQL &= " and ( Phone1 like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' or "
                SQL &= " Phone2 like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' or "
                SQL &= " CellPhone like '" & TextBoxSearch.Text.ToSafeSQLString() & "%' )"
            End If
        End If
        If ComboBoxStatus.SelectedIndex = 1 Then
            SQL &= " and CaseStatusID = 1 "
        ElseIf ComboBoxStatus.SelectedIndex = 2 Then
            SQL &= " and CaseStatusID <> 1 "
        End If
        If ComboBoxCaseType.SelectedIndex > 0 Then
            SQL &= " and CaseTypeID = " & CType(ComboBoxCaseType.SelectedItem, ValueDescription).Value
        End If
        If ComboBoxSearchPeriod.SelectedIndex > 0 Then
            SQL &= " and Datediff(m,InsertedDT,getdate())<=" & ComboBoxSearchPeriod.SelectedIndex
        End If

        SQL &= " Order by FName, LName"

        Reader = gSQLGetDataReader(SQL)

        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            With frmReportPatientVisitsProceduresByPaqtientSearch
                .ListViewPatients.BeginUpdate()
                Do Until Reader.Read = False
                    LI = .ListViewPatients.Items.Add(Reader("PatientID").ToString, CInt(Val(Reader("CaseStatusID").ToString) - 1))
                    LI.SubItems.Add(Reader("FName").ToString & " " & Reader("LName").ToString)
                    LI.ToolTipText = Reader("FName").ToString & " " & Reader("LName").ToString
                    LI.Tag = "" & Reader("PatientID").ToString
                Loop
                Reader.Close() : Reader.Dispose()
                Cursor = Cursors.Default
                If .ListViewPatients.Items.Count = 1 Then
                    PatientID = .ListViewPatients.Items(0).Tag
                    PatientName = .ListViewPatients.Items(0).ToolTipText
                    frmReportPatientVisitsProceduresByPaqtientSearch.Close()
                    frmReportPatientVisitsProceduresByPaqtientSearch.Dispose()
                    Timer1.Enabled = True
                Else
                    .CalledForm = Me
                    .ListViewPatients.EndUpdate()
                    If frmReportPatientVisitsProceduresByPaqtientSearch.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Timer1.Enabled = True
                    End If
                    frmReportPatientVisitsProceduresByPaqtientSearch.Dispose()
                End If

            End With
        Else
            MsgBox("No search results found by search criteria.", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Loading As Boolean
    Private Sub Load_Data()
        Loading = True
        ComboBoxCaseType.Items.Clear()
        ComboBoxCaseType.Items.AddRange(gCaseTypes)
        ComboBoxCaseType.SelectedIndex = CInt(GetSetting(My.Application.Info.ProductName, "Settings", "LastQSearchCaseStatusIndex", "0"))
        ComboBoxStatus.SelectedIndex = 1
        ComboBoxSearchPeriod.SelectedIndex = 3
        Loading = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        gShowWait(True, PanelWait, Me)
        Setup_report(PatientID)
        gShowWait(False, PanelWait)
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        If Loading = True Then Exit Sub
        If TextBoxSearch.Text.Trim <> "" Then
            Loading = True
            If IsNumeric(TextBoxSearch.Text) = False And RadioButton1.Checked = True Then
                RadioButton2.Checked = True
            ElseIf IsNumeric(TextBoxSearch.Text) = True And RadioButton2.Checked = True Then
                RadioButton1.Checked = True
            End If
            Loading = False
        End If
    End Sub

End Class