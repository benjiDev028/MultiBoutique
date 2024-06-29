using AutoMapper;
using IdentityBusinessLogic.Exceptions;
using IdentityBusiniessLogic.DTO;
using IdentityBusiniessLogic.Services.Interfaces;
using IdentityDataAccess.Entities;
using IdentityDataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityBusiniessLogic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async  Task<bool> CreateAsync(UserDto user)
        {
            var UserToCreate = _mapper.Map<User>(user);
            var UsernameVerified = await _userRepository.GetByUsernameAsync(user.Username);
            var EmailVerified = await _userRepository.GetByEmailAsync(user.Email);
            if (UsernameVerified != null) 
            {
                throw new AlreadyExistException("username already exists");
            
            }
            if (EmailVerified != null)
            {

                throw new AlreadyExistException("email already exits");
            }
            var IsCreated = await _userRepository.CreateAsync(UserToCreate);
            return IsCreated;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var UserDeleted = await _userRepository.GetByIdAsync(id);
            if (UserDeleted == null)
            {
                throw new NotFoundException("there is not exost user with this Id");
            }
            await _userRepository.DeleteAsync(UserDeleted.UserId);
            return true;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var Users = await _userRepository.GetAllAsync();
            if(Users  == null)
            {
                throw new NotFoundException("no users found");
            }
            return  _mapper.Map<List<UserDto>>(Users);
        }

        public  async Task<UserDto> GetByEmailAsync(string email)
        {
            
            var User = await _userRepository.GetByEmailAsync(email);
            if(User == null)
            {
                throw new NotFoundException(" there is not user with this email");
            }
            return _mapper.Map<UserDto>(User);
        }

        public  async Task<UserDto> GetByIdAsync(Guid id)
        {
            var User = await _userRepository.GetByIdAsync(id);
            if (User == null)
            {
                throw new NotFoundException(" there is not user with this Id");
            }
            return _mapper.Map<UserDto>(User);
        }

        public async Task<UserDto> GetByUsernameAsync(string username)
        {
            var User = await _userRepository.GetByUsernameAsync(username);
            if (User == null)
            {
                throw new NotFoundException(" there is not user with this username");
            }
            return _mapper.Map<UserDto>(User);
        }

        public Task<UserDto> UpdateAsync(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePasswordAsync(Guid id, byte[] hashPassword, byte[] saltPassword)
        {
            throw new NotImplementedException();
        }
    }
}
