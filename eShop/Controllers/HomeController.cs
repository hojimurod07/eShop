using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
