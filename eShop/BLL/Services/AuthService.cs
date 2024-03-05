using eShop.BLL.DTOs.UserDtos;

namespace eShop.BLL.Services
{
    public class AuthService(IUnitOfWork unitOfWork) : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public bool IsLoggedIn()
        {
            throw new NotImplementedException();
        }

        public AuthResult Login(LoginDto logindto)
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
