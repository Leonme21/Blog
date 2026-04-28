using Microsoft.Extensions.Configuration;
using PersonalBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Infrastructure.Persistence
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher _passwordHasher;

        public DbInitializer(ApplicationDbContext context, IConfiguration configuration, IPasswordHasher passwordHasher)
        {
            _context = context;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();
            if (_context.Usuarios.Any()) return;

            var userName = _configuration["AdminUser:UserName"];
            var email = _configuration["AdminUser:Email"];
            var password = _configuration["AdminUser:Password"];

            var admin = new Domain.Entities.Usuario
            {
                Nombre = "Administrador",
                NombreUsuario = userName!,
                Email = email!,
                Rol = Domain.Enums.Rol.Admin,
                
                Contraseña = _passwordHasher.HashContraseña(password!),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Usuarios.Add(admin);
            _context.SaveChanges();
        }
    }
}