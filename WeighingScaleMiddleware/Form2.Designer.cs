namespace WeighingScaleMiddleware
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            grpScale2 = new GroupBox();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            dgvHistori = new DataGridView();
            btnImport = new Button();
            btnExport = new Button();
            btnDeleteAll = new Button();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            txtSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cmbMutu = new ComboBox();
            txtAlamat = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            grpReceive = new GroupBox();
            txtPetugas = new TextBox();
            txtSlump = new TextBox();
            txtTotal = new TextBox();
            txtKeterangan = new TextBox();
            txtRitase = new TextBox();
            txtVolume = new TextBox();
            txtTransId = new TextBox();
            txtNoTruck = new TextBox();
            txtProyek = new TextBox();
            txtSupir = new TextBox();
            cmbPembeli = new ComboBox();
            label13 = new Label();
            label12 = new Label();
            btnSettingTimbangan = new Button();
            groupBox1 = new GroupBox();
            lblbatchingrun = new Label();
            btnSampling6 = new Button();
            btnSampling5 = new Button();
            txtCumulativeFlyash = new TextBox();
            txtCumulativeSemen = new TextBox();
            btnSampling4 = new Button();
            btnSampling3 = new Button();
            btnSampling2 = new Button();
            btnSampling1 = new Button();
            txtCumulativeBin4 = new TextBox();
            txtCumulativeBin3 = new TextBox();
            txtCumulativeBin2 = new TextBox();
            txtCumulativeBin1 = new TextBox();
            txtActualScale4 = new TextBox();
            label21 = new Label();
            label20 = new Label();
            label19 = new Label();
            txtActualScale3 = new TextBox();
            txtActualScale2 = new TextBox();
            label25 = new Label();
            txtTargetAditif = new TextBox();
            label26 = new Label();
            txtTargetAir = new TextBox();
            label24 = new Label();
            txtTargetFlyAsh = new TextBox();
            label23 = new Label();
            txtTargetSemen = new TextBox();
            label18 = new Label();
            txtActualScale1 = new TextBox();
            txtTargetBin4 = new TextBox();
            txtTargetBin3 = new TextBox();
            txtTargetBin2 = new TextBox();
            txtTargetBin1 = new TextBox();
            btnBatal = new Button();
            btnBatching = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox9 = new PictureBox();
            btnProduk = new Button();
            btnPembeli = new Button();
            btnLaporan = new Button();
            label17 = new Label();
            imageList1 = new ImageList(components);
            btnSettingFaktur = new Button();
            pictureBox1 = new PictureBox();
            grpScale2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistori).BeginInit();
            grpReceive.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // grpScale2
            // 
            grpScale2.Controls.Add(dtpEndDate);
            grpScale2.Controls.Add(dtpStartDate);
            grpScale2.Controls.Add(dgvHistori);
            grpScale2.Controls.Add(btnImport);
            grpScale2.Controls.Add(btnExport);
            grpScale2.Controls.Add(btnDeleteAll);
            grpScale2.Controls.Add(label16);
            grpScale2.Controls.Add(label15);
            grpScale2.Controls.Add(label14);
            grpScale2.Controls.Add(txtSearch);
            grpScale2.Location = new Point(12, 603);
            grpScale2.Name = "grpScale2";
            grpScale2.Size = new Size(1612, 418);
            grpScale2.TabIndex = 3;
            grpScale2.TabStop = false;
            grpScale2.Text = "Historical Recod";
            grpScale2.Enter += grpScale2_Enter;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(894, 27);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(122, 27);
            dtpEndDate.TabIndex = 45;
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(715, 27);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(122, 27);
            dtpStartDate.TabIndex = 44;
            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            // 
            // dgvHistori
            // 
            dgvHistori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistori.Location = new Point(6, 64);
            dgvHistori.Name = "dgvHistori";
            dgvHistori.RowHeadersWidth = 51;
            dgvHistori.Size = new Size(1576, 347);
            dgvHistori.TabIndex = 43;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(1423, 23);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(159, 33);
            btnImport.TabIndex = 42;
            btnImport.Text = "Import Data";
            btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(1258, 23);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(159, 33);
            btnExport.TabIndex = 41;
            btnExport.Text = "Export Exel";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Location = new Point(1093, 23);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(159, 33);
            btnDeleteAll.TabIndex = 40;
            btnDeleteAll.Text = "Hapus Semua Data";
            btnDeleteAll.UseVisualStyleBackColor = true;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = SystemColors.HighlightText;
            label16.Location = new Point(853, 29);
            label16.Name = "label16";
            label16.Size = new Size(30, 20);
            label16.TabIndex = 38;
            label16.Text = "s/d";
            label16.UseMnemonic = false;
            label16.Click += label16_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = SystemColors.HighlightText;
            label15.Location = new Point(640, 29);
            label15.Name = "label15";
            label15.Size = new Size(61, 20);
            label15.TabIndex = 37;
            label15.Text = "Tanggal";
            label15.UseMnemonic = false;
            label15.Click += label15_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = SystemColors.HighlightText;
            label14.Location = new Point(26, 29);
            label14.Name = "label14";
            label14.Size = new Size(71, 20);
            label14.TabIndex = 36;
            label14.Text = "Cari Data";
            label14.UseMnemonic = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(158, 26);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(431, 27);
            txtSearch.TabIndex = 36;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(22, 35);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 5;
            label1.Text = "Trans ID         :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.HighlightText;
            label2.Location = new Point(22, 68);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 7;
            label2.Text = "Supir              :";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.HighlightText;
            label3.Location = new Point(22, 101);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 9;
            label3.Text = "Pembeli         :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.HighlightText;
            label4.Location = new Point(22, 167);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 11;
            label4.Text = "No. Truck       :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.HighlightText;
            label5.Location = new Point(22, 134);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 13;
            label5.Text = "Proyek           :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.HighlightText;
            label6.Location = new Point(22, 200);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 15;
            label6.Text = "Mutu              :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.HighlightText;
            label7.Location = new Point(22, 233);
            label7.Name = "label7";
            label7.Size = new Size(104, 20);
            label7.TabIndex = 17;
            label7.Text = "Alamat           :";
            // 
            // cmbMutu
            // 
            cmbMutu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMutu.FormattingEnabled = true;
            cmbMutu.Location = new Point(142, 197);
            cmbMutu.Name = "cmbMutu";
            cmbMutu.Size = new Size(166, 28);
            cmbMutu.TabIndex = 18;
            cmbMutu.SelectedIndexChanged += cmbMutu_SelectedIndexChanged;
            // 
            // txtAlamat
            // 
            txtAlamat.Location = new Point(142, 233);
            txtAlamat.Multiline = true;
            txtAlamat.Name = "txtAlamat";
            txtAlamat.Size = new Size(266, 76);
            txtAlamat.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.HighlightText;
            label8.Location = new Point(22, 318);
            label8.Name = "label8";
            label8.Size = new Size(102, 20);
            label8.TabIndex = 21;
            label8.Text = "Volume          :";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.HighlightText;
            label9.Location = new Point(22, 351);
            label9.Name = "label9";
            label9.Size = new Size(104, 20);
            label9.TabIndex = 23;
            label9.Text = "Keterangan    :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = SystemColors.HighlightText;
            label10.Location = new Point(22, 384);
            label10.Name = "label10";
            label10.Size = new Size(113, 20);
            label10.TabIndex = 25;
            label10.Text = "Total               :  ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = SystemColors.HighlightText;
            label11.Location = new Point(21, 417);
            label11.Name = "label11";
            label11.Size = new Size(106, 20);
            label11.TabIndex = 27;
            label11.Text = "Slump             :";
            label11.UseMnemonic = false;
            // 
            // grpReceive
            // 
            grpReceive.Controls.Add(txtPetugas);
            grpReceive.Controls.Add(txtSlump);
            grpReceive.Controls.Add(txtTotal);
            grpReceive.Controls.Add(txtKeterangan);
            grpReceive.Controls.Add(txtRitase);
            grpReceive.Controls.Add(txtVolume);
            grpReceive.Controls.Add(txtTransId);
            grpReceive.Controls.Add(txtNoTruck);
            grpReceive.Controls.Add(txtProyek);
            grpReceive.Controls.Add(txtSupir);
            grpReceive.Controls.Add(cmbPembeli);
            grpReceive.Controls.Add(label13);
            grpReceive.Controls.Add(label12);
            grpReceive.Controls.Add(label11);
            grpReceive.Controls.Add(label1);
            grpReceive.Controls.Add(label10);
            grpReceive.Controls.Add(label2);
            grpReceive.Controls.Add(label9);
            grpReceive.Controls.Add(label3);
            grpReceive.Controls.Add(label8);
            grpReceive.Controls.Add(label4);
            grpReceive.Controls.Add(txtAlamat);
            grpReceive.Controls.Add(label5);
            grpReceive.Controls.Add(cmbMutu);
            grpReceive.Controls.Add(label6);
            grpReceive.Controls.Add(label7);
            grpReceive.Location = new Point(1186, 128);
            grpReceive.Name = "grpReceive";
            grpReceive.Size = new Size(438, 469);
            grpReceive.TabIndex = 28;
            grpReceive.TabStop = false;
            grpReceive.Text = "Informasi Data";
            grpReceive.Enter += grpReceive_Enter;
            // 
            // txtPetugas
            // 
            txtPetugas.Location = new Point(323, 380);
            txtPetugas.Multiline = true;
            txtPetugas.Name = "txtPetugas";
            txtPetugas.Size = new Size(86, 28);
            txtPetugas.TabIndex = 42;
            // 
            // txtSlump
            // 
            txtSlump.Location = new Point(142, 414);
            txtSlump.Multiline = true;
            txtSlump.Name = "txtSlump";
            txtSlump.Size = new Size(86, 28);
            txtSlump.TabIndex = 41;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(142, 381);
            txtTotal.Multiline = true;
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(86, 28);
            txtTotal.TabIndex = 40;
            // 
            // txtKeterangan
            // 
            txtKeterangan.Location = new Point(142, 347);
            txtKeterangan.Multiline = true;
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.Size = new Size(267, 28);
            txtKeterangan.TabIndex = 39;
            // 
            // txtRitase
            // 
            txtRitase.Location = new Point(323, 314);
            txtRitase.Multiline = true;
            txtRitase.Name = "txtRitase";
            txtRitase.Size = new Size(86, 28);
            txtRitase.TabIndex = 38;
            // 
            // txtVolume
            // 
            txtVolume.Location = new Point(142, 314);
            txtVolume.Multiline = true;
            txtVolume.Name = "txtVolume";
            txtVolume.Size = new Size(86, 28);
            txtVolume.TabIndex = 37;
            txtVolume.TextChanged += txtVolume_TextChanged_1;
            // 
            // txtTransId
            // 
            txtTransId.Location = new Point(142, 32);
            txtTransId.Multiline = true;
            txtTransId.Name = "txtTransId";
            txtTransId.Size = new Size(166, 28);
            txtTransId.TabIndex = 36;
            // 
            // txtNoTruck
            // 
            txtNoTruck.Location = new Point(142, 163);
            txtNoTruck.Multiline = true;
            txtNoTruck.Name = "txtNoTruck";
            txtNoTruck.Size = new Size(166, 28);
            txtNoTruck.TabIndex = 35;
            // 
            // txtProyek
            // 
            txtProyek.Location = new Point(142, 130);
            txtProyek.Multiline = true;
            txtProyek.Name = "txtProyek";
            txtProyek.Size = new Size(166, 28);
            txtProyek.TabIndex = 34;
            txtProyek.TextChanged += textBox1_TextChanged;
            // 
            // txtSupir
            // 
            txtSupir.Location = new Point(142, 64);
            txtSupir.Multiline = true;
            txtSupir.Name = "txtSupir";
            txtSupir.Size = new Size(166, 28);
            txtSupir.TabIndex = 33;
            // 
            // cmbPembeli
            // 
            cmbPembeli.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPembeli.FormattingEnabled = true;
            cmbPembeli.Location = new Point(142, 97);
            cmbPembeli.Name = "cmbPembeli";
            cmbPembeli.Size = new Size(166, 28);
            cmbPembeli.TabIndex = 32;
            cmbPembeli.SelectedIndexChanged += cmbPembeli_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = SystemColors.HighlightText;
            label13.Location = new Point(250, 380);
            label13.Name = "label13";
            label13.Size = new Size(71, 20);
            label13.TabIndex = 31;
            label13.Text = "Petugas : ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = SystemColors.HighlightText;
            label12.Location = new Point(249, 318);
            label12.Name = "label12";
            label12.Size = new Size(60, 20);
            label12.TabIndex = 29;
            label12.Text = "Ritase  :";
            // 
            // btnSettingTimbangan
            // 
            btnSettingTimbangan.Location = new Point(1465, 26);
            btnSettingTimbangan.Name = "btnSettingTimbangan";
            btnSettingTimbangan.Size = new Size(159, 44);
            btnSettingTimbangan.TabIndex = 43;
            btnSettingTimbangan.Text = "Setting Timbangan";
            btnSettingTimbangan.UseVisualStyleBackColor = true;
            btnSettingTimbangan.Click += btnSettingTimbangan_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblbatchingrun);
            groupBox1.Controls.Add(btnSampling6);
            groupBox1.Controls.Add(btnSampling5);
            groupBox1.Controls.Add(txtCumulativeFlyash);
            groupBox1.Controls.Add(txtCumulativeSemen);
            groupBox1.Controls.Add(btnSampling4);
            groupBox1.Controls.Add(btnSampling3);
            groupBox1.Controls.Add(btnSampling2);
            groupBox1.Controls.Add(btnSampling1);
            groupBox1.Controls.Add(txtCumulativeBin4);
            groupBox1.Controls.Add(txtCumulativeBin3);
            groupBox1.Controls.Add(txtCumulativeBin2);
            groupBox1.Controls.Add(txtCumulativeBin1);
            groupBox1.Controls.Add(txtActualScale4);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(txtActualScale3);
            groupBox1.Controls.Add(txtActualScale2);
            groupBox1.Controls.Add(label25);
            groupBox1.Controls.Add(txtTargetAditif);
            groupBox1.Controls.Add(label26);
            groupBox1.Controls.Add(txtTargetAir);
            groupBox1.Controls.Add(label24);
            groupBox1.Controls.Add(txtTargetFlyAsh);
            groupBox1.Controls.Add(label23);
            groupBox1.Controls.Add(txtTargetSemen);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(txtActualScale1);
            groupBox1.Controls.Add(txtTargetBin4);
            groupBox1.Controls.Add(txtTargetBin3);
            groupBox1.Controls.Add(txtTargetBin2);
            groupBox1.Controls.Add(txtTargetBin1);
            groupBox1.Controls.Add(btnBatal);
            groupBox1.Controls.Add(btnBatching);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(pictureBox3);
            groupBox1.Controls.Add(pictureBox4);
            groupBox1.Controls.Add(pictureBox5);
            groupBox1.Controls.Add(pictureBox6);
            groupBox1.Controls.Add(pictureBox7);
            groupBox1.Controls.Add(pictureBox8);
            groupBox1.Controls.Add(pictureBox9);
            groupBox1.Location = new Point(12, 128);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1157, 469);
            groupBox1.TabIndex = 44;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lblbatchingrun
            // 
            lblbatchingrun.AutoSize = true;
            lblbatchingrun.Font = new Font("Arial", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblbatchingrun.ForeColor = Color.Lime;
            lblbatchingrun.Location = new Point(751, 414);
            lblbatchingrun.Name = "lblbatchingrun";
            lblbatchingrun.Size = new Size(284, 39);
            lblbatchingrun.TabIndex = 97;
            lblbatchingrun.Text = "BATCH RUN .....!";
            lblbatchingrun.Click += label22_Click_1;
            // 
            // btnSampling6
            // 
            btnSampling6.BackColor = Color.BlanchedAlmond;
            btnSampling6.Location = new Point(780, 255);
            btnSampling6.Name = "btnSampling6";
            btnSampling6.Size = new Size(90, 28);
            btnSampling6.TabIndex = 89;
            btnSampling6.Text = "SB6";
            btnSampling6.UseVisualStyleBackColor = false;
            btnSampling6.Click += btnSampling6_Click;
            // 
            // btnSampling5
            // 
            btnSampling5.BackColor = Color.BlanchedAlmond;
            btnSampling5.Location = new Point(658, 255);
            btnSampling5.Name = "btnSampling5";
            btnSampling5.Size = new Size(90, 28);
            btnSampling5.TabIndex = 88;
            btnSampling5.Text = "SB5";
            btnSampling5.UseVisualStyleBackColor = false;
            btnSampling5.Click += btnSampling5_Click;
            // 
            // txtCumulativeFlyash
            // 
            txtCumulativeFlyash.BackColor = Color.Aqua;
            txtCumulativeFlyash.Location = new Point(780, 134);
            txtCumulativeFlyash.Multiline = true;
            txtCumulativeFlyash.Name = "txtCumulativeFlyash";
            txtCumulativeFlyash.Size = new Size(90, 28);
            txtCumulativeFlyash.TabIndex = 87;
            txtCumulativeFlyash.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCumulativeSemen
            // 
            txtCumulativeSemen.BackColor = Color.Aqua;
            txtCumulativeSemen.Location = new Point(658, 134);
            txtCumulativeSemen.Multiline = true;
            txtCumulativeSemen.Name = "txtCumulativeSemen";
            txtCumulativeSemen.Size = new Size(90, 28);
            txtCumulativeSemen.TabIndex = 86;
            txtCumulativeSemen.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSampling4
            // 
            btnSampling4.BackColor = Color.BlanchedAlmond;
            btnSampling4.Location = new Point(440, 255);
            btnSampling4.Name = "btnSampling4";
            btnSampling4.Size = new Size(90, 28);
            btnSampling4.TabIndex = 85;
            btnSampling4.Text = "SB4";
            btnSampling4.UseVisualStyleBackColor = false;
            btnSampling4.Click += btnSampling4_Click;
            // 
            // btnSampling3
            // 
            btnSampling3.BackColor = Color.BlanchedAlmond;
            btnSampling3.Location = new Point(312, 255);
            btnSampling3.Name = "btnSampling3";
            btnSampling3.Size = new Size(90, 28);
            btnSampling3.TabIndex = 84;
            btnSampling3.Text = "SB3";
            btnSampling3.UseVisualStyleBackColor = false;
            btnSampling3.Click += btnSampling3_Click;
            // 
            // btnSampling2
            // 
            btnSampling2.BackColor = Color.BlanchedAlmond;
            btnSampling2.Location = new Point(184, 255);
            btnSampling2.Name = "btnSampling2";
            btnSampling2.Size = new Size(90, 28);
            btnSampling2.TabIndex = 83;
            btnSampling2.Text = "SB2";
            btnSampling2.UseVisualStyleBackColor = false;
            btnSampling2.Click += btnSampling2_Click;
            // 
            // btnSampling1
            // 
            btnSampling1.BackColor = Color.BlanchedAlmond;
            btnSampling1.Location = new Point(54, 255);
            btnSampling1.Name = "btnSampling1";
            btnSampling1.Size = new Size(90, 28);
            btnSampling1.TabIndex = 82;
            btnSampling1.Text = "SB1";
            btnSampling1.UseVisualStyleBackColor = false;
            btnSampling1.Click += btnSampling1_Click;
            // 
            // txtCumulativeBin4
            // 
            txtCumulativeBin4.BackColor = Color.Aqua;
            txtCumulativeBin4.Location = new Point(440, 134);
            txtCumulativeBin4.Multiline = true;
            txtCumulativeBin4.Name = "txtCumulativeBin4";
            txtCumulativeBin4.Size = new Size(90, 28);
            txtCumulativeBin4.TabIndex = 81;
            txtCumulativeBin4.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCumulativeBin3
            // 
            txtCumulativeBin3.BackColor = Color.Aqua;
            txtCumulativeBin3.Location = new Point(312, 134);
            txtCumulativeBin3.Multiline = true;
            txtCumulativeBin3.Name = "txtCumulativeBin3";
            txtCumulativeBin3.Size = new Size(90, 28);
            txtCumulativeBin3.TabIndex = 80;
            txtCumulativeBin3.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCumulativeBin2
            // 
            txtCumulativeBin2.BackColor = Color.Aqua;
            txtCumulativeBin2.Location = new Point(184, 134);
            txtCumulativeBin2.Multiline = true;
            txtCumulativeBin2.Name = "txtCumulativeBin2";
            txtCumulativeBin2.Size = new Size(90, 28);
            txtCumulativeBin2.TabIndex = 79;
            txtCumulativeBin2.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCumulativeBin1
            // 
            txtCumulativeBin1.BackColor = Color.Aqua;
            txtCumulativeBin1.Location = new Point(54, 134);
            txtCumulativeBin1.Multiline = true;
            txtCumulativeBin1.Name = "txtCumulativeBin1";
            txtCumulativeBin1.Size = new Size(90, 28);
            txtCumulativeBin1.TabIndex = 78;
            txtCumulativeBin1.TextAlign = HorizontalAlignment.Center;
            // 
            // txtActualScale4
            // 
            txtActualScale4.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtActualScale4.Location = new Point(1022, 282);
            txtActualScale4.Multiline = true;
            txtActualScale4.Name = "txtActualScale4";
            txtActualScale4.Size = new Size(121, 40);
            txtActualScale4.TabIndex = 77;
            txtActualScale4.TextAlign = HorizontalAlignment.Center;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = SystemColors.HighlightText;
            label21.Location = new Point(455, 39);
            label21.Name = "label21";
            label21.Size = new Size(60, 23);
            label21.TabIndex = 76;
            label21.Text = "BIN-4";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.ForeColor = SystemColors.HighlightText;
            label20.Location = new Point(327, 39);
            label20.Name = "label20";
            label20.Size = new Size(60, 23);
            label20.TabIndex = 75;
            label20.Text = "BIN-3";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.HighlightText;
            label19.Location = new Point(199, 39);
            label19.Name = "label19";
            label19.Size = new Size(60, 23);
            label19.TabIndex = 74;
            label19.Text = "BIN-2";
            // 
            // txtActualScale3
            // 
            txtActualScale3.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtActualScale3.Location = new Point(895, 282);
            txtActualScale3.Multiline = true;
            txtActualScale3.Name = "txtActualScale3";
            txtActualScale3.Size = new Size(121, 40);
            txtActualScale3.TabIndex = 73;
            txtActualScale3.TextAlign = HorizontalAlignment.Center;
            txtActualScale3.TextChanged += textBox19_TextChanged;
            // 
            // txtActualScale2
            // 
            txtActualScale2.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtActualScale2.Location = new Point(645, 333);
            txtActualScale2.Multiline = true;
            txtActualScale2.Name = "txtActualScale2";
            txtActualScale2.Size = new Size(244, 54);
            txtActualScale2.TabIndex = 72;
            txtActualScale2.TextAlign = HorizontalAlignment.Center;
            txtActualScale2.TextChanged += txtActualScale2_TextChanged;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label25.ForeColor = SystemColors.HighlightText;
            label25.Location = new Point(1047, 39);
            label25.Name = "label25";
            label25.Size = new Size(73, 23);
            label25.TabIndex = 71;
            label25.Text = "ADITIF";
            // 
            // txtTargetAditif
            // 
            txtTargetAditif.BackColor = SystemColors.MenuHighlight;
            txtTargetAditif.Location = new Point(1038, 93);
            txtTargetAditif.Multiline = true;
            txtTargetAditif.Name = "txtTargetAditif";
            txtTargetAditif.Size = new Size(90, 28);
            txtTargetAditif.TabIndex = 70;
            txtTargetAditif.TextAlign = HorizontalAlignment.Center;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label26.ForeColor = SystemColors.HighlightText;
            label26.Location = new Point(938, 39);
            label26.Name = "label26";
            label26.Size = new Size(43, 23);
            label26.TabIndex = 69;
            label26.Text = "AIR";
            // 
            // txtTargetAir
            // 
            txtTargetAir.BackColor = SystemColors.MenuHighlight;
            txtTargetAir.Location = new Point(910, 93);
            txtTargetAir.Multiline = true;
            txtTargetAir.Name = "txtTargetAir";
            txtTargetAir.Size = new Size(90, 28);
            txtTargetAir.TabIndex = 68;
            txtTargetAir.TextAlign = HorizontalAlignment.Center;
            txtTargetAir.TextChanged += txtTargetAir_TextChanged;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label24.ForeColor = SystemColors.HighlightText;
            label24.Location = new Point(780, 39);
            label24.Name = "label24";
            label24.Size = new Size(90, 23);
            label24.TabIndex = 67;
            label24.Text = "FLY-ASH";
            // 
            // txtTargetFlyAsh
            // 
            txtTargetFlyAsh.BackColor = SystemColors.MenuHighlight;
            txtTargetFlyAsh.Location = new Point(780, 93);
            txtTargetFlyAsh.Multiline = true;
            txtTargetFlyAsh.Name = "txtTargetFlyAsh";
            txtTargetFlyAsh.Size = new Size(90, 28);
            txtTargetFlyAsh.TabIndex = 66;
            txtTargetFlyAsh.TextAlign = HorizontalAlignment.Center;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label23.ForeColor = SystemColors.HighlightText;
            label23.Location = new Point(664, 39);
            label23.Name = "label23";
            label23.Size = new Size(79, 23);
            label23.TabIndex = 65;
            label23.Text = "SEMEN";
            // 
            // txtTargetSemen
            // 
            txtTargetSemen.BackColor = SystemColors.MenuHighlight;
            txtTargetSemen.Location = new Point(658, 93);
            txtTargetSemen.Multiline = true;
            txtTargetSemen.Name = "txtTargetSemen";
            txtTargetSemen.Size = new Size(90, 28);
            txtTargetSemen.TabIndex = 64;
            txtTargetSemen.TextAlign = HorizontalAlignment.Center;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = SystemColors.HighlightText;
            label18.Location = new Point(69, 39);
            label18.Name = "label18";
            label18.Size = new Size(60, 23);
            label18.TabIndex = 53;
            label18.Text = "BIN-1";
            // 
            // txtActualScale1
            // 
            txtActualScale1.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtActualScale1.Location = new Point(40, 333);
            txtActualScale1.Multiline = true;
            txtActualScale1.Name = "txtActualScale1";
            txtActualScale1.Size = new Size(506, 54);
            txtActualScale1.TabIndex = 59;
            txtActualScale1.TextAlign = HorizontalAlignment.Center;
            txtActualScale1.TextChanged += textBox17_TextChanged;
            // 
            // txtTargetBin4
            // 
            txtTargetBin4.BackColor = SystemColors.MenuHighlight;
            txtTargetBin4.Location = new Point(440, 93);
            txtTargetBin4.Multiline = true;
            txtTargetBin4.Name = "txtTargetBin4";
            txtTargetBin4.Size = new Size(90, 28);
            txtTargetBin4.TabIndex = 54;
            txtTargetBin4.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTargetBin3
            // 
            txtTargetBin3.BackColor = SystemColors.MenuHighlight;
            txtTargetBin3.Location = new Point(312, 93);
            txtTargetBin3.Multiline = true;
            txtTargetBin3.Name = "txtTargetBin3";
            txtTargetBin3.Size = new Size(90, 28);
            txtTargetBin3.TabIndex = 53;
            txtTargetBin3.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTargetBin2
            // 
            txtTargetBin2.BackColor = SystemColors.MenuHighlight;
            txtTargetBin2.Location = new Point(184, 93);
            txtTargetBin2.Multiline = true;
            txtTargetBin2.Name = "txtTargetBin2";
            txtTargetBin2.Size = new Size(90, 28);
            txtTargetBin2.TabIndex = 52;
            txtTargetBin2.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTargetBin1
            // 
            txtTargetBin1.BackColor = SystemColors.MenuHighlight;
            txtTargetBin1.Location = new Point(54, 93);
            txtTargetBin1.Multiline = true;
            txtTargetBin1.Name = "txtTargetBin1";
            txtTargetBin1.Size = new Size(90, 28);
            txtTargetBin1.TabIndex = 43;
            txtTargetBin1.TextAlign = HorizontalAlignment.Center;
            txtTargetBin1.TextChanged += txtTargetBin1_TextChanged;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.LightCoral;
            btnBatal.Location = new Point(184, 414);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(159, 44);
            btnBatal.TabIndex = 51;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // btnBatching
            // 
            btnBatching.BackColor = Color.YellowGreen;
            btnBatching.Location = new Point(19, 414);
            btnBatching.Name = "btnBatching";
            btnBatching.Size = new Size(159, 44);
            btnBatching.TabIndex = 50;
            btnBatching.Text = "F4 : Simpan";
            btnBatching.UseVisualStyleBackColor = false;
            btnBatching.Click += btnBatching_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.ErrorImage = null;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(645, 68);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(121, 319);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 53;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.ErrorImage = null;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.InitialImage = null;
            pictureBox3.Location = new Point(766, 68);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(121, 320);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 90;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.ErrorImage = null;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.InitialImage = null;
            pictureBox4.Location = new Point(40, 65);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(121, 323);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 91;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.ErrorImage = null;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.InitialImage = null;
            pictureBox5.Location = new Point(171, 65);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(121, 323);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 92;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.ErrorImage = null;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.InitialImage = null;
            pictureBox6.Location = new Point(298, 65);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(121, 323);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 93;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.ErrorImage = null;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.InitialImage = null;
            pictureBox7.Location = new Point(425, 65);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(121, 323);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 94;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.ErrorImage = null;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.InitialImage = null;
            pictureBox8.Location = new Point(895, 18);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(121, 370);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 95;
            pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.ErrorImage = null;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.InitialImage = null;
            pictureBox9.Location = new Point(1022, 18);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(121, 370);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 96;
            pictureBox9.TabStop = false;
            // 
            // btnProduk
            // 
            btnProduk.Location = new Point(845, 76);
            btnProduk.Name = "btnProduk";
            btnProduk.Size = new Size(159, 44);
            btnProduk.TabIndex = 45;
            btnProduk.Text = "Produk";
            btnProduk.UseVisualStyleBackColor = true;
            btnProduk.Click += btnProduk_Click_1;
            // 
            // btnPembeli
            // 
            btnPembeli.Location = new Point(845, 24);
            btnPembeli.Name = "btnPembeli";
            btnPembeli.Size = new Size(159, 44);
            btnPembeli.TabIndex = 46;
            btnPembeli.Text = "Pembeli";
            btnPembeli.UseVisualStyleBackColor = true;
            btnPembeli.Click += btnPembeli_Click_1;
            // 
            // btnLaporan
            // 
            btnLaporan.Location = new Point(1010, 76);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(159, 44);
            btnLaporan.TabIndex = 47;
            btnLaporan.Text = "Laporan";
            btnLaporan.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial Narrow", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = SystemColors.HighlightText;
            label17.Location = new Point(162, 37);
            label17.Name = "label17";
            label17.Size = new Size(524, 55);
            label17.TabIndex = 49;
            label17.Text = "PT. ARTHA MULIA BETON ";
            label17.Click += label17_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "images-removebg-preview.png");
            // 
            // btnSettingFaktur
            // 
            btnSettingFaktur.Location = new Point(1010, 24);
            btnSettingFaktur.Name = "btnSettingFaktur";
            btnSettingFaktur.Size = new Size(159, 44);
            btnSettingFaktur.TabIndex = 50;
            btnSettingFaktur.Text = "Setting Faktur";
            btnSettingFaktur.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(144, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 52;
            pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1662, 1033);
            Controls.Add(pictureBox1);
            Controls.Add(btnSettingFaktur);
            Controls.Add(label17);
            Controls.Add(btnLaporan);
            Controls.Add(btnPembeli);
            Controls.Add(btnProduk);
            Controls.Add(groupBox1);
            Controls.Add(btnSettingTimbangan);
            Controls.Add(grpReceive);
            Controls.Add(grpScale2);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            grpScale2.ResumeLayout(false);
            grpScale2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistori).EndInit();
            grpReceive.ResumeLayout(false);
            grpReceive.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpScale2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cmbMutu;
        private TextBox txtAlamat;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private GroupBox grpReceive;
        private Label label12;
        private Label label13;
        private Label label15;
        private Label label14;
        private TextBox txtSearch;
        private ComboBox cmbPembeli;
        private Label label16;
        private Button btnImport;
        private Button btnExport;
        private Button btnDeleteAll;
        private Button btnSettingTimbangan;
        private GroupBox groupBox1;
        private Button btnBatching;
        private Button btnProduk;
        private Button btnPembeli;
        private Button btnLaporan;
        private Button btnBatal;
        private Label label17;
        private ImageList imageList1;
        private Button btnSettingFaktur;
        private PictureBox pictureBox1;
        private TextBox txtTargetBin4;
        private TextBox txtTargetBin3;
        private TextBox txtTargetBin2;
        private TextBox txtTargetBin1;
        private TextBox txtActualScale1;
        private Label label18;
        private Label label23;
        private TextBox txtTargetSemen;
        private Label label25;
        private TextBox txtTargetAditif;
        private Label label26;
        private TextBox txtTargetAir;
        private Label label24;
        private TextBox txtTargetFlyAsh;
        private Label label21;
        private Label label20;
        private Label label19;
        private TextBox txtActualScale3;
        private TextBox txtActualScale2;
        private TextBox txtActualScale4;
        private TextBox txtCumulativeBin4;
        private TextBox txtCumulativeBin3;
        private TextBox txtCumulativeBin2;
        private TextBox txtCumulativeBin1;
        private TextBox txtNoTruck;
        private TextBox txtProyek;
        private TextBox txtSupir;
        private TextBox txtPetugas;
        private TextBox txtSlump;
        private TextBox txtTotal;
        private TextBox txtKeterangan;
        private TextBox txtRitase;
        private TextBox txtVolume;
        private TextBox txtTransId;
        private DataGridView dgvHistori;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Button btnSampling4;
        private Button btnSampling3;
        private Button btnSampling2;
        private Button btnSampling1;
        private Button btnSampling6;
        private Button btnSampling5;
        private TextBox txtCumulativeFlyash;
        private TextBox txtCumulativeSemen;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private Label lblbatchingrun;
    }
}