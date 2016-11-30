Imports System.Data.SqlClient
Public Class frmCusDelConfirm

    Private Sub frmCusDelConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMaKH.Text = frmEdit_CustomerList.txtMaKH.Text
        lblTenKH.Text = frmEdit_CustomerList.txtTenKH.Text
        lblGioitinh.Text = frmEdit_CustomerList.txtGioitinh.Text
        lblDiachi.Text = frmEdit_CustomerList.txtDiachi.Text
        lblSDT.Text = frmEdit_CustomerList.txtSDT.Text
    End Sub


    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim Query As String = "Delete From KHACH_HANG Where Ma_KH = @MaKH"
        Dim Delete As SqlCommand = New SqlCommand(Query, Connect)

        Try
            Delete.Parameters.AddWithValue("@MaKH", lblMaKH.Text)
            Delete.ExecuteNonQuery()
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Close()
        End Try

        frmEdit_CustomerList.dgvKH.DataSource = Nothing
        frmEdit_CustomerList.txtMaKH.Text = ""
        frmEdit_CustomerList.txtTenKH.Text = ""
        frmEdit_CustomerList.txtGioitinh.Text = ""
        frmEdit_CustomerList.txtDiachi.Text = ""
        frmEdit_CustomerList.txtSDT.Text = ""
        Me.Close()
    End Sub

End Class