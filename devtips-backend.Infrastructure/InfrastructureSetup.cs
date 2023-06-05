using devtips_backend.Infrastructure.Contexts;
using devtips_backend.Infrastructure.Interfaces;
using devtips_backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Infrastructure
{
    public static class InfrastructureSetup
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDb");
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
