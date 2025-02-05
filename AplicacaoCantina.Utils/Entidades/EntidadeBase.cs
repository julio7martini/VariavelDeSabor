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
    public abstract class EntidadeBase<T>
    {
        public int Id {  get; set; }
        protected abstract string TableName { get; }

        protected abstract List<string> Fields { get; }

        protected abstract T Fill(MySqlDataReader reader);
        protected abstract void FillParameters(MySqlParameterCollection parameters);

        public T Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT {string.Join(", ", Fields)} FROM {TableName} WHERE ID = @ID";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Fill(reader);
                }
            }

            return default(T);
        }

        public List<T> GetAll()
        {
            var result = new List<T>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT {string.Join(", ", Fields)} FROM CLIENTE";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(Fill(reader));
                }
            }

            return result;
        }

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


        //public void Create()
        //{
        //    using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        cmd.CommandText = $"INSERT INTO {TableName} (NOME) VALUE (@pNOME)";
        //        cmd.Parameters.Add(new MySqlParameter("pNome", Nome));
        //        cmd.ExecuteNonQuery();

        //    }
        //}
        
    }
}
