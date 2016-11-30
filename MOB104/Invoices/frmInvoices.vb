Imports System.Data.SqlClient
Imports System.Data.DataSet
Public Class frmInvoices

    Private Sub frmInvoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvHD.DataSource = LoadHD.Tables(0)
        cboMaHD.DataSource = LoadHD.Tables(0)
        cboMaHD.DisplayMember = "Mã HĐ"
        cboMaHD.ValueMember = "Mã HĐ"
        cboMaKH.DataSource = LoadKH.Tables(0)
        cboMaKH.DisplayMember = "Mã KH"
        cboMaKH.ValueMember = "Mã KH"
    End Sub

    Private Sub btnViewAll_Click(sender As Object, e As EventArgs) Handles btnViewAll.Click
        dgvHD.DataSource = Nothing
        dgvHD.DataSource = LoadHD.Tables(0)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimhoadon @Ma_HD = '" & cboMaHD.SelectedValue & "', @Ma_KH = '" & cboMaKH.SelectedValue & "'", Connect)
            db.Clear()
            dgvHD.DataSource = Nothing
                Dadapter.Fill(db)
            If db.Rows.Count > 0 Then
                dgvHD.DataSource = db.DefaultView
            Else
                MessageBox.Show("Không tìm được")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connect.Close()
        End Try
    End Sub

    Private Sub ckxMaHD_CheckedChanged(sender As Object, e As EventArgs) Handles ckxMaHD.CheckedChanged
        If ckxMaHD.Checked = True Then
            cboMaHD.DataSource = Nothing
        Else
            cboMaHD.DataSource = LoadHD.Tables(0)
            cboMaHD.DisplayMember = "Mã HĐ"
            cboMaHD.ValueMember = "Mã HĐ"
        End If
    End Sub

    Private Sub ckxMaKH_CheckedChanged(sender As Object, e As EventArgs) Handles ckxMaKH.CheckedChanged
        If ckxMaKH.Checked = True Then
            cboMaKH.DataSource = Nothing
        Else
            cboMaKH.DataSource = LoadKH.Tables(0)
            cboMaKH.DisplayMember = "Mã KH"
            cboMaKH.ValueMember = "Mã KH"
        End If
    End Sub
End Class