using devtips_backend.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResponse>> GetRolesAsync();
    }
}
