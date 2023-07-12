using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gurko_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_ogrenci_giris fr =new frm_ogrenci_giris();
            fr.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_ogretmen fr=new frm_ogretmen();
            fr.Show();
            this.Hide();
        }
    }
}
