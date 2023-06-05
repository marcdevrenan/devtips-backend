using devtips_backend.Domain.Requests;
using devtips_backend.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<UserResponse> Register(RegisterUserRequest request);
        Task<AuthResponse> Login(LoginUserRequest request);
    }
}
