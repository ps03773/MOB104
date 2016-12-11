Imports System.Data.SqlClient
Public Class frmStaDelConfirm

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim Query As String = "Delete From NHAN_VIEN Where MA_NV = @MaNV"
        Dim Delete As SqlCommand = New SqlCommand(Query, Connect)

        Try
            Delete.Parameters.AddWithValue("@MaNV", frmEdit_StaffList.txtMaNV.Text)
            Delete.ExecuteNonQuery()
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Close()
        End Try

        frmEdit_StaffList.dgvNV.DataSource = Nothing
        frmEdit_StaffList.txtMaNV.Clear()
        frmEdit_StaffList.txtHoTen.Clear()
        frmEdit_StaffList.txtSDT.Clear()
        frmEdit_StaffList.txtDiaChi.Clear()
        frmEdit_StaffList.txtLuong.Clear()
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        Me.Close()
    End Sub
End Class