using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gurko_proje
{
    internal class sql_baglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan=new SqlConnection("Data Source=FURKAN\\SQLEXPRESS;Initial Catalog=school_project;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
