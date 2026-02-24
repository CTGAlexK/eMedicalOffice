Public Class RoundedForm
    Inherits Form

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim path As New Drawing2D.GraphicsPath()
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)

        ' Radius determines how round you want the corners to be
        Dim radius As Integer = 20

        ' Add arcs to the path to create rounded corners
        path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90)

        ' Close the path
        path.CloseFigure()

        ' Set the region to be the rounded rectangle
        'Me.Region = New Region(path)
        Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20))
    End Sub
End Class
