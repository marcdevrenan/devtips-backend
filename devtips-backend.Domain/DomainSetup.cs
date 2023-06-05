using devtips_backend.Domain.Interfaces;
using devtips_backend.Domain.Services;
using devtips_backend.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain
{
    public static class DomainSetup
    {
        public static void ConfigureDomain(this IServiceCollection services)
        {
            services.ConfigureInfrastructure();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
