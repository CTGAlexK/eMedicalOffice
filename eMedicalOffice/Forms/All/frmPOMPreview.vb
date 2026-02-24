Imports System.Reflection
Imports log4net

Public Class frmPOMPreview
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmDocumentPreview_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        pdfViewer.CloseDocument(False)
    End Sub

    Private Sub frmDocumentPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        pdfViewer.PrintDocument(Me)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtoneMail.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to process your request. No Document Scanned")
        End If
        Subject = "Attached: POM #" & Tag & " PDF File"
        Fname = pdfViewer.Tag
        Try
            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        If Tag <> "" Then
            Label42.Text = "POM FOR THE BILL #" & Tag
        End If
        'pdfViewer.setShowToolbar(False)
        'pdfViewer.setShowScrollbars(True)
        'Application.DoEvents()
        'pdfViewer.setView("Fit")
        'pdfViewer.setLayoutMode("SinglePage")
        pdfViewer.LoadDocument(pdfViewer.Tag.ToString())
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveFileDialog1.InitialDirectory = GetSetting(My.Application.Info.ProductName, "Settings", "POMLastFilePath", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))
        SaveFileDialog1.FileName = "POM-" & Tag & ".pdf"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.AutoUpgradeEnabled = True
        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                If System.IO.File.Exists(SaveFileDialog1.FileName) Then
                    IO.File.Delete(SaveFileDialog1.FileName)
                End If
                If pdfViewer.Tag.ToString.Right(3).ToUpper = "PDF" Then
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

    Private Sub ButtonFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFax.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to process your request. No Document Scanned")
        End If
        Subject = "Attached: POM #" & Tag & " PDF File"
        Fname = pdfViewer.Tag
        Try
            gFax(Me, "", "Attached: Document", pdfViewer.Tag, gOfficeFax)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

End Class