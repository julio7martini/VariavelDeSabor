using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCantina.Utils.Database
{
    public class DBConenection
    {
        public const string CONNECTION_STRING = "Server=localhost;Database=mydb;User ID=root;Password=senha;";

        public static bool TestarConexao()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConenection.CONNECTION_STRING))
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
