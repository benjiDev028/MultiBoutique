using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityBusiniessLogic.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int ConfirmationCode { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string SecretWord { get; set; } = string.Empty;
    }
}
