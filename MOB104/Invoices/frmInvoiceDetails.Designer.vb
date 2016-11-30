<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoiceDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoiceDetails))
        Me.btnViewAll = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dgvCTHD = New System.Windows.Forms.DataGridView()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboMaHD = New System.Windows.Forms.ComboBox()
        Me.cboMaKT = New System.Windows.Forms.ComboBox()
        Me.ckxMaHD = New System.Windows.Forms.CheckBox()
        Me.ckxMaKT = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCTHD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(89, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(279, 31)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "CHI TIẾT HÓA ĐƠN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(71, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'dgvCTHD
        '
        Me.dgvCTHD.AllowUserToAddRows = False
        Me.dgvCTHD.AllowUserToDeleteRows = False
        Me.dgvCTHD.AllowUserToResizeColumns = False
        Me.dgvCTHD.AllowUserToResizeRows = False
        Me.dgvCTHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCTHD.GridColor = System.Drawing.SystemColors.Control
        Me.dgvCTHD.Location = New System.Drawing.Point(12, 118)
        Me.dgvCTHD.Name = "dgvCTHD"
        Me.dgvCTHD.ReadOnly = True
        Me.dgvCTHD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvCTHD.RowHeadersVisible = False
        Me.dgvCTHD.Size = New System.Drawing.Size(703, 295)
        Me.dgvCTHD.TabIndex = 18
        Me.dgvCTHD.TabStop = False
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboMaHD)
        Me.GroupBox1.Controls.Add(Me.cboMaKT)
        Me.GroupBox1.Controls.Add(Me.ckxMaHD)
        Me.GroupBox1.Controls.Add(Me.ckxMaKT)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(453, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(262, 98)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tìm kiếm"
        '
        'cboMaHD
        '
        Me.cboMaHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaHD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMaHD.FormattingEnabled = True
        Me.cboMaHD.Location = New System.Drawing.Point(134, 43)
        Me.cboMaHD.Name = "cboMaHD"
        Me.cboMaHD.Size = New System.Drawing.Size(113, 23)
        Me.cboMaHD.TabIndex = 3
        '
        'cboMaKT
        '
        Me.cboMaKT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaKT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMaKT.FormattingEnabled = True
        Me.cboMaKT.Location = New System.Drawing.Point(10, 43)
        Me.cboMaKT.Name = "cboMaKT"
        Me.cboMaKT.Size = New System.Drawing.Size(113, 23)
        Me.cboMaKT.TabIndex = 2
        '
        'ckxMaHD
        '
        Me.ckxMaHD.AutoSize = True
        Me.ckxMaHD.Location = New System.Drawing.Point(134, 72)
        Me.ckxMaHD.Name = "ckxMaHD"
        Me.ckxMaHD.Size = New System.Drawing.Size(90, 22)
        Me.ckxMaHD.TabIndex = 5
        Me.ckxMaHD.TabStop = False
        Me.ckxMaHD.Text = "Bỏ chọn"
        Me.ckxMaHD.UseVisualStyleBackColor = True
        '
        'ckxMaKT
        '
        Me.ckxMaKT.AutoSize = True
        Me.ckxMaKT.Location = New System.Drawing.Point(10, 72)
        Me.ckxMaKT.Name = "ckxMaKT"
        Me.ckxMaKT.Size = New System.Drawing.Size(90, 22)
        Me.ckxMaKT.TabIndex = 5
        Me.ckxMaKT.TabStop = False
        Me.ckxMaKT.Text = "Bỏ chọn"
        Me.ckxMaKT.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(131, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Mã HĐ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mã KT"
        '
        'frmInvoiceDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(727, 425)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dgvCTHD)
        Me.Controls.Add(Me.btnViewAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInvoiceDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chi tiết hóa đơn"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCTHD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnViewAll As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dgvCTHD As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboMaHD As ComboBox
    Friend WithEvents cboMaKT As ComboBox
    Friend WithEvents ckxMaHD As CheckBox
    Friend WithEvents ckxMaKT As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
