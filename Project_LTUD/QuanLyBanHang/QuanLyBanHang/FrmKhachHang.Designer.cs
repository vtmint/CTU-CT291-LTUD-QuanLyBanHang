namespace QuanLyBanHang
{
    partial class FrmKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.txtSearchCus = new System.Windows.Forms.TextBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelAddCus = new System.Windows.Forms.Button();
            this.btnSaveCus = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEditCus = new System.Windows.Forms.Button();
            this.btnDeleteCus = new System.Windows.Forms.Button();
            this.btnAddCus = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cbLoai);
            this.groupBox1.Controls.Add(this.txtSearchCus);
            this.groupBox1.Controls.Add(this.txtDiachi);
            this.groupBox1.Controls.Add(this.txtSdt);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1025, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Items.AddRange(new object[] {
            "Khách hàng thường",
            "Khách hàng thân thiết"});
            this.cbLoai.Location = new System.Drawing.Point(585, 96);
            this.cbLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(217, 24);
            this.cbLoai.TabIndex = 2;
            // 
            // txtSearchCus
            // 
            this.txtSearchCus.Location = new System.Drawing.Point(765, 169);
            this.txtSearchCus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchCus.Name = "txtSearchCus";
            this.txtSearchCus.Size = new System.Drawing.Size(227, 23);
            this.txtSearchCus.TabIndex = 1;
            this.txtSearchCus.TextChanged += new System.EventHandler(this.txtSearchCus_TextChanged);
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(164, 142);
            this.txtDiachi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(217, 23);
            this.txtDiachi.TabIndex = 1;
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(585, 44);
            this.txtSdt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(217, 23);
            this.txtSdt.TabIndex = 1;
            this.txtSdt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NhapSo);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(164, 96);
            this.txtTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(217, 23);
            this.txtTen.TabIndex = 1;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(164, 49);
            this.txtMa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(217, 23);
            this.txtMa.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Loại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số điện thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(602, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tìm kiếm khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Địa chỉ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btnCancelAddCus);
            this.groupBox2.Controls.Add(this.btnSaveCus);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.btnEditCus);
            this.groupBox2.Controls.Add(this.btnDeleteCus);
            this.groupBox2.Controls.Add(this.btnAddCus);
            this.groupBox2.Location = new System.Drawing.Point(11, 226);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1025, 546);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelAddCus
            // 
            this.btnCancelAddCus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAddCus.Location = new System.Drawing.Point(313, 489);
            this.btnCancelAddCus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelAddCus.Name = "btnCancelAddCus";
            this.btnCancelAddCus.Size = new System.Drawing.Size(99, 40);
            this.btnCancelAddCus.TabIndex = 4;
            this.btnCancelAddCus.Text = "Hủy";
            this.btnCancelAddCus.UseVisualStyleBackColor = true;
            this.btnCancelAddCus.Click += new System.EventHandler(this.btnCancelAddCus_Click);
            // 
            // btnSaveCus
            // 
            this.btnSaveCus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCus.Location = new System.Drawing.Point(164, 489);
            this.btnSaveCus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveCus.Name = "btnSaveCus";
            this.btnSaveCus.Size = new System.Drawing.Size(99, 40);
            this.btnSaveCus.TabIndex = 3;
            this.btnSaveCus.Text = "Lưu";
            this.btnSaveCus.UseVisualStyleBackColor = true;
            this.btnSaveCus.Click += new System.EventHandler(this.btnSaveCus_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 13);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(963, 452);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnEditCus
            // 
            this.btnEditCus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCus.Location = new System.Drawing.Point(164, 489);
            this.btnEditCus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditCus.Name = "btnEditCus";
            this.btnEditCus.Size = new System.Drawing.Size(99, 40);
            this.btnEditCus.TabIndex = 1;
            this.btnEditCus.Text = "Sửa";
            this.btnEditCus.UseVisualStyleBackColor = true;
            this.btnEditCus.Click += new System.EventHandler(this.btnEditCus_Click);
            // 
            // btnDeleteCus
            // 
            this.btnDeleteCus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCus.Location = new System.Drawing.Point(313, 489);
            this.btnDeleteCus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteCus.Name = "btnDeleteCus";
            this.btnDeleteCus.Size = new System.Drawing.Size(99, 40);
            this.btnDeleteCus.TabIndex = 1;
            this.btnDeleteCus.Text = "Xóa";
            this.btnDeleteCus.UseVisualStyleBackColor = true;
            this.btnDeleteCus.Click += new System.EventHandler(this.btnDeleteCus_Click);
            // 
            // btnAddCus
            // 
            this.btnAddCus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCus.Location = new System.Drawing.Point(24, 489);
            this.btnAddCus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCus.Name = "btnAddCus";
            this.btnAddCus.Size = new System.Drawing.Size(99, 40);
            this.btnAddCus.TabIndex = 1;
            this.btnAddCus.Text = "Thêm";
            this.btnAddCus.UseVisualStyleBackColor = true;
            this.btnAddCus.Click += new System.EventHandler(this.btnAddCus_Click);
            // 
            // FrmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1047, 781);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmKhachHang";
            this.Text = "FrmKhachHang";
            this.Load += new System.EventHandler(this.FrmKhachHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEditCus;
        private System.Windows.Forms.Button btnDeleteCus;
        private System.Windows.Forms.Button btnAddCus;
        private System.Windows.Forms.TextBox txtSearchCus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveCus;
        private System.Windows.Forms.Button btnCancelAddCus;
    }
}