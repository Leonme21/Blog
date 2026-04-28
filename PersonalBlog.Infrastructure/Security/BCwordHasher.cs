using PersonalBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace PersonalBlog.Infrastructure.Security
{
    public class BCwordHasher : IPasswordHasher
    {
        public string HashContraseña(string contraseña)
        {
            return BC.HashPassword(contraseña);
        }

        public bool VerificacionContraseña(string contraseña, string hashedContraseña)
        {
            return BC.Verify(contraseña, hashedContraseña);
        }
    }
}

