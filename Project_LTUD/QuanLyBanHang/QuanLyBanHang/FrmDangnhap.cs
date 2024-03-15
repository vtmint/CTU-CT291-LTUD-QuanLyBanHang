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
    public partial class FrmDangnhap : Form
    {
        public SqlConnection conn = new SqlConnection();
        Function function = new Function();

        public FrmDangnhap()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            function.Connection(conn);
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string userN = txtUser.Text;
            string passW = txtPass.Text;
            string sql_login = "select * from NHAN_VIEN where MaNV = '" + userN + "' and MatKhau = '" + passW + "'";

            SqlCommand comd = new SqlCommand(sql_login, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                //Xoa text mat khau da nhap
                txtPass.Text = "";
                FrmAdmin frmAdmin = new FrmAdmin(userN);
                frmAdmin.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Vui lòng kiểm tra lại username và password.");
            }

            reader.Close();            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string userN = txtUser.Text;
                string passW = txtPass.Text;
                string sql_login = "select * from NHAN_VIEN where MaNV = '" + userN + "' and MatKhau = '" + passW + "'";

                SqlCommand comd = new SqlCommand(sql_login, conn);
                SqlDataReader reader = comd.ExecuteReader();

                if (reader.Read())
                {
                    txtPass.Text = string.Empty;
                    FrmAdmin frmAdmin = new FrmAdmin(userN);
                    frmAdmin.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại! Vui lòng kiểm tra lại username và password.");
                    txtPass.Text = string.Empty;
                }

                reader.Close();
            }
        }
    }
}
