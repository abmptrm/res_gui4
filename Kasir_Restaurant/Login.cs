using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kasir_Restaurant
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            textBox2.UseSystemPasswordChar = true;
        }



        void clearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sqlserver Kon = new Sqlserver();
            SqlConnection conn = Kon.getConn();

            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM tb_user WHERE nama_user='" + textBox1.Text + "' and pass_user='" + textBox2.Text + "'";

            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            rd.Read();

            if (rd.HasRows)
            {
                

                DialogResult result = MessageBox.Show("Login Sukses", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Hide();
                    Menu_Restaurant menu = new Menu_Restaurant(textBox2.Text);
                    menu.Show();
                }

                // this.Close();
                conn.Close();
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

            

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apa Kamu Yakin ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            } 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
             
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox2.UseSystemPasswordChar = true;
            } else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
