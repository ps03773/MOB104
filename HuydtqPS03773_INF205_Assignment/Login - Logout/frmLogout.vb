Public Class frmLogout

    Private _LogoutResult As DialogResult

    Private Sub btnDongy_Click(sender As Object, e As EventArgs) Handles btnDongy.Click
        frmMain.lblUser.Text = ""
        frmLogin.ShowDialog()

        _LogoutResult = frmLogin.DialogResult

        If _LogoutResult = Windows.Forms.DialogResult.Cancel Then
            frmMain.Close()
            Me.Close()
        ElseIf _LogoutResult = Windows.Forms.DialogResult.OK Then
            frmMain.lblUser.Text = ""
            frmMain.lblUser.Text = User
            frmMain.MenuItemCNSP.Visible = True
            frmMain.MenuItemCNKH.Visible = True
            Me.Close()
        ElseIf _LogoutResult = Windows.Forms.DialogResult.Yes Then
            frmMain.lblUser.Text = ""
            frmMain.lblUser.Text = User
            frmMain.MenuItemCNSP.Visible = False
            frmMain.MenuItemCNKH.Visible = False
            Me.Close()
        Else
            frmMain.Close()
            Me.Close()
        End If
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        Me.Close()
    End Sub

End Class