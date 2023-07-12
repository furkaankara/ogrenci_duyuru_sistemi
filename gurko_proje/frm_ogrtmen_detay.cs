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

namespace gurko_proje
{
    public partial class frm_ogrtmen_detay : Form
    {
        public frm_ogrtmen_detay()
        {
            InitializeComponent();
        }
        public string tc;
        sql_baglantisi bgl=new sql_baglantisi();
        
        private void frm_ogrtmen_detay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            //Ad SOYAD ÇEKME    

            SqlCommand komut =new SqlCommand("select ogrtmnadsoyad from tbl_ogretmen_giris where ogrtmntc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_ogrenci_g", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close(); 


            DataTable dt2= new DataTable();
            SqlDataAdapter dv = new SqlDataAdapter("select * from tbl_duyuru", bgl.baglanti());
            dv.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into tbl_duyuru (duyuru) values(@p1)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", richTextBox1.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Duyuru Yapılmıştır");
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("insert into tbl_ogrenci_g(ogradsoyad,ogrno) values(@p1,@p2)", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.Parameters.AddWithValue("@p2", textBox2.Text.ToString());
            komut3.ExecuteNonQuery();
            MessageBox.Show("öğrenci kaydı yapılmıştır");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_ogrenci_g", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut5 = new SqlCommand("update tbl_ogrenci_g set ogradsoyad=@p1  where ogrno=@p2", bgl.baglanti());
            komut5.Parameters.AddWithValue("@p1", textBox1.Text);
            komut5.Parameters.AddWithValue("@p2", textBox2.Text.ToString());
            komut5.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Güncellenmiştir");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter dv = new SqlDataAdapter("select * from tbl_duyuru", bgl.baglanti());
            dv.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand komut6 = new SqlCommand("DELETE FROM tbl_ogrenci_g WHERE ogradsoyad = @p1 AND ogrno = @p2", bgl.baglanti());
            komut6.Parameters.AddWithValue("@p1", textBox1.Text);
            komut6.Parameters.AddWithValue("@p2", textBox2.Text.ToString());
            komut6.ExecuteNonQuery();
            MessageBox.Show("Kaydınız silinmiştir");
        }

        private void lbladsoyad_Click(object sender, EventArgs e)
        {

        }
    }
}
