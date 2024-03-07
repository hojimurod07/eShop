using eShop.BLL.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Areas.Admin.Controllers
{

    [Area("admin")]

    public class AuthController(IAuthService authService)
        : Controller
    {
        private readonly IAuthService _authService = authService;

        public IActionResult Login()
        {
            LoginDto dto = new();
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto, Role.Admin);
            if (result.IsSuccess)
            {
                return RedirectToAction("index", "home");
            }

            dto.Eror = result.ErrorMessage;
            return View(dto);
        }

        public IActionResult Logout()
        {
            _authService.Logout(Role.Admin);
            return RedirectToAction("login");
        }
    }
}