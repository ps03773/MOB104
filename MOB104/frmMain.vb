Public Class frmMain
    Private _LoginResult As DialogResult

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        If User = "admin" Then
            lblUser.Text = User
            MenuItemCNSP.Visible = True
            MenuItemCNKH.Visible = True
            MenuItemLogin.Visible = True
        ElseIf _LoginResult = Windows.Forms.DialogResult.OK Then
            lblUser.Text = User
            MenuItemCNSP.Visible = True
            MenuItemCNKH.Visible = True
            MenuItemLogin.Visible = False
        ElseIf _LoginResult = Windows.Forms.DialogResult.Yes Then
            lblUser.Text = User
            MenuItemCNSP.Visible = False
            MenuItemCNKH.Visible = False
            MenuItemLogin.Visible = False
        Else
            Me.Close()
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim frm As New frmLogin
        frm.ShowDialog()
        _LoginResult = frm.DialogResult
    End Sub

    Private Sub ĐăngXuấtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ĐăngXuấtToolStripMenuItem.Click
        frmLogout.ShowDialog()
    End Sub

    Private Sub DanhMụcSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DanhMụcSảnPhẩmToolStripMenuItem.Click
        frmProductList.ShowDialog()
    End Sub

    Private Sub CậpNhậtSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItemCNSP.Click
        frmEdit_ProductList.ShowDialog()
    End Sub

    Private Sub MenuItemLogin_Click(sender As Object, e As EventArgs) Handles MenuItemLogin.Click
        frmLoginTable.ShowDialog()
    End Sub
End Class