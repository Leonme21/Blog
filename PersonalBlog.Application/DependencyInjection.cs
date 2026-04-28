using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Application.Interfaces;
using PersonalBlog.Application.Services;

namespace PersonalBlog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Aquí puedes registrar tus servicios de aplicación
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticuloService, ArticuloService>();
            // Agrega más servicios según sea necesario
            return services;
        }
    }
}
