using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Domain.Interfaces
{
    public interface IPasswordHasher
    {
        string HashContraseña(string contraseña);
        bool VerificacionContraseña(string contraseña, string hashedContraseña);
    }
}
