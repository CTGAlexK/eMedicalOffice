Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection
Imports System.Security.AccessControl
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Text
Imports log4net

Public Class frmCDBurn
    Public InvoiceID As Long
    Public PatientID As String
    Public PatientName As String
    Public PatientDOB As String
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    <DllImport("shell32.dll", EntryPoint:="SHGetFolderPathW",
    CallingConvention:=CallingConvention.StdCall)>
    Private Shared Function SHGetFolderPath(ByVal hWnd As Integer,
                          ByVal nFolder As Integer, ByVal nToken As Integer,
                          ByVal dwFlags As Integer,
                          <MarshalAs(UnmanagedType.LPTStr)> ByVal lpszPath As String) As Boolean
    End Function

    Public Function Load_Data(ByVal pInvoiceID As Long) As Boolean
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        Dim DescriptionFixed As String
        Dim SC As Integer
        Dim PatientID As String
        Dim PACSPat As Boolean
        SQL = "SELECT  TOP 1 Patients.FName, Patients.MI, Patients.LName, Patients.Suffix, Patients.DOB, Patients.PatientID, Sex FROM         ImageDiskRequests INNER JOIN Patients ON ImageDiskRequests.PatientID = Patients.PatientID WHERE ImageDiskRequests.ID = " & pInvoiceID & " and  ImageDiskRequests.OfficeID = " & gOfficeID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then
            TopMost = False
            MsgBox("Unexpected Error. Please call your system administrator." & vbCrLf & "No Patient Profile Found.", MsgBoxStyle.Critical, "Error")
            log.Error("Unexpected Error. Please call your system administrator. No Patient Profile Found.")
            Exit Function
        End If
        If Reader.HasRows = False Then
            MsgBox("Unexpected Error. Please call your system administrator." & vbCrLf & "No Patient Profile Found.")
            log.Error("Unexpected Error. Please call your system administrator. No Patient Profile Found.")
            Exit Function
        End If
        Reader.Read()
        InvoiceID = pInvoiceID
        PatientID = Reader("PatientID").ToString.Trim()
        PatientName = Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString & " " & Reader("Suffix").ToString
        PatientDOB = CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy")
        lblMsg.Text = UCase("PATIENT: " & Reader("PatientID").ToString.Trim & "     " & Reader("LName").ToString.Trim & " " & Reader("FName").ToString.Trim & "     DOB: " & CDate(Reader("DOB").ToString.Trim).ToString("MM/dd/yyyy") & "     SEX: " & Reader("Sex").ToString.Trim)

        If gPacsConnectionString = "" Then Exit Function
        SQL = "SELECT PatientID,  PatientNam, PatientBir, PatientSex,  StudyDate, StudyInsta, StudyDescr, StudyModal FROM " & gPACSSQLServerDatabase & ".dbo.DICOMStudies WHERE RTRIM(PatientID) = '" & PatientID & "'"

        Reader = SQLGetDataReader(SQL)
        If Reader Is Nothing Then
            Exit Function

        End If

        If Reader.HasRows = False Then
            SQL = "SELECT  PatientID, PatientNam, PatientBir, PatientSex,  StudyDate, StudyInsta, StudyDescr, StudyModal FROM " & gPACSSQLServerDatabase & ".dbo.DICOMStudies WHERE LEN(PatientID)>3 AND LEFT(RTRIM(PatientID),LEN(RTRIM(PatientID))-3) = '" & PatientID & "'"
            Reader = SQLGetDataReader(SQL)
        End If
        If Reader.HasRows = False Then
            SQL = "SELECT  PatientID, PatientNam, PatientBir, PatientSex,  StudyDate, StudyInsta, StudyDescr, StudyModal FROM " & gPACSSQLServerDatabase & ".dbo.DICOMStudies WHERE LEN(PatientID)>4 AND LEFT(RTRIM(PatientID),LEN(RTRIM(PatientID))-4) = '" & PatientID & "'"
            Reader = SQLGetDataReader(SQL)
        End If
        If Reader.HasRows = False Then
            SQL = "SELECT  PatientID, PatientNam, PatientBir, PatientSex,  StudyDate, StudyInsta, StudyDescr, StudyModal FROM " & gPACSSQLServerDatabase & ".dbo.DICOMStudies WHERE LEN(PatientID)>6 AND LEFT(RTRIM(PatientID),LEN(RTRIM(PatientID))-6) = '" & PatientID & "'"
            Reader = SQLGetDataReader(SQL)
        End If

        Reader = SQLGetDataReader(SQL)
        Do Until Reader.Read = False
            If PACSPat = False Then
                lblMsg2.Text = UCase("PATIENT: " & Reader("PatientID").ToString.Trim & "     " & Reader("PatientNam").ToString.Trim & "     DOB: " & Reader("PatientBir").ToString().Trim().Mid(5, 2) & "/" & Reader("PatientBir").ToString().Trim().Right(2) & "/" & Reader("PatientBir").ToString().Trim().Left(4) & "     SEX: " & Reader("PatientSex").ToString.Trim)
                If lblMsg.Text <> lblMsg2.Text Then
                    lblMsg2.ForeColor = Color.FromKnownColor(KnownColor.Orange)
                End If
                PACSPat = True
            End If
            SC = SC + 1

            If gPACSPatientIDPadded Then
                Dim abbr As StringBuilder = New StringBuilder()
                Dim patId As String = Reader("PatientID").ToString
                ' Get Letters Code only.
                For Each c As Char In patId
                    If Char.IsLetter(c) Then
                        abbr.Append(c)
                    End If
                Next
                DescriptionFixed = gSQLGetSingleValueString("SELECT ProcName FROM Procedures WHERE Abbr = '" & abbr.ToString() & "'")
            Else
                DescriptionFixed = Reader("StudyDescr").ToString.ToUpper
            End If
            If DescriptionFixed = "" Then
                Select Case Reader("StudyModal").ToString.ToUpper
                    Case "CT"
                        DescriptionFixed = "CT-SCAN " & SC
                    Case "MR"
                        DescriptionFixed = "MRI " & SC
                    Case "CR"
                        DescriptionFixed = "X-RAY " & SC
                    Case Else
                        DescriptionFixed = "STUDY " & SC
                End Select
            End If
            LI = ListViewStudies.Items.Add(DescriptionFixed)
            LI.Tag = Reader("StudyInsta").ToString
            LI.Checked = True
        Loop
        If ListViewStudies.Items.Count > 0 Then
            ListViewStudies.Items(0).Selected = True
            ListViewStudies.Items(0).EnsureVisible()
            'ListViewStudies_SelectedIndexChanged(Nothing, Nothing)
        End If
        Load_Data = True
    End Function

    Private Sub Load_Series()
        Dim StudyInsta As String
        Dim SQL As String
        Dim DescriptionFixed As String
        Dim SC As Integer
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        ListViewSeries.Items.Clear()
        If ListViewStudies.SelectedItems.Count = 0 Then Exit Sub
        StudyInsta = ListViewStudies.SelectedItems(0).Tag
        SQL = "SELECT     SeriesInst, SeriesDesc, Modality FROM " & gPACSSQLServerDatabase & ".dbo.DICOMSeries Where StudyInsta = '" & StudyInsta & "'"
        If gPacsConnectionString = "" Then Exit Sub
        Reader = SQLGetDataReader(SQL)
        SC = 0
        Do Until Reader.Read = False
            SC = SC + 1
            DescriptionFixed = Reader("SeriesDesc").ToString.Trim.ToUpper
            If DescriptionFixed = "" Then
                Select Case Reader("Modality").ToString.Trim.ToUpper
                    Case "CT"
                        DescriptionFixed = "CT-SCAN " & SC
                    Case "MR"
                        DescriptionFixed = "MRI " & SC
                    Case "CR"
                        DescriptionFixed = "X-RAY " & SC
                    Case Else
                        DescriptionFixed = "SERIES " & SC
                End Select
            End If
            LI = ListViewSeries.Items.Add(DescriptionFixed)
            LI.Tag = Reader("SeriesInst").ToString
        Loop
        If ListViewSeries.Items.Count > 0 Then
            ListViewSeries.Items(0).Selected = True
            ListViewSeries.Items(0).EnsureVisible()
            'ListViewSeries_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub frmCDBurn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub frmCDBurn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Ret As String
        Dim clsBurn As CDBurnClass
        Dim BurnerPath As String
        Try
            clsBurn = New CDBurnClass
            BurnerPath = clsBurn.mstrBurnPath
        Catch ex As Exception
            lblMsg.ForeColor = Color.Red
            lblMsg.Text = $"Incomplete CD Burner Setup or CD Recorder device not exists."
            ListViewStudies.Enabled = False
            ListViewSeries.Enabled = False
            cmdBurn.Enabled = False
            Return
        End Try

        If BurnerPath.EndsWith("\") = False Then BurnerPath = BurnerPath & "\"
        gDeleteFolder(BurnerPath)

        If gPacsConnectionString = "" Then
            lblMsg.ForeColor = Color.Red
            lblMsg.Text = $"Incomplete CD Burner Setup. Please call your system administrator."
            ListViewStudies.Enabled = False
            ListViewSeries.Enabled = False
            cmdBurn.Enabled = False
        End If
        Ret = clsBurn.Check_CDBurner()
        If Ret <> "" Then
            lblMsg.ForeColor = Color.Red
            lblMsg.Text = $"Unable to Record CD. " & Ret
            ListViewStudies.Enabled = False
            ListViewSeries.Enabled = False
            cmdBurn.Enabled = False
        End If
        'gWindow_Settings(Me, ReadWrite.sRead)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Public Function SQLGetDataReader(ByVal SQL As String) As SqlClient.SqlDataReader
        Dim Cnn As New SqlClient.SqlConnection(gPacsConnectionString)
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim Cmd As New SqlClient.SqlCommand(SQL, Cnn)
        Dim ErCount As Integer
        Dim ErrorCount As Integer
Er:
        ErCount = ErCount + 1
        Try
            Cnn.Open()
        Catch ex As Exception
            Thread.Sleep(200)
            SqlClient.SqlConnection.ClearPool(Cnn)
            SqlClient.SqlConnection.ClearAllPools()
            Cnn.Open()
        End Try
        Cmd.CommandTimeout = 300
        Try
            Reader = Cmd.ExecuteReader
        Catch ex As Exception
            ErrorCount = ErrorCount + 1
            If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                SqlClient.SqlConnection.ClearPool(Cnn)
                SqlClient.SqlConnection.ClearAllPools()
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()
                End If
                Thread.Sleep(200)
                GoTo Er
            Else
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End If
        End Try

        SQLGetDataReader = Reader
    End Function

    Private Sub ListViewStudies_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewStudies.ItemCheck
        Timer1.Enabled = True
    End Sub

    Private Sub ListViewStudies_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewStudies.SelectedIndexChanged
        gHighlightListviewItem(ListViewStudies)
        Load_Series()
    End Sub

    Private Sub cmdBurn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBurn.Click
        Dim LiSt As ListViewItem
        Dim LiSr As ListViewItem
        Dim StudyInsta As String
        Dim SeriesInst As String
        Dim SQL As String
        Dim DescriptionFixed As String
        Dim SC As Integer
        Dim ReaderSeries As SqlClient.SqlDataReader
        Dim ReaderFiles As SqlClient.SqlDataReader
        Dim clsBurn As CDBurnClass
        Dim di As IO.DirectoryInfo
        Dim diar1 As IO.FileInfo()
        Dim dra As IO.FileInfo
        Dim BurnerPath As String
        Dim ST As Integer = 0
        Dim SE As Integer = 0
        Dim SEPath As String
        Dim FL As Integer = 0
        Try
            clsBurn = New CDBurnClass
        Catch ex As Exception
            MsgBox("Unable to Record CD. " & ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
        If ListViewStudies.CheckedItems.Count = 0 Then
            MsgBox("Unable to Produce CD. No Studies selected", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Directory.Exists(gPACSPath) = False Then
            MsgBox("Unable to Produce CD. The PACS folder is invalid or not accessible." & vbCrLf & vbCrLf & gPACSPath & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Directory.Exists(gAppPath & "CDTemp\") = False Then
            MsgBox("Unable to Produce CD. The [CDTemp] folder required by the system is not exist." & vbCrLf & vbCrLf & "..\CDTemp\" & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Directory.Exists(gAppPath & "CDBurn\") = False Then
            MsgBox("Unable to Produce CD. The [CDBurn] folder required by the system is not exist." & vbCrLf & vbCrLf & "..\CDBurn\" & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Directory.Exists(gAppPath & "CDBurn\eFilmLite\") = False Then
            MsgBox("Unable to Produce CD. The [eFilmLite] folder required by the system is not exist." & vbCrLf & vbCrLf & "..\CDBurn\eFilmLite\" & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If File.Exists(gAppPath & "CDTemp\dcmmkdir.exe") = False Then
            MsgBox("Unable to Produce CD. The dcmmkdir.exe file required by the system is not exist." & vbCrLf & vbCrLf & "..\CDTemp\dcmmkdir.exe" & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        WaitDlg(True)
        cmdBurn.Enabled = False
        ListViewStudies.Enabled = False

        If gPACSPath.EndsWith("\") = False Then gPACSPath &= "\"
        BurnerPath = clsBurn.mstrBurnPath
        If BurnerPath.EndsWith("\") = False Then BurnerPath = BurnerPath & "\"

        ProgressBar1.Value = 10
        ProgressBar1.Refresh()
        lblProgress.Text = "Initializing System 10%"
        lblProgress.Refresh()

        Clean_CDRom_Data(BurnerPath)

        lblProgress.Text = "Initializing System 20%"

        gDeleteFolder(gAppPath & "CDTemp\DICOM\")

        lblProgress.Text = "Initializing System 30%"

        Try
            If IO.File.Exists(gAppPath & "CDTemp\DICOMDIR") Then
                IO.File.Delete(gAppPath & "CDTemp\DICOMDIR")
            End If
        Catch ex As Exception
            log.Error(ex.Message, ex)
        End Try

        lblProgress.Text = "Initializing System 40%"

        Try
            AddDirectorySecurity(gAppPath, "Everyone", FileSystemRights.FullControl, AccessControlType.Allow)
            AddDirectorySecurity(BurnerPath, "Everyone", FileSystemRights.FullControl, AccessControlType.Allow)
            AddDirectorySecurity(gAppPath & "CDTemp\", "Everyone", FileSystemRights.FullControl, AccessControlType.Allow)
            AddDirectorySecurity(gAppPath & "CDBurn\", "Everyone", FileSystemRights.FullControl, AccessControlType.Allow)
        Catch ex As Exception
            log.Error(ex.Message, ex)
        End Try

        Try
            IO.Directory.CreateDirectory(gAppPath & "CDTemp\DICOM\PA000000")
            AddDirectorySecurity(gAppPath & "CDTemp\DICOM\PA000000", "Everyone", FileSystemRights.FullControl, AccessControlType.Allow)
            ProgressBar1.Value = 20
            ProgressBar1.Refresh()
            lblProgress.Text = "Creating CD File Structures"
            lblProgress.Refresh()

            ST = 0
            For Each LiSt In ListViewStudies.CheckedItems
                IO.Directory.CreateDirectory(gAppPath & "CDTemp\DICOM\PA000000\ST" & ST.ToString.PadLeft(6, "0"))
                AddDirectorySecurity(gAppPath & "CDTemp\DICOM\PA000000\ST" & ST.ToString.PadLeft(6, "0"), "Everyone", FileSystemRights.FullControl, AccessControlType.Allow)
                SeriesInst = ""
                SE = 0
                FL = 0
                StudyInsta = LiSt.Tag
                SQL = " SELECT     DICOMSeries.SeriesInst, DICOMImages.ObjectFile FROM DICOMSeries INNER JOIN DICOMImages ON DICOMSeries.SeriesInst = DICOMImages.SeriesInst WHERE DICOMSeries.StudyInsta = '" & StudyInsta & "' ORDER BY DICOMSeries.SeriesInst, ObjectFile "
                ReaderSeries = SQLGetDataReader(SQL)
                Do Until ReaderSeries.Read = False
                    If SeriesInst <> ReaderSeries("SeriesInst").ToString Then

                        IO.Directory.CreateDirectory(gAppPath & "CDTemp\DICOM\PA000000\ST" & ST.ToString.PadLeft(6, "0") & "\SE" & SE.ToString.PadLeft(6, "0"))
                        AddDirectorySecurity(gAppPath & "CDTemp\DICOM\PA000000\ST" & ST.ToString.PadLeft(6, "0") & "\SE" & SE.ToString.PadLeft(6, "0"), "Everyone", FileSystemRights.FullControl, AccessControlType.Allow)
                        FL = 0
                        SeriesInst = ReaderSeries("SeriesInst").ToString
                        SEPath = gAppPath & "CDTemp\DICOM\PA000000\ST" & ST.ToString.PadLeft(6, "0") & "\SE" & SE.ToString.PadLeft(6, "0")
                        SE = SE + 1
                        If ProgressBar1.Value < 100 Then
                            ProgressBar1.Value = ProgressBar1.Value + 5
                            ProgressBar1.Refresh()
                        End If
                        lblProgress.Text = "Adding ..\PA000000\ST" & ST.ToString.PadLeft(6, "0") & "\SE" & SE.ToString.PadLeft(6, "0")
                        lblProgress.Refresh()
                    End If

                    If File.Exists(gPACSPath & ReaderSeries("ObjectFile").ToString) Then
                        IO.File.Copy(gPACSPath & ReaderSeries("ObjectFile").ToString, SEPath & "\IM" & FL.ToString.PadLeft(6, "0"), True)
                        AddDirectorySecurity(SEPath & "\IM" & FL.ToString.PadLeft(6, "0"), "Everyone", FileSystemRights.FullControl, AccessControlType.Allow)
                    End If
                    FL = FL + 1
                Loop
                ST = ST + 1
            Next
            ProgressBar1.Value = 80
            ProgressBar1.Refresh()
            lblProgress.Text = "Creating PACS Structure"
            lblProgress.Refresh()
            IO.Directory.SetCurrentDirectory(gAppPath & "CDTemp\")
            Shell("dcmmkdir.exe +r +m -Nxc *.", AppWinStyle.Hide, True)
            If IO.File.Exists(gAppPath & "CDTemp\DICOMDIR") = False Then
                MsgBox("Unable to Produce CD. Unexpected Error. Please call your system administrator.", MsgBoxStyle.Exclamation)
                cmdBurn.Enabled = True
                ListViewStudies.Enabled = True
                WaitDlg(False)
                Exit Sub
            End If

            lblProgress.Text = "Adding Files to CD Writer"
            lblProgress.Refresh()
            ProgressBar1.Value = 90
            ProgressBar1.Refresh()

            clsBurn.AddFolderToBurn(gAppPath & "CDTemp\DICOM\", BurnerPath & "DICOM\", True)

            If File.Exists(gAppPath & "CDTemp\DICOMDIR") Then
                IO.File.Copy(gAppPath & "CDTemp\DICOMDIR", BurnerPath & "DICOMDIR", True)
            End If
            clsBurn.AddFolderToBurn(gAppPath & "CDBurn\", BurnerPath, True)

            clsBurn.Burn(Me.Handle)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            GoTo ExitProc
        End Try

ExitProc:
        Clean_CDRom_Data(BurnerPath)
        cmdBurn.Enabled = True
        ListViewStudies.Enabled = True
        WaitDlg(False)
    End Sub

    Private Sub Clean_CDRom_Data(ByVal BurnerPath As String)
        On Error Resume Next
        gDeleteFolder(BurnerPath)
        IO.Directory.Delete(BurnerPath & "\DICOM", True)
        IO.Directory.Delete(BurnerPath & "\DICOM\", True)
        IO.Directory.Delete(BurnerPath & "\eFilmLite", True)
        IO.Directory.Delete(BurnerPath & "\eFilmLite\", True)

        gDeleteFolder(gAppPath & "CDTemp\DICOM\")
        If IO.File.Exists(gAppPath & "CDTemp\DICOMDIR") Then
            IO.File.Delete(gAppPath & "CDTemp\DICOMDIR")
        End If

    End Sub

    Sub AddDirectorySecurity(ByVal FileName As String, ByVal Account As String, ByVal Rights As FileSystemRights, ByVal ControlType As AccessControlType)
        ' Create a new DirectoryInfoobject.
        Dim dInfo As New DirectoryInfo(FileName)

        ' Get a DirectorySecurity object that represents the
        ' current security settings.
        Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()
        Try
            ' Add the FileSystemAccessRule to the security settings.
            dSecurity.AddAccessRule(New FileSystemAccessRule(Account, Rights, ControlType))
            ' Set the new access settings.
            dInfo.SetAccessControl(dSecurity)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try

    End Sub

    Private Sub WaitDlg(ByVal Show As Boolean)
        lblProgress.Text = ""
        If Show Then
            ProgressBar1.Value = 0
            Cursor = Cursors.WaitCursor
            ProgressBar1.Visible = True
            lblProgress.Visible = True
        Else
            Cursor = Cursors.Default
            ProgressBar1.Visible = False
            lblProgress.Visible = False
            ProgressBar1.Value = 100
        End If
        Application.DoEvents()

    End Sub

    Private Sub ShowCD()

        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()

        Dim d As DriveInfo
        For Each d In allDrives
            If d.DriveType = DriveType.CDRom Then
                If IO.File.Exists(d.Name & "eFilmLite\eFilmLt.exe") Then
                    Shell(d.Name & "eFilmLite\eFilmLt.exe", AppWinStyle.NormalFocus)
                End If
            End If
        Next
    End Sub

    Private Sub Delete_Files(ByVal Fname As String)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        LabelCount.Text = "Studies to be copied to CD: " & ListViewStudies.CheckedItems.Count
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListViewStudies.BeginUpdate()
        For Each LI In ListViewStudies.Items
            If LI.Checked = False Then LI.Checked = True
        Next
        ListViewStudies.EndUpdate()
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListViewStudies.BeginUpdate()
        For Each LI In ListViewStudies.Items
            If LI.Checked = True Then LI.Checked = False
        Next
        ListViewStudies.EndUpdate()

    End Sub

    Private Sub ListViewSeries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewSeries.SelectedIndexChanged
        gHighlightListviewItem(ListViewSeries)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        WaitDlg(True)
        lblProgress.Text = "Print In Progress"
        ProgressBar1.Value = 10
        lblProgress.Refresh()
        Try
            If gCDEnvelopeLabelType = 1 Then
                CR = New rptImageDiskEnvelopeLabel
            Else
                CR = New rptCDShippingLabel
            End If

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            ProgressBar1.Value = 50
            ProgressBar1.Refresh()
            CR.SetParameterValue("CDInvoiceID", InvoiceID.ToString)
            If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
            'Set Label Size to Priter Paper Size
            Dim doctoprint As New System.Drawing.Printing.PrintDocument()
            doctoprint.PrinterSettings.PrinterName = gPrinterFileLabel
            CR.PrintOptions.PaperSize = doctoprint.DefaultPageSettings.PaperSize.RawKind

            CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
            CR.PrintToPrinter(1, False, 0, 0)
            ProgressBar1.Value = 100
            ProgressBar1.Refresh()
        Catch ex As Exception
            ProgressBar1.Value = 0
            ProgressBar1.Refresh()
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        lblProgress.Text = ""
        lblProgress.Refresh()
        WaitDlg(False)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            CR = New rptImageCDDisk

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("RequestID", InvoiceID.ToString)
            If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gCDLabelPrinter

            CR.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
    End Sub

End Class