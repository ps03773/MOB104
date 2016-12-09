Imports System.Data.SqlClient
Public Class frmProAddConfirm

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim Query As String = "Insert Into SAN_PHAM(SO_SERI, MA_SP, TEN_SP, NHAN_HIEU, CHIP, RAM, HDD_SDD, GIA, BAO_HANH_THANG, TRANG_THAI, MA_DL) Values(@SoSR, @MaSP, @TenSp, @NhanHieu, @Chip, @RAM, @HDD_SDD, @Gia, @BaoHanh, @TrangThai, @MaDL)"
        Dim Save As SqlCommand = New SqlCommand(Query, Connect)

        Try
            Save.Parameters.AddWithValue("@SoSR", frmEdit_ProductList.txtSoSR.Text)
            Save.Parameters.AddWithValue("@MaSP", frmEdit_ProductList.txtMaSP.Text)
            Save.Parameters.AddWithValue("@TenSP", frmEdit_ProductList.txtTenSP.Text)
            Save.Parameters.AddWithValue("@NhanHieu", frmEdit_ProductList.txtNhanhieu.Text)
            Save.Parameters.AddWithValue("@Chip", frmEdit_ProductList.txtChip.Text)
            Save.Parameters.AddWithValue("@RAM", frmEdit_ProductList.txtRAM.Text)
            Save.Parameters.AddWithValue("@HDD_SDD", frmEdit_ProductList.txtHDD.Text)
            Save.Parameters.AddWithValue("@Gia", frmEdit_ProductList.txtGia.Text)
            Save.Parameters.AddWithValue("@BaoHanh", frmEdit_ProductList.txtBaohanh.Text)
            Save.Parameters.AddWithValue("@TrangThai", frmEdit_ProductList.txtTrangthai.Text)
            Save.Parameters.AddWithValue("@MaDL", frmEdit_ProductList.txtMaDL.Text)
            Save.ExecuteNonQuery()
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Close()
        End Try

        frmEdit_ProductList.dgvSP.DataSource = Nothing
        frmEdit_ProductList.txtSoSR.Text = ""
        frmEdit_ProductList.txtMaSP.Text = ""
        frmEdit_ProductList.txtTenSP.Text = ""
        frmEdit_ProductList.txtNhanhieu.Text = ""
        frmEdit_ProductList.txtChip.Text = ""
        frmEdit_ProductList.txtRAM.Text = ""
        frmEdit_ProductList.txtHDD.Text = ""
        frmEdit_ProductList.txtGia.Text = ""
        frmEdit_ProductList.txtBaohanh.Text = ""
        frmEdit_ProductList.txtTrangthai.Text = ""
        frmEdit_ProductList.txtMaDL.Text = ""
        Me.Close()
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        Me.Close()
    End Sub

End Class