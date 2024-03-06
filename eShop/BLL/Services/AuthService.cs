using eShop.BLL.DTOs.UserDtos;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace eShop.BLL.Services
{
    public class AuthService(IUnitOfWork unitOfWork,
                            IHttpContextAccessor httpContextAccess) : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccess = httpContextAccess;

        public bool IsLoggedIn()
        {
            return _httpContextAccess.HttpContext!.User.Identity!.IsAuthenticated;
        }

        public async Task<AuthResult> LoginAsync(LoginDto logindto)
        {
            if (logindto == null)
            {
                return new()
                {
                    IsSuccess = false,
                    ErrorMessage = "Logindto is null"
                };
            }
            var user = _unitOfWork.Users.GetAll().FirstOrDefault(u => u.Phone == logindto.PhoneNumber);
            if (user == null)
            {
                return new()
                {
                    IsSuccess = false,
                    ErrorMessage = "User not found"
                };

            }
            if (user.Password != logindto.Passsword)
            {
                return new()
                {
                    IsSuccess = false,
                    ErrorMessage = "Password is Incorrecr"
                };
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Role, "User")
            };
            var identity = new ClaimsIdentity(claims, "ApplicationCookie");
            var principal = new ClaimsPrincipal(identity);




            if (logindto.RememberMe)
            {
                await _httpContextAccess.HttpContext!.SignInAsync("ApplicationCookie", principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMonths(1)
                });
            }
            else
            {
                await _httpContextAccess.HttpContext!.SignInAsync("ApplicationCookie", principal);
            }


            return new()
            {
                IsSuccess = true,
            };

        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
