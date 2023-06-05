using devtips_backend.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Requests
{
    public class RegisterUserRequest : LoginUserRequest
    {
        public new string Name { get; set; } = null!;
        public new string Email { get; set; } = null!;
        // public RoleType Role { get; set; }
    }
}
