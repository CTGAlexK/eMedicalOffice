<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSplashNew
    Inherits RoundedForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplashNew))
        Me.ButtonLogin = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSQLServer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSQLServerDatabaseName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSQLServerUID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSQLServerPassword = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ComboBoxOffice = New System.Windows.Forms.ComboBox()
        Me.txtSC = New System.Windows.Forms.TextBox()
        Me.LabelOffice = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBoxKeyboard = New System.Windows.Forms.PictureBox()
        Me.PictureBoxWin8Logo = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.chkUpdate = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBoxProgress = New System.Windows.Forms.PictureBox()
        Me.TimerText = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PanelLogin = New System.Windows.Forms.Panel()
        Me.PanelLoading = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxWin8Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLogin.SuspendLayout()
        Me.PanelLoading.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonLogin
        '
        Me.ButtonLogin.BackColor = System.Drawing.Color.White
        Me.ButtonLogin.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonLogin.FlatAppearance.BorderSize = 0
        Me.ButtonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLogin.Image = CType(resources.GetObject("ButtonLogin.Image"), System.Drawing.Image)
        Me.ButtonLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLogin.Location = New System.Drawing.Point(15, 85)
        Me.ButtonLogin.Name = "ButtonLogin"
        Me.ButtonLogin.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLogin.TabIndex = 9
        Me.ButtonLogin.Text = "Login"
        Me.ButtonLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonLogin.UseVisualStyleBackColor = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.White
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancel.Image = CType(resources.GetObject("ButtonCancel.Image"), System.Drawing.Image)
        Me.ButtonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCancel.Location = New System.Drawing.Point(100, 85)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 10
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.Color.White
        Me.txtUserName.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtUserName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtUserName.Location = New System.Drawing.Point(15, 17)
        Me.txtUserName.MaxLength = 10
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(158, 20)
        Me.txtUserName.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtUserName, "Login User Name")
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtPassword, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtPassword.Location = New System.Drawing.Point(15, 59)
        Me.txtPassword.MaxLength = 10
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(158, 20)
        Me.txtPassword.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txtPassword, "Login Password")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "User Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(348, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(191, 210)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'txtSQLServer
        '
        Me.txtSQLServer.BackColor = System.Drawing.Color.White
        Me.ErrorProvider1.SetIconAlignment(Me.txtSQLServer, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtSQLServer.Location = New System.Drawing.Point(363, 151)
        Me.txtSQLServer.Name = "txtSQLServer"
        Me.txtSQLServer.Size = New System.Drawing.Size(158, 20)
        Me.txtSQLServer.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtSQLServer, "SQL Server Name or SQL Server IP Address ")
        Me.txtSQLServer.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(360, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "SQL Server IP/Name"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(360, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Database Name"
        Me.Label5.Visible = False
        '
        'txtSQLServerDatabaseName
        '
        Me.txtSQLServerDatabaseName.BackColor = System.Drawing.Color.White
        Me.ErrorProvider1.SetIconAlignment(Me.txtSQLServerDatabaseName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtSQLServerDatabaseName.Location = New System.Drawing.Point(363, 186)
        Me.txtSQLServerDatabaseName.Name = "txtSQLServerDatabaseName"
        Me.txtSQLServerDatabaseName.Size = New System.Drawing.Size(158, 20)
        Me.txtSQLServerDatabaseName.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtSQLServerDatabaseName, "System SQL Server Database Name")
        Me.txtSQLServerDatabaseName.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(360, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "SQL Server Uset ID"
        Me.Label6.Visible = False
        '
        'txtSQLServerUID
        '
        Me.txtSQLServerUID.BackColor = System.Drawing.Color.White
        Me.ErrorProvider1.SetIconAlignment(Me.txtSQLServerUID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtSQLServerUID.Location = New System.Drawing.Point(363, 221)
        Me.txtSQLServerUID.Name = "txtSQLServerUID"
        Me.txtSQLServerUID.Size = New System.Drawing.Size(158, 20)
        Me.txtSQLServerUID.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtSQLServerUID, "SQL Server System User ID")
        Me.txtSQLServerUID.UseSystemPasswordChar = True
        Me.txtSQLServerUID.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(360, 243)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "SQL Server Password"
        Me.Label7.Visible = False
        '
        'txtSQLServerPassword
        '
        Me.txtSQLServerPassword.BackColor = System.Drawing.Color.White
        Me.ErrorProvider1.SetIconAlignment(Me.txtSQLServerPassword, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtSQLServerPassword.Location = New System.Drawing.Point(363, 256)
        Me.txtSQLServerPassword.Name = "txtSQLServerPassword"
        Me.txtSQLServerPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSQLServerPassword.Size = New System.Drawing.Size(158, 20)
        Me.txtSQLServerPassword.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtSQLServerPassword, "SQL Server System Password")
        Me.txtSQLServerPassword.UseSystemPasswordChar = True
        Me.txtSQLServerPassword.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
        '
        'ComboBoxOffice
        '
        Me.ComboBoxOffice.BackColor = System.Drawing.Color.White
        Me.ComboBoxOffice.DropDownWidth = 300
        Me.ComboBoxOffice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxOffice.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxOffice, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxOffice.Location = New System.Drawing.Point(363, 291)
        Me.ComboBoxOffice.Name = "ComboBoxOffice"
        Me.ComboBoxOffice.Size = New System.Drawing.Size(158, 21)
        Me.ComboBoxOffice.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.ComboBoxOffice, "Current Office Name")
        Me.ComboBoxOffice.Visible = False
        '
        'txtSC
        '
        Me.txtSC.BackColor = System.Drawing.Color.White
        Me.ErrorProvider1.SetIconAlignment(Me.txtSC, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtSC.Location = New System.Drawing.Point(98, 59)
        Me.txtSC.MaxLength = 10
        Me.txtSC.Name = "txtSC"
        Me.txtSC.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSC.Size = New System.Drawing.Size(75, 20)
        Me.txtSC.TabIndex = 8
        Me.txtSC.Visible = False
        '
        'LabelOffice
        '
        Me.LabelOffice.AutoSize = True
        Me.LabelOffice.BackColor = System.Drawing.Color.Transparent
        Me.LabelOffice.ForeColor = System.Drawing.Color.White
        Me.LabelOffice.Location = New System.Drawing.Point(360, 278)
        Me.LabelOffice.Name = "LabelOffice"
        Me.LabelOffice.Size = New System.Drawing.Size(66, 13)
        Me.LabelOffice.TabIndex = 18
        Me.LabelOffice.Text = "Office Name"
        Me.LabelOffice.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 1
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 50
        Me.ToolTip1.ShowAlways = True
        '
        'PictureBoxKeyboard
        '
        Me.PictureBoxKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxKeyboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxKeyboard.Image = CType(resources.GetObject("PictureBoxKeyboard.Image"), System.Drawing.Image)
        Me.PictureBoxKeyboard.Location = New System.Drawing.Point(298, 460)
        Me.PictureBoxKeyboard.Name = "PictureBoxKeyboard"
        Me.PictureBoxKeyboard.Size = New System.Drawing.Size(32, 28)
        Me.PictureBoxKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxKeyboard.TabIndex = 25
        Me.PictureBoxKeyboard.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxKeyboard, "Touch Screen Keyboard")
        '
        'PictureBoxWin8Logo
        '
        Me.PictureBoxWin8Logo.BackColor = System.Drawing.Color.White
        Me.PictureBoxWin8Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBoxWin8Logo.Image = CType(resources.GetObject("PictureBoxWin8Logo.Image"), System.Drawing.Image)
        Me.PictureBoxWin8Logo.Location = New System.Drawing.Point(299, 229)
        Me.PictureBoxWin8Logo.Name = "PictureBoxWin8Logo"
        Me.PictureBoxWin8Logo.Size = New System.Drawing.Size(24, 24)
        Me.PictureBoxWin8Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxWin8Logo.TabIndex = 39
        Me.PictureBoxWin8Logo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxWin8Logo, "Windows 8 Compatible")
        Me.PictureBoxWin8Logo.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.White
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(152, 63)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(21, 15)
        Me.PictureBox4.TabIndex = 40
        Me.PictureBox4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox4, "Show Hidden Password Characters")
        '
        'chkUpdate
        '
        Me.chkUpdate.AutoSize = True
        Me.chkUpdate.BackColor = System.Drawing.Color.Transparent
        Me.chkUpdate.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red
        Me.chkUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.chkUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkUpdate.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkUpdate.ForeColor = System.Drawing.Color.White
        Me.chkUpdate.Location = New System.Drawing.Point(12, 468)
        Me.chkUpdate.Name = "chkUpdate"
        Me.chkUpdate.Size = New System.Drawing.Size(98, 20)
        Me.chkUpdate.TabIndex = 50
        Me.chkUpdate.Text = "Force Update"
        Me.chkUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.chkUpdate, "Force Auto Update")
        Me.chkUpdate.UseVisualStyleBackColor = False
        Me.chkUpdate.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "345634563456"
        Me.Label8.Visible = False
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(222, 108)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(299, 13)
        Me.lblVersion.TabIndex = 22
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(184, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(312, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Verifying Database Connection. Please Wait..."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(15, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(315, 116)
        Me.Label10.TabIndex = 34
        '
        'PictureBoxProgress
        '
        Me.PictureBoxProgress.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxProgress.Image = CType(resources.GetObject("PictureBoxProgress.Image"), System.Drawing.Image)
        Me.PictureBoxProgress.Location = New System.Drawing.Point(505, 72)
        Me.PictureBoxProgress.Name = "PictureBoxProgress"
        Me.PictureBoxProgress.Size = New System.Drawing.Size(18, 18)
        Me.PictureBoxProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxProgress.TabIndex = 35
        Me.PictureBoxProgress.TabStop = False
        '
        'TimerText
        '
        Me.TimerText.Interval = 50
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 270)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(334, 232)
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(18, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 16)
        Me.PictureBox2.TabIndex = 37
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(52, 13)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 15)
        Me.PictureBox3.TabIndex = 38
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PanelLogin
        '
        Me.PanelLogin.BackColor = System.Drawing.Color.Transparent
        Me.PanelLogin.Controls.Add(Me.PictureBox4)
        Me.PanelLogin.Controls.Add(Me.txtSC)
        Me.PanelLogin.Controls.Add(Me.Label2)
        Me.PanelLogin.Controls.Add(Me.Label1)
        Me.PanelLogin.Controls.Add(Me.txtPassword)
        Me.PanelLogin.Controls.Add(Me.txtUserName)
        Me.PanelLogin.Controls.Add(Me.ButtonCancel)
        Me.PanelLogin.Controls.Add(Me.ButtonLogin)
        Me.PanelLogin.Location = New System.Drawing.Point(346, 375)
        Me.PanelLogin.Name = "PanelLogin"
        Me.PanelLogin.Size = New System.Drawing.Size(190, 114)
        Me.PanelLogin.TabIndex = 41
        Me.PanelLogin.Visible = False
        '
        'PanelLoading
        '
        Me.PanelLoading.BackColor = System.Drawing.Color.Transparent
        Me.PanelLoading.BackgroundImage = CType(resources.GetObject("PanelLoading.BackgroundImage"), System.Drawing.Image)
        Me.PanelLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanelLoading.Controls.Add(Me.PictureBox5)
        Me.PanelLoading.Location = New System.Drawing.Point(387, 387)
        Me.PanelLoading.Name = "PanelLoading"
        Me.PanelLoading.Size = New System.Drawing.Size(100, 88)
        Me.PanelLoading.TabIndex = 48
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(38, 33)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 46
        Me.PictureBox5.TabStop = False
        '
        'frmSplashNew
        '
        Me.AcceptButton = Me.ButtonLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(548, 500)
        Me.Controls.Add(Me.chkUpdate)
        Me.Controls.Add(Me.PanelLogin)
        Me.Controls.Add(Me.PictureBoxWin8Logo)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBoxProgress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.LabelOffice)
        Me.Controls.Add(Me.ComboBoxOffice)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSQLServerPassword)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSQLServerUID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSQLServerDatabaseName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSQLServer)
        Me.Controls.Add(Me.PictureBoxKeyboard)
        Me.Controls.Add(Me.PanelLoading)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmSplashNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "eMedicalOffice"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxWin8Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxProgress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLogin.ResumeLayout(False)
        Me.PanelLogin.PerformLayout()
        Me.PanelLoading.ResumeLayout(False)
        Me.PanelLoading.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonLogin As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSQLServer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSQLServerDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSQLServerUID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSQLServerPassword As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents LabelOffice As System.Windows.Forms.Label
    Friend WithEvents ComboBoxOffice As System.Windows.Forms.ComboBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents txtSC As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PictureBoxKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxProgress As System.Windows.Forms.PictureBox
    Friend WithEvents TimerText As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxWin8Logo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PanelLogin As System.Windows.Forms.Panel
    Friend WithEvents PanelLoading As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents chkUpdate As CheckBox
End Class
