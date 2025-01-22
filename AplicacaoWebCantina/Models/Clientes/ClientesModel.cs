using AplicacaoWebCantina.Models.Cliente;

namespace AplicacaoWebCantina.Models.Clientes
{
    public class ClientesModel
    {
        public List<ClienteModel> Clientes { get; set; }

        public ClientesModel()
        {
            Clientes = new List<ClienteModel>();
        }
    }
}
