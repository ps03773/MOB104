<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginTable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginTable))
        Me.dgvMaLoai = New System.Windows.Forms.DataGridView()
        CType(Me.dgvMaLoai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMaLoai
        '
        Me.dgvMaLoai.AllowUserToAddRows = False
        Me.dgvMaLoai.AllowUserToDeleteRows = False
        Me.dgvMaLoai.AllowUserToResizeColumns = False
        Me.dgvMaLoai.AllowUserToResizeRows = False
        Me.dgvMaLoai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMaLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaLoai.GridColor = System.Drawing.SystemColors.Control
        Me.dgvMaLoai.Location = New System.Drawing.Point(13, 12)
        Me.dgvMaLoai.Name = "dgvMaLoai"
        Me.dgvMaLoai.ReadOnly = True
        Me.dgvMaLoai.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMaLoai.RowHeadersVisible = False
        Me.dgvMaLoai.Size = New System.Drawing.Size(639, 295)
        Me.dgvMaLoai.TabIndex = 21
        Me.dgvMaLoai.TabStop = False
        '
        'frmLoginTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(664, 322)
        Me.Controls.Add(Me.dgvMaLoai)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLoginTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tài khoản đăng nhập"
        CType(Me.dgvMaLoai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvMaLoai As System.Windows.Forms.DataGridView
End Class
