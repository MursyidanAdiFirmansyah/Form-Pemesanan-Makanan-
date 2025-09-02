using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pemesanan_Makanan_Online
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> menuMakanan = new Dictionary<string, int>()
        {
            {"Mie Goreng", 12000},
            {"Mie Kuah", 12000},
            {"Mie Ayam", 15000},
            {"Mie Ayam + Bakso Ayam", 20000},
            {"Bakso Ayam", 15000},
            {"Bakso Sapi", 20000},
            {"Nasi Goreng", 15000},
            {"Ayam Goreng", 15000},
            {"Bebek Goreng", 15000},
            {"Sate Ayam", 15000},
            {"Sate Kambing", 25000},
            {"Sate Bebek", 20000},
            {"Babi Gulung", 30000},
            {"Babi Kecap", 25000},
            {"Sup", 10000}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in menuMakanan)
            {
                comboBox1.Items.Add(item.Key);
            }

            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox1.TextChanged += comboBox1_TextChanged;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string menuDipilih = comboBox1.Text.Trim();

            if (menuMakanan.ContainsKey(menuDipilih))
            {
                textBox2.Text = menuMakanan[menuDipilih].ToString();
            }
            else
            {
                textBox2.Clear();
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Pilih menu dan masukkan jumlah pesanan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int harga = int.Parse(textBox2.Text);
                int jumlah = int.Parse(textBox3.Text);

                int total = harga * jumlah;
                textBox4.Text = total.ToString();
            }
            catch
            {
                MessageBox.Show("Jumlah pesanan harus berupa angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // nanti bisa ditambahkan misalnya untuk reset form atau keluar aplikasi
        }
    }
}
