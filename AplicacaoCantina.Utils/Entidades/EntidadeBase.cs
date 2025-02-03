using AplicacaoCantina.Utils.Database;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCantina.Utils.Entidades
{
    public abstract class EntidadeBase
    {
        public int Id {  get; set; }
        protected abstract string TableName { get; }

        public void Delete()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.Parameters.Add(new MySqlParameter("pId", Id));
                cmd.CommandText = @$"DELETE FROM {TableName} WHERE ID = @pID";
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT * FROM {TableName} WHERE ID = {id}";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("ID", id));
                Console.WriteLine(TableName, " ", Id);

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
    }
}
