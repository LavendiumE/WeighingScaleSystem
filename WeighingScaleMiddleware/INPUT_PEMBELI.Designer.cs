namespace WeighingScaleMiddleware
{
    partial class INPUT_PEMBELI
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
            grpScale2 = new GroupBox();
            dgvPembeli = new DataGridView();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            groupBox1 = new GroupBox();
            button4 = new Button();
            btnTambahPembeli = new Button();
            button5 = new Button();
            label1 = new Label();
            button6 = new Button();
            txtAlamat = new TextBox();
            label14 = new Label();
            txtPembeli = new TextBox();
            groupBox2 = new GroupBox();
            btnHapusPembeli = new Button();
            button7 = new Button();
            button9 = new Button();
            button11 = new Button();
            label3 = new Label();
            txtHapusPembeli = new TextBox();
            grpScale2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPembeli).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grpScale2
            // 
            grpScale2.Controls.Add(dgvPembeli);
            grpScale2.Controls.Add(button3);
            grpScale2.Controls.Add(button2);
            grpScale2.Controls.Add(button1);
            grpScale2.Location = new Point(12, 183);
            grpScale2.Name = "grpScale2";
            grpScale2.Size = new Size(1293, 374);
            grpScale2.TabIndex = 5;
            grpScale2.TabStop = false;
            grpScale2.Text = "Tabel Pembeli";
            // 
            // dgvPembeli
            // 
            dgvPembeli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPembeli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPembeli.Location = new Point(6, 26);
            dgvPembeli.Name = "dgvPembeli";
            dgvPembeli.RowHeadersWidth = 51;
            dgvPembeli.Size = new Size(1281, 342);
            dgvPembeli.TabIndex = 43;
            // 
            // button3
            // 
            button3.Location = new Point(1705, 26);
            button3.Name = "button3";
            button3.Size = new Size(159, 33);
            button3.TabIndex = 42;
            button3.Text = "Import Data";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1540, 26);
            button2.Name = "button2";
            button2.Size = new Size(159, 33);
            button2.TabIndex = 41;
            button2.Text = "Export Exel";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(1375, 26);
            button1.Name = "button1";
            button1.Size = new Size(159, 33);
            button1.TabIndex = 40;
            button1.Text = "Hapus Semua Data";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(btnTambahPembeli);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(txtAlamat);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(txtPembeli);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(580, 165);
            groupBox1.TabIndex = 43;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tambah Pembeli";
            // 
            // button4
            // 
            button4.Location = new Point(1705, 26);
            button4.Name = "button4";
            button4.Size = new Size(159, 33);
            button4.TabIndex = 42;
            button4.Text = "Import Data";
            button4.UseVisualStyleBackColor = true;
            // 
            // btnTambahPembeli
            // 
            btnTambahPembeli.BackColor = Color.YellowGreen;
            btnTambahPembeli.Location = new Point(438, 25);
            btnTambahPembeli.Name = "btnTambahPembeli";
            btnTambahPembeli.Size = new Size(125, 113);
            btnTambahPembeli.TabIndex = 54;
            btnTambahPembeli.Text = "TAMBAH";
            btnTambahPembeli.UseVisualStyleBackColor = false;
            btnTambahPembeli.Click += btnTambahPembeli_Click;
            // 
            // button5
            // 
            button5.Location = new Point(1540, 26);
            button5.Name = "button5";
            button5.Size = new Size(159, 33);
            button5.TabIndex = 41;
            button5.Text = "Export Exel";
            button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(14, 71);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 45;
            label1.Text = "ALAMAT";
            label1.UseMnemonic = false;
            label1.Click += label1_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1375, 26);
            button6.Name = "button6";
            button6.Size = new Size(159, 33);
            button6.TabIndex = 40;
            button6.Text = "Hapus Semua Data";
            button6.UseVisualStyleBackColor = true;
            // 
            // txtAlamat
            // 
            txtAlamat.Location = new Point(134, 68);
            txtAlamat.Multiline = true;
            txtAlamat.Name = "txtAlamat";
            txtAlamat.Size = new Size(263, 70);
            txtAlamat.TabIndex = 46;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = SystemColors.HighlightText;
            label14.Location = new Point(14, 28);
            label14.Name = "label14";
            label14.Size = new Size(66, 20);
            label14.TabIndex = 43;
            label14.Text = "PEMBELI";
            label14.UseMnemonic = false;
            label14.Click += label14_Click;
            // 
            // txtPembeli
            // 
            txtPembeli.Location = new Point(134, 25);
            txtPembeli.Multiline = true;
            txtPembeli.Name = "txtPembeli";
            txtPembeli.Size = new Size(263, 27);
            txtPembeli.TabIndex = 44;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnHapusPembeli);
            groupBox2.Controls.Add(button7);
            groupBox2.Controls.Add(button9);
            groupBox2.Controls.Add(button11);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtHapusPembeli);
            groupBox2.Location = new Point(610, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(417, 165);
            groupBox2.TabIndex = 55;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hapus Pembeli";
            // 
            // btnHapusPembeli
            // 
            btnHapusPembeli.BackColor = Color.LightPink;
            btnHapusPembeli.Location = new Point(14, 104);
            btnHapusPembeli.Name = "btnHapusPembeli";
            btnHapusPembeli.Size = new Size(383, 34);
            btnHapusPembeli.TabIndex = 57;
            btnHapusPembeli.Text = "HAPUS";
            btnHapusPembeli.UseVisualStyleBackColor = false;
            btnHapusPembeli.Click += btnHapusPembeli_Click;
            // 
            // button7
            // 
            button7.Location = new Point(1705, 26);
            button7.Name = "button7";
            button7.Size = new Size(159, 33);
            button7.TabIndex = 42;
            button7.Text = "Import Data";
            button7.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(1540, 26);
            button9.Name = "button9";
            button9.Size = new Size(159, 33);
            button9.TabIndex = 41;
            button9.Text = "Export Exel";
            button9.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(1375, 26);
            button11.Name = "button11";
            button11.Size = new Size(159, 33);
            button11.TabIndex = 40;
            button11.Text = "Hapus Semua Data";
            button11.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.HighlightText;
            label3.Location = new Point(14, 42);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 43;
            label3.Text = "PEMBELI";
            label3.UseMnemonic = false;
            // 
            // txtHapusPembeli
            // 
            txtHapusPembeli.Location = new Point(134, 39);
            txtHapusPembeli.Multiline = true;
            txtHapusPembeli.Name = "txtHapusPembeli";
            txtHapusPembeli.Size = new Size(263, 27);
            txtHapusPembeli.TabIndex = 44;
            // 
            // INPUT_PEMBELI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(1317, 573);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(grpScale2);
            Name = "INPUT_PEMBELI";
            Text = "INPUT_PEMBELI";
            grpScale2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPembeli).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpScale2;
        private Button button3;
        private Button button2;
        private Button button1;
        private GroupBox groupBox1;
        private Button button4;
        private Button btnTambahPembeli;
        private Button button5;
        private Label label1;
        private Button button6;
        private TextBox txtAlamat;
        private Label label14;
        private TextBox txtPembeli;
        private GroupBox groupBox2;
        private Button button7;
        private Button button9;
        private Button button11;
        private Label label3;
        private TextBox txtHapusPembeli;
        private Button btnHapusPembeli;
        private DataGridView dgvPembeli;
    }
}