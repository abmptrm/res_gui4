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
using System.Globalization;

namespace Kasir_Restaurant
{
    public partial class Transaksi : Form
    {
        public Transaksi()
        {
            InitializeComponent();
        }

        void clearData()
        {
            // textBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            label5.Text = "Rp0";
            comboBox1.ResetText();



        }

        void showData()
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            try
            {
                conn.Open();
                string cmdSelect = "SELECT * FROM tb_transaksi_satu";
                SqlCommand cmd = new SqlCommand(cmdSelect, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tb_transaksi_satu");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tb_transaksi_satu";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                
            } catch (Exception g)
            {
                MessageBox.Show(g.ToString());
            }finally
            {
                conn.Close();
            }
        }

        void showIdPesanan()
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();
            SqlDataReader rd;

            try
            {
                conn.Open();
                string Select_cmd = "SELECT id_pesanan FROM tb_pesanan_satu";
                SqlCommand cmd = new SqlCommand(Select_cmd, conn);

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd["id_pesanan"]);
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

        private int totalHarga(int a, int b)
        {
            int total = a * b;
            return total;
        }

        private int hitungKembalian(int a, int b)
        {
            int total = a - b;
            return total;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            try
            {
                conn.Open();
                string cmdSelect = "SELECT * FROM tb_pesanan_satu WHERE id_pesanan='"+comboBox1.SelectedItem.ToString()+"'";
                SqlCommand cmd = new SqlCommand(cmdSelect, conn);
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["nama_menu"].ToString();
                    textBox4.Text = dr["harga"].ToString();
                    textBox6.Text = dr["jumlah_pesanan"].ToString();
                    int total = totalHarga((int)dr["harga"],(int)dr["jumlah_pesanan"]);
                    
                    //textBox5.Text = total.ToString();
                    //textBox7.Text = total.ToString();

                    label5.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));



                }
                

            }
            catch (Exception g)
            {
                MessageBox.Show(g.ToString());
            } finally
            {
                conn.Close();
            }
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            showIdPesanan();
            clearData();
            showData();
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO tb_transaksi_satu VALUES('"+textBox1.Text+"', '"+comboBox1.Text+"', '"+textBox2.Text+"', '"+textBox4.Text+"', '"+textBox6.Text+"', '"+textBox5.Text+"', '"+textBox7.Text+"')";
               

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Tersimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearData();
                showData();

            } catch (Exception g)
            {
                MessageBox.Show(g.ToString());
            } finally
            {
                conn.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            clearData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["id_transaksi"].Value.ToString();
            comboBox1.Text = row.Cells["id_pesanan"].Value.ToString();
            textBox2.Text = row.Cells["nama_menu"].Value.ToString();
            
            textBox4.Text = row.Cells["harga"].Value.ToString();
            textBox6.Text = row.Cells["jumlah_pesanan"].Value.ToString();
            textBox5.Text = row.Cells["pembayaran"].Value.ToString();

            textBox7.Text = row.Cells["kembalian"].Value.ToString();
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sqlserver con = new Sqlserver();
            SqlConnection conn = con.getConn();

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox7.Text.Trim() == "" || comboBox1.Text == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
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
                        cmd.CommandText = "DELETE FROM tb_transaksi_satu WHERE id_transaksi='" + textBox1.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Di Hapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Klik 'OK' Untuk Kembali Ke Menu Utama", "Kembali", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Hide();
                Menu_Restaurant menu = new Menu_Restaurant();
                menu.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int total = totalHarga(int.Parse(textBox4.Text), int.Parse(textBox6.Text));
            int kembali = hitungKembalian( int.Parse(textBox5.Text), total);
            textBox7.Text = kembali.ToString();

            //int kembalian = hitungKembalian((int)textBox5.Text, (int)textBox7.Text));
        }
    }
}
