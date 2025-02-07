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
    public class Produto : EntidadeBase<Produto>
    {
        protected override string TableName => "PRODUTO";
        protected override List<string> Fields => new List<string>()
        {
            "ID",
            "NOME",
            "PRECO",
        };
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        protected override Produto Fill(MySqlDataReader reader)
        {
            var aux = new Produto();

            aux.ID = reader.GetInt32("ID");
            aux.Nome = reader.GetString("NOME");
            aux.Preco = reader.GetDecimal("PRECO");

            return aux;
        }

        public void Create()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"INSERT INTO {TableName} (NOME,PRECO)
                                        VALUES (@pNOME,@pPRECO)";

                cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
                cmd.Parameters.Add(new MySqlParameter("pPRECO", Preco));


                cmd.ExecuteNonQuery();
            }
        }

        protected override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pNOME", Nome));
            parameters.Add(new MySqlParameter("pPRECO", Preco));

        }
    }
}
