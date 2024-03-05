namespace eShop.BLL.DTOs.UserDtos
{
    public class LoginDto
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string Passsword { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
        public string Eror { get; set; } = string.Empty;
    }
}
