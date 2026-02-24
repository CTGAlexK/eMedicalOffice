Public Class frmPatientPhotoPreview
    Public AccidentDate As String
    Public DOB As String
    Private Sub frmPatientPhotoPreview_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub frmPatientPhotoPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        Me.Opacity = 0
        Timer1.Interval = 20
        Timer1.Enabled = True
    End Sub
    Dim PrintPreviewDialog1 As PrintPreviewDialog = New PrintPreviewDialog
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim PrintDocument1 As Printing.PrintDocument = New Printing.PrintDocument

        AddHandler PrintDocument1.PrintPage, AddressOf Me.PrintDocument1_PrintPage
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.UseAntiAlias = True
        AddHandler PrintPreviewDialog1.Load, AddressOf Me.PrintPreviewDialog_Load
        PrintPreviewDialog1.ShowDialog(Me)

        'PrintDocument1.Print()

    End Sub
    Private Sub PrintPreviewDialog_Load()
        PrintPreviewDialog1.Left = Me.Left
        PrintPreviewDialog1.Top = Me.Top
        PrintPreviewDialog1.Width = Me.Width
        PrintPreviewDialog1.Height = Me.Height
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        e.Graphics.DrawString(Label1.Text & "     DOB:" & DOB, New Font("Arial", 16), Brushes.Black, 100, 100)
        e.Graphics.DrawImage(PictureBox1.Image, 100, 150, 640, 480)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.1
        If Me.Opacity >= 1 Then Timer1.Enabled = False
    End Sub
End Class