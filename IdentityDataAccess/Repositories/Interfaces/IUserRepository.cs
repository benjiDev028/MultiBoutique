using IdentityDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username);
        Task<bool> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> UpdatePasswordAsync(Guid id, byte[] hashPassword, byte[] saltPassword);
        Task DeleteAsync(Guid id);



    }
}
