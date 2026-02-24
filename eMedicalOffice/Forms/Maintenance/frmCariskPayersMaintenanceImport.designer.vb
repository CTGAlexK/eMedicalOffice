<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCariskPayersMaintenanceImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCariskPayersMaintenanceImport))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnImport = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picArrow = New System.Windows.Forms.PictureBox()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.lblWait = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblMultipleOffices = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.picArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader9, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 38)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(943, 356)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DisplayIndex = 2
        Me.ColumnHeader1.Text = "Payer Name"
        Me.ColumnHeader1.Width = 223
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.DisplayIndex = 3
        Me.ColumnHeader9.Text = "PayerId"
        Me.ColumnHeader9.Width = 96
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DisplayIndex = 4
        Me.ColumnHeader2.Text = "States"
        Me.ColumnHeader2.Width = 98
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 5
        Me.ColumnHeader3.Text = "Professional"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 6
        Me.ColumnHeader4.Text = "Institutional"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 7
        Me.ColumnHeader5.Text = "PharmacyRx"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DisplayIndex = 8
        Me.ColumnHeader6.Text = "WorkComp"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DisplayIndex = 9
        Me.ColumnHeader7.Text = "Automotive"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.DisplayIndex = 10
        Me.ColumnHeader8.Text = "835/EOB"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.DisplayIndex = 1
        Me.ColumnHeader10.Text = "Action"
        Me.ColumnHeader10.Width = 76
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.DisplayIndex = 0
        Me.ColumnHeader11.Text = "Row"
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(10, 4)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(95, 23)
        Me.btnImport.TabIndex = 2
        Me.btnImport.Text = "Load File"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Carisk-Payers xlsx file|Carisk-Payers.xlsx"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnImport)
        Me.Panel1.Controls.Add(Me.picArrow)
        Me.Panel1.Controls.Add(Me.cmdUpdate)
        Me.Panel1.Controls.Add(Me.lblWait)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 394)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(943, 32)
        Me.Panel1.TabIndex = 156
        '
        'picArrow
        '
        Me.picArrow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picArrow.BackColor = System.Drawing.Color.Transparent
        Me.picArrow.Image = CType(resources.GetObject("picArrow.Image"), System.Drawing.Image)
        Me.picArrow.Location = New System.Drawing.Point(773, 10)
        Me.picArrow.Name = "picArrow"
        Me.picArrow.Size = New System.Drawing.Size(40, 12)
        Me.picArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picArrow.TabIndex = 4
        Me.picArrow.TabStop = False
        Me.picArrow.Visible = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Location = New System.Drawing.Point(816, 4)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(119, 23)
        Me.cmdUpdate.TabIndex = 0
        Me.cmdUpdate.Text = "Update Database"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'lblWait
        '
        Me.lblWait.BackColor = System.Drawing.Color.Transparent
        Me.lblWait.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWait.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblWait.ForeColor = System.Drawing.Color.White
        Me.lblWait.Location = New System.Drawing.Point(0, 0)
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(943, 32)
        Me.lblWait.TabIndex = 3
        Me.lblWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Maroon
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.lblMultipleOffices)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(943, 34)
        Me.Panel4.TabIndex = 157
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(905, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 164
        Me.PictureBox1.TabStop = False
        '
        'lblMultipleOffices
        '
        Me.lblMultipleOffices.BackColor = System.Drawing.Color.Transparent
        Me.lblMultipleOffices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblMultipleOffices.ForeColor = System.Drawing.Color.White
        Me.lblMultipleOffices.Location = New System.Drawing.Point(469, 12)
        Me.lblMultipleOffices.Name = "lblMultipleOffices"
        Me.lblMultipleOffices.Size = New System.Drawing.Size(325, 13)
        Me.lblMultipleOffices.TabIndex = 163
        Me.lblMultipleOffices.Text = "Update All Offices"
        Me.lblMultipleOffices.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(341, 13)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "ADMINISTRATIVE FUNCTION - CARISK PAYERS IMPORT"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.White
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 34)
        Me.ProgressBar1.MarqueeAnimationSpeed = 0
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(943, 4)
        Me.ProgressBar1.TabIndex = 161
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        Me.ToolTip1.ShowAlways = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'frmCariskPayersMaintenanceImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 426)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCariskPayersMaintenanceImport"
        Me.Opacity = 0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carisk Payers Maintenance - Import"
        Me.Panel1.ResumeLayout(False)
        CType(Me.picArrow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents btnImport As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdUpdate As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents lblWait As Label
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents picArrow As PictureBox
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents lblMultipleOffices As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ColumnHeader11 As ColumnHeader
End Class
