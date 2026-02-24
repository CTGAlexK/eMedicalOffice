Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class AutoCompleteComboBox
    Inherits ComboBox

    Private Const WM_PAINT As Integer = 15

    Private _borderColor As Color = Color.Black

    Private _limitToList As Boolean = True

    Private _MaxValue As Double = Double.MaxValue

    Private _NoDecimals As Boolean

    Private _NumericOnly As Boolean

    Private _saveBorderColor As Color = Color.Black

    Private m_readOnly As Boolean

    Public Sub New()
        MyBase.New
        DoubleBuffered = True
    End Sub

    <Description("Specify if DropDown box is in readonly mode"),
     Category("Behavior")>
    Public Property ReadOnlyCombo As Boolean
        Get
            Return Me.m_readOnly
        End Get
        Set
            m_readOnly = Value
            DropDownStyle = IIf(m_readOnly, ComboBoxStyle.Simple, ComboBoxStyle.DropDown)
            BackColor = IIf(m_readOnly, Color.FromKnownColor(KnownColor.Control), Color.White)
        End Set
    End Property

    <Category("Behavior")>
    Public Property LimitToList As Boolean
        Get
            Return Me._limitToList
        End Get
        Set
            Me._limitToList = Value
        End Set
    End Property

    <Category("Numeric Behavior")>
    Public Property NumericOnly As Boolean
        Get
            Return Me._NumericOnly
        End Get
        Set
            Me._NumericOnly = Value
        End Set
    End Property

    <Category("Numeric Behavior")>
    Public Property NoDecimals As Boolean
        Get
            Return Me._NoDecimals
        End Get
        Set
            Me._NoDecimals = Value
        End Set
    End Property

    <Category("Numeric Behavior")>
    Public Property MaxNumericValue As Double
        Get
            Return Me._MaxValue
        End Get
        Set
            Me._MaxValue = Value
        End Set
    End Property

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        If (Text = "") Then
            SelectedIndex = -1
            OnSelectedIndexChanged(e)
        End If

        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        If Me.m_readOnly Then
            e.Handled = True
            e.SuppressKeyPress = True
            Return
        End If

        If ((e.KeyCode = Keys.V) _
                    AndAlso (e.Modifiers = Keys.Control)) Then
            Dim ret = Clipboard.GetText
            If Me._NumericOnly AndAlso Not IsNumeric(ret) Then
                e.Handled = True
                e.SuppressKeyPress = True
                Return
            End If

            If Me._NumericOnly AndAlso Not IsNumeric(ret) Then
                If (Double.Parse(ret) > Me._MaxValue) Then
                    e.Handled = True
                    e.SuppressKeyPress = True
                    Return
                End If

            End If

            Dim intIdx = FindString(ret)
            If (intIdx <> -1) Then
                SelectedText = ret
                SelectedIndex = intIdx
                SelectionStart = 0
                SelectionLength = ret.Length
                e.SuppressKeyPress = True
                e.Handled = True
            Else
                If Me._limitToList Then
                    Text = ""
                End If

                SelectedIndex = -1
                e.SuppressKeyPress = True
                e.Handled = True
            End If

            e.SuppressKeyPress = True
            e.Handled = True
        End If

        MyBase.OnKeyDown(e)
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        If Me.m_readOnly Then
            e.Handled = True
            Return
        End If

        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Escape) Then
            DroppedDown = False
            e.Handled = True
            MyBase.OnKeyPress(e)
            Return
        End If

        If Me._NumericOnly Then
            If (Not Char.IsControl(e.KeyChar) _
                        AndAlso (Not Char.IsDigit(e.KeyChar) _
                        AndAlso (e.KeyChar <> Microsoft.VisualBasic.ChrW(46)))) Then
                e.Handled = True
                Return
            End If

            If Me._NoDecimals Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(46)) Then
                    e.Handled = True
                    Return
                End If

            End If

            ' only allow one decimal point
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46)) _
                        AndAlso (Text.IndexOf(Microsoft.VisualBasic.ChrW(46)) > -1)) Then
                e.Handled = True
            End If

            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46)) _
                        AndAlso (Text.IndexOf(Microsoft.VisualBasic.ChrW(46)) > -1)) Then
                e.Handled = True
                Return
            End If

        End If

        Dim strFindStr As String
        If e.KeyChar = ChrW(Keys.Back) Then
            If (SelectionStart <= 1) Then
                Text = ""
                SelectedIndex = -1
                DroppedDown = False
                Return
            End If

            strFindStr = IIf(SelectionLength = 0, Text.Mid(1, (Text.Length - 1)), Text.Mid(1, (SelectionStart - 1)))
        ElseIf (SelectionLength = 0) Then
            strFindStr = (Text + e.KeyChar)
        Else
            strFindStr = (Mid(Text, 1, SelectionStart) + e.KeyChar)
        End If

        If Me._NumericOnly Then
            If (Double.Parse(strFindStr) > Me._MaxValue) Then
                e.Handled = True
                Return
            End If

        End If

        DroppedDown = True
        ' Search the string in the ComboBox list.
        Dim intIdx = FindString(strFindStr)
        If (intIdx <> -1) Then
            SelectedText = strFindStr
            SelectedIndex = intIdx
            SelectionStart = strFindStr.Length
            SelectionLength = Text.Length
            e.Handled = True
        ElseIf Me._limitToList Then
            e.Handled = True
        End If

        MyBase.OnKeyPress(e)
    End Sub

    Public Sub SelectItemByValue(ByVal value As String)
        Dim i As Integer = 0
        Do While (i < Items.Count)
            Dim prop = Items(i).GetType.GetProperty(ValueMember)
            If ((Not (prop) Is Nothing) _
                        AndAlso (prop.GetValue(Items(i), Nothing).ToString = value)) Then
                SelectedIndex = i
                Exit Do
            End If

            i = (i + 1)
        Loop

    End Sub

End Class