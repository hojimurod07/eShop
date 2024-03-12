using eShop.BLL.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class AuthController(IAuthService _authService) : Controller
    {
        private readonly IAuthService _authService = _authService;

        public IActionResult Login()
        {
            LoginDto loginDto = new LoginDto();
            return View(loginDto);
        }
        public IActionResult Register()
        {
            RegisterDto dto = new();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Register(RegisterDto registerDto)
        {
            var result = _authService.CreateUser(registerDto);
            if (result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            else
            {
                registerDto.ErrorMessage = result.ErrorMessage;
                return View(registerDto);
            }
        }

    }
}
