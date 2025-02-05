using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoCantina.Utils.Database;
using MySqlX.XDevAPI.Common;
using System.Numerics;

namespace AplicacaoCantina.Utils.Entidades
{
    public class Cliente : EntidadeBase<Cliente>
    {
        protected override string TableName => "CLIENTE";
        protected override List<string> Fields => new List<string>()
        {
            "ID",
            "NOME",
        };
        public string Nome { get; set; }

        protected override Cliente Fill(MySqlDataReader reader)
        {
            var aux = new Cliente();

            aux.ID = reader.GetInt32("ID");
            aux.Nome = reader.GetString("NOME");

            return aux;
        }

        public void Create()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"INSERT INTO {TableName} (NOME) 
                                        VALUES (@pNOME)";

                cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));

                cmd.ExecuteNonQuery();
            }
        }

        protected override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pNOME", Nome));
        }
    }
}
