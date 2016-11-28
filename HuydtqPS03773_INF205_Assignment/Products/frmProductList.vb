Imports System.Data.SqlClient
Imports System.Data.DataSet
Public Class frmProductList

    Private Sub frmProductList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvSP.DataSource = LoadSP.Tables(0)
        Edata = LoadSP.Tables(0)

        txtMaSP.Clear()
        txtTenSP.Clear()
        txtMaLoai.Clear()
    End Sub

    Private Sub btnViewAll_Click(sender As Object, e As EventArgs) Handles btnViewAll.Click
        dgvSP.DataSource = Nothing
        dgvSP.DataSource = LoadSP.Tables(0)
        Edata.Clear()

        Edata = LoadSP.Tables(0)
        txtMaSP.Clear()
        txtTenSP.Clear()
        txtMaLoai.Clear()
    End Sub

    Private Sub txtMaSP_TextChanged(sender As Object, e As EventArgs) Handles txtMaSP.TextChanged
        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimsanpham @Ma_SP = '" & txtMaSP.Text & "', @Ten_SP = N'%" & txtTenSP.Text & "%', @Ma_loai = '%" & txtMaLoai.Text & "%'", Connect)
            db.Clear()
            Edata.Clear()
            Dadapter.Fill(db)
            Dadapter.Fill(Edata)
            dgvSP.DataSource = Nothing
            dgvSP.DataSource = db.DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
    End Sub

    Private Sub txtTenSP_TextChanged(sender As Object, e As EventArgs) Handles txtTenSP.TextChanged
        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimsanpham @Ma_SP = '" & txtMaSP.Text & "', @Ten_SP = N'%" & txtTenSP.Text & "%', @Ma_loai = '%" & txtMaLoai.Text & "%'", Connect)
            db.Clear()
            Edata.Clear()
            Dadapter.Fill(db)
            Dadapter.Fill(Edata)
            dgvSP.DataSource = Nothing
            dgvSP.DataSource = db.DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
    End Sub

    Private Sub txtLoaiSP_TextChanged(sender As Object, e As EventArgs) Handles txtMaLoai.TextChanged
        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimsanpham @Ma_SP = '" & txtMaSP.Text & "', @Ten_SP = N'%" & txtTenSP.Text & "%', @Ma_loai = '%" & txtMaLoai.Text & "%'", Connect)
            db.Clear()
            Edata.Clear()
            Dadapter.Fill(db)
            Dadapter.Fill(Edata)
            dgvSP.DataSource = Nothing
            dgvSP.DataSource = db.DefaultView
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
            Export_to_Excel(Edata, "Mã SP,Tên sản phẩm,Loại sản phẩm,Mã loại,Ngày nhập,Đơn giá,SL tồn kho", File_name)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

End Class