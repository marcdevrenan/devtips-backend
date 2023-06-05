using devtips_backend.Domain.Interfaces;
using devtips_backend.Infrastructure.Models;
using devtips_backend.Domain.Requests;
using devtips_backend.Domain.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devtips_backend.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using devtips_backend.Infrastructure.Enums;

namespace devtips_backend.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository,  IRoleRepository roleRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
        }

        public async Task<AuthResponse> Login(LoginUserRequest request)
        {
            var user = await GetUserByEmail(request)
                ?? throw new Exception("Login error");

            ValidatePassword(user, request);
            return new AuthResponse
            {
                User = new UserResponse(user),
                Token = GenerateToken(user)
            };
        }

        public async Task<UserResponse> Register(RegisterUserRequest request)
        {
            await ValidateRegisterRequest(request);
            var role = await _roleRepository.GetByTypeAsync(RoleType.Guest)
                ?? throw new Exception();

            var user = await CreateUser(request, role);
            return new UserResponse(user);
        }

        private async Task<User> CreateUser(RegisterUserRequest request, Role role)
        {
            CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = role
            };

            return await _userRepository.CreateAsync(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        } 

        private async Task ValidateRegisterRequest(RegisterUserRequest request)
        {
            if (await _userRepository.GetByEmailAsync(request.Email) is not null)
                throw new Exception($"User with Email {request.Email} already exists");
        }

        private async Task<User?> GetUserByEmail(LoginUserRequest request)
        {
            return await _userRepository.GetByEmailAsync(request.Email!);
        }

        private void ValidatePassword(User user, LoginUserRequest request)
        {
            if (string.IsNullOrEmpty(request.Password))
                throw new Exception("Password is required");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    throw new Exception("Invalid password");
            }
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Authentication:ApiKey"]!);
            var claims = new List<Claim>
            {
                new Claim("uid", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            if (user.Role is not null)
                claims.Add(new Claim(ClaimTypes.Role, user.Role!.Type.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
