Imports System.Data.SqlClient
Public Class frmProDelConfirm
    
    Private Sub frmProDelConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMaSP.Text = frmEdit_ProductList.txtMaSP.Text
        lblTenSP.Text = frmEdit_ProductList.txtTenSP.Text
        lblMaLoai.Text = frmEdit_ProductList.txtMaLoai.Text
        lblNgayNhap.Text = frmEdit_ProductList.dtpNgayNhap.Text
        lblDonGia.Text = frmEdit_ProductList.txtDongia.Text
        lblTonKho.Text = frmEdit_ProductList.txtTonKho.Text
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim Query As String = "Delete From SAN_PHAM Where Ma_SP = @MaSP"
        Dim Delete As SqlCommand = New SqlCommand(Query, Connect)

        Try
            Delete.Parameters.AddWithValue("@MaSP", lblMaSP.Text)
            Delete.ExecuteNonQuery()
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Close()
        End Try

        frmEdit_ProductList.dgvSP.DataSource = Nothing
        frmEdit_ProductList.txtMaSP.Text = ""
        frmEdit_ProductList.txtTenSP.Text = ""
        frmEdit_ProductList.txtMaLoai.Text = ""
        frmEdit_ProductList.dtpNgayNhap.Text = ""
        frmEdit_ProductList.txtDongia.Text = ""
        frmEdit_ProductList.txtTonKho.Text = ""
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        Me.Close()
    End Sub
End Class