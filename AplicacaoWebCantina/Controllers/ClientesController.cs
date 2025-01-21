using Microsoft.AspNetCore.Mvc;

namespace AplicacaoWebCantina.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
