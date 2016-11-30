Imports System.Data.SqlClient
Imports System.Data.DataSet
Imports System.IO
Public Class frmEdit_ProductList
    'Sub load ảnh từ CSDL
    Private Sub Loadanh()
        Dim Dadapter = New SqlDataAdapter("Select * From ANH_SAN_PHAM Where Ma_SP = '" & txtMaSP.Text & "'", Connect)
        Dim ds As New DataTable
        Try
            Connect.Open()
            Dadapter.Fill(ds)
            Dim c As Integer = ds.Rows.Count 'Biến c dùng để đếm số dùng trong kết quả trả về từ câu truy vấn SQL
            If c > 0 Then 'Nếu có kết quả
                '(Load ảnh vào bộ nhớ
                Dim bytImage() As Byte =
                    ds.Rows(c - 1)("Anh_SP")
                Dim stmImage As New MemoryStream(bytImage)
                ')
                KhungAnh.SizeMode = PictureBoxSizeMode.Zoom
                KhungAnh.Image = Image.FromStream(stmImage) 'Hiển thị lên PictureBox
            Else 'Không có kết quả => PictureBox hiển thị ảnh mặc định
                KhungAnh.Image = KhungAnh.ErrorImage
                KhungAnh.SizeMode = PictureBoxSizeMode.CenterImage
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
    End Sub

    'Sự kiện load form
    Private Sub frmEdit_ProductList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KhungAnh.Image = KhungAnh.ErrorImage 'PictureBox hiển thị ảnh mặc định
        KhungAnh.SizeMode = PictureBoxSizeMode.CenterImage
        dgvSP.DataSource = LoadSP.Tables(0) 'Load dữ liệu vào DataGridView
        btnHuy.Hide()
        '(Xóa kí tự trong Textbox
        txtMaSP.Clear()
        txtTenSP.Clear()
        txtMaLoai.Clear()
        txtDongia.Clear()
        txtTonKho.Clear()
        ')
    End Sub

    'Sự kiện click vào ô bất kì trong DataGridView
    Private Sub dgvSP_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSP.CellClick
        '(Nếu có ô được click
        If dgvSP.SelectedCells.Count > 0 Then
            '(Dữ liệu hiển thị trên các Textbox và DateTimePicker sẽ lần lượt là từng cột trong cùng một hàng DataGridView
            txtMaSP.Text = dgvSP.CurrentRow.Cells(0).Value.ToString
            txtTenSP.Text = dgvSP.CurrentRow.Cells(1).Value.ToString
            txtMaLoai.Text = dgvSP.CurrentRow.Cells(3).Value.ToString
            dtpNgayNhap.Value = dgvSP.CurrentRow.Cells(4).Value.ToString
            txtDongia.Text = dgvSP.CurrentRow.Cells(5).Value.ToString
            txtTonKho.Text = dgvSP.CurrentRow.Cells(6).Value.ToString
            ')

            'Chúng ta sẽ gọi sub load ảnh từ CSDL
            Loadanh()
        End If
    End Sub

    'Nút thao tác
    Private Sub btnThaoTac_Click(sender As Object, e As EventArgs) Handles btnThaoTac.Click
        frmChangeProPic.ShowDialog()
        If frmChangeProPic.DialogResult = DialogResult.OK Then 'Kết quả thực thi của form chọn ảnh frmChangeProPic
            Loadanh()
        End If
    End Sub

    Private Sub btnXem_Click(sender As Object, e As EventArgs) Handles btnXem.Click
        frmTypeID.ShowDialog()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select Ma_SP From SAN_PHAM Where Ma_SP = '" & txtMaSP.Text & "'", Connect)
        Dim Dadapter2 As SqlDataAdapter = New SqlDataAdapter("Select Ma_loai From LOAI_SAN_PHAM Where Ma_loai = '" & txtMaLoai.Text & "'", Connect)
        Dim db2 As New DataTable

        Try
            Connect.Open()
            db2.Clear()
            Dadapter2.Fill(db2)
            If txtMaSP.Text = "" Or txtTenSP.Text = "" Or txtMaLoai.Text = "" Or txtDongia.Text = "" Or txtTonKho.Text = "" Then
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf txtMaSP.Text.Contains("SP") = False Or Len(txtMaSP.Text) <> 6 Then
                MessageBox.Show _
                    ("Sai cú pháp" & vbCrLf & "Mã SP có dạng sau: 'SP****',với '****' là dãy số từ 0001 -> 9999", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtMaSP.Text = ""
                txtMaSP.Focus()
            ElseIf db2.Rows.Count = 0 Then
                MessageBox.Show("Mã loại không hợp lệ" & vbCrLf & "Vui lòng tra cứu mã loại trước khi nhập", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf IsNumeric(txtDongia.Text) = False Then
                MessageBox.Show _
                    ("Vui lòng nhập số vào đơn giá", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDongia.Focus()
            ElseIf IsNumeric(txtTonKho.Text) = False Then
                MessageBox.Show _
                    ("Vui lòng nhập số vào SL tồn kho", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtTonKho.Focus()
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count > 0 Then
                    MessageBox.Show("Trùng mã SP", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtMaSP.Focus()
                Else
                    frmProAddConfirm.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try

        If frmProAddConfirm.DialogResult = Windows.Forms.DialogResult.OK Then
            dgvSP.DataSource = LoadSP.Tables(0)
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select Ma_SP From SAN_PHAM Where Ma_SP = '" & txtMaSP.Text & "'", Connect)

        Try
            Connect.Open()
            If txtMaSP.Text = "" Then
                MessageBox.Show _
                    ("Vui lòng nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count > 0 Then
                    frmProDelConfirm.ShowDialog()
                Else
                    MessageBox.Show("Mã sản phẩm không khớp", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try

        If frmProDelConfirm.DialogResult = Windows.Forms.DialogResult.OK Then
            dgvSP.DataSource = LoadSP.Tables(0)
        End If
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select Ma_SP From SAN_PHAM Where Ma_SP = '" & txtMaSP.Text & "'", Connect)
        Dim Dadapter2 As SqlDataAdapter = New SqlDataAdapter("Select Ma_loai From LOAI_SAN_PHAM Where Ma_loai = '" & txtMaLoai.Text & "'", Connect)
        Dim db2 As New DataTable

        Try
            Connect.Open()
            db2.Clear()
            Dadapter2.Fill(db2)
            If txtMaSP.Text = "" Or txtTenSP.Text = "" Or txtMaLoai.Text = "" Or txtDongia.Text = "" Or txtTonKho.Text = "" Then
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count < 0 Then
                    MessageBox.Show("Mã sản phẩm không khớp", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    btnHuy.Show()
                    If btnSua.Text = "Sửa" Then
                        txtMaSP.ReadOnly = True
                        btnSua.Text = "Update"
                        txtTenSP.Focus()
                    ElseIf btnSua.Text = "Update" Then
                        Dim Query As String = "Update SAN_PHAM Set Ma_loai = @MaLoai, Ten_SP = @TenSP, Ngay_nhap = @NgayNhap, Don_gia= @DonGia, SL_ton_kho = @TonKho Where Ma_SP= @MaSP"
                        Dim Update As SqlCommand = New SqlCommand(Query, Connect)

                        If db2.Rows.Count = 0 Then
                            MessageBox.Show("Mã loại không hợp lệ" & vbCrLf & "Vui lòng tra cứu mã loại trước khi nhập", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            Update.Parameters.AddWithValue("@MaSP", txtMaSP.Text)
                            Update.Parameters.AddWithValue("@MaLoai", txtMaLoai.Text)
                            Update.Parameters.AddWithValue("@TenSP", txtTenSP.Text)
                            Update.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value)
                            Update.Parameters.AddWithValue("@DonGia", txtDongia.Text)
                            Update.Parameters.AddWithValue("@TonKho", txtTonKho.Text)
                            Update.ExecuteNonQuery()

                            MessageBox.Show("Update thành công")
                            txtMaSP.ReadOnly = False
                            btnSua.Text = "Sửa"
                            btnHuy.Hide()
                            txtMaSP.Text = ""
                            txtMaLoai.Text = ""
                            txtTenSP.Text = ""
                            txtDongia.Text = ""
                            txtTonKho.Text = ""
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
        dgvSP.DataSource = Nothing
        dgvSP.DataSource = LoadSP.Tables(0)
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        txtMaSP.ReadOnly = False
        btnSua.Text = "Sửa"
        btnHuy.Hide()
        txtMaSP.Text = ""
        txtMaLoai.Text = ""
        txtTenSP.Text = ""
        txtDongia.Text = ""
        txtTonKho.Text = ""
    End Sub

    Private Sub btnNhaplai_Click(sender As Object, e As EventArgs) Handles btnNhaplai.Click
        txtMaSP.Text = ""
        txtMaLoai.Text = ""
        txtTenSP.Text = ""
        txtDongia.Text = ""
        txtTonKho.Text = ""
    End Sub

End Class