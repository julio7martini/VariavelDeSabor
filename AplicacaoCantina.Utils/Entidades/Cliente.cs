using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoCantina.Utils.Database;
using MySqlX.XDevAPI.Common;

namespace AplicacaoCantina.Utils.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static Cliente Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConenection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT ID, NOME FROM CLIENTE WHERE ID = {id}";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read()) 
                {
                    return new Cliente
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME")
                    };
                }
            }
            return null;
        }

        public static List<Cliente> GetAll()
        {
            var result = new List<Cliente>(); 

            using (MySqlConnection conn = new MySqlConnection(DBConenection.CONNECTION_STRING))
            {
                conn.Open();
                var query = "SELECT ID, NOME FROM CLIENTE";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Cliente()
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME")
                    });
                }
            }
            return result;
        }
    }
}
