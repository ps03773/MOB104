Imports System.Data.SqlClient
Imports System.Data.DataSet
Public Class frmStaffList

    Private Sub frmStaffList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvNV.DataSource = LoadNV.Tables(0)
        Edata = LoadNV.Tables(0)

        txtMaNV.Clear()
        txtHoTen.Clear()
        txtDiaChi.Clear()
    End Sub

    Private Sub btnViewAll_Click(sender As Object, e As EventArgs) Handles btnViewAll.Click
        dgvNV.DataSource = Nothing
        dgvNV.DataSource = LoadNV.Tables(0)
        Edata.Clear()

        Edata = LoadNV.Tables(0)
        txtMaNV.Clear()
        txtHoTen.Clear()
        txtDiaChi.Clear()
    End Sub

    Private Sub txtMaNV_TextChanged(sender As Object, e As EventArgs) Handles txtMaNV.TextChanged
        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimkiemNV @Ma_NV = '%" & txtMaNV.Text & "%', @Ho_Ten = '%" & txtHoTen.Text & "%', @Dia_Chi = '%" & txtDiaChi.Text & "%'", Connect)
            db.Clear()
            Edata.Clear()
            Dadapter.Fill(db)
            Dadapter.Fill(Edata)
            dgvNV.DataSource = Nothing
            dgvNV.DataSource = db.DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
    End Sub

    Private Sub txtTenNV_TextChanged(sender As Object, e As EventArgs) Handles txtHoTen.TextChanged
        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimkiemNV @Ma_NV = '%" & txtMaNV.Text & "%', @Ho_Ten = '%" & txtHoTen.Text & "%', @Dia_Chi = '%" & txtDiaChi.Text & "%'", Connect)
            db.Clear()
            Edata.Clear()
            Dadapter.Fill(db)
            Dadapter.Fill(Edata)
            dgvNV.DataSource = Nothing
            dgvNV.DataSource = db.DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
    End Sub

    Private Sub txtLoaiNV_TextChanged(sender As Object, e As EventArgs) Handles txtDiaChi.TextChanged
        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimkiemNV @Ma_NV = '%" & txtMaNV.Text & "%', @Ho_Ten = '%" & txtHoTen.Text & "%', @Dia_Chi = '%" & txtDiaChi.Text & "%'", Connect)
            db.Clear()
            Edata.Clear()
            Dadapter.Fill(db)
            Dadapter.Fill(Edata)
            dgvNV.DataSource = Nothing
            dgvNV.DataSource = db.DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
    End Sub

    Private Sub btnXuatDL_Click(sender As Object, e As EventArgs) Handles btnXuatDL.Click
        Try
            SaveFileDialog1.Filter = "Excel (*.xlsx)|*.xlsx"
            SaveFileDialog1.ShowDialog()
            Dim File_name = SaveFileDialog1.FileName
            Export_to_Excel(Edata, "Mã NV,Họ & Tên,SĐT,Địa chỉ,Ngày vào làm,Lương", File_name)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

End Class