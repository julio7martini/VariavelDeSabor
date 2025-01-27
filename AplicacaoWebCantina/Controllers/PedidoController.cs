using Microsoft.AspNetCore.Mvc;
using AplicacaoWebCantina.Models.Pedido;

namespace AplicacaoWebCantina.Controllers
{
    public class PedidoController : Controller
    {
        // Lista estática para persistir pedidos
        private static Pedidos _pedidos = new Pedidos();

        // Exibe todos os pedidos
        public IActionResult Index()
        {
            var pedidos = _pedidos.ObterTodos();
            return View(pedidos); 
        }

        // Exibe o formulário para adicionar um pedido
        public IActionResult Adicionar()
        {
            return View(new Pedido()); 
        }

        // Processa o pedido para ser adicionado
        [HttpPost]
        public IActionResult Adicionar(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _pedidos.Adicionar(pedido); 
                return RedirectToAction("Index"); 
            }
            return View(pedido); 
        }

        // Exibe o formulário para editar um pedido
        public IActionResult Editar(int id)
        {
            var pedido = _pedidos.ObterPorId(id);
            if (pedido == null)
            {
                return NotFound(); 
            }
            return View(pedido); 
        }

        // Processa a edição do pedido
        [HttpPost]
        public IActionResult Editar(Pedido pedidoAtualizado)
        {
            if (ModelState.IsValid)
            {
                var pedidoExistente = _pedidos.ObterPorId(pedidoAtualizado.Id);
                if (pedidoExistente != null)
                {
                    // Atualiza o pedido na lista
                    pedidoExistente.NomeProduto = pedidoAtualizado.NomeProduto;
                    pedidoExistente.Quantidade = pedidoAtualizado.Quantidade;
                    pedidoExistente.Preco = pedidoAtualizado.Preco;
                    return RedirectToAction("Index"); // Redireciona para a página de listagem de pedidos
                }
                return NotFound(); 
            }
            return View(pedidoAtualizado); 
        }


        [HttpPost]
        public IActionResult Remover(int id)
        {
            var pedido = _pedidos.ObterPorId(id);
            if (pedido != null)
            {
                _pedidos.Remover(id); // Remove o pedido pela ID
            }
            return RedirectToAction("Index"); // Redireciona para a página de listagem de pedidos
        }


    }
}
