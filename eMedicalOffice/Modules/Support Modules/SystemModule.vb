Imports System.Drawing.Printing
Imports System.Reflection
Imports log4net

Module SystemModule
    private readonly log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public Function gPrintDialog(MSG As String, Optional ByVal Title As String = "Print Dialog") As DialogResult
        Try
            frmPtinterDialog.lblTitle.Text = Title
            frmPtinterDialog.lblMessage.Text = MSG
            gPrintDialog = frmPtinterDialog.ShowDialog
            frmPtinterDialog.Dispose()
        Catch ex As Exception
            log.Error(ex.Message,ex)
        End Try
    End Function
    Public Function CheckPrinter(PName As String) As String
        Dim I As Integer
        Dim SelectedPrinter = ""
        Try
            Dim prtdoc As New PrintDocument()
            Dim strDefaultPrinter As String = prtdoc.PrinterSettings.PrinterName
            If PName = "" Then GoTo ExitFunction
            For I = 0 To PrinterSettings.InstalledPrinters.Count - 1
                If PName.ToUpper = PrinterSettings.InstalledPrinters(I).ToString.ToUpper Then
                    SelectedPrinter = PName
                End If
            Next
            ExitFunction:
            If strDefaultPrinter <> "" Then If SelectedPrinter = "" Then SelectedPrinter = strDefaultPrinter
        Catch ex As Exception
            msgbox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Return SelectedPrinter
    End Function
    Public Function StartScreenSaver() As Boolean

        Try
            Dim lDesktopWindow As Long
            Dim lRet As Long
            lDesktopWindow = GetDesktopWindow()
            lRet = SendMessage(lDesktopWindow, WM_SYSCOMMAND, SC_SCREENSAVE, New IntPtr(0))
            StartScreenSaver = (lRet = 0)
        Catch ex As Exception
        End Try
    End Function
End Module
