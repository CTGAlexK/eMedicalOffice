Imports System.Runtime.InteropServices

Public Class NotifyMessage
    Private Const CS_DROPSHADOW As Integer = 131072

    ' Override the CreateParams property
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams

        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get

    End Property
#Region " Constructors "
    Public Sub New(ByVal pMessage As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Set the time for which the form should be displayed and the message to display.
        Dim myFont As Font = messageLabel.Font
        Dim StringSize As New SizeF
        Dim B As New Bitmap(16, 16)
        Dim G As Graphics = Graphics.FromImage(B)
        StringSize = G.MeasureString(pMessage, myFont)
        messageLabel.Text = pMessage
        Me.Height = StringSize.Height + 40
        If Me.Height < 80 Then Me.Height = 80

    End Sub

#End Region 'Constructors
    Private SaveIcon As Icon
    Public Shadows Sub Show()
        Me.Opacity = 0
        MyBase.Show()
        NotifyIcon1.Visible = True
        Timer1.Enabled = True
    End Sub
    Public Shadows Sub Show(ByVal Owner As System.Windows.Forms.IWin32Window)
        Me.Opacity = 0
        NotifyIcon1.Visible = True
        My.Computer.Audio.Play(My.Resources.Notify, AudioPlayMode.Background)
        MyBase.Show(Owner)
        Timer1.Enabled = True
    End Sub

    Private Sub NotifyMessage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Timer2.Enabled = False
        NotifyIcon1.Visible = False
        NotifyIcon1.Icon = My.Resources.MessageIcon

    End Sub


    Private Sub ToastForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Display the form just above the system tray.
        Dim TopLoc As Integer
        'Move each open form upwards to make room for this one.
        Dim lWidth As Integer
        Dim lHeight As Integer
        If Me.MdiParent Is Nothing Then
            lWidth = Screen.PrimaryScreen.WorkingArea.Width
            lHeight = Screen.PrimaryScreen.WorkingArea.Height
        Else
            For a As Integer = 0 To Me.MdiParent.Controls.Count - 1
                If TypeOf Me.MdiParent.Controls(a) Is MdiClient Then
                    lWidth = CType(Me.MdiParent.Controls(a), MdiClient).Width
                    lHeight = CType(Me.MdiParent.Controls(a), MdiClient).Height
                    Exit For
                End If
            Next
        End If
        TopLoc = (lHeight - Me.Height)
        Me.Location = New Point(lWidth - Me.Width - 3, TopLoc + 1)
        Me.TopMost = True
        SaveIcon = NotifyIcon1.Icon
    End Sub

    Private Sub ToastForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Not Me.CanFocus Then
            ToolStrip1.Focus()
        End If
    End Sub

    Private Sub ToastForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not Me.CanFocus Then
            ToolStrip1.Focus()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity += 0.02
        If Me.Opacity = 1 Then
            Timer1.Enabled = False
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If NotifyIcon1.Tag = "" Then
            NotifyIcon1.Icon = My.Resources.MessageGray
            NotifyIcon1.Tag = "1"
        Else
            NotifyIcon1.Icon = My.Resources.MessageIcon
            NotifyIcon1.Tag = ""
        End If
    End Sub

    Private Sub messageLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles messageLabel.Click

    End Sub

    Private Sub CloseMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseMessageToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Me.BringToFront()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

    End Sub
End Class