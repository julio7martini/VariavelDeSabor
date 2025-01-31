using AplicacaoCantina.Utils.Entidades;

namespace AplicacaoWebCantina.Models.Produto

{
    public class ProdutoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public ProdutoModel()
        {

        }

        public ProdutoModel(AplicacaoCantina.Utils.Entidades.Produto produto)
        {
            ID = produto.ID;
            Nome = produto.Nome;
            Preco = produto.Preco;
        }

        public AplicacaoCantina.Utils.Entidades.Produto GetEntidade()
        {
            return new AplicacaoCantina.Utils.Entidades.Produto()
            {
                ID = ID,
                Nome = Nome,
                Preco = Preco,            };
        }
    }
}