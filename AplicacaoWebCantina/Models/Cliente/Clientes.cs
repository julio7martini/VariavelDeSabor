namespace AplicacaoWebCantina.Models.Cliente
{
    public class Clientes
    {
        public List<ClienteModel> Cliente{ get; set; }

        public ClientesModel()
        {
            Clientes = new List<ClienteModel>();
        }
    }
}
