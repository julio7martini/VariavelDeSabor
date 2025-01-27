using AplicacaoWebCantina.Models.Estoque;
using AplicacaoWebCantina.Models.Produto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicacaoWebCantina.Controllers
{
    public class EstoqueController : Controller
    {
        // Dados mocados
        private static List<EstoqueModel> Estoques = new List<EstoqueModel>
{
            new EstoqueModel { ID = 1, ProdutoId = 101, QuantidadeAtual = 50, QuantidadeMinima = 10, DataUltimaReposicao = DateTime.Now.AddMonths(-1) },
            new EstoqueModel { ID = 2, ProdutoId = 102, QuantidadeAtual = 5, QuantidadeMinima = 10, DataUltimaReposicao = DateTime.Now.AddMonths(-2) },
            new EstoqueModel { ID = 3, ProdutoId = 103, QuantidadeAtual = 200, QuantidadeMinima = 100, DataUltimaReposicao = DateTime.Now.AddMonths(-3) },
            new EstoqueModel { ID = 4, ProdutoId = 104, QuantidadeAtual = 15, QuantidadeMinima = 5, DataUltimaReposicao = DateTime.Now.AddMonths(-1) },
            new EstoqueModel { ID = 5, ProdutoId = 105, QuantidadeAtual = 30, QuantidadeMinima = 10, DataUltimaReposicao = DateTime.Now.AddMonths(-6) },
            new EstoqueModel { ID = 6, ProdutoId = 106, QuantidadeAtual = 75, QuantidadeMinima = 20, DataUltimaReposicao = DateTime.Now.AddMonths(-4) },
            new EstoqueModel { ID = 7, ProdutoId = 107, QuantidadeAtual = 45, QuantidadeMinima = 20, DataUltimaReposicao = DateTime.Now.AddMonths(-2) },
            new EstoqueModel { ID = 8, ProdutoId = 108, QuantidadeAtual = 300, QuantidadeMinima = 150, DataUltimaReposicao = DateTime.Now.AddMonths(-5) },
            new EstoqueModel { ID = 9, ProdutoId = 109, QuantidadeAtual = 80, QuantidadeMinima = 30, DataUltimaReposicao = DateTime.Now.AddMonths(-7) },
            new EstoqueModel { ID = 10, ProdutoId = 110, QuantidadeAtual = 60, QuantidadeMinima = 25, DataUltimaReposicao = DateTime.Now.AddMonths(-3) }

};

        // Mostrar a View do estoque
        public IActionResult Index()
        {
            foreach (var estoque in Estoques)
            {
                estoque.Produto = new ProdutoModel { ID = estoque.ProdutoId, Nome = "Produto " + estoque.ProdutoId };
            }

            return View(Estoques);
        }

        public IActionResult Edit(int id)
        {
            var estoque = Estoques.FirstOrDefault(e => e.ID == id);
            if (estoque == null)
                return NotFound();

            var produto = new ProdutoModel { ID = estoque.ProdutoId, Nome = "Produto " + estoque.ProdutoId };

            estoque.Produto = produto;  

            return View(estoque);
        }


        [HttpPost]
        public IActionResult Edit(EstoqueModel estoque)
        {
                var estoqueExistente = Estoques.FirstOrDefault(e => e.ID == estoque.ID);
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
