using System.Numerics;
using AplicacaoCantina.Utils.Entidades;

namespace AplicacaoWebCantina.Models.Produtos
{

    public class ProdutoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }

        public ProdutoModel() { }

        public ProdutoModel(Produto produto)
        {
            ID = produto.ID;
            Nome = produto.Nome;
            Preco = produto.Preco;
        }

        public Produto GetEntidade()
        {
            return new Produto()
            {
                ID = ID,
                Nome = Nome,
                Preco = Preco
            };
        }
    }
}