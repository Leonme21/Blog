using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Infrastructure.Persistence;
using PersonalBlog.Infrastructure.Repositories;
using PersonalBlog.Infrastructure.Security;

namespace PersonalBlog.Infrastructure
{
    public static class DependencyInjection { 
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IPasswordHasher, BCwordHasher>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<DbInitializer>();

            return services;
        }
    }
}
