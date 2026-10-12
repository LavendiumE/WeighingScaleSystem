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
    public partial class INPUT_PRODUK : Form
    {
        private readonly RecipeService _recipeService = AppServices.Recipe;

        public INPUT_PRODUK()
        {
            InitializeComponent();

            LoadRecipeTable();
        }

        private void LoadRecipeTable()
        {
            dgvMutu.DataSource = null;
            dgvMutu.DataSource = _recipeService.GetAll();
        }





        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTambahMutu_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMutu.Text))
                {
                    MessageBox.Show("Mutu belum diisi.");
                    return;
                }

                if (!decimal.TryParse(txtBin1.Text, out decimal bin1) ||
                    !decimal.TryParse(txtBin2.Text, out decimal bin2) ||
                    !decimal.TryParse(txtBin3.Text, out decimal bin3) ||
                    !decimal.TryParse(txtBin4.Text, out decimal bin4) ||
                    !decimal.TryParse(txtSemen.Text, out decimal semen) ||
                    !decimal.TryParse(txtFlyAsh.Text, out decimal flyAsh) ||
                    !decimal.TryParse(txtAir.Text, out decimal air) ||
                    !decimal.TryParse(txtAditif.Text, out decimal aditif))
                {
                    MessageBox.Show("Pastikan semua nilai bahan berupa angka.");
                    return;
                }

                var recipe = new Recipe
                {
                    Mutu = txtMutu.Text.Trim(),

                    Bin1 = bin1,
                    Bin2 = bin2,
                    Bin3 = bin3,
                    Bin4 = bin4,

                    Semen = semen,
                    FlyAsh = flyAsh,
                    Air = air,
                    Aditif = aditif
                };

                _recipeService.Add(recipe);

                LoadRecipeTable();

                MessageBox.Show("Recipe berhasil ditambahkan.");

                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearInput()
        {
            txtMutu.Clear();

            txtBin1.Clear();
            txtBin2.Clear();
            txtBin3.Clear();
            txtBin4.Clear();

            txtSemen.Clear();
            txtFlyAsh.Clear();
            txtAir.Clear();
            txtAditif.Clear();
        }

        private void btnHapusMutu_Click(object sender, EventArgs e)
        {
            try
            {
                string mutu = txtHapusMutu.Text.Trim();

                if (string.IsNullOrWhiteSpace(mutu))
                {
                    MessageBox.Show("Masukkan mutu yang ingin dihapus.");
                    return;
                }

                var result = MessageBox.Show(
                    $"Yakin ingin menghapus recipe {mutu}?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                    return;

                _recipeService.Delete(mutu);

                LoadRecipeTable();

                txtHapusMutu.Clear();

                MessageBox.Show(
                    $"Recipe {mutu} berhasil dihapus.",
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
