using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace QuanLyBanHang
{
    public partial class FrmLapHoaDon : Form
    {
        string userName;
        public SqlConnection conn = new SqlConnection();
        Function function = new Function();
        public FrmLapHoaDon(string userN)
        {
            userName = userN;
            InitializeComponent();
        }

        private void NhapSo(object sender, KeyPressEventArgs e)
        {
            //Chi cho phep nhap so
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmLapHoaDon_Load(object sender, EventArgs e)
        {
            function.Connection(conn);

            gbAddPro.Visible = false;
            gbAddPro.Enabled = false;

            gbCreBill.Visible = false;
            gbCreBill.Enabled = false;

            gbChange.Enabled = false;
            gbChange.Visible = false;

            gbChange_1.Enabled = false;
            gbChange_1.Visible = false;

            labelChange.Visible = false;
            DTP_Bill_CR.Visible = false;
            DTP_Bill_CR.Enabled = false;

            txtIDEmp.ReadOnly = true;
            txtNameEmp.ReadOnly = true;

            function.ShowData(dgwBill, "select * from HOA_DON order by SoHD desc", conn);

            string sql_getNV = "select HoTen from NHAN_VIEN where MaNV = '" + userName + "'"; //userName lay tu form dang nhap
            SqlCommand comd = new SqlCommand(sql_getNV, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                txtNameEmp.Text = reader.GetValue(0).ToString();
                txtIDEmp.Text = userName;
            }

            reader.Close();

        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            //Tat giao dien mac dinh
            gbIndex.Visible = false;
            gbIndex.Enabled = false;
            //Mo giao dien tao hoa don
            gbCreBill.Visible = true;
            gbCreBill.Enabled = true;

            //Che do "chi doc"
            txtSoHD.ReadOnly = true;
            txtIDEmp.ReadOnly = true;
            txtNameEmp.ReadOnly = true;
            txtNameCus.ReadOnly = true;
            txtIDCus.ReadOnly = true;
            DTPHoaDon.ShowCheckBox = false;

            

            //So hoa don tang tu dong
            string sql_getBillNum = "select max(substring(SoHD,3,8)) from HOA_DON";
            SqlCommand comd = new SqlCommand(sql_getBillNum, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                int max = (int)(Convert.ToInt64(reader.GetValue(0).ToString()) + 1);

                if (max < 10)
                {
                    txtSoHD.Text = "HD00000" + max;
                }
                if (max > 9 && max < 100)
                {
                    txtSoHD.Text = "HD0000" + max;
                }
                if (max > 99 && max < 1000)
                {
                    txtSoHD.Text = "HD000" + max;
                }
                if (max > 999 && max < 10000)
                {
                    txtSoHD.Text = "HD00" + max;
                }
                if (max > 9999 && max < 100000)
                {
                    txtSoHD.Text = "HD0" + max;
                }
                if (max > 99999 && max < 1000000)
                {
                    txtSoHD.Text = "HD" + max;
                }
            }

            reader.Close();

            string sql_addBill = "insert into HOA_DON(SoHD, MaKH, MaNV, NgayLap, ThanhTien) values('" + txtSoHD.Text + "', 'KH000', '" + txtIDEmp.Text + "', '" + DTPHoaDon.Value.ToString() + "', 0)";
            function.Update(sql_addBill, conn);

            function.ShowData(dgwCus, "select * from KHACH_HANG", conn);
        }

        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            //Tim khach hang bang so dien thoai
            string keyword = txtPhoneNum.Text;
            string sql_getCus = "select * from KHACH_HANG where SDT like '%" + keyword + "%';";
            function.ShowData(dgwCus, sql_getCus, conn);

            //Neu khong tim thay khach hang. Kiem tra lai so dien thoai khach hang
            //Hoac them moi neu chua co khach hang duoc luu trong co so du lieu
        }

        private void dgwCus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDCus.Text = dgwCus.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNameCus.Text = dgwCus.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhoneNum.Text = dgwCus.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            //Tat giao dien tao hoa don
            gbCreBill.Visible = false;
            gbCreBill.Enabled = false;
            //Mo giao dien them mat hang
            gbAddPro.Enabled = true;
            gbAddPro.Visible = true;

            txtTotal.ReadOnly = true;
            txtPrice.ReadOnly = true;
            txtIDPro.ReadOnly = true;

            function.ShowData(dgwProduct, "select * from MAT_HANG", conn);
        }

      /*  private float get_Discount(string MaKH)
        {
            float discount = 0;

            string sql_getDC = "select GiamGia from LOAI_KHACH_HANG a, KHACH_HANG b where b.MaKH = '" + txtIDCus.Text + "' and a.MaLoaiKH = b.MaLoaiKH";
            SqlCommand comd = new SqlCommand(sql_getDC, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                discount = float.Parse(reader.GetValue(0).ToString());
            }

            reader.Close();

            return discount;
        }*/

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Tim mat hang
            string keyword = txtSearch.Text;
            string sql_getProduct = "select * from MAT_HANG where tenhang like '%" + keyword + "%';";
            function.ShowData(dgwProduct, sql_getProduct, conn);
        }

        private void dgwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDPro.Text = dgwProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProName.Text = dgwProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPrice.Text = dgwProduct.Rows[e.RowIndex].Cells[5].Value.ToString();

            txtNum.Text = string.Empty; //lam moi o so luong moi khi chon mat hang moi
        }

        private void btnAddPro_Click(object sender, EventArgs e)
        {
            //Khoi tao gia tri cho thanh tien
            if (String.IsNullOrEmpty(txtTotal.Text))
            {
                txtTotal.Text = "0";
            }

            //Kiem tra da nhap so luong hang hay chua
            if (String.IsNullOrEmpty(txtNum.Text) || String.Compare(txtNum.Text, "0") == 0)
            {
                MessageBox.Show("Nhap so luong mat hang!");
            }

            else
            {

                int soluong = Convert.ToInt16(txtNum.Text);
                float gia = float.Parse(txtPrice.Text);

                txtTotal.Text = Convert.ToString(float.Parse(txtTotal.Text) + (float)soluong * gia);
 
                //Them mat hang da chon vao chi tiet hoa don
                string sql_addCTHD = "insert into CHI_TIET_HOA_DON values('" + txtSoHD.Text + "', '" + txtIDPro.Text + "', " + soluong + ", '', '')";
                function.Update(sql_addCTHD, conn);

                function.ShowData(dgwCTHD, "select SoHD, a.MaHang, TenHang, Gia, DVT, SoLuong from CHI_TIET_HOA_DON a, MAT_HANG b where a.MaHang = b.MaHang and SoHD = '" + txtSoHD.Text + "'", conn);
            }
        }

        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            int soluong = Convert.ToInt16(txtNum.Text);
            float gia = float.Parse(txtPrice.Text);
            // float thanhtien = 0;

            txtTotal.Text = Convert.ToString(float.Parse(txtTotal.Text) - ((float)soluong * gia));

            string sql_delete = "delete from CHI_TIET_HOA_DON where SoHD = '" + txtSoHD.Text + "' and MaHang = '" + txtIDPro.Text + "'";
            function.Update(sql_delete, conn);

            function.ShowData(dgwCTHD, "select SoHD, a.MaHang, TenHang, Gia, DVT, SoLuong from CHI_TIET_HOA_DON a, MAT_HANG b where a.MaHang = b.MaHang and SoHD = '" + txtSoHD.Text + "'", conn);

        }

        private void dgwCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDPro.Text = dgwCTHD.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProName.Text = dgwCTHD.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNum.Text = dgwCTHD.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPrice.Text = dgwCTHD.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnComPro_Click(object sender, EventArgs e)
        {
            //Thoat khoi giao dien them mat hang
            gbAddPro.Enabled = false;
            gbAddPro.Visible = false;
            //Mo giao dien tao hoa don
            gbCreBill.Enabled = true;
            gbCreBill.Visible = true;

            //Hien thi chi tiet hoa don vua tao de nguoi dung co the kiem tra lai mat hang va so luong
            function.ShowData(dgwCTHD_3, "select SoHD, a.MaHang, TenHang, SoLuong from CHI_TIET_HOA_DON a, MAT_HANG b where a.MaHang = b.MaHang and SoHD = '" + txtSoHD.Text + "'", conn);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiem tra hoa don da co them chi tiet hoa don hay chua
            if (!String.IsNullOrEmpty(txtTotal.Text) && String.Compare(txtTotal.Text, "0") != 0) {

                //Kiem tra hoa don da co them khach hang hay chua
                if (!String.IsNullOrEmpty(txtIDCus.Text))
                {
                    //Kiem tra co dung so dien thoai cua khach hang da chon hay khong
                    string sql_check = "select * from KHACH_HANG where SDT = '" + txtPhoneNum.Text + "'";
                    SqlCommand comd = new SqlCommand(sql_check, conn);
                    SqlDataReader reader = comd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();

                        string sql_update = "update HOA_DON set MaKH = '" + txtIDCus.Text + "', ThanhTien = " + float.Parse(txtTotal.Text) + " where SoHD = '" + txtSoHD.Text + "'";
                        function.Update(sql_update, conn); 

                        //Thoat khoi giao dien tao hoa don
                        gbCreBill.Enabled = false;
                        gbCreBill.Visible = false;
                        //Mo giao dien mac dinh
                        gbIndex.Enabled = true;
                        gbIndex.Visible = true;

                        //Lam moi data grid view hien thi danh sach hoa don
                        function.ShowData(dgwBill, "select * from HOA_DON order by SoHD desc", conn);
                    }

                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng có số điện thoại" + txtPhoneNum.Text + ". Vui lòng kiểm tra lại số điện thoại!");
                        reader.Close();
                    }
                }

                else MessageBox.Show("Vui lòng thêm thông tin khách hàng!");
            }

            else MessageBox.Show("Vui lòng nhập chi tiết hóa đơn!");
        }

        private void btnCancelCre_Click(object sender, EventArgs e)
        {
            string delete_sql = "delete from CHI_TIET_HOA_DON where SoHD = '" + txtSoHD.Text + "'";
            function.Update(delete_sql, conn);

            delete_sql = "delete from HOA_DON where SoHD = '" + txtSoHD.Text + "'";
            function.Update(delete_sql, conn);

            MessageBox.Show("Đã hủy!");

            gbCreBill.Visible = false;
            gbCreBill.Enabled = false;
            gbIndex.Visible = true;
            gbIndex.Enabled = true;
        }

        private void dgwBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtSoHD.Text = dgwBill.Rows[e.RowIndex].Cells[0].Value.ToString();
            function.ShowData(dgwCTHD_2, "select SoHD, a.MaHang, TenHang, SoLuong from CHI_TIET_HOA_DON a, MAT_HANG b where a.MaHang = b.MaHang and SoHD = '" + dgwBill.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", conn);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //Dong giao dien mac dinh
            gbIndex.Enabled = false;
            gbIndex.Visible = false;
            //Mo giao dien doi tra
            gbChange_1.Enabled = true;
            gbChange_1.Visible = true;

            //Lam moi so hoa don
            txtSoHD.Text = string.Empty;
            txtRefund.ReadOnly = true;
            
            //Do chi duoc doi tra san pham trong vong 3 ngay ke tu ngay mua
            //Nen chi hien thi nhung hoa don duoc lap trong khong thoi gian do
            function.ShowData(dgwBill_2, "select * from HOA_DON where 3 >= DATEDIFF(day, NgayLap, GETDATE()) order by NgayLap desc", conn);
        }


        //Ham kiem tra han doi tra san pham
        private int check_date(DateTime dateTime)
        {
            //Han doi tra = ngay hien tai - 3 ngay truoc do
            TimeSpan maxi = DateTime.Now.Date - DateTime.Now.AddDays(-3).Date;

            //Khoang thoi gian tu ngay lap hoa don cho den ngay hien tai
            TimeSpan span = DateTime.Now.Date - dateTime.Date;

            //Kiem tra qua han doi tra
            if (span.CompareTo(maxi) > 0)
                return 0;
            else return 1;
        }

        private void DTPHoaDon_ValueChanged(object sender, EventArgs e)
        {
            //Chi cho phep chon ngay hien tai hoac nhung ngay truoc do
            if (DateTime.Compare(DTPHoaDon.Value, DateTime.Now) > 0)
            {
                MessageBox.Show("Vui lòng chỉ chọn ngày hiện tại hoặc trước ngày hiện tại!");
            }

            else
            {
                if (check_date(DTPHoaDon.Value) == 0)
                {
                    MessageBox.Show("Hóa đơn đã quá hạn đổi trả!");
                }

                else
                {
                    //Hien thi nhung hoa don duoc lap trong ngay da chon (chi nhung hoa don con han doi tra)
                    function.ShowData(dgwBill_2, "select * from HOA_DON where NgayLap between '" + DTPHoaDon.Value.ToString("yyyy/MM/dd") + " 00:00:00' and '" + DTPHoaDon.Value.ToString("yyyy/MM/dd") + " 23:59:59'", conn);
                }
            }
        }

        private void txtSoHD_KeyDown(object sender, KeyEventArgs e)
        {
            txtSoHD.ReadOnly = false;

            //Tim hoa don bang so hoa don
            if (e.KeyCode == Keys.Enter)
            {
                string sql_getBill = "select * from HOA_DON where SoHD = '" + txtSoHD.Text + "'";
                SqlCommand comd = new SqlCommand(sql_getBill, conn);
                SqlDataReader reader = comd.ExecuteReader();

                if (reader.Read())
                {
                    DateTime dateTime = (DateTime)reader.GetValue(3);
                    reader.Close();

                    if (check_date(dateTime) == 0)
                    {
                        MessageBox.Show("Hóa đơn đã quá hạn đổi trả!");
                        txtSoHD.Text = "";
                    }
                    else function.ShowData(dgwBill_2, sql_getBill, conn);
                }

                else
                {
                    MessageBox.Show("Hóa đơn số " + txtSoHD.Text + " không tồn tại. Vui lòng kiểm tra lại số hóa đơn!");
                    txtSoHD.Text = "";
                    reader.Close();
                }
            }

        }
        private void dgwBill_2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtSoHD.Text = dgwBill_2.Rows[e.RowIndex].Cells[0].Value.ToString();

            string sql_getCus = "select a.MaKH, a.HoTen, a.SDT from KHACH_HANG a, HOA_DON b where b.SoHD = '" + txtSoHD.Text + "' and a.MaKH = b.MaKH";
            SqlCommand comd = new SqlCommand(sql_getCus, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                txtIDCus.Text = reader.GetValue(0).ToString();
                txtNameCus.Text = reader.GetValue(1).ToString();
                txtPhoneNum.Text = reader.GetValue(2).ToString();
            }

            reader.Close();

            function.ShowData(dgwCTHD_5, "select a.SoHD, a.MaHang, TenHang, SoLuong, Doi_Tra, LyDo from CHI_TIET_HOA_DON a, MAT_HANG b where SoHD = '" + txtSoHD.Text + "' and a.MaHang = b.MaHang", conn);

        }

        private void btnChg_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSoHD.Text))
            {
                gbChange_1.Enabled = false;
                gbChange_1.Visible = false;

                gbChange.Enabled = true;
                gbChange.Visible = true;

                btnSaveC.Enabled = true;
                btnSaveC.Visible = true;

                btnSaveR.Enabled = false;
                btnSaveR.Visible = false;

                txtSoHD.ReadOnly = true;

                labelCre.Visible = false;
                DTPHoaDon.Visible = false;
                DTPHoaDon.Enabled = false;

                labelChange.Visible = true;
                DTP_Bill_CR.Visible = true;
                DTP_Bill_CR.Enabled = true;

                txtRefund.Text = "0";

                function.ShowData(dgwCTHD_4, "select SoHD, a.MaHang, TenHang, SoLuong, Doi_Tra, LyDo from CHI_TIET_HOA_DON a, MAT_HANG b where SoHD = '" + txtSoHD.Text + "' and a.MaHang = b.MaHang", conn);
            }

            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn chứa mặt hàng cần đổi!");
            }

        }

        private void dgwCTHD_4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql_getKP = "select MaLoaiHang from CHI_TIET_HOA_DON a, MAT_HANG b where a.MaHang = '" + dgwCTHD_4.Rows[e.RowIndex].Cells[1].Value.ToString() + "' and a.MaHang = b.MaHang";
            SqlCommand comd = new SqlCommand(sql_getKP, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if(reader.Read())
            {
                if(reader.GetValue(0).ToString().CompareTo("ML004") == 0)
                {
                    MessageBox.Show("Không thể đổi/trả mặt hàng loại THỰC PHẨM TƯƠI SỐNG!");

                    reader.Close();
                }

                else
                {
                    txtProID.Text = dgwCTHD_4.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtProName_1.Text = dgwCTHD_4.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtProNum.Text = dgwCTHD_4.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtReason.Text = dgwCTHD_4.Rows[e.RowIndex].Cells[5].Value.ToString();

                    btnComp.Enabled = false;

                    reader.Close();

                    string sql_getPrice = "select Gia from MAT_HANG a, CHI_TIET_HOA_DON b where SoHD = '" + txtSoHD.Text + "' and a.MaHang = '" + txtProID.Text + "'";
                    comd = new SqlCommand(sql_getPrice, conn);
                    reader = comd.ExecuteReader();

                    if(reader.Read())
                    {
                        txtProPrice.Text = reader.GetValue(0).ToString();
                    }
                }

             reader.Close();

            }    
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
           if(!string.IsNullOrEmpty(txtSoHD.Text))
           {
                gbChange_1.Enabled = false;
                gbChange_1.Visible = false;

                gbChange.Enabled = true;
                gbChange.Visible = true;

                btnSaveR.Enabled = true;
                btnSaveR.Visible = true;

                btnSaveC.Enabled = false;
                btnSaveC.Visible = false;

                txtSoHD.ReadOnly = true;

                labelCre.Visible = false;
                DTPHoaDon.Visible = false;
                DTPHoaDon.Enabled = false;

                labelChange.Visible = true;
                DTP_Bill_CR.Visible = true;
                DTP_Bill_CR.Enabled = true;

                txtRefund.Text = "0";

                function.ShowData(dgwCTHD_4, "select SoHD, a.MaHang, TenHang, SoLuong, Doi_Tra, LyDo from CHI_TIET_HOA_DON a, MAT_HANG b where SoHD = '" + txtSoHD.Text + "' and a.MaHang = b.MaHang", conn);
            }

            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn chứa mặt hàng cần trả!");
            }
        }

        private void btnSaveC_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtReason.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả lý do đổi hàng!");
            }

            else
            {
                string sql_update = "update CHI_TIET_HOA_DON set LyDo = N'" + txtReason.Text + "', Doi_Tra = N'Đổi' where SoHD = '" + txtSoHD.Text + "' and MaHang = '" + txtProID.Text + "'";
                function.Update(sql_update, conn);
                function.ShowData(dgwCTHD_4, "select SoHD, a.MaHang, TenHang, SoLuong, Doi_Tra, LyDo from CHI_TIET_HOA_DON a, MAT_HANG b where a.MaHang = b.MaHang and SoHD = '" + txtSoHD.Text + "'", conn);

                btnComp.Enabled = true;
            }
        }

        private void btnSaveR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReason.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả lý do trả hàng!");
            }

            else
            {
                string sql_update = "update CHI_TIET_HOA_DON set LyDo = N'" + txtReason.Text + "', Doi_Tra = N'Trả' where SoHD = '" + txtSoHD.Text + "' and MaHang = '" + txtProID.Text + "'";
                function.Update(sql_update, conn);
                function.ShowData(dgwCTHD_4, "select SoHD, a.MaHang, TenHang, SoLuong, Doi_Tra, LyDo from CHI_TIET_HOA_DON a, MAT_HANG b where a.MaHang = b.MaHang and SoHD = '" + txtSoHD.Text + "'", conn);

                //Tinh thanh tien = thanh tien + (so luong * don gia cua san pham)
                int soluong = Convert.ToInt16(txtProNum.Text);
                float gia = float.Parse(txtProPrice.Text);

                txtRefund.Text = Convert.ToString(float.Parse(txtRefund.Text) + (gia * soluong));    
                
                btnComp.Enabled = true;
            }         
        }

        private void btnRe_Click(object sender, EventArgs e)
        {
            btnComp.Enabled = true;

            txtProName_1.Text = string.Empty;
            txtProID.Text = string.Empty;
            txtProNum.Text = string.Empty;
            txtProPrice.Text = string.Empty;
            txtReason.Text = string.Empty;
        }

        private void btnComp_Click(object sender, EventArgs e)
        {
            string get_Update = "update HOA_DON set NgayDoiTra = '" + DTP_Bill_CR.Value.ToString() + "', MaNV_DoiTra = '" + txtIDEmp.Text + "' where SoHD = '" + txtSoHD.Text + "'";
            function.Update(get_Update, conn);

            txtSoHD.ReadOnly = false;
            function.ShowData(dgwBill_2, "select * from HOA_DON where 3 >= DATEDIFF(day, NgayLap, GETDATE()) order by NgayLap desc", conn);
            function.ShowData(dgwCTHD_4, "select SoHD, a.MaHang, TenHang, SoLuong, Doi_Tra, LyDo from CHI_TIET_HOA_DON a, MAT_HANG b where a.MaHang = b.MaHang and SoHD = '" + txtSoHD.Text + "'", conn);

            gbChange_1.Enabled = true;
            gbChange_1.Visible = true;

            gbChange.Enabled = false;
            gbChange.Visible = false;

            labelCre.Visible = true;
            DTPHoaDon.Visible = true;
            DTPHoaDon.Enabled = true;

            labelChange.Visible = false;
            DTP_Bill_CR.Visible = false;
            DTP_Bill_CR.Enabled = false;
        }

        private void btnExitCR_Click(object sender, EventArgs e)
        {
            gbIndex.Enabled = true;
            gbIndex.Visible = true;

            gbChange_1.Enabled = false;
            gbChange_1.Visible = false;

            function.ShowData(dgwBill, "select * from HOA_DON order by SoHD desc", conn);
        }

        private void btnCancelCR_Click(object sender, EventArgs e)
        {
            txtSoHD.ReadOnly = false;
            function.ShowData(dgwBill_2, "select * from HOA_DON where 3 >= DATEDIFF(day, NgayLap, GETDATE()) order by NgayLap desc", conn);

            gbChange_1.Enabled = true;
            gbChange_1.Visible = true;

            gbChange.Enabled = true;
            gbChange.Visible = true;

            labelCre.Visible = true;
            DTPHoaDon.Visible = true;
            DTPHoaDon.Enabled = true;

            labelChange.Visible = false;
            DTP_Bill_CR.Visible = false;
            DTP_Bill_CR.Enabled = false;
        }
    }
}
