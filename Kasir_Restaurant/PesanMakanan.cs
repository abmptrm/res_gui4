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
    public partial class PesanMakanan : Form
    {
        public PesanMakanan()
        {
            InitializeComponent();
        }

        void clearData()
        {
            // textBox1.Text = "";
            textBox1.Text = ""; 
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.ResetText();
            comboBox2.ResetText();
            
            //comboBox4.ResetText();
            comboBox5.ResetText();
            
        }

        void showIdMenu()
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();
            SqlDataReader rd;

            try
            {
                
                conn.Open();
                string Select_cmd = "SELECT * FROM tb_menu ";

               

                SqlCommand cmd = new SqlCommand(Select_cmd, conn);
        
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd["id_menu"]);

                }

                


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

                string cmdSelect = "SELECT * FROM tb_pesanan_satu WHERE id_pesanan like '%" + textBox3.Text + "%' OR id_menu like '%" + textBox3.Text + "%'";
                SqlCommand cmd = new SqlCommand(cmdSelect, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "tb_pesanan_satu");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tb_pesanan_satu";
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








        void showIdPelanggan()
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();
            SqlDataReader rd;

            try
            {
                conn.Open();
                string Select_cmd = "SELECT id_pelanggan FROM tb_pelanggan";
                SqlCommand cmd = new SqlCommand(Select_cmd, conn);

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox2.Items.Add(rd["id_pelanggan"]);
                }


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

        

        void showIdUser()
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();
            SqlDataReader rd;

            try
            {
                conn.Open();
                string Select_cmd = "SELECT id_user FROM tb_user";
                SqlCommand cmd = new SqlCommand(Select_cmd, conn);

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox5.Items.Add(rd["id_user"]);
                }


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

        




        void showData()
        {

            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();



            try
            {
                conn.Open();
                // string cmdSelect = "SELECT id_pesanan, nama_menu, nama_pelanggan, jumlah_pesanan FROM tb_pesanan JOIN tb_menu ON tb_pesanan.id_menu = tb_menu.id_menu JOIN tb_pelanggan ON tb_pesanan.id_pelanggan = tb_pelanggan.id_pelanggan";
                //string cmdSelect = "SELECT id_pesanan, nama_menu, nama_pesanan, jumlah_pesanan FROM tb_pesanan, tb_menu, tb_pelanggan";
                string cmdSelect = "SELECT * FROM tb_pesanan_satu";
                SqlCommand cmd = new SqlCommand(cmdSelect, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "tb_pesanan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tb_pesanan";
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

        private void PesanMakanan_Load(object sender, EventArgs e)
        {
            showIdMenu();
            cariData();
            //showNamaMenu();
            showIdPelanggan();
            //showNamaPelanggan();
            showIdUser();
            //showNamaUser();
            showData();
            clearData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Klik 'OK' Untuk Kembali Ke Menu Halaman", "Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Hide();
                Menu_Restaurant menu = new Menu_Restaurant();
                menu.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();
           
            try { 
                conn.Open();
                string selectnama = "SELECT * FROM tb_menu WHERE id_menu='"+comboBox1.SelectedItem.ToString()+"'";
                SqlCommand cmd= new SqlCommand(selectnama, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox4.Text = dr["nama_menu"].ToString();
                    textBox7.Text = dr["harga"].ToString();
                    //String.Format, textBox7.Text);
                }
                
                


            } catch (Exception g)
            {
                MessageBox.Show(g.ToString());
            } finally
            {
                conn.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            try
            {
                conn.Open();
                string selectnama = "SELECT id_pelanggan, nama_pelanggan FROM tb_pelanggan WHERE id_pelanggan='" + comboBox2.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(selectnama, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox5.Text = dr["nama_pelanggan"].ToString();
                    
                }

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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || comboBox5.Text.Trim() == "")
            {
                MessageBox.Show("isi terlebih dahulu kolom di atas", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO tb_pesanan_satu VALUES('" + textBox1.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "', '" + textBox7.Text + "', '" + comboBox2.Text + "', '"+ textBox5.Text +"', '"+textBox2.Text+"', '"+ comboBox5.Text + "', '" + textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Sudah Di Kirim !");
                clearData();
                showData();


            }
            catch (Exception g)
            {
                MessageBox.Show(g.ToString());
            } finally
            {
                conn.Close();
            }
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            try
            {
                conn.Open();
                string selectnama = "SELECT * FROM tb_user WHERE id_user='" + comboBox5.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(selectnama, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox6.Text = dr["nama_user"].ToString();
                    
                }




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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["id_pesanan"].Value.ToString();
            comboBox1.Text = row.Cells["id_menu"].Value.ToString();
            textBox4.Text = row.Cells["nama_menu"].Value.ToString();
            textBox7.Text = row.Cells["harga"].Value.ToString();
            comboBox2.Text = row.Cells["id_pelanggan"].Value.ToString();
            textBox5.Text = row.Cells["nama_pelanggan"].Value.ToString();
            textBox2.Text = row.Cells["jumlah_pesanan"].Value.ToString();
            comboBox5.Text = row.Cells["id_user"].Value.ToString();
            textBox6.Text = row.Cells["harga"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();


            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox4.Text.Trim() == "" ||  comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || comboBox5.Text.Trim() == "" || textBox7.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
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
                        cmd.CommandText = "DELETE FROM tb_pesanan_satu WHERE id_pesanan='" + textBox1.Text + "'";
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

        private void button4_Click(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox4.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || comboBox5.Text.Trim() == "" || textBox7.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
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
                    cmd.CommandText = "UPDATE tb_pesanan_satu SET id_pesanan='" + textBox1.Text + "', id_menu='" + comboBox1.Text + "', nama_menu='" + textBox4.Text + "' , harga='" + textBox7.Text + "' , id_pelanggan='" + comboBox2.Text + "' , nama_pelanggan='" + textBox5.Text + "' , jumlah_pesanan='" + textBox2.Text + "' , id_user='" + comboBox5.Text + "', nama_user='" + textBox6.Text + "' WHERE id_pesanan='" + textBox1.Text + "'";
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            cariData();
        }
    }
}
