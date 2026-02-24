<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiagnosticMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiagnosticMaintenance))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtDiagName = New System.Windows.Forms.TextBox()
        Me.txtDiagDescription = New System.Windows.Forms.TextBox()
        Me.CheckBoxActiveInd = New System.Windows.Forms.CheckBox()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.txtAbbreviation = New System.Windows.Forms.TextBox()
        Me.cboBillingProvider = New System.Windows.Forms.ComboBox()
        Me.cboTreatingProvider = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboInterval = New System.Windows.Forms.ComboBox()
        Me.buttonFormulaAdd = New System.Windows.Forms.Button()
        Me.buttonDeleteFormula = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ButtonProcessFormula = New System.Windows.Forms.Button()
        Me.buttonFormulaCancel = New System.Windows.Forms.Button()
        Me.buttonUpdateFormula = New System.Windows.Forms.Button()
        Me.PanelFormulaEdit = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboCaseTypes = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboInsuranceCompanyID = New System.Windows.Forms.ComboBox()
        Me.txtFormula = New System.Windows.Forms.TextBox()
        Me.NumericUpDownFixed = New System.Windows.Forms.NumericUpDown()
        Me.RadioButtonFixed = New System.Windows.Forms.RadioButton()
        Me.NumericUpDownPercent = New System.Windows.Forms.NumericUpDown()
        Me.RadioButtonPercent = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBoxAutoReasize = New System.Windows.Forms.PictureBox()
        Me.ButtonFilter = New System.Windows.Forms.Button()
        Me.buttonFormulaEdit = New System.Windows.Forms.Button()
        Me.cboOfficeType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ListViewFormulas = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripCustomizeToolStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CustomizeToolbarDeleteFormula = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelFormula = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboInsuranceCompanyIDSearch = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelFormulaEdit.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownFixed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxAutoReasize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ContextMenuStripCustomizeToolStrip.SuspendLayout()
        Me.PanelFormula.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(3, 42)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(228, 356)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 200
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(755, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtDiagName
        '
        Me.txtDiagName.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtDiagName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtDiagName.Location = New System.Drawing.Point(12, 79)
        Me.txtDiagName.MaxLength = 50
        Me.txtDiagName.Name = "txtDiagName"
        Me.txtDiagName.Size = New System.Drawing.Size(389, 20)
        Me.txtDiagName.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtDiagName, "Procedure Name")
        '
        'txtDiagDescription
        '
        Me.txtDiagDescription.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtDiagDescription, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtDiagDescription.Location = New System.Drawing.Point(12, 118)
        Me.txtDiagDescription.MaxLength = 255
        Me.txtDiagDescription.Name = "txtDiagDescription"
        Me.txtDiagDescription.Size = New System.Drawing.Size(389, 20)
        Me.txtDiagDescription.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtDiagDescription, "Procedure Description")
        '
        'CheckBoxActiveInd
        '
        Me.CheckBoxActiveInd.AutoSize = True
        Me.CheckBoxActiveInd.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxActiveInd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxActiveInd.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxActiveInd, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxActiveInd.Location = New System.Drawing.Point(468, 11)
        Me.CheckBoxActiveInd.Name = "CheckBoxActiveInd"
        Me.CheckBoxActiveInd.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActiveInd.TabIndex = 3
        Me.CheckBoxActiveInd.Text = "Active"
        Me.ToolTip1.SetToolTip(Me.CheckBoxActiveInd, "Procedure Active Indicator")
        Me.CheckBoxActiveInd.UseVisualStyleBackColor = False
        '
        'TextBoxSearch
        '
        Me.ErrorProvider1.SetIconAlignment(Me.TextBoxSearch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.TextBoxSearch.Location = New System.Drawing.Point(3, 16)
        Me.TextBoxSearch.MaxLength = 50
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(228, 20)
        Me.TextBoxSearch.TabIndex = 0
        '
        'txtAbbreviation
        '
        Me.txtAbbreviation.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtAbbreviation, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtAbbreviation.Location = New System.Drawing.Point(407, 79)
        Me.txtAbbreviation.MaxLength = 50
        Me.txtAbbreviation.Name = "txtAbbreviation"
        Me.txtAbbreviation.Size = New System.Drawing.Size(118, 20)
        Me.txtAbbreviation.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtAbbreviation, "Procedure Name")
        '
        'cboBillingProvider
        '
        Me.cboBillingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingProvider.Enabled = False
        Me.cboBillingProvider.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboBillingProvider.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.cboBillingProvider, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.cboBillingProvider.Location = New System.Drawing.Point(12, 157)
        Me.cboBillingProvider.Name = "cboBillingProvider"
        Me.cboBillingProvider.Size = New System.Drawing.Size(513, 21)
        Me.cboBillingProvider.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cboBillingProvider, "Select a Billing Provider for the PT Procedure")
        '
        'cboTreatingProvider
        '
        Me.cboTreatingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTreatingProvider.Enabled = False
        Me.cboTreatingProvider.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboTreatingProvider.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.cboTreatingProvider, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.cboTreatingProvider.Location = New System.Drawing.Point(12, 205)
        Me.cboTreatingProvider.Name = "cboTreatingProvider"
        Me.cboTreatingProvider.Size = New System.Drawing.Size(513, 21)
        Me.cboTreatingProvider.TabIndex = 167
        Me.ToolTip1.SetToolTip(Me.cboTreatingProvider, "Select a Billing Provider for the PT Procedure")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        Me.ToolTip1.ShowAlways = True
        '
        'cboInterval
        '
        Me.cboInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInterval.Enabled = False
        Me.cboInterval.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboInterval.FormattingEnabled = True
        Me.cboInterval.Location = New System.Drawing.Point(407, 117)
        Me.cboInterval.Name = "cboInterval"
        Me.cboInterval.Size = New System.Drawing.Size(118, 21)
        Me.cboInterval.TabIndex = 287
        Me.ToolTip1.SetToolTip(Me.cboInterval, "Minimum Interval Between Procedures Of This Type")
        '
        'buttonFormulaAdd
        '
        Me.buttonFormulaAdd.BackColor = System.Drawing.Color.Transparent
        Me.buttonFormulaAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttonFormulaAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.buttonFormulaAdd.FlatAppearance.BorderSize = 0
        Me.buttonFormulaAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.buttonFormulaAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.buttonFormulaAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonFormulaAdd.ForeColor = System.Drawing.Color.Black
        Me.buttonFormulaAdd.Image = CType(resources.GetObject("buttonFormulaAdd.Image"), System.Drawing.Image)
        Me.buttonFormulaAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonFormulaAdd.Location = New System.Drawing.Point(0, 0)
        Me.buttonFormulaAdd.Name = "buttonFormulaAdd"
        Me.buttonFormulaAdd.Size = New System.Drawing.Size(70, 23)
        Me.buttonFormulaAdd.TabIndex = 267
        Me.buttonFormulaAdd.Text = "Add   "
        Me.buttonFormulaAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.buttonFormulaAdd, "Add Agreement Formula")
        Me.buttonFormulaAdd.UseVisualStyleBackColor = False
        '
        'buttonDeleteFormula
        '
        Me.buttonDeleteFormula.BackColor = System.Drawing.Color.Transparent
        Me.buttonDeleteFormula.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttonDeleteFormula.Dock = System.Windows.Forms.DockStyle.Left
        Me.buttonDeleteFormula.FlatAppearance.BorderSize = 0
        Me.buttonDeleteFormula.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.buttonDeleteFormula.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.buttonDeleteFormula.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonDeleteFormula.ForeColor = System.Drawing.Color.Black
        Me.buttonDeleteFormula.Image = CType(resources.GetObject("buttonDeleteFormula.Image"), System.Drawing.Image)
        Me.buttonDeleteFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonDeleteFormula.Location = New System.Drawing.Point(140, 0)
        Me.buttonDeleteFormula.Name = "buttonDeleteFormula"
        Me.buttonDeleteFormula.Size = New System.Drawing.Size(70, 23)
        Me.buttonDeleteFormula.TabIndex = 268
        Me.buttonDeleteFormula.Text = "Delete"
        Me.buttonDeleteFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.buttonDeleteFormula, "Delete Agreement Formula")
        Me.buttonDeleteFormula.UseVisualStyleBackColor = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Help
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(448, 66)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(9, 9)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox4.TabIndex = 299
        Me.PictureBox4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox4, "The Agreement Formula will be set to the fixed price and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "applied to all procedur" &
        "es within the selected diagnostic " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the selected insurance company")
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Help
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(288, 66)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(9, 9)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 298
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "The Agreement Formula will be calculated " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "as a percent of the procedure price ap" &
        "plied " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to all procedures within the selected diagnostic ")
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Help
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(73, 66)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(9, 9)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 297
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, resources.GetString("PictureBox2.ToolTip"))
        '
        'ButtonProcessFormula
        '
        Me.ButtonProcessFormula.BackColor = System.Drawing.Color.Beige
        Me.ButtonProcessFormula.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonProcessFormula.FlatAppearance.BorderSize = 0
        Me.ButtonProcessFormula.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButtonProcessFormula.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.ButtonProcessFormula.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonProcessFormula.ForeColor = System.Drawing.Color.LightGray
        Me.ButtonProcessFormula.Image = CType(resources.GetObject("ButtonProcessFormula.Image"), System.Drawing.Image)
        Me.ButtonProcessFormula.Location = New System.Drawing.Point(506, 101)
        Me.ButtonProcessFormula.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonProcessFormula.Name = "ButtonProcessFormula"
        Me.ButtonProcessFormula.Size = New System.Drawing.Size(15, 15)
        Me.ButtonProcessFormula.TabIndex = 296
        Me.ButtonProcessFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButtonProcessFormula, "Check Formula")
        Me.ButtonProcessFormula.UseVisualStyleBackColor = False
        '
        'buttonFormulaCancel
        '
        Me.buttonFormulaCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonFormulaCancel.BackColor = System.Drawing.Color.Transparent
        Me.buttonFormulaCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttonFormulaCancel.FlatAppearance.BorderSize = 0
        Me.buttonFormulaCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.buttonFormulaCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.buttonFormulaCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonFormulaCancel.ForeColor = System.Drawing.Color.Black
        Me.buttonFormulaCancel.Image = CType(resources.GetObject("buttonFormulaCancel.Image"), System.Drawing.Image)
        Me.buttonFormulaCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonFormulaCancel.Location = New System.Drawing.Point(462, 4)
        Me.buttonFormulaCancel.Name = "buttonFormulaCancel"
        Me.buttonFormulaCancel.Size = New System.Drawing.Size(70, 23)
        Me.buttonFormulaCancel.TabIndex = 270
        Me.buttonFormulaCancel.Text = "Cancel"
        Me.buttonFormulaCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.buttonFormulaCancel, "Cancel")
        Me.buttonFormulaCancel.UseVisualStyleBackColor = False
        '
        'buttonUpdateFormula
        '
        Me.buttonUpdateFormula.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonUpdateFormula.BackColor = System.Drawing.Color.Transparent
        Me.buttonUpdateFormula.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttonUpdateFormula.FlatAppearance.BorderSize = 0
        Me.buttonUpdateFormula.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.buttonUpdateFormula.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.buttonUpdateFormula.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonUpdateFormula.ForeColor = System.Drawing.Color.Black
        Me.buttonUpdateFormula.Image = CType(resources.GetObject("buttonUpdateFormula.Image"), System.Drawing.Image)
        Me.buttonUpdateFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonUpdateFormula.Location = New System.Drawing.Point(390, 4)
        Me.buttonUpdateFormula.Name = "buttonUpdateFormula"
        Me.buttonUpdateFormula.Size = New System.Drawing.Size(70, 23)
        Me.buttonUpdateFormula.TabIndex = 269
        Me.buttonUpdateFormula.Text = "Update"
        Me.buttonUpdateFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.buttonUpdateFormula, "Add Formula")
        Me.buttonUpdateFormula.UseVisualStyleBackColor = False
        '
        'PanelFormulaEdit
        '
        Me.PanelFormulaEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.PanelFormulaEdit.Controls.Add(Me.PictureBox5)
        Me.PanelFormulaEdit.Controls.Add(Me.Label10)
        Me.PanelFormulaEdit.Controls.Add(Me.cboCaseTypes)
        Me.PanelFormulaEdit.Controls.Add(Me.Label9)
        Me.PanelFormulaEdit.Controls.Add(Me.PictureBox4)
        Me.PanelFormulaEdit.Controls.Add(Me.PictureBox3)
        Me.PanelFormulaEdit.Controls.Add(Me.PictureBox2)
        Me.PanelFormulaEdit.Controls.Add(Me.ButtonProcessFormula)
        Me.PanelFormulaEdit.Controls.Add(Me.NumericUpDown1)
        Me.PanelFormulaEdit.Controls.Add(Me.Label1)
        Me.PanelFormulaEdit.Controls.Add(Me.cboInsuranceCompanyID)
        Me.PanelFormulaEdit.Controls.Add(Me.txtFormula)
        Me.PanelFormulaEdit.Controls.Add(Me.NumericUpDownFixed)
        Me.PanelFormulaEdit.Controls.Add(Me.RadioButtonFixed)
        Me.PanelFormulaEdit.Controls.Add(Me.NumericUpDownPercent)
        Me.PanelFormulaEdit.Controls.Add(Me.RadioButtonPercent)
        Me.PanelFormulaEdit.Controls.Add(Me.Label7)
        Me.PanelFormulaEdit.Controls.Add(Me.buttonFormulaCancel)
        Me.PanelFormulaEdit.Controls.Add(Me.buttonUpdateFormula)
        Me.PanelFormulaEdit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFormulaEdit.Location = New System.Drawing.Point(0, 225)
        Me.PanelFormulaEdit.Name = "PanelFormulaEdit"
        Me.PanelFormulaEdit.Size = New System.Drawing.Size(532, 130)
        Me.PanelFormulaEdit.TabIndex = 289
        Me.ToolTip1.SetToolTip(Me.PanelFormulaEdit, "11")
        Me.PanelFormulaEdit.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Help
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(71, 6)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(9, 9)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 302
        Me.PictureBox5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox5, "Agreement formula available for the No Fault case types only.")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(10, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 301
        Me.Label10.Text = "Formula:"
        '
        'cboCaseTypes
        '
        Me.cboCaseTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaseTypes.FormattingEnabled = True
        Me.cboCaseTypes.Location = New System.Drawing.Point(84, 6)
        Me.cboCaseTypes.Name = "cboCaseTypes"
        Me.cboCaseTypes.Size = New System.Drawing.Size(205, 21)
        Me.cboCaseTypes.TabIndex = 300
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 295
        Me.Label9.Text = "Case Type:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(84, 68)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDown1.TabIndex = 295
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 294
        Me.Label1.Text = "Procedure #"
        '
        'cboInsuranceCompanyID
        '
        Me.cboInsuranceCompanyID.FormattingEnabled = True
        Me.cboInsuranceCompanyID.Location = New System.Drawing.Point(84, 36)
        Me.cboInsuranceCompanyID.Name = "cboInsuranceCompanyID"
        Me.cboInsuranceCompanyID.Size = New System.Drawing.Size(441, 21)
        Me.cboInsuranceCompanyID.TabIndex = 279
        '
        'txtFormula
        '
        Me.txtFormula.BackColor = System.Drawing.Color.Beige
        Me.txtFormula.Location = New System.Drawing.Point(84, 100)
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.ReadOnly = True
        Me.txtFormula.Size = New System.Drawing.Size(441, 20)
        Me.txtFormula.TabIndex = 278
        '
        'NumericUpDownFixed
        '
        Me.NumericUpDownFixed.DecimalPlaces = 2
        Me.NumericUpDownFixed.Location = New System.Drawing.Point(464, 68)
        Me.NumericUpDownFixed.Maximum = New Decimal(New Integer() {9999999, 0, 0, 131072})
        Me.NumericUpDownFixed.Name = "NumericUpDownFixed"
        Me.NumericUpDownFixed.Size = New System.Drawing.Size(61, 20)
        Me.NumericUpDownFixed.TabIndex = 277
        Me.NumericUpDownFixed.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'RadioButtonFixed
        '
        Me.RadioButtonFixed.AutoSize = True
        Me.RadioButtonFixed.ForeColor = System.Drawing.Color.Black
        Me.RadioButtonFixed.Location = New System.Drawing.Point(361, 68)
        Me.RadioButtonFixed.Name = "RadioButtonFixed"
        Me.RadioButtonFixed.Size = New System.Drawing.Size(88, 17)
        Me.RadioButtonFixed.TabIndex = 276
        Me.RadioButtonFixed.Text = "Fixed amount"
        Me.RadioButtonFixed.UseVisualStyleBackColor = True
        '
        'NumericUpDownPercent
        '
        Me.NumericUpDownPercent.Location = New System.Drawing.Point(304, 68)
        Me.NumericUpDownPercent.Name = "NumericUpDownPercent"
        Me.NumericUpDownPercent.Size = New System.Drawing.Size(43, 20)
        Me.NumericUpDownPercent.TabIndex = 275
        Me.NumericUpDownPercent.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'RadioButtonPercent
        '
        Me.RadioButtonPercent.AutoSize = True
        Me.RadioButtonPercent.ForeColor = System.Drawing.Color.Black
        Me.RadioButtonPercent.Location = New System.Drawing.Point(146, 70)
        Me.RadioButtonPercent.Name = "RadioButtonPercent"
        Me.RadioButtonPercent.Size = New System.Drawing.Size(143, 17)
        Me.RadioButtonPercent.TabIndex = 273
        Me.RadioButtonPercent.Text = "Percent of Fee Schedule"
        Me.RadioButtonPercent.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 272
        Me.Label7.Text = "Insurance:"
        '
        'PictureBoxAutoReasize
        '
        Me.PictureBoxAutoReasize.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxAutoReasize.Image = CType(resources.GetObject("PictureBoxAutoReasize.Image"), System.Drawing.Image)
        Me.PictureBoxAutoReasize.Location = New System.Drawing.Point(433, 20)
        Me.PictureBoxAutoReasize.Name = "PictureBoxAutoReasize"
        Me.PictureBoxAutoReasize.Size = New System.Drawing.Size(23, 16)
        Me.PictureBoxAutoReasize.TabIndex = 156
        Me.PictureBoxAutoReasize.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxAutoReasize, "Auto resize Columns Width")
        Me.PictureBoxAutoReasize.Visible = False
        '
        'ButtonFilter
        '
        Me.ButtonFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFilter.BackColor = System.Drawing.Color.Transparent
        Me.ButtonFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFilter.FlatAppearance.BorderSize = 0
        Me.ButtonFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButtonFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.ButtonFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFilter.ForeColor = System.Drawing.Color.Black
        Me.ButtonFilter.Image = CType(resources.GetObject("ButtonFilter.Image"), System.Drawing.Image)
        Me.ButtonFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonFilter.Location = New System.Drawing.Point(471, 5)
        Me.ButtonFilter.Name = "ButtonFilter"
        Me.ButtonFilter.Size = New System.Drawing.Size(58, 23)
        Me.ButtonFilter.TabIndex = 282
        Me.ButtonFilter.Text = "Filter"
        Me.ButtonFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButtonFilter, "Filter Formulas")
        Me.ButtonFilter.UseVisualStyleBackColor = False
        '
        'buttonFormulaEdit
        '
        Me.buttonFormulaEdit.BackColor = System.Drawing.Color.Transparent
        Me.buttonFormulaEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttonFormulaEdit.Dock = System.Windows.Forms.DockStyle.Left
        Me.buttonFormulaEdit.FlatAppearance.BorderSize = 0
        Me.buttonFormulaEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.buttonFormulaEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.buttonFormulaEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonFormulaEdit.ForeColor = System.Drawing.Color.Black
        Me.buttonFormulaEdit.Image = CType(resources.GetObject("buttonFormulaEdit.Image"), System.Drawing.Image)
        Me.buttonFormulaEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonFormulaEdit.Location = New System.Drawing.Point(70, 0)
        Me.buttonFormulaEdit.Name = "buttonFormulaEdit"
        Me.buttonFormulaEdit.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.buttonFormulaEdit.Size = New System.Drawing.Size(70, 23)
        Me.buttonFormulaEdit.TabIndex = 269
        Me.buttonFormulaEdit.Text = "Edit"
        Me.buttonFormulaEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.buttonFormulaEdit, "Add Agreement Formula")
        Me.buttonFormulaEdit.UseVisualStyleBackColor = False
        '
        'cboOfficeType
        '
        Me.cboOfficeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOfficeType.Enabled = False
        Me.cboOfficeType.FormattingEnabled = True
        Me.cboOfficeType.Location = New System.Drawing.Point(12, 39)
        Me.cboOfficeType.Name = "cboOfficeType"
        Me.cboOfficeType.Size = New System.Drawing.Size(513, 21)
        Me.cboOfficeType.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Diagnostic Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Diagnostic Description"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Controls.Add(Me.cmdEdit)
        Me.Panel2.Controls.Add(Me.cmdAddNew)
        Me.Panel2.Controls.Add(Me.cmdDelete)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 402)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(784, 34)
        Me.Panel2.TabIndex = 99
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(699, 6)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Location = New System.Drawing.Point(246, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Location = New System.Drawing.Point(165, 6)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Location = New System.Drawing.Point(84, 6)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.cmdEdit.TabIndex = 2
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(3, 6)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddNew.TabIndex = 1
        Me.cmdAddNew.Text = "Add New"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Location = New System.Drawing.Point(3, 6)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 0
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        Me.cmdDelete.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(2, 2)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(27, 13)
        Me.Label25.TabIndex = 155
        Me.Label25.Text = "Find"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(237, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(540, 381)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.CheckBoxActiveInd)
        Me.TabPage1.Controls.Add(Me.CheckBox7)
        Me.TabPage1.Controls.Add(Me.CheckBox6)
        Me.TabPage1.Controls.Add(Me.CheckBox5)
        Me.TabPage1.Controls.Add(Me.CheckBox4)
        Me.TabPage1.Controls.Add(Me.CheckBox3)
        Me.TabPage1.Controls.Add(Me.CheckBox2)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.cboInterval)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cboTreatingProvider)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.cboBillingProvider)
        Me.TabPage1.Controls.Add(Me.txtAbbreviation)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cboOfficeType)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtDiagName)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtDiagDescription)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(532, 355)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 13)
        Me.Label8.TabIndex = 296
        Me.Label8.Text = "Diagnostic Service Dates"
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Enabled = False
        Me.CheckBox7.ForeColor = System.Drawing.Color.Red
        Me.CheckBox7.Location = New System.Drawing.Point(457, 270)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox7.TabIndex = 295
        Me.CheckBox7.Text = "Saturday"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Enabled = False
        Me.CheckBox6.Location = New System.Drawing.Point(387, 270)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(54, 17)
        Me.CheckBox6.TabIndex = 294
        Me.CheckBox6.Text = "Friday"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Enabled = False
        Me.CheckBox5.Location = New System.Drawing.Point(313, 270)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox5.TabIndex = 293
        Me.CheckBox5.Text = "Thursday"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Enabled = False
        Me.CheckBox4.Location = New System.Drawing.Point(231, 270)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(83, 17)
        Me.CheckBox4.TabIndex = 292
        Me.CheckBox4.Text = "Wednesday"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Location = New System.Drawing.Point(158, 270)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(67, 17)
        Me.CheckBox3.TabIndex = 291
        Me.CheckBox3.Text = "Tuesday"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(84, 270)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(64, 17)
        Me.CheckBox2.TabIndex = 290
        Me.CheckBox2.Text = "Monday"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.ForeColor = System.Drawing.Color.Red
        Me.CheckBox1.Location = New System.Drawing.Point(12, 270)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(62, 17)
        Me.CheckBox1.TabIndex = 289
        Me.CheckBox1.Text = "Sunday"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(404, 101)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 13)
        Me.Label18.TabIndex = 288
        Me.Label18.Text = "Schedule Interval"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 13)
        Me.Label4.TabIndex = 168
        Me.Label4.Text = "Default Treating Provider"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 13)
        Me.Label15.TabIndex = 166
        Me.Label15.Text = "Default Billing Provider"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(404, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Abbr"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Office Type"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ListViewFormulas)
        Me.TabPage3.Controls.Add(Me.PanelFormula)
        Me.TabPage3.Controls.Add(Me.PanelFormulaEdit)
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(532, 355)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Billing Agreement Formulas"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ListViewFormulas
        '
        Me.ListViewFormulas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader9, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListViewFormulas.ContextMenuStrip = Me.ContextMenuStripCustomizeToolStrip
        Me.ListViewFormulas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewFormulas.FullRowSelect = True
        Me.ListViewFormulas.GridLines = True
        Me.ListViewFormulas.HideSelection = False
        Me.ListViewFormulas.LargeImageList = Me.ImageList2
        Me.ListViewFormulas.Location = New System.Drawing.Point(0, 32)
        Me.ListViewFormulas.MultiSelect = False
        Me.ListViewFormulas.Name = "ListViewFormulas"
        Me.ListViewFormulas.Size = New System.Drawing.Size(532, 170)
        Me.ListViewFormulas.SmallImageList = Me.ImageList2
        Me.ListViewFormulas.TabIndex = 291
        Me.ListViewFormulas.UseCompatibleStateImageBehavior = False
        Me.ListViewFormulas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Case"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Diagnostic"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Insurance"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Type"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Proc #"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Formula"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "CreatedBy"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Created DT"
        '
        'ContextMenuStripCustomizeToolStrip
        '
        Me.ContextMenuStripCustomizeToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.CustomizeToolbarDeleteFormula})
        Me.ContextMenuStripCustomizeToolStrip.Name = "ContextMenuStripCustomizeToolStrip"
        Me.ContextMenuStripCustomizeToolStrip.Size = New System.Drawing.Size(155, 54)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(154, 22)
        Me.ToolStripMenuItem1.Text = "Edit Formula"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(151, 6)
        '
        'CustomizeToolbarDeleteFormula
        '
        Me.CustomizeToolbarDeleteFormula.Image = CType(resources.GetObject("CustomizeToolbarDeleteFormula.Image"), System.Drawing.Image)
        Me.CustomizeToolbarDeleteFormula.Name = "CustomizeToolbarDeleteFormula"
        Me.CustomizeToolbarDeleteFormula.Size = New System.Drawing.Size(154, 22)
        Me.CustomizeToolbarDeleteFormula.Text = "Delete Formula"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "SORT1")
        Me.ImageList2.Images.SetKeyName(1, "SORT2")
        Me.ImageList2.Images.SetKeyName(2, "SORT0")
        '
        'PanelFormula
        '
        Me.PanelFormula.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.PanelFormula.Controls.Add(Me.buttonDeleteFormula)
        Me.PanelFormula.Controls.Add(Me.buttonFormulaEdit)
        Me.PanelFormula.Controls.Add(Me.buttonFormulaAdd)
        Me.PanelFormula.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFormula.Location = New System.Drawing.Point(0, 202)
        Me.PanelFormula.Name = "PanelFormula"
        Me.PanelFormula.Size = New System.Drawing.Size(532, 23)
        Me.PanelFormula.TabIndex = 290
        Me.PanelFormula.Tag = """1"""
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel1.Controls.Add(Me.ButtonFilter)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cboInsuranceCompanyIDSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(532, 32)
        Me.Panel1.TabIndex = 292
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(3, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 281
        Me.Label11.Text = "Insurance:"
        '
        'cboInsuranceCompanyIDSearch
        '
        Me.cboInsuranceCompanyIDSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboInsuranceCompanyIDSearch.FormattingEnabled = True
        Me.cboInsuranceCompanyIDSearch.Location = New System.Drawing.Point(61, 5)
        Me.cboInsuranceCompanyIDSearch.Name = "cboInsuranceCompanyIDSearch"
        Me.cboInsuranceCompanyIDSearch.Size = New System.Drawing.Size(404, 21)
        Me.cboInsuranceCompanyIDSearch.TabIndex = 280
        '
        'frmDiagnosticMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(784, 436)
        Me.Controls.Add(Me.PictureBoxAutoReasize)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TextBoxSearch)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 470)
        Me.Name = "frmDiagnosticMaintenance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Diagnostic Maintenance"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelFormulaEdit.ResumeLayout(False)
        Me.PanelFormulaEdit.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownFixed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownPercent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxAutoReasize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.ContextMenuStripCustomizeToolStrip.ResumeLayout(False)
        Me.PanelFormula.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDiagName As System.Windows.Forms.TextBox
    Friend WithEvents txtDiagDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxActiveInd As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboOfficeType As System.Windows.Forms.ComboBox
    Friend WithEvents txtAbbreviation As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBillingProvider As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTreatingProvider As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboInterval As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents PanelFormula As Panel
    Private WithEvents buttonFormulaAdd As Button
    Private WithEvents buttonDeleteFormula As Button
    Friend WithEvents PanelFormulaEdit As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Private WithEvents ButtonProcessFormula As Button
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents cboInsuranceCompanyID As ComboBox
    Friend WithEvents txtFormula As TextBox
    Friend WithEvents NumericUpDownFixed As NumericUpDown
    Friend WithEvents RadioButtonFixed As RadioButton
    Friend WithEvents NumericUpDownPercent As NumericUpDown
    Friend WithEvents RadioButtonPercent As RadioButton
    Friend WithEvents Label7 As Label
    Private WithEvents buttonFormulaCancel As Button
    Private WithEvents buttonUpdateFormula As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents cboCaseTypes As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ListViewFormulas As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents PictureBoxAutoReasize As PictureBox
    Friend WithEvents Panel1 As Panel
    Private WithEvents ButtonFilter As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents cboInsuranceCompanyIDSearch As ComboBox
    Friend WithEvents ContextMenuStripCustomizeToolStrip As ContextMenuStrip
    Friend WithEvents CustomizeToolbarDeleteFormula As ToolStripMenuItem
    Private WithEvents buttonFormulaEdit As Button
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PictureBox5 As PictureBox
End Class
