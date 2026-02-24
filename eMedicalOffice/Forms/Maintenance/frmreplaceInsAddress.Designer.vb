<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReplaceInsAddress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReplaceInsAddress))
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtNumberOfBills = New System.Windows.Forms.TextBox()
        Me.txtNewCode = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtOldCode = New System.Windows.Forms.TextBox()
        Me.txtOldAddress = New System.Windows.Forms.TextBox()
        Me.txtNewAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(9, 56)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(114, 13)
        Me.Label28.TabIndex = 198
        Me.Label28.Text = "Old Insurance Address"
        '
        'txtNumberOfBills
        '
        Me.txtNumberOfBills.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtNumberOfBills.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtNumberOfBills.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNumberOfBills.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfBills.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.txtNumberOfBills, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtNumberOfBills.Location = New System.Drawing.Point(660, 45)
        Me.txtNumberOfBills.MaxLength = 250
        Me.txtNumberOfBills.Name = "txtNumberOfBills"
        Me.txtNumberOfBills.ReadOnly = True
        Me.txtNumberOfBills.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNumberOfBills.Size = New System.Drawing.Size(101, 20)
        Me.txtNumberOfBills.TabIndex = 2
        Me.txtNumberOfBills.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNewCode
        '
        Me.txtNewCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtNewCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtNewCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewCode.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.txtNewCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtNewCode.Location = New System.Drawing.Point(12, 116)
        Me.txtNewCode.MaxLength = 50
        Me.txtNewCode.Name = "txtNewCode"
        Me.txtNewCode.Size = New System.Drawing.Size(77, 20)
        Me.txtNewCode.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(771, 39)
        Me.Panel1.TabIndex = 203
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(722, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Maroon
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(771, 2)
        Me.Panel3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Replace Bill Insurance Addresses"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(771, 34)
        Me.Panel2.TabIndex = 204
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(687, 6)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Location = New System.Drawing.Point(606, 6)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 0
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtOldCode
        '
        Me.ErrorProvider1.SetIconAlignment(Me.txtOldCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtOldCode.Location = New System.Drawing.Point(12, 72)
        Me.txtOldCode.MaxLength = 10
        Me.txtOldCode.Name = "txtOldCode"
        Me.txtOldCode.Size = New System.Drawing.Size(77, 20)
        Me.txtOldCode.TabIndex = 0
        '
        'txtOldAddress
        '
        Me.txtOldAddress.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ErrorProvider1.SetIconAlignment(Me.txtOldAddress, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtOldAddress.Location = New System.Drawing.Point(95, 72)
        Me.txtOldAddress.MaxLength = 10
        Me.txtOldAddress.Name = "txtOldAddress"
        Me.txtOldAddress.ReadOnly = True
        Me.txtOldAddress.Size = New System.Drawing.Size(666, 20)
        Me.txtOldAddress.TabIndex = 207
        '
        'txtNewAddress
        '
        Me.txtNewAddress.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ErrorProvider1.SetIconAlignment(Me.txtNewAddress, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtNewAddress.Location = New System.Drawing.Point(95, 116)
        Me.txtNewAddress.MaxLength = 10
        Me.txtNewAddress.Name = "txtNewAddress"
        Me.txtNewAddress.ReadOnly = True
        Me.txtNewAddress.Size = New System.Drawing.Size(666, 20)
        Me.txtNewAddress.TabIndex = 208
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "New Insurance Address"
        '
        'frmReplaceInsAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(771, 180)
        Me.Controls.Add(Me.txtNewAddress)
        Me.Controls.Add(Me.txtOldAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOldCode)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtNumberOfBills)
        Me.Controls.Add(Me.txtNewCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReplaceInsAddress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrative Function"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfBills As System.Windows.Forms.TextBox
    Friend WithEvents txtNewCode As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtOldCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOldAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtNewAddress As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
