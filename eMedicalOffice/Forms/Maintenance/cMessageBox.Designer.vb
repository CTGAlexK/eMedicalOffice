<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cMessageBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cMessageBox))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonYes = New System.Windows.Forms.Button()
        Me.PictureBoxSign = New System.Windows.Forms.PictureBox()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.LabelMessage = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout
        CType(Me.PictureBoxSign,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Controls.Add(Me.ButtonCancel)
        Me.Panel1.Controls.Add(Me.ButtonYes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 313)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(643, 42)
        Me.Panel1.TabIndex = 0
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.DimGray
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.FlatAppearance.BorderSize = 0
        Me.ButtonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.ButtonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonCancel.ForeColor = System.Drawing.Color.White
        Me.ButtonCancel.Location = New System.Drawing.Point(518, 5)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(114, 32)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "No Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonYes
        '
        Me.ButtonYes.BackColor = System.Drawing.Color.DimGray
        Me.ButtonYes.FlatAppearance.BorderSize = 0
        Me.ButtonYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.ButtonYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonYes.ForeColor = System.Drawing.Color.White
        Me.ButtonYes.Location = New System.Drawing.Point(398, 5)
        Me.ButtonYes.Name = "ButtonYes"
        Me.ButtonYes.Size = New System.Drawing.Size(114, 32)
        Me.ButtonYes.TabIndex = 0
        Me.ButtonYes.Text = "Yes Continue"
        Me.ButtonYes.UseVisualStyleBackColor = False
        '
        'PictureBoxSign
        '
        Me.PictureBoxSign.Image = CType(resources.GetObject("PictureBoxSign.Image"), System.Drawing.Image)
        Me.PictureBoxSign.Location = New System.Drawing.Point(22, 22)
        Me.PictureBoxSign.Name = "PictureBoxSign"
        Me.PictureBoxSign.Size = New System.Drawing.Size(32, 32)
        Me.PictureBoxSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxSign.TabIndex = 1
        Me.PictureBoxSign.TabStop = False
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.White
        Me.LabelTitle.Location = New System.Drawing.Point(60, 29)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(105, 24)
        Me.LabelTitle.TabIndex = 2
        Me.LabelTitle.Text = "WARNING!"
        '
        'LabelMessage
        '
        Me.LabelMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelMessage.ForeColor = System.Drawing.Color.White
        Me.LabelMessage.Location = New System.Drawing.Point(66, 69)
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.Size = New System.Drawing.Size(565, 227)
        Me.LabelMessage.TabIndex = 3
        Me.LabelMessage.Text = "Label1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'cMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(643, 355)
        Me.ControlBox = false
        Me.Controls.Add(Me.LabelMessage)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxSign)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "cMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(false)
        CType(Me.PictureBoxSign,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBoxSign As PictureBox
    Public WithEvents LabelTitle As Label
    Public WithEvents LabelMessage As Label
    Friend WithEvents Timer1 As Timer
    Public WithEvents ButtonCancel As Button
    Public WithEvents ButtonYes As Button
End Class
