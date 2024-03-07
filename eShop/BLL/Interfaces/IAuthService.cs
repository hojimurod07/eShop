
using eShop.BLL.DTOs.UserDtos;

namespace eShop.BLL.Interfaces
{
    public interface IAuthService
    {

        Task<AuthResult> LoginAsync(LoginDto logindto);
        bool IsLoggedIn();
        void Logout();


    }
}
