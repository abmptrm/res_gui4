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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }



        void clearData()
        {
            // textBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
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
             
                string cmdSelect = "SELECT * FROM tb_menu;";
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

        void cariData()
        {

            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();



            try
            {
                conn.Open();

                string cmdSelect = "SELECT * FROM tb_menu WHERE id_menu like '%"+textBox4.Text+"%' OR nama_menu like '%"+textBox4.Text+"%'";
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
                    //cmd.CommandText = "INSERT INTO tb_menu values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "'); INSERT INTO tb_pesanan SET [id_menu]='"+textBox1.Text+"')";
                    cmd.CommandText = "INSERT INTO tb_menu VALUES(@id, @nama, @harga)";
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nama", textBox2.Text);
                    cmd.Parameters.AddWithValue("@harga", textBox3.Text);
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

        private void Menu_Load(object sender, EventArgs e)
        {
            showData();
            clearData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Isi Semua Data !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE tb_menu SET id_menu='" + textBox1.Text + "', nama_menu='" + textBox2.Text + "', harga='" + textBox3.Text + "' WHERE id_menu='" + textBox1.Text + "'";
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
                            cmd.CommandText = "DELETE FROM tb_menu WHERE id_menu='" + textBox1.Text + "'";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["id_menu"].Value.ToString();
            textBox2.Text = row.Cells["nama_menu"].Value.ToString();
            textBox3.Text = row.Cells["harga"].Value.ToString();
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

        private void button5_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            cariData();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
