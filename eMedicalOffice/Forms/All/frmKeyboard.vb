Public Class frmKeyboard
    Public CalledForm As frmSplashNew
    Private DestinationControl As TextBox

    Private Sub frmKeyboard_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If CalledForm.Name = "frmSplashNew" Then
            With CalledForm
                If .ActiveControl Is Nothing Then
                    If .txtSQLServer.Visible Then
                        DestinationControl = .txtSQLServer
                    Else
                        DestinationControl = .txtUserName
                    End If
                Else
                    If TypeOf .ActiveControl Is TextBox Then
                        DestinationControl = .ActiveControl
                    Else
                        If .txtSQLServer.Visible Then
                            DestinationControl = .txtSQLServer
                        Else
                            DestinationControl = .txtUserName
                        End If
                    End If
                End If
            End With

        End If
    End Sub
    Public Function Load_Keyboard() As Point
        Me.Opacity = 0
        Dim Btn As Button
        Dim BtnSpace As Integer = 1
        Dim btnLeft As Integer = BtnSpace
        Dim btnTop As Integer = BtnSpace
        Dim BtnSize As Integer = 53
        Dim ColsPerRow As Integer = 10
        Dim ColCount As Integer

        For i As Integer = Asc("0") To Asc("9")
            Btn = New Button
            With Btn
                ColCount += 1
                .Name = "Btn_" & Chr(i)
                .Text = "&" & Chr(i)
                .Size = New Size(BtnSize, BtnSize)
                .Location = New Point(btnLeft, btnTop)
                .Tag = Chr(i)
                btnLeft = btnLeft + BtnSize + BtnSpace
                If ColCount Mod ColsPerRow = 0 Then
                    btnTop = btnTop + BtnSize + BtnSpace
                    btnLeft = BtnSpace
                End If
                .Font = New Font(New FontFamily(.Font.Name), 12, FontStyle.Bold)
                .Visible = True
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 1
                .FlatAppearance.CheckedBackColor = Color.DarkOrange
                .FlatAppearance.BorderColor = Color.LightSteelBlue
                .FlatAppearance.MouseDownBackColor = Color.DarkOrange

            End With
            Me.Controls.Add(Btn)
            AddHandler Btn.Click, AddressOf Btn_click
        Next

        For i As Integer = Asc("A") To Asc("Z")
            Btn = New Button
            With Btn
                ColCount += 1
                .Name = "Btn_" & Chr(i)
                .Text = "&" & Chr(i)
                .Size = New Size(BtnSize, BtnSize)
                .Location = New Point(btnLeft, btnTop)
                .Tag = Chr(i)
                btnLeft = btnLeft + BtnSize + BtnSpace
                If ColCount Mod ColsPerRow = 0 Then
                    btnTop = btnTop + BtnSize + BtnSpace
                    btnLeft = BtnSpace
                End If
                .Font = New Font(.Font, FontStyle.Bold)
                .Visible = True
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 1
                .FlatAppearance.CheckedBackColor = Color.DarkOrange
                .FlatAppearance.BorderColor = Color.LightSteelBlue
                .FlatAppearance.MouseDownBackColor = Color.DarkOrange


            End With
            Me.Controls.Add(Btn)
            AddHandler Btn.Click, AddressOf Btn_click
        Next
        Btn = New Button
        With Btn
            ColCount += 1
            .Name = "Btn_Clear"
            .Text = "&Clear"
            .Size = New Size(((BtnSize * 4) / 3) + BtnSpace, BtnSize)
            .Location = New Point(btnLeft, btnTop)
            .Tag = "Clear"
            btnLeft = btnLeft + ((BtnSize * 4) / 3) + BtnSpace + BtnSpace
            .Font = New Font(.Font, FontStyle.Bold)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.CheckedBackColor = Color.DarkOrange
            .FlatAppearance.BorderColor = Color.LightSteelBlue
            .FlatAppearance.MouseDownBackColor = Color.DarkOrange
            .Visible = True
        End With
        Me.Controls.Add(Btn)
        AddHandler Btn.Click, AddressOf Btn_click

        Btn = New Button
        With Btn
            ColCount += 1
            .Name = "Btn_Hide"
            .Text = "&Hide"
            .Size = New Size(((BtnSize * 4) / 3) + BtnSpace, BtnSize)
            .Location = New Point(btnLeft, btnTop)
            .Tag = "Hide"
            btnLeft = btnLeft + ((BtnSize * 4) / 3) + BtnSpace + BtnSpace
            .Font = New Font(.Font, FontStyle.Bold)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.CheckedBackColor = Color.DarkOrange
            .FlatAppearance.BorderColor = Color.LightSteelBlue
            .FlatAppearance.MouseDownBackColor = Color.DarkOrange
            .Visible = True
        End With
        Me.Controls.Add(Btn)
        AddHandler Btn.Click, AddressOf Btn_click
        Btn = New Button
        With Btn
            ColCount += 1
            .Name = "Btn_Enter"
            .Text = "&Enter"
            .Size = New Size(((BtnSize * 4) / 3) + BtnSpace, BtnSize)
            .Location = New Point(btnLeft, btnTop)
            .Tag = "Enter"
            .ForeColor = Color.Green
            .Font = New Font(.Font, FontStyle.Bold)
            btnLeft = btnLeft + ((BtnSize * 4) / 3) + BtnSpace + BtnSpace
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.CheckedBackColor = Color.DarkOrange
            .FlatAppearance.BorderColor = Color.LightSteelBlue
            .FlatAppearance.MouseDownBackColor = Color.DarkOrange
            .Visible = True
        End With
        Me.Controls.Add(Btn)
        AddHandler Btn.Click, AddressOf Btn_click

        ClientSize = New Size(BtnSpace + ((BtnSize + BtnSpace) * ColsPerRow) + BtnSpace, btnTop + BtnSize + BtnSpace)
        Return ClientSize

    End Function
    Private Sub Btn_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        If DestinationControl Is Nothing Then Exit Sub
        If DirectCast(sender, Button).Tag = "Hide" Then
            CalledForm.PictureBoxKeyboard.Visible = True
            Me.Close()
            Exit Sub
        End If
        If DirectCast(sender, Button).Tag = "Clear" Then
            DestinationControl.Text = ""
            DestinationControl.Focus()
            Exit Sub
        End If
        If DirectCast(sender, Button).Tag = "Enter" Then
            DestinationControl.Focus()
            SendKeys.Send(Chr(13))
            Exit Sub
        End If

        DestinationControl.Text = DestinationControl.Text & DirectCast(sender, Button).Tag
        DestinationControl.Focus()
    End Sub

    Private Sub frmKeyboard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.02
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
        End If
    End Sub
End Class