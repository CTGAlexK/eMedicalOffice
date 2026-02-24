Imports System.Reflection
Imports log4net

Public Class frmDocumentPreview
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmDocumentPreview_FormClosing(ByVal sender As Object,
                                               ByVal e As System.Windows.Forms.FormClosingEventArgs) _
        Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", "DocumentPreviewFont", TextBoxReading.Font.Size)
        pdfViewer.CloseDocument(False)
    End Sub

    Private Sub frmDocumentPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        Dim FontSize As Integer
        FontSize = GetSetting(My.Application.Info.ProductName, "Settings", "DocumentPreviewFont",
                              TextBoxReading.Font.Size)
        TextBoxReading.Font = New Font(TextBoxReading.Font.Name, FontSize, FontStyle.Regular)
        ToolStripFontSize.Renderer = New ToolStripOverride
        If RichTextBox1.Visible Then
            ButtonRotatePDF.Visible = False
        Else
            ButtonRotatePDF.Visible = True
            ButtonRotatePDF.BringToFront()
        End If
        Timer1.Enabled = True
    End Sub

    Dim WithEvents prnDoc As New Printing.PrintDocument
    Dim StringToPrint As String

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        If TextBoxReading.Visible = False Then
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
        Else
            StringToPrint = TextBoxReading.Text
            prnDoc.Print()
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub prnDoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
        Handles prnDoc.PrintPage
        Dim numChars As Integer
        Dim numLines As Integer
        Dim stringForPage As String
        Dim strFormat As New StringFormat()
        Dim PrintFont As Font

        PrintFont = New Font(TextBoxReading.Font.Name, 12, FontStyle.Regular)
        Dim _
            rectDraw As _
                New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height)

        Dim sizeMeasure As New SizeF(e.MarginBounds.Width, e.MarginBounds.Height - PrintFont.GetHeight(e.Graphics))

        strFormat.Trimming = StringTrimming.Word

        e.Graphics.MeasureString(StringToPrint, PrintFont, sizeMeasure, strFormat, numChars, numLines)

        stringForPage = StringToPrint.Mid(1, numChars)

        e.Graphics.DrawString(stringForPage, PrintFont, Brushes.Black, rectDraw, strFormat)

        If numChars < StringToPrint.Length Then

            StringToPrint = StringToPrint.Mid(numChars + 1)

            e.HasMorePages = True
        Else

            e.HasMorePages = False

        End If
    End Sub

    Private Sub ButtoneMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtoneMail.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String = "Attached: Document"
        Dim Fname As String
        If TextBoxReading.Visible = False Then
            If pdfViewer.Tag = "" Then
                MsgBox("Unable to process your request. No Document Loaded.")
            End If
            Subject = "Attached: Document"
            Fname = pdfViewer.Tag
            Try
                Msg.SendMail(Fname.ToString, Subject, Subject)
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
        Else

            Dim TargetFile As IO.StreamWriter
            Fname = System.IO.Path.GetTempFileName.ToString
            Fname = Fname.Replace("tmp", "txt")
            TargetFile = New IO.StreamWriter(Fname, False)
            TargetFile.Write(TextBoxReading.Text)
            TargetFile.Close()
            Try

                Msg.SendMail(Fname.ToString, Subject, Subject)
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
        Dim Subject As String = "Attached: Document"
        Dim Fname As String
        If TextBoxReading.Visible = False Then
            If pdfViewer.Tag = "" Then
                MsgBox("Unable to process your request. No Document Loaded.")
            End If
            Subject = "Attached: Document"
            Fname = pdfViewer.Tag
            Try
                gFax(Me, "", "Attached: Document", Fname, gOfficeFax)
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
        Else

            Dim TargetFile As IO.StreamWriter
            Fname = System.IO.Path.GetTempFileName.ToString
            Fname = Fname.Replace("tmp", "txt")
            TargetFile = New IO.StreamWriter(Fname, False)
            TargetFile.Write(TextBoxReading.Text)
            TargetFile.Close()
            Try
                gFax(Me, "", "Attached: Document", Fname, gOfficeFax)
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
        End If
    End Sub

    Private Sub TextBoxReading_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxReading.TextChanged

    End Sub

    Private Sub TextBoxReading_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxReading.VisibleChanged

        ToolStripFontSize.Visible = TextBoxReading.Visible
    End Sub

    Private Sub ButtonDn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDn.Click
        If TextBoxReading.Font.Size > 72 Then Exit Sub
        TextBoxReading.Font = New Font(TextBoxReading.Font.Name, TextBoxReading.Font.Size + 1, FontStyle.Regular)
    End Sub

    Private Sub ButtonUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUp.Click
        If TextBoxReading.Font.Size < 9 Then Exit Sub
        TextBoxReading.Font = New Font(TextBoxReading.Font.Name, TextBoxReading.Font.Size - 1, FontStyle.Regular)
    End Sub

    Private Sub frmDocumentPreview_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If RichTextBox1.Visible Then
            ButtonRotatePDF.Visible = False
        Else
            ButtonRotatePDF.Visible = True
            ButtonRotatePDF.BringToFront()
        End If

    End Sub

    Private Sub ButtonRotatePDF_Click(sender As Object, e As EventArgs) Handles ButtonRotatePDF.Click
        txtDummy.Focus()
        On Error GoTo er
        If pdfViewer.Visible = False Then Exit Sub
        If RichTextBox1.Visible Then Exit Sub
        pdfViewer.Renderer.RotateRight()
        pdfViewer.Refresh()
er:

    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        On Error GoTo er
        pdfViewer.Renderer.Rotation = PdfiumViewer.PdfRotation.Rotate0
        pdfViewer.Refresh()
er:
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        On Error GoTo er
        pdfViewer.Renderer.Rotation = PdfiumViewer.PdfRotation.Rotate90
        pdfViewer.Refresh()
er:
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        On Error GoTo er
        pdfViewer.Renderer.Rotation = PdfiumViewer.PdfRotation.Rotate180
        pdfViewer.Refresh()
er:
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        On Error GoTo er
        pdfViewer.Renderer.Rotation = PdfiumViewer.PdfRotation.Rotate270
        pdfViewer.Refresh()
er:
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        If pdfViewer.Visible And TextBoxReading.Visible = False Then
            ButtonRotatePDF.Visible = True
            pdfViewer.ShowToolbar = True
        Else
            ButtonRotatePDF.Visible = False
        End If
    End Sub

End Class