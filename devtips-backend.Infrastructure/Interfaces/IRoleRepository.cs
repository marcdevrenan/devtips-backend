using devtips_backend.Infrastructure.Enums;
using devtips_backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Infrastructure.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role?> GetByTypeAsync(RoleType type);
    }
}
