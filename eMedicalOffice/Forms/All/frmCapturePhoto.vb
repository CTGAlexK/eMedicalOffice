Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Threading
Imports log4net

Public Class frmCapturePhoto
    ' Create constant using attend in function of DLL file.

    Public Declare Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    private readonly log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Function SendBitmapMessage(hWnd As IntPtr, wMsg As UInteger, wParam As Integer, ByRef lParam As BITMAPINFO) As Integer
    End Function


    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Private Const WM_CAP_GRAB_FRAME As Long = 1084
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1
    Private Const WM_CAP_START = WM_CAP
    Private Const WM_CAP_STOP = WM_CAP_START + 68
    Private Const WM_CAP_ABORT = WM_CAP_START + 69
    Public Const WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41
    Public Const WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42
    Public Const WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 43
    Public Const WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44
    Public Const WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45
    Public Const WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46
    Private Declare Function BitBlt Lib "GDI32.DLL" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Int32) As Boolean
    Private Const WM_CAP_SET_CALLBACK_ERROR = WM_CAP_START + 2
    Private Const WM_CAP_SET_CALLBACK_STATUS = WM_CAP_START + 3
    Private Const WM_CAP_SET_CALLBACK_YIELD = WM_CAP_START + 4
    Private Const WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5
    Private Const WM_CAP_SET_CALLBACK_VIDEOSTREAM = WM_CAP_START + 6
    Private Const WM_CAP_SET_CALLBACK_WAVESTREAM = WM_CAP_START + 7
    Structure POINTAPI
        Dim x As Integer
        Dim y As Integer
    End Structure
    Public Structure CAPSTATUS
        Dim uiImageWidth As Integer          '// Width of the image
        Dim uiImageHeight As Integer          '// Height of the image
        Dim fLiveWindow As Integer           '// Now Previewing video?
        Dim fOverlayWindow As Integer         '// Now Overlaying video?
        Dim fScale As Integer             '// Scale image to client?
        Dim ptScroll As POINTAPI          '// Scroll position
        Dim fUsingDefaultPalette As Integer      '// Using default driver palette?
        Dim fAudioHardware As Integer         '// Audio hardware present?
        Dim fCapFileExists As Integer         '// Does capture file exist?
        Dim dwCurrentVideoFrame As Integer       '// # of video frames cap'td
        Dim dwCurrentVideoFramesDropped As Integer   '// # of video frames dropped
        Dim dwCurrentWaveSamples As Integer      '// # of wave samples cap'td
        Dim dwCurrentTimeElapsedMS As Integer     '// Elapsed capture duration
        Dim hPalCurrent As Integer           '// Current palette in use
        Dim fCapturingNow As Integer          '// Capture in progress?
        Dim dwReturn As Integer            '// Error value after any operation
        Dim wNumVideoAllocated As Integer       '// Actual number of video buffers
        Dim wNumAudioAllocated As Integer       '// Actual number of audio buffers
    End Structure

    Dim CaptureWindowHwnd As Integer  ' Handle value to preview window
    public ParentForm as MDIForm1Win8
    Public ToolStripButtonPreview as ToolStripButton
    ' Declare function from AVI capture DLL.

    'Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
    '    (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
    '     ByVal lParam As Object) As Integer

  
    'Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Boolean, ByRef lParam As Integer) As Boolean

    Private Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
         ByRef lParam As Integer) As Boolean

    Private Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean
    Private Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    Private Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean
    <StructLayout(LayoutKind.Sequential)> _
    public  Structure BITMAPINFOHEADER
        Public biSize As UInteger
        Public biWidth As Integer
        Public biHeight As Integer
        Public biPlanes As UShort
        Public biBitCount As UShort
        Public biCompression As UInteger
        Public biSizeImage As UInteger
        Public biXPelsPerMeter As Integer
        Public biYPelsPerMeter As Integer
        Public biClrUsed As UInteger
        Public biClrImportant As UInteger
    End Structure
    <StructLayout(LayoutKind.Sequential)> _
    public  Structure BITMAPINFO
        Public bmiHeader As BITMAPINFOHEADER
        Public bmiColors As Integer
    End Structure
    ' Connect to the device.

    Private Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0
        Dim LastDevice As Integer = -1  ' 
        ' Load name of all avialable devices into the lstDevices .

        Do
            '   Get Driver name and version
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            ' If there was a device add device name to the list 
            If bReturn Then lstDevices.Items.Add(strName.Trim)
            x += 1
        Loop Until bReturn = False
        If lstDevices.Items.Count = 0 Then
            LabelMsg.Text = "No Capture Device Found."
            LabelMsg.ForeColor = Color.Red
            LabelMsg.Visible = True
        Else
            LastDevice = GetSetting(My.Application.Info.ProductName, "Settings\CameraSettings", "LastSelected", -1)
            If LastDevice + 1 <= lstDevices.Items.Count Then
                lstDevices.SelectedIndex = LastDevice
            Else
                If lstDevices.Items.Count = 1 Then
                    lstDevices.SelectedIndex = 0
                    lstDevices_SelectedIndexChanged(Nothing, Nothing)
                Else
                    LabelMsg.Text = "Select The Capture Device."
                    LabelMsg.Visible = True
                End If

            End If
        End If
    End Sub

    ' To display the output from a video capture device, you need to create a capture window.

    public Sub OpenPreviewWindow()
        Dim iHeight As Integer = picCapture.Height
        Dim iWidth As Integer = picCapture.Width
        Cursor = Cursors.WaitCursor
        LabelMsg.ForeColor = Color.Black
        LabelMsg.Text = "Connecting Capture Device. Please Wait..."
        LabelMsg.Visible = True
        If InitialImage Is Nothing Then picSave.Image = Nothing
        lblImageSize.Text = ""
        PictureBoxCapture.Visible = False
        Application.DoEvents()
        ' Open Preview window in picturebox .
        ' Create a child window with capCreateCaptureWindowA so you can display it in a picturebox.
        CaptureWindowHwnd = capCreateCaptureWindowA(lstDevices.Text, WS_VISIBLE Or WS_CHILD, 0, 0, iHeight, iWidth, picCapture.Handle.ToInt32, 0)

        ' Connect to device
        If SendMessage(CaptureWindowHwnd, WM_CAP_DRIVER_CONNECT, New IntPtr(lstDevices.SelectedIndex), IntPtr.Zero) Then

            ' Set Video Format

            'Dim bInfo as BITMAPINFO = New BITMAPINFO()
            
            'bInfo = New BITMAPINFO()
            'bInfo.bmiHeader = New BITMAPINFOHEADER()
            'SendBitmapMessage(CaptureWindowHwnd, WM_CAP_GET_VIDEOFORMAT, Marshal.SizeOf(bInfo), bInfo)
            'bInfo.bmiHeader.biSize = CUInt(Marshal.SizeOf(bInfo.bmiHeader))
            'bInfo.bmiHeader.biWidth = iHeight
            'bInfo.bmiHeader.biHeight = iWidth
            'bInfo.bmiHeader.biBitCount=24
            'bInfo.bmiHeader.biCompression =System.Drawing.Imaging.PixelFormat.Format24bppRgb


            'SendBitmapMessage(CaptureWindowHwnd, WM_CAP_SET_VIDEOFORMAT, Marshal.SizeOf(bInfo), bInfo)


            ' Set the preview scale
            SendMessage(CaptureWindowHwnd, WM_CAP_SET_SCALE, New IntPtr(1), IntPtr.Zero)

            ' Set the preview rate in milliseconds
            SendMessage(CaptureWindowHwnd, WM_CAP_SET_PREVIEWRATE, New IntPtr(24), IntPtr.Zero)

            ' Start previewing the image from the camera 
            SendMessage(CaptureWindowHwnd, WM_CAP_SET_PREVIEW, New IntPtr(1), IntPtr.Zero)

            ' Resize window to fit in picturebox 
            SetWindowPos(CaptureWindowHwnd, HWND_BOTTOM, 0, 0, iWidth, iHeight, SWP_NOMOVE Or SWP_NOZORDER)
            btnSave.Enabled = True
            ButtonSettings.Enabled = True
            LabelMsg.Text = ""
            LabelMsg.Visible = False
        Else
            ' Error connecting to device close window 
            Cursor = Cursors.Default
            DestroyWindow(CaptureWindowHwnd)
            picCapture.Image = Nothing
            LabelMsg.Text = "Error connecting Capture Device."
            LabelMsg.ForeColor = Color.Red
            btnSave.Enabled = False
            ButtonSettings.Enabled = False
            LabelMsg.Visible = True
            MsgBox("Error Connecting Capture Device.", MsgBoxStyle.Exclamation)
        End If
        Cursor = Cursors.Default
    End Sub
    Private SkeepAdjustments As Boolean
    ' Use SendMessage to copy the data to the clipboard Then transfer the image to the picture box. 
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim data As IDataObject
        Dim bmap As Image
        dim RetryCount as Integer =0
        try
            Application.DoEvents()
            Clipboard.Clear()
            ' Copy image to clipboard 
            RetryCount:
            SendMessage(CaptureWindowHwnd, WM_CAP_EDIT_COPY, IntPtr.Zero, IntPtr.Zero)

            ' Get image from clipboard and convert it to a bitmap 
            data = Clipboard.GetDataObject()
            If data.GetDataPresent(GetType(Bitmap)) Then
                bmap = CType(data.GetData(GetType(Bitmap)), Image)
                Dim Graphic As System.Drawing.Graphics = Graphics.FromImage(bmap)
                If chkTimeStamp.Checked Then
                    Dim F As New Font(Font.FontFamily, 30, FontStyle.Bold, GraphicsUnit.Pixel)
                    Dim B As New SolidBrush(Color.Red)
                    Dim DT As DateTime = Now
                    Dim Sz As New SizeF
                    Dim Len As Integer = Graphic.MeasureString(DT.ToString, F, Sz).Width
                    Graphic.DrawString(DT, F, B, bmap.Width - Len - 40, bmap.Height - 40)
                End If

                picSave.Image = bmap
                picSave.SizeMode = PictureBoxSizeMode.Zoom
                img = bmap.Clone
                SkeepAdjustments = True
                HScrollBarZoom.Value = 100
                HScrollBarBrightness.Value = 0
                SkeepAdjustments = False
                HScrollBarZoom.Enabled = True
                HScrollBarBrightness.Enabled = True

                lblImageSize.Text = "Image Size: " & gNumeric2Bytes(BmpToBytes_MemStream(img.Clone))
                PictureBoxSave.SizeMode = PictureBoxSizeMode.Zoom
                PictureBoxSave.Image = bmap.Clone
                PictureBoxCapture.Visible = True

                'ClosePreviewWindow()
                'If sfdImage.ShowDialog = DialogResult.OK Then
                ' bmap.Save(sfdImage.FileName, Imaging.ImageFormat.Bmp)
                'End If
            else
                RetryCount=RetryCount+1
                if RetryCount >10 Then
                    Return
                End If
                Thread.Sleep(200)
                      goto RetryCount  
            End If
            
        Catch ex As Exception
            log.Error(ex)
            MsgBox(ex.Message,MsgBoxStyle.Exclamation)
        End Try


    End Sub
    Private Function BmpToBytes_MemStream(ByVal bmp As Image) As Double
        Dim ms As MemoryStream = New MemoryStream()
        ' Save to memory using the Jpeg format 


        bmp.Save(ms, ImageFormat.Jpeg)
        Dim bmpBytes() As Byte = ms.GetBuffer()
        bmp.Dispose()
        ms.Close()
        Return bmpBytes.Length
    End Function

    ' Finally, to close the preview window, disconnect from the device and destroy the preview window. 
    public Sub ClosePreviewWindow()
        ' Disconnect from device
        If lstDevices.SelectedIndex > -1 Then
            SendMessage(CaptureWindowHwnd, WM_CAP_DRIVER_DISCONNECT, New IntPtr(lstDevices.SelectedIndex), IntPtr.Zero)
            ' close window 
            DestroyWindow(CaptureWindowHwnd)
        End If
    End Sub

    Private Sub frmCapturePhoto_FormClosing(ByVal sender As Object, ByVal e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(My.Application.Info.ProductName, "Settings\CameraSettings", "LastSelected", lstDevices.SelectedIndex)
        SaveSetting(My.Application.Info.ProductName, "Settings\CameraSettings", "PhotoTimeStamp", chkTimeStamp.Checked)
        if e.CloseReason<>CloseReason.ApplicationExitCall and e.CloseReason<>CloseReason.MdiFormClosing and e.CloseReason<>CloseReason.FormOwnerClosing and e.CloseReason<>CloseReason.TaskManagerClosing and e.CloseReason<>CloseReason.WindowsShutDown Then
            e.Cancel=True
            FirstLoad = false
            hide       
            if not ParentForm is nothing and ParentForm.IsDisposed=False
                ParentForm.Enabled=true
            End If
            return  
        End If
        ClosePreviewWindow()
    End Sub

    Public Function StopStream() As Boolean


        SendMessage(CaptureWindowHwnd, WM_CAP_SET_CALLBACK_VIDEOSTREAM, 0, vbNull)
        SendMessage(CaptureWindowHwnd, WM_CAP_SET_CALLBACK_YIELD, 0, vbNull)
        SendMessage(CaptureWindowHwnd, WM_CAP_SET_PREVIEW, 0, 0)


        SendMessage(CaptureWindowHwnd, WM_CAP_ABORT, 0, 0)


        Return True
    End Function

    Public Sub ZoomImage(ByRef ZoomValue As Double)
        If SkeepAdjustments Then Exit Sub
        If PictureBoxSave.Image Is Nothing Then
            Exit Sub
        End If
        Dim original As Image
        'Get our original image
        original = PictureBoxSave.Image.Clone
        'Create a new image based on the zoom parameters we require
        Dim zoomImage As Bitmap
        Try
            zoomImage = New Bitmap(original, (Convert.ToInt32(PictureBoxSave.Width * ZoomValue)), (Convert.ToInt32(PictureBoxSave.Height * ZoomValue)))
        Catch ex As Exception
            Stop
        End Try





        'Create a new graphics object based on the new image
        Dim converted As Graphics = Graphics.FromImage(zoomImage)
        'Clean up the image
        converted.InterpolationMode = InterpolationMode.HighQualityBicubic
        'Clear out the original image
        picSave.Image = Nothing

        'Display the new "zoomed" image
        picSave.Image = zoomImage
        picSave.SizeMode = PictureBoxSizeMode.CenterImage
        'picSave.Refresh()
        img = picSave.Image.Clone
        lblImageSize.Text = "Image Size: " & gNumeric2Bytes(BmpToBytes_MemStream(img.Clone))




    End Sub
    Public ParentPhotoContainer As PictureBox
    Public InitialImage As Image
    Public FirstLoad as Boolean
    Private Sub frmCapturePhoto_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        If FirstLoad Then
            PictureBoxCapture.Parent = picSave
            PictureBoxCapture.Top = 1
            PictureBoxCapture.Left = 1
            PictureBoxCapture.Width = picSave.Width - 2
            PictureBoxCapture.Height = picSave.Height - 2
            PictureBoxCapture.SizeMode = PictureBoxSizeMode.Zoom
            PictureBoxSave.Size = New Point(320, 242)
            picSave.SizeMode = PictureBoxSizeMode.CenterImage
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
            chkTimeStamp.Checked = GetSetting(My.Application.Info.ProductName, "Settings\CameraSettings", "PhotoTimeStamp", True)
        End If
        'btnSave.Text = "Capture Photo" & vbCrLf & "F2"
    End Sub

    Private Sub lstDevices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles lstDevices.SelectedIndexChanged
        If lstDevices.SelectedIndex > -1 Then
            ClosePreviewWindow()
            OpenPreviewWindow()
            picCapture.Image = Nothing
        Else

            ClosePreviewWindow()
        End If
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OpenPreviewWindow()
    End Sub
    Dim img As Image
    Sub setBrightness(ByVal Brightness As Single)
        ' Brightness should be -1 (black) to 0 (neutral) to 1 (white) 
        If SkeepAdjustments = True Then Exit Sub
        Dim g As Graphics

        Dim r As Rectangle

        Dim colorMatrixVal As Single()() = { _
           New Single() {1, 0, 0, 0, 0}, _
           New Single() {0, 1, 0, 0, 0}, _
           New Single() {0, 0, 1, 0, 0}, _
           New Single() {0, 0, 0, 1, 0}, _
           New Single() {Brightness, Brightness, Brightness, 0, 1}}

        Dim colorMatrix As New ColorMatrix(colorMatrixVal)
        Dim ia As New ImageAttributes
        r = New Rectangle(0, 0, img.Width, img.Height)

        ia.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)
        g = Graphics.FromImage(picSave.Image)
        g.DrawImage(img, r, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia)
        picSave.Refresh()
        lblImageSize.Text = "Image Size: " & gNumeric2Bytes(BmpToBytes_MemStream(picSave.Image.Clone))
    End Sub


    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBarZoom.Scroll
        If picSave.Image Is Nothing Then
            If HScrollBarZoom.Value <> 100 Then HScrollBarZoom.Value = 100
            Exit Sub
        End If
        ZoomImage((HScrollBarZoom.Value / 100))
        setBrightness(HScrollBarBrightness.Value / 100)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        LoadDeviceList()
        InitialImage = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  



    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Img As Image
        If picSave.Image Is Nothing Then
            MsgBox("Unable to update the patient's profile." & vbCrLf & "No Photo Captured.")
            Exit Sub
        End If
        Img = picSave.Image.Clone
        If HScrollBarZoom.Value > 100 Then
            Dim bmp As New Bitmap(picSave.Width, picSave.Height)
            Dim g = Graphics.FromImage(bmp)
            g.DrawImage(picSave.Image, 0, 0, New Rectangle((picSave.Image.Width - picSave.Width) / 2, (picSave.Image.Height - picSave.Height) / 2, picSave.Width, picSave.Height), GraphicsUnit.Pixel)
            ParentPhotoContainer.Image = bmp
        Else
            ParentPhotoContainer.Image = Img
        End If
        ParentPhotoContainer.Tag = "1"
        ToolStripButtonPreview.Enabled=True
        Me.close()
    End Sub

    Private Sub frmCapturePhoto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F2 Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub HScrollBarBrightness_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBarBrightness.Scroll
        If picSave.Image Is Nothing Then
            If HScrollBarBrightness.Value <> 100 Then HScrollBarBrightness.Value = 0
            Exit Sub
        End If
        setBrightness(HScrollBarBrightness.Value / 100)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSettings.Click
        ContextMenuStrip1.Show(ButtonSettings, 15, 15)
    End Sub

    Private Sub DeviceSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceSettingsToolStripMenuItem.Click
        picSave.Image = Nothing
        lblImageSize.Text = ""
        SendMessage(CaptureWindowHwnd, WM_CAP_DLG_VIDEOSOURCE, 0, 0)
    End Sub

    Private Sub CompresionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompresionToolStripMenuItem.Click
        picSave.Image = Nothing
        lblImageSize.Text = ""
        SendMessage(CaptureWindowHwnd, WM_CAP_DLG_VIDEOFORMAT, 0, 0)

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub frmCapturePhoto_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
       
    End Sub
End Class