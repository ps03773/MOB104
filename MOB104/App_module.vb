Imports System.Data.SqlClient
Imports System.Data

Module App_module
    Public User As String ' Hiện Username trên form Main
    Public Username As String
    Public Password As String
    '(Kết nối đến Database
    Public _ConnectionString As String = "Data Source=KUROKAMI;Initial Catalog=QLBH_LAPTOP;Integrated Security=True"
    Public Connect As SqlConnection = New SqlConnection(_ConnectionString)
    ')
    Public Dadapter As SqlDataAdapter ' Gửi các truy vấn đến Database
    Public Edata As New DataTable

    ' Đọc dữ liệu từ bảng SAN_PHAM
    Public Function LoadSP() As DataSet
        Dadapter = New SqlDataAdapter("Select SO_SERI as 'Số Seri' , MA_SP as 'Mã sản phẩm', TEN_SP as 'Tên sản phẩm', NHAN_HIEU as 'Nhãn hiệu',  CHIP as 'Chip xử lí', RAM as 'Bộ nhớ RAM', HDD_SDD as 'HDD/SSD', GIA as 'Giá', BAO_HANH_THANG as 'Bảo hành (Tháng)', TRANG_THAI as 'Trạng thái', MA_DL as 'Mã đại lí' From SAN_PHAM", Connect)
        Dim db As New DataSet
        Connect.Open()
        Dadapter.Fill(db)
        Connect.Close()
        Return db
    End Function

    ' Đọc dữ liệu từ bảng SAN_PHAM
    Public Function LoadKH() As DataSet
        Dadapter = New SqlDataAdapter("Select Ma_SP as 'Mã SP' , Ten_SP as 'Tên sản phẩm', Loai_san_pham as 'Loại sản phẩm', SAN_PHAM.Ma_loai as 'Mã loại', Convert(Date,Ngay_nhap,105) as 'Ngày nhập', Don_gia as 'Đơn giá', SL_ton_kho as 'SL tồn kho' From SAN_PHAM join LOAI_SAN_PHAM on SAN_PHAM.Ma_loai = LOAI_SAN_PHAM.Ma_loai", Connect)
        Dim db As New DataSet
        Connect.Open()
        Dadapter.Fill(db)
        Connect.Close()
        Return db
    End Function

    ' Đọc dữ liệu từ bảng HOA_DON
    Public Function LoadHD() As DataSet
        Dadapter = New SqlDataAdapter("Select Ma_HD as 'Mã HĐ', HOA_DON.Ma_KH as 'Mã KH', Ho_ten_KH as 'Tên khách hàng', Dia_chi as 'Địa chỉ' From KHACH_HANG join HOA_DON on KHACH_HANG.Ma_KH = HOA_DON.Ma_KH", Connect)
        Dim db As New DataSet
        Connect.Open()
        Dadapter.Fill(db)
        Connect.Close()
        Return db
    End Function

    ' Đọc dữ liệu từ bảng CHI_TIET_HD
    Public Function LoadCTHD() As DataSet
        Dadapter = New SqlDataAdapter("Select Ma_kiem_tra as 'Mã kiểm tra', CHI_TIET_HD.Ma_HD as 'Mã HĐ', CHI_TIET_HD.Ma_SP as 'Mã SP', Ten_SP as 'Tên sản phẩm', So_luong as 'Số lượng' From CHI_TIET_HD join HOA_DON on CHI_TIET_HD.Ma_HD = HOA_DON.Ma_HD join SAN_PHAM on CHI_TIET_HD.Ma_SP = SAN_PHAM.Ma_SP", Connect)
        Dim db As New DataSet
        Connect.Open()
        Dadapter.Fill(db)
        Connect.Close()
        Return db
    End Function

    'Lưu file Excel
    Public Sub Export_to_Excel(ByVal _DataSet As DataTable, ByVal _List_Col As String, ByVal Path As String)
        '- _Dataset: lưu dữu liệu cần Export
        '- _List_Col: Danh sách tên cột hiển thị. Tên cột cách nhau dấu ','
        '- Path: Đường dẫn lưu file excel

        Dim col, row As Integer
        Dim arrListcol() As String
        arrListcol = _List_Col.Split(",")

        If _DataSet.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim Excel As Object = CreateObject("Excel.Application")
        If Excel Is Nothing Then
            MessageBox.Show("Để xuất ra Excel, máy bạn phải cài đặt bộ phần mềm Microsoft Office.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Export to Excel process
        Try
            With Excel
                .SheetsInNewWorkbook = 1
                .Workbooks.Add()
                .Worksheets(1).Select()

                Dim i As Integer = 2
                .cells(1, 4).value = "Ngày:" + Date.Now
                .cells(1, 4).EntireRow.Font.Name = "Times New Roman"
                .cells(1, 4).EntireRow.Font.Size = 12
                .cells(2, i).value = "STT"
                .cells(2, i).EntireRow.Font.Bold = True
                For col = 0 To arrListcol.Length - 1
                    i += 1
                    .cells(2, i).value = arrListcol(col).ToUpper()
                    .cells(2, i).EntireRow.Font.Name = "Times New Roman"
                    .cells(2, i).EntireRow.Font.Size = 12
                    .cells(2, i).EntireRow.Font.Bold = True
                Next
                i = 3
                Dim k As Integer = 3

                For col = 0 To _DataSet.Columns.Count - 1
                    i = 3

                    For row = 0 To _DataSet.Rows.Count - 1
                        .Cells(i, 2).Value = i - 2
                        .Cells(i, k).Value = _DataSet.Rows(row).ItemArray(col)
                        .cells(i, k).EntireRow.Font.Name = "Times New Roman"
                        .cells(i, k).EntireRow.Font.Size = 12
                        i += 1
                    Next
                    k += 1
                Next
                .Columns.AutoFit()
                .ActiveCell.Worksheet.SaveAs(Path)
            End With
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            Excel = Nothing
            MessageBox.Show("Xuất dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim proc As System.Diagnostics.Process
            For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
                proc.Kill()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

End Module
