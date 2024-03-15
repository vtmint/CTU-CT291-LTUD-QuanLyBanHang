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
    public partial class FrmKhachHang : Form
    {
        SqlConnection conn = new SqlConnection();
        Function function = new Function();

        public FrmKhachHang()
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

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            function.Connection(conn);
            function.ShowData(dataGridView1, "select kh.makh,kh.hoten,kh.diachi,kh.sdt,lkh.tenloaikh from KHACH_HANG kh,LOAI_KHACH_HANG lkh where kh.maloaikh= lkh.maloaikh order by MaKH desc", conn);
            function.ShowDataComb(cbLoai, "select maloaikh,tenloaikh from LOAI_KHACH_HANG", conn, "tenloaikh", "maloaikh");

            txtMa.ReadOnly = true;

            btnSaveCus.Enabled = false;
            btnSaveCus.Visible = false;

            btnCancelAddCus.Enabled = false;
            btnCancelAddCus.Visible = false;
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            string sql_max = "select max(SUBSTRING(makh,3,3)) from KHACH_HANG";
            SqlCommand comd = new SqlCommand(sql_max, conn);
            SqlDataReader reader = comd.ExecuteReader();
           
            if (reader.Read())
            {
                int max = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                if (max < 10)
                {
                    txtMa.Text = "KH00" + max;
                }
                else if (max < 100)
                {
                    txtMa.Text = "KH0" + max;
                }
                else
                {
                    txtMa.Text = "KH" + max;
                }
            }

            reader.Close();
   
            txtTen.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";
            cbLoai.Text = "Chọn loại khách hàng";

            dataGridView1.Enabled = false;
            txtSearchCus.Enabled = false;

            btnDeleteCus.Enabled = false;
            btnDeleteCus.Visible = false;

            btnEditCus.Enabled = false;
            btnEditCus.Visible = false;

            btnSaveCus.Enabled = true;
            btnSaveCus.Visible = true;

            btnCancelAddCus.Enabled = true;
            btnCancelAddCus.Visible = true;
        }

        private void Update_Customer(string sql)
        {
            function.Update(sql, conn);
            function.ShowData(dataGridView1, "select kh.makh,kh.hoten,kh.diachi,kh.sdt,lkh.tenloaikh from KHACH_HANG kh,LOAI_KHACH_HANG lkh where kh.maloaikh= lkh.maloaikh order by MaKH desc", conn);
        }

        private void btnEditCus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
            }

            else if (string.IsNullOrEmpty(txtDiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng!");
            }

            else if (string.IsNullOrEmpty(txtSdt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!");
            }

            else if (cbLoai.Text.CompareTo("Chọn loại khách hàng") == 0)
            {
                MessageBox.Show("Vui lòng chọn loại khách hàng!");
            }

            else
            {
                Update_Customer("update KHACH_HANG set hoten=N'" + txtTen.Text + "',diachi=N'" + txtDiachi.Text + "',Sdt='" + txtSdt.Text + "',maloaikh='" + cbLoai.SelectedValue.ToString() + "' where makh ='" + txtMa.Text + "'");
            }
        }

        private void btnDeleteCus_Click(object sender, EventArgs e)
        {
           Update_Customer("delete from KHACH_HANG where makh='" + txtMa.Text + "'");
        }

        private void btnSaveCus_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
            }

            else if (string.IsNullOrEmpty(txtDiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng!");
            }

            else if(string.IsNullOrEmpty(txtSdt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!");
            }

            else if(cbLoai.Text.CompareTo("Chọn loại khách hàng") == 0)
            {
                MessageBox.Show("Vui lòng chọn loại khách hàng!");
            }

            else
            {
                Update_Customer("insert into KHACH_HANG(makh,hoten,diachi,sdt,maloaikh) values('" + txtMa.Text + "',N'" + txtTen.Text + "',N'" + txtDiachi.Text + "','" + txtSdt.Text + "','" + cbLoai.SelectedValue.ToString() + "')");

                dataGridView1.Enabled = true;
                txtSearchCus.Enabled = true;

                btnDeleteCus.Enabled = true;
                btnDeleteCus.Visible = true;

                btnEditCus.Enabled = true;
                btnEditCus.Visible = true;


                btnSaveCus.Enabled = false;
                btnSaveCus.Visible = false;

                btnCancelAddCus.Enabled = false;
                btnCancelAddCus.Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbLoai.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void txtSearchCus_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtSearchCus.Text;
            string search = "Select MaKH, HoTen, DiaChi, SDT, TenLoaiKH from KHACH_HANG kh,LOAI_KHACH_HANG lkh where kh.maloaikh = lkh.maloaikh and (makh like '%" + tukhoa + "%' or hoten like N'%" + tukhoa + "%' or TenLoaiKH like '%" + tukhoa + "%' or SDT like N'%" + tukhoa + "%')";
            function.ShowData(dataGridView1, search, conn);
        }

        private void btnCancelAddCus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã hủy!");

            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtSdt.Text = string.Empty;
            txtDiachi.Text = string.Empty;

            dataGridView1.Enabled = true;
            txtSearchCus.Enabled = true;

            btnDeleteCus.Enabled = true;
            btnDeleteCus.Visible = true;

            btnEditCus.Enabled = true;
            btnEditCus.Visible = true;


            btnSaveCus.Enabled = false;
            btnSaveCus.Visible = false;

            btnCancelAddCus.Enabled = false;
            btnCancelAddCus.Visible = false;
        }
    }
}
