using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Responses
{
    public class AuthResponse
    {
        public required UserResponse User { get; init; } = null!;
        public required string Token { get; init; } = null!;
    }
}
