using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDataAccess.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Role UserRole { get; set; }
        public Guid? BoutiqueId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public int ConfirmationCode { get; set; }
    }

    public enum Role
    {
        Client,
        Gerante,
        SuperAdmin
    }


}
}
