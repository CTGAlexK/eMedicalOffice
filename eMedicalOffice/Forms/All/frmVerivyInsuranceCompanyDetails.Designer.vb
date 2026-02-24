<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerivyInsuranceCompanyDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVerivyInsuranceCompanyDetails))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.lblInsurance = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblAdjusterContact = New System.Windows.Forms.Label()
        Me.lblInsuranceContact = New System.Windows.Forms.Label()
        Me.lblAdjuster = New System.Windows.Forms.Label()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPolicyNumber = New System.Windows.Forms.TextBox()
        Me.txtClaimNumber = New System.Windows.Forms.TextBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtCommentsNew = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(505, 34)
        Me.Panel1.TabIndex = 251
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(467, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Patient Insurance Information"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 419)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(505, 34)
        Me.Panel2.TabIndex = 252
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(396, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(106, 23)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Location = New System.Drawing.Point(8, 6)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(106, 23)
        Me.cmdAdd.TabIndex = 1
        Me.cmdAdd.Text = "Update"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'lblInsurance
        '
        Me.lblInsurance.AutoSize = True
        Me.lblInsurance.BackColor = System.Drawing.Color.Transparent
        Me.lblInsurance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblInsurance.ForeColor = System.Drawing.Color.White
        Me.lblInsurance.Location = New System.Drawing.Point(12, 28)
        Me.lblInsurance.Name = "lblInsurance"
        Me.lblInsurance.Size = New System.Drawing.Size(39, 13)
        Me.lblInsurance.TabIndex = 253
        Me.lblInsurance.Text = "Label2"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblAdjusterContact)
        Me.Panel3.Controls.Add(Me.lblInsuranceContact)
        Me.Panel3.Controls.Add(Me.lblAdjuster)
        Me.Panel3.Controls.Add(Me.lblPatient)
        Me.Panel3.Controls.Add(Me.lblInsurance)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 34)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(505, 101)
        Me.Panel3.TabIndex = 254
        '
        'lblAdjusterContact
        '
        Me.lblAdjusterContact.AutoSize = True
        Me.lblAdjusterContact.BackColor = System.Drawing.Color.Transparent
        Me.lblAdjusterContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblAdjusterContact.ForeColor = System.Drawing.Color.White
        Me.lblAdjusterContact.Location = New System.Drawing.Point(12, 80)
        Me.lblAdjusterContact.Name = "lblAdjusterContact"
        Me.lblAdjusterContact.Size = New System.Drawing.Size(39, 13)
        Me.lblAdjusterContact.TabIndex = 257
        Me.lblAdjusterContact.Text = "Label2"
        '
        'lblInsuranceContact
        '
        Me.lblInsuranceContact.AutoSize = True
        Me.lblInsuranceContact.BackColor = System.Drawing.Color.Transparent
        Me.lblInsuranceContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblInsuranceContact.ForeColor = System.Drawing.Color.White
        Me.lblInsuranceContact.Location = New System.Drawing.Point(12, 44)
        Me.lblInsuranceContact.Name = "lblInsuranceContact"
        Me.lblInsuranceContact.Size = New System.Drawing.Size(39, 13)
        Me.lblInsuranceContact.TabIndex = 256
        Me.lblInsuranceContact.Text = "Label2"
        '
        'lblAdjuster
        '
        Me.lblAdjuster.AutoSize = True
        Me.lblAdjuster.BackColor = System.Drawing.Color.Transparent
        Me.lblAdjuster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblAdjuster.ForeColor = System.Drawing.Color.White
        Me.lblAdjuster.Location = New System.Drawing.Point(12, 64)
        Me.lblAdjuster.Name = "lblAdjuster"
        Me.lblAdjuster.Size = New System.Drawing.Size(39, 13)
        Me.lblAdjuster.TabIndex = 255
        Me.lblAdjuster.Text = "Label2"
        '
        'lblPatient
        '
        Me.lblPatient.AutoSize = True
        Me.lblPatient.BackColor = System.Drawing.Color.Transparent
        Me.lblPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblPatient.ForeColor = System.Drawing.Color.White
        Me.lblPatient.Location = New System.Drawing.Point(12, 8)
        Me.lblPatient.Name = "lblPatient"
        Me.lblPatient.Size = New System.Drawing.Size(39, 13)
        Me.lblPatient.TabIndex = 254
        Me.lblPatient.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(8, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 255
        Me.Label2.Text = "Policy Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(230, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Claim Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(8, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 257
        Me.Label4.Text = "Comments"
        '
        'txtPolicyNumber
        '
        Me.txtPolicyNumber.Location = New System.Drawing.Point(8, 164)
        Me.txtPolicyNumber.MaxLength = 20
        Me.txtPolicyNumber.Name = "txtPolicyNumber"
        Me.txtPolicyNumber.Size = New System.Drawing.Size(219, 20)
        Me.txtPolicyNumber.TabIndex = 258
        '
        'txtClaimNumber
        '
        Me.txtClaimNumber.Location = New System.Drawing.Point(233, 164)
        Me.txtClaimNumber.MaxLength = 50
        Me.txtClaimNumber.Name = "txtClaimNumber"
        Me.txtClaimNumber.Size = New System.Drawing.Size(260, 20)
        Me.txtClaimNumber.TabIndex = 259
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtComments.Location = New System.Drawing.Point(8, 203)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ReadOnly = True
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(487, 96)
        Me.txtComments.TabIndex = 260
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.DarkGreen
        Me.CheckBox1.Image = CType(resources.GetObject("CheckBox1.Image"), System.Drawing.Image)
        Me.CheckBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(356, 393)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(144, 26)
        Me.CheckBox1.TabIndex = 261
        Me.CheckBox1.Text = "Insurance Verified"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'txtCommentsNew
        '
        Me.txtCommentsNew.BackColor = System.Drawing.Color.White
        Me.txtCommentsNew.Location = New System.Drawing.Point(8, 305)
        Me.txtCommentsNew.Multiline = True
        Me.txtCommentsNew.Name = "txtCommentsNew"
        Me.txtCommentsNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCommentsNew.Size = New System.Drawing.Size(487, 84)
        Me.txtCommentsNew.TabIndex = 262
        '
        'frmVerivyInsuranceCompanyDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(505, 453)
        Me.Controls.Add(Me.txtCommentsNew)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.txtClaimNumber)
        Me.Controls.Add(Me.txtPolicyNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmVerivyInsuranceCompanyDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Patient Details"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents lblInsurance As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblAdjuster As System.Windows.Forms.Label
    Friend WithEvents lblPatient As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtClaimNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtCommentsNew As System.Windows.Forms.TextBox
    Friend WithEvents lblAdjusterContact As System.Windows.Forms.Label
    Friend WithEvents lblInsuranceContact As System.Windows.Forms.Label
End Class
