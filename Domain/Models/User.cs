using Domain.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string  Email { get; set; }
        public DateTime CreatedAt { get; set; }

        private User(string username, string email)
        {
            Username = username;
            Email = email;
            CreatedAt = DateTime.Now;
        }

        public static User Create(string username, string password, string email)
        {
            ValidatePassword(password);
            var user = new User(username,email);
            user.SetPassword(password);
            return user;
        }

        private void SetPassword(string planePassword)
        {
            using (var sha256 = SHA256.Create())
            {
                PasswordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(planePassword));
            }
        }

        private static void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                throw new BusinessRuleValidationException("La contraseña es inválida. Debe tener al menos 8 caracteres.");
            }
        }
    }
}
