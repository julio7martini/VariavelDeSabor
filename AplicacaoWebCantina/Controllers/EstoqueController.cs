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
             new EstoqueModel { Id = 1, ProdutoId = 101, QuantidadeAtual = 50, QuantidadeMinima = 10, DataUltimaReposicao = DateTime.Now.AddMonths(-1) },
             new EstoqueModel { Id = 2, ProdutoId = 102, QuantidadeAtual = 5, QuantidadeMinima = 10, DataUltimaReposicao = DateTime.Now.AddMonths(-2) }
};

        // Mostrar a View do estoque
        public IActionResult Index()
        {
            foreach (var estoque in Estoques)
            {
                estoque.Produto = new Produto { Id = estoque.ProdutoId, Nome = "Produto " + estoque.ProdutoId };
            }

            return View(Estoques);
        }

        public IActionResult Edit(int id)
        {
            var estoque = Estoques.FirstOrDefault(e => e.Id == id);
            if (estoque == null)
                return NotFound();

            var produto = new Produto { Id = estoque.ProdutoId, Nome = "Produto " + estoque.ProdutoId };

            estoque.Produto = produto;  

            return View(estoque);
        }


        [HttpPost]
        public IActionResult Edit(EstoqueModel estoque)
        {
            if (ModelState.IsValid)
            {
                var estoqueExistente = Estoques.FirstOrDefault(e => e.Id == estoque.Id);
                if (estoqueExistente != null)
                {
                    estoqueExistente.QuantidadeAtual = estoque.QuantidadeAtual;
                    estoqueExistente.DataUltimaReposicao = estoque.DataUltimaReposicao;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estoque);
        }
    }
}
