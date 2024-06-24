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
        Task<User> GetByIdAsync(Guid id);
        Task <List<User>> GetAllAsync();
        Task DeleteAsync(Guid id);


    }
}
