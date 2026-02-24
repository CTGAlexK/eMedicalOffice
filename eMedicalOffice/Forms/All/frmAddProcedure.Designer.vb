<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddProcedure
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddProcedure))
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.ComboBoxDiagIDSearch = New System.Windows.Forms.ComboBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.ListViewProcedures = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ComboBoxTreatingProviderID = New System.Windows.Forms.ComboBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.ComboBoxReferringDoctor = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBoxBillingProvider = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePickerProcDate = New System.Windows.Forms.DateTimePicker()
        Me.LabelProcDate = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PanelPreCertification = New System.Windows.Forms.Panel()
        Me.CheckBoxPreCertification = New System.Windows.Forms.CheckBox()
        Me.LabelCaseType = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.PanelPreCertification.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Location = New System.Drawing.Point(390, 21)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(158, 20)
        Me.TextBoxSearch.TabIndex = 1
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.BackColor = System.Drawing.Color.Transparent
        Me.Label83.ForeColor = System.Drawing.Color.Transparent
        Me.Label83.Location = New System.Drawing.Point(387, 8)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(90, 13)
        Me.Label83.TabIndex = 247
        Me.Label83.Text = "Procedure  Name"
        '
        'ComboBoxDiagIDSearch
        '
        Me.ComboBoxDiagIDSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDiagIDSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxDiagIDSearch.FormattingEnabled = True
        Me.ComboBoxDiagIDSearch.Location = New System.Drawing.Point(11, 21)
        Me.ComboBoxDiagIDSearch.Name = "ComboBoxDiagIDSearch"
        Me.ComboBoxDiagIDSearch.Size = New System.Drawing.Size(370, 21)
        Me.ComboBoxDiagIDSearch.TabIndex = 0
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.BackColor = System.Drawing.Color.Transparent
        Me.Label82.ForeColor = System.Drawing.Color.Transparent
        Me.Label82.Location = New System.Drawing.Point(11, 5)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(83, 13)
        Me.Label82.TabIndex = 246
        Me.Label82.Text = "Procedure Type"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.LabelCaseType)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(689, 31)
        Me.Panel1.TabIndex = 250
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(651, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add Procedures"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 481)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(689, 34)
        Me.Panel2.TabIndex = 251
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(575, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(106, 28)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "Close"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdd.Location = New System.Drawing.Point(10, 3)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(124, 28)
        Me.cmdAdd.TabIndex = 1
        Me.cmdAdd.Text = "Add Procedure"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'ListViewProcedures
        '
        Me.ListViewProcedures.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader1})
        Me.ListViewProcedures.FullRowSelect = True
        Me.ListViewProcedures.GridLines = True
        Me.ListViewProcedures.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewProcedures.HideSelection = False
        Me.ListViewProcedures.Location = New System.Drawing.Point(11, 213)
        Me.ListViewProcedures.MultiSelect = False
        Me.ListViewProcedures.Name = "ListViewProcedures"
        Me.ListViewProcedures.Size = New System.Drawing.Size(670, 236)
        Me.ListViewProcedures.TabIndex = 6
        Me.ListViewProcedures.UseCompatibleStateImageBehavior = False
        Me.ListViewProcedures.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Procedure Name"
        Me.ColumnHeader5.Width = 520
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Code"
        Me.ColumnHeader1.Width = 102
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(532, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 283
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "Search By Procedure Name")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        '
        'ComboBoxTreatingProviderID
        '
        Me.ComboBoxTreatingProviderID.AccessibleDescription = "1"
        Me.ComboBoxTreatingProviderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTreatingProviderID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxTreatingProviderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxTreatingProviderID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTreatingProviderID.FormattingEnabled = True
        Me.ComboBoxTreatingProviderID.Location = New System.Drawing.Point(11, 102)
        Me.ComboBoxTreatingProviderID.Name = "ComboBoxTreatingProviderID"
        Me.ComboBoxTreatingProviderID.Size = New System.Drawing.Size(670, 21)
        Me.ComboBoxTreatingProviderID.TabIndex = 4
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.Transparent
        Me.Label68.Location = New System.Drawing.Point(11, 88)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(88, 13)
        Me.Label68.TabIndex = 293
        Me.Label68.Text = "Treating Provider"
        '
        'ComboBoxReferringDoctor
        '
        Me.ComboBoxReferringDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxReferringDoctor.Enabled = False
        Me.ComboBoxReferringDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxReferringDoctor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxReferringDoctor.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxReferringDoctor.FormattingEnabled = True
        Me.ComboBoxReferringDoctor.Location = New System.Drawing.Point(11, 143)
        Me.ComboBoxReferringDoctor.Name = "ComboBoxReferringDoctor"
        Me.ComboBoxReferringDoctor.Size = New System.Drawing.Size(670, 21)
        Me.ComboBoxReferringDoctor.Sorted = True
        Me.ComboBoxReferringDoctor.TabIndex = 5
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.Transparent
        Me.Label63.Location = New System.Drawing.Point(11, 129)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(85, 13)
        Me.Label63.TabIndex = 295
        Me.Label63.Text = "Referring Doctor"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(11, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 297
        Me.Label15.Text = "Billing Provider"
        '
        'ComboBoxBillingProvider
        '
        Me.ComboBoxBillingProvider.AccessibleDescription = "1"
        Me.ComboBoxBillingProvider.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxBillingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBillingProvider.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxBillingProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxBillingProvider.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxBillingProvider.FormattingEnabled = True
        Me.ComboBoxBillingProvider.Location = New System.Drawing.Point(11, 64)
        Me.ComboBoxBillingProvider.Name = "ComboBoxBillingProvider"
        Me.ComboBoxBillingProvider.Size = New System.Drawing.Size(670, 21)
        Me.ComboBoxBillingProvider.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(565, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 328
        Me.Label2.Text = "(Check Referral Color)"
        '
        'DateTimePickerProcDate
        '
        Me.DateTimePickerProcDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DateTimePickerProcDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerProcDate.Location = New System.Drawing.Point(557, 22)
        Me.DateTimePickerProcDate.Name = "DateTimePickerProcDate"
        Me.DateTimePickerProcDate.Size = New System.Drawing.Size(124, 20)
        Me.DateTimePickerProcDate.TabIndex = 2
        Me.DateTimePickerProcDate.Visible = False
        '
        'LabelProcDate
        '
        Me.LabelProcDate.AutoSize = True
        Me.LabelProcDate.BackColor = System.Drawing.Color.Transparent
        Me.LabelProcDate.ForeColor = System.Drawing.Color.Transparent
        Me.LabelProcDate.Location = New System.Drawing.Point(554, 8)
        Me.LabelProcDate.Name = "LabelProcDate"
        Me.LabelProcDate.Size = New System.Drawing.Size(85, 13)
        Me.LabelProcDate.TabIndex = 330
        Me.LabelProcDate.Text = "Procedure  Date"
        Me.LabelProcDate.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.LabelProcDate)
        Me.Panel3.Controls.Add(Me.DateTimePickerProcDate)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.ComboBoxBillingProvider)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.ComboBoxReferringDoctor)
        Me.Panel3.Controls.Add(Me.Label63)
        Me.Panel3.Controls.Add(Me.ComboBoxTreatingProviderID)
        Me.Panel3.Controls.Add(Me.Label68)
        Me.Panel3.Controls.Add(Me.PictureBox3)
        Me.Panel3.Controls.Add(Me.TextBoxSearch)
        Me.Panel3.Controls.Add(Me.Label83)
        Me.Panel3.Controls.Add(Me.ComboBoxDiagIDSearch)
        Me.Panel3.Controls.Add(Me.Label82)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(689, 175)
        Me.Panel3.TabIndex = 331
        '
        'PanelPreCertification
        '
        Me.PanelPreCertification.BackColor = System.Drawing.Color.Brown
        Me.PanelPreCertification.Controls.Add(Me.CheckBoxPreCertification)
        Me.PanelPreCertification.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelPreCertification.Location = New System.Drawing.Point(0, 455)
        Me.PanelPreCertification.Name = "PanelPreCertification"
        Me.PanelPreCertification.Size = New System.Drawing.Size(689, 26)
        Me.PanelPreCertification.TabIndex = 332
        '
        'CheckBoxPreCertification
        '
        Me.CheckBoxPreCertification.AutoSize = True
        Me.CheckBoxPreCertification.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxPreCertification.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CheckBoxPreCertification.ForeColor = System.Drawing.Color.White
        Me.CheckBoxPreCertification.Location = New System.Drawing.Point(17, 6)
        Me.CheckBoxPreCertification.Name = "CheckBoxPreCertification"
        Me.CheckBoxPreCertification.Size = New System.Drawing.Size(173, 17)
        Me.CheckBoxPreCertification.TabIndex = 0
        Me.CheckBoxPreCertification.Text = "Pre-Certification Complete"
        Me.CheckBoxPreCertification.UseVisualStyleBackColor = False
        '
        'LabelCaseType
        '
        Me.LabelCaseType.AutoSize = True
        Me.LabelCaseType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelCaseType.Location = New System.Drawing.Point(548, 9)
        Me.LabelCaseType.Name = "LabelCaseType"
        Me.LabelCaseType.Size = New System.Drawing.Size(97, 13)
        Me.LabelCaseType.TabIndex = 2
        Me.LabelCaseType.Text = "Add Procedures"
        '
        'frmAddProcedure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(689, 515)
        Me.Controls.Add(Me.PanelPreCertification)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ListViewProcedures)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAddProcedure"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Procedure"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PanelPreCertification.ResumeLayout(False)
        Me.PanelPreCertification.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDiagIDSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents ListViewProcedures As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ComboBoxTreatingProviderID As System.Windows.Forms.ComboBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxReferringDoctor As System.Windows.Forms.ComboBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxBillingProvider As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerProcDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelProcDate As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelPreCertification As System.Windows.Forms.Panel
    Friend WithEvents CheckBoxPreCertification As System.Windows.Forms.CheckBox
    Friend WithEvents LabelCaseType As Label
End Class
