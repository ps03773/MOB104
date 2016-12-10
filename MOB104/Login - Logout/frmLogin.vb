Imports System.Data.SqlClient
Public Class frmLogin
    'Đọc dữ liệu từ CSDL, table LOGIN_USER
    Private Function getDataTable(sqlQuery As String) As DataTable
        Dim Dtable As New DataTable
        Dadapter = New SqlDataAdapter(sqlQuery, Connect)

        Try
            Connect.Open()
            Dadapter.Fill(Dtable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi")
        Finally
            Connect.Close()
        End Try
        Return Dtable
    End Function

    'Kiểm tra tên đăng nhập và mật khẩu có trong CSDL hay không
    Private Function CheckLogin(Username As String, Password As String)
        Dim sqlQuery As String = String.Format("Select * From dbo.LOGIN_USER Where USER_NAME = '{0}' and PASSWORD = '{1}'", Username, Password)
        Dim Dtable As DataTable = getDataTable(sqlQuery)
        Return Dtable.Rows.Count > 0
    End Function

    Private Function IsEmpty() As Boolean
        Return String.IsNullOrEmpty(Me.txtUsername.Text) And String.IsNullOrEmpty(Me.txtPassword.Text)
    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If IsEmpty() Then
            MessageBox.Show("Vui lòng nhập Username và Password")
            txtUsername.Focus()
            '(Đăng nhập với tư cách khách, chỉ có thể tìm kiếm dữ liệu, không thể thay đổi
        ElseIf txtUsername.Text.ToLower = "guest" Then
            User = "Guest"
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            MessageBox.Show("Đăng nhập với tư cách khách")
            Me.Close()
            ')
        Else
            If CheckLogin(Me.txtUsername.Text.ToLower, Me.txtPassword.Text.ToLower) Then
                User = txtUsername.Text.ToLower
                txtUsername.Focus()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                MessageBox.Show("Đăng nhập thành công")
                Me.Close()
            Else
                MessageBox.Show("Sai Username hoặc Password")
                txtPassword.Clear()
                txtUsername.Focus()
            End If
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Đổi màu chữ khi rê chuột vào label
    Private Sub lblHuongDan_MouseEnter(sender As Object, e As EventArgs) Handles lblHuongDan.MouseEnter
        lblHuongDan.ForeColor = Color.Red
        lblHuongDan.Cursor = Cursors.Hand
    End Sub

    'Đổi màu chữ khi rê chuột khỏi label
    Private Sub lblHuongDan_MouseLeave(sender As Object, e As EventArgs) Handles lblHuongDan.MouseLeave
        lblHuongDan.ForeColor = SystemColors.Control
    End Sub

    Private Sub lblHuongDan_Click(sender As Object, e As EventArgs) Handles lblHuongDan.Click
        MessageBox.Show _
            ("Nếu bạn không có tài khoản User, nhập 'Guest' vào mục Username để đăng nhập với tài khoản khách", "Hướng dẫn đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lblTaoAccount_MouseEnter(sender As Object, e As EventArgs) Handles lblTaoAccount.MouseEnter
        lblTaoAccount.ForeColor = Color.Red
        lblTaoAccount.Cursor = Cursors.Hand
    End Sub

    Private Sub lblTaoAccount_MouseLeave(sender As Object, e As EventArgs) Handles lblTaoAccount.MouseLeave
        lblTaoAccount.ForeColor = SystemColors.Control
    End Sub

    Private Sub lblTaoAccount_Click(sender As Object, e As EventArgs) Handles lblTaoAccount.Click
        frmCreateUser.ShowDialog()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.Clear()
        txtUsername.Clear()
    End Sub
End Class