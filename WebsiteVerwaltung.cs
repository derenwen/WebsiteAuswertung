using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.IO;
using System.Data.SqlClient;


namespace Websiteauswertung
{
    class WebsiteVerwaltung
    {

        private static int max = 10;

        internal DB_Connection dbc = new DB_Connection();
        internal List<string> WebsitenAuswertung = new List<string>();
        internal string[] domains = new string[max];
        internal double[] amounts = new double[max];

        public void getWebsiteDaten()
        {
            dbc.conOpen();
            DataTable st = dbc.getData("SELECT domain,amount FROM traffic ORDER BY amount DESC LIMIT " + max + ";");
            dbc.conClose();

            int count = st.Rows.Count > max ? max : st.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                domains[i] = st.Rows[i].Field<string>("domain");
                amounts[i] = st.Rows[i].Field<int>("amount");
            }
        }
    }
}
