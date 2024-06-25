using IdentityBusiniessLogic.DTO;
using IdentityDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityBusiniessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> GetByEmailAsync(string email);
        Task<UserDto> GetByUsernameAsync(string username);
        Task<bool> CreateAsync(UserDto user);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<bool> UpdatePasswordAsync(Guid id, byte[] hashPassword, byte[] saltPassword);
        Task<bool> DeleteAsync(Guid id);
    }
}
