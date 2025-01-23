using AplicacaoWebCantina.Models.Produto;


namespace AplicacaoWebCantina.Models.Produto
{
    public class ProdutosModel
    {
        public List<ProdutoModel> Produtos { get; set; }

        public ProdutosModel()
        {
            Produtos = new List<ProdutoModel>();
        }
    }
}
