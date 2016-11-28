Imports System.Data.SqlClient
Imports System.Data.DataSet
Public Class frmEdit_CustomerList

    Private Sub frmEdit_CustomerList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvKH.DataSource = LoadKH.Tables(0)
        btnHuy.Hide()
    End Sub

    Private Sub dgvKH_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKH.CellClick
        If dgvKH.SelectedCells.Count > 0 Then
            Dim MaKH As String = dgvKH.CurrentRow.Cells(0).Value.ToString
            Dim TenKH As String = dgvKH.CurrentRow.Cells(1).Value.ToString
            Dim Gioi_tinh As String = dgvKH.CurrentRow.Cells(2).Value.ToString
            Dim Dia_chi As String = dgvKH.CurrentRow.Cells(3).Value.ToString
            Dim SDT As String = dgvKH.CurrentRow.Cells(4).Value.ToString

            txtMaKH.Text = MaKH
            txtTenKH.Text = TenKH
            txtGioitinh.Text = Gioi_tinh
            txtDiachi.Text = Dia_chi
            txtSDT.Text = SDT
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select Ma_KH From KHACH_HANG Where Ma_KH = '" & txtMaKH.Text & "'", Connect)

        Try
            Connect.Open()
            If txtMaKH.Text = "" Or txtTenKH.Text = "" Or txtGioitinh.Text = "" Or txtDiachi.Text = "" Then
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf txtMaKH.Text.Contains("KH") = False Or Len(txtMaKH.Text) <> 6 Then
                MessageBox.Show _
                    ("Sai cú pháp" & vbCrLf & "Mã KH có dạng sau: 'KH****',với '****' là dãy số từ 0001 -> 9999", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtMaKH.Text = ""
                txtMaKH.Focus()
            ElseIf txtGioitinh.Text <> "Nam" And txtGioitinh.Text <> "Nữ" Then
                MessageBox.Show _
                    ("Giới tính chỉ được nhập 'Nam' hoặc 'Nữ'", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtGioitinh.Focus()
            ElseIf IsNumeric(txtSDT.Text) = False Then
                MessageBox.Show _
                    ("Vui lòng nhập đúng số điện thoại", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtSDT.Focus()
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count > 0 Then
                    MessageBox.Show("Trùng mã KH", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtMaKH.Focus()
                Else
                    frmCusAddConfirm.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try

        If frmCusAddConfirm.DialogResult = Windows.Forms.DialogResult.OK Then
            dgvKH.DataSource = LoadKH.Tables(0)
        End If
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select Ma_KH From KHACH_HANG Where Ma_KH = '" & txtMaKH.Text & "'", Connect)

        Try
            Connect.Open()
            If txtMaKH.Text = "" Or txtTenKH.Text = "" Or txtGioitinh.Text = "" Or txtDiachi.Text = "" Then
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf txtGioitinh.Text <> "Nam" And txtGioitinh.Text <> "Nữ" Then
                MessageBox.Show _
                    ("Giới tính chỉ được nhập 'Nam' hoặc 'Nữ'", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtGioitinh.Focus()
            Else
                Dim ConvertGT As String
                If txtGioitinh.Text = "Nam" Then
                    ConvertGT = 1
                Else : ConvertGT = 0
                End If
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count < 0 Then
                    MessageBox.Show("Mã khách hàng không khớp", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    btnHuy.Show()
                    If btnSua.Text = "Sửa" Then
                        txtMaKH.ReadOnly = True
                        btnSua.Text = "Update"
                        txtTenKH.Focus()
                    ElseIf btnSua.Text = "Update" Then
                        Dim Query As String = "Update KHACH_HANG Set Ho_ten_KH = @TenKH, Gioi_tinh = @Gioi_tinh, Dia_chi = @Dia_chi, SDT = @SDT Where Ma_KH= @MaKH"
                        Dim Update As SqlCommand = New SqlCommand(Query, Connect)

                        Update.Parameters.AddWithValue("@MaKH", txtMaKH.Text)
                        Update.Parameters.AddWithValue("@TenKH", txtTenKH.Text)
                        Update.Parameters.AddWithValue("@Gioi_tinh", ConvertGT)
                        Update.Parameters.AddWithValue("@Dia_chi", txtDiachi.Text)
                        Update.Parameters.AddWithValue("@SDT", txtSDT.Text)
                        Update.ExecuteNonQuery()

                        MessageBox.Show("Update thành công")
                        txtMaKH.ReadOnly = False
                        btnSua.Text = "Sửa"
                        txtMaKH.Text = ""
                        txtTenKH.Text = ""
                        txtGioitinh.Text = ""
                        txtDiachi.Text = ""
                        txtSDT.Text = ""
                        btnHuy.Hide()

                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
        dgvKH.DataSource = Nothing
        dgvKH.DataSource = LoadKH.Tables(0)
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        btnSua.Text = "Sửa"
        txtMaKH.Text = ""
        txtMaKH.ReadOnly = False
        txtTenKH.Text = ""
        txtGioitinh.Text = ""
        txtDiachi.Text = ""
        txtSDT.Text = ""
        btnHuy.Hide()

    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select Ma_KH From KHACH_HANG Where Ma_KH = '" & txtMaKH.Text & "'", Connect)

        Try
            Connect.Open()
            If txtMaKH.Text = "" Then
                MessageBox.Show _
                    ("Vui lòng nhập mã khách hàng", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                db.Clear()
                Dadapter.Fill(db)
                If db.Rows.Count > 0 Then
                    frmCusDelConfirm.ShowDialog()
                Else
                    MessageBox.Show("Mã khách hàng không khớp", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try

        If frmCusDelConfirm.DialogResult = Windows.Forms.DialogResult.OK Then
            dgvKH.DataSource = LoadKH.Tables(0)
        End If
    End Sub

    Private Sub btnNhaplai_Click(sender As Object, e As EventArgs) Handles btnNhaplai.Click
        txtMaKH.Text = ""
        txtTenKH.Text = ""
        txtGioitinh.Text = ""
        txtDiachi.Text = ""
        txtSDT.Text = ""
        txtMaKH.Focus()
    End Sub

End Class