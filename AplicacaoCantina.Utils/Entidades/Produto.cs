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
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public static Produto Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT ID, NOME, PRECO FROM PRODUTO WHERE ID = @ID";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Produto
                    {
                        ID = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        Preco = reader.GetDouble("PRECO")

                    };
                }
            }

            return null;
        }

        public static List<Produto> GetAll()
        {
            var result = new List<Produto>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = "SELECT ID, NOME, PRECO  FROM PRODUTO";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Produto()
                    {
                        ID = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        Preco = reader.GetDouble("PRECO"),
                    });
                }
            }

            return result;
        }

        public void Create()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO PRODUTO (NOME, PRECO) 
                                    VALUES (@pNOME, @pPRECO)";

                cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
                cmd.Parameters.Add(new MySqlParameter("pPRECO", Preco));

                cmd.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"UPDATE PRODUTO SET NOME = @pNOME, PRECO = @pPRECO
                                    WHERE ID = @pID";

                cmd.Parameters.Add(new MySqlParameter("pID", ID));
                cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
                cmd.Parameters.Add(new MySqlParameter("pPRECO", Preco));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.Parameters.Add(new MySqlParameter("pID", ID));
                cmd.CommandText = @$"DELETE FROM PRODUTO WHERE ID = @pID";

                cmd.ExecuteNonQuery();
            }
        }
    }
}