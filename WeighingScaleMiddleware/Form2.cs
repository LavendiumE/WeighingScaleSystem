using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeighingScaleMiddleware.Helpers;
using WeighingScaleMiddleware.Models;
using WeighingScaleMiddleware.Services;
using ClosedXML.Excel;

namespace WeighingScaleMiddleware
{
    public partial class Form2 : Form
    {
        private readonly RecipeService _recipeService = AppServices.Recipe;
        private readonly BuyerService _buyerService = AppServices.Buyer;
        private readonly BatchingService _batchingService = new BatchingService();
        private readonly List<Scale> _scales = new();
        private readonly TransactionService _transactionService = AppServices.Transaction;
        private bool isBatching = false;
        private decimal _rw1 = 0;
        private decimal _rw2 = 0;
        private decimal _rw3 = 0;
        private decimal _rw4 = 0;
        private decimal _samplingBin1 = 0;
        private decimal _samplingBin2 = 0;
        private decimal _samplingBin3 = 0;
        private decimal _samplingBin4 = 0;
        private decimal _samplingSemen;
        private decimal _samplingFlyAsh;
        private MainForm? _scaleSettingsForm;
        private System.Windows.Forms.Timer _batchingBlinkTimer;
        private bool _batchingBlinkState = false;


        public Form2()
        {
            InitializeComponent();

            InitializeScales();

            LoadBuyerData();

            LoadRecipeData();

            LoadTransactionHistory();

            GenerateNewTransactionId();

            _batchingBlinkTimer = new System.Windows.Forms.Timer();
            _batchingBlinkTimer.Interval = 500;
            _batchingBlinkTimer.Tick += BatchingBlinkTimer_Tick;


            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;

            LoadTransactionHistory();

            lblbatchingrun.Visible = false;


        }

        private void InitializeScales()
        {
            for (int i = 1; i <= 4; i++)
            {
                Scale scale = new Scale();

                scale.Id = i;

                scale.SerialService.DataReceived += SerialService_DataReceived;

                _scales.Add(scale);
            }
        }

        private void LoadBuyerData()
        {
            cmbPembeli.Items.Clear();

            foreach (var buyer in _buyerService.GetAll())
            {
                cmbPembeli.Items.Add(buyer.Name);
            }
        }

        private void LoadRecipeData()
        {
            cmbMutu.Items.Clear();

            foreach (var recipe in _recipeService.GetAll())
            {
                cmbMutu.Items.Add(recipe.Mutu);
            }
        }

        private void cmbPembeli_SelectedIndexChanged(
        object sender,
        EventArgs e)
        {
            if (cmbPembeli.SelectedItem == null)
            {
                txtAlamat.Clear();
                return;
            }

            string namaPembeli = cmbPembeli.SelectedItem.ToString()!;

            var buyer = _buyerService.GetByName(namaPembeli);

            if (buyer == null)
            {
                txtAlamat.Clear();
                return;
            }

            txtAlamat.Text = buyer.Address;
        }

        private void SerialService_DataReceived(
        SerialService serialService,
        string data)
        {
            if (InvokeRequired)
            {
                Invoke(() => ProcessReceivedData(serialService, data));
                return;
            }

            ProcessReceivedData(serialService, data);
        }

        private void ProcessReceivedData(
        SerialService serialService,
        string data)
        {
            Scale? scale = _scales.FirstOrDefault(
                x => x.SerialService == serialService
            );

            if (scale == null)
                return;

            // Parse data dari loadcell
            decimal weight = WeightParser.ParseWeight(data);

            // Simpan ke object Scale
            scale.Weight = weight;

            // Tampilkan ke textbox sesuai loadcell
            switch (scale.Id)
            {
                case 1:
                    txtActualScale1.Text = weight.ToString("0");
                    break;

                case 2:
                    txtActualScale2.Text = weight.ToString("0");
                    break;

                case 3:
                    txtActualScale3.Text = "0";
                    break;

                case 4:
                    txtActualScale4.Text = "0";
                    break;
            }

            // Diagnostic
            System.Diagnostics.Debug.WriteLine(
                $"[LOADCELL {scale.Id}] Raw: '{data}' -> Weight: {weight}"
            );
        }

        private void TestWeightParser()
        {
            string[] testData =
            {
                "0000.012",
                "0000.120",
                "0012.345",
                "0000.000",
                "-0000.012"
            };

            foreach (string raw in testData)
            {
                decimal result = WeightParser.ParseWeight(raw);

                System.Diagnostics.Debug.WriteLine(
                    $"RAW = {raw} | RESULT = {result}"
                );
            }
        }

        private void CalculateBatching()
        {
            if (cmbMutu.SelectedItem == null)
                return;

            if (!decimal.TryParse(txtVolume.Text, out decimal volume))
                return;

            if (volume <= 0)
                return;

            string mutu = cmbMutu.SelectedItem.ToString()!;

            var recipe = _recipeService.GetByMutu(mutu);

            if (recipe == null)
            {
                MessageBox.Show($"Recipe untuk mutu '{mutu}' tidak ditemukan.");
                return;
            }

            var result = _batchingService.Calculate(recipe, volume);

            // Target Recipe - Biru Tua
            txtTargetBin1.Text = result.Bin1.ToString("0.##");
            txtTargetBin2.Text = result.Bin2.ToString("0.##");
            txtTargetBin3.Text = result.Bin3.ToString("0.##");
            txtTargetBin4.Text = result.Bin4.ToString("0.##");

            // Target Cumulative - Biru Muda
            txtCumulativeBin1.Text = result.CumulativeBin1.ToString("0.##");
            txtCumulativeBin2.Text = result.CumulativeBin2.ToString("0.##");
            txtCumulativeBin3.Text = result.CumulativeBin3.ToString("0.##");
            txtCumulativeBin4.Text = result.CumulativeBin4.ToString("0.##");

            // Material
            // Material
            txtTargetSemen.Text = result.Semen.ToString("0.##");
            txtCumulativeSemen.Text = result.CumulativeSemen.ToString("0.##");

            txtTargetFlyAsh.Text = result.FlyAsh.ToString("0.##");
            txtCumulativeFlyash.Text = result.CumulativeFlyAsh.ToString("0.##");

            txtTargetAir.Text = result.Air.ToString("0.##");
            txtTargetAditif.Text = result.Aditif.ToString("0.##");

            txtActualScale3.Text = "0";
            txtActualScale4.Text = "0";
        }

        public void UpdateActualScale(int scaleId, decimal weight)
        {
            switch (scaleId)
            {
                case 1:
                    txtActualScale1.Text = weight.ToString("0000.00");
                    break;

                case 2:
                    txtActualScale2.Text = weight.ToString("0000.00");
                    break;

                case 3:
                    txtActualScale3.Text = weight.ToString("0000.00");
                    break;

                case 4:
                    txtActualScale4.Text = weight.ToString("0000.00");
                    break;
            }
        }

        private Transaction CreateTransactionFromForm()
        {
            decimal.TryParse(txtVolume.Text, out decimal volume);
            decimal.TryParse(txtRitase.Text, out decimal ritase);
            decimal.TryParse(txtTotal.Text, out decimal total);
            decimal.TryParse(txtSlump.Text, out decimal slump);

            return new Transaction
            {
                TransId = _transactionService.GenerateTransactionId(),
                Tanggal = DateTime.Now,

                Supir = txtSupir.Text.Trim(),
                Pembeli = cmbPembeli.SelectedItem?.ToString() ?? "",
                Proyek = txtProyek.Text.Trim(),
                NoTruck = txtNoTruck.Text.Trim(),
                Mutu = cmbMutu.SelectedItem?.ToString() ?? "",
                Alamat = txtAlamat.Text.Trim(),

                Volume = volume,
                Ritase = ritase,
                Keterangan = txtKeterangan.Text.Trim(),
                Total = total,
                Petugas = txtPetugas.Text.Trim(),
                Slump = slump,

                // Hasil Sampling Aggregate
                Bin1 = _samplingBin1,
                Bin2 = _samplingBin2,
                Bin3 = _samplingBin3,
                Bin4 = _samplingBin4,

                // Material
                Semen = _samplingSemen,
                FlyAsh = _samplingFlyAsh,

                // Air & Aditif tidak ada loadcell
                Air = 0,
                Aditif = 0
            };
        }

        private void SaveTransaction()
        {
            var transaction = CreateTransactionFromForm();

            try
            {
                _transactionService.Add(transaction);

                LoadTransactionHistory();

                MessageBox.Show(
                    "Transaksi berhasil disimpan.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Gagal menyimpan transaksi:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cmbMutu_SelectedIndexChanged(
        object sender,
        EventArgs e)
        {
            CalculateBatching();
        }

        private void txtVolume_TextChanged(
        object sender,
        EventArgs e)
        {
            CalculateBatching();
        }


        private void LoadTransactionHistory()
        {
            FilterTransactionByDate();

            dgvHistori.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistori.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;

            dgvHistori.ReadOnly = true;
            dgvHistori.AllowUserToAddRows = false;
            dgvHistori.AllowUserToDeleteRows = false;
            dgvHistori.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        private void dtpTanggalHistori_ValueChanged(
        object sender, EventArgs e)
            {
                LoadTransactionHistory();
            }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void grpReceive_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void grpScale2_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPembeli_Click_1(object sender, EventArgs e)
        {
            using (var form = new INPUT_PEMBELI())
            {
                form.ShowDialog(this);
            }

            LoadBuyerData();
        }

        private void btnProduk_Click_1(object sender, EventArgs e)
        {
            using (var form = new INPUT_PRODUK())
            {
                form.ShowDialog(this);
            }

            LoadRecipeData();
        }

        private void btnSettingTimbangan_Click_1(object sender, EventArgs e)
        {
            if (_scaleSettingsForm == null || _scaleSettingsForm.IsDisposed)
            {
                _scaleSettingsForm = new MainForm(this);
            }

            _scaleSettingsForm.Show(this);
            _scaleSettingsForm.BringToFront();
        }

        private void btnBatching_Click(object sender, EventArgs e)
        {
            if (!isBatching)
            {
                if (!ValidateTransactionInput())
                    return;

                isBatching = true;

                btnBatching.Text = "Batching...";

                StartBatchingBlink();

                return;
            }

            // Klik kedua → batching selesai
            isBatching = false;

            btnBatching.Text = "Simpan";

            StopBatchingBlink();

            // Hitung Fly Ash setelah batching selesai
            // RW Fly Ash = RW Scale 2 - RW Semen
            CalculateFlyAshSampling();

            SaveTransaction();
        }

        private bool ValidateTransactionInput()
        {
            if (cmbMutu.SelectedItem == null)
            {
                MessageBox.Show("Mutu belum dipilih.");
                cmbMutu.Focus();
                return false;
            }

            if (!decimal.TryParse(txtVolume.Text, out decimal volume) ||
                volume <= 0)
            {
                MessageBox.Show("Volume harus lebih dari 0.");
                txtVolume.Focus();
                return false;
            }

            return true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            var transactions = string.IsNullOrEmpty(keyword)
                ? _transactionService.GetAll()
                : _transactionService.Search(keyword);

            dgvHistori.DataSource = null;
            dgvHistori.DataSource = transactions;
        }

        private void dtpStartDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTransactionByDate();

        }

        private void dtpEndDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTransactionByDate();

        }

        private void FilterTransactionByDate()
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show(
                    "Tanggal mulai tidak boleh lebih besar dari tanggal akhir.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var transactions = _transactionService.GetByDate(
                startDate,
                endDate
            );

            dgvHistori.DataSource = null;
            dgvHistori.DataSource = transactions;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            FilterTransactionByDate();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            FilterTransactionByDate();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Apakah anda yakin ingin menghapus semua data transaksi?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _transactionService.DeleteAll();

                // Refresh tabel history
                dgvHistori.DataSource = null;
                dgvHistori.DataSource = _transactionService.GetAll();

                MessageBox.Show(
                    "Semua data transaksi berhasil dihapus.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Gagal menghapus data transaksi:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            if (!isBatching)
                return;

            isBatching = false;

            btnBatching.Text = "Simpan";

            MessageBox.Show(
                "Proses batching dibatalkan.",
                "Batching",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void txtVolume_TextChanged_1(object sender, EventArgs e)
        {
            CalculateBatching();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvHistori.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Tidak ada data histori untuk diekspor.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            using SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveDialog.Title = "Simpan Data Histori";
            saveDialog.FileName =
                $"History_Transaksi_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using XLWorkbook workbook = new XLWorkbook();

                IXLWorksheet worksheet = workbook.Worksheets.Add("History");

                // Header
                for (int column = 0; column < dgvHistori.Columns.Count; column++)
                {
                    worksheet.Cell(1, column + 1).Value =
                        dgvHistori.Columns[column].HeaderText;
                }

                // Data
                int excelRow = 2;

                foreach (DataGridViewRow row in dgvHistori.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    for (int column = 0; column < dgvHistori.Columns.Count; column++)
                    {
                        object? value = row.Cells[column].Value;

                        worksheet.Cell(excelRow, column + 1).Value =
                            value?.ToString() ?? "";
                    }

                    excelRow++;
                }

                // Format header
                IXLRange headerRange = worksheet.Range(
                    1,
                    1,
                    1,
                    dgvHistori.Columns.Count
                );

                headerRange.Style.Font.Bold = true;
                headerRange.Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;

                // Rapikan lebar kolom
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(saveDialog.FileName);

                MessageBox.Show(
                    "Data histori berhasil diekspor ke Excel.",
                    "Export Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Gagal mengekspor data ke Excel:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void GenerateNewTransactionId()
        {
            txtTransId.Text = _transactionService.GenerateTransactionId();
        }

        private void btnSampling1_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTargetBin1.Text, out decimal target))
                return;

            if (!decimal.TryParse(txtActualScale1.Text, out decimal rw))
                return;

            if (target <= 0)
            {
                _samplingBin1 = 0;
                _rw1 = 0;
                return;
            }

            _rw1 = rw;
            _samplingBin1 = rw;
        }

        private void btnSampling2_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTargetBin2.Text, out decimal target))
                return;

            if (!decimal.TryParse(txtActualScale1.Text, out decimal rw))
                return;

            if (target <= 0)
            {
                _samplingBin2 = 0;
                _rw2 = 0;
                return;
            }

            _rw2 = rw;

            _samplingBin2 =
                rw - _samplingBin1;
        }

        private void btnSampling3_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTargetBin3.Text, out decimal target))
                return;

            if (!decimal.TryParse(txtActualScale1.Text, out decimal rw))
                return;

            if (target <= 0)
            {
                _samplingBin3 = 0;
                _rw3 = 0;
                return;
            }

            _rw3 = rw;

            _samplingBin3 =
                rw
                - _samplingBin1
                - _samplingBin2;
        }

        private void btnSampling4_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTargetBin4.Text, out decimal target))
                return;

            if (!decimal.TryParse(txtActualScale1.Text, out decimal rw))
                return;

            if (target <= 0)
            {
                _samplingBin4 = 0;
                _rw4 = 0;
                return;
            }

            _rw4 = rw;

            _samplingBin4 =
                rw
                - _samplingBin1
                - _samplingBin2
                - _samplingBin3;
        }

        private void btnSampling5_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(
                txtActualScale2.Text,
                out decimal rwSemen))
                return;

            _samplingSemen = rwSemen;
        }

        private void CalculateFlyAshSampling()
        {
            if (!decimal.TryParse(
                txtActualScale2.Text,
                out decimal rw))
                return;

            _samplingFlyAsh = rw - _samplingSemen;

            if (_samplingFlyAsh < 0)
                _samplingFlyAsh = 0;
        }

        private void btnSampling6_Click(object sender, EventArgs e)
        {

            
        }

        protected override bool ProcessCmdKey(
        ref Message msg,
        Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                btnSampling1.PerformClick();
                return true;
            }

            if (keyData == Keys.F2)
            {
                btnSampling2.PerformClick();
                return true;
            }

            if (keyData == Keys.F3)
            {
                btnSampling3.PerformClick();
                return true;
            }

            if (keyData == Keys.F4)
            {
                btnBatching.PerformClick();
                return true;
            }

            if (keyData == Keys.F5)
            {
                btnSampling4.PerformClick();
                btnSampling5.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BatchingBlinkTimer_Tick(object? sender, EventArgs e)
        {
            _batchingBlinkState = !_batchingBlinkState;

            lblbatchingrun.Visible = _batchingBlinkState;
        }

        private void StartBatchingBlink()
        {
            _batchingBlinkState = true;
            lblbatchingrun.Visible = true;

            _batchingBlinkTimer.Start();
        }

        private void StopBatchingBlink()
        {
            _batchingBlinkTimer.Stop();

            _batchingBlinkState = false;
            lblbatchingrun.Visible = false;
        }

        private void txtActualScale2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click_1(object sender, EventArgs e)
        {

        }

        private void txtTargetAir_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTargetBin1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
