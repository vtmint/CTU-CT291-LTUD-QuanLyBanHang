using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace QuanLyBanHang
{
    public partial class FrmAdmin : Form
    {
        string userName;
        SqlConnection conn = new SqlConnection();
        Function function = new Function();

        public FrmAdmin(string userN)
        {
            userName = userN;

            InitializeComponent();
        }

        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            FrmLapHoaDon lapHoaDon = new FrmLapHoaDon(userName);
            lapHoaDon.TopLevel = false;
            flowLayoutPanel1.Controls.Add(lapHoaDon);            
            lapHoaDon.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            FrmNhanVien nhanvien = new FrmNhanVien();
            nhanvien.TopLevel = false;
            flowLayoutPanel1.Controls.Add(nhanvien);
            nhanvien.Show();
        }

        private void btnMatHang_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            FrmMatHang matHang = new FrmMatHang();
            matHang.TopLevel = false;
            flowLayoutPanel1.Controls.Add(matHang);
            matHang.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            FrmThongKe thongKe = new FrmThongKe();
            thongKe.TopLevel = false;
            flowLayoutPanel1.Controls.Add(thongKe);
            thongKe.Show();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            FrmNhaCungCap nhaCungCap = new FrmNhaCungCap();
            nhaCungCap.TopLevel = false;
            flowLayoutPanel1.Controls.Add(nhaCungCap);
            nhaCungCap.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            FrmKhachHang khachHang = new FrmKhachHang();
            khachHang.TopLevel = false;
            flowLayoutPanel1.Controls.Add(khachHang);
            khachHang.Show();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            function.Connection(conn);

            string sql_getEmp = "select HoTen, LoaiNV from NHAN_VIEN where MaNV = '" + userName + "'";
            SqlCommand comd = new SqlCommand(sql_getEmp, conn);
            SqlDataReader reader = comd.ExecuteReader();
            
            if(reader.Read())
            {
                lbUsername.Text = "Mã nhân viên: " + userName;
                lbEmpName.Text = "Họ tên: " + reader.GetValue(0).ToString();
                lbPosition.Text = "Vị trí: " + reader.GetValue(1).ToString();
            }

            reader.Close();

            if (string.Compare(userName.Substring(0,2), "AD", true) != 0)
            {
                btnNhanVien.Enabled = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
