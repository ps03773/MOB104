Imports System.Data.SqlClient
Public Class frmCusAddConfirm

    Private Sub frmCusAddConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMaKH.Text = frmEdit_CustomerList.txtMaKH.Text
        lblTenKH.Text = frmEdit_CustomerList.txtTenKH.Text
        lblGioitinh.Text = frmEdit_CustomerList.txtGioitinh.Text
        lblDiachi.Text = frmEdit_CustomerList.txtDiachi.Text
        lblSDT.Text = frmEdit_CustomerList.txtSDT.Text
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim Query As String = "Insert Into KHACH_HANG Values(@MaKH, @TenKH, @Gioi_tinh, @Dia_chi, @SDT)"
        Dim Save As SqlCommand = New SqlCommand(Query, Connect)
        Dim ConvertGT As String

        If lblGioitinh.Text = "Nam" Then
            ConvertGT = 1
        Else : ConvertGT = 0
        End If

        Try
            Save.Parameters.AddWithValue("@MaKH", lblMaKH.Text)
            Save.Parameters.AddWithValue("@TenKH", lblTenKH.Text)
            Save.Parameters.AddWithValue("@Gioi_tinh", ConvertGT)
            Save.Parameters.AddWithValue("@Dia_chi", lblDiachi.Text)
            Save.Parameters.AddWithValue("@SDT", lblSDT.Text)
            Save.ExecuteNonQuery()
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        Me.Close()
    End Sub

End Class