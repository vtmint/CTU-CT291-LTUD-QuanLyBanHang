namespace QuanLyBanHang
{
    partial class FrmNhaCungCap
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
            this.txtSearchVendor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelAV = new System.Windows.Forms.Button();
            this.btnSaveVendor = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDeleteVendor = new System.Windows.Forms.Button();
            this.btnEditVendor = new System.Windows.Forms.Button();
            this.btnAddVendor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtSearchVendor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDiachi);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.txtSdt);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1016, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN NHÀ CUNG CẤP";
            // 
            // txtSearchVendor
            // 
            this.txtSearchVendor.Location = new System.Drawing.Point(738, 176);
            this.txtSearchVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchVendor.Name = "txtSearchVendor";
            this.txtSearchVendor.Size = new System.Drawing.Size(238, 23);
            this.txtSearchVendor.TabIndex = 3;
            this.txtSearchVendor.TextChanged += new System.EventHandler(this.txtSearchVendor_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tìm nhà cung cấp";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số điện thoại";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Địa chỉ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên nhà cung cấp";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã nhà cung cấp";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(652, 62);
            this.txtDiachi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(180, 23);
            this.txtDiachi.TabIndex = 0;
            this.txtDiachi.TextChanged += new System.EventHandler(this.txtDiachi_TextChanged);
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(241, 62);
            this.txtMa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(180, 23);
            this.txtMa.TabIndex = 0;
            this.txtMa.TextChanged += new System.EventHandler(this.txtMa_TextChanged);
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(652, 112);
            this.txtSdt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(180, 23);
            this.txtSdt.TabIndex = 0;
            this.txtSdt.TextChanged += new System.EventHandler(this.txtSdt_TextChanged);
            this.txtSdt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NhapSo);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(241, 112);
            this.txtTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(180, 23);
            this.txtTen.TabIndex = 0;
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btnCancelAV);
            this.groupBox2.Controls.Add(this.btnSaveVendor);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.btnDeleteVendor);
            this.groupBox2.Controls.Add(this.btnEditVendor);
            this.groupBox2.Controls.Add(this.btnAddVendor);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 241);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1016, 512);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelAV
            // 
            this.btnCancelAV.Location = new System.Drawing.Point(311, 453);
            this.btnCancelAV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelAV.Name = "btnCancelAV";
            this.btnCancelAV.Size = new System.Drawing.Size(104, 36);
            this.btnCancelAV.TabIndex = 5;
            this.btnCancelAV.Text = "Hủy";
            this.btnCancelAV.UseVisualStyleBackColor = true;
            this.btnCancelAV.Click += new System.EventHandler(this.btnCancelAV_Click);
            // 
            // btnSaveVendor
            // 
            this.btnSaveVendor.Location = new System.Drawing.Point(165, 453);
            this.btnSaveVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveVendor.Name = "btnSaveVendor";
            this.btnSaveVendor.Size = new System.Drawing.Size(104, 36);
            this.btnSaveVendor.TabIndex = 4;
            this.btnSaveVendor.Text = "Lưu";
            this.btnSaveVendor.UseVisualStyleBackColor = true;
            this.btnSaveVendor.Click += new System.EventHandler(this.btnSaveVendor_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1005, 421);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // btnDeleteVendor
            // 
            this.btnDeleteVendor.Location = new System.Drawing.Point(311, 453);
            this.btnDeleteVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteVendor.Name = "btnDeleteVendor";
            this.btnDeleteVendor.Size = new System.Drawing.Size(104, 36);
            this.btnDeleteVendor.TabIndex = 2;
            this.btnDeleteVendor.Text = "Xóa";
            this.btnDeleteVendor.UseVisualStyleBackColor = true;
            this.btnDeleteVendor.Click += new System.EventHandler(this.btnDeleteVendor_Click);
            // 
            // btnEditVendor
            // 
            this.btnEditVendor.Location = new System.Drawing.Point(165, 454);
            this.btnEditVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditVendor.Name = "btnEditVendor";
            this.btnEditVendor.Size = new System.Drawing.Size(104, 36);
            this.btnEditVendor.TabIndex = 2;
            this.btnEditVendor.Text = "Sửa";
            this.btnEditVendor.UseVisualStyleBackColor = true;
            this.btnEditVendor.Click += new System.EventHandler(this.btnEditVendor_Click);
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Location = new System.Drawing.Point(21, 453);
            this.btnAddVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(104, 37);
            this.btnAddVendor.TabIndex = 2;
            this.btnAddVendor.Text = "Thêm";
            this.btnAddVendor.UseVisualStyleBackColor = true;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // FrmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1038, 768);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmNhaCungCap";
            this.Text = "FrmNhaCungCap";
            this.Load += new System.EventHandler(this.FrmNhaCungCap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDeleteVendor;
        private System.Windows.Forms.Button btnEditVendor;
        private System.Windows.Forms.Button btnAddVendor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveVendor;
        private System.Windows.Forms.TextBox txtSearchVendor;
        private System.Windows.Forms.Button btnCancelAV;
    }
}