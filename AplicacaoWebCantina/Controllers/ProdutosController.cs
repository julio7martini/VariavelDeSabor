using Microsoft.AspNetCore.Mvc;
using AplicacaoWebCantina.Models.Produto;
using AplicacaoWebCantina.Models.Cliente;

namespace AplicacaoWebCantina.Controllers
{
    public class ProdutosController : Controller
    {
        static List<ProdutoModel> _Produtos = new List<ProdutoModel>() {
            new ProdutoModel(){ ID = 1, Nome = "Coxinha", Preco = 5.00 },
            new ProdutoModel(){ ID = 2, Nome = "Pastel de Carne", Preco = 6.50 },
            new ProdutoModel(){ ID = 3, Nome = "Kibe", Preco = 4.00 },
            new ProdutoModel(){ ID = 4, Nome = "Pão de Queijo", Preco = 3.50 },
            new ProdutoModel(){ ID = 5, Nome = "Suco de Laranja", Preco = 4.50 },
            new ProdutoModel(){ ID = 6, Nome = "Refrigerante Lata", Preco = 5.00 },
            new ProdutoModel(){ ID = 7, Nome = "Água Mineral", Preco = 2.50 },
            new ProdutoModel(){ ID = 8, Nome = "Torta de Limão", Preco = 7.00 },
            new ProdutoModel(){ ID = 9, Nome = "Brigadeiro", Preco = 2.00 },
            new ProdutoModel(){ ID = 10, Nome = "Café Expresso", Preco = 3.00 },
        };

        public IActionResult Index()
        {
            var model = new ProdutosModel() { Produtos = _Produtos };
            return View(model);
        }

        public IActionResult Record(long id)
        {
            var model = _Produtos.FirstOrDefault(produto => produto.ID == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Save(ProdutoModel model)
        {
            var produto = _Produtos.FirstOrDefault(i => i.ID == model.ID);

            if (produto != null)
            {
                produto.Nome = model.Nome;
                produto.Preco = model.Preco;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(ProdutoModel model)
        {
            var produto = _Produtos.FirstOrDefault(i => i.ID == model.ID);

            if (produto != null) // Verifica se o produto foi encontrado
            {
                _Produtos.Remove(produto); // Remove o produto da lista
            }

            return RedirectToAction("Index");
        }
    }
}
