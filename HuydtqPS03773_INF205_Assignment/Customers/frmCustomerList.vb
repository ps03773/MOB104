Imports System.Data.SqlClient
Imports System.Data.DataSet
Public Class frmCustomerList
    Private Sub frmCustomerList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvKH.DataSource = LoadKH.Tables(0)
        Edata = LoadKH.Tables(0)
        txtMaKH.Clear()
        txtTenKH.Clear()
        txtDiaChi.Clear()
    End Sub

    Private Sub txtMaKH_TextChanged(sender As Object, e As EventArgs) Handles txtMaKH.TextChanged
        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimkhachhang @Ma_KH = '" & txtMaKH.Text & "', @Ten_KH = N'%" & txtTenKH.Text & "%', @Dia_chi = N'%" & txtDiaChi.Text & "%'", Connect)
            db.Clear()
            Edata.Clear()
            Dadapter.Fill(db)
            Dadapter.Fill(Edata)
            dgvKH.DataSource = Nothing
            dgvKH.DataSource = db.DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
    End Sub

    Private Sub txtTenKH_TextChanged(sender As Object, e As EventArgs) Handles txtTenKH.TextChanged, txtMaKH.TextChanged
        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimkhachhang @Ma_KH = '" & txtMaKH.Text & "', @Ten_KH = N'%" & txtTenKH.Text & "%', @Dia_chi = N'%" & txtDiaChi.Text & "%'", Connect)
            db.Clear()
            Edata.Clear()
            Dadapter.Fill(db)
            Dadapter.Fill(Edata)
            dgvKH.DataSource = Nothing
            dgvKH.DataSource = db.DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
    End Sub

    Private Sub txtDiaChi_TextChanged(sender As Object, e As EventArgs) Handles txtDiaChi.TextChanged
        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimkhachhang @Ma_KH = '" & txtMaKH.Text & "', @Ten_KH = N'%" & txtTenKH.Text & "%', @Dia_chi = N'%" & txtDiaChi.Text & "%'", Connect)
            db.Clear()
            Edata.Clear()
            Dadapter.Fill(db)
            Dadapter.Fill(Edata)
            dgvKH.DataSource = Nothing
            dgvKH.DataSource = db.DefaultView
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
            Export_to_Excel(Edata, "Mã KH,Tên khách hàng,Giới tính,Địa chỉ,SĐT", File_name)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

End Class