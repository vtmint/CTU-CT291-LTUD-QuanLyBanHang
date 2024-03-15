using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class Function
    {
        public void Connection(SqlConnection conn)
        {
            string connString = "SERVER = DESKTOP-7S0FQ8J\\SQLEXPRESS; database = QLSieuThi; Integrated Security = true";
            conn.ConnectionString = connString;
            conn.Open();
        }

        public void ShowData(DataGridView dg, string sql, SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "new_table");

            dg.DataSource = dataset;
            dg.DataMember = "new_table";
        }

        public void ShowDataComb(ComboBox comb, string sql, SqlConnection conn, string show, string value)
        {
            SqlCommand comd = new SqlCommand(sql, conn);
            SqlDataReader reader = comd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);

            comb.DataSource = table;
            comb.DisplayMember = show;
            comb.ValueMember = value;

            reader.Close();
        }

        public void Update(string sql, SqlConnection conn)
        {
            SqlCommand comd = new SqlCommand(sql, conn);
            try
            {
                comd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Your query is: " + sql + "with the error is: " + e.Message);
            }
        }

        public void Show_Photo(string sql, string auto_link, SqlConnection conn, PictureBox pbox)
        {
            SqlCommand comd = new SqlCommand(sql, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                pbox.Image = new Bitmap(auto_link + reader.GetValue(0).ToString());
            }

            reader.Close();
        }

    }
}
