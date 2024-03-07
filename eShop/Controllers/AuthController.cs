using eShop.BLL.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            LoginDto loginDto = new LoginDto();
            return View(loginDto);
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
