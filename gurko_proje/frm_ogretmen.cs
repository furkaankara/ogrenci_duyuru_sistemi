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
    public partial class frm_ogretmen : Form
    {
        public frm_ogretmen()
        {
            InitializeComponent();
        }

        sql_baglantisi bgl=new sql_baglantisi();
        private void frm_ogretmen_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SqlCommand komut = new SqlCommand("select * from tbl_ogretmen_giris where ogrtmnadsoyad=@p1 and ogrtmnTc=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtogrtmnAdSoyad.Text);
            komut.Parameters.AddWithValue("@p2", msktc.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read()) {
                frm_ogrtmen_detay frs = new frm_ogrtmen_detay();
                frs.tc = msktc.Text;
                frs.Show();
                this.Hide();
          
            
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız ");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frm_ogrtmn_kayit fr=new frm_ogrtmn_kayit();
            fr.Show();
        }
    }
}
