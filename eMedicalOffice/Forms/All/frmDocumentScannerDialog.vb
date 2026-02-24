Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports log4net

Public Class frmDocumentScannerDialog
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    'Public CalledViewer As WebBrowser
    Public CalledViewer As PdfiumViewer.PdfViewer

    Public DialogText As String

    Private Sub frmDocumentScannerDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gScannerFolder = "" Then
            MsgBox(
                "Unable to scan. The Scanner Folder has not been specified." & vbCrLf &
                "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        gDeleteAllFiles(gScannerFolder, "*.pdf", True, True)
        FileSystemWatcher.Path = gScannerFolder
        FileSystemWatcher.EnableRaisingEvents = True
        Label1.Text = DialogText
        Select Case gScannerImageIndex
            Case -1
                PictureBox1.Image = Nothing
            Case 0
                PictureBox1.Image = My.Resources.Scanner1
            Case 1
                PictureBox1.Image = My.Resources.Scanner2
            Case 2
                PictureBox1.Image = My.Resources.Scanner3
            Case 3
                PictureBox1.Image = My.Resources.Scanner4
            Case 4
                PictureBox1.Image = My.Resources.Scanner5
            Case 5
                PictureBox1.Image = My.Resources.Scanner6
            Case 6
                PictureBox1.Image = My.Resources.Scanner7
            Case 7
                PictureBox1.Image = My.Resources.Scanner8
            Case 8
                PictureBox1.Image = My.Resources.Scanner9
            Case 9
                PictureBox1.Image = My.Resources.Scanner10
            Case 10
                PictureBox1.Image = My.Resources.Scanner11
            Case 11
                PictureBox1.Image = My.Resources.Scanner12
            Case 12
                PictureBox1.Image = My.Resources.Scanner13
            Case 13
                PictureBox1.Image = My.Resources.Scanner14
            Case 14
                PictureBox1.Image = My.Resources.Scanner15
        End Select
        Label1.Text =
            "Place a Document into the Scanner document feeder and click the Scan button (simple or duplex)." & vbCrLf &
            "Make sure the correct profile is selected."
    End Sub

    Private FileName As String

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim FName As String
        Dim retryCount As Integer
        Timer1.Enabled = False
RetryProcess:
        retryCount = retryCount + 1
        FName = Path.GetTempFileName.ToString
        Try
            FName = FName.Replace("tmp", "pdf")
            log.Debug("Retry: " & retryCount & " Move: " & FileName & " to " & FName)
            lblStatus.Text = "Processing File... " & retryCount.ToString
            lblStatus.Refresh()
            Application.DoEvents()
            Thread.Sleep(500)
            Application.DoEvents()
            File.Move(FileName, FName)
            ShowDocument(FName)
            Application.DoEvents()
            Try
                gDeleteAllFiles(gScannerFolder, "*.pdf", True, False)
            Catch ex As Exception
            End Try

            DialogResult = DialogResult.OK
            Close()
            Return
        Catch ex As Exception
            Dim lockers As List(Of Process) = FindLockers(FileName)
            Dim msg As String
            If lockers.Count > 0 Then
                msg = "Unable to process file: " & FileName & "." & vbCrLf & "The file it is locked by:" &
                        vbCrLf
                For Each item As Process In lockers
                    msg = msg & item.ProcessName & vbCrLf
                Next
                log.Error(msg & vbCrLf & ex.Message, ex)
            Else
                log.Error(ex.Message, ex)
            End If

            Try
                If File.Exists(FileName) Then
                    FName = Path.GetTempFileName.ToString
                    log.Debug("Retry: " & retryCount & " Copy: " & FileName & " to " & FName)
                    lblStatus.Text = "Processing File... " & retryCount
                    lblStatus.Refresh()
                    Application.DoEvents()
                    Thread.Sleep(500)
                    Application.DoEvents()
                    File.Copy(FileName, FName, True)
                    ShowDocument(FName)
                    Application.DoEvents()
                    gDeleteAllFiles(gScannerFolder, "*.pdf", False, False)
                    DialogResult = DialogResult.OK
                    Close()
                    Return
                End If
            Catch ex1 As Exception
                lockers = FindLockers(FileName)
                If lockers.Count > 0 Then
                    msg = "Unable to process file: " & FileName & "." & vbCrLf & "The file it is locked by:" &
                            vbCrLf
                    For Each item As Process In lockers
                        msg = msg & item.ProcessName & vbCrLf
                    Next
                    log.Error(msg & vbCrLf & ex.Message, ex)
                Else
                    log.Error(ex.Message, ex)
                End If

                log.Error(ex1.Message, ex1)
                If retryCount < 5 Then
                    Thread.Sleep(1000)
                    GoTo RetryProcess
                End If
                MsgBox(ex1.Message & vbCrLf & "Retry 5", MsgBoxStyle.Exclamation, "Oops...")
                DialogResult = DialogResult.Cancel
            End Try
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Ooops...")
        End Try
    End Sub

    Private Sub ShowDocument(fName As String)
        Dim RetryCount = 1
        Do Until RetryCount = 5
            lblStatus.Text = "Loading File... "
            lblStatus.Refresh()

            Try
                log.Debug("Retry " & RetryCount & " CalledViewer Navigate: " & fName)
                'CalledViewer.NavigateURL(FName)
                CalledViewer.LoadDocument(fName)
                CalledViewer.Tag = fName
                Return
            Catch ex As Exception
                log.Error(ex.Message, ex)
            End Try
            Thread.Sleep(1000)
            RetryCount = RetryCount + 1
        Loop
        MsgBox("Unable to load document into viewer." & vbCrLf & "Please try again...", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub FileSystemWatcher_Created(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher.Created
        ButtonCancel.Enabled = True
        lblStatus.Text = "Scan Started"
        FileName = e.FullPath
        If FileName.ToString().Right(3).ToUpper() = "PDF" Then
            lblStatus.Text = "Scan Complete"
            FileSystemWatcher.EnableRaisingEvents = False
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub FileSystemWatcher_Renamed(sender As Object, e As RenamedEventArgs) Handles FileSystemWatcher.Renamed

        FileName = e.FullPath
        If FileName.Right(3).ToUpper() = "PDF" Then
            lblStatus.Text = "Scan Complete"
            FileSystemWatcher.EnableRaisingEvents = False
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub FileSystemWatcher_Changed(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher.Changed
    End Sub

    Private Sub frmDocumentScannerDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

End Class