Imports System.Data.SqlClient
Imports System.Data.DataSet
Public Class frmInvoiceDetails

    Private Sub frmInvoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCTHD.DataSource = LoadCTHD.Tables(0)
        cboMaHD.DataSource = LoadHD.Tables(0)
        cboMaHD.DisplayMember = "Mã HĐ"
        cboMaHD.ValueMember = "Mã HĐ"
        cboMaKT.DataSource = LoadCTHD.Tables(0)
        cboMaKT.DisplayMember = "Mã kiểm tra"
        cboMaKT.ValueMember = "Mã kiểm tra"
    End Sub

    Private Sub btnViewAll_Click(sender As Object, e As EventArgs) Handles btnViewAll.Click
        dgvCTHD.DataSource = Nothing
        dgvCTHD.DataSource = LoadCTHD.Tables(0)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Try
            Connect.Open()
            Dim db As New DataTable
            Dadapter = New SqlDataAdapter _
                ("Exec spTimchitiethoadon @Ma_HD = '" & cboMaHD.SelectedValue & "', @Ma_KT = '" & cboMaKT.SelectedValue & "'", Connect)
            db.Clear()
            dgvCTHD.DataSource = Nothing
            Dadapter.Fill(db)
            If db.Rows.Count > 0 Then
                dgvCTHD.DataSource = db.DefaultView
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

    Private Sub ckxMaKT_CheckedChanged(sender As Object, e As EventArgs) Handles ckxMaKT.CheckedChanged
        If ckxMaKT.Checked = True Then
            cboMaKT.DataSource = Nothing
        Else
            cboMaKT.DataSource = LoadCTHD.Tables(0)
            cboMaKT.DisplayMember = "Mã kiểm tra"
            cboMaKT.ValueMember = "Mã kiểm tra"
        End If
    End Sub

End Class