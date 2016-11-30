Imports System.Data.SqlClient
Public Class frmTypeID

    Private Sub frmTypeID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select Ma_loai as 'Mã Loại', Loai_san_pham as 'Loại sản phẩm', Mo_ta as 'Mô tả' From LOAI_SAN_PHAM", Connect)
        Dadapter.Fill(db)
        dgvMaLoai.DataSource = db.DefaultView
    End Sub

End Class