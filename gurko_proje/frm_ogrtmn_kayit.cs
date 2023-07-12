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
    public partial class frm_ogrtmn_kayit : Form
    {
        public frm_ogrtmn_kayit()
        {
            InitializeComponent();
        }

        sql_baglantisi bgl=new sql_baglantisi();
        private void frm_ogrtmn_kayit_Load(object sender, EventArgs e)
        {
            
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_ogretmen_giris (ogrtmnadsoyad,ogrtmntc) values(@p1,@p2)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", maskedTextBox1.Text.ToString());
            cmd.ExecuteNonQuery();
            MessageBox.Show("kaydınız başarıyla oluşmuştur");
        }
    }
}
