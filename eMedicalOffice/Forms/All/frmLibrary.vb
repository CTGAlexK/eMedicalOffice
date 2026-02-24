Imports System.IO
Imports System.Reflection
Imports log4net

Public Class frmLibrary
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientID As Long
    Public BillID As Long
    Public calledForm As Form
    Private Files As List(Of ListFile)
    Private DataFields As DocFields
    Private TempFile As String = ""
    Private docAdded As Boolean

    Private Sub frmDocumentPreview_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If LabelDocumentChanged.Visible Then
            If MsgBox("You have unsaved document." & vbCrLf & "Discard Changes?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If

        End If
        gWindow_Settings(Me, ReadWrite.sWrite)
        DialogResult = DialogResult.OK
    End Sub

    Private checkPrint As Integer

    Private Sub frmLibrary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gSystemLibraryPath.Trim().Length = 0 Then
            MsgBox("Unable to open documents library." & vbCrLf & "The Documents library path is not set.", MsgBoxStyle.Critical, "Oops")
            Close()
        End If
        If gCanRead(gSystemLibraryPath) = False Then
            MsgBox("Unable to open documents library." & vbCrLf & "The path: " & gSystemLibraryPath & " is not exists or not accessible.", MsgBoxStyle.Critical, "Oops")
            Close()
        End If
        gWindow_Settings(Me, ReadWrite.sRead)
        Dim FontSize As Integer
        DataFields = New DocFields(BillID)
        'PatientID = DataFields.PATIENTID
        LabelPatient.Text = "PAT ID: " & DataFields.PATIENTID & "   " & DataFields.PATIENTNAME.ToUpper & "  BILL #:" & DataFields.BILLNO
        SetFont()
        Files = New List(Of ListFile)
        Timer1.Enabled = True
    End Sub

    Private Sub loadDocuments()
        Dim LV As ListViewItem
        Dim lFiles As List(Of String)
        ListViewDocuments.Items.Clear()
        RichTextBox1.Text = ""
        LabelCount.Text = "Loading Documents..."
        Application.DoEvents()
        LabelPatient.Refresh()

        Try
            If My.Computer.FileSystem.DirectoryExists(gSystemLibraryPath) Then

                lFiles = My.Computer.FileSystem.GetFiles(gSystemLibraryPath, FileIO.SearchOption.SearchAllSubDirectories, "*.rtf").ToList()
                lFiles.Sort()

                For Each foundFile As String In lFiles
                    Dim f As New ListFile
                    f.FileName = Path.GetFileNameWithoutExtension(foundFile)
                    f.FilePath = foundFile
                    LV = ListViewDocuments.Items.Add(f.FileName)
                    LV.Tag = foundFile
                    Files.Add(f)
                Next
            Else
                MsgBox("The folder " & gSystemLibraryPath & " is not accessible.", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If
        Catch ex As Exception
            LabelCount.Text = "Error Loading..."
            log.Error("frmLibrary.loadDocuments", ex)
            MsgBox("Error" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
        If ListViewDocuments.Items.Count > 0 Then
            ListViewDocuments.Items(0).Selected = True
            ListViewDocuments.Items(0).EnsureVisible()
            ListViewDocuments_SelectedIndexChanged(Nothing, Nothing)
        End If
        LabelCount.Text = ListViewDocuments.Items.Count & " Documents"
        ListViewDocuments.Columns(0).Width = ListViewDocuments.Width - 25
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    Private Sub TextBoxReading_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        Try
            If ListViewDocuments.Columns.Count > 0 Then
                ListViewDocuments.Columns(0).Width = ListViewDocuments.Width - 25
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        RichTextBox1.Text = ""
        RichTextBox2.Text = ""

        loadDocuments()
        If TextBoxSearch.CanFocus Then TextBoxSearch.Focus()

    End Sub

    Private SaveIndex As Integer = 0
    Private Skeep As Boolean
    Private nOtRANSLATION As Boolean

    Private Sub ListViewDocuments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewDocuments.SelectedIndexChanged
        If selecting Or ListViewDocuments.SelectedItems.Count = 0 Then Exit Sub

        If RichTextBox1.Rtf <> RichTextBox2.Rtf Then
            If SaveIndex <> ListViewDocuments.SelectedItems(0).Index Then
                If MsgBox("The current document has been changed." & vbCrLf & "Discard Changes?" & vbCrLf & vbCrLf & "To save document to the patient's profile, click the Add To Patient button.", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Document Changed") = MsgBoxResult.No Then
                    selecting = True
                    TimerReset.Enabled = True
                    Exit Sub
                End If
            End If
        End If
        Skeep = False
        LabelDocumentChanged.Visible = False
        If File.Exists(TempFile) Then
            Try
                Kill(TempFile)
            Catch
            End Try
        End If
        If nOtRANSLATION = False Then

            SaveIndex = ListViewDocuments.SelectedIndices(0)
            Dim fname As String = ListViewDocuments.SelectedItems(0).Tag
            If File.Exists(fname) Then
                ListViewDocuments.SuspendLayout()
                gLockWindowUpdate(ListViewDocuments.Handle, False)
                RichTextBox1.LoadFile(fname)
                RichTextBox2.LoadFile(fname)
                ReplaceText("OFFICENAME", DataFields.OFFICENAME)
                ReplaceText("OFFICEADDRESS", DataFields.OFFICEADDRESS)
                ReplaceText("OFFICECITYSTATEZIP", DataFields.OFFICECITYSTATEZIP)
                ReplaceText("OFFICEPHONE", DataFields.OFFICEPHONE)
                ReplaceText("OFFICEFAX", DataFields.OFFICEFAX)
                ReplaceText("BILLINGOFFICENAME", DataFields.BILLINGOFFICENAME)
                ReplaceText("BILLINGOFFICEADDRESS", DataFields.BILLINGOFFICEADDRESS)
                ReplaceText("BILLINGOFFICECITYSTATEZIP", DataFields.BILLINGOFFICECITYSTATEZIP)
                ReplaceText("BILLINGOFFICEPHONE", DataFields.BILLINGOFFICEPHONE)
                ReplaceText("BILLINGOFFICEFAX", DataFields.BILLINGOFFICEFAX)
                ReplaceText("PATIENTNAME", DataFields.PATIENTNAME)
                ReplaceText("PATIENTDOB", DataFields.PATIENTDOB)
                ReplaceText("DATEOFBIRTH", DataFields.PATIENTDOB)
                ReplaceText("HOMEADDRESS", DataFields.HOMEADDRESS)
                ReplaceText("HOMEADDRESSFULL", DataFields.HOMEADDRESSFULL)
                ReplaceText("HOMECITYSTATEZIP", DataFields.HOMECITYSTATEZIP)
                ReplaceText("CURRENTDATE", DataFields.CURRENTDATE)
                ReplaceText("INSURANCECOMP", DataFields.INSURANCECOMP)
                ReplaceText("INSURANCENAME", DataFields.INSURANCECOMP)
                ReplaceText("INSADDRESS", DataFields.INSADDRESS)
                ReplaceText("INSCITYSTATEZIP", DataFields.INSCITYSTATEZIP)
                ReplaceText("INSPHONE", DataFields.INSPHONE)
                ReplaceText("INSFAX", DataFields.INSFAX)
                ReplaceText("CLAIMNUMBER", DataFields.CLAIMNUMBER)
                ReplaceText("DATEACC", DataFields.DATEACC)
                ReplaceText("DATEOFACCIDENT", DataFields.DATEACC)
                ReplaceText("MONTHDATEYEAR", DataFields.DATEACC)
                ReplaceText("DATESOFSERVICES", DataFields.DATESOFSERVICES)
                ReplaceText("SERVICEDATE", DataFields.DATESOFSERVICES)
                ReplaceText("DATEOFSERVICE", DataFields.DATESOFSERVICES)
                ReplaceText("BILLNO", DataFields.BILLNO)
                ReplaceText("BILLDATE", DataFields.INSPHONE)
                ReplaceText("BILLAMOUNT", DataFields.BILLAMOUNT)
                ReplaceText("PATIENTID", DataFields.PATIENTID)
                ReplaceText("CURRDATE", DataFields.CURRENTDATE)
                ListViewDocuments.ResumeLayout()
                gLockWindowUpdate(ListViewDocuments.Handle, True)
            End If
        End If
        RichTextBox1.Width = 100

        checkChanges()

        gHighlightListviewItem(ListViewDocuments)
    End Sub

    Private Sub ReplaceText(FromStr As String, ToString As String)
        Dim indx As Integer = 1
        If ToString = "" Then ToString = " "
        indx = RichTextBox1.Find(FromStr, 0, RichTextBoxFinds.None)
        Do Until indx = -1
            RichTextBox1.Select(indx, FromStr.Length)
            RichTextBox2.Select(indx, FromStr.Length)

            If RichTextBox1.SelectedText <> "" Then
                RichTextBox1.SelectedText = ToString
                RichTextBox2.SelectedText = ToString
            End If
            indx = RichTextBox1.Find(FromStr, indx + 1, RichTextBoxFinds.None)
        Loop
    End Sub

    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        ListViewDocuments.Font = F
        'RichTextBox1.ZoomFactor = RichTextBox1.ZoomFactor +incr
    End Sub

    Private Sub ButtonDn_Click(sender As Object, e As EventArgs) Handles ButtonDn.Click
        SetFont(1)
    End Sub

    Private Sub ButtonUp_Click(sender As Object, e As EventArgs) Handles ButtonUp.Click
        SetFont(-1)
    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        Dim LV As ListViewItem
        LabelDocumentChanged.Visible = False
        Dim result = Files.OfType(Of ListFile)().
        Where(Function(s) s.FileName.ToUpper.Contains(TextBoxSearch.Text.ToUpper))
        ListViewDocuments.Items.Clear()
        SaveIndex = 0
        RichTextBox2.Text = ""
        RichTextBox1.Text = ""

        For Each foundFile In result
            LV = ListViewDocuments.Items.Add(foundFile.FileName)
            LV.Tag = foundFile.FilePath
        Next
        LabelCount.Text = ListViewDocuments.Items.Count & " Documents"
        If ListViewDocuments.Items.Count > 0 Then
            Timer2.Enabled = False
            Timer2.Enabled = True
        End If

    End Sub

    Private selecting As Boolean

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        If ListViewDocuments.Items.Count > 0 Then
            selecting = True
            ListViewDocuments.Items(0).Selected = True
            ListViewDocuments.Items(0).EnsureVisible()
            selecting = False
            ListViewDocuments_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub TextBoxSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSearch.KeyDown
        If e.KeyValue = 40 Then
            ListViewDocuments.Focus()
        End If
    End Sub

    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonOpenDocument.Click
        TempFile = Path.GetTempFileName()
        TempFile = TempFile.Mid(1, TempFile.Length - 3) & "rtf"
        RichTextBox1.SaveFile(TempFile)
        Dim objProcess As System.Diagnostics.Process
        Try
            objProcess = New System.Diagnostics.Process()
            objProcess.StartInfo.FileName = TempFile
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            objProcess.Start()
            'Wait until the process passes back an exit code
            objProcess.WaitForExit()
            'Free resources associated with this process
            objProcess.Close()
            RichTextBox1.LoadFile(TempFile)

            If RichTextBox1.Rtf <> RichTextBox2.Rtf Then
                LabelDocumentChanged.Visible = True
            End If
        Catch ex As Exception
            log.Error("ToolStripButtonRTF_Click", ex)
            MsgBox(ex.Message, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TimerReset_Tick(sender As Object, e As EventArgs) Handles TimerReset.Tick
        TimerReset.Enabled = False
        If SaveIndex > ListViewDocuments.Items.Count Then Exit Sub
        ListViewDocuments.Items(SaveIndex).Selected = True
        ListViewDocuments.Items(SaveIndex).EnsureVisible()
        selecting = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonAddToPatient.Click

        If ListViewDocuments.SelectedItems.Count = 0 Then
            MsgBox("Unable to add document to patient." & vbCrLf & "No document selected.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If gSQLGetSingleValue("select count(*) from PatientRTFDocuments where PatientID = " & PatientID & " and DocName = '" & ListViewDocuments.SelectedItems(0).Text.ToSafeSQLString() & "'") > 0 Then
            If MsgBox("The document [" & ListViewDocuments.SelectedItems(0).Text & "] is already exists in  the patient's profile." & vbCrLf & vbCrLf & "Please confirm you want to add another [" & ListViewDocuments.SelectedItems(0).Text & "] to the patient profile?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        Else
            If MsgBox("Please confirm you want to add [" & ListViewDocuments.SelectedItems(0).Text & "] to the patient's profile." & vbCrLf & vbCrLf & "Continue?.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM PatientRTFDocuments Where 1=2", gConnectionString)
        Dim CB As New SqlClient.SqlCommandBuilder(TA)
        CB.ConflictOption = ConflictOption.OverwriteChanges
        Dim TR As DataRow
        Dim dTab As New DataTable("PatientRTFDocuments")
        TA.Fill(dTab)
        TR = dTab.Rows.Add
        TR("PatientID") = PatientID
        TR("DocName") = ListViewDocuments.SelectedItems(0).Text
        TR("Data") = RichTextBox1.Rtf
        TR("DocDate") = Now.Date
        TR("AddedBy") = gCurrentEmployee.EmpID

        TA.UpdateCommand = CB.GetUpdateCommand(True)
        Try
            TA.Update(dTab)
            dTab.AcceptChanges()
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tDocumentAdded, ListViewDocuments.SelectedItems(0).Text)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Exit Sub
        End Try
        dTab.Dispose()
        CB.Dispose()
        TA.Dispose()
        MsgBox("The [" & ListViewDocuments.SelectedItems(0).Text & "] has been added to the patient's profile" & vbCrLf & vbCrLf & "The current document will be reset to the original template.", MsgBoxStyle.Information, "Complete")
        docAdded = True
        RichTextBox1.Rtf = RichTextBox2.Rtf
        LabelDocumentChanged.Visible = False
        If TempFile.Length > 0 AndAlso File.Exists(TempFile) Then
            Try
                Kill(TempFile)
            Catch

            End Try
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        frmLibraryHelp.ShowDialog(Me)
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Print the content of the RichTextBox. Store the last character printed.
        checkPrint = RichTextBox1.Print(checkPrint, RichTextBox1.TextLength, e)

        ' Look for more pages
        If checkPrint < RichTextBox1.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub SelectFontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectFontToolStripMenuItem.Click

        Try
            If Not (RichTextBox1.SelectionFont Is Nothing) Then
                FontDialog1.Font = RichTextBox1.SelectionFont
            Else
                FontDialog1.Font = Nothing
            End If
            FontDialog1.ShowApply = True
            If FontDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.SelectionFont = FontDialog1.Font
                checkChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub tbrFont_Click(sender As Object, e As EventArgs) Handles tbrFont.Click
        SelectFontToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub FontColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontColorToolStripMenuItem.Click
        Try
            ColorDialog1.Color = RichTextBox1.ForeColor
            If ColorDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.SelectionColor = ColorDialog1.Color

                checkChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub tspColor_Click(sender As Object, e As EventArgs) Handles tspColor.Click
        FontColorToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuPageSetup_Click(sender As Object, e As EventArgs) Handles mnuPageSetup.Click

        Try
            PageSetupDialog1.Document = PrintDocument1
            If PageSetupDialog1.ShowDialog() <> DialogResult.Cancel Then
                checkChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click

        Try
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try

    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click

        Try
            PrintDialog1.Document = PrintDocument1
            If PrintDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                PrintDocument1.Print()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub mnuUndo_Click(sender As Object, e As EventArgs) Handles mnuUndo.Click

        Try
            If RichTextBox1.CanUndo Then
                RichTextBox1.Undo()
            End If
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub mnuRedo_Click(sender As Object, e As EventArgs) Handles mnuRedo.Click

        Try
            If RichTextBox1.CanRedo Then
                RichTextBox1.Redo()
            End If
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click

        Try
            RichTextBox1.SelectAll()
        Catch generatedExceptionName As Exception
            MessageBox.Show("Unable to select all document content.", "RTE - Select", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click

        Try
            RichTextBox1.Copy()
        Catch generatedExceptionName As Exception
            MessageBox.Show("Unable to copy document content.", "RTE - Copy", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click

        Try
            RichTextBox1.Cut()
            checkChanges()
        Catch
            MessageBox.Show("Unable to cut document content.", "RTE - Cut", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click

        Try
            RichTextBox1.Paste()
            checkChanges()
        Catch
            MessageBox.Show("Unable to copy clipboard content to document.", "RTE - Paste", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub InsertImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertImageToolStripMenuItem.Click
        OpenFileDialog1.Title = "Insert Image File"
        OpenFileDialog1.DefaultExt = ""
        OpenFileDialog1.Filter = "All Picture Files|*.bmp;*.jpg;*.gif;*.png|Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif|PNG Files|*.png"
        OpenFileDialog1.FilterIndex = 0
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Return
        End If

        If OpenFileDialog1.FileName = "" Then
            Return
        End If

        Try
            Dim strImagePath As String = OpenFileDialog1.FileName
            Dim img As Image
            img = Image.FromFile(strImagePath)
            Clipboard.SetDataObject(img)
            Dim df As DataFormats.Format
            df = DataFormats.GetFormat(DataFormats.Bitmap)
            If RichTextBox1.CanPaste(df) Then
                RichTextBox1.Paste(df)
            End If
            LabelDocumentChanged.Visible = True
        Catch
            MessageBox.Show("Unable to insert image format selected.", "RTE - Paste", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub BoldToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BoldToolStripMenuItem.Click

        Try
            If Not (RichTextBox1.SelectionFont Is Nothing) Then
                Dim currentFont As System.Drawing.Font = RichTextBox1.SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle

                newFontStyle = RichTextBox1.SelectionFont.Style Xor FontStyle.Bold
                RichTextBox1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

                checkChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub ItalicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItalicToolStripMenuItem.Click

        Try
            If Not (RichTextBox1.SelectionFont Is Nothing) Then
                Dim currentFont As System.Drawing.Font = RichTextBox1.SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle

                newFontStyle = RichTextBox1.SelectionFont.Style Xor FontStyle.Italic

                RichTextBox1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

                checkChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub UnderlineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnderlineToolStripMenuItem.Click

        Try
            If Not (RichTextBox1.SelectionFont Is Nothing) Then
                Dim currentFont As System.Drawing.Font = RichTextBox1.SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle

                newFontStyle = RichTextBox1.SelectionFont.Style Xor FontStyle.Underline

                RichTextBox1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

                checkChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try

    End Sub

    Private Sub NormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalToolStripMenuItem.Click

        Try
            If Not (RichTextBox1.SelectionFont Is Nothing) Then
                Dim currentFont As System.Drawing.Font = RichTextBox1.SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle
                newFontStyle = FontStyle.Regular
                RichTextBox1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

                checkChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub PageColorToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Try
            ColorDialog1.Color = RichTextBox1.BackColor
            If ColorDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.BackColor = ColorDialog1.Color

                checkChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub IndentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndentToolStripMenuItem.Click

        Try
            RichTextBox1.SelectionIndent = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub mnuIndent5_Click(sender As Object, e As EventArgs) Handles mnuIndent5.Click
        Try
            RichTextBox1.SelectionIndent = 5
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub mnuIndent10_Click(sender As Object, e As EventArgs) Handles mnuIndent10.Click
        Try
            RichTextBox1.SelectionIndent = 10
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub mnuIndent15_Click(sender As Object, e As EventArgs) Handles mnuIndent15.Click
        Try
            RichTextBox1.SelectionIndent = 15
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub mnuIndent20_Click(sender As Object, e As EventArgs) Handles mnuIndent20.Click
        Try
            RichTextBox1.SelectionIndent = 20
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub LeftToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeftToolStripMenuItem.Click

        Try
            RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub CenterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CenterToolStripMenuItem.Click

        Try
            RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub RightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RightToolStripMenuItem.Click

        Try
            RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub AddBulletsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddBulletsToolStripMenuItem.Click

        Try
            RichTextBox1.BulletIndent = 10
            RichTextBox1.SelectionBullet = True
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub RemoveBulletsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveBulletsToolStripMenuItem.Click

        Try
            RichTextBox1.SelectionBullet = False
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub tbrLeft_Click(sender As Object, e As EventArgs) Handles tbrLeft.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
        checkChanges()
    End Sub

    Private Sub tbrCenter_Click(sender As Object, e As EventArgs) Handles tbrCenter.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
        checkChanges()
    End Sub

    Private Sub tbrRight_Click(sender As Object, e As EventArgs) Handles tbrRight.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
        checkChanges()
    End Sub

    Private Sub tbrBold_Click(sender As Object, e As EventArgs) Handles tbrBold.Click

        BoldToolStripMenuItem_Click(Nothing, e)
    End Sub

    Private Sub tbrItalic_Click(sender As Object, e As EventArgs) Handles tbrItalic.Click
        ItalicToolStripMenuItem_Click(Nothing, e)
    End Sub

    Private Sub tbrUnderline_Click(sender As Object, e As EventArgs) Handles tbrUnderline.Click
        UnderlineToolStripMenuItem_Click(Nothing, e)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        InsertImageToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        checkChanges()
    End Sub

    Private Sub mnuIndent0_Click(sender As Object, e As EventArgs) Handles mnuIndent0.Click

        Try
            RichTextBox1.SelectionIndent = 0
            checkChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If Not (RichTextBox1.SelectedText Is Nothing) Then
                Dim selstart = RichTextBox1.SelectionStart
                Dim sellen = RichTextBox1.SelectionLength
                RichTextBox1.SelectedText = RichTextBox1.SelectedText.ToUpper
                checkChanges()
                RichTextBox1.SelectionStart = selstart
                RichTextBox1.SelectionLength = sellen
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            If Not (RichTextBox1.SelectedText Is Nothing) Then
                Dim selstart = RichTextBox1.SelectionStart
                Dim sellen = RichTextBox1.SelectionLength
                RichTextBox1.SelectedText = RichTextBox1.SelectedText.ToLower
                checkChanges()
                RichTextBox1.SelectionStart = selstart
                RichTextBox1.SelectionLength = sellen

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error")
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        PrintToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ResetAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetAllToolStripMenuItem.Click
        If MsgBox("Discard All Changes?", MsgBoxStyle.Critical + vbYesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        RichTextBox1.Rtf = RichTextBox2.Rtf
        LabelDocumentChanged.Visible = False
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        ResetAllToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub LabelDocumentChanged_VisibleChanged(sender As Object, e As EventArgs) Handles LabelDocumentChanged.VisibleChanged

    End Sub

    Private Sub TextBoxSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearch.KeyPress
        If RichTextBox1.Rtf <> RichTextBox2.Rtf Then
            If MsgBox("The current document has been changed." & vbCrLf & "Discard Changes?" & vbCrLf & vbCrLf & "To save document to the patient's profile, click the Add To Patient button.", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Document Changed") = MsgBoxResult.No Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Fname As String
        If ListViewDocuments.SelectedItems.Count = 0 Then
            MsgBox("Unable to Save. No document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            Fname = ListViewDocuments.SelectedItems(0).Text
        End If
        SaveFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf"
        SaveFileDialog1.DefaultExt = "rtf"
        Fname &= ".rtf"
        Fname = gFixFileName(Fname)
        SaveFileDialog1.FileName = Fname
        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                RichTextBox1.SaveFile(SaveFileDialog1.FileName)
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim TempFile As String
        Dim Subject As String
        If ListViewDocuments.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Subject = "Document: " & ListViewDocuments.SelectedItems(0).Text
        TempFile = Path.GetTempFileName()
        TempFile = TempFile.Mid(1, TempFile.Length - 3) & "rtf"
        Try
            RichTextBox1.SaveFile(TempFile)
            gFax(Me, "", Subject, TempFile, gOfficeFax)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim fCount As Integer
        Dim DocNames As String
        Dim Fname() As String = Nothing
        If ListViewDocuments.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim TempFile As String
        Subject = "Document: " & ListViewDocuments.SelectedItems(0).Text
        TempFile = Path.GetTempFileName()
        TempFile = TempFile.Mid(1, TempFile.Length - 3) & "rtf"
        Try
            RichTextBox1.SaveFile(TempFile)
            Msg.SendMail(TempFile, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PrintToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub CrToolStripTextBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If RichTextBox1.Rtf <> RichTextBox2.Rtf Then
            e.Cancel = True
        End If

    End Sub

    Private Sub RefreshLibraryDocumentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshLibraryDocumentsToolStripMenuItem.Click
        Timer1.Enabled = True
    End Sub

    Private pos As Integer = 0
    Private stuff As String = "DOCUMENT CHANGED"

    Private Sub checkChanges()
        If RichTextBox1.Rtf = RichTextBox2.Rtf Then
            LabelDocumentChanged.Visible = False
            Timer3.Enabled = False
        Else
            If LabelDocumentChanged.Visible = False Then
                LabelDocumentChanged.Text = ""
                LabelDocumentChanged.Visible = True
                Timer3.Interval = 20
                pos = 0
                Timer3.Enabled = True
            End If
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If pos < stuff.Length Then
            LabelDocumentChanged.Text = LabelDocumentChanged.Text & (Mid(stuff, pos + 1, 1))
            pos += 1
        Else
            Timer3.Enabled = False
        End If
    End Sub

End Class

Public Class ListFile
    Public FileName As String
    Public FilePath As String
End Class