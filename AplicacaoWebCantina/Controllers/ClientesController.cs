using Microsoft.AspNetCore.Mvc;
using AplicacaoWebCantina.Models.Clientes;
using AplicacaoCantina.Utils.Entidades;

namespace AplicacaoWebCantina.Controllers
{
    public class ClientesController : Controller
    {

        public IActionResult record(ClienteModel model)
        {

            return View(model);
        }

        [HttpPost]
        public IActionResult save(ClienteModel model)
        {
            Cliente cliente = model.GetEntidade();

            if (model.Id > 0)
            {
                cliente.Update();
            }
            else
            {
                cliente.Create();
            }
            return RedirectToAction("index");
        }


        public IActionResult excluir(ClienteModel model)
        {
            Cliente cliente = model.GetEntidade();
            cliente.Delete();

            return RedirectToAction("index");
        }

        public IActionResult Index()
        {
            var model = new ClientesModel();
            model.Clientes = new List<ClienteModel>();

            var clientes = new Cliente().GetAll();

            model.Clientes = clientes.Select(clienteEntidade => new ClienteModel(clienteEntidade)).ToList();

            return View(model);
        }

    }
}
