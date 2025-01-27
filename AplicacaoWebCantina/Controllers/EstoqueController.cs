using AplicacaoWebCantina.Models.Estoque;
using AplicacaoWebCantina.Models.Produto;
using Microsoft.AspNetCore.Mvc;

namespace AplicacaoWebCantina.Controllers
{
    public class EstoqueController : Controller
    {
        // Dados mocados
        private static List<EstoqueModel> Estoques = new List<EstoqueModel>
        {
            new EstoqueModel { ID = 1, ProdutoId = 101, QuantidadeAtual = 50, QuantidadeMinima = 10, DataUltimaReposicao = DateTime.Now.AddMonths(-1) },
            new EstoqueModel { ID = 2, ProdutoId = 102, QuantidadeAtual = 5, QuantidadeMinima = 10, DataUltimaReposicao = DateTime.Now.AddMonths(-2) },
            new EstoqueModel { ID = 3, ProdutoId = 103, QuantidadeAtual = 30, QuantidadeMinima = 15, DataUltimaReposicao = DateTime.Now.AddMonths(-3) },
            new EstoqueModel { ID = 4, ProdutoId = 104, QuantidadeAtual = 12, QuantidadeMinima = 8, DataUltimaReposicao = DateTime.Now.AddMonths(-4) },
            new EstoqueModel { ID = 5, ProdutoId = 105, QuantidadeAtual = 20, QuantidadeMinima = 5, DataUltimaReposicao = DateTime.Now.AddMonths(-5) },
            new EstoqueModel { ID = 6, ProdutoId = 106, QuantidadeAtual = 45, QuantidadeMinima = 20, DataUltimaReposicao = DateTime.Now.AddMonths(-6) },
            new EstoqueModel { ID = 7, ProdutoId = 107, QuantidadeAtual = 25, QuantidadeMinima = 10, DataUltimaReposicao = DateTime.Now.AddMonths(-7) }
        };

        public IActionResult Index()
        {
            // Associando produtos fictícios aos estoques
            foreach (var estoque in Estoques)
            {
                estoque.Produto = new ProdutoModel
                {
                    ID = estoque.ProdutoId,
                    Nome = "Produto " + estoque.ProdutoId,
                    Preco = (double)(10.00m + estoque.ProdutoId)  
                };
            }

            return View(Estoques);
        }

        public IActionResult Edit(int id)
        {
            var estoque = Estoques.FirstOrDefault(e => e.ID == id);
            if (estoque == null)
                return NotFound();

            var produto = new ProdutoModel { ID = estoque.ProdutoId, Nome = "Produto " + estoque.ProdutoId, Preco = (double)(10.00m + estoque.ProdutoId) };
            estoque.Produto = produto;

            return View(estoque);
        }

        [HttpPost]
        public IActionResult Edit(EstoqueModel estoque)
        {
                var estoqueExistente = Estoques.FirstOrDefault(i => i.ID == estoque.ID);
                if (estoqueExistente != null)
                {
                    estoqueExistente.QuantidadeAtual = estoque.QuantidadeAtual;
                    estoqueExistente.QuantidadeMinima = estoque.QuantidadeMinima;
                    estoqueExistente.DataUltimaReposicao = estoque.DataUltimaReposicao;

                }
                     return RedirectToAction("Index");

        }


    }
}
