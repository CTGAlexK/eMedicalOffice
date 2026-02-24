Module ModulePrintListview
    Private WithEvents PD As Printing.PrintDocument
    Private LV As ListView
    Private PrLandscape As Boolean
    Private Title As String
    Public Enum PrinterOrientation
        Portrait = 0
        Landscape = 1
    End Enum
    Public Sub gPrintListview(ByVal pLV As ListView, Optional ByVal pPrinterOrientation As PrinterOrientation = PrinterOrientation.Portrait, Optional ByVal Preview As Boolean = False, Optional ByVal pTitle As String = "")
        If pPrinterOrientation = PrinterOrientation.Landscape Then
            PrLandscape = True
        Else
            PrLandscape = False
        End If
        PD = New Printing.PrintDocument
        LV = pLV
        Title = pTitle
        If Preview Then
            Dim PrintPreview As New PrintPreviewDialog
            Dim frm As Form = DirectCast(PrintPreview, Form)
            PrintPreview.Width = pLV.Parent.Width
            PrintPreview.Height = pLV.Parent.Height
            frm.StartPosition = FormStartPosition.CenterScreen
            PrintPreview.PrintPreviewControl.AutoZoom = True
            'PrintPreview.PrintPreviewControl.Zoom = 1
            PrintPreview.PrintPreviewControl.UseAntiAlias = True
            PrintPreview.Document = PD
            PrintPreview.ShowDialog()
        Else
            PD.Print()
        End If

    End Sub

    Private Sub PD_QueryPageSettings(ByVal sender As Object, ByVal e As Printing.QueryPageSettingsEventArgs) Handles PD.QueryPageSettings
        e.PageSettings.Landscape = PrLandscape
    End Sub
    Public Sub PrintListView(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles PD.PrintPage
        Dim i As Integer
        Static LastIndex As Integer = 0
        Static CurrentPage As Integer = 0
        'Getting the current dpi so the textleftpad 
        'will be the same on a different dpi than 
        'the 96 i'm using.  Won't make much of a difference though
        Dim Gr As Graphics = e.Graphics
        Dim DpiX As Integer = Gr.DpiX
        'Gr.Dispose()
        Dim X, Y As Integer
        Dim ImageWidth As Integer
        Dim TextRect As Rectangle = Rectangle.Empty
        Dim TextLeftPad As Single = 0 'CSng(4 * (DpiX / 96)) 'pixel pad on the left
        Dim ColumnHeaderHeight As Single = CSng(LV.Font.Height + (1 * (DpiX / 96))) 'pixel pad on the top an bottom
        Dim StringFormat As New StringFormat
        Dim PageNumberWidth As Single = Gr.MeasureString(CStr(CurrentPage), LV.Font).Width
        'Specify the text should be drawn in the center of the line and
        'that the text should not be wrapped and the text should show
        'ellipsis would cut off.
        StringFormat.FormatFlags = StringFormatFlags.NoWrap
        StringFormat.Trimming = StringTrimming.EllipsisCharacter
        StringFormat.LineAlignment = StringAlignment.Center
        CurrentPage += 1
        'Start the x and  y at the top left margin
        X = CInt(e.MarginBounds.X)
        Y = CInt(e.MarginBounds.Y)
        If Title <> "" Then
            Gr.DrawString(CStr(Title), LV.Font, Brushes.Black, X, Y)
            Y = Y + Gr.MeasureString(CStr(Title), LV.Font).Height + 10
        End If
        'Draw the column headers
        For ColumnIndex As Integer = 0 To LV.Columns.Count - 1
            TextRect.X = X
            TextRect.Y = Y
            TextRect.Width = LV.Columns(ColumnIndex).Width
            TextRect.Height = ColumnHeaderHeight
            Gr.FillRectangle(Brushes.LightGray, TextRect)
            Gr.DrawRectangle(Pens.DarkGray, TextRect)
            'TextLeftPad adds a little padding from the gridline.
            'Add it to the left and subtract it from the right.
            TextRect.X += TextLeftPad
            TextRect.Width -= TextLeftPad
            Gr.DrawString(LV.Columns(ColumnIndex).Text, LV.Font, Brushes.Black, TextRect, StringFormat)
            'Move the x position over the width of the column width.
            'Since I subtracted some padding add the padding back
            'when offsetting.
            X += TextRect.Width + TextLeftPad
        Next
        'Just drew the headers.  Move the Y down the height
        'of the column headers.
        Y += ColumnHeaderHeight
        'Now draw the items.  If this is the first page then the 
        'last index will be zero.  If its not then the last index
        'will be the last index we tried to draw but had no room.
        For i = LastIndex To LV.Items.Count - 1
            With LV.Items(i)
                'Start the x at the pages left margin.
                X = CInt(e.MarginBounds.X)
                'Check for Last Line
                If Y + .Bounds.Height > e.MarginBounds.Bottom Then
                    'This item won't fit.
                    'subtract 1 from i so the next time this sub
                    'is entered we can start with this item.
                    LastIndex = i - 1
                    e.HasMorePages = True
                    StringFormat.Dispose()
                    'Draw the current page number before leaving.
                    Gr.DrawString(CStr(CurrentPage), LV.Font, Brushes.Black, (e.PageBounds.Width - PageNumberWidth) / 2, e.PageBounds.Bottom - LV.Font.Height * 2)
                    Exit Sub
                End If
                'Print Images.
                'The image width is used so we can draw the gridline
                'around the image about to be drawn.  You'll see it 
                'below.
                ImageWidth = 0
                If LV.SmallImageList IsNot Nothing Then
                    'If the image key is set then draw the image
                    'with the key .  If not draw the image with the
                    'index.  A tiny bit of validation would be good.
                    If Not String.IsNullOrEmpty(.ImageKey) Then
                        Gr.DrawImage(LV.SmallImageList.Images(.ImageKey), X, Y)
                    ElseIf .ImageIndex >= 0 Then
                        Gr.DrawImage(LV.SmallImageList.Images(.ImageIndex), X, Y)
                    End If
                    ImageWidth = LV.SmallImageList.ImageSize.Width
                End If
                'Now draw the subitems.  using the columns count so the 
                'grid lines can be drawn.  If used the subitems count then
                'the table would not be full if some subitems where less
                'than others.
                For ColumnIndex As Integer = 0 To LV.Columns.Count - 1
                    TextRect.X = X
                    TextRect.Y = Y
                    TextRect.Width = LV.Columns(ColumnIndex).Width
                    TextRect.Height = .Bounds.Height
                    If LV.GridLines Then
                        Gr.DrawRectangle(Pens.DarkGray, TextRect)
                    End If
                    'If an image is drawn then shift over the x to 
                    'accomadate its width. If this was shifted before
                    'now then the gridline with draw rect above would be
                    ' on the wrong side of the image.
                    If ColumnIndex = 0 Then TextRect.X += ImageWidth
                    'Add a little padding from the gridline.
                    TextRect.X += TextLeftPad
                    TextRect.Width -= TextLeftPad
                    If ColumnIndex < .SubItems.Count Then
                        'This item has at least the same number of
                        'subitems as the current column index.
                        Gr.DrawString(.SubItems(ColumnIndex).Text, LV.Font, Brushes.Black, TextRect, StringFormat)
                    End If
                    'Shift the x of the width of this subitem.
                    'Add some padding to the left side of the text
                    'so need to add it back.
                    X += TextRect.Width + TextLeftPad
                Next
                'Set the next line
                Y += .Bounds.Height
            End With
        Next
        'Draw the final page number.
        Gr.DrawString(CStr(CurrentPage), LV.Font, Brushes.Black, (e.PageBounds.Width - PageNumberWidth) / 2, e.PageBounds.Bottom - LV.Font.Height * 2)
        StringFormat.Dispose()
        Gr.Dispose()
        LastIndex = 0
        CurrentPage = 0
    End Sub

End Module

