namespace QuanLyBanHang
{
    partial class FrmThongKe
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
            this.btnSelectRev = new System.Windows.Forms.Button();
            this.btnSelectCus = new System.Windows.Forms.Button();
            this.btnSelectPro = new System.Windows.Forms.Button();
            this.btnReSelect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbStatics = new System.Windows.Forms.ComboBox();
            this.btnSta = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRevenue = new System.Windows.Forms.ComboBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbSta = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalSta = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnSelectRev);
            this.groupBox1.Controls.Add(this.btnSelectCus);
            this.groupBox1.Controls.Add(this.btnSelectPro);
            this.groupBox1.Controls.Add(this.btnReSelect);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbStatics);
            this.groupBox1.Controls.Add(this.btnSta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbRevenue);
            this.groupBox1.Controls.Add(this.cbCustomer);
            this.groupBox1.Controls.Add(this.cbProduct);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1017, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê";
            // 
            // btnSelectRev
            // 
            this.btnSelectRev.Location = new System.Drawing.Point(388, 142);
            this.btnSelectRev.Name = "btnSelectRev";
            this.btnSelectRev.Size = new System.Drawing.Size(70, 31);
            this.btnSelectRev.TabIndex = 10;
            this.btnSelectRev.Text = "Chọn";
            this.btnSelectRev.UseVisualStyleBackColor = true;
            this.btnSelectRev.Click += new System.EventHandler(this.btnSelectRev_Click);
            // 
            // btnSelectCus
            // 
            this.btnSelectCus.Location = new System.Drawing.Point(388, 92);
            this.btnSelectCus.Name = "btnSelectCus";
            this.btnSelectCus.Size = new System.Drawing.Size(70, 31);
            this.btnSelectCus.TabIndex = 10;
            this.btnSelectCus.Text = "Chọn";
            this.btnSelectCus.UseVisualStyleBackColor = true;
            this.btnSelectCus.Click += new System.EventHandler(this.btnSelectCus_Click);
            // 
            // btnSelectPro
            // 
            this.btnSelectPro.Location = new System.Drawing.Point(388, 41);
            this.btnSelectPro.Name = "btnSelectPro";
            this.btnSelectPro.Size = new System.Drawing.Size(70, 31);
            this.btnSelectPro.TabIndex = 10;
            this.btnSelectPro.Text = "Chọn";
            this.btnSelectPro.UseVisualStyleBackColor = true;
            this.btnSelectPro.Click += new System.EventHandler(this.btnSelectPro_Click);
            // 
            // btnReSelect
            // 
            this.btnReSelect.Location = new System.Drawing.Point(345, 197);
            this.btnReSelect.Name = "btnReSelect";
            this.btnReSelect.Size = new System.Drawing.Size(113, 33);
            this.btnReSelect.TabIndex = 10;
            this.btnReSelect.Text = "Bỏ chọn";
            this.btnReSelect.UseVisualStyleBackColor = true;
            this.btnReSelect.Click += new System.EventHandler(this.btnReSelect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(564, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Loại thống kê";
            // 
            // cbStatics
            // 
            this.cbStatics.FormattingEnabled = true;
            this.cbStatics.Items.AddRange(new object[] {
            "Thống kê toàn bộ",
            "Thống kê theo khoảng thời gian đã chọn"});
            this.cbStatics.Location = new System.Drawing.Point(682, 39);
            this.cbStatics.Name = "cbStatics";
            this.cbStatics.Size = new System.Drawing.Size(264, 24);
            this.cbStatics.TabIndex = 8;
            // 
            // btnSta
            // 
            this.btnSta.Location = new System.Drawing.Point(833, 195);
            this.btnSta.Name = "btnSta";
            this.btnSta.Size = new System.Drawing.Size(113, 33);
            this.btnSta.TabIndex = 7;
            this.btnSta.Text = "Thống kê";
            this.btnSta.UseVisualStyleBackColor = true;
            this.btnSta.Click += new System.EventHandler(this.btnSta_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Doanh thu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Khách hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mặt hàng";
            // 
            // cbRevenue
            // 
            this.cbRevenue.FormattingEnabled = true;
            this.cbRevenue.Items.AddRange(new object[] {
            "Doanh thu bán hàng (tính theo từng tháng)",
            "Doanh thu bán hàng của từng nhân viên",
            "Doanh thu của từng nhân viên bán hàng (từng tháng)"});
            this.cbRevenue.Location = new System.Drawing.Point(133, 147);
            this.cbRevenue.Name = "cbRevenue";
            this.cbRevenue.Size = new System.Drawing.Size(235, 24);
            this.cbRevenue.TabIndex = 4;
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Items.AddRange(new object[] {
            "Số lượng khách hàng",
            "Khách hàng quay trở lại",
            "Khách hàng thường",
            "Khách hàng thân thiết",
            "Khách hàng V.I.P"});
            this.cbCustomer.Location = new System.Drawing.Point(133, 95);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(235, 24);
            this.cbCustomer.TabIndex = 4;
            // 
            // cbProduct
            // 
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Items.AddRange(new object[] {
            "Số lượng hàng đã bán",
            "Mặt hàng bán chạy nhất",
            "Mặt hàng bán ít nhất",
            "Mặt hàng chưa bán ra được"});
            this.cbProduct.Location = new System.Drawing.Point(133, 46);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(235, 24);
            this.cbProduct.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày kết thúc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(563, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày bắt đầu";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(682, 90);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(264, 23);
            this.dtpStart.TabIndex = 0;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(682, 142);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(264, 23);
            this.dtpEnd.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.lbSta);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTotalSta);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 270);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1017, 486);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lbSta
            // 
            this.lbSta.AutoSize = true;
            this.lbSta.Location = new System.Drawing.Point(15, 51);
            this.lbSta.Name = "lbSta";
            this.lbSta.Size = new System.Drawing.Size(0, 17);
            this.lbSta.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(664, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tổng";
            // 
            // txtTotalSta
            // 
            this.txtTotalSta.Location = new System.Drawing.Point(737, 48);
            this.txtTotalSta.Name = "txtTotalSta";
            this.txtTotalSta.Size = new System.Drawing.Size(209, 23);
            this.txtTotalSta.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 101);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1002, 368);
            this.dataGridView1.TabIndex = 0;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1038, 781);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmThongKe";
            this.Text = "FrmThongKe";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTotalSta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRevenue;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbStatics;
        private System.Windows.Forms.Button btnSta;
        private System.Windows.Forms.Label lbSta;
        private System.Windows.Forms.Button btnSelectRev;
        private System.Windows.Forms.Button btnSelectCus;
        private System.Windows.Forms.Button btnSelectPro;
        private System.Windows.Forms.Button btnReSelect;
    }
}