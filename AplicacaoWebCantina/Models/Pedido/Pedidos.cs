using AplicacaoCantina.Utils.Entidades;
using System;
using System.Collections.Generic;

namespace AplicacaoCantina.Models
{
    public class PedidoModel
    {
        public List<Pedido> GetAllPedidos()
        {
            var pedido = new Pedido();
            return pedido.GetAll();
        }

        public Pedido GetPedidoById(int id)
        {
            var pedido = new Pedido();
            return pedido.Get(id);
        }

        public void CreatePedido(Pedido pedido)
        {
            pedido.Create();
        }

        public void UpdatePedido(Pedido pedido)
        {
            pedido.Update();
        }

        public void DeletePedido(int id)
        {
            var pedido = new Pedido { ID = id };
            pedido.Delete();
        }
    }
}
