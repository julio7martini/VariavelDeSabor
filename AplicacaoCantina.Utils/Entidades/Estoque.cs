using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoCantina.Utils.Database;

namespace AplicacaoCantina.Utils.Entidades
{
    public class Estoque : EntidadeBase<Estoque>
    {
        protected override string TableName => "ESTOQUE";

        protected override List<string> Fields => new List<string>()
        {
            "ID",
            "PRODUTO_ID",
            "QUANTIDADE_ATUAL",
            "QUANTIDADE_MINIMA",
            "DATA_ULTIMA_REPOSICAO"
        };

        public int ProdutoId { get; set; }
        public int QuantidadeAtual { get; set; }
        public int QuantidadeMinima { get; set; }
        public DateTime DataUltimaReposicao { get; set; }

        public Produto Produto { get; set; } // Relacionamento com a classe Produto

        protected override Estoque Fill(MySqlDataReader reader)
        {
            var aux = new Estoque();

            aux.ID = reader.GetInt32("ID");
            aux.ProdutoId = reader.GetInt32("PRODUTO_ID");
            aux.QuantidadeAtual = reader.GetInt32("QUANTIDADE_ATUAL");
            aux.QuantidadeMinima = reader.GetInt32("QUANTIDADE_MINIMA");
            aux.DataUltimaReposicao = reader.GetDateTime("DATA_ULTIMA_REPOSICAO");

            // preencher a propriedade Produto com base no ProdutoId
            aux.Produto = new Produto().Get(aux.ProdutoId); // Deve ter um Get para obter o produto com base no ID

            return aux;
        }

        public void Create()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"INSERT INTO {TableName} (PRODUTO_ID, QUANTIDADE_ATUAL, QUANTIDADE_MINIMA, DATA_ULTIMA_REPOSICAO)
                                        VALUES (@pPRODUTO_ID, @pQUANTIDADE_ATUAL, @pQUANTIDADE_MINIMA, @pDATA_ULTIMA_REPOSICAO)";

                cmd.Parameters.Add(new MySqlParameter("pPRODUTO_ID", ProdutoId));
                cmd.Parameters.Add(new MySqlParameter("pQUANTIDADE_ATUAL", QuantidadeAtual));
                cmd.Parameters.Add(new MySqlParameter("pQUANTIDADE_MINIMA", QuantidadeMinima));
                cmd.Parameters.Add(new MySqlParameter("pDATA_ULTIMA_REPOSICAO", DataUltimaReposicao));

                cmd.ExecuteNonQuery();
            }
        }

        protected override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pPRODUTO_ID", ProdutoId));
            parameters.Add(new MySqlParameter("pQUANTIDADE_ATUAL", QuantidadeAtual));
            parameters.Add(new MySqlParameter("pQUANTIDADE_MINIMA", QuantidadeMinima));
            parameters.Add(new MySqlParameter("pDATA_ULTIMA_REPOSICAO", DataUltimaReposicao));
        }
    }
}
