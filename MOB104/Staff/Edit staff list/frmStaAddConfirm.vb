Imports System.Data.SqlClient
Public Class frmStaAddConfirm

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim Query As String = "Insert Into NHAN_VIEN(MA_NV, HO_TEN, SDT, DIA_CHI, NGAY_VAO_LAM, LUONG) Values(@MaNV, @HoTen, @SDT, @DiaChi, @NgayVaoLam, @Luong)"
        Dim Save As SqlCommand = New SqlCommand(Query, Connect)

        Try
            Save.Parameters.AddWithValue("@MaNV", frmEdit_StaffList.txtMaNV.Text)
            Save.Parameters.AddWithValue("@HoTen", frmEdit_StaffList.txtHoTen.Text)
            Save.Parameters.AddWithValue("@SDT", frmEdit_StaffList.txtSDT.Text)
            Save.Parameters.AddWithValue("@DiaChi", frmEdit_StaffList.txtDiaChi.Text)
            Save.Parameters.AddWithValue("@NgayVaolam", frmEdit_StaffList.dtpNgayLam.Value)
            Save.Parameters.AddWithValue("@Luong", frmEdit_StaffList.txtLuong.Text)
            Save.ExecuteNonQuery()
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Me.Close()
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        Me.Close()
    End Sub

End Class