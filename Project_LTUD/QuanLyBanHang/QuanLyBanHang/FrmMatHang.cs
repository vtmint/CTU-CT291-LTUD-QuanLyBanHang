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
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyBanHang
{
    public partial class FrmMatHang : Form
    {
        SqlConnection conn = new SqlConnection();
        Function function = new Function();

        private string auto_link = AppDomain.CurrentDomain.BaseDirectory + "\\images\\";
        private string image = string.Empty;

        public FrmMatHang()
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

        private void FrmMatHang_Load(object sender, EventArgs e)
        {
            function.Connection(conn);
            function.ShowData(dataGridView1, "select mh.mahang, mh.tenhang, mh.dvt, mh.gia, ncc.tenncc,lh.tenloaihang, mh.hinhanh from MAT_HANG mh,NHA_CUNG_CAP ncc,LOAI_HANG lh where mh.mancc=ncc.mancc and mh.maloaihang=lh.maloaihang order by mh.mahang desc", conn);
            function.ShowDataComb(cbVendor, "select mancc,tenncc from NHA_CUNG_CAP", conn, "tenncc", "mancc");
            function.ShowDataComb(cbType, "select maloaihang,tenloaihang from LOAI_HANG", conn, "tenloaihang", "maloaihang");

            cbDvt.Text = "Đơn vị tính";
            cbVendor.Text = "Nhà cung cấp";
            cbType.Text = "Loại hàng";

            txtMa.ReadOnly = true;

            btnCancelPro.Enabled = false;
            btnCancelPro.Visible = false;

            btnLuu.Enabled = false;
            btnLuu.Visible = false;
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            DialogResult kq = openFD.ShowDialog();
            if (kq == DialogResult.OK)
            {
                image = string.Empty;

                string fileAnh = openFD.FileName;
                pictureBox1.Image = new Bitmap(fileAnh);

                image = fileAnh.Substring(fileAnh.LastIndexOf("\\") + 1);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql_max = "select max(SUBSTRING(mahang,3,3)) from MAT_HANG";
            SqlCommand comd = new SqlCommand(sql_max, conn);
            SqlDataReader reader = comd.ExecuteReader();
            
            if (reader.Read())
            {
                int max = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                if (max < 10)
                {
                    txtMa.Text = "MH00" + max;
                }
                else if (max < 100)
                {
                    txtMa.Text = "MH0" + max;
                }
                else
                {
                    txtMa.Text = "MH" + max;
                }
            }
            reader.Close();

            dataGridView1.Enabled = false;

            btnCancelPro.Enabled = true;
            btnCancelPro.Visible = true;

            btnLuu.Enabled = true;
            btnLuu.Visible = true;

            btnSua.Enabled = false;
            btnSua.Visible = false;

            btnXoa.Enabled = false;
            btnXoa.Visible = false;

            image = string.Empty;
            txtTen.Text = "";
            txtGia.Text = "";
            cbDvt.Text = "Chọn đơn vị tính";
            cbVendor.Text = "Chọn nhà cung cấp";
            cbDvt.Text = "Chọn loại hàng";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng!");
            }

            else if (string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá của mặt hàng!");
            }

            else if (cbType.Text.CompareTo("Chọn loại hàng") == 0)
            {
                MessageBox.Show("Vui lòng chọn loại hàng!");
            }

            else if (cbVendor.Text.CompareTo("Chọn nhà cung cấp") == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
            }

            else if (cbDvt.Text.CompareTo("Chọn đơn vị tính") == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính!");
            }

            else if(string.IsNullOrEmpty(image))
            {
                MessageBox.Show("Vui lòng chọn hình ành!");
            }

            else
            {
                string sql_Them = "insert into MAT_HANG(mahang, tenhang, dvt, gia, mancc, maloaihang, hinhanh) values('" + txtMa.Text + "', N'" + txtTen.Text + "', N'" + cbDvt.Text + "','" + float.Parse(txtGia.Text) + "','" + cbVendor.SelectedValue.ToString() + "','" + cbType.SelectedValue.ToString() + "', '" + image + "')";

                function.Update(sql_Them, conn);
                function.ShowData(dataGridView1, "select mh.mahang, mh.tenhang, mh.dvt, mh.gia, ncc.tenncc,lh.tenloaihang, mh.hinhanh from MAT_HANG mh,NHA_CUNG_CAP ncc,LOAI_HANG lh where mh.mancc=ncc.mancc and mh.maloaihang=lh.maloaihang order by mh.mahang desc", conn);

                dataGridView1.Enabled = true;

                btnSua.Enabled = true;
                btnSua.Visible = true;

                btnXoa.Enabled = true;
                btnXoa.Visible = true;

                btnCancelPro.Enabled = false;
                btnCancelPro.Visible = false;

                btnLuu.Enabled = false;
                btnLuu.Visible = false;
            }
        }

        private void btnCancelPro_Click(object sender, EventArgs e)
        {
            image = string.Empty;

            MessageBox.Show("Đã hủy!");

            dataGridView1.Enabled = true;

            btnSua.Enabled = true;
            btnSua.Visible = true;

            btnXoa.Enabled = true;
            btnXoa.Visible = true;

            btnCancelPro.Enabled = false;
            btnCancelPro.Visible = false;

            btnLuu.Enabled = false;
            btnLuu.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbDvt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGia.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbVendor.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbType.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            image = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            pictureBox1.Image = new Bitmap(auto_link + image);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng!");
            }

            else if (string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá của mặt hàng!");
            }

            else if (cbType.Text.CompareTo("Chọn loại hàng") == 0)
            {
                MessageBox.Show("Vui lòng chọn loại hàng!");
            }

            else if (cbVendor.Text.CompareTo("Chọn nhà cung cấp") == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
            }

            else if (cbDvt.Text.CompareTo("Chọn đơn vị tính") == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính!");
            }

            else
            {
                string sql_Capnhat = "update MAT_HANG set tenhang = N'" + txtTen.Text + "', dvt = N'" + cbDvt.Text + "', gia = '" + float.Parse(txtGia.Text) + "', mancc = '" + cbVendor.SelectedValue.ToString() + "', maloaihang = '" + cbType.SelectedValue.ToString() + "', hinhanh = N'" + image + "' where mahang ='" + txtMa.Text + "'";
                function.Update(sql_Capnhat, conn);
                function.ShowData(dataGridView1, "select mh.mahang, mh.tenhang, mh.dvt, mh.gia, ncc.tenncc,lh.tenloaihang, mh.hinhanh from MAT_HANG mh,NHA_CUNG_CAP ncc,LOAI_HANG lh where mh.mancc=ncc.mancc and mh.maloaihang=lh.maloaihang order by mh.mahang desc", conn);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql_Xoa = "delete from MAT_HANG where mahang='" + txtMa.Text + "'";
            function.Update(sql_Xoa, conn);
            function.ShowData(dataGridView1, "select mh.mahang, mh.tenhang, mh.dvt, mh.gia, ncc.tenncc,lh.tenloaihang, mh.hinhanh from MAT_HANG mh,NHA_CUNG_CAP ncc,LOAI_HANG lh where mh.mancc=ncc.mancc and mh.maloaihang=lh.maloaihang order by mh.mahang desc", conn);
        }

        private void txtSearchPro_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtSearchPro.Text;
            string search = "select mh.mahang, mh.tenhang, mh.dvt, mh.gia, ncc.tenncc,lh.tenloaihang, mh.hinhanh from MAT_HANG mh,LOAI_HANG lh,NHA_CUNG_CAP ncc where mh.mancc=ncc.mancc and mh.maloaihang=lh.maloaihang and (mahang like '%" + tukhoa + "%'or tenhang like N'%" + tukhoa + "%' )";
            function.ShowData(dataGridView1, search, conn);
        }
    }
}
