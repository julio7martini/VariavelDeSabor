using Microsoft.AspNetCore.Mvc;
using AplicacaoWebCantina.Models.Cliente;
using AplicacaoWebCantina.Models.Clientes;

namespace AplicacaoWebCantina.Controllers
{
    public class ClientesController : Controller
    {
        static List<ClienteModel> _Clientes = new List<ClienteModel>() {
                new ClienteModel(){ Id = 1, Nome = "Ricardo"},
                new ClienteModel(){ Id = 2, Nome = "Bruna"},
                new ClienteModel(){ Id = 3, Nome = "Julio"},
                new ClienteModel(){ Id = 4, Nome = "João"},
                new ClienteModel(){ Id = 5, Nome = "Carlos"},
                new ClienteModel(){ Id = 6, Nome = "Leonardo"},
                new ClienteModel(){ Id = 7, Nome = "José"},
                new ClienteModel(){ Id = 8, Nome = "Lucas"}
            };

        public IActionResult Record(long id)
        {
            var clienteAtual = _Clientes.FirstOrDefault(cliente => cliente.Id == id);

            return View(clienteAtual);
        }

        [HttpPost]
        public IActionResult Save(ClienteModel model)
        {
            var cliente = _Clientes.FirstOrDefault(i => i.Id == model.Id);

            if (cliente == null)
            {
                cliente = new ClienteModel
                {
                    Id = _Clientes.Count > 0 ? _Clientes.Max(c => c.Id) + 1 : 1, // Próximo ID baseado na lista
                    Nome = model.Nome
                };

                _Clientes.Add(cliente);
            }
            else
            {
                cliente.Nome = model.Nome;
            }

            return RedirectToAction("Index");
        }


        public IActionResult Excluir(ClienteModel model)
        {
            var cliente = _Clientes.FirstOrDefault(i => i.Id == model.Id);

            _Clientes.Remove(cliente);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var model = new ClientesModel() { Clientes = _Clientes };

            return View(model);
        }

    }
}
