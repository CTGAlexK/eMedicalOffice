<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _Startup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_Startup))
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.PanelLogin = New System.Windows.Forms.Panel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonLogin = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.dummy = New System.Windows.Forms.Button()
        Me.PictureBoxWin8Logo = New System.Windows.Forms.PictureBox()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.lblLicense = New System.Windows.Forms.Label()
        Me.PanelLogin.SuspendLayout
        CType(Me.PictureBoxWin8Logo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = true
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Checked = true
        Me.RadioButton1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadioButton1.Location = New System.Drawing.Point(20, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(138, 21)
        Me.RadioButton1.TabIndex = 9
        Me.RadioButton1.TabStop = true
        Me.RadioButton1.Text = "Single Office Mode"
        Me.RadioButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadioButton1.UseVisualStyleBackColor = false
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = true
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.White
        Me.RadioButton2.Location = New System.Drawing.Point(20, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(150, 21)
        Me.RadioButton2.TabIndex = 10
        Me.RadioButton2.Text = "Multiple Office Mode"
        Me.RadioButton2.UseVisualStyleBackColor = false
        '
        'PanelLogin
        '
        Me.PanelLogin.BackColor = System.Drawing.Color.Transparent
        Me.PanelLogin.Controls.Add(Me.ButtonCancel)
        Me.PanelLogin.Controls.Add(Me.RadioButton2)
        Me.PanelLogin.Controls.Add(Me.ButtonLogin)
        Me.PanelLogin.Controls.Add(Me.RadioButton1)
        Me.PanelLogin.Location = New System.Drawing.Point(348, 376)
        Me.PanelLogin.Name = "PanelLogin"
        Me.PanelLogin.Size = New System.Drawing.Size(190, 111)
        Me.PanelLogin.TabIndex = 42
        Me.PanelLogin.Visible = false
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.White
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancel.Image = CType(resources.GetObject("ButtonCancel.Image"),System.Drawing.Image)
        Me.ButtonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCancel.Location = New System.Drawing.Point(100, 82)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 10
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancel.UseVisualStyleBackColor = false
        '
        'ButtonLogin
        '
        Me.ButtonLogin.BackColor = System.Drawing.Color.White
        Me.ButtonLogin.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonLogin.FlatAppearance.BorderSize = 0
        Me.ButtonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLogin.Image = CType(resources.GetObject("ButtonLogin.Image"),System.Drawing.Image)
        Me.ButtonLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLogin.Location = New System.Drawing.Point(15, 82)
        Me.ButtonLogin.Name = "ButtonLogin"
        Me.ButtonLogin.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLogin.TabIndex = 9
        Me.ButtonLogin.Text = "Save"
        Me.ButtonLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonLogin.UseVisualStyleBackColor = false
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'dummy
        '
        Me.dummy.Location = New System.Drawing.Point(-1000, 0)
        Me.dummy.Name = "dummy"
        Me.dummy.Size = New System.Drawing.Size(75, 23)
        Me.dummy.TabIndex = 43
        Me.dummy.Text = "Button1"
        Me.dummy.UseVisualStyleBackColor = true
        '
        'PictureBoxWin8Logo
        '
        Me.PictureBoxWin8Logo.BackColor = System.Drawing.Color.White
        Me.PictureBoxWin8Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBoxWin8Logo.Image = CType(resources.GetObject("PictureBoxWin8Logo.Image"),System.Drawing.Image)
        Me.PictureBoxWin8Logo.Location = New System.Drawing.Point(297, 227)
        Me.PictureBoxWin8Logo.Name = "PictureBoxWin8Logo"
        Me.PictureBoxWin8Logo.Size = New System.Drawing.Size(24, 24)
        Me.PictureBoxWin8Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxWin8Logo.TabIndex = 45
        Me.PictureBoxWin8Logo.TabStop = false
        '
        'LabelInfo
        '
        Me.LabelInfo.BackColor = System.Drawing.Color.Transparent
        Me.LabelInfo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.LabelInfo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelInfo.Location = New System.Drawing.Point(344, 137)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(189, 178)
        Me.LabelInfo.TabIndex = 46
        Me.LabelInfo.Text = resources.GetString("LabelInfo.Text")
        '
        'lblLicense
        '
        Me.lblLicense.AutoSize = true
        Me.lblLicense.BackColor = System.Drawing.Color.Transparent
        Me.lblLicense.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLicense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.lblLicense.ForeColor = System.Drawing.Color.DimGray
        Me.lblLicense.Location = New System.Drawing.Point(12, 109)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(257, 13)
        Me.lblLicense.TabIndex = 48
        Me.lblLicense.Text = "PLEASE SELECT AN OPERATIONAL MODE"
        '
        '_Startup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(546, 498)
        Me.ControlBox = false
        Me.Controls.Add(Me.lblLicense)
        Me.Controls.Add(Me.LabelInfo)
        Me.Controls.Add(Me.PictureBoxWin8Logo)
        Me.Controls.Add(Me.dummy)
        Me.Controls.Add(Me.PanelLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "_Startup"
        Me.Opacity = 0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelLogin.ResumeLayout(false)
        Me.PanelLogin.PerformLayout
        CType(Me.PictureBoxWin8Logo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents PanelLogin As Panel
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonLogin As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents dummy As Button
    Friend WithEvents PictureBoxWin8Logo As PictureBox
    Friend WithEvents LabelInfo As Label
    Friend WithEvents lblLicense As Label
End Class
