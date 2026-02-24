Imports System.Reflection
Imports log4net

Public Class frmPDFPreview
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmDocumentPreview_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        pdfViewer.CloseDocument(False)
    End Sub

    Private Sub frmDocumentPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'gWindow_Settings(Me, ReadWrite.sRead)
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
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

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtoneMail.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: Document"
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
        'pdfViewer.setShowToolbar(False)
        'pdfViewer.setShowScrollbars(True)
        Application.DoEvents()
        'pdfViewer.setView("Fit")
        'pdfViewer.setLayoutMode("SinglePage")
        pdfViewer.LoadDocument(pdfViewer.Tag.ToString())
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveFileDialog1.InitialDirectory = GetSetting(My.Application.Info.ProductName, "Settings", "PDFLastFilePath", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))
        SaveFileDialog1.FileName = pdfViewer.Tag
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.AutoUpgradeEnabled = True
        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                If System.IO.File.Exists(SaveFileDialog1.FileName) Then
                    IO.File.Delete(SaveFileDialog1.FileName)
                End If
                If pdfViewer.Tag.ToString().Right(3).ToUpper = "PDF" Then
                    IO.File.Copy(pdfViewer.Tag, SaveFileDialog1.FileName)
                Else
                    Image.FromFile(pdfViewer.Tag).Save(SaveFileDialog1.FileName)
                End If

                SaveSetting(My.Application.Info.ProductName, "Settings", "PDFLastFilePath", System.IO.Path.GetDirectoryName(SaveFileDialog1.FileName))
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try

        End If
    End Sub

    Private Sub ButtonFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFax.Click
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to process your request. No document loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        gFax(Me, "", "Attached: Document", pdfViewer.Tag, gOfficeFax)
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

End Class