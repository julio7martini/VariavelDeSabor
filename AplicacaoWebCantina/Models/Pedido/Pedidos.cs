namespace AplicacaoWebCantina.Models.Pedido
{
    public class Pedidos
    {
        public List<Pedido> Lista { get; set; } = new List<Pedido>();


        //Retorna os pedidos
        public IEnumerable<Pedido> ObterTodos()
        {
            return Lista;
        }

        //Retornar um pedido pelo Id
        public Pedido ObterPorId(int id)
        {
            foreach (var pedido in Lista)
            {
                if (pedido.Id == id)
                {
                    return pedido;
                }


            }
            return null; //Retorna nullo se nao encontra nada
        }

        //Adicionar um pedido
        public void Adicionar (Pedido pedido)
        {
            pedido.Id = Lista.Count + 1;
            Lista.Add(pedido);
        }

        //Remove um pedido pelo id
        //Remove um pedido pelo id
        public void Remover(int id)
        {
            var pedido = ObterPorId(id);
            if (pedido != null) // Verifica se o pedido existe
            {
                Lista.Remove(pedido); // Remove o pedido da lista
            }
        }

        //Edita um pedido que existe já
        public void Editar (Pedido pedidoAtualizado)
        {
            var Pedido = ObterPorId(pedidoAtualizado.Id);
            if (Pedido == null) 
            {
            Pedido.NomeProduto = pedidoAtualizado.NomeProduto;
            Pedido.Quantidade = pedidoAtualizado.Quantidade;
            Pedido.Preco = pedidoAtualizado.Preco;
            
            }
        }

    }
}
