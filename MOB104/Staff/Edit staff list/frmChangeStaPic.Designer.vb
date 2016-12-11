<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeStapic
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangeStapic))
        Me.KhungAnh = New System.Windows.Forms.PictureBox()
        Me.Mo_chon_anh = New System.Windows.Forms.OpenFileDialog()
        Me.txtTenNV = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnChon = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDoi = New System.Windows.Forms.Button()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMaNV = New System.Windows.Forms.TextBox()
        CType(Me.KhungAnh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KhungAnh
        '
        Me.KhungAnh.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.KhungAnh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.KhungAnh.ErrorImage = CType(resources.GetObject("KhungAnh.ErrorImage"), System.Drawing.Image)
        Me.KhungAnh.Location = New System.Drawing.Point(12, 12)
        Me.KhungAnh.Name = "KhungAnh"
        Me.KhungAnh.Size = New System.Drawing.Size(208, 224)
        Me.KhungAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.KhungAnh.TabIndex = 2
        Me.KhungAnh.TabStop = False
        '
        'txtTenNV
        '
        Me.txtTenNV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenNV.Location = New System.Drawing.Point(303, 90)
        Me.txtTenNV.Name = "txtTenNV"
        Me.txtTenNV.ReadOnly = True
        Me.txtTenNV.Size = New System.Drawing.Size(125, 22)
        Me.txtTenNV.TabIndex = 2
        Me.txtTenNV.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(234, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Mã NV:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(234, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Tên NV:"
        '
        'btnChon
        '
        Me.btnChon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnChon.Image = CType(resources.GetObject("btnChon.Image"), System.Drawing.Image)
        Me.btnChon.Location = New System.Drawing.Point(237, 122)
        Me.btnChon.Name = "btnChon"
        Me.btnChon.Size = New System.Drawing.Size(87, 31)
        Me.btnChon.TabIndex = 3
        Me.btnChon.Text = "Chọn"
        Me.btnChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnChon.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(330, 122)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 31)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Thêm"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDoi
        '
        Me.btnDoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDoi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDoi.Image = CType(resources.GetObject("btnDoi.Image"), System.Drawing.Image)
        Me.btnDoi.Location = New System.Drawing.Point(237, 159)
        Me.btnDoi.Name = "btnDoi"
        Me.btnDoi.Size = New System.Drawing.Size(87, 31)
        Me.btnDoi.TabIndex = 5
        Me.btnDoi.Text = "Đổi"
        Me.btnDoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDoi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnXoa.Image = CType(resources.GetObject("btnXoa.Image"), System.Drawing.Image)
        Me.btnXoa.Location = New System.Drawing.Point(330, 159)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(87, 31)
        Me.btnXoa.TabIndex = 6
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(248, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(188, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "ẢNH NHÂN VIÊN"
        '
        'txtMaNV
        '
        Me.txtMaNV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaNV.Location = New System.Drawing.Point(303, 61)
        Me.txtMaNV.Name = "txtMaNV"
        Me.txtMaNV.ReadOnly = True
        Me.txtMaNV.Size = New System.Drawing.Size(125, 22)
        Me.txtMaNV.TabIndex = 2
        Me.txtMaNV.TabStop = False
        '
        'frmChangeStapic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(461, 248)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnDoi)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnChon)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMaNV)
        Me.Controls.Add(Me.txtTenNV)
        Me.Controls.Add(Me.KhungAnh)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmChangeStapic"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ảnh nhân viên"
        CType(Me.KhungAnh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KhungAnh As PictureBox
    Friend WithEvents Mo_chon_anh As OpenFileDialog
    Friend WithEvents txtTenNV As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnChon As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDoi As Button
    Friend WithEvents btnXoa As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMaNV As TextBox
End Class
