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
    public partial class ReLoginAdmin : Form
    {
        public ReLoginAdmin()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        void clearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void ReLoginAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Klik 'OK' Untuk Kembali Ke Menu Halaman", "Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Hide();
                Menu_Restaurant menu = new Menu_Restaurant();
                menu.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin123")
            {
                DialogResult result = MessageBox.Show("Login Sukses", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Hide();
                    Form1 crud = new Form1();
                    crud.ShowDialog();
                }
            }       
            else
            {
                DialogResult result = MessageBox.Show("Login Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    clearData();
                }
            }
        }
    }
}
