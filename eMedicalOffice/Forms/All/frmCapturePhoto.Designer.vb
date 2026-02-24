<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturePhoto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturePhoto))
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.sfdImage = New System.Windows.Forms.SaveFileDialog()
        Me.lstDevices = New System.Windows.Forms.ComboBox()
        Me.picSave = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblImageSize = New System.Windows.Forms.Label()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.HScrollBarZoom = New System.Windows.Forms.HScrollBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelMsg = New System.Windows.Forms.Label()
        Me.PictureBoxCapture = New System.Windows.Forms.PictureBox()
        Me.PictureBoxSave = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.HScrollBarBrightness = New System.Windows.Forms.HScrollBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonSettings = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeviceSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompresionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkTimeStamp = New System.Windows.Forms.CheckBox()
        CType(Me.picCapture,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picSave,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel2.SuspendLayout
        Me.Panel1.SuspendLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBoxCapture,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBoxSave,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ButtonSettings,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ContextMenuStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'picCapture
        '
        Me.picCapture.BackColor = System.Drawing.Color.White
        Me.picCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCapture.Image = CType(resources.GetObject("picCapture.Image"),System.Drawing.Image)
        Me.picCapture.Location = New System.Drawing.Point(6, 78)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(320, 242)
        Me.picCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picCapture.TabIndex = 1
        Me.picCapture.TabStop = false
        '
        'btnSave
        '
        Me.btnSave.Enabled = false
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"),System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.Location = New System.Drawing.Point(332, 78)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 215)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Capture Photo"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"F2"
        Me.ToolTip1.SetToolTip(Me.btnSave, "Capture Image")
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'lstDevices
        '
        Me.lstDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstDevices.FormattingEnabled = true
        Me.lstDevices.Location = New System.Drawing.Point(6, 52)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(320, 21)
        Me.lstDevices.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.lstDevices, "Select Capture Device")
        '
        'picSave
        '
        Me.picSave.BackColor = System.Drawing.Color.White
        Me.picSave.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSave.Location = New System.Drawing.Point(421, 78)
        Me.picSave.Name = "picSave"
        Me.picSave.Size = New System.Drawing.Size(320, 242)
        Me.picSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picSave.TabIndex = 7
        Me.picSave.TabStop = false
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"),System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Controls.Add(Me.lblImageSize)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 337)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(765, 34)
        Me.Panel2.TabIndex = 150
        '
        'lblImageSize
        '
        Me.lblImageSize.AutoSize = true
        Me.lblImageSize.BackColor = System.Drawing.Color.Transparent
        Me.lblImageSize.Location = New System.Drawing.Point(423, 11)
        Me.lblImageSize.Name = "lblImageSize"
        Me.lblImageSize.Size = New System.Drawing.Size(0, 13)
        Me.lblImageSize.TabIndex = 2
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.ForeColor = System.Drawing.Color.Black
        Me.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUpdate.Location = New System.Drawing.Point(683, 6)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 1
        Me.cmdUpdate.Text = "&Update"
        Me.ToolTip1.SetToolTip(Me.cmdUpdate, "Update Patient's Profile")
        Me.cmdUpdate.UseVisualStyleBackColor = true
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(6, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.cmdCancel, "Cancel")
        Me.cmdCancel.UseVisualStyleBackColor = false
        '
        'HScrollBarZoom
        '
        Me.HScrollBarZoom.Enabled = false
        Me.HScrollBarZoom.LargeChange = 1
        Me.HScrollBarZoom.Location = New System.Drawing.Point(421, 52)
        Me.HScrollBarZoom.Maximum = 200
        Me.HScrollBarZoom.Minimum = 100
        Me.HScrollBarZoom.Name = "HScrollBarZoom"
        Me.HScrollBarZoom.Size = New System.Drawing.Size(155, 21)
        Me.HScrollBarZoom.TabIndex = 151
        Me.ToolTip1.SetToolTip(Me.HScrollBarZoom, "Zoom Image")
        Me.HScrollBarZoom.Value = 100
        '
        'Timer1
        '
        Me.Timer1.Enabled = true
        Me.Timer1.Interval = 500
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(765, 34)
        Me.Panel1.TabIndex = 152
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"),System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(727, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = false
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PATIENT'S PHOTO"
        '
        'LabelMsg
        '
        Me.LabelMsg.BackColor = System.Drawing.Color.White
        Me.LabelMsg.Location = New System.Drawing.Point(12, 294)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(303, 18)
        Me.LabelMsg.TabIndex = 153
        Me.LabelMsg.Text = "Select the Capture Devise"
        Me.LabelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBoxCapture
        '
        Me.PictureBoxCapture.BackColor = System.Drawing.Color.White
        Me.PictureBoxCapture.Location = New System.Drawing.Point(421, 78)
        Me.PictureBoxCapture.Name = "PictureBoxCapture"
        Me.PictureBoxCapture.Size = New System.Drawing.Size(318, 242)
        Me.PictureBoxCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxCapture.TabIndex = 2
        Me.PictureBoxCapture.TabStop = False
        Me.PictureBoxCapture.Visible = False
        '
        'PictureBoxSave
        '
        Me.PictureBoxSave.Location = New System.Drawing.Point(419, 375)
        Me.PictureBoxSave.Name = "PictureBoxSave"
        Me.PictureBoxSave.Size = New System.Drawing.Size(320, 242)
        Me.PictureBoxSave.TabIndex = 154
        Me.PictureBoxSave.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(423, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 155
        Me.Label2.Text = "Zoom +"
        '
        'HScrollBarBrightness
        '
        Me.HScrollBarBrightness.Enabled = False
        Me.HScrollBarBrightness.Location = New System.Drawing.Point(584, 52)
        Me.HScrollBarBrightness.Minimum = -100
        Me.HScrollBarBrightness.Name = "HScrollBarBrightness"
        Me.HScrollBarBrightness.Size = New System.Drawing.Size(155, 21)
        Me.HScrollBarBrightness.TabIndex = 156
        Me.ToolTip1.SetToolTip(Me.HScrollBarBrightness, "Adjust Brightness")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(581, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 157
        Me.Label3.Text = "Brightness"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(3, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 158
        Me.Label4.Text = "Capture Devise"
        '
        'ButtonSettings
        '
        Me.ButtonSettings.BackColor = System.Drawing.Color.Transparent
        Me.ButtonSettings.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ButtonSettings.Enabled = False
        Me.ButtonSettings.Image = CType(resources.GetObject("ButtonSettings.Image"), System.Drawing.Image)
        Me.ButtonSettings.Location = New System.Drawing.Point(332, 52)
        Me.ButtonSettings.Name = "ButtonSettings"
        Me.ButtonSettings.Size = New System.Drawing.Size(83, 21)
        Me.ButtonSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ButtonSettings.TabIndex = 159
        Me.ButtonSettings.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ButtonSettings, "Camera Settings")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeviceSettingsToolStripMenuItem, Me.CompresionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(155, 48)
        '
        'DeviceSettingsToolStripMenuItem
        '
        Me.DeviceSettingsToolStripMenuItem.Name = "DeviceSettingsToolStripMenuItem"
        Me.DeviceSettingsToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.DeviceSettingsToolStripMenuItem.Text = "Device Settings"
        '
        'CompresionToolStripMenuItem
        '
        Me.CompresionToolStripMenuItem.Name = "CompresionToolStripMenuItem"
        Me.CompresionToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.CompresionToolStripMenuItem.Text = "Video Format"
        '
        'chkTimeStamp
        '
        Me.chkTimeStamp.AutoSize = True
        Me.chkTimeStamp.BackColor = System.Drawing.Color.Transparent
        Me.chkTimeStamp.Location = New System.Drawing.Point(335, 299)
        Me.chkTimeStamp.Name = "chkTimeStamp"
        Me.chkTimeStamp.Size = New System.Drawing.Size(82, 17)
        Me.chkTimeStamp.TabIndex = 160
        Me.chkTimeStamp.Text = "Time Stamp"
        Me.ToolTip1.SetToolTip(Me.chkTimeStamp, "Time Stamp Photos")
        Me.chkTimeStamp.UseVisualStyleBackColor = False
        '
        'frmCapturePhoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(765, 371)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkTimeStamp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.HScrollBarBrightness)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBoxCapture)
        Me.Controls.Add(Me.LabelMsg)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.HScrollBarZoom)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.picSave)
        Me.Controls.Add(Me.ButtonSettings)
        Me.Controls.Add(Me.lstDevices)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.picCapture)
        Me.Controls.Add(Me.PictureBoxSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = true
        Me.Name = "frmCapturePhoto"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Capture Photo"
        CType(Me.picCapture,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picSave,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBoxCapture,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBoxSave,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ButtonSettings,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStrip1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents picCapture As System.Windows.Forms.PictureBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents sfdImage As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lstDevices As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents HScrollBarZoom As System.Windows.Forms.HScrollBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents lblImageSize As System.Windows.Forms.Label
    Friend WithEvents PictureBoxSave As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents HScrollBarBrightness As System.Windows.Forms.HScrollBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonSettings As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeviceSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompresionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkTimeStamp As System.Windows.Forms.CheckBox
    Public WithEvents PictureBoxCapture As PictureBox
    Public WithEvents picSave As PictureBox
End Class
