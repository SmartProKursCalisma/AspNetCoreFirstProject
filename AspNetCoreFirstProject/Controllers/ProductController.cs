using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFirstProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
