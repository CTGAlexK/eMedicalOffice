Public Class ComboBoxEx
    Inherits ComboBox
    Private _ValidateEmpty As Boolean
    Private _ValidateFrameColor As Color = Color.LightCoral
    Private WithEvents TMR As New Windows.Forms.Timer

    Public Property ValidateFrameColor() As Color
        Get
            Return _ValidateFrameColor
        End Get
        Set(ByVal Value As Color)
            _ValidateFrameColor = Value
            Me.Invalidate()
        End Set
    End Property
    Public Property ValidateEmpty() As Boolean
        Get
            Return _ValidateEmpty
        End Get
        Set(ByVal value As Boolean)
            _ValidateEmpty = value
            Me.Invalidate()
        End Set
    End Property
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
        Select Case m.Msg
            Case &HF
                If _ValidateEmpty And Me.SelectedIndex = -1 Then
                    Me.SuspendLayout()
                    Dim g As Graphics = Me.CreateGraphics
                    Dim p As Pen = New Pen(_ValidateFrameColor, 1)
                    Dim R As Rectangle = Me.ClientRectangle
                    R = New Rectangle(R.Left + 2, R.Top + 2, R.Right - 5, R.Bottom - 5)
                    g.DrawRectangle(p, R)
                    TMR.Enabled = True
                End If
            Case Else
                Exit Select
        End Select
    End Sub
    Public Shadows Property SelectedIndex() As Integer
        Get
            If MyBase.SelectedIndex <> -1 Then
                TMR.Enabled = True
            End If
            Return MyBase.SelectedIndex

        End Get
        Set(ByVal Value As Integer)
            MyBase.SelectedIndex = Value

        End Set
    End Property

    Private Sub TMR_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TMR.Tick
        TMR.Enabled = False
        Me.Invalidate(True)
    End Sub

    Public Sub New()
        TMR.Interval = 1
        TMR.Enabled = False
    End Sub
End Class