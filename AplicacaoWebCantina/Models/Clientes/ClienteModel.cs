using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using AplicacaoCantina.Utils.Entidades;

namespace AplicacaoWebCantina.Models.Clientes
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ClienteModel() { }

        public ClienteModel(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
        }

        public Cliente GetEntidade()
        {
            return new Cliente()
            {
                Id = Id,
                Nome = Nome
            };
        }
    }
}
