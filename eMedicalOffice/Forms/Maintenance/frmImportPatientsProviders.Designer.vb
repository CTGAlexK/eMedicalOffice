<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportPatientsProviders
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportPatientsProviders))
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxBillingProvider = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBoxReferringDoctor = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.ComboBoxTreatingProviderID = New System.Windows.Forms.ComboBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.ComboBoxReferringCompanyID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboProcedure = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProcedure = New System.Windows.Forms.TextBox()
        Me.txtBillingProvider = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTreatingProvider = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReferringOffice = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtReferringDoctor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdClose.Location = New System.Drawing.Point(8, 4)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(87, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdCopy
        '
        Me.cmdCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdCopy.Location = New System.Drawing.Point(681, 4)
        Me.cmdCopy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(87, 23)
        Me.cmdCopy.TabIndex = 1
        Me.cmdCopy.Text = "Update"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(400, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Procedure"
        '
        'ComboBoxBillingProvider
        '
        Me.ComboBoxBillingProvider.AccessibleDescription = "1"
        Me.ComboBoxBillingProvider.BackColor = System.Drawing.Color.White
        Me.ComboBoxBillingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBillingProvider.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxBillingProvider.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxBillingProvider.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxBillingProvider.FormattingEnabled = True
        Me.ComboBoxBillingProvider.Location = New System.Drawing.Point(400, 114)
        Me.ComboBoxBillingProvider.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxBillingProvider.Name = "ComboBoxBillingProvider"
        Me.ComboBoxBillingProvider.Size = New System.Drawing.Size(365, 25)
        Me.ComboBoxBillingProvider.TabIndex = 298
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(400, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 17)
        Me.Label15.TabIndex = 303
        Me.Label15.Text = "Billing Provider"
        '
        'ComboBoxReferringDoctor
        '
        Me.ComboBoxReferringDoctor.BackColor = System.Drawing.Color.White
        Me.ComboBoxReferringDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxReferringDoctor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxReferringDoctor.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxReferringDoctor.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxReferringDoctor.FormattingEnabled = True
        Me.ComboBoxReferringDoctor.Location = New System.Drawing.Point(400, 265)
        Me.ComboBoxReferringDoctor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxReferringDoctor.Name = "ComboBoxReferringDoctor"
        Me.ComboBoxReferringDoctor.Size = New System.Drawing.Size(365, 25)
        Me.ComboBoxReferringDoctor.Sorted = True
        Me.ComboBoxReferringDoctor.TabIndex = 300
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.White
        Me.Label63.Location = New System.Drawing.Point(400, 245)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(108, 17)
        Me.Label63.TabIndex = 302
        Me.Label63.Text = "Referring Doctor"
        '
        'ComboBoxTreatingProviderID
        '
        Me.ComboBoxTreatingProviderID.AccessibleDescription = "1"
        Me.ComboBoxTreatingProviderID.BackColor = System.Drawing.Color.White
        Me.ComboBoxTreatingProviderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTreatingProviderID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxTreatingProviderID.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxTreatingProviderID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTreatingProviderID.FormattingEnabled = True
        Me.ComboBoxTreatingProviderID.Location = New System.Drawing.Point(400, 164)
        Me.ComboBoxTreatingProviderID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxTreatingProviderID.Name = "ComboBoxTreatingProviderID"
        Me.ComboBoxTreatingProviderID.Size = New System.Drawing.Size(365, 25)
        Me.ComboBoxTreatingProviderID.TabIndex = 299
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.White
        Me.Label68.Location = New System.Drawing.Point(400, 144)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(112, 17)
        Me.Label68.TabIndex = 301
        Me.Label68.Text = "Treating Provider"
        '
        'ComboBoxReferringCompanyID
        '
        Me.ComboBoxReferringCompanyID.BackColor = System.Drawing.Color.White
        Me.ComboBoxReferringCompanyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxReferringCompanyID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxReferringCompanyID.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxReferringCompanyID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxReferringCompanyID.FormattingEnabled = True
        Me.ComboBoxReferringCompanyID.Location = New System.Drawing.Point(400, 214)
        Me.ComboBoxReferringCompanyID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxReferringCompanyID.Name = "ComboBoxReferringCompanyID"
        Me.ComboBoxReferringCompanyID.Size = New System.Drawing.Size(365, 25)
        Me.ComboBoxReferringCompanyID.Sorted = True
        Me.ComboBoxReferringCompanyID.TabIndex = 304
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(400, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 305
        Me.Label2.Text = "Referring Office"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Controls.Add(Me.cmdCopy)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 315)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(778, 30)
        Me.Panel3.TabIndex = 306
        '
        'cboProcedure
        '
        Me.cboProcedure.AccessibleDescription = "1"
        Me.cboProcedure.BackColor = System.Drawing.Color.White
        Me.cboProcedure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProcedure.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboProcedure.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboProcedure.ForeColor = System.Drawing.Color.Black
        Me.cboProcedure.FormattingEnabled = True
        Me.cboProcedure.Location = New System.Drawing.Point(400, 60)
        Me.cboProcedure.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboProcedure.Name = "cboProcedure"
        Me.cboProcedure.Size = New System.Drawing.Size(365, 25)
        Me.cboProcedure.TabIndex = 307
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Procedure"
        '
        'txtProcedure
        '
        Me.txtProcedure.BackColor = System.Drawing.Color.Gray
        Me.txtProcedure.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtProcedure.ForeColor = System.Drawing.Color.White
        Me.txtProcedure.Location = New System.Drawing.Point(7, 59)
        Me.txtProcedure.Name = "txtProcedure"
        Me.txtProcedure.ReadOnly = True
        Me.txtProcedure.Size = New System.Drawing.Size(367, 25)
        Me.txtProcedure.TabIndex = 309
        '
        'txtBillingProvider
        '
        Me.txtBillingProvider.BackColor = System.Drawing.Color.Gray
        Me.txtBillingProvider.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtBillingProvider.ForeColor = System.Drawing.Color.White
        Me.txtBillingProvider.Location = New System.Drawing.Point(7, 114)
        Me.txtBillingProvider.Name = "txtBillingProvider"
        Me.txtBillingProvider.ReadOnly = True
        Me.txtBillingProvider.Size = New System.Drawing.Size(367, 25)
        Me.txtBillingProvider.TabIndex = 311
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 17)
        Me.Label4.TabIndex = 310
        Me.Label4.Text = "Billing Provider"
        '
        'txtTreatingProvider
        '
        Me.txtTreatingProvider.BackColor = System.Drawing.Color.Gray
        Me.txtTreatingProvider.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTreatingProvider.ForeColor = System.Drawing.Color.White
        Me.txtTreatingProvider.Location = New System.Drawing.Point(7, 164)
        Me.txtTreatingProvider.Name = "txtTreatingProvider"
        Me.txtTreatingProvider.ReadOnly = True
        Me.txtTreatingProvider.Size = New System.Drawing.Size(367, 25)
        Me.txtTreatingProvider.TabIndex = 313
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(4, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 17)
        Me.Label5.TabIndex = 312
        Me.Label5.Text = "Treating Provider"
        '
        'txtReferringOffice
        '
        Me.txtReferringOffice.BackColor = System.Drawing.Color.Gray
        Me.txtReferringOffice.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtReferringOffice.ForeColor = System.Drawing.Color.White
        Me.txtReferringOffice.Location = New System.Drawing.Point(7, 214)
        Me.txtReferringOffice.Name = "txtReferringOffice"
        Me.txtReferringOffice.ReadOnly = True
        Me.txtReferringOffice.Size = New System.Drawing.Size(367, 25)
        Me.txtReferringOffice.TabIndex = 315
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(4, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 17)
        Me.Label6.TabIndex = 314
        Me.Label6.Text = "Referring Office"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(4, 245)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 17)
        Me.Label7.TabIndex = 316
        Me.Label7.Text = "Referring Doctor"
        '
        'txtReferringDoctor
        '
        Me.txtReferringDoctor.BackColor = System.Drawing.Color.Gray
        Me.txtReferringDoctor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtReferringDoctor.ForeColor = System.Drawing.Color.White
        Me.txtReferringDoctor.Location = New System.Drawing.Point(7, 265)
        Me.txtReferringDoctor.Name = "txtReferringDoctor"
        Me.txtReferringDoctor.ReadOnly = True
        Me.txtReferringDoctor.Size = New System.Drawing.Size(367, 25)
        Me.txtReferringDoctor.TabIndex = 317
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(8, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 25)
        Me.Label8.TabIndex = 318
        Me.Label8.Text = "SOURCE"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(628, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 25)
        Me.Label9.TabIndex = 319
        Me.Label9.Text = "DESTINATION"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(705, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 322
        Me.Label10.Text = "Add Office"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(703, 249)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 323
        Me.Label11.Text = "Add Doctor"
        '
        'frmImportPatientsProviders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(778, 345)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtReferringDoctor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtReferringOffice)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTreatingProvider)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBillingProvider)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtProcedure)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboProcedure)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ComboBoxReferringCompanyID)
        Me.Controls.Add(Me.ComboBoxBillingProvider)
        Me.Controls.Add(Me.ComboBoxReferringDoctor)
        Me.Controls.Add(Me.ComboBoxTreatingProviderID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.Label68)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmImportPatientsProviders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Patients - Procedure / Providers"
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxBillingProvider As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents ComboBoxReferringDoctor As ComboBox
    Friend WithEvents Label63 As Label
    Friend WithEvents ComboBoxTreatingProviderID As ComboBox
    Friend WithEvents Label68 As Label
    Friend WithEvents ComboBoxReferringCompanyID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cboProcedure As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProcedure As TextBox
    Friend WithEvents txtBillingProvider As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTreatingProvider As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtReferringOffice As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtReferringDoctor As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
End Class
