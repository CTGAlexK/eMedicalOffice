<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLibraryHelp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLibraryHelp))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelPatient = New System.Windows.Forms.Label()
        Me.ToolStripFontSize = New System.Windows.Forms.ToolStrip()
        Me.ButtonDn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonUp = New System.Windows.Forms.ToolStripButton()
        Me.ListViewDocuments = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyReservedWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStripFontSize.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 485)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(753, 34)
        Me.Panel2.TabIndex = 103
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.Location = New System.Drawing.Point(623, 6)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(118, 24)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LabelPatient)
        Me.Panel1.Controls.Add(Me.ToolStripFontSize)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 32)
        Me.Panel1.TabIndex = 104
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(157, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(537, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "COPIED TO CLIPBOARD"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Visible = False
        '
        'LabelPatient
        '
        Me.LabelPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelPatient.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelPatient.Location = New System.Drawing.Point(6, 9)
        Me.LabelPatient.Name = "LabelPatient"
        Me.LabelPatient.Size = New System.Drawing.Size(274, 13)
        Me.LabelPatient.TabIndex = 5
        Me.LabelPatient.Text = "RESERVED WORDS"
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
        Me.ToolStripFontSize.Location = New System.Drawing.Point(697, 5)
        Me.ToolStripFontSize.Name = "ToolStripFontSize"
        Me.ToolStripFontSize.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripFontSize.Size = New System.Drawing.Size(55, 23)
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
        Me.ButtonDn.Size = New System.Drawing.Size(23, 20)
        Me.ButtonDn.ToolTipText = "Font Increase"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'ButtonUp
        '
        Me.ButtonUp.BackColor = System.Drawing.Color.Transparent
        Me.ButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonUp.Image = CType(resources.GetObject("ButtonUp.Image"), System.Drawing.Image)
        Me.ButtonUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonUp.Name = "ButtonUp"
        Me.ButtonUp.Size = New System.Drawing.Size(23, 20)
        Me.ButtonUp.ToolTipText = "Font Decrease"
        '
        'ListViewDocuments
        '
        Me.ListViewDocuments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewDocuments.FullRowSelect = True
        Me.ListViewDocuments.GridLines = True
        Me.ListViewDocuments.Location = New System.Drawing.Point(0, 32)
        Me.ListViewDocuments.MultiSelect = False
        Me.ListViewDocuments.Name = "ListViewDocuments"
        Me.ListViewDocuments.Size = New System.Drawing.Size(753, 453)
        Me.ListViewDocuments.TabIndex = 105
        Me.ListViewDocuments.UseCompatibleStateImageBehavior = False
        Me.ListViewDocuments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Reserved Word"
        Me.ColumnHeader1.Width = 208
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 517
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyReservedWordToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 26)
        '
        'CopyReservedWordToolStripMenuItem
        '
        Me.CopyReservedWordToolStripMenuItem.Image = CType(resources.GetObject("CopyReservedWordToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyReservedWordToolStripMenuItem.Name = "CopyReservedWordToolStripMenuItem"
        Me.CopyReservedWordToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.CopyReservedWordToolStripMenuItem.Text = "Copy Reserved Word"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(6, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 24)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Copy"
        Me.ToolTip1.SetToolTip(Me.Button1, "Copy Reserved Word to Clipboard")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmLibraryHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 519)
        Me.Controls.Add(Me.ListViewDocuments)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(769, 553)
        Me.Name = "frmLibraryHelp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Library Help"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStripFontSize.ResumeLayout(False)
        Me.ToolStripFontSize.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmdClose As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelPatient As Label
    Friend WithEvents ToolStripFontSize As ToolStrip
    Friend WithEvents ButtonDn As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonUp As ToolStripButton
    Friend WithEvents ListViewDocuments As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyReservedWordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
