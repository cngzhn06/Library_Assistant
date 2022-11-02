using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Helper
{
    class Helper
    {

        public static void showMessage(string mesaj,string icon)
        { }

        public DataTable SetColumnsHeaderName(string[] TagName)
        {
            DataTable dt = new DataTable();
            foreach (var item in TagName)
            {
                dt.Columns.Add(item);
            }
            return dt;
        }

    }
}
