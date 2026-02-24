<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportPatients
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportPatients))
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.PanelConnection = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataSource = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ListViewPatients = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImportPatientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetPatientIndicatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.imgWait1 = New System.Windows.Forms.PictureBox()
        Me.PanelConnection.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.imgWait1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(5, 4)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(101, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(148, 4)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(101, 23)
        Me.cmdPrint.TabIndex = 10
        Me.cmdPrint.Text = "Print List"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdCopy
        '
        Me.cmdCopy.Enabled = False
        Me.cmdCopy.Location = New System.Drawing.Point(277, 4)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(101, 23)
        Me.cmdCopy.TabIndex = 1
        Me.cmdCopy.Text = "Import Patient"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.Location = New System.Drawing.Point(62, 85)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(191, 13)
        Me.lblCount.TabIndex = 9
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelConnection
        '
        Me.PanelConnection.BackColor = System.Drawing.Color.White
        Me.PanelConnection.Controls.Add(Me.imgWait1)
        Me.PanelConnection.Controls.Add(Me.lblCount)
        Me.PanelConnection.Controls.Add(Me.lblStatus)
        Me.PanelConnection.Controls.Add(Me.Button1)
        Me.PanelConnection.Controls.Add(Me.Label3)
        Me.PanelConnection.Controls.Add(Me.txtPassword)
        Me.PanelConnection.Controls.Add(Me.Label2)
        Me.PanelConnection.Controls.Add(Me.txtUserID)
        Me.PanelConnection.Controls.Add(Me.Label1)
        Me.PanelConnection.Controls.Add(Me.txtDataSource)
        Me.PanelConnection.Controls.Add(Me.txtDatabase)
        Me.PanelConnection.Controls.Add(Me.Label4)
        Me.PanelConnection.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelConnection.Location = New System.Drawing.Point(0, 0)
        Me.PanelConnection.Name = "PanelConnection"
        Me.PanelConnection.Size = New System.Drawing.Size(384, 109)
        Me.PanelConnection.TabIndex = 101
        Me.PanelConnection.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(62, 85)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(277, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Load Patients"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(190, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "PWD"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(229, 56)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(149, 20)
        Me.txtPassword.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(4, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "UID"
        '
        'txtUserID
        '
        Me.txtUserID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserID.Location = New System.Drawing.Point(63, 56)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(121, 20)
        Me.txtUserID.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Server"
        '
        'txtDataSource
        '
        Me.txtDataSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDataSource.Location = New System.Drawing.Point(63, 7)
        Me.txtDataSource.Name = "txtDataSource"
        Me.txtDataSource.Size = New System.Drawing.Size(315, 20)
        Me.txtDataSource.TabIndex = 0
        '
        'txtDatabase
        '
        Me.txtDatabase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatabase.Location = New System.Drawing.Point(63, 32)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(315, 20)
        Me.txtDatabase.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Database"
        '
        'ListViewPatients
        '
        Me.ListViewPatients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader1})
        Me.ListViewPatients.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListViewPatients.FullRowSelect = True
        Me.ListViewPatients.GridLines = True
        Me.ListViewPatients.HideSelection = False
        Me.ListViewPatients.LargeImageList = Me.ImageList1
        Me.ListViewPatients.Location = New System.Drawing.Point(7, 114)
        Me.ListViewPatients.MultiSelect = False
        Me.ListViewPatients.Name = "ListViewPatients"
        Me.ListViewPatients.Size = New System.Drawing.Size(371, 311)
        Me.ListViewPatients.SmallImageList = Me.ImageList1
        Me.ListViewPatients.TabIndex = 102
        Me.ListViewPatients.UseCompatibleStateImageBehavior = False
        Me.ListViewPatients.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "ID"
        Me.ColumnHeader7.Width = 74
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Patient Name"
        Me.ColumnHeader8.Width = 232
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Case"
        Me.ColumnHeader1.Width = 38
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "SORT1")
        Me.ImageList1.Images.SetKeyName(1, "SORT2")
        Me.ImageList1.Images.SetKeyName(2, "SORT0")
        Me.ImageList1.Images.SetKeyName(3, "CHECK")
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportPatientToolStripMenuItem, Me.ToolStripSeparator1, Me.ResetPatientIndicatorToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(220, 54)
        '
        'ImportPatientToolStripMenuItem
        '
        Me.ImportPatientToolStripMenuItem.Name = "ImportPatientToolStripMenuItem"
        Me.ImportPatientToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ImportPatientToolStripMenuItem.Text = "Import Patient"
        '
        'ResetPatientIndicatorToolStripMenuItem
        '
        Me.ResetPatientIndicatorToolStripMenuItem.Name = "ResetPatientIndicatorToolStripMenuItem"
        Me.ResetPatientIndicatorToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ResetPatientIndicatorToolStripMenuItem.Text = "Reset Patient Imported Indicator"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(216, 6)
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Controls.Add(Me.cmdCopy)
        Me.Panel3.Controls.Add(Me.cmdPrint)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 431)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(384, 30)
        Me.Panel3.TabIndex = 104
        '
        'imgWait1
        '
        Me.imgWait1.BackColor = System.Drawing.Color.Transparent
        Me.imgWait1.Image = CType(resources.GetObject("imgWait1.Image"), System.Drawing.Image)
        Me.imgWait1.Location = New System.Drawing.Point(7, 80)
        Me.imgWait1.Name = "imgWait1"
        Me.imgWait1.Size = New System.Drawing.Size(20, 20)
        Me.imgWait1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgWait1.TabIndex = 284
        Me.imgWait1.TabStop = False
        Me.imgWait1.Visible = False
        '
        'frmImportPatients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 461)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ListViewPatients)
        Me.Controls.Add(Me.PanelConnection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimumSize = New System.Drawing.Size(400, 500)
        Me.Name = "frmImportPatients"
        Me.Text = "Import Patients"
        Me.PanelConnection.ResumeLayout(False)
        Me.PanelConnection.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.imgWait1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents PanelConnection As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDataSource As TextBox
    Friend WithEvents ListViewPatients As ListView
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents cmdPrint As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ImportPatientToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetPatientIndicatorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Panel3 As Panel
    Friend WithEvents imgWait1 As PictureBox
End Class
