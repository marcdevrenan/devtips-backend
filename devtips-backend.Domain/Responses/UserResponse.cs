using devtips_backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Responses
{
    public class UserResponse
    {
        public UserResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Role = user.Role is null ? null : new RoleResponse(user.Role);
            Posts = user.Posts?.Select(p => new PostResponse(p)).ToList();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public RoleResponse? Role { get; set; }
        public List<PostResponse>? Posts { get; set; }
    }
}
