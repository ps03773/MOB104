Imports System.Data.SqlClient
Public Class frmTypeID

    Private Sub frmTypeID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select Ma_DL as 'Mã đại lí', TEN_DL as 'Tên đại lí', SDT as 'SĐT', DIA_CHI as 'Địa chỉ' From DAI_LY", Connect)
        Dadapter.Fill(db)
        dgvMaLoai.DataSource = db.DefaultView
    End Sub

End Class