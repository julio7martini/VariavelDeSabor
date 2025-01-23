using AplicacaoWebCantina.Models.Produto;

namespace AplicacaoWebCantina.Models.Estoque
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; } // Referência ao Produto
        public Produto.Produto Produto { get; set; }
        public int QuantidadeAtual { get; set; }
        public int QuantidadeMinima { get; set; } // Quantidade mínima para alerta de reposição
        public DateTime DataUltimaReposicao { get; set; }
    }
}
