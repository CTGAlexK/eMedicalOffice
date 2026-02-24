<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmailerMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmailerMaintenance))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CheckBoxActiveInd = New System.Windows.Forms.CheckBox()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.txtContactName = New System.Windows.Forms.TextBox()
        Me.txtEmailAddress1 = New System.Windows.Forms.TextBox()
        Me.txtTemplateName = New System.Windows.Forms.TextBox()
        Me.txtAttachement = New System.Windows.Forms.TextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.txtCompanyNameSearch = New System.Windows.Forms.TextBox()
        Me.txtTemplateNameSearch = New System.Windows.Forms.TextBox()
        Me.txtCompanyNameLogSearch = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.ComboBoxState = New System.Windows.Forms.ComboBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.MaskedTextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ListViewEmailLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdDelete1 = New System.Windows.Forms.Button()
        Me.cmdCancel1 = New System.Windows.Forms.Button()
        Me.cmdUpdate1 = New System.Windows.Forms.Button()
        Me.cmdEdit1 = New System.Windows.Forms.Button()
        Me.cmdAddNew1 = New System.Windows.Forms.Button()
        Me.ListViewAddresses = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ButtonRemoveAttachement = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdSelectAttachment = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.txtBody = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ListViewTempLates = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.lblCountLog = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListViewLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.FD = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PageRed.png")
        Me.ImageList1.Images.SetKeyName(1, "Page.png")
        Me.ImageList1.Images.SetKeyName(2, "PageBlueSys.png")
        Me.ImageList1.Images.SetKeyName(3, "Complete16White.png")
        Me.ImageList1.Images.SetKeyName(4, "Complete16.png")
        Me.ImageList1.Images.SetKeyName(5, "exclamation.png")
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(978, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'CheckBoxActiveInd
        '
        Me.CheckBoxActiveInd.AutoSize = True
        Me.CheckBoxActiveInd.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxActiveInd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxActiveInd.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxActiveInd, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxActiveInd.Location = New System.Drawing.Point(668, 3)
        Me.CheckBoxActiveInd.Name = "CheckBoxActiveInd"
        Me.CheckBoxActiveInd.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActiveInd.TabIndex = 2
        Me.CheckBoxActiveInd.Text = "Active"
        Me.ToolTip1.SetToolTip(Me.CheckBoxActiveInd, "Document Active Indicator")
        Me.CheckBoxActiveInd.UseVisualStyleBackColor = False
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCompanyName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCompanyName.Location = New System.Drawing.Point(229, 24)
        Me.txtCompanyName.MaxLength = 250
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(495, 20)
        Me.txtCompanyName.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtCompanyName, "Document Name")
        '
        'txtContactName
        '
        Me.txtContactName.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtContactName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtContactName.Location = New System.Drawing.Point(229, 141)
        Me.txtContactName.MaxLength = 250
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(495, 20)
        Me.txtContactName.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtContactName, "Document Name")
        '
        'txtEmailAddress1
        '
        Me.txtEmailAddress1.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtEmailAddress1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtEmailAddress1.Location = New System.Drawing.Point(229, 180)
        Me.txtEmailAddress1.MaxLength = 250
        Me.txtEmailAddress1.Name = "txtEmailAddress1"
        Me.txtEmailAddress1.Size = New System.Drawing.Size(495, 20)
        Me.txtEmailAddress1.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtEmailAddress1, "Document Name")
        '
        'txtTemplateName
        '
        Me.txtTemplateName.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtTemplateName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtTemplateName.Location = New System.Drawing.Point(229, 24)
        Me.txtTemplateName.MaxLength = 250
        Me.txtTemplateName.Name = "txtTemplateName"
        Me.txtTemplateName.Size = New System.Drawing.Size(564, 20)
        Me.txtTemplateName.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtTemplateName, "Document Name")
        '
        'txtAttachement
        '
        Me.ErrorProvider1.SetIconAlignment(Me.txtAttachement, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtAttachement.Location = New System.Drawing.Point(229, 368)
        Me.txtAttachement.MaxLength = 250
        Me.txtAttachement.Name = "txtAttachement"
        Me.txtAttachement.ReadOnly = True
        Me.txtAttachement.Size = New System.Drawing.Size(677, 20)
        Me.txtAttachement.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtAttachement, "Document Name")
        '
        'txtSubject
        '
        Me.txtSubject.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtSubject, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtSubject.Location = New System.Drawing.Point(229, 63)
        Me.txtSubject.MaxLength = 250
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(564, 20)
        Me.txtSubject.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtSubject, "Document Name")
        '
        'txtCompanyNameSearch
        '
        Me.ErrorProvider1.SetIconAlignment(Me.txtCompanyNameSearch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCompanyNameSearch.Location = New System.Drawing.Point(3, 24)
        Me.txtCompanyNameSearch.MaxLength = 250
        Me.txtCompanyNameSearch.Name = "txtCompanyNameSearch"
        Me.txtCompanyNameSearch.Size = New System.Drawing.Size(119, 20)
        Me.txtCompanyNameSearch.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtCompanyNameSearch, "Document Name")
        '
        'txtTemplateNameSearch
        '
        Me.ErrorProvider1.SetIconAlignment(Me.txtTemplateNameSearch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtTemplateNameSearch.Location = New System.Drawing.Point(3, 23)
        Me.txtTemplateNameSearch.MaxLength = 250
        Me.txtTemplateNameSearch.Name = "txtTemplateNameSearch"
        Me.txtTemplateNameSearch.Size = New System.Drawing.Size(220, 20)
        Me.txtTemplateNameSearch.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtTemplateNameSearch, "Document Name")
        '
        'txtCompanyNameLogSearch
        '
        Me.ErrorProvider1.SetIconAlignment(Me.txtCompanyNameLogSearch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCompanyNameLogSearch.Location = New System.Drawing.Point(6, 26)
        Me.txtCompanyNameLogSearch.MaxLength = 250
        Me.txtCompanyNameLogSearch.Name = "txtCompanyNameLogSearch"
        Me.txtCompanyNameLogSearch.Size = New System.Drawing.Size(165, 20)
        Me.txtCompanyNameLogSearch.TabIndex = 138
        Me.ToolTip1.SetToolTip(Me.txtCompanyNameLogSearch, "Document Name")
        '
        'txtAddress1
        '
        Me.txtAddress1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAddress1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAddress1.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtAddress1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtAddress1.Location = New System.Drawing.Point(229, 64)
        Me.txtAddress1.MaxLength = 150
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(237, 20)
        Me.txtAddress1.TabIndex = 138
        Me.ToolTip1.SetToolTip(Me.txtAddress1, "Office Address 1")
        '
        'ComboBoxState
        '
        Me.ComboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxState.Enabled = False
        Me.ComboBoxState.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxState.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxState, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxState.Location = New System.Drawing.Point(472, 103)
        Me.ComboBoxState.Name = "ComboBoxState"
        Me.ComboBoxState.Size = New System.Drawing.Size(76, 21)
        Me.ComboBoxState.TabIndex = 141
        Me.ToolTip1.SetToolTip(Me.ComboBoxState, "Office Address State")
        '
        'txtAddress2
        '
        Me.txtAddress2.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtAddress2, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtAddress2.Location = New System.Drawing.Point(472, 64)
        Me.txtAddress2.MaxLength = 150
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(252, 20)
        Me.txtAddress2.TabIndex = 139
        Me.ToolTip1.SetToolTip(Me.txtAddress2, "Office Address 2")
        '
        'txtZip
        '
        Me.txtZip.Enabled = False
        Me.txtZip.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconAlignment(Me.txtZip, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtZip.Location = New System.Drawing.Point(626, 103)
        Me.txtZip.Mask = "00000"
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(98, 20)
        Me.txtZip.TabIndex = 142
        Me.txtZip.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtZip, "Office Address Zip Code")
        '
        'txtCity
        '
        Me.txtCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCity.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCity, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCity.Location = New System.Drawing.Point(229, 102)
        Me.txtCity.MaxLength = 50
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(237, 20)
        Me.txtCity.TabIndex = 140
        Me.ToolTip1.SetToolTip(Me.txtCity, "Office Address City")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 467)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1016, 34)
        Me.Panel2.TabIndex = 99
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(929, 6)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        Me.ToolTip1.ShowAlways = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(5, 14)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1011, 450)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtAddress1)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.ComboBoxState)
        Me.TabPage2.Controls.Add(Me.txtAddress2)
        Me.TabPage2.Controls.Add(Me.txtZip)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtCity)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.ListViewEmailLog)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtCompanyNameSearch)
        Me.TabPage2.Controls.Add(Me.cmdDelete1)
        Me.TabPage2.Controls.Add(Me.cmdCancel1)
        Me.TabPage2.Controls.Add(Me.cmdUpdate1)
        Me.TabPage2.Controls.Add(Me.cmdEdit1)
        Me.TabPage2.Controls.Add(Me.cmdAddNew1)
        Me.TabPage2.Controls.Add(Me.ListViewAddresses)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.txtEmailAddress1)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.txtContactName)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtCompanyName)
        Me.TabPage2.Controls.Add(Me.CheckBoxActiveInd)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1003, 424)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Address Book"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(229, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 143
        Me.Label8.Text = "Address 1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(469, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 144
        Me.Label9.Text = "Address 2"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(229, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 13)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "City"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(623, 87)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 146
        Me.Label19.Text = "Zip Code"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(469, 87)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(32, 13)
        Me.Label20.TabIndex = 147
        Me.Label20.Text = "State"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(226, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Email Log"
        '
        'ListViewEmailLog
        '
        Me.ListViewEmailLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.ListViewEmailLog.FullRowSelect = True
        Me.ListViewEmailLog.GridLines = True
        Me.ListViewEmailLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewEmailLog.HideSelection = False
        Me.ListViewEmailLog.LargeImageList = Me.ImageList1
        Me.ListViewEmailLog.Location = New System.Drawing.Point(229, 219)
        Me.ListViewEmailLog.MultiSelect = False
        Me.ListViewEmailLog.Name = "ListViewEmailLog"
        Me.ListViewEmailLog.Size = New System.Drawing.Size(766, 169)
        Me.ListViewEmailLog.SmallImageList = Me.ImageList1
        Me.ListViewEmailLog.TabIndex = 136
        Me.ListViewEmailLog.UseCompatibleStateImageBehavior = False
        Me.ListViewEmailLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date"
        Me.ColumnHeader3.Width = 194
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Type"
        Me.ColumnHeader4.Width = 138
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Status"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Comments"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 13)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Search Company Name"
        '
        'cmdDelete1
        '
        Me.cmdDelete1.Enabled = False
        Me.cmdDelete1.Location = New System.Drawing.Point(553, 394)
        Me.cmdDelete1.Name = "cmdDelete1"
        Me.cmdDelete1.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete1.TabIndex = 10
        Me.cmdDelete1.Text = "Delete"
        Me.cmdDelete1.UseVisualStyleBackColor = True
        '
        'cmdCancel1
        '
        Me.cmdCancel1.Enabled = False
        Me.cmdCancel1.Location = New System.Drawing.Point(472, 394)
        Me.cmdCancel1.Name = "cmdCancel1"
        Me.cmdCancel1.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel1.TabIndex = 9
        Me.cmdCancel1.Text = "Cancel"
        Me.cmdCancel1.UseVisualStyleBackColor = True
        '
        'cmdUpdate1
        '
        Me.cmdUpdate1.Enabled = False
        Me.cmdUpdate1.Location = New System.Drawing.Point(391, 394)
        Me.cmdUpdate1.Name = "cmdUpdate1"
        Me.cmdUpdate1.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate1.TabIndex = 8
        Me.cmdUpdate1.Text = "Update"
        Me.cmdUpdate1.UseVisualStyleBackColor = True
        '
        'cmdEdit1
        '
        Me.cmdEdit1.Enabled = False
        Me.cmdEdit1.Location = New System.Drawing.Point(310, 394)
        Me.cmdEdit1.Name = "cmdEdit1"
        Me.cmdEdit1.Size = New System.Drawing.Size(75, 23)
        Me.cmdEdit1.TabIndex = 7
        Me.cmdEdit1.Text = "Edit"
        Me.cmdEdit1.UseVisualStyleBackColor = True
        '
        'cmdAddNew1
        '
        Me.cmdAddNew1.Location = New System.Drawing.Point(229, 394)
        Me.cmdAddNew1.Name = "cmdAddNew1"
        Me.cmdAddNew1.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddNew1.TabIndex = 6
        Me.cmdAddNew1.Text = "Add New"
        Me.cmdAddNew1.UseVisualStyleBackColor = True
        '
        'ListViewAddresses
        '
        Me.ListViewAddresses.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListViewAddresses.FullRowSelect = True
        Me.ListViewAddresses.GridLines = True
        Me.ListViewAddresses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewAddresses.HideSelection = False
        Me.ListViewAddresses.LargeImageList = Me.ImageList1
        Me.ListViewAddresses.Location = New System.Drawing.Point(3, 50)
        Me.ListViewAddresses.MultiSelect = False
        Me.ListViewAddresses.Name = "ListViewAddresses"
        Me.ListViewAddresses.Size = New System.Drawing.Size(220, 367)
        Me.ListViewAddresses.SmallImageList = Me.ImageList1
        Me.ListViewAddresses.TabIndex = 1
        Me.ListViewAddresses.UseCompatibleStateImageBehavior = False
        Me.ListViewAddresses.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 194
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(226, 164)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 121
        Me.Label12.Text = "Email Address 1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(229, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 119
        Me.Label11.Text = "Contact Name"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(229, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "Company Name"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ToolStrip2)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.txtTemplateNameSearch)
        Me.TabPage3.Controls.Add(Me.cmdDelete)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.cmdCancel)
        Me.TabPage3.Controls.Add(Me.cboPriority)
        Me.TabPage3.Controls.Add(Me.cmdUpdate)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.cmdEdit)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.cmdAddNew)
        Me.TabPage3.Controls.Add(Me.ComboBox1)
        Me.TabPage3.Controls.Add(Me.txtBody)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.txtSubject)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.txtAttachement)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.txtTemplateName)
        Me.TabPage3.Controls.Add(Me.ListViewTempLates)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1003, 424)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Templates"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonRemoveAttachement, Me.ToolStripSeparator3, Me.cmdSelectAttachment})
        Me.ToolStrip2.Location = New System.Drawing.Point(909, 363)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(55, 25)
        Me.ToolStrip2.TabIndex = 168
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ButtonRemoveAttachement
        '
        Me.ButtonRemoveAttachement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonRemoveAttachement.Enabled = False
        Me.ButtonRemoveAttachement.Image = CType(resources.GetObject("ButtonRemoveAttachement.Image"), System.Drawing.Image)
        Me.ButtonRemoveAttachement.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonRemoveAttachement.Name = "ButtonRemoveAttachement"
        Me.ButtonRemoveAttachement.Size = New System.Drawing.Size(23, 22)
        Me.ButtonRemoveAttachement.Text = "ToolStripButton1"
        Me.ButtonRemoveAttachement.ToolTipText = "Update Template With Current Changes"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'cmdSelectAttachment
        '
        Me.cmdSelectAttachment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSelectAttachment.Enabled = False
        Me.cmdSelectAttachment.Image = CType(resources.GetObject("cmdSelectAttachment.Image"), System.Drawing.Image)
        Me.cmdSelectAttachment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSelectAttachment.Name = "cmdSelectAttachment"
        Me.cmdSelectAttachment.Size = New System.Drawing.Size(23, 22)
        Me.cmdSelectAttachment.Text = "ToolStripButton2"
        Me.cmdSelectAttachment.ToolTipText = "Open Emailer Maintenance"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 13)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "Search Template Name"
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Location = New System.Drawing.Point(553, 394)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 12
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(796, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Priority"
        '
        'cmdCancel
        '
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Location = New System.Drawing.Point(472, 394)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboPriority
        '
        Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriority.Enabled = False
        Me.cboPriority.FormattingEnabled = True
        Me.cboPriority.Location = New System.Drawing.Point(799, 23)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(196, 21)
        Me.cboPriority.TabIndex = 3
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Location = New System.Drawing.Point(391, 394)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 10
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(799, 47)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 13)
        Me.Label18.TabIndex = 129
        Me.Label18.Text = "Script Commands"
        '
        'cmdEdit
        '
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Location = New System.Drawing.Point(310, 394)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.cmdEdit.TabIndex = 9
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(226, 86)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 128
        Me.Label17.Text = "Body"
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(229, 394)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddNew.TabIndex = 8
        Me.cmdAddNew.Text = "Add New"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(799, 62)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(196, 21)
        Me.ComboBox1.TabIndex = 127
        Me.ComboBox1.TabStop = False
        '
        'txtBody
        '
        Me.txtBody.Location = New System.Drawing.Point(229, 102)
        Me.txtBody.MaxLength = 4000
        Me.txtBody.Multiline = True
        Me.txtBody.Name = "txtBody"
        Me.txtBody.ReadOnly = True
        Me.txtBody.Size = New System.Drawing.Size(766, 247)
        Me.txtBody.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(229, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 124
        Me.Label16.Text = "Subject"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(226, 352)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 121
        Me.Label15.Text = "Attachment"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(229, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 13)
        Me.Label14.TabIndex = 119
        Me.Label14.Text = "Template Name"
        '
        'ListViewTempLates
        '
        Me.ListViewTempLates.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.ListViewTempLates.FullRowSelect = True
        Me.ListViewTempLates.GridLines = True
        Me.ListViewTempLates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewTempLates.HideSelection = False
        Me.ListViewTempLates.LargeImageList = Me.ImageList1
        Me.ListViewTempLates.Location = New System.Drawing.Point(3, 47)
        Me.ListViewTempLates.MultiSelect = False
        Me.ListViewTempLates.Name = "ListViewTempLates"
        Me.ListViewTempLates.Size = New System.Drawing.Size(220, 370)
        Me.ListViewTempLates.SmallImageList = Me.ImageList1
        Me.ListViewTempLates.TabIndex = 1
        Me.ListViewTempLates.UseCompatibleStateImageBehavior = False
        Me.ListViewTempLates.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 194
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.cboType)
        Me.TabPage1.Controls.Add(Me.lblCountLog)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.cboStatus)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtCompanyNameLogSearch)
        Me.TabPage1.Controls.Add(Me.ListViewLog)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1003, 424)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Emailer Log"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(174, 10)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 13)
        Me.Label21.TabIndex = 144
        Me.Label21.Text = "Type"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(177, 26)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(124, 21)
        Me.cboType.TabIndex = 143
        '
        'lblCountLog
        '
        Me.lblCountLog.Location = New System.Drawing.Point(789, 28)
        Me.lblCountLog.Name = "lblCountLog"
        Me.lblCountLog.Size = New System.Drawing.Size(189, 13)
        Me.lblCountLog.TabIndex = 142
        Me.lblCountLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(304, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 141
        Me.Label7.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(307, 25)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(124, 21)
        Me.cboStatus.TabIndex = 140
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "Company Name"
        '
        'ListViewLog
        '
        Me.ListViewLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader7, Me.ColumnHeader9})
        Me.ListViewLog.FullRowSelect = True
        Me.ListViewLog.GridLines = True
        Me.ListViewLog.HideSelection = False
        Me.ListViewLog.LargeImageList = Me.ImageList2
        Me.ListViewLog.Location = New System.Drawing.Point(6, 52)
        Me.ListViewLog.MultiSelect = False
        Me.ListViewLog.Name = "ListViewLog"
        Me.ListViewLog.Size = New System.Drawing.Size(991, 364)
        Me.ListViewLog.SmallImageList = Me.ImageList2
        Me.ListViewLog.TabIndex = 137
        Me.ListViewLog.UseCompatibleStateImageBehavior = False
        Me.ListViewLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Company"
        Me.ColumnHeader5.Width = 194
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Date"
        Me.ColumnHeader6.Width = 138
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Type"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Status"
        Me.ColumnHeader7.Width = 169
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Comments"
        Me.ColumnHeader9.Width = 152
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "SORT1")
        Me.ImageList2.Images.SetKeyName(1, "SORT2")
        Me.ImageList2.Images.SetKeyName(2, "SORT0")
        Me.ImageList2.Images.SetKeyName(3, "Complete16White.png")
        Me.ImageList2.Images.SetKeyName(4, "Complete16.png")
        Me.ImageList2.Images.SetKeyName(5, "exclamation.png")
        '
        'FD
        '
        Me.FD.Filter = "All Files (*.*)|*.*"
        Me.FD.Title = "Select Template Attachement"
        '
        'frmEmailerMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(1016, 501)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmailerMaintenance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bulk Emailer Maintenance"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CheckBoxActiveInd As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtContactName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ListViewTempLates As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTemplateName As System.Windows.Forms.TextBox
    Friend WithEvents ListViewAddresses As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAttachement As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtBody As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents cmdCancel1 As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate1 As System.Windows.Forms.Button
    Friend WithEvents cmdEdit1 As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew1 As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents FD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdDelete1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTemplateNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ListViewEmailLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonRemoveAttachement As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSelectAttachment As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ListViewLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyNameLogSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents lblCountLog As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxState As System.Windows.Forms.ComboBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
End Class
