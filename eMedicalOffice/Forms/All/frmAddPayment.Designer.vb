<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddPayment))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBoxAudio = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkScanCheck = New System.Windows.Forms.CheckBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.txtCheckNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBillAmount = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboNotes = New System.Windows.Forms.ComboBox()
        Me.txtRemaining = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.PaymentDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PaymentType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CheckNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Notes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPaid = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkNoMoreCollection = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCloseProfile = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboPart = New System.Windows.Forms.ComboBox()
        Me.cmdUnlockPostedDate = New System.Windows.Forms.Button()
        Me.ListViewBills = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBoxInfo = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBoxInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.CheckBoxAudio)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblMsg)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(881, 37)
        Me.Panel1.TabIndex = 146
        '
        'CheckBoxAudio
        '
        Me.CheckBoxAudio.AutoSize = True
        Me.CheckBoxAudio.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxAudio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxAudio.ForeColor = System.Drawing.Color.DimGray
        Me.CheckBoxAudio.Location = New System.Drawing.Point(763, 17)
        Me.CheckBoxAudio.Name = "CheckBoxAudio"
        Me.CheckBoxAudio.Size = New System.Drawing.Size(62, 17)
        Me.CheckBoxAudio.TabIndex = 0
        Me.CheckBoxAudio.Text = "Audio :)"
        Me.CheckBoxAudio.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(843, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(7, 12)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(96, 13)
        Me.lblMsg.TabIndex = 0
        Me.lblMsg.Text = "BILL PAYMENT"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.chkScanCheck)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 532)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(881, 34)
        Me.Panel2.TabIndex = 145
        '
        'chkScanCheck
        '
        Me.chkScanCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkScanCheck.AutoSize = True
        Me.chkScanCheck.BackColor = System.Drawing.Color.Transparent
        Me.chkScanCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkScanCheck.Location = New System.Drawing.Point(553, 12)
        Me.chkScanCheck.Name = "chkScanCheck"
        Me.chkScanCheck.Size = New System.Drawing.Size(182, 17)
        Me.chkScanCheck.TabIndex = 2
        Me.chkScanCheck.Text = "Scan Processed Payment Check"
        Me.chkScanCheck.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = False
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(7, 7)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
        Me.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUpdate.Location = New System.Drawing.Point(741, 7)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(128, 24)
        Me.cmdUpdate.TabIndex = 1
        Me.cmdUpdate.Text = "Process Payment"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtCheckNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ErrorProvider1.SetIconPadding(Me.txtCheckNumber, -17)
        Me.txtCheckNumber.Location = New System.Drawing.Point(253, 387)
        Me.txtCheckNumber.MaxLength = 20
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(107, 20)
        Me.txtCheckNumber.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtCheckNumber, "Payment Check Number")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(250, 373)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Check Number"
        '
        'txtAmount
        '
        Me.txtAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -17)
        Me.txtAmount.Location = New System.Drawing.Point(424, 387)
        Me.txtAmount.MaxLength = 50
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(85, 20)
        Me.txtAmount.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtAmount, "Payment Check Amount")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(421, 371)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Check Amount"
        '
        'txtNotes
        '
        Me.txtNotes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtNotes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtNotes.Enabled = False
        Me.ErrorProvider1.SetIconPadding(Me.txtNotes, -17)
        Me.txtNotes.Location = New System.Drawing.Point(7, 453)
        Me.txtNotes.MaxLength = 2000
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(866, 68)
        Me.txtNotes.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 408)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "Payment Notes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(509, 372)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 154
        Me.Label5.Text = "Bill Amount"
        '
        'txtBillAmount
        '
        Me.txtBillAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtBillAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBillAmount.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtBillAmount.ForeColor = System.Drawing.Color.Black
        Me.txtBillAmount.Location = New System.Drawing.Point(512, 387)
        Me.txtBillAmount.MaxLength = 10
        Me.txtBillAmount.Name = "txtBillAmount"
        Me.txtBillAmount.Size = New System.Drawing.Size(73, 20)
        Me.txtBillAmount.TabIndex = 6
        Me.txtBillAmount.TabStop = False
        Me.txtBillAmount.Tag = ""
        Me.ToolTip1.SetToolTip(Me.txtBillAmount, "Billed Amount")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cboNotes
        '
        Me.cboNotes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNotes.FormattingEnabled = True
        Me.ErrorProvider1.SetIconPadding(Me.cboNotes, -17)
        Me.cboNotes.Location = New System.Drawing.Point(7, 424)
        Me.cboNotes.Name = "cboNotes"
        Me.cboNotes.Size = New System.Drawing.Size(866, 21)
        Me.cboNotes.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.cboNotes, "Payment Notes")
        '
        'txtRemaining
        '
        Me.txtRemaining.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtRemaining.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtRemaining.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRemaining.Location = New System.Drawing.Point(664, 387)
        Me.txtRemaining.MaxLength = 10
        Me.txtRemaining.Name = "txtRemaining"
        Me.txtRemaining.Size = New System.Drawing.Size(73, 20)
        Me.txtRemaining.TabIndex = 8
        Me.txtRemaining.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txtRemaining, "Bill Remaining Balance")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(661, 371)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Balance"
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PaymentDate, Me.PaymentType, Me.Amount, Me.CheckNumber, Me.Notes})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(8, 229)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(865, 118)
        Me.ListView1.TabIndex = 12
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'PaymentDate
        '
        Me.PaymentDate.Text = "Payment DT"
        Me.PaymentDate.Width = 96
        '
        'PaymentType
        '
        Me.PaymentType.Text = "Type"
        Me.PaymentType.Width = 130
        '
        'Amount
        '
        Me.Amount.Text = "Amount"
        Me.Amount.Width = 93
        '
        'CheckNumber
        '
        Me.CheckNumber.Text = "Check #"
        Me.CheckNumber.Width = 103
        '
        'Notes
        '
        Me.Notes.Text = "Notes"
        Me.Notes.Width = 112
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(585, 371)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 161
        Me.Label7.Text = "Previously Paid"
        '
        'txtPaid
        '
        Me.txtPaid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPaid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPaid.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPaid.Location = New System.Drawing.Point(588, 387)
        Me.txtPaid.MaxLength = 10
        Me.txtPaid.Name = "txtPaid"
        Me.txtPaid.Size = New System.Drawing.Size(73, 20)
        Me.txtPaid.TabIndex = 7
        Me.txtPaid.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txtPaid, "Previous Payment(s) Received Amount")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        '
        'chkNoMoreCollection
        '
        Me.chkNoMoreCollection.AutoSize = True
        Me.chkNoMoreCollection.BackColor = System.Drawing.Color.Transparent
        Me.chkNoMoreCollection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNoMoreCollection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoMoreCollection.Location = New System.Drawing.Point(757, 372)
        Me.chkNoMoreCollection.Name = "chkNoMoreCollection"
        Me.chkNoMoreCollection.Size = New System.Drawing.Size(116, 17)
        Me.chkNoMoreCollection.TabIndex = 9
        Me.chkNoMoreCollection.Text = "No More Collection"
        Me.ToolTip1.SetToolTip(Me.chkNoMoreCollection, "Set Current Bill as No More Collection")
        Me.chkNoMoreCollection.UseVisualStyleBackColor = False
        '
        'CheckBoxCloseProfile
        '
        Me.CheckBoxCloseProfile.AutoSize = True
        Me.CheckBoxCloseProfile.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxCloseProfile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCloseProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCloseProfile.ForeColor = System.Drawing.Color.Red
        Me.CheckBoxCloseProfile.Location = New System.Drawing.Point(746, 397)
        Me.CheckBoxCloseProfile.Name = "CheckBoxCloseProfile"
        Me.CheckBoxCloseProfile.Size = New System.Drawing.Size(127, 17)
        Me.CheckBoxCloseProfile.TabIndex = 10
        Me.CheckBoxCloseProfile.Text = "Close Patient's Profile"
        Me.ToolTip1.SetToolTip(Me.CheckBoxCloseProfile, "Close Patient's Profile")
        Me.CheckBoxCloseProfile.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.CausesValidation = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(487, 389)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(19, 15)
        Me.Button1.TabIndex = 168
        Me.Button1.Text = "..."
        Me.ToolTip1.SetToolTip(Me.Button1, "Fill Amount")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboPart
        '
        Me.cboPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPart.FormattingEnabled = True
        Me.cboPart.Location = New System.Drawing.Point(374, 386)
        Me.cboPart.Name = "cboPart"
        Me.cboPart.Size = New System.Drawing.Size(46, 21)
        Me.cboPart.TabIndex = 4
        Me.cboPart.TabStop = False
        Me.ToolTip1.SetToolTip(Me.cboPart, "If this payment is covering more then one bill," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Use the Part option to specify t" &
        "he Check-Part Number." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The Check Number will appear as CheckNumber-PartNumber")
        '
        'cmdUnlockPostedDate
        '
        Me.cmdUnlockPostedDate.BackColor = System.Drawing.Color.White
        Me.cmdUnlockPostedDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdUnlockPostedDate.FlatAppearance.BorderSize = 0
        Me.cmdUnlockPostedDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUnlockPostedDate.Image = CType(resources.GetObject("cmdUnlockPostedDate.Image"), System.Drawing.Image)
        Me.cmdUnlockPostedDate.Location = New System.Drawing.Point(178, 385)
        Me.cmdUnlockPostedDate.Name = "cmdUnlockPostedDate"
        Me.cmdUnlockPostedDate.Size = New System.Drawing.Size(16, 19)
        Me.cmdUnlockPostedDate.TabIndex = 338
        Me.cmdUnlockPostedDate.TabStop = False
        Me.ToolTip1.SetToolTip(Me.cmdUnlockPostedDate, "Unlock Check Posted Date")
        Me.cmdUnlockPostedDate.UseVisualStyleBackColor = False
        '
        'ListViewBills
        '
        Me.ListViewBills.AllowColumnReorder = True
        Me.ListViewBills.BackColor = System.Drawing.Color.White
        Me.ListViewBills.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader7})
        Me.ListViewBills.FullRowSelect = True
        Me.ListViewBills.GridLines = True
        Me.ListViewBills.HideSelection = False
        Me.ListViewBills.Location = New System.Drawing.Point(10, 58)
        Me.ListViewBills.Name = "ListViewBills"
        Me.ListViewBills.Size = New System.Drawing.Size(863, 146)
        Me.ListViewBills.TabIndex = 11
        Me.ListViewBills.UseCompatibleStateImageBehavior = False
        Me.ListViewBills.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Bill #"
        Me.ColumnHeader6.Width = 93
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Bill DT"
        Me.ColumnHeader2.Width = 106
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Bill Status"
        Me.ColumnHeader5.Width = 85
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Bill Amount"
        Me.ColumnHeader3.Width = 136
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Paid Amoun"
        Me.ColumnHeader4.Width = 184
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Service DT"
        Me.ColumnHeader7.Width = 102
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(881, 327)
        Me.Panel3.TabIndex = 166
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(12, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 13)
        Me.Label8.TabIndex = 166
        Me.Label8.Text = "Patient Procedures / Bills"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 13)
        Me.Label6.TabIndex = 160
        Me.Label6.Text = "Current Bill Previous Payments"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(198, 387)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "Cash"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(8, 384)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(82, 20)
        Me.DateTimePicker1.TabIndex = 0
        Me.DateTimePicker1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 371)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 171
        Me.Label9.Text = "Check Date"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(373, 371)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = "Part #"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(360, 388)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 19)
        Me.Label11.TabIndex = 173
        Me.Label11.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(96, 371)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 175
        Me.Label12.Text = "Posted Date"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(96, 384)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(82, 20)
        Me.DateTimePicker2.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'PictureBoxInfo
        '
        Me.PictureBoxInfo.Image = CType(resources.GetObject("PictureBoxInfo.Image"), System.Drawing.Image)
        Me.PictureBoxInfo.Location = New System.Drawing.Point(857, 396)
        Me.PictureBoxInfo.Name = "PictureBoxInfo"
        Me.PictureBoxInfo.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxInfo.TabIndex = 339
        Me.PictureBoxInfo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxInfo, "Patient has UnBilled Procedures or Unpaid Bills")
        Me.PictureBoxInfo.Visible = False
        '
        'frmAddPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(881, 566)
        Me.Controls.Add(Me.PictureBoxInfo)
        Me.Controls.Add(Me.cmdUnlockPostedDate)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.txtCheckNumber)
        Me.Controls.Add(Me.cboPart)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBoxCloseProfile)
        Me.Controls.Add(Me.chkNoMoreCollection)
        Me.Controls.Add(Me.ListViewBills)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPaid)
        Me.Controls.Add(Me.cboNotes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRemaining)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBillAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmAddPayment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Billing"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBoxInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBillAmount As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRemaining As System.Windows.Forms.TextBox
    Friend WithEvents cboNotes As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPaid As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents PaymentDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents PaymentType As System.Windows.Forms.ColumnHeader
    Friend WithEvents Amount As System.Windows.Forms.ColumnHeader
    Friend WithEvents CheckNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents Notes As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkNoMoreCollection As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ListViewBills As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCloseProfile As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxAudio As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboPart As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents chkScanCheck As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents cmdUnlockPostedDate As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBoxInfo As PictureBox
End Class
