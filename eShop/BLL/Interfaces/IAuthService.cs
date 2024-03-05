
using eShop.BLL.DTOs.UserDtos;

namespace eShop.BLL.Interfaces
{
    public interface IAuthService
    {

        AuthResult Login(LoginDto logindto);
        bool IsLoggedIn();
        void Logout();


    }
}
