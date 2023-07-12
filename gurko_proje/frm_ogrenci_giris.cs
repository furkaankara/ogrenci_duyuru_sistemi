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
    public partial class frm_ogrenci_giris : Form
    {
        public frm_ogrenci_giris()
        {
            InitializeComponent();
        }
        sql_baglantisi bgl =new sql_baglantisi();
        private void frm_ogrenci_giris_Load(object sender, EventArgs e)

        {
           
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_ogrenci_g where ogradsoyad=@p1 and ogrno=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtadsoyad.Text);
            komut.Parameters.AddWithValue("@p2", txtokulno.Text.ToString());
          
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frm_ogrenci_detay fr=new frm_ogrenci_detay();
                fr.okulno = txtokulno.Text;
                fr.Show();
                  
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı giriş");
            }
            bgl.baglanti().Close()
;        }
    }
}
