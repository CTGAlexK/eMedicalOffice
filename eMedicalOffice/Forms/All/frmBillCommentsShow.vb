Imports System.Reflection
Imports log4net

Public Class frmBillCommentsShow
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Sub frmBillCommentsShow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sRead)
    End Sub
    Public BillNumber As Integer
    Public PatientName As String
    Private Sub frmBillCommentsShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
    End Sub
    Private PrtSetupDB As New PrintDialog()
    Private PrinterSettings As New System.Drawing.Printing.PrinterSettings()
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        PrintDocument1.DocumentName = "Bill Comments"
        PrtSetupDB.Document = PrintDocument1
        PrtSetupDB.PrinterSettings = PrinterSettings

        If PrtSetupDB.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(lblInfo.Text, New Font(TextBox1.Font, FontStyle.Bold), Brushes.Black, 0, 0)
        e.Graphics.DrawString(TextBox1.Text, TextBox1.Font, Brushes.Black, 0, 16)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        If TextBox1.Text.Trim = "" Then
            MsgBox("Unable to send email. Nothing to eMail.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Subject = Label1.Text & ".   " & lblInfo.Text
        Try
            Msg.SendMail("", Subject, Subject)
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)

        End Try
    End Sub
End Class