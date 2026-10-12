using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeighingScaleMiddleware.Models;
using WeighingScaleMiddleware.Services;

namespace WeighingScaleMiddleware
{
    public partial class INPUT_PEMBELI : Form
    {
        private readonly BuyerService _buyerService = AppServices.Buyer;
        public INPUT_PEMBELI()
        {
            InitializeComponent();

            LoadBuyerTable();
        }

        private void LoadBuyerTable()
        {
            dgvPembeli.DataSource = null;
            dgvPembeli.DataSource = _buyerService.GetAll();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTambahPembeli_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = txtPembeli.Text.Trim();
                string alamat = txtAlamat.Text.Trim();

                if (string.IsNullOrWhiteSpace(nama))
                {
                    MessageBox.Show(
                        "Nama pembeli belum diisi.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (string.IsNullOrWhiteSpace(alamat))
                {
                    MessageBox.Show(
                        "Alamat belum diisi.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var buyer = new Buyer
                {
                    Name = nama,
                    Address = alamat
                };

                _buyerService.Add(buyer);

                LoadBuyerTable();

                txtPembeli.Clear();
                txtAlamat.Clear();

                MessageBox.Show(
                    "Pembeli berhasil ditambahkan.",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnHapusPembeli_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = txtHapusPembeli.Text.Trim();

                if (string.IsNullOrWhiteSpace(nama))
                {
                    MessageBox.Show(
                        "Masukkan nama pembeli yang ingin dihapus.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Yakin ingin menghapus pembeli \"{nama}\"?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

                _buyerService.Delete(nama);

                LoadBuyerTable();

                txtHapusPembeli.Clear();

                MessageBox.Show(
                    "Pembeli berhasil dihapus.",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
