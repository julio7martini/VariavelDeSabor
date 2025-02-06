using Microsoft.AspNetCore.Mvc;
using AplicacaoWebCantina.Models.Produtos;
using AplicacaoCantina.Utils.Entidades;

namespace AplicacaoWebCantina.Controllers
{
    public class ProdutosController : Controller
    {

        public IActionResult record(ProdutoModel model)
        {

            return View(model);
        }

        [HttpPost]
        public IActionResult save(ProdutoModel model)
        {
            Produto produto = model.GetEntidade();

            if (model.ID > 0)
            {
                produto.Update();
            }
            else
            {
                produto.Create();
            }
            return RedirectToAction("index");
        }


        public IActionResult excluir(ProdutoModel model)
        {
            Produto produto = model.GetEntidade();
            produto.Delete();

            return RedirectToAction("index");
        }

        public IActionResult Index()
        {
            var model = new ProdutosModel();
            model.Produtos = new List<ProdutoModel>();

            var produtos = new Produto().GetAll();

            model.Produtos = produtos.Select(produtoEntidade => new ProdutoModel(produtoEntidade)).ToList();

            return View(model);
        }

    }
}
