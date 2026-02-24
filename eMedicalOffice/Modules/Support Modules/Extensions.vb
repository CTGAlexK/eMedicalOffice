Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports log4net
Imports System.Speech.Synthesis

Module Extensions
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    <Extension()>
    Public Function ToSafeSQLString(str As String) As String
        If String.IsNullOrEmpty(str) Then Return ""
        Return Replace(str, "'", "''")
    End Function

    <Extension()>
    Public Function Left(ByVal val As String, ByVal length As Integer) As String
        If String.IsNullOrEmpty(val) Then
            Return ""
        End If
        Return Microsoft.VisualBasic.Left(val, length)
    End Function

    <Extension()>
    Public Function Mid(ByVal input As String, ByVal startIndex As Integer, ByVal length As Integer) As String
        If String.IsNullOrEmpty(input) Or startIndex < 1 Or length < 1 Then
            Return ""
        End If
        Return Microsoft.VisualBasic.Mid(input, startIndex, length)
    End Function

    <Extension()>
    Public Function Mid(ByVal input As String, ByVal startIndex As Integer) As String
        If String.IsNullOrEmpty(input) Or startIndex < 1 Then
            Return ""
        End If
        Return Microsoft.VisualBasic.Mid(input, startIndex)
    End Function

    <Extension()>
    Public Function Right(ByVal val As String, ByVal length As Integer) As String
        If String.IsNullOrEmpty(val) Then
            Return ""
        End If
        Return Microsoft.VisualBasic.Right(val, length)
    End Function

    <Extension()>
    Public Function Encrypt(ByVal stringToEncrypt As String, ByVal key As String) As String
        If String.IsNullOrEmpty(stringToEncrypt) Then
            Return ""
        End If

        If String.IsNullOrEmpty(key) Then
            Throw New ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.")
        End If

        Dim cspp As CspParameters = New CspParameters()
        cspp.KeyContainerName = key
        Dim rsa As RSACryptoServiceProvider = New RSACryptoServiceProvider(cspp)
        rsa.PersistKeyInCsp = True
        Dim bytes As Byte() = rsa.Encrypt(System.Text.UTF8Encoding.UTF8.GetBytes(stringToEncrypt), True)
        Return BitConverter.ToString(bytes)
    End Function

    <Extension()>
    Public Function Decrypt(ByVal stringToDecrypt As String, ByVal key As String) As String
        Dim result As String = Nothing
        If String.IsNullOrEmpty(stringToDecrypt) Then
            Return ""
        End If

        If String.IsNullOrEmpty(key) Then
            Throw New ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.")
        End If

        Try
            Dim cspp As CspParameters = New CspParameters()
            cspp.KeyContainerName = key
            Dim rsa As RSACryptoServiceProvider = New RSACryptoServiceProvider(cspp)
            rsa.PersistKeyInCsp = True
            Dim decryptArray As String() = stringToDecrypt.Split(New String() {"-"}, StringSplitOptions.None)
            Dim decryptByteArray As Byte() = Array.ConvertAll(Of String, Byte)(decryptArray, (Function(s) Convert.ToByte(Byte.Parse(s, System.Globalization.NumberStyles.HexNumber))))
            Dim bytes As Byte() = rsa.Decrypt(decryptByteArray, True)
            result = System.Text.UTF8Encoding.UTF8.GetString(bytes)
        Finally
        End Try

        Return result
    End Function

    <Extension()>
    Public Function IsNumeric(ByVal theValue As String) As Boolean
        Return Microsoft.VisualBasic.IsNumeric(theValue)
    End Function

    <Extension()>
    Public Function ToProperCase(ByVal text As String) As String
        Return text.ToUpper()
    End Function

    <Extension()>
    Public Function IsValidUrl(ByVal text As String) As Boolean
        Dim rx As Regex = New Regex("http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")
        Return rx.IsMatch(text)
    End Function

    <Extension()>
    Public Function IsGuid(ByVal s As String) As Boolean
        If s Is Nothing Then Throw New ArgumentNullException("s")
        Dim format As Regex = New Regex("^[A-Fa-f0-9]{32}$|" & "^({|\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\))?$|" & "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$")
        Dim match As Match = format.Match(s)
        Return match.Success
    End Function

    <Extension()>
    Public Function SanitizeFileName(name As String, Optional replaceChar As Char = "-") As String
        Return Path.GetInvalidFileNameChars().Aggregate(name, Function(current, c) current.Replace(c, replaceChar))
    End Function

    <Extension()>
    Public Function IsValidIPAddress(ByVal input As String) As Boolean
        Return Regex.IsMatch(input, "\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b")
    End Function

    <Extension()>
    Public Function IsEmail(ByVal str As String) As Boolean
        Dim match = Regex.Match(str, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase)
        Return match.Success
    End Function

    <Extension()>
    Public Function ToInt32(ByVal value As String) As Integer
        Dim number As Integer
        Int32.TryParse(value, number)
        Return number
    End Function

    <Extension()>
    Public Function ToInt(ByVal value As String) As Integer
        Dim number As Integer
        Integer.TryParse(value, number)
        Return number
    End Function

    <Extension()>
    Public Function IsStrongPassword(ByVal s As String) As Boolean
        Dim isStrong As Boolean = Regex.IsMatch(s, "[\d]")
        If isStrong Then isStrong = Regex.IsMatch(s, "[a-z]")
        If isStrong Then isStrong = Regex.IsMatch(s, "[A-Z]")
        If isStrong Then isStrong = Regex.IsMatch(s, "[\s~!@#\$%\^&\*\(\)\{\}\|\[\]\\:;'?,.`+=<>\/]")
        If isStrong Then isStrong = s.Length > 7
        Return isStrong
    End Function

    <Extension()>
    Public Function ToDelimitedString(ByVal ls As List(Of String), ByVal delimiter As String) As String
        Dim sb As New StringBuilder

        For Each buf As String In ls
            sb.Append(buf)
            sb.Append(delimiter)
        Next

        ' The final delimiter is trimmed off since there is no record after that item
        Return sb.ToString.Trim(delimiter)
    End Function

    <Extension()>
    Public Function ToFileSize(ByVal size As Long) As String
        If size < 1024 Then
            Return (size).ToString("F0") & " bytes"
        End If

        If size < Math.Pow(1024, 2) Then
            Return (size / 1024).ToString("F0") & "KB"
        End If

        If size < Math.Pow(1024, 3) Then
            Return (size / Math.Pow(1024, 2)).ToString("F0") & "MB"
        End If

        If size < Math.Pow(1024, 4) Then
            Return (size / Math.Pow(1024, 3)).ToString("F0") & "GB"
        End If

        If size < Math.Pow(1024, 5) Then
            Return (size / Math.Pow(1024, 4)).ToString("F0") & "TB"
        End If

        If size < Math.Pow(1024, 6) Then
            Return (size / Math.Pow(1024, 5)).ToString("F0") & "PB"
        End If

        Return (size / Math.Pow(1024, 6)).ToString("F0") & "EB"
    End Function

    <Extension()>
    Public Function EqualsByValue(ByVal inString As String, ByVal compared As String) As Boolean
        If String.IsNullOrEmpty(inString) AndAlso String.IsNullOrEmpty(compared) Then Return True
        If inString Is Nothing Then Return False
        Return inString.Equals(compared)
    End Function

    <Extension()>
    Public Function RandomString(ByVal length As Integer) As String
        Dim random As Random = New Random(CInt(DateTime.Now.Ticks))
        Dim sb As StringBuilder = New StringBuilder()
        Dim validChars As String = "abcdefghijklmnopqrstuvwxyz0123456789"
        Dim c As Char
        For i As Integer = 0 To length - 1
            c = validChars(random.[Next](0, validChars.Length))
            sb.Append(c)
        Next

        Return sb.ToString()
    End Function

    <Extension()>
    Public Function ToDouble(ByVal theValue As String) As Double
        Dim retNum As Double
        Dim result = Double.TryParse(theValue, retNum)
        Return If(result, retNum, 0)
    End Function

    <Extension()>
    Public Function ReverseWords(ByVal sentence As String) As String
        Dim words = sentence.Split(" "c)
        Array.Reverse(words)
        Return String.Join(" ", words)
    End Function

    <Extension()>
    Public Function ToBool(ByVal value As String) As Boolean
        Dim val = value.ToLower().Trim()
        If val = "false" Then Return False
        If val = "f" Then Return False
        If val = "true" Then Return True
        If val = "t" Then Return True
        If val = "yes" Then Return True
        If val = "no" Then Return False
        If val = "y" Then Return True
        If val = "n" Then Return False
        If val = "1" Then Return True
        If val = "0" Then Return False

        Return False
    End Function

    <Extension()>
    Public Function LoadDocument(PDFviewer As PdfiumViewer.PdfViewer, load As String) As Boolean

        Try
            If PDFviewer.IsDisposed Then
                Return False
            End If

            If Not File.Exists(load) Then
                Return False
            End If
            If load = "about:blank" Then
                CloseDocument(PDFviewer, False)
                Return True
            End If
            If Not PDFviewer.IsDisposed Then
                If load = "" Then Return False
                Using _ms As MemoryStream = New MemoryStream(File.ReadAllBytes(load), False)
                    Dim mscopy As MemoryStream = New MemoryStream()
                    _ms.CopyTo(mscopy)
                    _ms.Close()
                    PDFviewer.Document = PdfiumViewer.PdfDocument.Load(mscopy)
                End Using
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Oops")
            log.Error("PdfiumViewer.LoadDocument1" & vbCrLf & ex.Message, ex)
            Return False
        End Try

    End Function

    <Extension()>
    Public Function LoadDocument(PDFviewer As PdfiumViewer.PdfViewer, ms As MemoryStream) As Boolean
        Try
            If PDFviewer.IsDisposed Then
                Return False
            End If
            'PDFviewer.Document = PdfiumViewer.PdfDocument.load(path)
            If Not PDFviewer.IsDisposed Then
                PDFviewer.Document = PdfiumViewer.PdfDocument.Load(ms)
            End If
            'If Not PDFviewer.IsDisposed Then
            '    PDFviewer.Renderer.Load(PDFviewer.Document)
            'End If

            Return True
        Catch ex As Exception
            MsgBox("PdfiumViewer.LoadDocument2" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Oops")
            log.Error(ex.Message, ex)
            Return False
        End Try

    End Function

    <Extension()>
    Public Function CloseDocument(PDFviewer As PdfiumViewer.PdfViewer, Optional LoadEmpty As Boolean = True) As Boolean
        Try
            Dim pdfpath As String = Path.Combine(gAppPath, "Empty.pdf")
            If Not PDFviewer.Document Is Nothing And PDFviewer.IsDisposed = False Then
                PDFviewer.Document.Dispose()
            Else
                Return False
            End If
            'If Not PDFviewer.IsDisposed Then
            '    If Not PDFviewer.Renderer Is Nothing Then
            '        If Not PDFviewer.Renderer.Document Is Nothing Then
            '            PDFviewer.Renderer.Document.Dispose()
            '        End If
            '    End If
            'End If

            If LoadEmpty Then
                If Not PDFviewer.IsDisposed Then
                    Dim _ms As MemoryStream = New MemoryStream(File.ReadAllBytes(pdfpath))
                    Dim ms As MemoryStream = New MemoryStream
                    _ms.CopyTo(ms)
                    PDFviewer.Document = PdfiumViewer.PdfDocument.Load(ms)
                End If
                'PDFviewer.Document = PdfiumViewer.PdfDocument.Load(pdfpath)
            End If
            Return True
        Catch ex As Exception
            MsgBox("PdfiumViewer.CloseDocument" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Oops")
            log.Error("PdfiumViewer.CloseDocument" & vbCrLf & ex.Message, ex)
            Return False
        End Try

    End Function

    <Extension()>
    Public Function PrintDocument(PDFviewer As PdfiumViewer.PdfViewer, parentForm As Form, Optional PreviewHidden As Boolean = False) As Boolean
        If PDFviewer.Document Is Nothing Then Return False
        Try
            Using form As New PrintPreviewDialog
                form.StartPosition = FormStartPosition.CenterParent
                gWindow_Settings(form, ReadWrite.sRead)
                form.Document = PDFviewer.Document.CreatePrintDocument(PDFviewer.DefaultPrintMode)
                form.Document.DefaultPageSettings.PrinterSettings.PrinterName = gPrinterOtherDocuments
                If PreviewHidden Then
                    form?.Document?.Print()
                Else
                    form.ShowDialog(parentForm)
                End If

                gWindow_Settings(form, ReadWrite.sWrite)
            End Using
            Return True
        Catch ex As Exception
            MsgBox("PdfiumViewer.PrintDocument" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Oops")
            log.Error(ex.Message, ex)
            Return False
        End Try

    End Function

    <Extension()>
    Public Function NavigateURL(ByVal browser As WebBrowser, url As String) As Boolean
        Dim c As Integer
        Dim b As Integer
        browser.ScriptErrorsSuppressed = True
        browser.Stop()
        If Not browser.Url Is Nothing Then
            If browser.Url.ToString.ToUpper.Trim = url.ToString.ToUpper.Trim Then Return True
        End If
        Application.DoEvents()
        Do Until browser.IsBusy = False
            c = c + 1
            browser.Stop()
            Threading.Thread.Sleep(1000)
            Application.DoEvents()
            If c > 50 Then
                MsgBox("Unable to navigate URL. IE is busy..." & vbCrLf & "Please close all other applications / Web pages using Internet Explorer. Msg[1]", MsgBoxStyle.Critical, "Oops")
                log.Error("Msg[1]. " & "Unable to navigate URL. IE is busy... URL: " & url)
                Return False
            End If
        Loop
        c = 0
        Do
            c = c + 1
            b = 0
            Try
                Do Until browser.IsBusy = False
                    browser.Stop()
                    b = b + 1
                    Threading.Thread.Sleep(1000)
                    Application.DoEvents()
                    If b > 50 Then
                        MsgBox("Unable to navigate URL. IE is busy..." & vbCrLf & "Please close all other applications / Web pages using Internet Explorer. Msg[2]", MsgBoxStyle.Critical, "Oops")
                        log.Error("Msg[2]. Unable to navigate URL. IE is busy... URL: " & url)
                        Return False
                    End If
                Loop
                browser.Navigate(url)
                Return True
            Catch ex As Exception
                If c >= 20 Then
                    MsgBox(ex.Message & vbCrLf & "Please close all other applications / Web pages using Internet Explorer. Msg[3]", MsgBoxStyle.Critical, "Oops")
                    log.Error("Msg[3]. " & ex.Message & vbCrLf & "URL: " & url, ex)
                    Return False
                End If
                browser.Stop()
                Threading.Thread.Sleep(500)
            End Try
        Loop
    End Function

End Module