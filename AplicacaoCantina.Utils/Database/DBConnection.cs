using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCantina.Utils.Database
{
    public class DBConnection
    {
        public const string CONNECTION_STRING = "Server=localhost;Database=mydb;User ID=root;Password=root";

        public static bool TestarConexao()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
                { 
                    conn.Open(); 
                    return true;
               }
            }
            catch
            {
                return false;
            }
        }
    }
}
