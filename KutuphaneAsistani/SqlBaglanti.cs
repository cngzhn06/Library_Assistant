using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace KutuphaneAsistani
{
    class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=CENGIZHAN\\SQLEXPRESS; Initial Catalog=master; Integrated Security=TRUE");
            baglanti.Open();
            return baglanti;
        }
        }
}
