using Microsoft.AspNetCore.Mvc;
using AplicacaoWebCantina.Models.Clientes;
using AplicacaoCantina.Utils.Entidades;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI;

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

        [HttpGet("api/v1/Clientes")]
        public IActionResult Get()
        {
            var result = new Cliente().GetAll().Select(cliente => new ClienteModel(cliente));
           
            return Ok(result);
        }

        [HttpPost("api/v1/Cliente")]
        public IActionResult Post([FromBody]ClienteModel cliente)
        {
            var clienteEntidade = cliente.GetEntidade();
            clienteEntidade.Create();

            return Ok("Cliente Adicionado");
        }

        [HttpPut("api/v1/Cliente/{id}")]    
        public IActionResult Put(int id, [FromBody] ClienteModel clienteAtualizado)
        {
            var clienteDB = new Cliente().Get(id);
            clienteDB.Nome = clienteAtualizado.Nome ?? clienteDB.Nome;
            clienteDB.Update();

            return Ok("Cliente atualizado!");
        }

        [HttpDelete("api/v1/Clientes/{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = new Cliente().Get(id);
            cliente.Delete();

            return Ok("Cliente Deletado");
        }
    }
}
