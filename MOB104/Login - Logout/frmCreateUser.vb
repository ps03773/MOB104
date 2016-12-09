Imports System.Data.SqlClient
Public Class frmCreateUser
    Private Sub frmCreateUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Clear()
        txtPassword.Clear()
        txtRe_password.Clear()
        txtFullName.Clear()
        txtEmail.Clear()
        lblDifference.Hide()
    End Sub

    Private Sub btnNhaplai_Click(sender As Object, e As EventArgs) Handles btnNhaplai.Click
        txtUsername.Clear()
        txtPassword.Clear()
        txtRe_password.Clear()
        txtFullName.Clear()
        txtEmail.Clear()
    End Sub

    Private Sub btnXacnhan_Click(sender As Object, e As EventArgs) Handles btnXacnhan.Click
        Dim db As New DataTable
        Dadapter = New SqlDataAdapter("Select USER_NAME From LOGIN_USER Where USER_NAME = '" & txtUsername.Text.ToLower & "'", Connect)
        Try
            Connect.Open()
            Dadapter.Fill(db)
            If db.Rows.Count > 0 Then
                MessageBox.Show("Tên tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf txtUsername.Text = "" Or txtPassword.Text = "" Or txtRe_password.Text = "" Or txtFullName.Text = "" Or txtEmail.Text = "" Then
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf txtRe_password.Text <> txtRe_password.Text Then
                MessageBox.Show("Mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf Len(txtPassword.Text) < 5 Then
                MessageBox.Show("Mật khẩu không hợp lệ" & vbCrLf &
                                "Vui lòng nhập mật khẩu gồm 5 -> 12 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf Len(txtPassword.Text) > 12 Then
                MessageBox.Show("Mật khẩu không hợp lệ" & vbCrLf &
                                "Vui lòng nhập mật khẩu gồm 5 -> 12 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf txtEmail.Text.Contains("@") = False Or txtEmail.Text.Contains(".com") = False Then
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim Sqlquery As String = "Insert Into LOGIN_USER Values( '" & txtUsername.Text & "', '" & txtPassword.Text & "', '" & txtFullName.Text & "', '" & txtEmail.Text & "')"
                Dim cmd As New SqlCommand(Sqlquery, Connect)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Tài khoản của bạn đã được tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUsername.Clear()
                txtPassword.Clear()
                txtRe_password.Clear()
                txtFullName.Clear()
                txtEmail.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try

    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text <> txtRe_password.Text Then
            lblDifference.Show()
        Else : lblDifference.Hide()
        End If
    End Sub

    Private Sub txtRe_password_TextChanged(sender As Object, e As EventArgs) Handles txtRe_password.TextChanged
        If txtPassword.Text <> txtRe_password.Text Then
            lblDifference.Show()
        Else : lblDifference.Hide()
        End If
    End Sub

End Class