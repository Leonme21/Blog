using PersonalBlog.Domain.Common;
using PersonalBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string NombreUsuario { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public Rol Rol { get; set; } = Rol.User;
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();

    }
}
