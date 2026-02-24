<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEFiling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEFiling))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.lblWait = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.TimerSearch = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripAutoResize = New System.Windows.Forms.ToolStripButton()
        Me.TimerLoad = New System.Windows.Forms.Timer(Me.components)
        Me.btnChangePath = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.PanelInfo = New System.Windows.Forms.Panel()
        Me.lblNumber = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblinsurance = New System.Windows.Forms.Label()
        Me.lblPatientId = New System.Windows.Forms.Label()
        Me.lblBillId = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListView1 = New eMedicalOffice.ListViewDoubleBuffered()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.PanelInfo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(265, 20)
        Me.TextBox1.TabIndex = 0
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(9, 7)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(122, 23)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Location = New System.Drawing.Point(699, 7)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(122, 23)
        Me.cmdUpdate.TabIndex = 0
        Me.cmdUpdate.Text = "Process Bill"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'lblWait
        '
        Me.lblWait.BackColor = System.Drawing.Color.Transparent
        Me.lblWait.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWait.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblWait.ForeColor = System.Drawing.Color.Black
        Me.lblWait.Location = New System.Drawing.Point(0, 0)
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(826, 32)
        Me.lblWait.TabIndex = 2
        Me.lblWait.Text = "e-File"
        Me.lblWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWait.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(283, 7)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(157, 17)
        Me.RadioButton1.TabIndex = 150
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Search By Name / Payer ID"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New System.Drawing.Point(442, 6)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(102, 17)
        Me.RadioButton2.TabIndex = 151
        Me.RadioButton2.Text = "Search By State"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'TimerSearch
        '
        Me.TimerSearch.Interval = 200
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAutoResize})
        Me.ToolStrip2.Location = New System.Drawing.Point(731, 95)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(47, 25)
        Me.ToolStrip2.TabIndex = 152
        Me.ToolStrip2.Text = "Paid Checked"
        '
        'ToolStripAutoResize
        '
        Me.ToolStripAutoResize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripAutoResize.Name = "ToolStripAutoResize"
        Me.ToolStripAutoResize.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.ToolStripAutoResize.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripAutoResize.ToolTipText = "Autosize Spreads Columns Width"
        '
        'TimerLoad
        '
        Me.TimerLoad.Interval = 200
        '
        'btnChangePath
        '
        Me.btnChangePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangePath.FlatAppearance.BorderSize = 0
        Me.btnChangePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnChangePath.Image = CType(resources.GetObject("btnChangePath.Image"), System.Drawing.Image)
        Me.btnChangePath.Location = New System.Drawing.Point(787, 3)
        Me.btnChangePath.Name = "btnChangePath"
        Me.btnChangePath.Size = New System.Drawing.Size(33, 26)
        Me.btnChangePath.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnChangePath, "Select Output Folder")
        Me.btnChangePath.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.btnChangePath)
        Me.Panel3.Controls.Add(Me.RadioButton1)
        Me.Panel3.Controls.Add(Me.RadioButton2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(826, 32)
        Me.Panel3.TabIndex = 153
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Panel4.Controls.Add(Me.ProgressBar1)
        Me.Panel4.Controls.Add(Me.PanelInfo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(826, 31)
        Me.Panel4.TabIndex = 154
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.White
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 27)
        Me.ProgressBar1.MarqueeAnimationSpeed = 0
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(826, 4)
        Me.ProgressBar1.TabIndex = 161
        '
        'PanelInfo
        '
        Me.PanelInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.PanelInfo.Controls.Add(Me.lblNumber)
        Me.PanelInfo.Controls.Add(Me.Label2)
        Me.PanelInfo.Controls.Add(Me.lblinsurance)
        Me.PanelInfo.Controls.Add(Me.lblPatientId)
        Me.PanelInfo.Controls.Add(Me.lblBillId)
        Me.PanelInfo.Controls.Add(Me.Label5)
        Me.PanelInfo.Controls.Add(Me.Label3)
        Me.PanelInfo.Controls.Add(Me.Label1)
        Me.PanelInfo.Controls.Add(Me.lblType)
        Me.PanelInfo.Location = New System.Drawing.Point(3, 0)
        Me.PanelInfo.Name = "PanelInfo"
        Me.PanelInfo.Size = New System.Drawing.Size(823, 27)
        Me.PanelInfo.TabIndex = 147
        '
        'lblNumber
        '
        Me.lblNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblNumber.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblNumber.ForeColor = System.Drawing.Color.White
        Me.lblNumber.Location = New System.Drawing.Point(746, 5)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(73, 17)
        Me.lblNumber.TabIndex = 11
        Me.lblNumber.Text = "Count"
        Me.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(88, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Type:"
        '
        'lblinsurance
        '
        Me.lblinsurance.AutoSize = True
        Me.lblinsurance.BackColor = System.Drawing.Color.Transparent
        Me.lblinsurance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblinsurance.ForeColor = System.Drawing.Color.White
        Me.lblinsurance.Location = New System.Drawing.Point(350, 5)
        Me.lblinsurance.Name = "lblinsurance"
        Me.lblinsurance.Size = New System.Drawing.Size(63, 17)
        Me.lblinsurance.TabIndex = 8
        Me.lblinsurance.Text = "Insurance"
        '
        'lblPatientId
        '
        Me.lblPatientId.AutoSize = True
        Me.lblPatientId.BackColor = System.Drawing.Color.Transparent
        Me.lblPatientId.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblPatientId.ForeColor = System.Drawing.Color.White
        Me.lblPatientId.Location = New System.Drawing.Point(227, 5)
        Me.lblPatientId.Name = "lblPatientId"
        Me.lblPatientId.Size = New System.Drawing.Size(57, 17)
        Me.lblPatientId.TabIndex = 6
        Me.lblPatientId.Text = "9999999"
        '
        'lblBillId
        '
        Me.lblBillId.AutoSize = True
        Me.lblBillId.BackColor = System.Drawing.Color.Transparent
        Me.lblBillId.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblBillId.ForeColor = System.Drawing.Color.White
        Me.lblBillId.Location = New System.Drawing.Point(35, 5)
        Me.lblBillId.Name = "lblBillId"
        Me.lblBillId.Size = New System.Drawing.Size(50, 17)
        Me.lblBillId.TabIndex = 5
        Me.lblBillId.Text = "999999"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(284, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Insurance:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(167, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Patient ID:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bill #"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.BackColor = System.Drawing.Color.Transparent
        Me.lblType.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblType.ForeColor = System.Drawing.Color.White
        Me.lblType.Location = New System.Drawing.Point(125, 5)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(35, 17)
        Me.lblType.TabIndex = 10
        Me.lblType.Text = "Type"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(568, 10)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(118, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "All Bills Same Payer"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.cmdClose)
        Me.Panel1.Controls.Add(Me.cmdUpdate)
        Me.Panel1.Controls.Add(Me.lblWait)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 361)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(826, 32)
        Me.Panel1.TabIndex = 155
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 63)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(826, 298)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Payer Name"
        Me.ColumnHeader1.Width = 187
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Payer ID"
        Me.ColumnHeader2.Width = 64
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "States"
        Me.ColumnHeader3.Width = 129
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Professional"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Institutional"
        Me.ColumnHeader5.Width = 63
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "PharmacyRx"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "WorkComp"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Automotive"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "835/EOB"
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(257, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(16, 14)
        Me.Button1.TabIndex = 152
        Me.ToolTip1.SetToolTip(Me.Button1, "Reload")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmEFiling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 393)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEFiling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "e-File"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.PanelInfo.ResumeLayout(False)
        Me.PanelInfo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ListView1 As ListViewDoubleBuffered
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdUpdate As Button
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents TimerSearch As Timer
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ToolStripAutoResize As ToolStripButton
    Friend WithEvents lblWait As Label
    Friend WithEvents TimerLoad As Timer
    Friend WithEvents btnChangePath As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PanelInfo As Panel
    Friend WithEvents lblType As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblinsurance As Label
    Friend WithEvents lblPatientId As Label
    Friend WithEvents lblBillId As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNumber As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button
End Class
