using System;
using System.Security.Cryptography;
using System.Text;

namespace MyAdsApi.Services
{
    public class PasswordHashingService
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert hashed bytes to string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInputPassword = HashPassword(password);
            return string.Equals(hashedInputPassword, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
