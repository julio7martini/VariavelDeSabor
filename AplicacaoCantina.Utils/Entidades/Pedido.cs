using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using AplicacaoCantina.Utils.Database;

namespace AplicacaoCantina.Utils.Entidades
{
    public class Pedido : EntidadeBase<Pedido>
    {
        public int ClienteID { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }

        protected override string TableName => "Pedido";
        protected override List<string> Fields => new List<string> { "ID", "DATA_PEDIDO", "VALOR_TOTAL", "CLIENTE_ID" };

        protected override Pedido Fill(MySqlDataReader reader)
        {
            return new Pedido
            {
                ID = reader.GetInt32("ID"),
                ClienteID = reader.GetInt32("CLIENTE_ID"),
                DataPedido = reader.GetDateTime("DATA_PEDIDO"),
                ValorTotal = reader.GetDecimal("VALOR_TOTAL")
            };
        }

        protected override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pID", ID));  // Verifique se o ID está sendo atribuído corretamente
            parameters.Add(new MySqlParameter("pCLIENTE_ID", ClienteID));
            parameters.Add(new MySqlParameter("pDATA_PEDIDO", DataPedido));
            parameters.Add(new MySqlParameter("pVALOR_TOTAL", ValorTotal));
        }
    }
}
