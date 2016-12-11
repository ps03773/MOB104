Imports System.Data.SqlClient
Imports System.Data.DataSet
Imports System.IO
Public Class frmEdit_StaffList
    'Sub load ảnh từ CSDL
    Private Sub Loadanh()
        Dim Dadapter = New SqlDataAdapter("Select HINH From NHAN_VIEN Where MA_NV = '" & txtMaNV.Text & "'", Connect)
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
        dgvNV.DataSource = LoadNV.Tables(0) 'Load dữ liệu vào DataGridView
        btnHuy.Hide()
        '(Xóa kí tự trong Textbox
        txtMaNV.Clear()
        txtHoTen.Clear()
        txtSDT.Clear()
        txtDiaChi.Clear()
        txtLuong.Clear()
        ')
    End Sub

    'Sự kiện click vào ô bất kì trong DataGridView
    Private Sub dgvNV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNV.CellClick, dgvNV.CellClick
        '(Nếu có ô được click
        If dgvNV.SelectedCells.Count > 0 Then
            '(Dữ liệu hiển thị trên các Textbox và DateTimePicker sẽ lần lượt là từng cột trong cùng một hàng DataGridView
            txtMaNV.Text = dgvNV.CurrentRow.Cells(0).Value.ToString
            txtHoTen.Text = dgvNV.CurrentRow.Cells(1).Value.ToString
            txtSDT.Text = dgvNV.CurrentRow.Cells(2).Value.ToString
            txtDiaChi.Text = dgvNV.CurrentRow.Cells(3).Value.ToString
            dtpNgayLam.Text = dgvNV.CurrentRow.Cells(4).Value
            txtLuong.Text = dgvNV.CurrentRow.Cells(5).Value.ToString
            ')

            'Chúng ta sẽ gọi sub load ảnh từ CSDL
            Loadanh()
        End If
    End Sub

    'Nút thao tác
    Private Sub btnThaoTac_Click(sender As Object, e As EventArgs) Handles btnThaoTac.Click
        frmChangeStaPic.ShowDialog()
        If frmChangeStaPic.DialogResult = DialogResult.OK Then 'Kết quả thực thi của form chọn ảnh frmChangeProPic
            Loadanh()
        End If
    End Sub

    Private Sub btnXem_Click(sender As Object, e As EventArgs)
        frmTypeID.ShowDialog()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select MA_NV From NHAN_VIEN Where MA_NV = '" & txtMaNV.Text & "'", Connect)

        Try
            Connect.Open()
            If txtMaNV.Text = "" Or txtHoTen.Text = "" Or txtDiaChi.Text = "" Or txtLuong.Text = "" Then
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf IsNumeric(txtLuong.Text) = False Then
                MessageBox.Show _
                    ("Vui lòng nhập số vào ô Lương", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtLuong.Focus()
            ElseIf txtMaNV.Text.Contains("NV") = False Or Len(txtMaNV.Text) <> 6 Then
                MessageBox.Show _
                    ("Sai cú pháp" & vbCrLf & "Mã NV có dạng sau: 'NV****',với '****' là dãy số từ 0001 -> 9999", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtMaNV.Text = ""
                txtMaNV.Focus()
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count > 0 Then
                    MessageBox.Show("Trùng mã nhân viên", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtMaNV.Focus()
                Else
                    frmStaAddConfirm.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try

        If frmStaAddConfirm.DialogResult = Windows.Forms.DialogResult.OK Then
            dgvNV.DataSource = LoadNV.Tables(0)
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select MA_NV From NHAN_VIEN Where MA_NV = '" & txtMaNV.Text & "'", Connect)

        Try
            Connect.Open()
            If txtMaNV.Text = "" Then
                MessageBox.Show _
                    ("Vui lòng nhập mã nhân viên", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count > 0 Then
                    frmStaDelConfirm.ShowDialog()
                Else
                    MessageBox.Show("Mã nhân viên không khớp", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try

        If frmStaDelConfirm.DialogResult = Windows.Forms.DialogResult.OK Then
            dgvNV.DataSource = LoadNV.Tables(0)
        End If
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select MA_NV From NHAN_VIEN Where MA_NV = '" & txtMaNV.Text & "'", Connect)

        Try
            Connect.Open()
            If txtMaNV.Text = "" Or txtHoTen.Text = "" Or txtLuong.Text = "" Then
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count < 0 Then
                    MessageBox.Show("Mã nhân viên không khớp", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    btnHuy.Show()
                    If btnSua.Text = "Sửa" Then
                        txtMaNV.ReadOnly = True
                        btnSua.Text = "Update"
                        txtMaNV.Focus()
                    ElseIf btnSua.Text = "Update" Then
                        Dim Query As String = "Update NHAN_VIEN Set Ma_NV = @MaNV, HO_TEN = @HoTen, SDT = @SDT, DIA_CHI = @DiaChi, NGAY_VAO_LAM = @NgayVaoLam, LUONG = @Luong Where MA_NV = @MaNV"
                        Dim Update As SqlCommand = New SqlCommand(Query, Connect)

                        Update.Parameters.AddWithValue("@MaNV", txtMaNV.Text)
                        Update.Parameters.AddWithValue("@HoTen", txtHoTen.Text)
                        Update.Parameters.AddWithValue("@SDT", txtSDT.Text)
                        Update.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text)
                        Update.Parameters.AddWithValue("@NgayVaoLam", dtpNgayLam.Value)
                        Update.Parameters.AddWithValue("@Luong", txtLuong.Text)
                        Update.ExecuteNonQuery()

                        MessageBox.Show("Update thành công")
                        txtMaNV.ReadOnly = False
                        btnSua.Text = "Sửa"
                        btnHuy.Hide()

                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
        dgvNV.DataSource = Nothing
        dgvNV.DataSource = LoadNV.Tables(0)
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        txtMaNV.ReadOnly = False
        btnSua.Text = "Sửa"
        btnHuy.Hide()
        txtMaNV.Clear()
        txtHoTen.Clear()
        txtSDT.Clear()
        txtDiaChi.Clear()
        txtLuong.Clear()
    End Sub

    Private Sub btnNhaplai_Click(sender As Object, e As EventArgs) Handles btnNhaplai.Click
        txtMaNV.Clear()
        txtHoTen.Clear()
        txtSDT.Clear()
        txtDiaChi.Clear()
        txtLuong.Clear()
    End Sub

End Class