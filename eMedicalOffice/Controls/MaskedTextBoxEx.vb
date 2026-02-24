Public Class MaskedTextBoxEx
    Inherits System.Windows.Forms.MaskedTextBox
    Private _ValidateEmpty As Boolean
    Private _ValidateFrameColor As Color = Color.LightCoral

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
                If _ValidateEmpty And Me.MaskCompleted = False Then
                    Dim g As Graphics = Me.CreateGraphics
                    Dim p As Pen = New Pen(_ValidateFrameColor, 2)
                    g.DrawRectangle(p, Me.ClientRectangle)
                End If
            Case Else
                Exit Select
        End Select

    End Sub
End Class
