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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void clearData()
        {
            // textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        void showData()
        {
            string connString = "Data Source = localhost; Initial Catalog=db_restaurant; Integrated security=true";
            SqlConnection conn = new SqlConnection(connString);



            try
            {
                conn.Open();
                string cmdSelect = "SELECT * FROM tb_pelanggan;";
                SqlCommand cmd = new SqlCommand(cmdSelect, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "tb_pelanggan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tb_pelanggan";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                


            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());

            }
            finally
            {
                conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clearData();
            showData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox2.Text = row.Cells["nama_pelanggan"].Value.ToString();
            textBox3.Text = row.Cells["jenis_kelamin"].Value.ToString();
            textBox4.Text = row.Cells["alamat"].Value.ToString();
            textBox6.Text = row.Cells["no_hp"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Klik 'OK' Untuk Kembali Ke Menu Halaman", "Kembali", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Hide();
                Menu_Restaurant menu = new Menu_Restaurant();
                menu.ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Mohon Untuk Mengisi Semua Kolom Di Atas !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                //string connString = "Data Source = localhost; Initial Catalog=db_restaurant; Integrated security=true";
                // SqlConnection conn = new SqlConnection(connString);
                
                Sqlserver con = new Sqlserver();
                SqlConnection conn = con.getConn();

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO tb_pelanggan VALUES('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox6.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Terkirim !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                    showData();

                }
                catch (SqlException g)
                {
                    MessageBox.Show(g.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } finally
                {
                    conn.Close();
                }
                

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Mohon Untuk Mengisi Semua Kolom Di Atas !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //string connString = "Data Source = localhost; Initial Catalog=db_restaurant; Integrated security=true";
                // SqlConnection conn = new SqlConnection(connString);

                Sqlserver con = new Sqlserver();
                SqlConnection conn = con.getConn();

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE tb_pelanggan SET nama_pelanggan='"+textBox2.Text+"', jenis_kelamin='"+textBox3.Text+"', alamat='"+textBox4.Text+"', no_hp='"+textBox6.Text+"' WHERE nama_pelanggan = '"+textBox2.Text+"'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Terupdate !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                    showData();

                }
                catch (SqlException g)
                {
                    MessageBox.Show(g.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Mohon Untuk Mengisi Semua Kolom Di Atas !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //string connString = "Data Source = localhost; Initial Catalog=db_restaurant; Integrated security=true";
                // SqlConnection conn = new SqlConnection(connString);

                Sqlserver con = new Sqlserver();
                SqlConnection conn = con.getConn();

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM tb_pelanggan WHERE nama_pelanggan='" + textBox2.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Terhapus !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                    showData();

                }
                catch (SqlException g)
                {
                    MessageBox.Show(g.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
    
}
