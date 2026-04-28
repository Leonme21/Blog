using PersonalBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario?> GetByNombreUsuarioAsync(string nombreusuario);
        Task AddAsync(Usuario usuario);
        Task<bool> ExistsByEmailAsync(string email);
        Task<Usuario?> GetByIdAsync(int id);
    }
}
