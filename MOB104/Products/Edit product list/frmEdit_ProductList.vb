Imports System.Data.SqlClient
Imports System.Data.DataSet
Imports System.IO
Public Class frmEdit_ProductList
    'Sub load ảnh từ CSDL
    Private Sub Loadanh()
        Dim Dadapter = New SqlDataAdapter("Select HINH From SAN_PHAM Where SO_SERI = '" & txtSoSR.Text & "'", Connect)
        Dim ds As New DataTable
        Try
            Connect.Open()
            Dadapter.Fill(ds)
            If IsDBNull(ds.Rows(0)("HINH")) = False Then 'Nếu có kết quả
                '(Load ảnh vào bộ nhớ
                Dim bytImage() As Byte = ds.Rows(0)("HINH")
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
        txtSoSR.Clear()
        txtMaSP.Clear()
        txtTenSP.Clear()
        txtNhanhieu.Clear()
        txtChip.Clear()
        txtRAM.Clear()
        txtHDD.Clear()
        txtGia.Clear()
        txtBaohanh.Clear()
        txtTrangthai.Clear()
        txtMaDL.Clear()
        ')
    End Sub

    'Sự kiện click vào ô bất kì trong DataGridView
    Private Sub dgvSP_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSP.CellClick
        '(Nếu có ô được click
        If dgvSP.SelectedCells.Count > 0 Then
            '(Dữ liệu hiển thị trên các Textbox và DateTimePicker sẽ lần lượt là từng cột trong cùng một hàng DataGridView
            txtSoSR.Text = dgvSP.CurrentRow.Cells(0).Value.ToString
            txtMaSP.Text = dgvSP.CurrentRow.Cells(1).Value.ToString
            txtTenSP.Text = dgvSP.CurrentRow.Cells(2).Value.ToString
            txtNhanhieu.Text = dgvSP.CurrentRow.Cells(3).Value.ToString
            txtChip.Text = dgvSP.CurrentRow.Cells(4).Value.ToString
            txtRAM.Text = dgvSP.CurrentRow.Cells(5).Value.ToString
            txtHDD.Text = dgvSP.CurrentRow.Cells(6).Value.ToString
            txtGia.Text = dgvSP.CurrentRow.Cells(7).Value.ToString
            txtBaohanh.Text = dgvSP.CurrentRow.Cells(8).Value.ToString
            txtTrangthai.Text = dgvSP.CurrentRow.Cells(9).Value.ToString
            txtMaDL.Text = dgvSP.CurrentRow.Cells(10).Value.ToString
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
        Dadapter = New SqlDataAdapter("Select SO_SERI From SAN_PHAM Where SO_SERI = '" & txtSoSR.Text & "'", Connect)
        Dim Dadapter2 As SqlDataAdapter = New SqlDataAdapter("Select Ma_DL From DAI_LY Where Ma_DL = '" & txtMaDL.Text & "'", Connect)
        Dim db2 As New DataTable

        Try
            Connect.Open()
            db2.Clear()
            Dadapter2.Fill(db2)
            If txtSoSR.Text = "" Or txtMaSP.Text = "" Or txtTenSP.Text = "" Or txtNhanhieu.Text = "" Or txtChip.Text = "" Or txtRAM.Text = "" Or txtHDD.Text = "" Or txtGia.Text = "" Or txtBaohanh.Text = "" Or txtTrangthai.Text = "" Or txtMaDL.Text = "" Then
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf IsNumeric(txtSoSR.Text) = False Then
                MessageBox.Show _
                    ("Vui lòng nhập số vào ô Số Seri", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf Len(txtSoSR.Text) <> 6 Then
                MessageBox.Show _
                    ("Vui lòng nhập đủ số Seri gồm 6 số", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf txtMaSP.Text.Contains("SP") = False Or Len(txtMaSP.Text) <> 6 Then
                MessageBox.Show _
                    ("Sai cú pháp" & vbCrLf & "Mã SP có dạng sau: 'SP****',với '****' là dãy số từ 0001 -> 9999", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtMaSP.Text = ""
                txtMaSP.Focus()
            ElseIf db2.Rows.Count = 0 Then
                MessageBox.Show("Mã đại lí không đúng" & vbCrLf & "Vui lòng tra cứu mã đại lí trước khi nhập", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf IsNumeric(txtGia.Text) = False Then
                MessageBox.Show _
                    ("Vui lòng nhập số vào đơn giá", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtGia.Focus()
            ElseIf IsNumeric(txtBaohanh.Text) = False Then
                MessageBox.Show _
                    ("Vui lòng nhập số vào ô bảo hành", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtBaohanh.Focus()
            ElseIf txtTrangthai.Text <> "Con" And txtTrangthai.Text <> "Het" Then
                MessageBox.Show _
                    ("Trạng thái chỉ được nhập [Con/Het]", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtTrangthai.Focus()
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count > 0 Then
                    MessageBox.Show("Trùng số seri", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Dadapter = New SqlDataAdapter("Select SO_SERI From SAN_PHAM Where SO_SERI = '" & txtSoSR.Text & "'", Connect)

        Try
            Connect.Open()
            If txtSoSR.Text = "" Then
                MessageBox.Show _
                    ("Vui lòng nhập số Seri", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count > 0 Then
                    frmProDelConfirm.ShowDialog()
                Else
                    MessageBox.Show("Số Seri không khớp", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Dadapter = New SqlDataAdapter("Select SO_SERI From SAN_PHAM Where SO_SERI = '" & txtSoSR.Text & "'", Connect)
        Dim Dadapter2 As SqlDataAdapter = New SqlDataAdapter("Select MA_DL From DAI_LY Where MA_DL = '" & txtMaDL.Text & "'", Connect)
        Dim db2 As New DataTable

        Try
            Connect.Open()
            db2.Clear()
            Dadapter2.Fill(db2)
            If txtSoSR.Text = "" Or txtMaSP.Text = "" Or txtTenSP.Text = "" Or txtNhanhieu.Text = "" Or txtChip.Text = "" Or txtRAM.Text = "" Or txtHDD.Text = "" Or txtGia.Text = "" Or txtBaohanh.Text = "" Or txtTrangthai.Text = "" Or txtMaDL.Text = "" Then
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count < 0 Then
                    MessageBox.Show("Số Seri không khớp", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    btnHuy.Show()
                    If btnSua.Text = "Sửa" Then
                        txtSoSR.ReadOnly = True
                        btnSua.Text = "Update"
                        txtMaSP.Focus()
                    ElseIf btnSua.Text = "Update" Then
                        Dim Query As String = "Update SAN_PHAM Set Ma_SP = @MaSP, Ten_SP = @TenSP, NHAN_HIEU = @NhanHieu, Chip = @Chip, RAM = @RAM, HDD_SDD = @HDD_SDD, Gia = @Gia, BAO_HANH_THANG = @Baohanh, TRANG_THAI = @TrangThai, MA_DL = @MaDL Where SO_SERI = @SoSR"
                        Dim Update As SqlCommand = New SqlCommand(Query, Connect)

                        If db2.Rows.Count = 0 Then
                            MessageBox.Show("Mã đại lí không đúng" & vbCrLf & "Vui lòng tra cứu mã đại lí trước khi nhập", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            Update.Parameters.AddWithValue("@SoSR", txtSoSR.Text)
                            Update.Parameters.AddWithValue("@MaSP", txtMaSP.Text)
                            Update.Parameters.AddWithValue("@TenSP", txtTenSP.Text)
                            Update.Parameters.AddWithValue("@NhanHieu", txtNhanhieu.Text)
                            Update.Parameters.AddWithValue("@Chip", txtChip.Text)
                            Update.Parameters.AddWithValue("@RAM", txtRAM.Text)
                            Update.Parameters.AddWithValue("@HDD_SDD", txtHDD.Text)
                            Update.Parameters.AddWithValue("@Gia", txtGia.Text)
                            Update.Parameters.AddWithValue("@BaoHanh", txtBaohanh.Text)
                            Update.Parameters.AddWithValue("@TrangThai", txtTrangthai.Text)
                            Update.Parameters.AddWithValue("@MaDL", txtMaDL.Text)
                            Update.ExecuteNonQuery()

                            MessageBox.Show("Update thành công")
                            txtSoSR.ReadOnly = False
                            btnSua.Text = "Sửa"
                            btnHuy.Hide()

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
        txtSoSR.ReadOnly = False
        btnSua.Text = "Sửa"
        btnHuy.Hide()
        txtSoSR.Text = ""
        txtMaSP.Text = ""
        txtTenSP.Text = ""
        txtNhanhieu.Text = ""
        txtChip.Text = ""
        txtRAM.Text = ""
        txtHDD.Text = ""
        txtGia.Text = ""
        txtBaohanh.Text = ""
        txtTrangthai.Text = ""
        txtMaDL.Text = ""
    End Sub

    Private Sub btnNhaplai_Click(sender As Object, e As EventArgs) Handles btnNhaplai.Click
        txtSoSR.Text = ""
        txtMaSP.Text = ""
        txtTenSP.Text = ""
        txtNhanhieu.Text = ""
        txtChip.Text = ""
        txtRAM.Text = ""
        txtHDD.Text = ""
        txtGia.Text = ""
        txtBaohanh.Text = ""
        txtTrangthai.Text = ""
        txtMaDL.Text = ""
    End Sub

End Class