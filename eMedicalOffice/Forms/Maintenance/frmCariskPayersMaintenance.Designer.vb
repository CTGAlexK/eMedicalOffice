<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCariskPayersMaintenance
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCariskPayersMaintenance))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtPayerId = New System.Windows.Forms.TextBox()
        Me.txtPayerName = New System.Windows.Forms.TextBox()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.txtStates = New System.Windows.Forms.TextBox()
        Me.txtSearchInsurances = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMultipleOffices = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblCheckedCount = New System.Windows.Forms.Label()
        Me.TabControlInsurances = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chk835EOB = New System.Windows.Forms.CheckBox()
        Me.chkAutomotive = New System.Windows.Forms.CheckBox()
        Me.chkWorkComp = New System.Windows.Forms.CheckBox()
        Me.chkPharmacyRx = New System.Windows.Forms.CheckBox()
        Me.chkInstitutional = New System.Windows.Forms.CheckBox()
        Me.chkProfessional = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelMsg = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TimerCheckedCount = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControlInsurances.SuspendLayout()
        Me.PanelMsg.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(3, 75)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(450, 312)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 425
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PageRed.png")
        Me.ImageList1.Images.SetKeyName(1, "Page.png")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtPayerId
        '
        Me.txtPayerId.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtPayerId, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtPayerId.Location = New System.Drawing.Point(9, 28)
        Me.txtPayerId.MaxLength = 25
        Me.txtPayerId.Name = "txtPayerId"
        Me.txtPayerId.Size = New System.Drawing.Size(103, 20)
        Me.txtPayerId.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtPayerId, "Injury Type Name")
        '
        'txtPayerName
        '
        Me.txtPayerName.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtPayerName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtPayerName.Location = New System.Drawing.Point(122, 28)
        Me.txtPayerName.MaxLength = 255
        Me.txtPayerName.Name = "txtPayerName"
        Me.txtPayerName.Size = New System.Drawing.Size(232, 20)
        Me.txtPayerName.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtPayerName, "Injury Type Description")
        '
        'TextBoxSearch
        '
        Me.ErrorProvider1.SetIconAlignment(Me.TextBoxSearch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.TextBoxSearch.Location = New System.Drawing.Point(3, 52)
        Me.TextBoxSearch.MaxLength = 50
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(165, 20)
        Me.TextBoxSearch.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.TextBoxSearch, "Procedure Name")
        '
        'txtStates
        '
        Me.txtStates.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtStates, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtStates.Location = New System.Drawing.Point(9, 67)
        Me.txtStates.MaxLength = 255
        Me.txtStates.Name = "txtStates"
        Me.txtStates.Size = New System.Drawing.Size(345, 20)
        Me.txtStates.TabIndex = 122
        Me.ToolTip1.SetToolTip(Me.txtStates, "Injury Type Description")
        '
        'txtSearchInsurances
        '
        Me.ErrorProvider1.SetIconAlignment(Me.txtSearchInsurances, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtSearchInsurances.Location = New System.Drawing.Point(10, 163)
        Me.txtSearchInsurances.MaxLength = 50
        Me.txtSearchInsurances.Name = "txtSearchInsurances"
        Me.txtSearchInsurances.Size = New System.Drawing.Size(165, 20)
        Me.txtSearchInsurances.TabIndex = 158
        Me.ToolTip1.SetToolTip(Me.txtSearchInsurances, "Procedure Name")
        Me.txtSearchInsurances.Visible = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        Me.ToolTip1.ShowAlways = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Payer Id"
        Me.ToolTip1.SetToolTip(Me.Label2, "Injury Type Name")
        '
        'lblMultipleOffices
        '
        Me.lblMultipleOffices.BackColor = System.Drawing.Color.Transparent
        Me.lblMultipleOffices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblMultipleOffices.ForeColor = System.Drawing.Color.White
        Me.lblMultipleOffices.Location = New System.Drawing.Point(469, 12)
        Me.lblMultipleOffices.Name = "lblMultipleOffices"
        Me.lblMultipleOffices.Size = New System.Drawing.Size(325, 13)
        Me.lblMultipleOffices.TabIndex = 160
        Me.lblMultipleOffices.Text = "Update All Offices"
        Me.lblMultipleOffices.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblMultipleOffices, "Injury Type Name")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(119, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Payer Name"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.cmdLoad)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtPassword)
        Me.Panel2.Controls.Add(Me.txtUserName)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Controls.Add(Me.cmdEdit)
        Me.Panel2.Controls.Add(Me.cmdAddNew)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 392)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(926, 34)
        Me.Panel2.TabIndex = 99
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(-10, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(28, 27)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 193
        Me.PictureBox2.TabStop = False
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(457, 6)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(67, 23)
        Me.cmdLoad.TabIndex = 192
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(222, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 191
        Me.Label9.Text = "Password"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(41, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 190
        Me.Label10.Text = "Supervisor UID"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(276, 8)
        Me.txtPassword.MaxLength = 10
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(94, 20)
        Me.txtPassword.TabIndex = 189
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(126, 8)
        Me.txtUserName.MaxLength = 10
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(94, 20)
        Me.txtUserName.TabIndex = 188
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(849, 6)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(67, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Location = New System.Drawing.Point(732, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(67, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Location = New System.Drawing.Point(664, 6)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(67, 23)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Location = New System.Drawing.Point(596, 6)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(67, 23)
        Me.cmdEdit.TabIndex = 2
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(528, 6)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(67, 23)
        Me.cmdAddNew.TabIndex = 1
        Me.cmdAddNew.Text = "Add New"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(2, 36)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(27, 13)
        Me.Label25.TabIndex = 157
        Me.Label25.Text = "Find"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(455, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(471, 349)
        Me.TabControl1.TabIndex = 158
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblCheckedCount)
        Me.TabPage1.Controls.Add(Me.txtSearchInsurances)
        Me.TabPage1.Controls.Add(Me.TabControlInsurances)
        Me.TabPage1.Controls.Add(Me.chk835EOB)
        Me.TabPage1.Controls.Add(Me.chkAutomotive)
        Me.TabPage1.Controls.Add(Me.chkWorkComp)
        Me.TabPage1.Controls.Add(Me.chkPharmacyRx)
        Me.TabPage1.Controls.Add(Me.chkInstitutional)
        Me.TabPage1.Controls.Add(Me.chkProfessional)
        Me.TabPage1.Controls.Add(Me.txtStates)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtPayerId)
        Me.TabPage1.Controls.Add(Me.txtPayerName)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.PanelMsg)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(463, 323)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblCheckedCount
        '
        Me.lblCheckedCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCheckedCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCheckedCount.Location = New System.Drawing.Point(285, 165)
        Me.lblCheckedCount.Name = "lblCheckedCount"
        Me.lblCheckedCount.Size = New System.Drawing.Size(173, 17)
        Me.lblCheckedCount.TabIndex = 160
        Me.lblCheckedCount.Text = "Selected"
        Me.lblCheckedCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCheckedCount.Visible = False
        '
        'TabControlInsurances
        '
        Me.TabControlInsurances.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControlInsurances.Controls.Add(Me.TabPage2)
        Me.TabControlInsurances.Location = New System.Drawing.Point(6, 189)
        Me.TabControlInsurances.Name = "TabControlInsurances"
        Me.TabControlInsurances.SelectedIndex = 0
        Me.TabControlInsurances.Size = New System.Drawing.Size(466, 131)
        Me.TabControlInsurances.TabIndex = 131
        Me.TabControlInsurances.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(458, 105)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chk835EOB
        '
        Me.chk835EOB.AutoSize = True
        Me.chk835EOB.Location = New System.Drawing.Point(275, 93)
        Me.chk835EOB.Name = "chk835EOB"
        Me.chk835EOB.Size = New System.Drawing.Size(71, 17)
        Me.chk835EOB.TabIndex = 129
        Me.chk835EOB.Text = "835/EOB"
        Me.chk835EOB.UseVisualStyleBackColor = True
        '
        'chkAutomotive
        '
        Me.chkAutomotive.AutoSize = True
        Me.chkAutomotive.Location = New System.Drawing.Point(275, 116)
        Me.chkAutomotive.Name = "chkAutomotive"
        Me.chkAutomotive.Size = New System.Drawing.Size(79, 17)
        Me.chkAutomotive.TabIndex = 128
        Me.chkAutomotive.Text = "Automotive"
        Me.chkAutomotive.UseVisualStyleBackColor = True
        '
        'chkWorkComp
        '
        Me.chkWorkComp.AutoSize = True
        Me.chkWorkComp.Location = New System.Drawing.Point(147, 90)
        Me.chkWorkComp.Name = "chkWorkComp"
        Me.chkWorkComp.Size = New System.Drawing.Size(79, 17)
        Me.chkWorkComp.TabIndex = 127
        Me.chkWorkComp.Text = "WorkComp"
        Me.chkWorkComp.UseVisualStyleBackColor = True
        '
        'chkPharmacyRx
        '
        Me.chkPharmacyRx.AutoSize = True
        Me.chkPharmacyRx.Location = New System.Drawing.Point(147, 113)
        Me.chkPharmacyRx.Name = "chkPharmacyRx"
        Me.chkPharmacyRx.Size = New System.Drawing.Size(86, 17)
        Me.chkPharmacyRx.TabIndex = 126
        Me.chkPharmacyRx.Text = "PharmacyRx"
        Me.chkPharmacyRx.UseVisualStyleBackColor = True
        '
        'chkInstitutional
        '
        Me.chkInstitutional.AutoSize = True
        Me.chkInstitutional.Location = New System.Drawing.Point(9, 113)
        Me.chkInstitutional.Name = "chkInstitutional"
        Me.chkInstitutional.Size = New System.Drawing.Size(79, 17)
        Me.chkInstitutional.TabIndex = 125
        Me.chkInstitutional.Text = "Institutional"
        Me.chkInstitutional.UseVisualStyleBackColor = True
        '
        'chkProfessional
        '
        Me.chkProfessional.AutoSize = True
        Me.chkProfessional.Location = New System.Drawing.Point(9, 90)
        Me.chkProfessional.Name = "chkProfessional"
        Me.chkProfessional.Size = New System.Drawing.Size(83, 17)
        Me.chkProfessional.TabIndex = 124
        Me.chkProfessional.Text = "Professional"
        Me.chkProfessional.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 13)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "States  ( Leave empty for All States )"
        '
        'PanelMsg
        '
        Me.PanelMsg.BackColor = System.Drawing.Color.Maroon
        Me.PanelMsg.Controls.Add(Me.Label3)
        Me.PanelMsg.Location = New System.Drawing.Point(10, 139)
        Me.PanelMsg.Name = "PanelMsg"
        Me.PanelMsg.Size = New System.Drawing.Size(459, 18)
        Me.PanelMsg.TabIndex = 161
        Me.PanelMsg.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(28, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(411, 15)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "To setup e-Filing to automated mode, assign payer to an insurance company"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Controls.Add(Me.lblMultipleOffices)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(926, 34)
        Me.Panel1.TabIndex = 159
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(888, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(382, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "ADMINISTRATIVE FUNCTION - CARISK PAYERS MAINTENANCE"
        '
        'TimerCheckedCount
        '
        '
        'frmCariskPayersMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(926, 426)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TextBoxSearch)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCariskPayersMaintenance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carisk Payers Maintenance"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControlInsurances.ResumeLayout(False)
        Me.PanelMsg.ResumeLayout(False)
        Me.PanelMsg.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPayerId As System.Windows.Forms.TextBox
    Friend WithEvents txtPayerName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chk835EOB As CheckBox
    Friend WithEvents chkAutomotive As CheckBox
    Friend WithEvents chkWorkComp As CheckBox
    Friend WithEvents chkPharmacyRx As CheckBox
    Friend WithEvents chkInstitutional As CheckBox
    Friend WithEvents chkProfessional As CheckBox
    Friend WithEvents txtStates As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMultipleOffices As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdLoad As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TabControlInsurances As TabControl
    Friend WithEvents txtSearchInsurances As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lblCheckedCount As Label
    Friend WithEvents TimerCheckedCount As Timer
    Friend WithEvents PanelMsg As Panel
    Friend WithEvents Label3 As Label
End Class
