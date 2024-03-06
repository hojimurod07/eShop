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
            var isLogidIn = _authService.IsLoggedIn();
            if (isLogidIn)
            {
                return View();
            }
            return RedirectToAction("login");
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
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result.IsSuccess)
            {

                return RedirectToAction("Index");
            }
            dto.Eror = result.ErrorMessage;

            return View(dto);
        }


    }
}
