using devtips_backend.Domain.Interfaces;
using devtips_backend.Domain.Requests;
using devtips_backend.Domain.Responses;
using devtips_backend.Infrastructure.Interfaces;
using devtips_backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserResponse(u)).ToList();
        }

        public async Task<UserResponse> GetUserById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id) ?? throw new Exception("User not found");
            return new UserResponse(user);
        }
    }
}
