using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasir_Restaurant
{
    public partial class Menu_Restaurant : Form
    {
        

        public Menu_Restaurant()
        {
            InitializeComponent();
            
        }
        String password;
        public Menu_Restaurant(String s)
        {
            InitializeComponent();
            password = s;

        }

        private void Menu_Restaurant_Load(object sender, EventArgs e)
        {
            if (password == "admin123")
            {
                
            }
            else if (password == "kasir123") // ini
            {
                button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transaksi transaksi = new Transaksi();
            transaksi.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apa Kamu Yakin ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Klik 'OK' Untuk Memesan Makanan", "Memesan Makanan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Hide();
                PesanMakanan pesan = new PesanMakanan();
                pesan.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Klik 'OK' Untuk Memesan Makanan", "Memesan Makanan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Hide();
                Menu pesan = new Menu();
                pesan.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Klik 'OK' Untuk Ke Menu Pelanggan", "Menu Pelanggan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Hide();
                Pelanggan pelanggan = new Pelanggan();
                pelanggan.ShowDialog();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apa Kamu Yakin ?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }
        }
    }
}
