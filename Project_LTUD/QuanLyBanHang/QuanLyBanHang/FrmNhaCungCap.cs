using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FrmNhaCungCap : Form
    {
        SqlConnection conn = new SqlConnection();
        Function function = new Function();

        public FrmNhaCungCap()
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


        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            function.Connection(conn);
            function.ShowData(dataGridView1, "select * from NHA_CUNG_CAP", conn);
            txtMa.ReadOnly = true;

            btnSaveVendor.Enabled = false;
            btnSaveVendor.Visible = false;

            btnCancelAV.Visible = false;
            btnCancelAV.Enabled = false;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        public void Update_Vendor(string sql)
        {
            function.Update(sql, conn);
            function.ShowData(dataGridView1, "select * from NHA_CUNG_CAP", conn);
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            string sql_max = "select max(SUBSTRING(mancc,4,2)) from NHA_CUNG_CAP";
            SqlCommand comd = new SqlCommand(sql_max, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                int max = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                if (max < 10)
                {
                    txtMa.Text = "NCC0" + max;
                }
                else
                {
                    txtMa.Text = "NCC" + max;
                }
            }

            reader.Close();
            
            txtTen.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";

            dataGridView1.Enabled = false;
            txtSearchVendor.Enabled = false;

            btnEditVendor.Enabled = false;
            btnEditVendor.Visible = false;

            btnDeleteVendor.Enabled = false;
            btnDeleteVendor.Visible = false;

            btnSaveVendor.Enabled = true;
            btnSaveVendor.Visible = true;

            btnCancelAV.Visible = true;
            btnCancelAV.Enabled = true;
        }

        private void btnSaveVendor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!");
            }

            else if (string.IsNullOrEmpty(txtDiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp!");
            }

            else if (string.IsNullOrEmpty(txtSdt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà cung cấp!");
            }

            else
            {
                Update_Vendor("insert into NHA_CUNG_CAP(mancc,tenncc,diachi,sdt) values('" + txtMa.Text + "',N'" + txtTen.Text + "',N'" + txtDiachi.Text + "','" + txtSdt.Text + "')");

                dataGridView1.Enabled = true;
                txtSearchVendor.Enabled = true;

                btnEditVendor.Enabled = true;
                btnEditVendor.Visible = true;

                btnDeleteVendor.Enabled = true;
                btnDeleteVendor.Visible = true;

                btnSaveVendor.Enabled = false;
                btnSaveVendor.Visible = false;

                btnCancelAV.Visible = false;
                btnCancelAV.Enabled = false;
            }
        }

        private void btnCancelAV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã hủy!");

            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtSdt.Text = string.Empty;
            txtDiachi.Text = string.Empty;

            dataGridView1.Enabled = true;
            txtSearchVendor.Enabled = true;

            btnEditVendor.Enabled = true;
            btnEditVendor.Visible = true;

            btnDeleteVendor.Enabled = true;
            btnDeleteVendor.Visible = true;

            btnSaveVendor.Enabled = false;
            btnSaveVendor.Visible = false;

            btnCancelAV.Visible = false;
            btnCancelAV.Enabled = false;
        }

        private void btnDeleteVendor_Click(object sender, EventArgs e)
        {
            Update_Vendor("delete from NHA_CUNG_CAP where mancc = '" + txtMa.Text + "'");
        }

        private void btnEditVendor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!");
            }

            else if (string.IsNullOrEmpty(txtDiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp!");
            }

            else if (string.IsNullOrEmpty(txtSdt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà cung cấp!");
            }

            else Update_Vendor("update NHA_CUNG_CAP set tenncc = N'" + txtTen.Text + "', diachi = N'" + txtDiachi.Text + "', Sdt = '" + txtSdt.Text + "' where mancc ='" + txtMa.Text + "'");
        }

        private void txtSearchVendor_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtSearchVendor.Text;
            string search = "Select * from NHA_CUNG_CAP where (mancc like '%" + tukhoa + "%' or tenncc like N'%" + tukhoa + "%' or SDT like '%" + tukhoa + "%')";
            function.ShowData(dataGridView1, search, conn);
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
