using devtips_backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Responses
{
    public class RoleResponse
    {
        public RoleResponse(Role role)
        {
            Type = role.Type.ToString();
        }

        public string Type { get; set; }
    }
}
