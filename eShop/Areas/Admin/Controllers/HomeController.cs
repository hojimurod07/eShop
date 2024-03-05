using eShop.BLL.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Areas.Admin.Controllers
{
    [Area("Admin")]
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


        public IActionResult Login()
        {
            LoginDto loginDto = new LoginDto();

            return View(loginDto);
        }
        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            var result = _authService.Login(dto);
            if (result.IsSuccess)
            {

                return RedirectToAction("Index");
            }
            dto.Eror = result.ErrorMessage;

            return View(dto);
        }


    }
}
