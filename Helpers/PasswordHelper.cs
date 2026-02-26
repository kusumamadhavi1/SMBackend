using System.Security.Cryptography;
using System.Text;

namespace StudentPR.Helpers
{
    public static class PasswordHelper
    {
        // HASH PASSWORD
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();

            var bytes =
                Encoding.UTF8.GetBytes(password);

            var hash =
                sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        // VERIFY PASSWORD (LOGIN)
        public static bool VerifyPassword(
            string enteredPassword,
            string storedHash)
        {
            var hash = HashPassword(enteredPassword);

            return hash == storedHash;
        }
    }
}
