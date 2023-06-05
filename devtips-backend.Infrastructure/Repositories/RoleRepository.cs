using devtips_backend.Infrastructure.Contexts;
using devtips_backend.Infrastructure.Enums;
using devtips_backend.Infrastructure.Interfaces;
using devtips_backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role?> GetByTypeAsync(RoleType type)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Type == type);
        }
    }
}
