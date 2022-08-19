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
    public partial class Pelanggan : Form
    {
        public Pelanggan()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        void clearData()
        {
            // textBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedItem = null;
        }

        void showData()
        {

            //string connString = @"Data Source= DESKTOP-G6MV476\SQLEXPRESS; Initial Catalog=db_restaurant; Integrated Security=True";

            //SqlConnection conn = new SqlConnection(connString);

            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();



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

        void cariData()
        {

            string connString = @"Data Source= DESKTOP-G6MV476\SQLEXPRESS; Initial Catalog=db_restaurant; Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);



            try
            {
                conn.Open();

                string cmdSelect = "SELECT * FROM tb_pelanggan WHERE id_pelanggan like '%" + textBox5.Text + "%' OR nama_pelanggan like '%" + textBox5.Text + "%' OR no_hp like '%"+textBox5.Text+ "%' OR alamat like '%" + textBox5.Text + "%'";
                SqlCommand cmd = new SqlCommand(cmdSelect, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "tb_menu");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tb_menu";
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

        private void button1_Click(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Isi Semua Data !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO tb_pelanggan values('" + textBox1.Text + "', '" + textBox2.Text + "', '"+ comboBox1.Text +"', '" + textBox3.Text + "', '"+textBox4.Text+"')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Terkirim !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                    showData();


                }
                catch (Exception g)
                {
                    MessageBox.Show(g.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void Pelanggan_Load(object sender, EventArgs e)
        {
            showData();
            clearData();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Isi Semua Data !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE tb_pelanggan SET id_pelanggan='" + textBox1.Text + "', nama_pelanggan='" + textBox2.Text + "', jenis_kelamin='" + comboBox1.Text + "', no_hp='"+textBox3.Text+"', alamat='"+textBox4.Text+"' WHERE id_pelanggan='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Terupdate !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                    showData();


                }
                catch (Exception g)
                {
                    MessageBox.Show(g.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["id_pelanggan"].Value.ToString();
            textBox2.Text = row.Cells["nama_pelanggan"].Value.ToString();
            comboBox1.Text = row.Cells["jenis_kelamin"].Value.ToString();
            textBox3.Text = row.Cells["no_hp"].Value.ToString();
            textBox4.Text = row.Cells["alamat"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();


            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Isi Semua Data !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Apakah Anda Yakin Menghapus Data Ini ?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "DELETE FROM tb_pelanggan WHERE id_pelanggan='" + textBox1.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Terhapus !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearData();
                        showData();


                    }
                    catch (Exception g)
                    {
                        MessageBox.Show(g.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else if (result == DialogResult.No)
                {

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Klik 'OK' Untuk Kembali Ke Menu Utama", "Kembali", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Hide();
                Menu_Restaurant menu = new Menu_Restaurant();
                menu.Show();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            cariData();
        }
    }
}
