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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyBanHang
{
    public partial class FrmNhanVien : Form
    {
        SqlConnection conn = new SqlConnection();
        Function function = new Function();

        public FrmNhanVien()
        {
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

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            function.Connection(conn);
            function.ShowData(dataGridView1, "SELECT * FROM NHAN_VIEN", conn);

            btnCancelAE.Enabled = false;
            btnCancelAE.Visible = false;

            btnLuu.Enabled = false;
            btnLuu.Visible = false;

            txtMa.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNv.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbPosition.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void Update_Employee(string sql)
        {
            function.Update(sql, conn);
            function.ShowData(dataGridView1, "select * from NHAN_VIEN", conn);
        }

        private string Auto_ID(string id)
        {
            string sql_max = "select max(SUBSTRING(manv,3,3)) from NHAN_VIEN where SUBSTRING(manv,1,2) = '" + id + "'";
            SqlCommand comd = new SqlCommand(sql_max, conn);
            SqlDataReader reader = comd.ExecuteReader();

            string id_emp = string.Empty;

            if (reader.Read())
            {
                int max = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                if (max < 10)
                {
                    id_emp = id + "00" + max;
                }
                else if (max < 100)
                {
                    id_emp = id + "0" + max;
                }
                else
                {
                    id_emp = id + max;
                }
            }

            reader.Close();

            return id_emp;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cbPosition.Text = "Chọn chức vụ";

            txtTenNv.Text = string.Empty;
            txtSdt.Text = string.Empty;   
            txtDiaChi.Text = string.Empty;
            txtMatKhau.Text = string.Empty;

            dataGridView1.Enabled = false;

            btnSua.Enabled = false;
            btnSua.Visible = false;

            btnLuu.Enabled = false;
            btnLuu.Visible = false;

            btnCancelAE.Enabled = true;
            btnCancelAE.Visible = true;

            btnLuu.Enabled = true;
            btnLuu.Visible = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbPosition.Text.CompareTo("Chọn chức vụ") == 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!");
            }

            else
            {
                if (cbPosition.Text.CompareTo("Nhân viên") == 0)
                {
                   txtMa.Text = Auto_ID("NV");
                }
                else txtMa.Text = Auto_ID("AD");

                if (string.IsNullOrEmpty(txtTenNv.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhân viên!");
                }

                else if (string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ nhân viên!");
                }

                else if (string.IsNullOrEmpty(txtSdt.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại nhân viên!");
                }

                else if (string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu nhân viên!");
                }

                else
                {
                    Update_Employee("INSERT INTO NHAN_VIEN values('" + txtMa.Text + "', N'" + txtTenNv.Text + "','" + txtSdt.Text + "', N'" + txtDiaChi.Text + "','" + txtMatKhau.Text + "', N'" + cbPosition.Text + "')");

                    dataGridView1.Enabled = true;

                    btnSua.Enabled = true;
                    btnSua.Visible = true;

                    btnLuu.Enabled = true;
                    btnLuu.Visible = true;

                    btnCancelAE.Enabled = false;
                    btnCancelAE.Visible = false;

                    btnLuu.Enabled = false;
                    btnLuu.Visible = false;
                }
            }
        }

        private void btnCancelAE_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã hủy!");

            txtMa.Text = string.Empty;
            txtTenNv.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtSdt.Text = string.Empty;

            dataGridView1.Enabled = true;

            btnSua.Enabled = true;
            btnSua.Visible = true;

            btnLuu.Enabled = true;
            btnLuu.Visible = true;

            btnCancelAE.Enabled = false;
            btnCancelAE.Visible = false;

            btnLuu.Enabled = false;
            btnLuu.Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNv.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
            }

            else if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhân viên!");
            }

            else if (string.IsNullOrEmpty(txtSdt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhân viên!");
            }

            else
            {

                if (cbPosition.Text.CompareTo("Nhân viên") == 0 && txtMa.Text.Substring(1) == "NV" || cbPosition.Text.CompareTo("Quản lý") == 0 && txtMa.Text.Substring(1) == "AD")
                {
                    Update_Employee("UPDATE NHAN_VIEN SET HOTEN=N'" + txtTenNv.Text + "',SDT='" + txtSdt.Text + "',DIACHI=N'" + txtDiaChi.Text + "',MATKHAU='" + txtMatKhau.Text + "',LOAINV = N'" + cbPosition.Text + "' WHERE MANV='" + txtMa.Text + "'");

                }

                else
                {
                    string id_emp = string.Empty;
                    //MessageBox.Show(txtMa.Text.Substring(0,2));

                    if (cbPosition.Text.CompareTo("Nhân viên") == 0 && txtMa.Text.Substring(0,2) == "AD")
                    { 
                        id_emp = Auto_ID("NV");             
                    }

                    if (cbPosition.Text.CompareTo("Quản lý") == 0 && txtMa.Text.Substring(0,2) == "NV")
                    {
                        id_emp = Auto_ID("AD");
                    }

                    Update_Employee("INSERT INTO NHAN_VIEN values('" + id_emp + "', N'" + txtTenNv.Text + "','" + txtSdt.Text + "', N'" + txtDiaChi.Text + "','" + txtMatKhau.Text + "', N'" + cbPosition.Text + "')");
                    Update_Employee("DELETE FROM NHAN_VIEN WHERE MANV='" + txtMa.Text + "' ");

                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Update_Employee("DELETE FROM NHAN_VIEN WHERE MANV='" + txtMa.Text + "' ");
        }
    }
}
