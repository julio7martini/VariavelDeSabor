using Microsoft.AspNetCore.Mvc;

namespace AplicacaoWebCantina.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
