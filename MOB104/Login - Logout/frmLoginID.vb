Imports System.Data.SqlClient
Public Class frmLoginTable

    Private Sub frmfrmLoginTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select USER_NAME as 'Tên đăng nhập', PASSWORD as 'Mật khẩu', TEN_DANG_NHAP as 'Họ tên', EMAIL as 'Địa chỉ Email' From LOGIN_USER", Connect)
        Dadapter.Fill(db)
        dgvMaLoai.DataSource = db.DefaultView
    End Sub

End Class