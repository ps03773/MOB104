Imports System.Data.SqlClient
Public Class frmProDelConfirm

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim Query As String = "Delete From SAN_PHAM Where SO_SERI = @SoSR"
        Dim Delete As SqlCommand = New SqlCommand(Query, Connect)

        Try
            Delete.Parameters.AddWithValue("@SoSR", frmEdit_ProductList.txtSoSR.Text)
            Delete.ExecuteNonQuery()
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        Me.Close()
    End Sub
End Class