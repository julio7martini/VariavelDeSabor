using Microsoft.AspNetCore.Mvc;
using AplicacaoWebCantina.Models.Produto;
using AplicacaoCantina.Utils.Entidades;
using AplicacaoCantina.Models.Produto;

namespace AplicacaoWebCantina.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            var model = new ProdutosModel();
            model.Produtos = new List<ProdutoModel>();

            var produtos = Produto.GetAll();

           
            model.Produtos = produtos.Select(produtoEntidade => new ProdutoModel(produtoEntidade)).ToList();

            return View(model);
        }

        private string? ProdutosModel()
        {
            throw new NotImplementedException();
        }

        public IActionResult Record(int? id)
        {
            var model = new ProdutoModel();

            if (id.HasValue)
            {
                model = new ProdutoModel(Produto.Get(id.Value));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Record(ProdutoModel model, string type)
        {
            Produto produto = model.GetEntidade();
            if (type == "save")
            {
                if (produto.ID > 0)
                {
                    produto.Update();
                }
                else
                {
                    produto.Create();
                }
            }
            else if (type == "delete")
            {
                produto.Delete();
            }
            else
            {
                return BadRequest("Requisição inválida!");
            }

            return RedirectToAction("Index");
        }
    }
}