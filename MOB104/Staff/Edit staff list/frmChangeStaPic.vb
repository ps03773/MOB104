Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Public Class frmChangeStapic
    Private GetPath As String 'Khai báo biến cục bộ để lưu đường dẫn đến file ảnh (dùng cho toàn form)

    'Sự kiện load form
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMaNV.Text = frmEdit_StaffList.txtMaNV.Text 'Lấy mã SP từ form Sản phẩm
        txtTenNV.Text = frmEdit_StaffList.txtHoTen.Text 'Lấy tên SP từ form Sản phẩm
        GetPath = "" 'Làm mới đường dẫn, set giá trị rỗng

        Dim Dadapter = New SqlDataAdapter("Select HINH, MA_NV From NHAN_VIEN Where MA_NV = '" & txtMaNV.Text & "'", Connect)
        Dim ds As New DataTable
        Try
            Connect.Open()
            Dadapter.Fill(ds)
            If IsDBNull(ds.Rows(0)("HINH")) = False Then 'Nếu có kết quả trả về => SP có trong table ANH_SAN_PHAM => vô hiệu hóa nút Add, cho phép đổi ảnh, xóa record
                btnAdd.Enabled = False
                btnDoi.Enabled = True
                btnXoa.Enabled = True
                '(Đọc dữ liệu trong cột Anh_SP, table ANH_SAN_PHAM
                Dim bytImage() As Byte = ds.Rows(0)("HINH")
                ')
                Dim stmImage As New MemoryStream(bytImage) 'Lưu ảnh vào bộ nhớ
                '(Hiển thị ảnh lên PictureBox
                KhungAnh.Image = Image.FromStream(stmImage)
                KhungAnh.SizeMode = PictureBoxSizeMode.Zoom
                ')
            Else
                KhungAnh.Image = KhungAnh.ErrorImage 'Không có kết quả trả về => PictureBox hiển thị ảnh mặc định
                KhungAnh.SizeMode = PictureBoxSizeMode.CenterImage
                '(Không thể đổi hay xóa ảnh vì không có dữ liệu => vô hiệu hóa nút Đổi & Xóa
                btnDoi.Enabled = False
                btnXoa.Enabled = False
                ')
                btnAdd.Enabled = True 'Nút Add được kích hoạt, có thể Add mã SP và ảnh SP vào CSDL
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try

    End Sub

    'Chọn ảnh
    Private Sub btnChon_Click(sender As Object, e As EventArgs) Handles btnChon.Click
        Try
            'Mo_chon_anh: Toolbox => OpenFileDialog
            '(Lọc phần đuôi mở rộng của file => chỉ chọn các file có định dạng ảnh
            Mo_chon_anh.Filter = "Image Files (*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)|*.jpg; *.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png"
            Mo_chon_anh.ShowDialog()
            ')
            Dim Path = Mo_chon_anh.FileName 'Khai báo biến Path dùng để lưu đường dẫn đến ảnh đã chọn
            GetPath = Path 'Biến Path chỉ dùng được trong Sub btnChon_Click => gán GetPath = Path
            '(Nếu không có đường dẫn, PictureBox hiển thị ảnh mặc định
            If String.IsNullOrEmpty(GetPath) Then
                KhungAnh.Image = KhungAnh.ErrorImage
                KhungAnh.SizeMode = PictureBoxSizeMode.CenterImage
                ')
            Else 'Ngược lại, PictureBox hiển thị ảnh đã chọn
                KhungAnh.Image = Image.FromFile(Path)
                KhungAnh.SizeMode = PictureBoxSizeMode.Zoom
            End If
        Catch
            MessageBox.Show("Vui lòng chọn ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'Thêm ảnh SP vào CSDL
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim cmd As New SqlCommand("Update NHAN_VIEN Set HINH = @ImageData Where MA_NV = @MaNV", Connect)
        Dim FilePath As String = GetPath 'Khai báo FilePath là biến lưu đường dẫn ảnh => gán đường dẫn từ GetPath cho FilePath
        If String.IsNullOrEmpty(FilePath) Then 'Nếu FilePath không chứa dũ liệu => hiện thông báo
            MessageBox.Show("Vui lòng chọn ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            btnDoi.Enabled = True
            btnXoa.Enabled = True
            Dim fsImage As New FileStream(FilePath, FileMode.Open, FileAccess.Read) 'Đọc ảnh trên ổ đĩa
            '(Chuyển đổi file hình ảnh sang kiểu dữ liệu Byte
            Dim bytImage(fsImage.Length() - 1) As Byte
            fsImage.Read(bytImage, 0, bytImage.Length)
            fsImage.Close()
            Dim prm As New SqlParameter("@ImageData", SqlDbType.VarBinary,
                bytImage.Length, ParameterDirection.Input, False,
                0, 0, Nothing, DataRowVersion.Current, bytImage)
            ')
            '(Gán giá trị cho 2 biến @MaSP & @ImageData trong câu lệnh SQL Insert dữ liệu
            cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text)
            cmd.Parameters.Add(prm)
            ')
            Try
                Connect.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Thêm thành công", "Thông báo")
                DialogResult = DialogResult.OK 'Kết quả thực thi
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Connect.Close()
            End Try
        End If
    End Sub

    'Đổi ảnh SP: cấu trúc code tương tự như thêm ảnh, chỉ khác câu lệnh SQL
    Private Sub Doi_Click(sender As Object, e As EventArgs) Handles btnDoi.Click
        Dim cmd As New SqlCommand("Update NHAN_VIEN Set HINH = @ImageData Where MA_NV = @MaNV", Connect)
        Dim FilePath As String = GetPath
        If String.IsNullOrEmpty(FilePath) Then
            MessageBox.Show("Vui lòng chọn ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim fsImage As New FileStream(FilePath,
            FileMode.Open, FileAccess.Read)
            Dim bytImage(fsImage.Length() - 1) As Byte
            fsImage.Read(bytImage, 0, bytImage.Length)
            fsImage.Close()
            Dim prm As New SqlParameter("@ImageData", SqlDbType.VarBinary,
                bytImage.Length, ParameterDirection.Input, False,
                0, 0, Nothing, DataRowVersion.Current, bytImage)
            cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text)
            cmd.Parameters.Add(prm)
            Try
                Connect.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Cập nhật thành công", "Thông báo")
                DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Connect.Close()
            End Try
        End If
    End Sub

    'Xóa 1 record với mã SP chúng ta đã chọn trong table ANH_SAN_PHAM
    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim cmd As New SqlCommand("Update NHAN_VIEN Set HINH = Null Where MA_NV = @MaNV", Connect)
        cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text)
        Try
            Connect.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Xóa thành công", "Thông báo")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Connect.Close()
        End Try
    End Sub

End Class