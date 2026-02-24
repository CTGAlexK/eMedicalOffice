<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillsForArbitration
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
        Dim frm As Form
        Try
            FormsCollection.Forms.Remove(Me)
        Catch ex As Exception

        End Try
        'Retry:
        '        For Each frm In FormsCollection.Forms
        '            If frm.Name = Me.Name Then
        '                FormsCollection.Forms.Remove(frm)
        '                GoTo Retry
        '            End If
        '        Next
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ColumnHeaderRenderer19 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer7 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim ColumnHeaderRenderer6 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer8 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim ColumnHeaderRenderer7 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer6 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim ColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer4 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim ColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer12 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer13 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer8 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer9 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer10 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer11 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer18 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer5 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer4 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer14 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer15 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer16 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer17 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer5 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillsForArbitration))
        Me.btnExport = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintCheckedBills3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFD = New System.Windows.Forms.SaveFileDialog()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cboDays = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabelAmount = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabelCount = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.cboAttorney = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.cboInsurance = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripButtonReset = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.PanelBills = New System.Windows.Forms.Panel()
        Me.ListViewRequests = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ListViewComments = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.mnuAddSelectedBillNotes1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.txtPatientComments = New System.Windows.Forms.TextBox()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ListViewPayments = New System.Windows.Forms.ListView()
        Me.PaymentDT = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Amount = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.TreeViewBills = New System.Windows.Forms.TreeView()
        Me.PanelBillDetails = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ButtonDetails = New System.Windows.Forms.PictureBox()
        Me.PanelShowBills = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New eMedicalOffice.clsListView()
        Me.PatientNo = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.PatientName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.DOA = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.BillNo = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.BillDT = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.BillAge = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.BillStatus = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Amt = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ServiceDt = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ReqStatusDT = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ReqStatusAge = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Insurance = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Policy = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Claim = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.AdjusterName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.AdjusterContact = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Attorney = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.AttorneyDate = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ArbitrationAttorney = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ArbitrationAttorneyDT = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.CourtIndex = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.ToolStrip2.SuspendLayout
        Me.PanelBills.SuspendLayout
        Me.ToolStrip3.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.ToolStrip5.SuspendLayout
        Me.ToolStrip4.SuspendLayout
        Me.PanelBillDetails.SuspendLayout
        CType(Me.ButtonDetails,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelShowBills.SuspendLayout
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        Me.SuspendLayout
        ColumnHeaderRenderer19.Name = "ColumnHeaderRenderer19"
        ColumnHeaderRenderer19.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        EnhancedColumnHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer7.Name = "EnhancedColumnHeaderRenderer7"
        EnhancedColumnHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer7.TextRotationAngle = 0R
        ColumnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer6.Name = "ColumnHeaderRenderer6"
        ColumnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer6.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer8.Name = "EnhancedColumnHeaderRenderer8"
        EnhancedColumnHeaderRenderer8.TextRotationAngle = 0R
        ColumnHeaderRenderer7.Name = "ColumnHeaderRenderer7"
        ColumnHeaderRenderer7.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        EnhancedColumnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer6.Name = "EnhancedColumnHeaderRenderer6"
        EnhancedColumnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer6.TextRotationAngle = 0R
        ColumnHeaderRenderer3.Name = "ColumnHeaderRenderer3"
        ColumnHeaderRenderer3.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer4.Name = "EnhancedColumnHeaderRenderer4"
        EnhancedColumnHeaderRenderer4.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        EnhancedColumnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer1.Name = "EnhancedColumnHeaderRenderer1"
        EnhancedColumnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer1.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer2.Name = "EnhancedColumnHeaderRenderer2"
        EnhancedColumnHeaderRenderer2.TextRotationAngle = 0R
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        EnhancedColumnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer3.Name = "EnhancedColumnHeaderRenderer3"
        EnhancedColumnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer3.TextRotationAngle = 0R
        ColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        ColumnHeaderRenderer12.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer12.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer12.Name = "ColumnHeaderRenderer12"
        ColumnHeaderRenderer12.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer12.TextRotationAngle = 0R
        ColumnHeaderRenderer13.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer13.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer13.Name = "ColumnHeaderRenderer13"
        ColumnHeaderRenderer13.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer13.TextRotationAngle = 0R
        ColumnHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer8.Name = "ColumnHeaderRenderer8"
        ColumnHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer8.TextRotationAngle = 0R
        ColumnHeaderRenderer8.WordWrap = false
        ColumnHeaderRenderer9.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer9.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer9.Name = "ColumnHeaderRenderer9"
        ColumnHeaderRenderer9.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer9.TextRotationAngle = 0R
        ColumnHeaderRenderer10.Name = "ColumnHeaderRenderer10"
        ColumnHeaderRenderer10.TextRotationAngle = 0R
        ColumnHeaderRenderer11.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer11.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer11.Name = "ColumnHeaderRenderer11"
        ColumnHeaderRenderer11.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer11.TextRotationAngle = 0R
        ColumnHeaderRenderer11.WordWrap = false
        ColumnHeaderRenderer18.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer18.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer18.Name = "ColumnHeaderRenderer18"
        ColumnHeaderRenderer18.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer18.TextRotationAngle = 0R
        ColumnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer5.Name = "ColumnHeaderRenderer5"
        ColumnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer5.TextRotationAngle = 0R
        ColumnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer4.Name = "ColumnHeaderRenderer4"
        ColumnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer4.TextRotationAngle = 0R
        ColumnHeaderRenderer14.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer14.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer14.Name = "ColumnHeaderRenderer14"
        ColumnHeaderRenderer14.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer14.TextRotationAngle = 0R
        ColumnHeaderRenderer14.WordWrap = false
        ColumnHeaderRenderer15.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer15.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer15.Name = "ColumnHeaderRenderer15"
        ColumnHeaderRenderer15.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer15.TextRotationAngle = 0R
        ColumnHeaderRenderer16.Name = "ColumnHeaderRenderer16"
        ColumnHeaderRenderer16.TextRotationAngle = 0R
        ColumnHeaderRenderer17.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        ColumnHeaderRenderer17.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer17.Name = "ColumnHeaderRenderer17"
        ColumnHeaderRenderer17.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer17.TextRotationAngle = 0R
        ColumnHeaderRenderer17.WordWrap = false
        EnhancedColumnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        EnhancedColumnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer5.Name = "EnhancedColumnHeaderRenderer5"
        EnhancedColumnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer5.TextRotationAngle = 0R
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"),System.Drawing.Image)
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExport.Location = New System.Drawing.Point(12, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(120, 24)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "Export To Excel"
        Me.btnExport.UseVisualStyleBackColor = true
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem, Me.ToolStripSeparator1, Me.mnuPrintCheckedBills3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(222, 76)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Image = CType(resources.GetObject("SelectAllToolStripMenuItem.Image"),System.Drawing.Image)
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SelectAllToolStripMenuItem.Text = "Check All"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Check None"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(218, 6)
        '
        'mnuPrintCheckedBills3
        '
        Me.mnuPrintCheckedBills3.Image = CType(resources.GetObject("mnuPrintCheckedBills3.Image"),System.Drawing.Image)
        Me.mnuPrintCheckedBills3.Name = "mnuPrintCheckedBills3"
        Me.mnuPrintCheckedBills3.Size = New System.Drawing.Size(221, 22)
        Me.mnuPrintCheckedBills3.Text = "Print Checked/Selected Bills"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "SORT1")
        Me.ImageList1.Images.SetKeyName(1, "SORT2")
        Me.ImageList1.Images.SetKeyName(2, "SORT0")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"),System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.btnExport)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 628)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1160, 34)
        Me.Panel2.TabIndex = 152
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(1082, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = true
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.cboDays, Me.ToolStripLabelAmount, Me.ToolStripLabelCount, Me.ToolStripLabel6, Me.cboAttorney, Me.ToolStripLabel8, Me.cboInsurance, Me.ToolStripButtonReset, Me.ToolStripButton2})
        Me.ToolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1160, 25)
        Me.ToolStrip2.TabIndex = 154
        Me.ToolStrip2.Text = "Paid Checked"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"),System.Drawing.Image)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.ToolStripButton7.Size = New System.Drawing.Size(28, 22)
        Me.ToolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton7.ToolTipText = "Autosize Spread Columns Width"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.ToolStripLabel1.Size = New System.Drawing.Size(111, 22)
        Me.ToolStripLabel1.Text = "No Response Day"
        Me.ToolStripLabel1.ToolTipText = "Insurance No Response Day"
        '
        'cboDays
        '
        Me.cboDays.AutoSize = false
        Me.cboDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDays.Name = "cboDays"
        Me.cboDays.Size = New System.Drawing.Size(70, 23)
        Me.cboDays.ToolTipText = "Days Since Last Insurance Response"
        '
        'ToolStripLabelAmount
        '
        Me.ToolStripLabelAmount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelAmount.Name = "ToolStripLabelAmount"
        Me.ToolStripLabelAmount.Padding = New System.Windows.Forms.Padding(12, 0, 12, 0)
        Me.ToolStripLabelAmount.Size = New System.Drawing.Size(75, 22)
        Me.ToolStripLabelAmount.Text = "Amount"
        '
        'ToolStripLabelCount
        '
        Me.ToolStripLabelCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelCount.Name = "ToolStripLabelCount"
        Me.ToolStripLabelCount.Padding = New System.Windows.Forms.Padding(12, 0, 12, 0)
        Me.ToolStripLabelCount.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripLabelCount.Text = "Count"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.ToolStripLabel6.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripLabel6.Text = "Attorney"
        '
        'cboAttorney
        '
        Me.cboAttorney.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttorney.Name = "cboAttorney"
        Me.cboAttorney.Size = New System.Drawing.Size(121, 25)
        Me.cboAttorney.ToolTipText = "Primary Attorney"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.ToolStripLabel8.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripLabel8.Text = "Insurance"
        '
        'cboInsurance
        '
        Me.cboInsurance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInsurance.Name = "cboInsurance"
        Me.cboInsurance.Size = New System.Drawing.Size(121, 25)
        Me.cboInsurance.ToolTipText = "Insurance Group / Company"
        '
        'ToolStripButtonReset
        '
        Me.ToolStripButtonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonReset.Image = CType(resources.GetObject("ToolStripButtonReset.Image"),System.Drawing.Image)
        Me.ToolStripButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonReset.Name = "ToolStripButtonReset"
        Me.ToolStripButtonReset.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonReset.Text = "Reset Search Criteria"
        Me.ToolStripButtonReset.ToolTipText = "Reset Search Criteria"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"),System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(20, 1, 0, 2)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton2.Text = "Find"
        '
        'PanelBills
        '
        Me.PanelBills.BackColor = System.Drawing.Color.White
        Me.PanelBills.Controls.Add(Me.ListViewRequests)
        Me.PanelBills.Controls.Add(Me.ToolStrip3)
        Me.PanelBills.Controls.Add(Me.txtComments)
        Me.PanelBills.Controls.Add(Me.Panel3)
        Me.PanelBills.Controls.Add(Me.ListViewComments)
        Me.PanelBills.Controls.Add(Me.ToolStrip1)
        Me.PanelBills.Controls.Add(Me.txtPatientComments)
        Me.PanelBills.Controls.Add(Me.ToolStrip5)
        Me.PanelBills.Controls.Add(Me.ListViewPayments)
        Me.PanelBills.Controls.Add(Me.ToolStrip4)
        Me.PanelBills.Controls.Add(Me.TreeViewBills)
        Me.PanelBills.Controls.Add(Me.PanelBillDetails)
        Me.PanelBills.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelBills.Location = New System.Drawing.Point(877, 47)
        Me.PanelBills.Name = "PanelBills"
        Me.PanelBills.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.PanelBills.Size = New System.Drawing.Size(283, 581)
        Me.PanelBills.TabIndex = 210
        '
        'ListViewRequests
        '
        Me.ListViewRequests.BackColor = System.Drawing.Color.White
        Me.ListViewRequests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListViewRequests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewRequests.FullRowSelect = true
        Me.ListViewRequests.GridLines = true
        Me.ListViewRequests.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewRequests.HideSelection = false
        Me.ListViewRequests.Location = New System.Drawing.Point(5, 477)
        Me.ListViewRequests.MultiSelect = false
        Me.ListViewRequests.Name = "ListViewRequests"
        Me.ListViewRequests.Size = New System.Drawing.Size(278, 104)
        Me.ListViewRequests.TabIndex = 9
        Me.ListViewRequests.UseCompatibleStateImageBehavior = false
        Me.ListViewRequests.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date"
        Me.ColumnHeader1.Width = 91
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Status"
        Me.ColumnHeader2.Width = 57
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Request"
        Me.ColumnHeader3.Width = 148
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStripButton1})
        Me.ToolStrip3.Location = New System.Drawing.Point(5, 452)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(278, 25)
        Me.ToolStrip3.TabIndex = 8
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripLabel2.Text = "BILL REQUESTS"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.AutoSize = false
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"),System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripButton1.Text = "Add request"
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton1.ToolTipText = "Add Request"
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.Color.White
        Me.txtComments.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtComments.Location = New System.Drawing.Point(5, 386)
        Me.txtComments.Multiline = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(278, 66)
        Me.txtComments.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(5, 383)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(278, 3)
        Me.Panel3.TabIndex = 295
        '
        'ListViewComments
        '
        Me.ListViewComments.BackColor = System.Drawing.Color.White
        Me.ListViewComments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListViewComments.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListViewComments.FullRowSelect = true
        Me.ListViewComments.GridLines = true
        Me.ListViewComments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewComments.HideSelection = false
        Me.ListViewComments.Location = New System.Drawing.Point(5, 312)
        Me.ListViewComments.MultiSelect = false
        Me.ListViewComments.Name = "ListViewComments"
        Me.ListViewComments.ShowItemToolTips = true
        Me.ListViewComments.Size = New System.Drawing.Size(278, 71)
        Me.ListViewComments.TabIndex = 6
        Me.ListViewComments.UseCompatibleStateImageBehavior = false
        Me.ListViewComments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Date"
        Me.ColumnHeader5.Width = 91
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "By"
        Me.ColumnHeader6.Width = 127
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.mnuAddSelectedBillNotes1, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(5, 287)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(278, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripLabel3.Text = "BILL NOTES"
        Me.ToolStripLabel3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'mnuAddSelectedBillNotes1
        '
        Me.mnuAddSelectedBillNotes1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.mnuAddSelectedBillNotes1.AutoSize = false
        Me.mnuAddSelectedBillNotes1.Image = CType(resources.GetObject("mnuAddSelectedBillNotes1.Image"),System.Drawing.Image)
        Me.mnuAddSelectedBillNotes1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuAddSelectedBillNotes1.Name = "mnuAddSelectedBillNotes1"
        Me.mnuAddSelectedBillNotes1.Size = New System.Drawing.Size(80, 22)
        Me.mnuAddSelectedBillNotes1.Text = "Add Note"
        Me.mnuAddSelectedBillNotes1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mnuAddSelectedBillNotes1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.mnuAddSelectedBillNotes1.ToolTipText = "Add Bill Notes"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"),System.Drawing.Image)
        Me.ToolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton5.Text = "Show"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton5.ToolTipText = "Show Bill Notes"
        '
        'txtPatientComments
        '
        Me.txtPatientComments.BackColor = System.Drawing.Color.White
        Me.txtPatientComments.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtPatientComments.Location = New System.Drawing.Point(5, 234)
        Me.txtPatientComments.Multiline = true
        Me.txtPatientComments.Name = "txtPatientComments"
        Me.txtPatientComments.ReadOnly = true
        Me.txtPatientComments.Size = New System.Drawing.Size(278, 53)
        Me.txtPatientComments.TabIndex = 4
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.ToolStripButton6})
        Me.ToolStrip5.Location = New System.Drawing.Point(5, 209)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(278, 25)
        Me.ToolStrip5.TabIndex = 3
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel4.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripLabel4.Text = "PATIENT COMMENTS"
        Me.ToolStripLabel4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"),System.Drawing.Image)
        Me.ToolStripButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton6.Text = "Show"
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton6.ToolTipText = "Show Patient's Comments"
        '
        'ListViewPayments
        '
        Me.ListViewPayments.BackColor = System.Drawing.Color.White
        Me.ListViewPayments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PaymentDT, Me.Amount, Me.ColumnHeader7})
        Me.ListViewPayments.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListViewPayments.FullRowSelect = true
        Me.ListViewPayments.GridLines = true
        Me.ListViewPayments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewPayments.HideSelection = false
        Me.ListViewPayments.Location = New System.Drawing.Point(5, 111)
        Me.ListViewPayments.MultiSelect = false
        Me.ListViewPayments.Name = "ListViewPayments"
        Me.ListViewPayments.ShowItemToolTips = true
        Me.ListViewPayments.Size = New System.Drawing.Size(278, 98)
        Me.ListViewPayments.TabIndex = 2
        Me.ListViewPayments.UseCompatibleStateImageBehavior = false
        Me.ListViewPayments.View = System.Windows.Forms.View.Details
        '
        'PaymentDT
        '
        Me.PaymentDT.Text = "Date"
        Me.PaymentDT.Width = 78
        '
        'Amount
        '
        Me.Amount.Text = "Amount"
        Me.Amount.Width = 127
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Check #"
        Me.ColumnHeader7.Width = 126
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel5})
        Me.ToolStrip4.Location = New System.Drawing.Point(5, 86)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(278, 25)
        Me.ToolStrip4.TabIndex = 1
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel5.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(91, 22)
        Me.ToolStripLabel5.Text = "BILL PAYMENTS"
        Me.ToolStripLabel5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TreeViewBills
        '
        Me.TreeViewBills.BackColor = System.Drawing.Color.White
        Me.TreeViewBills.Dock = System.Windows.Forms.DockStyle.Top
        Me.TreeViewBills.FullRowSelect = true
        Me.TreeViewBills.HideSelection = false
        Me.TreeViewBills.ImageKey = "2"
        Me.TreeViewBills.Indent = 12
        Me.TreeViewBills.Location = New System.Drawing.Point(5, 16)
        Me.TreeViewBills.Name = "TreeViewBills"
        Me.TreeViewBills.ShowNodeToolTips = true
        Me.TreeViewBills.Size = New System.Drawing.Size(278, 70)
        Me.TreeViewBills.TabIndex = 0
        '
        'PanelBillDetails
        '
        Me.PanelBillDetails.BackColor = System.Drawing.Color.White
        Me.PanelBillDetails.Controls.Add(Me.Label16)
        Me.PanelBillDetails.Controls.Add(Me.ButtonDetails)
        Me.PanelBillDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBillDetails.Location = New System.Drawing.Point(5, 0)
        Me.PanelBillDetails.Name = "PanelBillDetails"
        Me.PanelBillDetails.Size = New System.Drawing.Size(278, 16)
        Me.PanelBillDetails.TabIndex = 274
        '
        'Label16
        '
        Me.Label16.AutoSize = true
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label16.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 14)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "PATIENT BILLS"
        '
        'ButtonDetails
        '
        Me.ButtonDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDetails.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonDetails.Image = CType(resources.GetObject("ButtonDetails.Image"),System.Drawing.Image)
        Me.ButtonDetails.Location = New System.Drawing.Point(258, 0)
        Me.ButtonDetails.Name = "ButtonDetails"
        Me.ButtonDetails.Size = New System.Drawing.Size(20, 16)
        Me.ButtonDetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ButtonDetails.TabIndex = 12
        Me.ButtonDetails.TabStop = false
        Me.ButtonDetails.Tag = "1"
        '
        'PanelShowBills
        '
        Me.PanelShowBills.BackColor = System.Drawing.Color.White
        Me.PanelShowBills.Controls.Add(Me.PictureBox2)
        Me.PanelShowBills.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PanelShowBills.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelShowBills.Location = New System.Drawing.Point(861, 47)
        Me.PanelShowBills.Name = "PanelShowBills"
        Me.PanelShowBills.Size = New System.Drawing.Size(16, 581)
        Me.PanelShowBills.TabIndex = 211
        Me.PanelShowBills.Visible = false
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Enabled = false
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"),System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 13)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = false
        Me.PictureBox2.Tag = "1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1160, 22)
        Me.Panel1.TabIndex = 239
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(1160, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bills with no response by insurance company more than 30 days are qualified to be"& _ 
    " satisfied by arbitration."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = true
        Me.ListView1.CheckBoxes = true
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PatientNo, Me.PatientName, Me.DOA, Me.BillNo, Me.BillDT, Me.BillAge, Me.BillStatus, Me.Amt, Me.ServiceDt, Me.ReqStatusDT, Me.ReqStatusAge, Me.Insurance, Me.Policy, Me.Claim, Me.AdjusterName, Me.AdjusterContact, Me.Attorney, Me.AttorneyDate, Me.ArbitrationAttorney, Me.ArbitrationAttorneyDT, Me.CourtIndex})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = true
        Me.ListView1.GridLines = true
        Me.ListView1.HideSelection = false
        Me.ListView1.LabelWrap = false
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(0, 47)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(0)
        Me.ListView1.MultiSelect = false
        Me.ListView1.Name = "ListView1"
        Me.ListView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListView1.ShowGroups = false
        Me.ListView1.ShowItemToolTips = true
        Me.ListView1.Size = New System.Drawing.Size(861, 581)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 153
        Me.ListView1.UseCompatibleStateImageBehavior = false
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'PatientNo
        '
        Me.PatientNo.Text = "Patient #"
        Me.PatientNo.Width = 93
        '
        'PatientName
        '
        Me.PatientName.Text = "Name"
        Me.PatientName.Width = 166
        '
        'DOA
        '
        Me.DOA.Text = "DOA"
        Me.DOA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DOA.Width = 77
        '
        'BillNo
        '
        Me.BillNo.Text = "Bill #"
        Me.BillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BillDT
        '
        Me.BillDT.Text = "Bill DT"
        Me.BillDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.BillDT.Width = 90
        '
        'BillAge
        '
        Me.BillAge.Text = "Bill Age"
        Me.BillAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.BillAge.Width = 89
        '
        'BillStatus
        '
        Me.BillStatus.Text = "Bill Status"
        Me.BillStatus.Width = 89
        '
        'Amt
        '
        Me.Amt.Text = "Amt"
        Me.Amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ServiceDt
        '
        Me.ServiceDt.Text = "Service Dt"
        Me.ServiceDt.Width = 102
        '
        'ReqStatusDT
        '
        Me.ReqStatusDT.Text = "Req Status DT"
        Me.ReqStatusDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ReqStatusDT.Width = 119
        '
        'ReqStatusAge
        '
        Me.ReqStatusAge.Text = "Req Status Age"
        Me.ReqStatusAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Insurance
        '
        Me.Insurance.Text = "Insurance"
        '
        'Policy
        '
        Me.Policy.Text = "Policy #"
        '
        'Claim
        '
        Me.Claim.Text = "Claim #"
        '
        'AdjusterName
        '
        Me.AdjusterName.Text = "Adjuster Name"
        '
        'AdjusterContact
        '
        Me.AdjusterContact.Text = "Adjuster Contact"
        '
        'Attorney
        '
        Me.Attorney.Text = "Attorney"
        '
        'AttorneyDate
        '
        Me.AttorneyDate.Text = "Attorney Date"
        '
        'ArbitrationAttorney
        '
        Me.ArbitrationAttorney.Text = "Arbitration Attorney"
        '
        'ArbitrationAttorneyDT
        '
        Me.ArbitrationAttorneyDT.Text = "Arbitration Attorney DT"
        '
        'CourtIndex
        '
        Me.CourtIndex.Text = "Court Index"
        '
        'frmBillsForArbitration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1160, 662)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.PanelShowBills)
        Me.Controls.Add(Me.PanelBills)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(ColumnHeaderRenderer19)
        Me.Controls.Add(EnhancedColumnHeaderRenderer7)
        Me.Controls.Add(ColumnHeaderRenderer6)
        Me.Controls.Add(EnhancedColumnHeaderRenderer8)
        Me.Controls.Add(ColumnHeaderRenderer7)
        Me.Controls.Add(EnhancedColumnHeaderRenderer6)
        Me.Controls.Add(ColumnHeaderRenderer3)
        Me.Controls.Add(EnhancedColumnHeaderRenderer4)
        Me.Controls.Add(EnhancedColumnHeaderRenderer1)
        Me.Controls.Add(EnhancedColumnHeaderRenderer2)
        Me.Controls.Add(ColumnHeaderRenderer1)
        Me.Controls.Add(EnhancedColumnHeaderRenderer3)
        Me.Controls.Add(ColumnHeaderRenderer2)
        Me.Controls.Add(ColumnHeaderRenderer12)
        Me.Controls.Add(ColumnHeaderRenderer13)
        Me.Controls.Add(ColumnHeaderRenderer8)
        Me.Controls.Add(ColumnHeaderRenderer9)
        Me.Controls.Add(ColumnHeaderRenderer10)
        Me.Controls.Add(ColumnHeaderRenderer11)
        Me.Controls.Add(ColumnHeaderRenderer18)
        Me.Controls.Add(ColumnHeaderRenderer5)
        Me.Controls.Add(ColumnHeaderRenderer4)
        Me.Controls.Add(ColumnHeaderRenderer14)
        Me.Controls.Add(ColumnHeaderRenderer15)
        Me.Controls.Add(ColumnHeaderRenderer16)
        Me.Controls.Add(ColumnHeaderRenderer17)
        Me.Controls.Add(EnhancedColumnHeaderRenderer5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.MinimumSize = New System.Drawing.Size(1100, 700)
        Me.Name = "frmBillsForArbitration"
        Me.Text = "Bills Qualified For Arbitratrion - 30 Days No Answer Rule"
        Me.ContextMenuStrip1.ResumeLayout(false)
        Me.Panel2.ResumeLayout(false)
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        Me.PanelBills.ResumeLayout(false)
        Me.PanelBills.PerformLayout
        Me.ToolStrip3.ResumeLayout(false)
        Me.ToolStrip3.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.ToolStrip5.ResumeLayout(false)
        Me.ToolStrip5.PerformLayout
        Me.ToolStrip4.ResumeLayout(false)
        Me.ToolStrip4.PerformLayout
        Me.PanelBillDetails.ResumeLayout(false)
        Me.PanelBillDetails.PerformLayout
        CType(Me.ButtonDetails,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelShowBills.ResumeLayout(false)
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        FormsCollection.Forms.Add(Me)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents PatientName As System.Windows.Forms.ColumnHeader
    Friend WithEvents DOA As System.Windows.Forms.ColumnHeader
    Friend WithEvents BillNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents BillDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents BillAge As System.Windows.Forms.ColumnHeader
    Friend WithEvents PatientNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView1 As clsListView
    Friend WithEvents BillStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents ServiceDt As System.Windows.Forms.ColumnHeader
    Friend WithEvents ReqStatusDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents ReqStatusAge As System.Windows.Forms.ColumnHeader
    Friend WithEvents Insurance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Policy As System.Windows.Forms.ColumnHeader
    Friend WithEvents Claim As System.Windows.Forms.ColumnHeader
    Friend WithEvents AdjusterName As System.Windows.Forms.ColumnHeader
    Friend WithEvents AdjusterContact As System.Windows.Forms.ColumnHeader
    Friend WithEvents Attorney As System.Windows.Forms.ColumnHeader
    Friend WithEvents CourtIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SaveFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboDays As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrintCheckedBills3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelBills As System.Windows.Forms.Panel
    Friend WithEvents ListViewRequests As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ListViewComments As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnuAddSelectedBillNotes1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtPatientComments As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListViewPayments As System.Windows.Forms.ListView
    Friend WithEvents PaymentDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents Amount As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TreeViewBills As System.Windows.Forms.TreeView
    Friend WithEvents PanelBillDetails As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ButtonDetails As System.Windows.Forms.PictureBox
    Friend WithEvents PanelShowBills As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Amt As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripLabelCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabelAmount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents AttorneyDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents ArbitrationAttorney As System.Windows.Forms.ColumnHeader
    Friend WithEvents ArbitrationAttorneyDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboAttorney As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel8 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboInsurance As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripButtonReset As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
End Class
