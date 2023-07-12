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
    public partial class frm_ogrenci_detay : Form
    {
        public frm_ogrenci_detay()
        {
            InitializeComponent();
        }
        public string okulno;
        sql_baglantisi bgl=new sql_baglantisi();
        private void frm_ogrenci_detay_Load(object sender, EventArgs e)
        {
            label3.Text = okulno.ToString();

            SqlCommand komut = new SqlCommand("select ogradsoyad from tbl_ogrenci_g where ogrno=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label3.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label2.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_duyuru ",bgl.baglanti());
            bgl.baglanti();
            da.Fill(dt);    
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
