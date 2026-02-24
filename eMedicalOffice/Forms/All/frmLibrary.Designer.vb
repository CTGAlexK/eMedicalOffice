<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLibrary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLibrary))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelDocumentChanged = New System.Windows.Forms.Label()
        Me.LabelPatient = New System.Windows.Forms.Label()
        Me.ToolStripFontSize = New System.Windows.Forms.ToolStrip()
        Me.ButtonDn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonUp = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonAddToPatient = New System.Windows.Forms.Button()
        Me.ButtonOpenDocument = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListViewDocuments = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshLibraryDocumentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LabelCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RichTextBox1 = New eMedicalOffice.RichTextBoxPrintCtrl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbrFont = New System.Windows.Forms.ToolStripButton()
        Me.tspColor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbrLeft = New System.Windows.Forms.ToolStripButton()
        Me.tbrCenter = New System.Windows.Forms.ToolStripButton()
        Me.tbrRight = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbrBold = New System.Windows.Forms.ToolStripButton()
        Me.tbrItalic = New System.Windows.Forms.ToolStripButton()
        Me.tbrUnderline = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.InsertImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectFontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FontColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BoldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItalicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnderlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParagraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent20 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAlign = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BulletsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddBulletsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveBulletsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerReset = New System.Windows.Forms.Timer(Me.components)
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripFontSize.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.LabelDocumentChanged)
        Me.Panel1.Controls.Add(Me.LabelPatient)
        Me.Panel1.Controls.Add(Me.ToolStripFontSize)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(862, 38)
        Me.Panel1.TabIndex = 101
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'LabelDocumentChanged
        '
        Me.LabelDocumentChanged.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelDocumentChanged.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelDocumentChanged.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelDocumentChanged.Image = CType(resources.GetObject("LabelDocumentChanged.Image"), System.Drawing.Image)
        Me.LabelDocumentChanged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelDocumentChanged.Location = New System.Drawing.Point(645, 11)
        Me.LabelDocumentChanged.Name = "LabelDocumentChanged"
        Me.LabelDocumentChanged.Size = New System.Drawing.Size(153, 15)
        Me.LabelDocumentChanged.TabIndex = 6
        Me.LabelDocumentChanged.Text = "DOCUMENT CHANGED"
        Me.LabelDocumentChanged.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LabelDocumentChanged.Visible = False
        '
        'LabelPatient
        '
        Me.LabelPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelPatient.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelPatient.Location = New System.Drawing.Point(38, 12)
        Me.LabelPatient.Name = "LabelPatient"
        Me.LabelPatient.Size = New System.Drawing.Size(467, 13)
        Me.LabelPatient.TabIndex = 5
        Me.LabelPatient.Text = "LIBRARY"
        Me.LabelPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripFontSize
        '
        Me.ToolStripFontSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStripFontSize.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripFontSize.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripFontSize.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFontSize.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonDn, Me.ToolStripSeparator1, Me.ButtonUp})
        Me.ToolStripFontSize.Location = New System.Drawing.Point(806, 6)
        Me.ToolStripFontSize.Name = "ToolStripFontSize"
        Me.ToolStripFontSize.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripFontSize.Size = New System.Drawing.Size(55, 25)
        Me.ToolStripFontSize.TabIndex = 4
        Me.ToolStripFontSize.Text = "ToolStrip3"
        '
        'ButtonDn
        '
        Me.ButtonDn.BackColor = System.Drawing.Color.Transparent
        Me.ButtonDn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonDn.Image = CType(resources.GetObject("ButtonDn.Image"), System.Drawing.Image)
        Me.ButtonDn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonDn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDn.Name = "ButtonDn"
        Me.ButtonDn.Size = New System.Drawing.Size(23, 22)
        Me.ButtonDn.ToolTipText = "Font Increase"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonUp
        '
        Me.ButtonUp.BackColor = System.Drawing.Color.Transparent
        Me.ButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonUp.Image = CType(resources.GetObject("ButtonUp.Image"), System.Drawing.Image)
        Me.ButtonUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonUp.Name = "ButtonUp"
        Me.ButtonUp.Size = New System.Drawing.Size(23, 22)
        Me.ButtonUp.ToolTipText = "Font Decrease"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.ButtonAddToPatient)
        Me.Panel2.Controls.Add(Me.ButtonOpenDocument)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 465)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(862, 34)
        Me.Panel2.TabIndex = 102
        '
        'Button5
        '
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(393, 5)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(76, 26)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "Print"
        Me.ToolTip1.SetToolTip(Me.Button5, "Print Document")
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(311, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(76, 26)
        Me.Button4.TabIndex = 16
        Me.Button4.Text = "  Email"
        Me.ToolTip1.SetToolTip(Me.Button4, "Email Document")
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(229, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 26)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "   Fax"
        Me.ToolTip1.SetToolTip(Me.Button3, "Fax Document")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(147, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 26)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Save As"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button2, "Save Document AS")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 26)
        Me.Button1.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.Button1, "Show help on Reserved Words.")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonAddToPatient
        '
        Me.ButtonAddToPatient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddToPatient.FlatAppearance.BorderSize = 0
        Me.ButtonAddToPatient.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAddToPatient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonAddToPatient.Image = CType(resources.GetObject("ButtonAddToPatient.Image"), System.Drawing.Image)
        Me.ButtonAddToPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAddToPatient.Location = New System.Drawing.Point(636, 5)
        Me.ButtonAddToPatient.Name = "ButtonAddToPatient"
        Me.ButtonAddToPatient.Size = New System.Drawing.Size(128, 26)
        Me.ButtonAddToPatient.TabIndex = 12
        Me.ButtonAddToPatient.Text = "Add To Patient"
        Me.ButtonAddToPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAddToPatient.UseVisualStyleBackColor = True
        '
        'ButtonOpenDocument
        '
        Me.ButtonOpenDocument.FlatAppearance.BorderSize = 0
        Me.ButtonOpenDocument.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonOpenDocument.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonOpenDocument.Image = CType(resources.GetObject("ButtonOpenDocument.Image"), System.Drawing.Image)
        Me.ButtonOpenDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonOpenDocument.Location = New System.Drawing.Point(65, 4)
        Me.ButtonOpenDocument.Name = "ButtonOpenDocument"
        Me.ButtonOpenDocument.Size = New System.Drawing.Size(76, 26)
        Me.ButtonOpenDocument.TabIndex = 0
        Me.ButtonOpenDocument.Text = "  Open"
        Me.ToolTip1.SetToolTip(Me.ButtonOpenDocument, "Open Document in default viewer")
        Me.ButtonOpenDocument.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatAppearance.BorderSize = 0
        Me.cmdClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(773, 4)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(80, 26)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 38)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(862, 2)
        Me.Panel3.TabIndex = 139
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 40)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListViewDocuments)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.RichTextBox2)
        Me.SplitContainer1.Size = New System.Drawing.Size(862, 425)
        Me.SplitContainer1.SplitterDistance = 324
        Me.SplitContainer1.TabIndex = 371
        '
        'ListViewDocuments
        '
        Me.ListViewDocuments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListViewDocuments.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListViewDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewDocuments.FullRowSelect = True
        Me.ListViewDocuments.GridLines = True
        Me.ListViewDocuments.Location = New System.Drawing.Point(0, 43)
        Me.ListViewDocuments.MultiSelect = False
        Me.ListViewDocuments.Name = "ListViewDocuments"
        Me.ListViewDocuments.Size = New System.Drawing.Size(324, 382)
        Me.ListViewDocuments.TabIndex = 0
        Me.ListViewDocuments.UseCompatibleStateImageBehavior = False
        Me.ListViewDocuments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Document"
        Me.ColumnHeader1.Width = 296
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshLibraryDocumentsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(217, 26)
        '
        'RefreshLibraryDocumentsToolStripMenuItem
        '
        Me.RefreshLibraryDocumentsToolStripMenuItem.Image = CType(resources.GetObject("RefreshLibraryDocumentsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshLibraryDocumentsToolStripMenuItem.Name = "RefreshLibraryDocumentsToolStripMenuItem"
        Me.RefreshLibraryDocumentsToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.RefreshLibraryDocumentsToolStripMenuItem.Text = "Refresh Library Documents"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LabelCount)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.TextBoxSearch)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel4.Size = New System.Drawing.Size(324, 43)
        Me.Panel4.TabIndex = 2
        '
        'LabelCount
        '
        Me.LabelCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelCount.Location = New System.Drawing.Point(136, 0)
        Me.LabelCount.Name = "LabelCount"
        Me.LabelCount.Size = New System.Drawing.Size(185, 19)
        Me.LabelCount.TabIndex = 4
        Me.LabelCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Search"
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.BackColor = System.Drawing.Color.White
        Me.TextBoxSearch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBoxSearch.Location = New System.Drawing.Point(0, 19)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(324, 20)
        Me.TextBoxSearch.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.RichTextBox1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 49)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Panel5.Size = New System.Drawing.Size(534, 376)
        Me.Panel5.TabIndex = 375
        '
        'RichTextBox1
        '
        Me.RichTextBox1.AutoWordSelection = True
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(10, 0)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ShowSelectionMargin = True
        Me.RichTextBox1.Size = New System.Drawing.Size(524, 376)
        Me.RichTextBox1.TabIndex = 372
        Me.RichTextBox1.Text = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripSeparator6, Me.ToolStripButton2, Me.ToolStripSeparator2, Me.tbrFont, Me.tspColor, Me.ToolStripSeparator4, Me.tbrLeft, Me.tbrCenter, Me.tbrRight, Me.ToolStripSeparator3, Me.tbrBold, Me.tbrItalic, Me.tbrUnderline, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator7, Me.ToolStripButton1, Me.ToolStripSeparator8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(534, 25)
        Me.ToolStrip1.TabIndex = 374
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "ToolStripButton5"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Print"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tbrFont
        '
        Me.tbrFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrFont.Image = CType(resources.GetObject("tbrFont.Image"), System.Drawing.Image)
        Me.tbrFont.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrFont.Name = "tbrFont"
        Me.tbrFont.Size = New System.Drawing.Size(23, 22)
        Me.tbrFont.Text = "Font"
        '
        'tspColor
        '
        Me.tspColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tspColor.Image = CType(resources.GetObject("tspColor.Image"), System.Drawing.Image)
        Me.tspColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tspColor.Name = "tspColor"
        Me.tspColor.Size = New System.Drawing.Size(23, 22)
        Me.tspColor.Text = "Font Color"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tbrLeft
        '
        Me.tbrLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrLeft.Image = CType(resources.GetObject("tbrLeft.Image"), System.Drawing.Image)
        Me.tbrLeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrLeft.Name = "tbrLeft"
        Me.tbrLeft.Size = New System.Drawing.Size(23, 22)
        Me.tbrLeft.Text = "Left"
        '
        'tbrCenter
        '
        Me.tbrCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrCenter.Image = CType(resources.GetObject("tbrCenter.Image"), System.Drawing.Image)
        Me.tbrCenter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrCenter.Name = "tbrCenter"
        Me.tbrCenter.Size = New System.Drawing.Size(23, 22)
        Me.tbrCenter.Text = "Center"
        '
        'tbrRight
        '
        Me.tbrRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrRight.Image = CType(resources.GetObject("tbrRight.Image"), System.Drawing.Image)
        Me.tbrRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrRight.Name = "tbrRight"
        Me.tbrRight.Size = New System.Drawing.Size(23, 22)
        Me.tbrRight.Text = "Right"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tbrBold
        '
        Me.tbrBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrBold.Image = CType(resources.GetObject("tbrBold.Image"), System.Drawing.Image)
        Me.tbrBold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrBold.Name = "tbrBold"
        Me.tbrBold.Size = New System.Drawing.Size(23, 22)
        Me.tbrBold.Text = "Bold"
        '
        'tbrItalic
        '
        Me.tbrItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrItalic.Image = CType(resources.GetObject("tbrItalic.Image"), System.Drawing.Image)
        Me.tbrItalic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrItalic.Name = "tbrItalic"
        Me.tbrItalic.Size = New System.Drawing.Size(23, 22)
        Me.tbrItalic.Text = "Italic"
        '
        'tbrUnderline
        '
        Me.tbrUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrUnderline.Image = CType(resources.GetObject("tbrUnderline.Image"), System.Drawing.Image)
        Me.tbrUnderline.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrUnderline.Name = "tbrUnderline"
        Me.tbrUnderline.Size = New System.Drawing.Size(23, 22)
        Me.tbrUnderline.Text = "Underline"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "To Upper Case"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "To Lower Case"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Insert Image"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.FontToolStripMenuItem, Me.ParagraphToolStripMenuItem, Me.BulletsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(534, 24)
        Me.MenuStrip1.TabIndex = 373
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.mnuPageSetup, Me.PreviewToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(139, 6)
        '
        'mnuPageSetup
        '
        Me.mnuPageSetup.Name = "mnuPageSetup"
        Me.mnuPageSetup.Size = New System.Drawing.Size(142, 22)
        Me.mnuPageSetup.Text = "Page Setup..."
        '
        'PreviewToolStripMenuItem
        '
        Me.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem"
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.PreviewToolStripMenuItem.Text = "Pre&view..."
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.PrintToolStripMenuItem.Text = "&Print..."
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUndo, Me.mnuRedo, Me.ToolStripMenuItem4, Me.SelectAllToolStripMenuItem, Me.ToolStripMenuItem5, Me.CopyToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripMenuItem8, Me.InsertImageToolStripMenuItem, Me.ResetAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'mnuUndo
        '
        Me.mnuUndo.Name = "mnuUndo"
        Me.mnuUndo.Size = New System.Drawing.Size(148, 22)
        Me.mnuUndo.Text = "&Undo"
        '
        'mnuRedo
        '
        Me.mnuRedo.Name = "mnuRedo"
        Me.mnuRedo.Size = New System.Drawing.Size(148, 22)
        Me.mnuRedo.Text = "&Redo"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(145, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select &All"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(145, 6)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CutToolStripMenuItem.Text = "C&ut"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.PasteToolStripMenuItem.Text = "Pas&te"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(145, 6)
        '
        'InsertImageToolStripMenuItem
        '
        Me.InsertImageToolStripMenuItem.Name = "InsertImageToolStripMenuItem"
        Me.InsertImageToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.InsertImageToolStripMenuItem.Text = "Insert Image..."
        '
        'ResetAllToolStripMenuItem
        '
        Me.ResetAllToolStripMenuItem.Name = "ResetAllToolStripMenuItem"
        Me.ResetAllToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ResetAllToolStripMenuItem.Text = "Reset All"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectFontToolStripMenuItem, Me.ToolStripMenuItem6, Me.FontColorToolStripMenuItem, Me.ToolStripSeparator5, Me.BoldToolStripMenuItem, Me.ItalicToolStripMenuItem, Me.UnderlineToolStripMenuItem, Me.NormalToolStripMenuItem})
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.FontToolStripMenuItem.Text = "F&ont"
        '
        'SelectFontToolStripMenuItem
        '
        Me.SelectFontToolStripMenuItem.Name = "SelectFontToolStripMenuItem"
        Me.SelectFontToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SelectFontToolStripMenuItem.Text = "Se&lect Font..."
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(138, 6)
        '
        'FontColorToolStripMenuItem
        '
        Me.FontColorToolStripMenuItem.Name = "FontColorToolStripMenuItem"
        Me.FontColorToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.FontColorToolStripMenuItem.Text = "Font &Color..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(138, 6)
        '
        'BoldToolStripMenuItem
        '
        Me.BoldToolStripMenuItem.Name = "BoldToolStripMenuItem"
        Me.BoldToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.BoldToolStripMenuItem.Text = "&Bold"
        '
        'ItalicToolStripMenuItem
        '
        Me.ItalicToolStripMenuItem.Name = "ItalicToolStripMenuItem"
        Me.ItalicToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ItalicToolStripMenuItem.Text = "&Italic"
        '
        'UnderlineToolStripMenuItem
        '
        Me.UnderlineToolStripMenuItem.Name = "UnderlineToolStripMenuItem"
        Me.UnderlineToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.UnderlineToolStripMenuItem.Text = "&Underline"
        '
        'NormalToolStripMenuItem
        '
        Me.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem"
        Me.NormalToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.NormalToolStripMenuItem.Text = "&Normal"
        '
        'ParagraphToolStripMenuItem
        '
        Me.ParagraphToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IndentToolStripMenuItem, Me.mnuAlign})
        Me.ParagraphToolStripMenuItem.Name = "ParagraphToolStripMenuItem"
        Me.ParagraphToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.ParagraphToolStripMenuItem.Text = "P&aragraph"
        '
        'IndentToolStripMenuItem
        '
        Me.IndentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuIndent0, Me.mnuIndent5, Me.mnuIndent10, Me.mnuIndent15, Me.mnuIndent20})
        Me.IndentToolStripMenuItem.Name = "IndentToolStripMenuItem"
        Me.IndentToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.IndentToolStripMenuItem.Text = "&Indent"
        '
        'mnuIndent0
        '
        Me.mnuIndent0.Name = "mnuIndent0"
        Me.mnuIndent0.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent0.Text = "None"
        '
        'mnuIndent5
        '
        Me.mnuIndent5.Name = "mnuIndent5"
        Me.mnuIndent5.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent5.Text = "5 pts"
        '
        'mnuIndent10
        '
        Me.mnuIndent10.Name = "mnuIndent10"
        Me.mnuIndent10.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent10.Text = "10 pts"
        '
        'mnuIndent15
        '
        Me.mnuIndent15.Name = "mnuIndent15"
        Me.mnuIndent15.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent15.Text = "15 pts"
        '
        'mnuIndent20
        '
        Me.mnuIndent20.Name = "mnuIndent20"
        Me.mnuIndent20.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent20.Text = "20 pts"
        '
        'mnuAlign
        '
        Me.mnuAlign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LeftToolStripMenuItem, Me.CenterToolStripMenuItem, Me.RightToolStripMenuItem})
        Me.mnuAlign.Name = "mnuAlign"
        Me.mnuAlign.Size = New System.Drawing.Size(108, 22)
        Me.mnuAlign.Text = "&Align"
        '
        'LeftToolStripMenuItem
        '
        Me.LeftToolStripMenuItem.Name = "LeftToolStripMenuItem"
        Me.LeftToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.LeftToolStripMenuItem.Text = "Left"
        '
        'CenterToolStripMenuItem
        '
        Me.CenterToolStripMenuItem.Name = "CenterToolStripMenuItem"
        Me.CenterToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.CenterToolStripMenuItem.Text = "Center"
        '
        'RightToolStripMenuItem
        '
        Me.RightToolStripMenuItem.Name = "RightToolStripMenuItem"
        Me.RightToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.RightToolStripMenuItem.Text = "Right"
        '
        'BulletsToolStripMenuItem
        '
        Me.BulletsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddBulletsToolStripMenuItem, Me.RemoveBulletsToolStripMenuItem})
        Me.BulletsToolStripMenuItem.Name = "BulletsToolStripMenuItem"
        Me.BulletsToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.BulletsToolStripMenuItem.Text = "&Bullets"
        '
        'AddBulletsToolStripMenuItem
        '
        Me.AddBulletsToolStripMenuItem.Name = "AddBulletsToolStripMenuItem"
        Me.AddBulletsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.AddBulletsToolStripMenuItem.Text = "A&dd Bullets"
        '
        'RemoveBulletsToolStripMenuItem
        '
        Me.RemoveBulletsToolStripMenuItem.Name = "RemoveBulletsToolStripMenuItem"
        Me.RemoveBulletsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.RemoveBulletsToolStripMenuItem.Text = "&Remove Bullets"
        '
        'RichTextBox2
        '
        Me.RichTextBox2.AutoWordSelection = True
        Me.RichTextBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RichTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox2.BulletIndent = 2
        Me.RichTextBox2.Location = New System.Drawing.Point(395, 380)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ReadOnly = True
        Me.RichTextBox2.Size = New System.Drawing.Size(189, 148)
        Me.RichTextBox2.TabIndex = 371
        Me.RichTextBox2.Text = ""
        Me.RichTextBox2.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'TimerReset
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer3
        '
        Me.Timer3.Interval = 500
        '
        'frmLibrary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(862, 499)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.MinimumSize = New System.Drawing.Size(878, 537)
        Me.Name = "frmLibrary"
        Me.Text = "Library"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripFontSize.ResumeLayout(False)
        Me.ToolStripFontSize.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonOpenDocument As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ListViewDocuments As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStripFontSize As ToolStrip
    Friend WithEvents ButtonDn As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonUp As ToolStripButton
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents ButtonAddToPatient As Button
    Friend WithEvents TimerReset As Timer
    Friend WithEvents LabelPatient As Label
    Friend WithEvents LabelDocumentChanged As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents RichTextBox1 As RichTextBoxPrintCtrl
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tbrFont As ToolStripButton
    Private WithEvents tspColor As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tbrLeft As ToolStripButton
    Friend WithEvents tbrCenter As ToolStripButton
    Friend WithEvents tbrRight As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tbrBold As ToolStripButton
    Friend WithEvents tbrItalic As ToolStripButton
    Friend WithEvents tbrUnderline As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents mnuPageSetup As ToolStripMenuItem
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuUndo As ToolStripMenuItem
    Friend WithEvents mnuRedo As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripSeparator
    Friend WithEvents InsertImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectFontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents FontColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents BoldToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItalicToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnderlineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NormalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParagraphToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IndentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuIndent0 As ToolStripMenuItem
    Friend WithEvents mnuIndent5 As ToolStripMenuItem
    Friend WithEvents mnuIndent10 As ToolStripMenuItem
    Friend WithEvents mnuIndent15 As ToolStripMenuItem
    Friend WithEvents mnuIndent20 As ToolStripMenuItem
    Friend WithEvents mnuAlign As ToolStripMenuItem
    Friend WithEvents LeftToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CenterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RightToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BulletsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddBulletsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveBulletsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolTip2 As ToolTip
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ResetAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LabelCount As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RefreshLibraryDocumentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Panel5 As Panel
End Class
