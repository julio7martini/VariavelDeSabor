using Microsoft.AspNetCore.Mvc;
using AplicacaoWebCantina.Models.Produtos;
using AplicacaoCantina.Utils.Entidades;
using AplicacaoWebCantina.Models.Clientes;

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

        [HttpGet("api/v1/Produtos")]
        public IActionResult Get()
        {
            var result = new Produto().GetAll().Select(produto => new ProdutoModel(produto));

            return Ok(result);
        }

        [HttpPost("api/v1/Produto")]
        public IActionResult Post([FromBody] ProdutoModel produto)
        {
            var produtoEntidade = produto.GetEntidade();
            produtoEntidade.Create();

            return Ok("Produto Adicionado");
        }

        [HttpPut("api/v1/Produto/{id}")]
        public IActionResult Put(int id, [FromBody] ProdutoModel produtoAtualizado)
        {
            var produtoDB = new Produto().Get(id);
            produtoDB.Nome = produtoAtualizado.Nome ?? produtoDB.Nome;
            produtoDB.Update();

            return Ok("Produto atualizado!");
        }

        [HttpDelete("api/v1/Produtos/{id}")]
        public IActionResult Delete(int id)
        {
            var produto = new Produto().Get(id);
            produto.Delete();

            return Ok("Produto Deletado");
        }
    }
}
