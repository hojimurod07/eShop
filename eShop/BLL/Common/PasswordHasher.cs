using System.Security.Cryptography;
using System.Text;

namespace eShop.BLL.Common
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                return HashPassword(password) == hashedPassword;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error verifying password: {ex.Message}");
                return false;
            }
        }
    }
}
