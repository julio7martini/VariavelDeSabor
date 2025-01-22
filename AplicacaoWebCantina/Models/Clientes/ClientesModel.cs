namespace AplicacaoWebCantina.Models.Cliente
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
