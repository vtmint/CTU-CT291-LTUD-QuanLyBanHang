using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FrmThongKe : Form
    {

        SqlConnection conn = new SqlConnection();
        Function function = new Function();
        int flag = 0;

        public FrmThongKe()
        {
            InitializeComponent();
        }

        public string Get_Total(string sql)
        {
            string total = string.Empty;

            SqlCommand comd = new SqlCommand(sql, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                total = reader.GetValue(0).ToString();
            }

            reader.Close();

            return total;
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            function.Connection(conn);

            Default_Show();

           // MessageBox.Show(dtpStart.Value.ToString("yyyy-MM-dd");
        }

        private void Default_Show()
        {
            cbProduct.Text = "Chọn loại thống kê";
            cbCustomer.Text = "Chọn loại thống kê";
            cbRevenue.Text = "Chọn loại thống kê";
            cbStatics.Text = "Chọn loại thống kê";
        }

        private void btnSelectPro_Click(object sender, EventArgs e)
        {
            flag = 1;

            cbCustomer.Enabled = false;
            cbRevenue.Enabled = false;
            
            btnSelectCus.Enabled = false;
            btnSelectRev.Enabled = false;
        }

        private void btnSelectCus_Click(object sender, EventArgs e)
        {
            flag = 2;

            cbProduct.Enabled = false;
            cbRevenue.Enabled = false;

            btnSelectPro.Enabled = false;
            btnSelectRev.Enabled = false;
        }

        private void btnSelectRev_Click(object sender, EventArgs e)
        {
            flag = 3;

            cbCustomer.Enabled = false;
            cbProduct.Enabled = false;

            btnSelectCus.Enabled = false;
            btnSelectPro.Enabled = false;
        }

        private void btnReSelect_Click(object sender, EventArgs e)
        {
            flag = 0;

            cbCustomer.Enabled = true;
            cbRevenue.Enabled = true;
            cbProduct.Enabled = true;

            btnSelectCus.Enabled = true;
            btnSelectRev.Enabled = true;
            btnSelectPro.Enabled = true;
        }

        private void Product()
        {
            string sql_tong = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, a.DVT, a.Gia, b.SO_LUONG_DA_BAN from MAT_HANG a, (select b.MAHANG, sum(b.SOLUONG) SO_LUONG_DA_BAN from MAT_HANG a, CHI_TIET_HOA_DON b where a.MAHANG = b.MAHANG group by b.MAHANG) b where a.MAHANG = b.MAHANG";
            function.ShowData(dataGridView1, sql_tong, conn);

            txtTotalSta.Text = Get_Total("select sum(a.SO_LUONG_DA_BAN) from (" + sql_tong + ") a");          
        }

        private void Product(DateTime start, DateTime end)
        {
            string sql_tong = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, a.DVT, a.Gia, b.SO_LUONG_DA_BAN from MAT_HANG a, (select b.MAHANG, sum(b.SOLUONG) SO_LUONG_DA_BAN from CHI_TIET_HOA_DON b, HOA_DON c where c.SOHD = b.SOHD and c.NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "' group by b.MAHANG) b where a.MAHANG = b.MAHANG";
            function.ShowData(dataGridView1, sql_tong, conn);

            txtTotalSta.Text = Get_Total("select sum(a.SO_LUONG_DA_BAN) from (" + sql_tong + ") a");
        }

        private void Best_Product()
        {
            string sql_getBP = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, a.DVT, a.Gia, b.SO_LUONG_DA_BAN from MAT_HANG a, (select MAHANG, sum(SOLUONG) SO_LUONG_DA_BAN from CHI_TIET_HOA_DON group by MAHANG) b where a.MAHANG = b.MAHANG and b.SO_LUONG_DA_BAN = (select max(sl.SO_LUONG_DA_BAN) from (select MAHANG, sum(SOLUONG) SO_LUONG_DA_BAN from CHI_TIET_HOA_DON group by MAHANG) sl)";
            function.ShowData(dataGridView1, sql_getBP, conn);
        }

        private void Best_Product(DateTime start, DateTime end)
        {
            string sql_getBP = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, a.DVT, a.Gia, b.SO_LUONG_DA_BAN from MAT_HANG a, (select b.MAHANG, a.TENHANG, sum(b.SOLUONG) SO_LUONG_DA_BAN from MAT_HANG a, CHI_TIET_HOA_DON b, HOA_DON c where a.MAHANG = b.MAHANG and c.SOHD = b.SOHD and c.NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "' group by b.MAHANG, a.TENHANG) b where a.MAHANG = b.MAHANG and b.SO_LUONG_DA_BAN = (select max(sl.SO_LUONG_DA_BAN) from (select b.MAHANG, a.TENHANG, sum(b.SOLUONG) SO_LUONG_DA_BAN from CHI_TIET_HOA_DON b, HOA_DON c where c.SOHD = b.SOHD and c.NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "' group by b.MAHANG) sl)";
            function.ShowData(dataGridView1, sql_getBP, conn);
        }

        private void Slump_Product()
        {
            string sql_getSL = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, a.DVT, a.Gia, b.SO_LUONG_DA_BAN\r\nfrom MAT_HANG a,\r\n\t(select MAHANG, sum(SOLUONG) SO_LUONG_DA_BAN\r\n\tfrom CHI_TIET_HOA_DON\r\n\tgroup by MAHANG) b \r\nwhere a.MAHANG = b.MAHANG\r\n\tand b.SO_LUONG_DA_BAN = (select min(sl.SO_LUONG_DA_BAN) \r\n\t\t\t\t\t\t\tfrom (select MAHANG, sum(SOLUONG) SO_LUONG_DA_BAN\r\n\t\t\t\t\t\t\t\tfrom CHI_TIET_HOA_DON\r\n\t\t\t\t\t\t\t\tgroup by MAHANG) sl);";
            function.ShowData(dataGridView1, sql_getSL, conn);
        }

        private void Slump_Product(DateTime start, DateTime end)
        {
            string sql_getSL = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, a.DVT, a.Gia, b.SO_LUONG_DA_BAN from MAT_HANG a, (select b.MAHANG, a.TENHANG, sum(b.SOLUONG) SO_LUONG_DA_BAN from MAT_HANG a, CHI_TIET_HOA_DON b, HOA_DON c where a.MAHANG = b.MAHANG and c.SOHD = b.SOHD and c.NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "' group by b.MAHANG, a.TENHANG) b where a.MAHANG = b.MAHANG and b.SO_LUONG_DA_BAN = (select min(sl.SO_LUONG_DA_BAN) from (select b.MAHANG, a.TENHANG, sum(b.SOLUONG) SO_LUONG_DA_BAN from CHI_TIET_HOA_DON b, HOA_DON c where c.SOHD = b.SOHD and c.NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "' group by b.MAHANG) sl)";
            function.ShowData(dataGridView1 , sql_getSL, conn);
        }

        private void NSell_Product()
        {
            string sql_getNSP = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, a.DVT, a.Gia from MAT_HANG a, (select MAHANG from MAT_HANG except select MAHANG from CHI_TIET_HOA_DON) b where a.MAHANG = b.MAHANG";
            function.ShowData(dataGridView1, sql_getNSP, conn);

            txtTotalSta.Text = Get_Total("select count(*) from (" + sql_getNSP + ") a");
        }

        private void NSell_Product(DateTime start, DateTime end)
        {
            string sql_getNSP = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, a.DVT, a.Gia from MAT_HANG a, (select MAHANG from MAT_HANG except select a.MAHANG from CHI_TIET_HOA_DON a, HOA_DON b where a.SOHD = b.SOHD and b.NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "') b where a.MAHANG = b.MAHANG";
            function.ShowData(dataGridView1, sql_getNSP, conn);

            txtTotalSta.Text = Get_Total("select count(*) from (" + sql_getNSP + ") a");
        }

        private void Statics_Product()
        {
            if (cbProduct.Text.CompareTo("Số lượng hàng đã bán") == 0)
            {
                if (cbStatics.Text.CompareTo("Thống kê toàn bộ") == 0)
                {
                    lbSta.Text = "Thống kê toàn bộ hàng đã bán";
                    Product();
                }

                else
                {
                    lbSta.Text = "Thống kê toàn bộ hàng đã bán từ ngày " + dtpStart.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpEnd.Value.ToString("dd/MM/yyyy");
                    Product(dtpStart.Value, dtpEnd.Value);
                }
            }

            else if (cbProduct.Text.CompareTo("Mặt hàng bán chạy nhất") == 0)
            {
                if (cbStatics.Text.CompareTo("Thống kê toàn bộ") == 0)
                {
                    lbSta.Text = "Thống kê toàn bộ mặt hàng bán chạy nhất";
                    Best_Product();
                }

                else
                {
                    lbSta.Text = "Thống kê toàn bộ mặt hàng bán chạy nhất từ ngày " + dtpStart.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpEnd.Value.ToString("dd/MM/yyyy");
                    Best_Product(dtpStart.Value, dtpEnd.Value);
                }
            }

            else if (cbProduct.Text.CompareTo("Mặt hàng bán ít nhất") == 0)
            {
                if (cbStatics.Text.CompareTo("Thống kê toàn bộ") == 0)
                {
                    lbSta.Text = "Thống kê toàn bộ mặt hàng bán được ít nhất";
                    Slump_Product();
                }

                else
                {
                    lbSta.Text = "Thống kê toàn bộ mặt hàng bán được ít nhất từ ngày " + dtpStart.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpEnd.Value.ToString("dd/MM/yyyy");
                    Slump_Product(dtpStart.Value, dtpEnd.Value);
                }
            }

            else if(cbProduct.Text.CompareTo("Mặt hàng chưa bán ra được") == 0)
            {
                if (cbStatics.Text.CompareTo("Thống kê toàn bộ") == 0)
                {
                    lbSta.Text = "Thống kê toàn bộ mặt hàng chưa bán ra được";
                    NSell_Product();
                }

                else
                {
                    lbSta.Text = "Thống kê toàn bộ mặt hàng chưa bán được từ ngày " + dtpStart.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpEnd.Value.ToString("dd/MM/yyyy");
                    NSell_Product(dtpStart.Value, dtpEnd.Value);
                }
            }
        }

        private void Customer()
        {
            string sql_getCus = "select * from KHACH_HANG";
            function.ShowData(dataGridView1, sql_getCus, conn);

            txtTotalSta.Text = Get_Total("select count(*) from KHACH_HANG");
        }

        private void Customer(DateTime start, DateTime end)
        {
            string sql_getCus = "select distinct a.MAKH, MALOAIKH, HOTEN, DIACHI, SDT from KHACH_HANG a, HOA_DON b where a.MAKH = b.MAKH and b.NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "'";
            function.ShowData(dataGridView1, sql_getCus, conn);

            txtTotalSta.Text = Get_Total("select count(*) from (" + sql_getCus + ") a");
        }

        private void Customer_Type(string idType)
        {
            string sql_getCus = "select * from KHACH_HANG where MALOAIKH = '" + idType + "'";
            function.ShowData(dataGridView1, sql_getCus, conn);

            if(idType.CompareTo("LK001") == 0)
            {
                int temp = Convert.ToInt16(Get_Total("select count(*) from (" + sql_getCus + ") a"));
                txtTotalSta.Text = Convert.ToString(temp - 1);
            }

            else txtTotalSta.Text = Get_Total("select count(*) from (" + sql_getCus + ") a");
        }

        private void Returned_Customer()
        {
            string sql_getCus = "select a.MAKH, MALOAIKH, HOTEN, DIACHI, SDT, SO_LAN_MUA_HANG from KHACH_HANG a, (select MAKH, count(*) SO_LAN_MUA_HANG from HOA_DON group by MAKH) b where a.MAKH = b.MAKH and SO_LAN_MUA_HANG > 1";
            function.ShowData(dataGridView1, sql_getCus, conn);

            txtTotalSta.Text = Get_Total("select count(*) from (" + sql_getCus + ") a");
        }

        private void Statics_Customer()
        {
            if(cbCustomer.Text.CompareTo("Số lượng khách hàng") == 0)
            {
                if(cbStatics.Text.CompareTo("Thống kê toàn bộ") == 0)
                {
                    lbSta.Text = "Thống kê toàn bộ khách hàng";
                    Customer();
                }

                else
                {
                    lbSta.Text = "Thống kê toàn bộ khách hàng từ ngày " + dtpStart.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpEnd.Value.ToString("dd/MM/yyyy");
                    Customer(dtpStart.Value, dtpEnd.Value);
                }
            }

            else if(cbCustomer.Text.CompareTo("Khách hàng thường") == 0)
            {
                lbSta.Text = "Thống kê toàn bộ khách hàng thường";
                Customer_Type("LK001");
            }

            else if (cbCustomer.Text.CompareTo("Khách hàng thân thiết") == 0)
            {
                lbSta.Text = "Thống kê toàn bộ khách hàng thân thiết";
                Customer_Type("LK002");
            }

            else if (cbCustomer.Text.CompareTo("Khách hàng V.I.P") == 0)
            {
                lbSta.Text = "Thống kê toàn bộ khách hàng V.I.P";
                Customer_Type("LK003");
            }

            else if (cbCustomer.Text.CompareTo("Khách hàng quay trở lại") == 0)
            {
                lbSta.Text = "Thống kê toàn bộ khách hàng có quay trở lại mua hàng sau lần đầu mua";
                Returned_Customer();
            }

        }

        private void Revenue()
        {
            string sql_Rev = "select YEAR(NGAYLAP) NAM, MONTH(NGAYLAP) THANG, sum(THANHTIEN) TONGDOANHTHU from HOA_DON group by YEAR(NGAYLAP), MONTH(NGAYLAP)";
            function.ShowData(dataGridView1, sql_Rev, conn);

            txtTotalSta.Text = Get_Total("select sum(THANHTIEN) from HOA_DON");
        }

        private void Revenue(DateTime start, DateTime end)
        {
            string sql_Rev = "select YEAR(NGAYLAP) NAM, MONTH(NGAYLAP) THANG, sum(THANHTIEN) TONGDOANHTHU from HOA_DON where NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "' group by YEAR(NGAYLAP), MONTH(NGAYLAP)";
            function.ShowData(dataGridView1, sql_Rev, conn);

            txtTotalSta.Text = Get_Total("select sum(THANHTIEN) from HOA_DON where NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "'");
        }

      /*  private void Revenue_Product()
        {
            string sql_getRe = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, b.SO_LUONG_DA_BAN * GIA DOANHTHU from MAT_HANG a, (select b.MAHANG, sum(b.SOLUONG) SO_LUONG_DA_BAN from MAT_HANG a, CHI_TIET_HOA_DON b where a.MAHANG = b.MAHANG group by b.MAHANG) b where a.MAHANG = b.MAHANG";
            function.ShowData(dataGridView1, sql_getRe, conn);

            txtTotalSta.Text = Get_Total("select sum(DOANH_THU) from (" + sql_getRe + ") a");
        }

        private void Revenue_Product(DateTime start, DateTime end)
        {
            string sql_getRe = "select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, b.SO_LUONG_DA_BAN * a.GIA DOANHTHU from MAT_HANG a, (select a.MAHANG, a.MALOAIHANG, a.MANCC, a.TENHANG, a.DVT, a.Gia, b.SO_LUONG_DA_BAN from MAT_HANG a, (select b.MAHANG, sum(b.SOLUONG) SO_LUONG_DA_BAN from CHI_TIET_HOA_DON b, HOA_DON c where c.SOHD = b.SOHD and c.NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:s") + "' group by b.MAHANG) b where a.MAHANG = b.MAHANG) b where a.MAHANG = b.MAHANG";
            function.ShowData(dataGridView1, sql_getRe, conn);

            txtTotalSta.Text = Get_Total("select sum(DOANH_THU) from (" + sql_getRe + ") a");
        }*/

        private void Revenue_Employee()
        {
            string sql_getRE = "select b.MANV, a.HOTEN, sum(THANHTIEN) TONGDOANHTHU from NHAN_VIEN a, HOA_DON b where a.MANV = b.MANV group by b.MANV, a.HOTEN";
            function.ShowData(dataGridView1 , sql_getRE, conn);
        }

        private void Revenue_Employee(DateTime start, DateTime end)
        {
            string sql_getRE = "select a.MANV, b.HOTEN, sum(THANHTIEN) TONGDOANHTHU from HOA_DON a, NHAN_VIEN b where a.MANV = b.MANV and NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "' group by a.MANV, b.HOTEN";
            function.ShowData(dataGridView1,sql_getRE, conn);
        }

        private void Revenue_Employee_Month()
        {
            string sql_getRE = "select b.NAM, b.THANG, a.MANV, a.HOTEN, b.TONGDOANHTHU from NHAN_VIEN a, (select YEAR(NGAYLAP) NAM, MONTH(NGAYLAP) THANG, MANV, sum(THANHTIEN) TONGDOANHTHU from HOA_DON group by YEAR(NGAYLAP), MONTH(NGAYLAP), MANV) b where a.MANV = b.MANV";
            function.ShowData(dataGridView1, sql_getRE, conn);
        }

        private void Revenue_Employee_Month(DateTime start, DateTime end)
        {
            string sql_getRE = "select b.NAM, b.THANG, a.MANV, a.HOTEN, b.TONGDOANHTHU from NHAN_VIEN a, (select YEAR(NGAYLAP) NAM, MONTH(NGAYLAP) THANG, MANV, sum(THANHTIEN) TONGDOANHTHU from HOA_DON where NGAYLAP between '" + start.ToString("yyyy-MM-dd hh:mm:ss") + "' and '" + end.ToString("yyyy-MM-dd hh:mm:ss") + "' group by YEAR(NGAYLAP), MONTH(NGAYLAP), MANV) b where a.MANV = b.MANV";
            function.ShowData(dataGridView1, sql_getRE, conn);
        }

        private void Statics_Revenue()
        {
            if (cbRevenue.Text.CompareTo("Doanh thu bán hàng (tính theo từng tháng)") == 0)
            {
                if (cbStatics.Text.CompareTo("Thống kê toàn bộ") == 0)
                {
                    lbSta.Text = "Thống kê toàn bộ doanh thu (hiển thị theo từng tháng)";
                    Revenue();
                }

                else
                {
                    lbSta.Text = "Thống kê doanh thu từ ngày " + dtpStart.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpEnd.Value.ToString("dd/MM/yyyy") + "(hiển thị theo từng tháng)";
                    Revenue(dtpStart.Value, dtpEnd.Value);
                }
            }

            else if (cbRevenue.Text.CompareTo("Doanh thu bán hàng của từng nhân viên") == 0)
            {
                if (cbStatics.Text.CompareTo("Thống kê toàn bộ") == 0)
                {
                    lbSta.Text = "Thống kê toàn bộ doanh thu bán hàng của từng nhân viên";
                    Revenue_Employee();
                }

                else
                {
                    lbSta.Text = "Thống kê doanh thu bán hàng của từng nhân viên từ ngày " + dtpStart.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpEnd.Value.ToString("dd/MM/yyyy");
                    Revenue_Employee(dtpStart.Value, dtpEnd.Value);
                }
            }

            else if (cbRevenue.Text.CompareTo("Doanh thu của từng nhân viên bán hàng (từng tháng)") == 0)
            {
                if (cbStatics.Text.CompareTo("Thống kê toàn bộ") == 0)
                {
                    lbSta.Text = "Thống kê toàn bộ doanh thu bán hàng của từng nhân viên (hiển thị theo từng tháng)";
                    Revenue_Employee_Month();
                }

                else
                {
                    lbSta.Text = "Thống kê doanh thu bán hàng của từng nhân viên từ ngày " + dtpStart.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpEnd.Value.ToString("dd/MM/yyyy") + "(hiển thị theo từng tháng)";
                    Revenue_Employee_Month(dtpStart.Value, dtpEnd.Value);
                }
            }

        }

        private void btnSta_Click(object sender, EventArgs e)
        {
            if(flag == 0 || cbStatics.Text.CompareTo("Chọn loại thống kê") == 0)
            {
                MessageBox.Show("Vui lòng chọn loại thống kê");
            }

            else
            {
                if (flag == 1)
                {
                    Statics_Product();
                }

   //             else if(cbStatics.Text.CompareTo("Chọn loại thống kê") == 0)
   //             {
                else if (flag == 2)
                {
                    Statics_Customer();
                }

                else if (flag == 3)
                {
                    Statics_Revenue();
                }

                flag = 0;

                cbCustomer.Enabled = true;
                cbRevenue.Enabled = true;
                cbProduct.Enabled = true;

                btnSelectCus.Enabled = true;
                btnSelectRev.Enabled = true;
                btnSelectPro.Enabled = true;

                Default_Show();
            }
        }
    }
}
