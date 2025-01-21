namespace AplicacaoWebCantina.Models.Estoque
{
    public class Estoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; } // Referência ao Produto
        public int QuantidadeAtual { get; set; }
        public int QuantidadeMinima { get; set; } // Quantidade mínima para alerta de reposição
        public DateTime DataUltimaReposicao { get; set; }
    }
}
