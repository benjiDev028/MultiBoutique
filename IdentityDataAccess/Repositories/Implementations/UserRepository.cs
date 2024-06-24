using IdentityDataAccess.Entities;
using IdentityDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDataAccess.Repositories.Implementations
{
    internal class UserRepository : IUserRepository
    {
        private readonly UserContext _UserContext;

        public UserRepository(UserContext userContext)
        {
            _UserContext = userContext;
        }
        public  async Task<bool> CreateAsync(User user)
        {
            _UserContext.Users.Add(user);
            await _UserContext.SaveChangesAsync();
            return true;          
        }

        public  async Task DeleteAsync(Guid id)
        {
            var DeletedUser = await _UserContext.Users.FindAsync(id);
            _UserContext.Users.Remove(DeletedUser);
            await _UserContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _UserContext
                .Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
           return   await _UserContext.Users.Where
                (u => u.Email.Equals(email))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _UserContext.Users.Where
                (u => u.UserId.Equals(id))
                .AsNoTracking()
                .FirstOrDefaultAsync();

        }

        public async  Task<User?> GetByUsernameAsync(string username)
        {
            return await _UserContext.Users.Where
                 (u => u.Username.Equals(username))
                 .AsNoTracking()
                 .FirstOrDefaultAsync();
        }

        public  async Task<User> UpdateAsync(User user)
        {
            var UpdatedUser = await _UserContext.Users.Where
                (u => u.UserId.Equals(user.UserId))
                .FirstOrDefaultAsync();

            UpdatedUser.FirstName = user.FirstName;
            UpdatedUser.LastName = user.LastName;
            UpdatedUser.Email = user.Email;
            UpdatedUser.UserRole = user.UserRole;
            await _UserContext.SaveChangesAsync();

            return UpdatedUser;
        }

        public Task<bool> UpdatePasswordAsync(Guid id, byte[] hashPassword, byte[] saltPassword)
        {
            throw new NotImplementedException();
        }
    }
}
