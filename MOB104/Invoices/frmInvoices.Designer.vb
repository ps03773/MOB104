<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoices
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoices))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboMaKH = New System.Windows.Forms.ComboBox()
        Me.cboMaHD = New System.Windows.Forms.ComboBox()
        Me.ckxMaKH = New System.Windows.Forms.CheckBox()
        Me.ckxMaHD = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnViewAll = New System.Windows.Forms.Button()
        Me.dgvHD = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboMaKH)
        Me.GroupBox1.Controls.Add(Me.cboMaHD)
        Me.GroupBox1.Controls.Add(Me.ckxMaKH)
        Me.GroupBox1.Controls.Add(Me.ckxMaHD)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(453, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(262, 98)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tìm kiếm"
        '
        'cboMaKH
        '
        Me.cboMaKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaKH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMaKH.FormattingEnabled = True
        Me.cboMaKH.Location = New System.Drawing.Point(134, 43)
        Me.cboMaKH.Name = "cboMaKH"
        Me.cboMaKH.Size = New System.Drawing.Size(113, 23)
        Me.cboMaKH.TabIndex = 3
        '
        'cboMaHD
        '
        Me.cboMaHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaHD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMaHD.FormattingEnabled = True
        Me.cboMaHD.Location = New System.Drawing.Point(10, 43)
        Me.cboMaHD.Name = "cboMaHD"
        Me.cboMaHD.Size = New System.Drawing.Size(113, 23)
        Me.cboMaHD.TabIndex = 2
        '
        'ckxMaKH
        '
        Me.ckxMaKH.AutoSize = True
        Me.ckxMaKH.Location = New System.Drawing.Point(134, 72)
        Me.ckxMaKH.Name = "ckxMaKH"
        Me.ckxMaKH.Size = New System.Drawing.Size(90, 22)
        Me.ckxMaKH.TabIndex = 5
        Me.ckxMaKH.TabStop = False
        Me.ckxMaKH.Text = "Bỏ chọn"
        Me.ckxMaKH.UseVisualStyleBackColor = True
        '
        'ckxMaHD
        '
        Me.ckxMaHD.AutoSize = True
        Me.ckxMaHD.Location = New System.Drawing.Point(10, 72)
        Me.ckxMaHD.Name = "ckxMaHD"
        Me.ckxMaHD.Size = New System.Drawing.Size(90, 22)
        Me.ckxMaHD.TabIndex = 5
        Me.ckxMaHD.TabStop = False
        Me.ckxMaHD.Text = "Bỏ chọn"
        Me.ckxMaHD.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(131, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Mã KH"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mã HĐ"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(199, 53)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(94, 31)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Tìm kiếm"
        Me.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(89, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(348, 31)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "HÓA ĐƠN KHÁCH HÀNG"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(71, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'btnViewAll
        '
        Me.btnViewAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnViewAll.Image = CType(resources.GetObject("btnViewAll.Image"), System.Drawing.Image)
        Me.btnViewAll.Location = New System.Drawing.Point(95, 53)
        Me.btnViewAll.Name = "btnViewAll"
        Me.btnViewAll.Size = New System.Drawing.Size(98, 31)
        Me.btnViewAll.TabIndex = 1
        Me.btnViewAll.Text = "Xem tất cả"
        Me.btnViewAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnViewAll.UseVisualStyleBackColor = True
        '
        'dgvHD
        '
        Me.dgvHD.AllowUserToAddRows = False
        Me.dgvHD.AllowUserToDeleteRows = False
        Me.dgvHD.AllowUserToResizeColumns = False
        Me.dgvHD.AllowUserToResizeRows = False
        Me.dgvHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHD.GridColor = System.Drawing.SystemColors.Control
        Me.dgvHD.Location = New System.Drawing.Point(12, 116)
        Me.dgvHD.Name = "dgvHD"
        Me.dgvHD.ReadOnly = True
        Me.dgvHD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvHD.RowHeadersVisible = False
        Me.dgvHD.Size = New System.Drawing.Size(703, 295)
        Me.dgvHD.TabIndex = 13
        Me.dgvHD.TabStop = False
        '
        'frmInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(727, 425)
        Me.Controls.Add(Me.dgvHD)
        Me.Controls.Add(Me.btnViewAll)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInvoices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hóa đơn khách hàng"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnViewAll As System.Windows.Forms.Button
    Friend WithEvents dgvHD As System.Windows.Forms.DataGridView
    Friend WithEvents cboMaKH As ComboBox
    Friend WithEvents cboMaHD As ComboBox
    Friend WithEvents ckxMaKH As CheckBox
    Friend WithEvents ckxMaHD As CheckBox
End Class
