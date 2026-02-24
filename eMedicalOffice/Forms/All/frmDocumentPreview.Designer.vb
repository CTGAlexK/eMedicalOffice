<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDocumentPreview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentPreview))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDummy = New System.Windows.Forms.TextBox()
        Me.ButtonRotatePDF = New System.Windows.Forms.Button()
        Me.ToolStripFontSize = New System.Windows.Forms.ToolStrip()
        Me.ButtonDn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonUp = New System.Windows.Forms.ToolStripButton()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonFax = New System.Windows.Forms.Button()
        Me.ButtoneMail = New System.Windows.Forms.Button()
        Me.ButtonPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextBoxReading = New System.Windows.Forms.TextBox()
        Me.pdfViewer = New PdfiumViewer.PdfViewer()
        Me.MenuPDFRotate = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.ToolStripFontSize.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuPDFRotate.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txtDummy)
        Me.Panel1.Controls.Add(Me.ButtonRotatePDF)
        Me.Panel1.Controls.Add(Me.ToolStripFontSize)
        Me.Panel1.Controls.Add(Me.Label42)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(715, 32)
        Me.Panel1.TabIndex = 101
        '
        'txtDummy
        '
        Me.txtDummy.Location = New System.Drawing.Point(307, -1000)
        Me.txtDummy.Name = "txtDummy"
        Me.txtDummy.Size = New System.Drawing.Size(100, 20)
        Me.txtDummy.TabIndex = 380
        '
        'ButtonRotatePDF
        '
        Me.ButtonRotatePDF.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonRotatePDF.FlatAppearance.BorderSize = 0
        Me.ButtonRotatePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRotatePDF.Image = CType(resources.GetObject("ButtonRotatePDF.Image"), System.Drawing.Image)
        Me.ButtonRotatePDF.Location = New System.Drawing.Point(691, 0)
        Me.ButtonRotatePDF.Name = "ButtonRotatePDF"
        Me.ButtonRotatePDF.Size = New System.Drawing.Size(24, 32)
        Me.ButtonRotatePDF.TabIndex = 379
        Me.ButtonRotatePDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.ButtonRotatePDF, "Rotate Document")
        Me.ButtonRotatePDF.UseVisualStyleBackColor = True
        '
        'ToolStripFontSize
        '
        Me.ToolStripFontSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStripFontSize.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripFontSize.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripFontSize.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFontSize.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonDn, Me.ToolStripSeparator1, Me.ButtonUp})
        Me.ToolStripFontSize.Location = New System.Drawing.Point(636, 4)
        Me.ToolStripFontSize.Name = "ToolStripFontSize"
        Me.ToolStripFontSize.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripFontSize.Size = New System.Drawing.Size(55, 23)
        Me.ToolStripFontSize.TabIndex = 3
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
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label42.Location = New System.Drawing.Point(12, 9)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(138, 13)
        Me.Label42.TabIndex = 2
        Me.Label42.Text = "DOCUMENT PREVIEW"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.ButtonFax)
        Me.Panel2.Controls.Add(Me.ButtoneMail)
        Me.Panel2.Controls.Add(Me.ButtonPrint)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 568)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(715, 34)
        Me.Panel2.TabIndex = 102
        '
        'ButtonFax
        '
        Me.ButtonFax.Image = CType(resources.GetObject("ButtonFax.Image"), System.Drawing.Image)
        Me.ButtonFax.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFax.Location = New System.Drawing.Point(180, 7)
        Me.ButtonFax.Name = "ButtonFax"
        Me.ButtonFax.Size = New System.Drawing.Size(81, 23)
        Me.ButtonFax.TabIndex = 11
        Me.ButtonFax.Text = "Fax"
        Me.ButtonFax.UseVisualStyleBackColor = True
        '
        'ButtoneMail
        '
        Me.ButtoneMail.Image = CType(resources.GetObject("ButtoneMail.Image"), System.Drawing.Image)
        Me.ButtoneMail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtoneMail.Location = New System.Drawing.Point(93, 7)
        Me.ButtoneMail.Name = "ButtoneMail"
        Me.ButtoneMail.Size = New System.Drawing.Size(81, 23)
        Me.ButtoneMail.TabIndex = 10
        Me.ButtoneMail.Text = "Email"
        Me.ButtoneMail.UseVisualStyleBackColor = True
        '
        'ButtonPrint
        '
        Me.ButtonPrint.Image = CType(resources.GetObject("ButtonPrint.Image"), System.Drawing.Image)
        Me.ButtonPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonPrint.Location = New System.Drawing.Point(12, 7)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPrint.TabIndex = 0
        Me.ButtonPrint.Text = "Print"
        Me.ButtonPrint.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.Location = New System.Drawing.Point(628, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 32)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(715, 2)
        Me.Panel3.TabIndex = 139
        '
        'TextBoxReading
        '
        Me.TextBoxReading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxReading.Location = New System.Drawing.Point(0, 34)
        Me.TextBoxReading.Multiline = True
        Me.TextBoxReading.Name = "TextBoxReading"
        Me.TextBoxReading.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxReading.Size = New System.Drawing.Size(715, 534)
        Me.TextBoxReading.TabIndex = 137
        Me.TextBoxReading.Visible = False
        '
        'pdfViewer
        '
        Me.pdfViewer.ContextMenuStrip = Me.MenuPDFRotate
        Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewer.Location = New System.Drawing.Point(0, 34)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.ShowBookmarks = False
        Me.pdfViewer.Size = New System.Drawing.Size(715, 534)
        Me.pdfViewer.TabIndex = 369
        Me.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth
        '
        'MenuPDFRotate
        '
        Me.MenuPDFRotate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem13, Me.ToolStripMenuItem14, Me.ToolStripMenuItem15, Me.ToolStripMenuItem16})
        Me.MenuPDFRotate.Name = "MenuPDFRotate"
        Me.MenuPDFRotate.ShowImageMargin = False
        Me.MenuPDFRotate.Size = New System.Drawing.Size(73, 92)
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripMenuItem13.Text = "0°"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripMenuItem14.Text = "90°"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripMenuItem15.Text = "180°"
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripMenuItem16.Text = "270°"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 34)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(715, 534)
        Me.RichTextBox1.TabIndex = 370
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 300
        '
        'frmDocumentPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(715, 602)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.TextBoxReading)
        Me.Controls.Add(Me.pdfViewer)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmDocumentPreview"
        Me.Text = "Preview"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStripFontSize.ResumeLayout(False)
        Me.ToolStripFontSize.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.MenuPDFRotate.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents ButtonFax As System.Windows.Forms.Button
    Friend WithEvents ButtoneMail As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripFontSize As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonDn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonUp As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBoxReading As TextBox
    Friend WithEvents pdfViewer As PdfiumViewer.PdfViewer
    Friend WithEvents PrintDialog1 As PrintDialog
    Public WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents ButtonRotatePDF As Button
    Friend WithEvents txtDummy As TextBox
    Friend WithEvents MenuPDFRotate As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem13 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
End Class
