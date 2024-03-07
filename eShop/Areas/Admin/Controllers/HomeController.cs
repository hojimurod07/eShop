using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class HomeController(IAuthService authService) : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService = authService;


        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Eror(string? url)
        {
            if (url == null)
            {
                url = "/";
            }
            return View("Eror", url);
        }





    }
}
