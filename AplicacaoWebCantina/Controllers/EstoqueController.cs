using Microsoft.AspNetCore.Mvc;

namespace AplicacaoWebCantina.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
