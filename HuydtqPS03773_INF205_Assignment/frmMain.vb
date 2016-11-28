Public Class frmMain
    Private _LoginResult As DialogResult

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _LoginResult = Windows.Forms.DialogResult.OK Then
            lblUser.Text = User
            MenuItemCNSP.Visible = True
            MenuItemCNKH.Visible = True
        ElseIf _LoginResult = Windows.Forms.DialogResult.Yes Then
            lblUser.Text = User
            MenuItemCNSP.Visible = False
            MenuItemCNKH.Visible = False
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

    Private Sub DanhSáchKháchHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DanhSáchKháchHàngToolStripMenuItem.Click
        frmCustomerList.ShowDialog()
    End Sub

    Private Sub ChiTiếtHóaĐơnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChiTiếtHóaĐơnToolStripMenuItem.Click
        frmInvoices.ShowDialog()
    End Sub

    Private Sub ChiTiếtHóaĐơnToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChiTiếtHóaĐơnToolStripMenuItem1.Click
        frmInvoiceDetails.ShowDialog()
    End Sub

    Private Sub CậpNhậtDanhSáchKHToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItemCNKH.Click
        frmEdit_CustomerList.ShowDialog()
    End Sub

    Private Sub CậpNhậtSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItemCNSP.Click
        frmEdit_ProductList.ShowDialog()
    End Sub

End Class