using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace Websiteauswertung
{
    class DB_Connection
    {


        string connectionString = "Server = deren-pi.local; Database = db_networksniffing; UiD = tcpdumpread; Pwd = Ws1nSdOT;";

        MySqlConnection con = new MySqlConnection();

        public void conOpen()
        {
            try
            {
                con.ConnectionString = connectionString;
                con.Open();
                Console.WriteLine("Connection established!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void conClose()
        {

            con.Close();
        }

        public DataTable getData(string query)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            return dt;
        }

        private static void setData(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}