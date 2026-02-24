<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillingLitigationArbitrationComments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillingLitigationArbitrationComments))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxComment = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListViewPatients = New System.Windows.Forms.ListView()
        Me.BillID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BillDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CurrentStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PatientNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PatientName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Insurance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxAttorneys = New System.Windows.Forms.ComboBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 432)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(827, 34)
        Me.Panel2.TabIndex = 143
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(7, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Location = New System.Drawing.Point(725, 5)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(96, 23)
        Me.cmdUpdate.TabIndex = 0
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(827, 35)
        Me.Panel1.TabIndex = 144
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "BILL NOTES"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(781, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(46, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(9, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BILL NOTES"
        '
        'TextBoxComment
        '
        Me.TextBoxComment.Location = New System.Drawing.Point(7, 284)
        Me.TextBoxComment.MaxLength = 2000
        Me.TextBoxComment.Multiline = True
        Me.TextBoxComment.Name = "TextBoxComment"
        Me.TextBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxComment.Size = New System.Drawing.Size(811, 142)
        Me.TextBoxComment.TabIndex = 145
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Firebrick
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(827, 19)
        Me.Panel3.TabIndex = 146
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(459, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ATTENTION! THIS FUNCTION CAN BE USED BY BILLING COLLECTOR ONLY!"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ListViewPatients
        '
        Me.ListViewPatients.AllowColumnReorder = True
        Me.ListViewPatients.BackColor = System.Drawing.Color.White
        Me.ListViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.BillID, Me.BillDT, Me.CurrentStatus, Me.PatientNo, Me.PatientName, Me.Insurance})
        Me.ListViewPatients.FullRowSelect = True
        Me.ListViewPatients.GridLines = True
        Me.ListViewPatients.HideSelection = False
        Me.ListViewPatients.LabelWrap = False
        Me.ListViewPatients.Location = New System.Drawing.Point(7, 62)
        Me.ListViewPatients.Margin = New System.Windows.Forms.Padding(0)
        Me.ListViewPatients.MultiSelect = False
        Me.ListViewPatients.Name = "ListViewPatients"
        Me.ListViewPatients.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListViewPatients.ShowGroups = False
        Me.ListViewPatients.ShowItemToolTips = True
        Me.ListViewPatients.Size = New System.Drawing.Size(811, 166)
        Me.ListViewPatients.TabIndex = 147
        Me.ListViewPatients.UseCompatibleStateImageBehavior = False
        Me.ListViewPatients.View = System.Windows.Forms.View.Details
        '
        'BillID
        '
        Me.BillID.Text = "Bill #"
        '
        'BillDT
        '
        Me.BillDT.Text = "Bill DT"
        Me.BillDT.Width = 106
        '
        'CurrentStatus
        '
        Me.CurrentStatus.Text = "Status"
        Me.CurrentStatus.Width = 87
        '
        'PatientNo
        '
        Me.PatientNo.Text = "Patient #"
        Me.PatientNo.Width = 84
        '
        'PatientName
        '
        Me.PatientName.Text = "Name"
        Me.PatientName.Width = 228
        '
        'Insurance
        '
        Me.Insurance.Text = "Insurance"
        Me.Insurance.Width = 192
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(4, 268)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 148
        Me.Label4.Text = "Comments"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(4, 228)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = "Attorneys"
        '
        'ComboBoxAttorneys
        '
        Me.ComboBoxAttorneys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAttorneys.FormattingEnabled = True
        Me.ComboBoxAttorneys.Location = New System.Drawing.Point(7, 244)
        Me.ComboBoxAttorneys.Name = "ComboBoxAttorneys"
        Me.ComboBoxAttorneys.Size = New System.Drawing.Size(808, 21)
        Me.ComboBoxAttorneys.TabIndex = 149
        '
        'frmBillingLitigationArbitrationComments
        '
        Me.AcceptButton = Me.cmdUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(827, 466)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBoxAttorneys)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListViewPatients)
        Me.Controls.Add(Me.TextBoxComment)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmBillingLitigationArbitrationComments"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Bill Status Comments"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxComment As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListViewPatients As System.Windows.Forms.ListView
    Friend WithEvents PatientNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents PatientName As System.Windows.Forms.ColumnHeader
    Friend WithEvents BillID As System.Windows.Forms.ColumnHeader
    Friend WithEvents BillDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents Insurance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CurrentStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxAttorneys As System.Windows.Forms.ComboBox
End Class
